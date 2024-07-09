namespace myInvoices
{
 
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
public partial class Signature
{

    private SignatureSignedInfo signedInfoField;

    private string signatureValueField;

    private SignatureKeyInfo keyInfoField;

    /// <remarks/>
    public SignatureSignedInfo SignedInfo
    {
        get
        {
            return this.signedInfoField;
        }
        set
        {
            this.signedInfoField = value;
        }
    }

    /// <remarks/>
    public string SignatureValue
    {
        get
        {
            return this.signatureValueField;
        }
        set
        {
            this.signatureValueField = value;
        }
    }

    /// <remarks/>
    public SignatureKeyInfo KeyInfo
    {
        get
        {
            return this.keyInfoField;
        }
        set
        {
            this.keyInfoField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
public partial class SignatureSignedInfo
{

    private SignatureSignedInfoCanonicalizationMethod canonicalizationMethodField;

    private SignatureSignedInfoSignatureMethod signatureMethodField;

    private SignatureSignedInfoReference referenceField;

    /// <remarks/>
    public SignatureSignedInfoCanonicalizationMethod CanonicalizationMethod
    {
        get
        {
            return this.canonicalizationMethodField;
        }
        set
        {
            this.canonicalizationMethodField = value;
        }
    }

    /// <remarks/>
    public SignatureSignedInfoSignatureMethod SignatureMethod
    {
        get
        {
            return this.signatureMethodField;
        }
        set
        {
            this.signatureMethodField = value;
        }
    }

    /// <remarks/>
    public SignatureSignedInfoReference Reference
    {
        get
        {
            return this.referenceField;
        }
        set
        {
            this.referenceField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
public partial class SignatureSignedInfoCanonicalizationMethod
{

    private string algorithmField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Algorithm
    {
        get
        {
            return this.algorithmField;
        }
        set
        {
            this.algorithmField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
public partial class SignatureSignedInfoSignatureMethod
{

    private string algorithmField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Algorithm
    {
        get
        {
            return this.algorithmField;
        }
        set
        {
            this.algorithmField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
public partial class SignatureSignedInfoReference
{

    private SignatureSignedInfoReferenceTransform[] transformsField;

    private SignatureSignedInfoReferenceDigestMethod digestMethodField;

    private string digestValueField;

    private string uRIField;

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Transform", IsNullable = false)]
    public SignatureSignedInfoReferenceTransform[] Transforms
    {
        get
        {
            return this.transformsField;
        }
        set
        {
            this.transformsField = value;
        }
    }

    /// <remarks/>
    public SignatureSignedInfoReferenceDigestMethod DigestMethod
    {
        get
        {
            return this.digestMethodField;
        }
        set
        {
            this.digestMethodField = value;
        }
    }

    /// <remarks/>
    public string DigestValue
    {
        get
        {
            return this.digestValueField;
        }
        set
        {
            this.digestValueField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string URI
    {
        get
        {
            return this.uRIField;
        }
        set
        {
            this.uRIField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
public partial class SignatureSignedInfoReferenceTransform
{

    private string algorithmField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Algorithm
    {
        get
        {
            return this.algorithmField;
        }
        set
        {
            this.algorithmField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
public partial class SignatureSignedInfoReferenceDigestMethod
{

    private string algorithmField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Algorithm
    {
        get
        {
            return this.algorithmField;
        }
        set
        {
            this.algorithmField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
public partial class SignatureKeyInfo
{

    private SignatureKeyInfoX509Data x509DataField;

    /// <remarks/>
    public SignatureKeyInfoX509Data X509Data
    {
        get
        {
            return this.x509DataField;
        }
        set
        {
            this.x509DataField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
public partial class SignatureKeyInfoX509Data
{

    private string x509CertificateField;

    /// <remarks/>
    public string X509Certificate
    {
        get
        {
            return this.x509CertificateField;
        }
        set
        {
            this.x509CertificateField = value;
        }
    }
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.unece.org/cefact/namespaces/StandardBusinessDocumentHeader")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.unece.org/cefact/namespaces/StandardBusinessDocumentHeader", IsNullable = false, ElementName = "StandardBusinessDocument")]
public partial class StandardBusinessDocument : StandardBusinessDocumentBase
{

    private CreditNoteType[] creditNoteField;

    private ApplicationResponseType applicationResponseField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("CreditNote", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CreditNote-2")]
    public CreditNoteType[] CreditNote
    {
        get
        {
            return this.creditNoteField;
        }
        set
        {
            this.creditNoteField = value;
        }
    }
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ApplicationResponse", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:ApplicationResponse-2")]
    public ApplicationResponseType ApplicationResponse
    {
        get
        {
            return this.applicationResponseField;
        }
        set
        {
            this.applicationResponseField = value;
        }
    }

}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.unece.org/cefact/namespaces/StandardBusinessDocumentHeader")]
public partial class StandardBusinessDocumentStandardBusinessDocumentHeader
{

    private string headerVersionField;

    private StandardBusinessDocumentStandardBusinessDocumentHeaderSender senderField;

    private StandardBusinessDocumentStandardBusinessDocumentHeaderReceiver receiverField;

    private StandardBusinessDocumentStandardBusinessDocumentHeaderDocumentIdentification documentIdentificationField;

    private StandardBusinessDocumentStandardBusinessDocumentHeaderScope[] businessScopeField;

    /// <remarks/>
    public string HeaderVersion
    {
        get
        {
            return this.headerVersionField;
        }
        set
        {
            this.headerVersionField = value;
        }
    }

    /// <remarks/>
    public StandardBusinessDocumentStandardBusinessDocumentHeaderSender Sender
    {
        get
        {
            return this.senderField;
        }
        set
        {
            this.senderField = value;
        }
    }

    /// <remarks/>
    public StandardBusinessDocumentStandardBusinessDocumentHeaderReceiver Receiver
    {
        get
        {
            return this.receiverField;
        }
        set
        {
            this.receiverField = value;
        }
    }

    /// <remarks/>
    public StandardBusinessDocumentStandardBusinessDocumentHeaderDocumentIdentification DocumentIdentification
    {
        get
        {
            return this.documentIdentificationField;
        }
        set
        {
            this.documentIdentificationField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Scope", IsNullable = false)]
    public StandardBusinessDocumentStandardBusinessDocumentHeaderScope[] BusinessScope
    {
        get
        {
            return this.businessScopeField;
        }
        set
        {
            this.businessScopeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.unece.org/cefact/namespaces/StandardBusinessDocumentHeader")]
public partial class StandardBusinessDocumentStandardBusinessDocumentHeaderSender
{

    private StandardBusinessDocumentStandardBusinessDocumentHeaderSenderIdentifier identifierField;

    /// <remarks/>
    public StandardBusinessDocumentStandardBusinessDocumentHeaderSenderIdentifier Identifier
    {
        get
        {
            return this.identifierField;
        }
        set
        {
            this.identifierField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.unece.org/cefact/namespaces/StandardBusinessDocumentHeader")]
public partial class StandardBusinessDocumentStandardBusinessDocumentHeaderSenderIdentifier
{

    private string authorityField;

    private string valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Authority
    {
        get
        {
            return this.authorityField;
        }
        set
        {
            this.authorityField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.unece.org/cefact/namespaces/StandardBusinessDocumentHeader")]
public partial class StandardBusinessDocumentStandardBusinessDocumentHeaderReceiver
{

    private StandardBusinessDocumentStandardBusinessDocumentHeaderReceiverIdentifier identifierField;

    /// <remarks/>
    public StandardBusinessDocumentStandardBusinessDocumentHeaderReceiverIdentifier Identifier
    {
        get
        {
            return this.identifierField;
        }
        set
        {
            this.identifierField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.unece.org/cefact/namespaces/StandardBusinessDocumentHeader")]
public partial class StandardBusinessDocumentStandardBusinessDocumentHeaderReceiverIdentifier
{

    private string authorityField;

    private string valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Authority
    {
        get
        {
            return this.authorityField;
        }
        set
        {
            this.authorityField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.unece.org/cefact/namespaces/StandardBusinessDocumentHeader")]
public partial class StandardBusinessDocumentStandardBusinessDocumentHeaderDocumentIdentification
{

    private string standardField;

    private string typeVersionField;

    private string instanceIdentifierField;

    private string typeField;

    private string creationDateAndTimeField;

    /// <remarks/>
    public string Standard
    {
        get
        {
            return this.standardField;
        }
        set
        {
            this.standardField = value;
        }
    }

    /// <remarks/>
    public string TypeVersion
    {
        get
        {
            return this.typeVersionField;
        }
        set
        {
            this.typeVersionField = value;
        }
    }

    /// <remarks/>
    public string InstanceIdentifier
    {
        get
        {
            return this.instanceIdentifierField;
        }
        set
        {
            this.instanceIdentifierField = value;
        }
    }

    /// <remarks/>
    public string Type
    {
        get
        {
            return this.typeField;
        }
        set
        {
            this.typeField = value;
        }
    }

    /// <remarks/>
    public string CreationDateAndTime
    {
        get
        {
            return this.creationDateAndTimeField;
        }
        set
        {
            this.creationDateAndTimeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.unece.org/cefact/namespaces/StandardBusinessDocumentHeader")]
public partial class StandardBusinessDocumentStandardBusinessDocumentHeaderScope
{

    private string typeField;

    private string instanceIdentifierField;

    /// <remarks/>
    public string Type
    {
        get
        {
            return this.typeField;
        }
        set
        {
            this.typeField = value;
        }
    }

    /// <remarks/>
    public string InstanceIdentifier
    {
        get
        {
            return this.instanceIdentifierField;
        }
        set
        {
            this.instanceIdentifierField = value;
        }
    }
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.unece.org/cefact/namespaces/StandardBusinessDocumentHeader")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.unece.org/cefact/namespaces/StandardBusinessDocumentHeader", IsNullable = false, ElementName = "StandardBusinessDocument")]
public partial class StandardBusinessDocumentBase
{
    private StandardBusinessDocumentStandardBusinessDocumentHeader standardBusinessDocumentHeaderField;

    private InvoiceType[] invoiceField;

    private MyDATA.InvoicesDoc invoicesDocField;

    private Classification classificationField;

    private Signature signatureField;


    /// <remarks/>
    /// 
    [System.Xml.Serialization.XmlElementAttribute("StandardBusinessDocumentHeader", Namespace = "http://www.unece.org/cefact/namespaces/StandardBusinessDocumentHeader")]
    public StandardBusinessDocumentStandardBusinessDocumentHeader StandardBusinessDocumentHeader
    {
        get
        {
            return this.standardBusinessDocumentHeaderField;
        }
        set
        {
            this.standardBusinessDocumentHeaderField = value;
        }
    }
    [System.Xml.Serialization.XmlElementAttribute("Invoice", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2")]
    public InvoiceType[] Invoice
    {
        get
        {
            return this.invoiceField;
        }
        set
        {
            this.invoiceField = value;
        }
    }

    /// <remarks/>
    public MyDATA.InvoicesDoc InvoicesDoc
    {
        get
        {
            return this.invoicesDocField;
        }
        set
        {
            this.invoicesDocField = value;
        }
    }

    public Classification Classification
    {
        get
        {
            return this.classificationField;
        }
        set
        {
            this.classificationField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public Signature Signature
    {
        get
        {
            return this.signatureField;
        }
        set
        {
            this.signatureField = value;
        }
    }
}
}