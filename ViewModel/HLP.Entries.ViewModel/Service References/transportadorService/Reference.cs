﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.32559
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HLP.Entries.ViewModel.transportadorService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="modelBase", Namespace="http://schemas.datacontract.org/2004/07/HLP.Comum.Model.Models")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.Transportes.Transportador_ContatoModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.Transportes.Transportador_EnderecoModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.Transportes.Transportador_MotoristaModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.Transportes.Transportador_VeiculosModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.Transportes.TransportadorModel))]
    public partial class modelBase : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.List<HLP.Entries.ViewModel.transportadorService.PesquisaPadraoModelContract> lcamposSqlNotNullField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private HLP.Entries.ViewModel.transportadorService.statusModel statusField;
        
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
        public System.Collections.Generic.List<HLP.Entries.ViewModel.transportadorService.PesquisaPadraoModelContract> lcamposSqlNotNull {
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
        public HLP.Entries.ViewModel.transportadorService.statusModel status {
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
        private string COLUMN_NAMEField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DATA_TYPEField;
        
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="transportadorService.IserviceTransportador")]
    public interface IserviceTransportador {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceTransportador/getTransportador", ReplyAction="http://tempuri.org/IserviceTransportador/getTransportadorResponse")]
        HLP.Entries.Model.Models.Transportes.TransportadorModel getTransportador(int idTransportador);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceTransportador/getTransportador", ReplyAction="http://tempuri.org/IserviceTransportador/getTransportadorResponse")]
        System.Threading.Tasks.Task<HLP.Entries.Model.Models.Transportes.TransportadorModel> getTransportadorAsync(int idTransportador);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceTransportador/saveTransportador", ReplyAction="http://tempuri.org/IserviceTransportador/saveTransportadorResponse")]
        int saveTransportador(HLP.Entries.Model.Models.Transportes.TransportadorModel objTransportador);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceTransportador/saveTransportador", ReplyAction="http://tempuri.org/IserviceTransportador/saveTransportadorResponse")]
        System.Threading.Tasks.Task<int> saveTransportadorAsync(HLP.Entries.Model.Models.Transportes.TransportadorModel objTransportador);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceTransportador/delTransportador", ReplyAction="http://tempuri.org/IserviceTransportador/delTransportadorResponse")]
        bool delTransportador(int idTransportador);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceTransportador/delTransportador", ReplyAction="http://tempuri.org/IserviceTransportador/delTransportadorResponse")]
        System.Threading.Tasks.Task<bool> delTransportadorAsync(int idTransportador);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceTransportador/copyTransportador", ReplyAction="http://tempuri.org/IserviceTransportador/copyTransportadorResponse")]
        int copyTransportador(int idTransportador);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceTransportador/copyTransportador", ReplyAction="http://tempuri.org/IserviceTransportador/copyTransportadorResponse")]
        System.Threading.Tasks.Task<int> copyTransportadorAsync(int idTransportador);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IserviceTransportadorChannel : HLP.Entries.ViewModel.transportadorService.IserviceTransportador, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class IserviceTransportadorClient : System.ServiceModel.ClientBase<HLP.Entries.ViewModel.transportadorService.IserviceTransportador>, HLP.Entries.ViewModel.transportadorService.IserviceTransportador {
        
        public IserviceTransportadorClient() {
        }
        
        public IserviceTransportadorClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public IserviceTransportadorClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IserviceTransportadorClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IserviceTransportadorClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public HLP.Entries.Model.Models.Transportes.TransportadorModel getTransportador(int idTransportador) {
            return base.Channel.getTransportador(idTransportador);
        }
        
        public System.Threading.Tasks.Task<HLP.Entries.Model.Models.Transportes.TransportadorModel> getTransportadorAsync(int idTransportador) {
            return base.Channel.getTransportadorAsync(idTransportador);
        }
        
        public int saveTransportador(HLP.Entries.Model.Models.Transportes.TransportadorModel objTransportador) {
            return base.Channel.saveTransportador(objTransportador);
        }
        
        public System.Threading.Tasks.Task<int> saveTransportadorAsync(HLP.Entries.Model.Models.Transportes.TransportadorModel objTransportador) {
            return base.Channel.saveTransportadorAsync(objTransportador);
        }
        
        public bool delTransportador(int idTransportador) {
            return base.Channel.delTransportador(idTransportador);
        }
        
        public System.Threading.Tasks.Task<bool> delTransportadorAsync(int idTransportador) {
            return base.Channel.delTransportadorAsync(idTransportador);
        }
        
        public int copyTransportador(int idTransportador) {
            return base.Channel.copyTransportador(idTransportador);
        }
        
        public System.Threading.Tasks.Task<int> copyTransportadorAsync(int idTransportador) {
            return base.Channel.copyTransportadorAsync(idTransportador);
        }
    }
}