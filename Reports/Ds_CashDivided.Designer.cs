﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.5420
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

#pragma warning disable 1591

namespace Reports {
    
    
    /// <summary>
    ///Represents a strongly typed in-memory cache of data.
    ///</summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
    [global::System.Serializable()]
    [global::System.ComponentModel.DesignerCategoryAttribute("code")]
    [global::System.ComponentModel.ToolboxItem(true)]
    [global::System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
    [global::System.Xml.Serialization.XmlRootAttribute("Ds_CashDivided")]
    [global::System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
    public partial class Ds_CashDivided : global::System.Data.DataSet {
        
        private DataTable1DataTable tableDataTable1;
        
        private global::System.Data.SchemaSerializationMode _schemaSerializationMode = global::System.Data.SchemaSerializationMode.IncludeSchema;
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public Ds_CashDivided() {
            this.BeginInit();
            this.InitClass();
            global::System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new global::System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += schemaChangedHandler;
            base.Relations.CollectionChanged += schemaChangedHandler;
            this.EndInit();
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected Ds_CashDivided(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context) : 
                base(info, context, false) {
            if ((this.IsBinarySerialized(info, context) == true)) {
                this.InitVars(false);
                global::System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler1 = new global::System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
                this.Tables.CollectionChanged += schemaChangedHandler1;
                this.Relations.CollectionChanged += schemaChangedHandler1;
                return;
            }
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((this.DetermineSchemaSerializationMode(info, context) == global::System.Data.SchemaSerializationMode.IncludeSchema)) {
                global::System.Data.DataSet ds = new global::System.Data.DataSet();
                ds.ReadXmlSchema(new global::System.Xml.XmlTextReader(new global::System.IO.StringReader(strSchema)));
                if ((ds.Tables["DataTable1"] != null)) {
                    base.Tables.Add(new DataTable1DataTable(ds.Tables["DataTable1"]));
                }
                this.DataSetName = ds.DataSetName;
                this.Prefix = ds.Prefix;
                this.Namespace = ds.Namespace;
                this.Locale = ds.Locale;
                this.CaseSensitive = ds.CaseSensitive;
                this.EnforceConstraints = ds.EnforceConstraints;
                this.Merge(ds, false, global::System.Data.MissingSchemaAction.Add);
                this.InitVars();
            }
            else {
                this.ReadXmlSchema(new global::System.Xml.XmlTextReader(new global::System.IO.StringReader(strSchema)));
            }
            this.GetSerializationData(info, context);
            global::System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new global::System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.ComponentModel.Browsable(false)]
        [global::System.ComponentModel.DesignerSerializationVisibility(global::System.ComponentModel.DesignerSerializationVisibility.Content)]
        public DataTable1DataTable DataTable1 {
            get {
                return this.tableDataTable1;
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.ComponentModel.BrowsableAttribute(true)]
        [global::System.ComponentModel.DesignerSerializationVisibilityAttribute(global::System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public override global::System.Data.SchemaSerializationMode SchemaSerializationMode {
            get {
                return this._schemaSerializationMode;
            }
            set {
                this._schemaSerializationMode = value;
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.ComponentModel.DesignerSerializationVisibilityAttribute(global::System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public new global::System.Data.DataTableCollection Tables {
            get {
                return base.Tables;
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.ComponentModel.DesignerSerializationVisibilityAttribute(global::System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public new global::System.Data.DataRelationCollection Relations {
            get {
                return base.Relations;
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override void InitializeDerivedDataSet() {
            this.BeginInit();
            this.InitClass();
            this.EndInit();
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public override global::System.Data.DataSet Clone() {
            Ds_CashDivided cln = ((Ds_CashDivided)(base.Clone()));
            cln.InitVars();
            cln.SchemaSerializationMode = this.SchemaSerializationMode;
            return cln;
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override bool ShouldSerializeTables() {
            return false;
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override bool ShouldSerializeRelations() {
            return false;
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override void ReadXmlSerializable(global::System.Xml.XmlReader reader) {
            if ((this.DetermineSchemaSerializationMode(reader) == global::System.Data.SchemaSerializationMode.IncludeSchema)) {
                this.Reset();
                global::System.Data.DataSet ds = new global::System.Data.DataSet();
                ds.ReadXml(reader);
                if ((ds.Tables["DataTable1"] != null)) {
                    base.Tables.Add(new DataTable1DataTable(ds.Tables["DataTable1"]));
                }
                this.DataSetName = ds.DataSetName;
                this.Prefix = ds.Prefix;
                this.Namespace = ds.Namespace;
                this.Locale = ds.Locale;
                this.CaseSensitive = ds.CaseSensitive;
                this.EnforceConstraints = ds.EnforceConstraints;
                this.Merge(ds, false, global::System.Data.MissingSchemaAction.Add);
                this.InitVars();
            }
            else {
                this.ReadXml(reader);
                this.InitVars();
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override global::System.Xml.Schema.XmlSchema GetSchemaSerializable() {
            global::System.IO.MemoryStream stream = new global::System.IO.MemoryStream();
            this.WriteXmlSchema(new global::System.Xml.XmlTextWriter(stream, null));
            stream.Position = 0;
            return global::System.Xml.Schema.XmlSchema.Read(new global::System.Xml.XmlTextReader(stream), null);
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        internal void InitVars() {
            this.InitVars(true);
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        internal void InitVars(bool initTable) {
            this.tableDataTable1 = ((DataTable1DataTable)(base.Tables["DataTable1"]));
            if ((initTable == true)) {
                if ((this.tableDataTable1 != null)) {
                    this.tableDataTable1.InitVars();
                }
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void InitClass() {
            this.DataSetName = "Ds_CashDivided";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/Ds_CashDivided.xsd";
            this.EnforceConstraints = true;
            this.SchemaSerializationMode = global::System.Data.SchemaSerializationMode.IncludeSchema;
            this.tableDataTable1 = new DataTable1DataTable();
            base.Tables.Add(this.tableDataTable1);
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private bool ShouldSerializeDataTable1() {
            return false;
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void SchemaChanged(object sender, global::System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == global::System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public static global::System.Xml.Schema.XmlSchemaComplexType GetTypedDataSetSchema(global::System.Xml.Schema.XmlSchemaSet xs) {
            Ds_CashDivided ds = new Ds_CashDivided();
            global::System.Xml.Schema.XmlSchemaComplexType type = new global::System.Xml.Schema.XmlSchemaComplexType();
            global::System.Xml.Schema.XmlSchemaSequence sequence = new global::System.Xml.Schema.XmlSchemaSequence();
            global::System.Xml.Schema.XmlSchemaAny any = new global::System.Xml.Schema.XmlSchemaAny();
            any.Namespace = ds.Namespace;
            sequence.Items.Add(any);
            type.Particle = sequence;
            global::System.Xml.Schema.XmlSchema dsSchema = ds.GetSchemaSerializable();
            if (xs.Contains(dsSchema.TargetNamespace)) {
                global::System.IO.MemoryStream s1 = new global::System.IO.MemoryStream();
                global::System.IO.MemoryStream s2 = new global::System.IO.MemoryStream();
                try {
                    global::System.Xml.Schema.XmlSchema schema = null;
                    dsSchema.Write(s1);
                    for (global::System.Collections.IEnumerator schemas = xs.Schemas(dsSchema.TargetNamespace).GetEnumerator(); schemas.MoveNext(); ) {
                        schema = ((global::System.Xml.Schema.XmlSchema)(schemas.Current));
                        s2.SetLength(0);
                        schema.Write(s2);
                        if ((s1.Length == s2.Length)) {
                            s1.Position = 0;
                            s2.Position = 0;
                            for (; ((s1.Position != s1.Length) 
                                        && (s1.ReadByte() == s2.ReadByte())); ) {
                                ;
                            }
                            if ((s1.Position == s1.Length)) {
                                return type;
                            }
                        }
                    }
                }
                finally {
                    if ((s1 != null)) {
                        s1.Close();
                    }
                    if ((s2 != null)) {
                        s2.Close();
                    }
                }
            }
            xs.Add(dsSchema);
            return type;
        }
        
        public delegate void DataTable1RowChangeEventHandler(object sender, DataTable1RowChangeEvent e);
        
        /// <summary>
        ///Represents the strongly named DataTable class.
        ///</summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        [global::System.Serializable()]
        [global::System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedTableSchema")]
        public partial class DataTable1DataTable : global::System.Data.TypedTableBase<DataTable1Row> {
            
            private global::System.Data.DataColumn _columnSL_No_;
            
            private global::System.Data.DataColumn columnClient_ID;
            
            private global::System.Data.DataColumn columnBO_ID;
            
            private global::System.Data.DataColumn _columnShareholder_s_Name;
            
            private global::System.Data.DataColumn _columnShareholding_Position_Qty_;
            
            private global::System.Data.DataColumn _columnCash_Dividend__Amount_;
            
            private global::System.Data.DataColumn columnCompany_Name;
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public DataTable1DataTable() {
                this.TableName = "DataTable1";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal DataTable1DataTable(global::System.Data.DataTable table) {
                this.TableName = table.TableName;
                if ((table.CaseSensitive != table.DataSet.CaseSensitive)) {
                    this.CaseSensitive = table.CaseSensitive;
                }
                if ((table.Locale.ToString() != table.DataSet.Locale.ToString())) {
                    this.Locale = table.Locale;
                }
                if ((table.Namespace != table.DataSet.Namespace)) {
                    this.Namespace = table.Namespace;
                }
                this.Prefix = table.Prefix;
                this.MinimumCapacity = table.MinimumCapacity;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected DataTable1DataTable(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context) : 
                    base(info, context) {
                this.InitVars();
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataColumn _SL_No_Column {
                get {
                    return this._columnSL_No_;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataColumn Client_IDColumn {
                get {
                    return this.columnClient_ID;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataColumn BO_IDColumn {
                get {
                    return this.columnBO_ID;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataColumn _Shareholder_s_NameColumn {
                get {
                    return this._columnShareholder_s_Name;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataColumn _Shareholding_Position_Qty_Column {
                get {
                    return this._columnShareholding_Position_Qty_;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataColumn _Cash_Dividend__Amount_Column {
                get {
                    return this._columnCash_Dividend__Amount_;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataColumn Company_NameColumn {
                get {
                    return this.columnCompany_Name;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.ComponentModel.Browsable(false)]
            public int Count {
                get {
                    return this.Rows.Count;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public DataTable1Row this[int index] {
                get {
                    return ((DataTable1Row)(this.Rows[index]));
                }
            }
            
            public event DataTable1RowChangeEventHandler DataTable1RowChanging;
            
            public event DataTable1RowChangeEventHandler DataTable1RowChanged;
            
            public event DataTable1RowChangeEventHandler DataTable1RowDeleting;
            
            public event DataTable1RowChangeEventHandler DataTable1RowDeleted;
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void AddDataTable1Row(DataTable1Row row) {
                this.Rows.Add(row);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public DataTable1Row AddDataTable1Row(string _SL_No_, string Client_ID, string BO_ID, string _Shareholder_s_Name, string _Shareholding_Position_Qty_, string _Cash_Dividend__Amount_, string Company_Name) {
                DataTable1Row rowDataTable1Row = ((DataTable1Row)(this.NewRow()));
                object[] columnValuesArray = new object[] {
                        _SL_No_,
                        Client_ID,
                        BO_ID,
                        _Shareholder_s_Name,
                        _Shareholding_Position_Qty_,
                        _Cash_Dividend__Amount_,
                        Company_Name};
                rowDataTable1Row.ItemArray = columnValuesArray;
                this.Rows.Add(rowDataTable1Row);
                return rowDataTable1Row;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public override global::System.Data.DataTable Clone() {
                DataTable1DataTable cln = ((DataTable1DataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override global::System.Data.DataTable CreateInstance() {
                return new DataTable1DataTable();
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal void InitVars() {
                this._columnSL_No_ = base.Columns["SL No."];
                this.columnClient_ID = base.Columns["Client ID"];
                this.columnBO_ID = base.Columns["BO ID"];
                this._columnShareholder_s_Name = base.Columns["Shareholder’s Name"];
                this._columnShareholding_Position_Qty_ = base.Columns["Shareholding Position/Qty."];
                this._columnCash_Dividend__Amount_ = base.Columns["Cash Dividend (Amount)"];
                this.columnCompany_Name = base.Columns["Company Name"];
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private void InitClass() {
                this._columnSL_No_ = new global::System.Data.DataColumn("SL No.", typeof(string), null, global::System.Data.MappingType.Element);
                this._columnSL_No_.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnSL_No_");
                this._columnSL_No_.ExtendedProperties.Add("Generator_UserColumnName", "SL No.");
                base.Columns.Add(this._columnSL_No_);
                this.columnClient_ID = new global::System.Data.DataColumn("Client ID", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnClient_ID);
                this.columnBO_ID = new global::System.Data.DataColumn("BO ID", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnBO_ID);
                this._columnShareholder_s_Name = new global::System.Data.DataColumn("Shareholder’s Name", typeof(string), null, global::System.Data.MappingType.Element);
                this._columnShareholder_s_Name.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnShareholder_s_Name");
                this._columnShareholder_s_Name.ExtendedProperties.Add("Generator_UserColumnName", "Shareholder’s Name");
                base.Columns.Add(this._columnShareholder_s_Name);
                this._columnShareholding_Position_Qty_ = new global::System.Data.DataColumn("Shareholding Position/Qty.", typeof(string), null, global::System.Data.MappingType.Element);
                this._columnShareholding_Position_Qty_.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnShareholding_Position_Qty_");
                this._columnShareholding_Position_Qty_.ExtendedProperties.Add("Generator_UserColumnName", "Shareholding Position/Qty.");
                base.Columns.Add(this._columnShareholding_Position_Qty_);
                this._columnCash_Dividend__Amount_ = new global::System.Data.DataColumn("Cash Dividend (Amount)", typeof(string), null, global::System.Data.MappingType.Element);
                this._columnCash_Dividend__Amount_.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnCash_Dividend__Amount_");
                this._columnCash_Dividend__Amount_.ExtendedProperties.Add("Generator_UserColumnName", "Cash Dividend (Amount)");
                base.Columns.Add(this._columnCash_Dividend__Amount_);
                this.columnCompany_Name = new global::System.Data.DataColumn("Company Name", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnCompany_Name);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public DataTable1Row NewDataTable1Row() {
                return ((DataTable1Row)(this.NewRow()));
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override global::System.Data.DataRow NewRowFromBuilder(global::System.Data.DataRowBuilder builder) {
                return new DataTable1Row(builder);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override global::System.Type GetRowType() {
                return typeof(DataTable1Row);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowChanged(global::System.Data.DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.DataTable1RowChanged != null)) {
                    this.DataTable1RowChanged(this, new DataTable1RowChangeEvent(((DataTable1Row)(e.Row)), e.Action));
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowChanging(global::System.Data.DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.DataTable1RowChanging != null)) {
                    this.DataTable1RowChanging(this, new DataTable1RowChangeEvent(((DataTable1Row)(e.Row)), e.Action));
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowDeleted(global::System.Data.DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.DataTable1RowDeleted != null)) {
                    this.DataTable1RowDeleted(this, new DataTable1RowChangeEvent(((DataTable1Row)(e.Row)), e.Action));
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowDeleting(global::System.Data.DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.DataTable1RowDeleting != null)) {
                    this.DataTable1RowDeleting(this, new DataTable1RowChangeEvent(((DataTable1Row)(e.Row)), e.Action));
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void RemoveDataTable1Row(DataTable1Row row) {
                this.Rows.Remove(row);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public static global::System.Xml.Schema.XmlSchemaComplexType GetTypedTableSchema(global::System.Xml.Schema.XmlSchemaSet xs) {
                global::System.Xml.Schema.XmlSchemaComplexType type = new global::System.Xml.Schema.XmlSchemaComplexType();
                global::System.Xml.Schema.XmlSchemaSequence sequence = new global::System.Xml.Schema.XmlSchemaSequence();
                Ds_CashDivided ds = new Ds_CashDivided();
                global::System.Xml.Schema.XmlSchemaAny any1 = new global::System.Xml.Schema.XmlSchemaAny();
                any1.Namespace = "http://www.w3.org/2001/XMLSchema";
                any1.MinOccurs = new decimal(0);
                any1.MaxOccurs = decimal.MaxValue;
                any1.ProcessContents = global::System.Xml.Schema.XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any1);
                global::System.Xml.Schema.XmlSchemaAny any2 = new global::System.Xml.Schema.XmlSchemaAny();
                any2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
                any2.MinOccurs = new decimal(1);
                any2.ProcessContents = global::System.Xml.Schema.XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any2);
                global::System.Xml.Schema.XmlSchemaAttribute attribute1 = new global::System.Xml.Schema.XmlSchemaAttribute();
                attribute1.Name = "namespace";
                attribute1.FixedValue = ds.Namespace;
                type.Attributes.Add(attribute1);
                global::System.Xml.Schema.XmlSchemaAttribute attribute2 = new global::System.Xml.Schema.XmlSchemaAttribute();
                attribute2.Name = "tableTypeName";
                attribute2.FixedValue = "DataTable1DataTable";
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                global::System.Xml.Schema.XmlSchema dsSchema = ds.GetSchemaSerializable();
                if (xs.Contains(dsSchema.TargetNamespace)) {
                    global::System.IO.MemoryStream s1 = new global::System.IO.MemoryStream();
                    global::System.IO.MemoryStream s2 = new global::System.IO.MemoryStream();
                    try {
                        global::System.Xml.Schema.XmlSchema schema = null;
                        dsSchema.Write(s1);
                        for (global::System.Collections.IEnumerator schemas = xs.Schemas(dsSchema.TargetNamespace).GetEnumerator(); schemas.MoveNext(); ) {
                            schema = ((global::System.Xml.Schema.XmlSchema)(schemas.Current));
                            s2.SetLength(0);
                            schema.Write(s2);
                            if ((s1.Length == s2.Length)) {
                                s1.Position = 0;
                                s2.Position = 0;
                                for (; ((s1.Position != s1.Length) 
                                            && (s1.ReadByte() == s2.ReadByte())); ) {
                                    ;
                                }
                                if ((s1.Position == s1.Length)) {
                                    return type;
                                }
                            }
                        }
                    }
                    finally {
                        if ((s1 != null)) {
                            s1.Close();
                        }
                        if ((s2 != null)) {
                            s2.Close();
                        }
                    }
                }
                xs.Add(dsSchema);
                return type;
            }
        }
        
        /// <summary>
        ///Represents strongly named DataRow class.
        ///</summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public partial class DataTable1Row : global::System.Data.DataRow {
            
            private DataTable1DataTable tableDataTable1;
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal DataTable1Row(global::System.Data.DataRowBuilder rb) : 
                    base(rb) {
                this.tableDataTable1 = ((DataTable1DataTable)(this.Table));
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string _SL_No_ {
                get {
                    try {
                        return ((string)(this[this.tableDataTable1._SL_No_Column]));
                    }
                    catch (global::System.InvalidCastException e) {
                        throw new global::System.Data.StrongTypingException("The value for column \'SL No.\' in table \'DataTable1\' is DBNull.", e);
                    }
                }
                set {
                    this[this.tableDataTable1._SL_No_Column] = value;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string Client_ID {
                get {
                    try {
                        return ((string)(this[this.tableDataTable1.Client_IDColumn]));
                    }
                    catch (global::System.InvalidCastException e) {
                        throw new global::System.Data.StrongTypingException("The value for column \'Client ID\' in table \'DataTable1\' is DBNull.", e);
                    }
                }
                set {
                    this[this.tableDataTable1.Client_IDColumn] = value;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string BO_ID {
                get {
                    try {
                        return ((string)(this[this.tableDataTable1.BO_IDColumn]));
                    }
                    catch (global::System.InvalidCastException e) {
                        throw new global::System.Data.StrongTypingException("The value for column \'BO ID\' in table \'DataTable1\' is DBNull.", e);
                    }
                }
                set {
                    this[this.tableDataTable1.BO_IDColumn] = value;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string _Shareholder_s_Name {
                get {
                    try {
                        return ((string)(this[this.tableDataTable1._Shareholder_s_NameColumn]));
                    }
                    catch (global::System.InvalidCastException e) {
                        throw new global::System.Data.StrongTypingException("The value for column \'Shareholder’s Name\' in table \'DataTable1\' is DBNull.", e);
                    }
                }
                set {
                    this[this.tableDataTable1._Shareholder_s_NameColumn] = value;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string _Shareholding_Position_Qty_ {
                get {
                    try {
                        return ((string)(this[this.tableDataTable1._Shareholding_Position_Qty_Column]));
                    }
                    catch (global::System.InvalidCastException e) {
                        throw new global::System.Data.StrongTypingException("The value for column \'Shareholding Position/Qty.\' in table \'DataTable1\' is DBNull" +
                                ".", e);
                    }
                }
                set {
                    this[this.tableDataTable1._Shareholding_Position_Qty_Column] = value;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string _Cash_Dividend__Amount_ {
                get {
                    try {
                        return ((string)(this[this.tableDataTable1._Cash_Dividend__Amount_Column]));
                    }
                    catch (global::System.InvalidCastException e) {
                        throw new global::System.Data.StrongTypingException("The value for column \'Cash Dividend (Amount)\' in table \'DataTable1\' is DBNull.", e);
                    }
                }
                set {
                    this[this.tableDataTable1._Cash_Dividend__Amount_Column] = value;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string Company_Name {
                get {
                    try {
                        return ((string)(this[this.tableDataTable1.Company_NameColumn]));
                    }
                    catch (global::System.InvalidCastException e) {
                        throw new global::System.Data.StrongTypingException("The value for column \'Company Name\' in table \'DataTable1\' is DBNull.", e);
                    }
                }
                set {
                    this[this.tableDataTable1.Company_NameColumn] = value;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool Is_SL_No_Null() {
                return this.IsNull(this.tableDataTable1._SL_No_Column);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void Set_SL_No_Null() {
                this[this.tableDataTable1._SL_No_Column] = global::System.Convert.DBNull;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsClient_IDNull() {
                return this.IsNull(this.tableDataTable1.Client_IDColumn);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetClient_IDNull() {
                this[this.tableDataTable1.Client_IDColumn] = global::System.Convert.DBNull;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsBO_IDNull() {
                return this.IsNull(this.tableDataTable1.BO_IDColumn);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetBO_IDNull() {
                this[this.tableDataTable1.BO_IDColumn] = global::System.Convert.DBNull;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool Is_Shareholder_s_NameNull() {
                return this.IsNull(this.tableDataTable1._Shareholder_s_NameColumn);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void Set_Shareholder_s_NameNull() {
                this[this.tableDataTable1._Shareholder_s_NameColumn] = global::System.Convert.DBNull;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool Is_Shareholding_Position_Qty_Null() {
                return this.IsNull(this.tableDataTable1._Shareholding_Position_Qty_Column);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void Set_Shareholding_Position_Qty_Null() {
                this[this.tableDataTable1._Shareholding_Position_Qty_Column] = global::System.Convert.DBNull;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool Is_Cash_Dividend__Amount_Null() {
                return this.IsNull(this.tableDataTable1._Cash_Dividend__Amount_Column);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void Set_Cash_Dividend__Amount_Null() {
                this[this.tableDataTable1._Cash_Dividend__Amount_Column] = global::System.Convert.DBNull;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsCompany_NameNull() {
                return this.IsNull(this.tableDataTable1.Company_NameColumn);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetCompany_NameNull() {
                this[this.tableDataTable1.Company_NameColumn] = global::System.Convert.DBNull;
            }
        }
        
        /// <summary>
        ///Row event argument class
        ///</summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class DataTable1RowChangeEvent : global::System.EventArgs {
            
            private DataTable1Row eventRow;
            
            private global::System.Data.DataRowAction eventAction;
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public DataTable1RowChangeEvent(DataTable1Row row, global::System.Data.DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public DataTable1Row Row {
                get {
                    return this.eventRow;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataRowAction Action {
                get {
                    return this.eventAction;
                }
            }
        }
    }
}

#pragma warning restore 1591