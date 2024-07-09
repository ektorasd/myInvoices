using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace myInvoices
{
    public class OrianMyDATAResponse
    {
        public bool isSuccess { get; set; }
        public string AuthenticationCode { get; set; }
        public string InvoiceMARK { get; set; }
        public string InvoiceUID { get; set; }
        public string QRCode { get; set; }
        public string VoucherName { get; set; }
        public string invoiceID { get; set; }
        public string InvoiceUrl { get; set; }
        public string ProviderUrl { get; set; }
        public DateTime IssueDate { get; set; }
        public int StatusCode { get; set; }
        public string StatusText { get; set; }
        public List<ValidationMessage> validationMessages { get; set; } =
            new List<ValidationMessage>();
        public string fileName { get; set; }
        public PaymentSigned PaymentInfo { get; set; }
    }

    public class ValidationMessage
    {
        public string identificationID { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public string location { get; set; }
    }

    public class EInvoiceBody
    {
        public string InvoiceID { get; set; }
        public string Data { get; set; }
        public DateTime ActualIssueDate { get; set; }
        public int OfflineMode { get; set; }
        public bool ConcurrentPayment { get; set; }
        public PaymentRequest PaymentRequest { get; set; }
    }

    public class PaymentRequest
    {
        public Guid? SupplierUid { get; set; }
        public decimal? Amount { get; set; }
        public string TerminalID { get; set; }
        public int Instalments { get; set; }
        public bool PreloadTransaction { get; set; }
        public string InitialTransactionId { get; set; }
    }

    public class PaymentSigned
    {
        public string PaymentID { get; set; }
        public bool ConcurrentPayment { get; set; }
        public string PaymentSignature { get; set; }
        public decimal PaymentAmount { get; set; }
        public decimal NetValue { get; set; }
        public decimal VatValue { get; set; }
        public DateTime? SignatureCreateDate { get; set; }
        public string UID { get; set; }
        public string VoucherID { get; set; }
        public string Mark { get; set; }
        public string TerminalID { get; set; }
        public string VoucherName { get; set; }
        public bool Refund { get; set; }
        public int Instalmments { get; set; }
        public bool PreloadTransaction { get; set; }
        public string InitialTransactionId { get; set; }
    }

    public class PaymentCompleted
    {
        public string PaymentID { get; set; }
        public string UniquePaymentID { get; set; }
        public decimal ActualAmount { get; set; }
    }

    public class EInvoiceResponse
    {
        public string VoucherName { get; set; }
        public string invoiceID { get; set; }
        public string invoiceUrl { get; set; }
        public string providerUrl { get; set; }
        public string issueDate { get; set; }
        public string authenticationCode { get; set; }
        public string mark { get; set; }
        public string uid { get; set; }
        public int statusCode { get; set; }
        public string statusText { get; set; }
        public List<ValidationMessage> validationMessages { get; set; }
        public string fileName { get; set; }
        public Byte[] qrCode { get; set; }
    }

    public enum AadeTaxesCategory
    {
        Withheld = 1,
        Fees = 2,
        OtherTaxes = 3,
        StampDuty = 4,
        Deductions = 5,
        incomes = 6,
        Expenses = 7
    }

    public enum WithheldTaxCategories
    {
        [Description("Περιπτ. β’- Τόκοι - 15%")]
        Item1 = 1,

        [Description("Περιπτ. γ’ - Δικαιώματα - 20%")]
        Item2 = 2,

        [Description("Περιπτ. δ’ -  Αμοιβές Συμβουλών Διοίκησης - 20%")]
        Item3 = 3,

        [Description("Περιπτ. δ’ -  Τεχνικά Έργα - 3%")]
        Item4 = 4,

        [Description("Υγρά καύσιμα και προϊόντα καπνοβιομηχανίας 1%")]
        Item5 = 5,

        [Description("Λοιπά Αγαθά 4%")]
        Item6 = 6,

        [Description("Παροχή Υπηρεσιών 8%")]
        Item7 = 7,

        [Description(
            "Προκαταβλητέος Φόρος Αρχιτεκτόνων και Μηχανικών επί Συμβατικών Αμοιβών, για Εκπόνηση Μελετών και Σχεδίων 4%"
        )]
        Item8 = 8,

        [Description(
            "Προκαταβλητέος Φόρος Αρχιτεκτόνων και Μηχανικών επί Συμβατικών Αμοιβών, που αφορούν οποιασδήποτε άλλης φύσης έργα 10%"
        )]
        Item9 = 9,

        [Description("Προκαταβλητέος Φόρος στις Αμοιβές Δικηγόρων 15%")]
        Item10 = 10,

        [Description("Παρακράτηση Φόρου Μισθωτών Υπηρεσιών  παρ. 1 αρ. 15 ν. 4172/2013")]
        Item11 = 11,

        [Description(
            "Παρακράτηση Φόρου Μισθωτών Υπηρεσιών  παρ. 2 αρ. 15 ν. 4172/2013 - Αξιωματικών Εμπορικού Ναυτικού"
        )]
        Item12 = 12,

        [Description(
            "Παρακράτηση Φόρου Μισθωτών Υπηρεσιών παρ. 2 αρ. 15 ν. 4172/2013 - Κατώτερο Πλήρωμα Εμπορικού Ναυτικού"
        )]
        Item13 = 13,

        [Description("Παρακράτηση Ειδικής Εισφοράς Αλληλεγγύης")]
        Item14 = 14,

        [Description(
            "Παρακράτηση Φόρου Αποζημίωσης λόγω Διακοπής Σχέσης Εργασίας  παρ. 3 αρ. 15 ν. 4172/2013"
        )]
        Item15 = 15,

        [Description(
            "Παρακρατήσεις συναλλαγών αλλοδαπής βάσει συμβάσεων αποφυγής διπλής φορολογίας (Σ.Α.Δ.Φ.)"
        )]
        Item16 = 16,

        [Description("Λοιπές Παρακρατήσεις Φόρου")]
        Item17 = 17,

        [Description("Παρακράτηση Φόρου Μερίσματα περ.α παρ. 1 αρ. 64 ν. 4172/2013")]
        Item18 = 18
    }

    public enum OtherTaxesCategories
    {
        [Description("α1) ασφάλιστρα κλάδου πυρός 20%")]
        Item1 = 1,

        [Description("α2) ασφάλιστρα κλάδου πυρός 20%")]
        Item2 = 2,

        [Description("β) ασφάλιστρα κλάδου ζωής 4%")]
        Item3 = 3,

        [Description("γ) ασφάλιστρα λοιπών κλάδων 15%")]
        Item4 = 4,

        [Description("δ) απαλλασσόμενα φόρου ασφαλίστρων 0%")]
        Item5 = 5,

        [Description("Ξενοδοχεία 1-2 αστέρων 0,50 €")]
        Item6 = 6,

        [Description("Ξενοδοχεία 3 αστέρων 1,50 €")]
        Item7 = 7,

        [Description("Ξενοδοχεία 4 αστέρων 3,00 €")]
        Item8 = 8,

        [Description("Ξενοδοχεία 4 αστέρων 4,00 €")]
        Item9 = 9,

        [Description("Ενοικιαζόμενα - επιπλωμένα δωμάτια - διαμερίσματα 0,50 €")]
        Item10 = 10,

        [Description("Ειδικός Φόρος στις διαφημίσεις που προβάλλονται από την τηλεόραση (ΕΦΤΔ) 5%")]
        Item11 = 11,

        [Description(
            "3.1 Φόρος πολυτελείας 10% επί της φορολογητέας αξίας για τα ενδοκοινοτικώς αποκτούμενα και εισαγόμενα από τρίτες χώρες  10%"
        )]
        Item12 = 12,

        [Description(
            "3.2 Φόρος πολυτελείας 10% επί της τιμής πώλησης προ Φ.Π.Α. για τα εγχωρίως παραγόμενα είδη 10%"
        )]
        Item13 = 13,

        [Description("Δικαίωμα του Δημοσίου στα εισιτήρια των καζίνο (80% επί του εισιτηρίου)")]
        Item14 = 14,

        [Description("ασφάλιστρα κλάδου πυρός 20%")]
        Item15 = 15,

        [Description("Τελωνειακοί Δασμοί-Φόροι")]
        Item16 = 16,

        [Description("Λοιποί Φόροι")]
        Item17 = 17,

        [Description("Επιβαρύνσεις Λοιπών Φόρων")]
        Item18 = 18,

        [Description("ΕΦΚ")]
        Item19 = 19
    }

    public enum StampDutyCategories
    {
        [Description("Συντελεστής 1,2 %")]
        Item1 = 1,

        [Description("Συντελεστής  2,4 %")]
        Item2 = 2,

        [Description("Συντελεστής  3,6 %")]
        Item3 = 3,

        [Description("Λοιπές περιπτώσεις Χαρτοσήμου")]
        Item4 = 4
    }

    public enum FeesCategories
    {
        [Description("Για μηνιαίο λογαριασμό μέχρι και 50 ευρώ  12%")]
        Item1 = 1,

        [Description("Για μηνιαίο λογαριασμό από 50,01 μέχρι και 100 ευρώ 15%")]
        Item2 = 2,

        [Description("Για μηνιαίο λογαριασμό από 100,01 μέχρι και 150 ευρώ 18%")]
        Item3 = 3,

        [Description("Για μηνιαίο λογαριασμό από 150,01 ευρώ και άνω 20%")]
        Item4 = 4,

        [Description("Τέλος καρτοκινητής επί της αξίας του χρόνου ομιλίας (12%)")]
        Item5 = 5,

        [Description("Τέλος στη συνδρομητική τηλεόραση 10%")]
        Item6 = 6,

        [Description("Τέλος συνδρομητών σταθερής τηλεφωνίας 5%")]
        Item7 = 7,

        [Description(
            "Περιβαλλοντικό Τέλος & πλαστικής σακούλας ν. 2339/2001 αρ. 6α 0,07 ευρώ ανά τεμάχιο"
        )]
        Item8 = 8,

        [Description("Εισφορά δακοκτονίας 2%")]
        Item9 = 9,

        [Description("Λοιπά τέλη")]
        Item10 = 10,

        [Description("Τέλη Λοιπών Φόρων")]
        Item11 = 11,

        [Description("Εισφορά δακοκτονίας")]
        Item12 = 12,

        [Description("Για μηνιαίο λογαριασμό κάθε σύνδεσης (10%)")]
        Item13 = 13,

        [Description("Τέλος καρτοκινητής επί της αξίας του χρόνου ομιλίας (10%)")]
        Item14 = 14,

        [Description(
            "Τέλος κινητής και καρτοκινητής για φυσικά πρόσωπα ηλικίας 15 έως και 29 ετών (0%)"
        )]
        Item15 = 15,

        [Description("Εισφορά προστασίας περιβάλλοντος πλαστικών προϊόντων 0,04 λεπτά ανα τεμάχιο")]
        Item16 = 16,

        [Description("Τέλος ανακύκλωσης 0,08 λεπτά ανά τεμάχιο [άρθρο 80 ν. 4819/2021]")]
        Item17 = 17,

        [Description("Τέλος διαμονής παρεπιδημούντων")]
        Item18 = 18,

        [Description("Tέλος επί των ακαθάριστων εσόδων των εστιατορίων και συναφών καταστημάτων")]
        Item19 = 19,

        [Description("Τέλος επί των ακαθάριστων εσόδων των κέντρων διασκέδασης")]
        Item20 = 20,

        [Description("Τέλος επί των ακαθάριστων εσόδων των καζίνο")]
        Item21 = 21,

        [Description("Λοιπά τέλη επί των ακαθάριστων εσόδων")]
        Item22 = 22
    }

    public class SendFilePeppolResponse
    {
        public string InstanceIdentifier { get; set; }
        public bool Success { get; set; }
        public String AS4Status { get; set; }
        public String Message { get; set; }
    }

    public class ReceivedPeppol
    {
        public String _id { get; set; }
        public String sender { get; set; }
        public String receiver { get; set; }
        public String instanceIdentifier { get; set; }
        public String documentType { get; set; }
        public string messageCreationDate { get; set; }
        public string receivedDate { get; set; }
        public Boolean isProcessed { get; set; }
        public int size { get; set; }

        public byte[] message;
    }

    public class Credentials
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
