﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34011
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HLP.Sales.ViewModel.wcf_Orcamento {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="modelBase", Namespace="http://schemas.datacontract.org/2004/07/HLP.Comum.Model.Models")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Sales.Model.Models.Comercial.Orcamento_Item_ImpostosModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Sales.Model.Models.Comercial.Orcamento_ItemModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Sales.Model.Models.Comercial.Orcamento_Total_ImpostosModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Sales.Model.Models.Comercial.Orcamento_retTranspModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Sales.Model.Models.Comercial.Orcamento_ideModel))]
    public partial class modelBase : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private HLP.Sales.ViewModel.wcf_Orcamento.PesquisaPadraoModelContract[] lcamposSqlNotNullField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private HLP.Sales.ViewModel.wcf_Orcamento.statusModel statusField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public HLP.Sales.ViewModel.wcf_Orcamento.PesquisaPadraoModelContract[] lcamposSqlNotNull {
            get {
                return this.lcamposSqlNotNullField;
            }
            set {
                if ((object.ReferenceEquals(this.lcamposSqlNotNullField, value) != true)) {
                    this.lcamposSqlNotNullField = value;
                    this.RaisePropertyChanged("lcamposSqlNotNull");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public HLP.Sales.ViewModel.wcf_Orcamento.statusModel status {
            get {
                return this.statusField;
            }
            set {
                if ((this.statusField.Equals(value) != true)) {
                    this.statusField = value;
                    this.RaisePropertyChanged("status");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PesquisaPadraoModelContract", Namespace="http://schemas.datacontract.org/2004/07/HLP.Comum.Model.Components")]
    [System.SerializableAttribute()]
    public partial class PesquisaPadraoModelContract : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CHARACTER_MAXIMUM_LENGTHField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string COLUMN_NAMEField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DATA_TYPEField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IS_NULLABLEField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CHARACTER_MAXIMUM_LENGTH {
            get {
                return this.CHARACTER_MAXIMUM_LENGTHField;
            }
            set {
                if ((this.CHARACTER_MAXIMUM_LENGTHField.Equals(value) != true)) {
                    this.CHARACTER_MAXIMUM_LENGTHField = value;
                    this.RaisePropertyChanged("CHARACTER_MAXIMUM_LENGTH");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string COLUMN_NAME {
            get {
                return this.COLUMN_NAMEField;
            }
            set {
                if ((object.ReferenceEquals(this.COLUMN_NAMEField, value) != true)) {
                    this.COLUMN_NAMEField = value;
                    this.RaisePropertyChanged("COLUMN_NAME");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DATA_TYPE {
            get {
                return this.DATA_TYPEField;
            }
            set {
                if ((object.ReferenceEquals(this.DATA_TYPEField, value) != true)) {
                    this.DATA_TYPEField = value;
                    this.RaisePropertyChanged("DATA_TYPE");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string IS_NULLABLE {
            get {
                return this.IS_NULLABLEField;
            }
            set {
                if ((object.ReferenceEquals(this.IS_NULLABLEField, value) != true)) {
                    this.IS_NULLABLEField = value;
                    this.RaisePropertyChanged("IS_NULLABLE");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="statusModel", Namespace="http://schemas.datacontract.org/2004/07/HLP.Comum.Resources.RecursosBases")]
    public enum statusModel : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        nenhum = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        criado = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        alterado = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        excluido = 3,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="stOrigem", Namespace="http://schemas.datacontract.org/2004/07/HLP.Comum.Resources.RecursosBases")]
    public enum stOrigem : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        NACION = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ESTRIMPDIRET = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ESTRMERCINTERNO = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        NACIONBEMIMPORTSUP40 = 3,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        NACIONDECRETO28867 = 4,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        NACIONBEMIMPORTINF40 = 5,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ESTRIMPDIRETSEMSIMILNACION = 6,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ESTRMERCINTERNOSEMSIMILNACION = 7,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="modelToComboBox", Namespace="http://schemas.datacontract.org/2004/07/HLP.Comum.Model.Models")]
    [System.SerializableAttribute()]
    public partial class modelToComboBox : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string displayField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string display {
            get {
                return this.displayField;
            }
            set {
                if ((object.ReferenceEquals(this.displayField, value) != true)) {
                    this.displayField = value;
                    this.RaisePropertyChanged("display");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int id {
            get {
                return this.idField;
            }
            set {
                if ((this.idField.Equals(value) != true)) {
                    this.idField = value;
                    this.RaisePropertyChanged("id");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="wcf_Orcamento.Iwcf_Orcamento")]
    public interface Iwcf_Orcamento {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Orcamento/Save", ReplyAction="http://tempuri.org/Iwcf_Orcamento/SaveResponse")]
        HLP.Sales.Model.Models.Comercial.Orcamento_ideModel Save(HLP.Sales.Model.Models.Comercial.Orcamento_ideModel objModel);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Orcamento/Save", ReplyAction="http://tempuri.org/Iwcf_Orcamento/SaveResponse")]
        System.Threading.Tasks.Task<HLP.Sales.Model.Models.Comercial.Orcamento_ideModel> SaveAsync(HLP.Sales.Model.Models.Comercial.Orcamento_ideModel objModel);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Orcamento/GetObjeto", ReplyAction="http://tempuri.org/Iwcf_Orcamento/GetObjetoResponse")]
        HLP.Sales.Model.Models.Comercial.Orcamento_ideModel GetObjeto(int idObjeto, int idEmpresa);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Orcamento/GetObjeto", ReplyAction="http://tempuri.org/Iwcf_Orcamento/GetObjetoResponse")]
        System.Threading.Tasks.Task<HLP.Sales.Model.Models.Comercial.Orcamento_ideModel> GetObjetoAsync(int idObjeto, int idEmpresa);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Orcamento/Delete", ReplyAction="http://tempuri.org/Iwcf_Orcamento/DeleteResponse")]
        bool Delete(HLP.Sales.Model.Models.Comercial.Orcamento_ideModel objModel);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Orcamento/Delete", ReplyAction="http://tempuri.org/Iwcf_Orcamento/DeleteResponse")]
        System.Threading.Tasks.Task<bool> DeleteAsync(HLP.Sales.Model.Models.Comercial.Orcamento_ideModel objModel);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Orcamento/Copy", ReplyAction="http://tempuri.org/Iwcf_Orcamento/CopyResponse")]
        HLP.Sales.Model.Models.Comercial.Orcamento_ideModel Copy(HLP.Sales.Model.Models.Comercial.Orcamento_ideModel objModel);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Orcamento/Copy", ReplyAction="http://tempuri.org/Iwcf_Orcamento/CopyResponse")]
        System.Threading.Tasks.Task<HLP.Sales.Model.Models.Comercial.Orcamento_ideModel> CopyAsync(HLP.Sales.Model.Models.Comercial.Orcamento_ideModel objModel);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Orcamento/GerarVersao", ReplyAction="http://tempuri.org/Iwcf_Orcamento/GerarVersaoResponse")]
        HLP.Sales.Model.Models.Comercial.Orcamento_ideModel GerarVersao(HLP.Sales.Model.Models.Comercial.Orcamento_ideModel objModel);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Orcamento/GerarVersao", ReplyAction="http://tempuri.org/Iwcf_Orcamento/GerarVersaoResponse")]
        System.Threading.Tasks.Task<HLP.Sales.Model.Models.Comercial.Orcamento_ideModel> GerarVersaoAsync(HLP.Sales.Model.Models.Comercial.Orcamento_ideModel objModel);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface Iwcf_OrcamentoChannel : HLP.Sales.ViewModel.wcf_Orcamento.Iwcf_Orcamento, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Iwcf_OrcamentoClient : System.ServiceModel.ClientBase<HLP.Sales.ViewModel.wcf_Orcamento.Iwcf_Orcamento>, HLP.Sales.ViewModel.wcf_Orcamento.Iwcf_Orcamento {
        
        public Iwcf_OrcamentoClient() {
        }
        
        public Iwcf_OrcamentoClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Iwcf_OrcamentoClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Iwcf_OrcamentoClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Iwcf_OrcamentoClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public HLP.Sales.Model.Models.Comercial.Orcamento_ideModel Save(HLP.Sales.Model.Models.Comercial.Orcamento_ideModel objModel) {
            return base.Channel.Save(objModel);
        }
        
        public System.Threading.Tasks.Task<HLP.Sales.Model.Models.Comercial.Orcamento_ideModel> SaveAsync(HLP.Sales.Model.Models.Comercial.Orcamento_ideModel objModel) {
            return base.Channel.SaveAsync(objModel);
        }
        
        public HLP.Sales.Model.Models.Comercial.Orcamento_ideModel GetObjeto(int idObjeto, int idEmpresa) {
            return base.Channel.GetObjeto(idObjeto, idEmpresa);
        }
        
        public System.Threading.Tasks.Task<HLP.Sales.Model.Models.Comercial.Orcamento_ideModel> GetObjetoAsync(int idObjeto, int idEmpresa) {
            return base.Channel.GetObjetoAsync(idObjeto, idEmpresa);
        }
        
        public bool Delete(HLP.Sales.Model.Models.Comercial.Orcamento_ideModel objModel) {
            return base.Channel.Delete(objModel);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteAsync(HLP.Sales.Model.Models.Comercial.Orcamento_ideModel objModel) {
            return base.Channel.DeleteAsync(objModel);
        }
        
        public HLP.Sales.Model.Models.Comercial.Orcamento_ideModel Copy(HLP.Sales.Model.Models.Comercial.Orcamento_ideModel objModel) {
            return base.Channel.Copy(objModel);
        }
        
        public System.Threading.Tasks.Task<HLP.Sales.Model.Models.Comercial.Orcamento_ideModel> CopyAsync(HLP.Sales.Model.Models.Comercial.Orcamento_ideModel objModel) {
            return base.Channel.CopyAsync(objModel);
        }
        
        public HLP.Sales.Model.Models.Comercial.Orcamento_ideModel GerarVersao(HLP.Sales.Model.Models.Comercial.Orcamento_ideModel objModel) {
            return base.Channel.GerarVersao(objModel);
        }
        
        public System.Threading.Tasks.Task<HLP.Sales.Model.Models.Comercial.Orcamento_ideModel> GerarVersaoAsync(HLP.Sales.Model.Models.Comercial.Orcamento_ideModel objModel) {
            return base.Channel.GerarVersaoAsync(objModel);
        }
    }
}
