﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.32559
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HLP.Comum.Facade.Canal_VendaService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="modelBase", Namespace="http://schemas.datacontract.org/2004/07/HLP.Comum.Model.Models")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Comum.Facade.Canal_VendaService.Canal_vendaModel))]
    public partial class modelBase : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private HLP.Comum.Facade.Canal_VendaService.PesquisaPadraoModelContract[] lcamposSqlNotNullField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private HLP.Comum.Facade.Canal_VendaService.statusModel statusField;
        
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
        public HLP.Comum.Facade.Canal_VendaService.PesquisaPadraoModelContract[] lcamposSqlNotNull {
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
        public HLP.Comum.Facade.Canal_VendaService.statusModel status {
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Canal_vendaModel", Namespace="http://schemas.datacontract.org/2004/07/HLP.Entries.Model.Models.Comercial")]
    [System.SerializableAttribute()]
    public partial class Canal_vendaModel : HLP.Comum.Facade.Canal_VendaService.modelBase {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string cCanalVendaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> idCanalVendaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string xCanalVendaField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string cCanalVenda {
            get {
                return this.cCanalVendaField;
            }
            set {
                if ((object.ReferenceEquals(this.cCanalVendaField, value) != true)) {
                    this.cCanalVendaField = value;
                    this.RaisePropertyChanged("cCanalVenda");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> idCanalVenda {
            get {
                return this.idCanalVendaField;
            }
            set {
                if ((this.idCanalVendaField.Equals(value) != true)) {
                    this.idCanalVendaField = value;
                    this.RaisePropertyChanged("idCanalVenda");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string xCanalVenda {
            get {
                return this.xCanalVendaField;
            }
            set {
                if ((object.ReferenceEquals(this.xCanalVendaField, value) != true)) {
                    this.xCanalVendaField = value;
                    this.RaisePropertyChanged("xCanalVenda");
                }
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Canal_VendaService.IserviceCanal_Venda")]
    public interface IserviceCanal_Venda {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceCanal_Venda/getCanal_venda", ReplyAction="http://tempuri.org/IserviceCanal_Venda/getCanal_vendaResponse")]
        HLP.Comum.Facade.Canal_VendaService.Canal_vendaModel getCanal_venda(int idCanal_venda);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceCanal_Venda/getCanal_venda", ReplyAction="http://tempuri.org/IserviceCanal_Venda/getCanal_vendaResponse")]
        System.Threading.Tasks.Task<HLP.Comum.Facade.Canal_VendaService.Canal_vendaModel> getCanal_vendaAsync(int idCanal_venda);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceCanal_Venda/saveCanal_venda", ReplyAction="http://tempuri.org/IserviceCanal_Venda/saveCanal_vendaResponse")]
        int saveCanal_venda(HLP.Comum.Facade.Canal_VendaService.Canal_vendaModel objCanal_venda);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceCanal_Venda/saveCanal_venda", ReplyAction="http://tempuri.org/IserviceCanal_Venda/saveCanal_vendaResponse")]
        System.Threading.Tasks.Task<int> saveCanal_vendaAsync(HLP.Comum.Facade.Canal_VendaService.Canal_vendaModel objCanal_venda);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceCanal_Venda/deleteCanal_venda", ReplyAction="http://tempuri.org/IserviceCanal_Venda/deleteCanal_vendaResponse")]
        bool deleteCanal_venda(int idCanal_venda);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceCanal_Venda/deleteCanal_venda", ReplyAction="http://tempuri.org/IserviceCanal_Venda/deleteCanal_vendaResponse")]
        System.Threading.Tasks.Task<bool> deleteCanal_vendaAsync(int idCanal_venda);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceCanal_Venda/copyCanal_venda", ReplyAction="http://tempuri.org/IserviceCanal_Venda/copyCanal_vendaResponse")]
        int copyCanal_venda(int idCanal_venda);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceCanal_Venda/copyCanal_venda", ReplyAction="http://tempuri.org/IserviceCanal_Venda/copyCanal_vendaResponse")]
        System.Threading.Tasks.Task<int> copyCanal_vendaAsync(int idCanal_venda);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IserviceCanal_VendaChannel : HLP.Comum.Facade.Canal_VendaService.IserviceCanal_Venda, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class IserviceCanal_VendaClient : System.ServiceModel.ClientBase<HLP.Comum.Facade.Canal_VendaService.IserviceCanal_Venda>, HLP.Comum.Facade.Canal_VendaService.IserviceCanal_Venda {
        
        public IserviceCanal_VendaClient() {
        }
        
        public IserviceCanal_VendaClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public IserviceCanal_VendaClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IserviceCanal_VendaClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IserviceCanal_VendaClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public HLP.Comum.Facade.Canal_VendaService.Canal_vendaModel getCanal_venda(int idCanal_venda) {
            return base.Channel.getCanal_venda(idCanal_venda);
        }
        
        public System.Threading.Tasks.Task<HLP.Comum.Facade.Canal_VendaService.Canal_vendaModel> getCanal_vendaAsync(int idCanal_venda) {
            return base.Channel.getCanal_vendaAsync(idCanal_venda);
        }
        
        public int saveCanal_venda(HLP.Comum.Facade.Canal_VendaService.Canal_vendaModel objCanal_venda) {
            return base.Channel.saveCanal_venda(objCanal_venda);
        }
        
        public System.Threading.Tasks.Task<int> saveCanal_vendaAsync(HLP.Comum.Facade.Canal_VendaService.Canal_vendaModel objCanal_venda) {
            return base.Channel.saveCanal_vendaAsync(objCanal_venda);
        }
        
        public bool deleteCanal_venda(int idCanal_venda) {
            return base.Channel.deleteCanal_venda(idCanal_venda);
        }
        
        public System.Threading.Tasks.Task<bool> deleteCanal_vendaAsync(int idCanal_venda) {
            return base.Channel.deleteCanal_vendaAsync(idCanal_venda);
        }
        
        public int copyCanal_venda(int idCanal_venda) {
            return base.Channel.copyCanal_venda(idCanal_venda);
        }
        
        public System.Threading.Tasks.Task<int> copyCanal_vendaAsync(int idCanal_venda) {
            return base.Channel.copyCanal_vendaAsync(idCanal_venda);
        }
    }
}