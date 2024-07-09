using System;
using System.Collections.Generic;

namespace myInvoices
{
    public class SimpleInvoice
    {
        public Guid SupplierUID { get; set; }
        public string DocumentTypeDescription { get; set; }
        public string IssuerVat { get; set; }
        public string IssuerName { get; set; }
        public string IssuerAddress { get; set; }
        public string IssuerCityName { get; set; }
        public string IssuerPostalCode { get; set; }
        public string CustomerVat { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerCityName { get; set; }
        public string CustomerPostalCode { get; set; }
        public string CustomerCountry { get; set; }
        public string CustomerEmail { get; set; }
        public string CreditTerms { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string DeliveryAddress { get; set; }
        public string DeliveryCityName { get; set; }
        public string DeliveryPostalCode { get; set; }
        public string DeliveryCountry { get; set; }
        public string AadeCategory { get; set; }
        public string Series { get; set; }
        public int InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public List<SimpleInvoiceLine> Lines { get; set; } = new List<SimpleInvoiceLine>();
    }

    public class SimpleInvoiceLine
    {
        public int LineID { get; set; }
        public string Description { get; set; }
        public string CpvCode { get; set; }
        public decimal VatPercent { get; set; }
        public string PeppolVatClassification
        {
            get { return VatPercent == 0 ? "E" : "S"; }
        }
        public int VatCategory { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }
        public decimal NetAmount { get; set; }
        public decimal VatAmount { get; set; }
        public string ClassificationType { get; set; }
        public string ClassificationCategory { get; set; }
    }
}
