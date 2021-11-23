using System.Xml;


namespace xmlPars
{
    public class NamespaceIgnorantXmlTextReader : XmlTextReader
    {
        public NamespaceIgnorantXmlTextReader(System.IO.TextReader reader) : base(reader) { }
        public override string NamespaceURI
        {
            get { return ""; }
        }
    }
    public class contract
    {
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]

        public partial class export
        {
            private exportContract contractField = new exportContract();

            public exportContract contract
            {
                get { return this.contractField; }
                set { if (value != null) this.contractField = value; }
            }
        }

        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]

        public partial class exportContract
        {
            private string contractSbjField;
            public string contractSubject
            {
                get { return this.contractSbjField; }
                set { this.contractSbjField = value; }
            }

            private System.DateTime protocolDateField;
            [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
            public System.DateTime protocolDate
            {
                get { return this.protocolDateField; }
                set { this.protocolDateField = value; }
            }

            private System.DateTime signDateField;
            [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
            public System.DateTime signDate
            {
                get { return this.signDateField; }
                set { this.signDateField = value; }
            }

            private string numberField;
            public string number
            {
                get { return this.numberField; }
                set { this.numberField = value; }
            }

            private exportContractCustomer customerField = new exportContractCustomer();
            public exportContractCustomer customer
            {
                get { return this.customerField; }
                set { if (value != null) this.customerField = value; }
            }
        }

        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class exportContractCustomer
        {
            private ulong regnumField;
            public ulong regNum
            {
                get { return this.regnumField; }
                set { this.regnumField = value; }
            }

            private string shortNameField;
            public string shortName
            {
                get { return this.shortNameField; }
                set { this.shortNameField = value; }
            }        
        }
        }
}

