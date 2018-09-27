﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4927
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
    public partial class Positions {
        
        private object deleteAllPositionsField;
        
        private object[] itemsField;
        
        private ProcessingMode_Position processingModeField;
        
        private string brokerIDField;
        
        public Positions() {
            this.processingModeField = ProcessingMode_Position.BatchInsert;
        }
        
        /// <remarks/>
        public object DeleteAllPositions {
            get {
                return this.deleteAllPositionsField;
            }
            set {
                this.deleteAllPositionsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Delete", typeof(DeletePositions))]
        [System.Xml.Serialization.XmlElementAttribute("InsertOne", typeof(InsertOnePosition))]
        public object[] Items {
            get {
                return this.itemsField;
            }
            set {
                this.itemsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(ProcessingMode_Position.BatchInsert)]
        public ProcessingMode_Position ProcessingMode {
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
    public partial class InsertOnePosition {
        
        private string clientCodeField;
        
        private string securityCodeField;
        
        private string iSINField;
        
        private long quantityField;
        
        private double totalCostField;
        
        private PositionType positionTypeField;
        
        public InsertOnePosition() {
            this.positionTypeField = PositionType.Long;
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
        public string SecurityCode {
            get {
                return this.securityCodeField;
            }
            set {
                this.securityCodeField = value;
            }
        }
        
        /// <remarks/>
        public string ISIN {
            get {
                return this.iSINField;
            }
            set {
                this.iSINField = value;
            }
        }
        
        /// <remarks/>
        public long Quantity {
            get {
                return this.quantityField;
            }
            set {
                this.quantityField = value;
            }
        }
        
        /// <remarks/>
        public double TotalCost {
            get {
                return this.totalCostField;
            }
            set {
                this.totalCostField = value;
            }
        }
        
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(PositionType.Long)]
        public PositionType PositionType {
            get {
                return this.positionTypeField;
            }
            set {
                this.positionTypeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    public enum PositionType {
        
        /// <remarks/>
        Long,
        
        /// <remarks/>
        Short,
        
        /// <remarks/>
        Borrowed,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class DeletePositions {
        
        private string clientCodeField;
        
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
    public enum ProcessingMode_Position {
        
        /// <remarks/>
        BatchInsert,
        
        /// <remarks/>
        IncrementQuantity,
        
        /// <remarks/>
        BatchInsertOrUpdate
    }
}
