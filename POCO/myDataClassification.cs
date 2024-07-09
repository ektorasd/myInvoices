using System;
using System.Collections.Generic;
using System.Text;

namespace myInvoices
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Classification
    {

        private ClassificationVatCategory[] vatCategoryField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("VatCategory")]
        public ClassificationVatCategory[] VatCategory
        {
            get
            {
                return this.vatCategoryField;
            }
            set
            {
                this.vatCategoryField = value;
            }
        }

    }

   


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ClassificationVatCategory
    {

        private int vatRateField;

        private ClassificationVatCategoryIncomeClassification[] incomeClassificationField;

        private ClassificationVatCategoryExpensesClassification[] expensesClassificationField;

        /// <remarks/>
        public int VatRate
        {
            get
            {
                return this.vatRateField;
            }
            set
            {
                this.vatRateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("IncomeClassification")]
        public ClassificationVatCategoryIncomeClassification[] IncomeClassification
        {
            get
            {
                return this.incomeClassificationField;
            }
            set
            {
                this.incomeClassificationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ExpensesClassification")]
        public ClassificationVatCategoryExpensesClassification[] ExpensesClassification
        {
            get
            {
                return this.expensesClassificationField;
            }
            set
            {
                this.expensesClassificationField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ClassificationVatCategoryIncomeClassification
    {

        private string categoryField;

        private string typeField;

        private decimal amountField;

        /// <remarks/>
        public string Category
        {
            get
            {
                return this.categoryField;
            }
            set
            {
                this.categoryField = value;
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
        public decimal Amount
        {
            get
            {
                return this.amountField;
            }
            set
            {
                this.amountField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ClassificationVatCategoryExpensesClassification
    {

        private string categoryField;

        private string typeField;

        private decimal amountField;

        /// <remarks/>
        public string Category
        {
            get
            {
                return this.categoryField;
            }
            set
            {
                this.categoryField = value;
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
        public decimal Amount
        {
            get
            {
                return this.amountField;
            }
            set
            {
                this.amountField = value;
            }
        }
    }
}
