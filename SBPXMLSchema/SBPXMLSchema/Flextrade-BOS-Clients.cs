﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.5466
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by xsd, Version=2.0.50727.3038.
// 
namespace SBPXMLSchema {
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class Clients {
        
        private object deactivateAllClientsField;
        
        private ClientRegistration[] registerField;
        
        private ClientSuspension[] suspendField;
        
        private ClientDeactivation[] deactivateField;
        
        private ClientLimits[] limitsField;
        
        private ProcessingMode processingModeField;
        
        private string brokerIDField;
        
        public Clients() {
            this.processingModeField = ProcessingMode.BatchInsertOrUpdate;
        }
        
        /// <remarks/>
        public object DeactivateAllClients {
            get {
                return this.deactivateAllClientsField;
            }
            set {
                this.deactivateAllClientsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Register")]
        public ClientRegistration[] Register {
            get {
                return this.registerField;
            }
            set {
                this.registerField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Suspend")]
        public ClientSuspension[] Suspend {
            get {
                return this.suspendField;
            }
            set {
                this.suspendField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Deactivate")]
        public ClientDeactivation[] Deactivate {
            get {
                return this.deactivateField;
            }
            set {
                this.deactivateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Limits")]
        public ClientLimits[] Limits {
            get {
                return this.limitsField;
            }
            set {
                this.limitsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(ProcessingMode.BatchInsertOrUpdate)]
        public ProcessingMode ProcessingMode {
            get {
                return this.processingModeField;
            }
            set {
                this.processingModeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string BrokerID {
            get {
                return this.brokerIDField;
            }
            set {
                this.brokerIDField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class MarginLimit {
        
        private long depositField;
        
        private decimal marginRatioField;
        
        private bool marginRatioFieldSpecified;
        
        public MarginLimit() {
            this.depositField = ((long)(0));
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(typeof(long), "0")]
        public long Deposit {
            get {
                return this.depositField;
            }
            set {
                this.depositField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal MarginRatio {
            get {
                return this.marginRatioField;
            }
            set {
                this.marginRatioField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MarginRatioSpecified {
            get {
                return this.marginRatioFieldSpecified;
            }
            set {
                this.marginRatioFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ClientLimits {
        
        private string branchIDField;
        
        private string clientCodeField;
        
        private long cashField;
        
        private MarginLimit marginField;
        
        private long maxCapitalBuyField;
        
        private bool maxCapitalBuyFieldSpecified;
        
        private long maxCapitalSellField;
        
        private bool maxCapitalSellFieldSpecified;
        
        private long totalTransactionField;
        
        private bool totalTransactionFieldSpecified;
        
        private long netTransactionField;
        
        private bool netTransactionFieldSpecified;
        
        public ClientLimits() {
            this.branchIDField = "1";
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="integer")]
        public string BranchID {
            get {
                return this.branchIDField;
            }
            set {
                this.branchIDField = value;
            }
        }
        
        /// <remarks/>
        public string ClientCode {
            get {
                return this.clientCodeField;
            }
            set {
                this.clientCodeField = value;
            }
        }
        
        /// <remarks/>
        public long Cash {
            get {
                return this.cashField;
            }
            set {
                this.cashField = value;
            }
        }
        
        /// <remarks/>
        public MarginLimit Margin {
            get {
                return this.marginField;
            }
            set {
                this.marginField = value;
            }
        }
        
        /// <remarks/>
        public long MaxCapitalBuy {
            get {
                return this.maxCapitalBuyField;
            }
            set {
                this.maxCapitalBuyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MaxCapitalBuySpecified {
            get {
                return this.maxCapitalBuyFieldSpecified;
            }
            set {
                this.maxCapitalBuyFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public long MaxCapitalSell {
            get {
                return this.maxCapitalSellField;
            }
            set {
                this.maxCapitalSellField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MaxCapitalSellSpecified {
            get {
                return this.maxCapitalSellFieldSpecified;
            }
            set {
                this.maxCapitalSellFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public long TotalTransaction {
            get {
                return this.totalTransactionField;
            }
            set {
                this.totalTransactionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TotalTransactionSpecified {
            get {
                return this.totalTransactionFieldSpecified;
            }
            set {
                this.totalTransactionFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public long NetTransaction {
            get {
                return this.netTransactionField;
            }
            set {
                this.netTransactionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NetTransactionSpecified {
            get {
                return this.netTransactionFieldSpecified;
            }
            set {
                this.netTransactionFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ClientDeactivation {
        
        private string branchIDField;
        
        private string clientCodeField;
        
        public ClientDeactivation() {
            this.branchIDField = "1";
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="integer")]
        public string BranchID {
            get {
                return this.branchIDField;
            }
            set {
                this.branchIDField = value;
            }
        }
        
        /// <remarks/>
        public string ClientCode {
            get {
                return this.clientCodeField;
            }
            set {
                this.clientCodeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ClientSuspension {
        
        private string branchIDField;
        
        private string clientCodeField;
        
        private SuspendResume sell_SuspendField;
        
        private SuspendResume buy_SuspendField;
        
        private string remarkField;
        
        public ClientSuspension() {
            this.branchIDField = "1";
            this.sell_SuspendField = SuspendResume.NoChange;
            this.buy_SuspendField = SuspendResume.NoChange;
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="integer")]
        public string BranchID {
            get {
                return this.branchIDField;
            }
            set {
                this.branchIDField = value;
            }
        }
        
        /// <remarks/>
        public string ClientCode {
            get {
                return this.clientCodeField;
            }
            set {
                this.clientCodeField = value;
            }
        }
        
        /// <remarks/>
        public SuspendResume Sell_Suspend {
            get {
                return this.sell_SuspendField;
            }
            set {
                this.sell_SuspendField = value;
            }
        }
        
        /// <remarks/>
        public SuspendResume Buy_Suspend {
            get {
                return this.buy_SuspendField;
            }
            set {
                this.buy_SuspendField = value;
            }
        }
        
        /// <remarks/>
        public string Remark {
            get {
                return this.remarkField;
            }
            set {
                this.remarkField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    public enum SuspendResume {
        
        /// <remarks/>
        Suspend,
        
        /// <remarks/>
        Resume,
        
        /// <remarks/>
        NoChange,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ClientRegistration {
        
        private string branchIDField;
        
        private string clientCodeField;
        
        private string dealerIDField;
        
        private string bOIDField;
        
        private BooleanYesNo withNetAdjustmentField;
        
        private string nameField;
        
        private string shortNameField;
        
        private string addressField;
        
        private string telField;
        
        private string iCNoField;
        
        private AccountType accountTypeField;
        
        private BooleanYesNo shortSellingAllowedField;
        
        public ClientRegistration() {
            this.branchIDField = "1";
            this.withNetAdjustmentField = BooleanYesNo.No;
            this.accountTypeField = AccountType.Normal;
            this.shortSellingAllowedField = BooleanYesNo.No;
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="integer")]
        public string BranchID {
            get {
                return this.branchIDField;
            }
            set {
                this.branchIDField = value;
            }
        }
        
        /// <remarks/>
        public string ClientCode {
            get {
                return this.clientCodeField;
            }
            set {
                this.clientCodeField = value;
            }
        }
        
        /// <remarks/>
        public string DealerID {
            get {
                return this.dealerIDField;
            }
            set {
                this.dealerIDField = value;
            }
        }
        
        /// <remarks/>
        public string BOID {
            get {
                return this.bOIDField;
            }
            set {
                this.bOIDField = value;
            }
        }
        
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(BooleanYesNo.No)]
        public BooleanYesNo WithNetAdjustment {
            get {
                return this.withNetAdjustmentField;
            }
            set {
                this.withNetAdjustmentField = value;
            }
        }
        
        /// <remarks/>
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        public string ShortName {
            get {
                return this.shortNameField;
            }
            set {
                this.shortNameField = value;
            }
        }
        
        /// <remarks/>
        public string Address {
            get {
                return this.addressField;
            }
            set {
                this.addressField = value;
            }
        }
        
        /// <remarks/>
        public string Tel {
            get {
                return this.telField;
            }
            set {
                this.telField = value;
            }
        }
        
        /// <remarks/>
        public string ICNo {
            get {
                return this.iCNoField;
            }
            set {
                this.iCNoField = value;
            }
        }
        
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(AccountType.Normal)]
        public AccountType AccountType {
            get {
                return this.accountTypeField;
            }
            set {
                this.accountTypeField = value;
            }
        }
        
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(BooleanYesNo.No)]
        public BooleanYesNo ShortSellingAllowed {
            get {
                return this.shortSellingAllowedField;
            }
            set {
                this.shortSellingAllowedField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    public enum BooleanYesNo {
        
        /// <remarks/>
        No,
        
        /// <remarks/>
        Yes,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    public enum AccountType {
        
        /// <remarks/>
        Normal,
        
        /// <remarks/>
        Foreign,
        
        /// <remarks/>
        Corporate,
        
        /// <remarks/>
        Proprietary_Trader,
        
        /// <remarks/>
        NRB,
        
        /// <remarks/>
        Omnibus,
        
        /// <remarks/>
        Others,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    public enum ProcessingMode {

        /// <remarks/>
        BatchInsert,

        /// <remarks/>
        IncrementQuantity,
        BatchInsertOrUpdate
    }
}
