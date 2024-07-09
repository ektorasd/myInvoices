using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Reflection;
using System.Xml;
using System.IO;

namespace myInvoices
{
    public class Utils
    {
        public static string GetTaxesDescription (int AadeTaxesCategory, int? AadeTaxesSubCategory)
        {
            switch (AadeTaxesCategory)
            {
                case 1:
                    return "Παρακρατούμενοι Φόροι " + GetDescriptionFromEnumValue<WithheldTaxCategories>((WithheldTaxCategories)AadeTaxesSubCategory.Value);
                case 2:
                    return "Τέλη " + GetDescriptionFromEnumValue<FeesCategories>((FeesCategories)AadeTaxesSubCategory.Value);
                case 3:
                    return "Λοιποί Φόροι " + GetDescriptionFromEnumValue<OtherTaxesCategories>((OtherTaxesCategories)AadeTaxesSubCategory.Value);
                case 4:
                    return "Χαρτόσημο " + GetDescriptionFromEnumValue<StampDutyCategories>((StampDutyCategories)AadeTaxesSubCategory.Value);
                case 5:
                    return "Κρατήσεις Δημοσίου ";
            }
            return "";
        }
        public static string GetDescriptionFromEnumValue<T>(T pEnumVal)

        {
            Type type = pEnumVal.GetType();
            FieldInfo info = type.GetField(Enum.GetName(typeof(T), pEnumVal));
            System.ComponentModel.DescriptionAttribute att = (System.ComponentModel.DescriptionAttribute)info.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false)[0];
            //If there is an xmlattribute defined, return the name
            return att.Description;
        }
        public static string PrepareInvoiceDataXML<T>(T obj)
        {
            XmlSerializer serializer = null;
            var ov = new XmlAttributeOverrides();
            ov.Add(typeof(StandardBusinessDocumentBase), "InvoicesDoc", new XmlAttributes() { XmlElements = { createElements("InvoicesDoc", "http://www.aade.gr/myDATA/invoice/v1.0") } });
            serializer = new XmlSerializer(typeof(T), ov);            
            var ns=AddNamespaces();
            return SerializeToString(serializer, obj,ns);
        }
        public static string SerializeToString<T>(XmlSerializer serializer, T obj,XmlSerializerNamespaces ns){
            using (var memoryStream = new MemoryStream())
            using (var xmlWriter = XmlWriter.Create(memoryStream, new XmlWriterSettings { Encoding = new UTF8Encoding(false) }))
            {
                serializer.Serialize(xmlWriter, obj,ns);
                return Encoding.UTF8.GetString(memoryStream.ToArray());
            }
        }
        private static XmlElementAttribute createElements(string elementName, string ns)
        {
            var element = new XmlElementAttribute(elementName);
            element.Namespace = ns;
            return element;
        }
        private static XmlSerializerNamespaces AddNamespaces()
        {
            var ns = new XmlSerializerNamespaces();
            ns.Add("cbc", @"urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
            ns.Add("sac", @"urn:oasis:names:specification:ubl:schema:xsd:SignatureAggregateComponents-2");
            ns.Add("cac", @"urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");
            ns.Add("sig", @"urn:oasis:names:specification:ubl:schema:xsd:CommonSignatureComponents-2");
            ns.Add("ext", @"urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2");
            ns.Add("sgi", @"http://www.w3.org/2001/XMLSchema-instance");
            ns.Add("md", @"http://www.aade.gr/myDATA/invoice/v1.0");
            return ns;
        }
        public static T GetCode<T>(string value) {
            foreach (object o in System.Enum.GetValues(typeof(T))) {
                T enumValue = (T)o;
                if (GetXmlAttrNameFromEnumValue<T>(enumValue).Equals(value, StringComparison.OrdinalIgnoreCase)) {
                    return (T)o;
                }
            }

            throw new ArgumentException("No XmlEnumAttribute code exists for type " + typeof(T).ToString() + " corresponding to value of " + value);
        }
        public static string GetXmlAttrNameFromEnumValue<T>(T pEnumVal) {
            Type type = pEnumVal.GetType();
            FieldInfo info = type.GetField(Enum.GetName(typeof(T), pEnumVal));
            XmlEnumAttribute att = (XmlEnumAttribute)info.GetCustomAttributes(typeof(XmlEnumAttribute), false)[0];
            //If there is an xmlattribute defined, return the name

            return att.Name;
        }

    }
}
