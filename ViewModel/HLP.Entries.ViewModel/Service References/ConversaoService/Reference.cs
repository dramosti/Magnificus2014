﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.32559
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HLP.Entries.ViewModel.ConversaoService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="modelBase", Namespace="http://schemas.datacontract.org/2004/07/HLP.Comum.Model.Models")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.Gerais.ConversaoModel))]
    public partial class modelBase : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.List<HLP.Entries.ViewModel.ConversaoService.PesquisaPadraoModelContract> lcamposSqlNotNullField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private HLP.Entries.ViewModel.ConversaoService.statusModel statusField;
        
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
        public System.Collections.Generic.List<HLP.Entries.ViewModel.ConversaoService.PesquisaPadraoModelContract> lcamposSqlNotNull {
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
        public HLP.Entries.ViewModel.ConversaoService.statusModel status {
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ConversaoService.IserviceConversao")]
    public interface IserviceConversao {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceConversao/getlConversao", ReplyAction="http://tempuri.org/IserviceConversao/getlConversaoResponse")]
        System.Collections.Generic.List<HLP.Entries.Model.Models.Gerais.ConversaoModel> getlConversao(int idProduto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceConversao/getlConversao", ReplyAction="http://tempuri.org/IserviceConversao/getlConversaoResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<HLP.Entries.Model.Models.Gerais.ConversaoModel>> getlConversaoAsync(int idProduto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceConversao/savelConversao", ReplyAction="http://tempuri.org/IserviceConversao/savelConversaoResponse")]
        void savelConversao(System.Collections.Generic.List<HLP.Entries.Model.Models.Gerais.ConversaoModel> lConversao);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceConversao/savelConversao", ReplyAction="http://tempuri.org/IserviceConversao/savelConversaoResponse")]
        System.Threading.Tasks.Task savelConversaoAsync(System.Collections.Generic.List<HLP.Entries.Model.Models.Gerais.ConversaoModel> lConversao);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceConversao/dellConversao", ReplyAction="http://tempuri.org/IserviceConversao/dellConversaoResponse")]
        bool dellConversao(int idProduto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceConversao/dellConversao", ReplyAction="http://tempuri.org/IserviceConversao/dellConversaoResponse")]
        System.Threading.Tasks.Task<bool> dellConversaoAsync(int idProduto);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IserviceConversaoChannel : HLP.Entries.ViewModel.ConversaoService.IserviceConversao, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class IserviceConversaoClient : System.ServiceModel.ClientBase<HLP.Entries.ViewModel.ConversaoService.IserviceConversao>, HLP.Entries.ViewModel.ConversaoService.IserviceConversao {
        
        public IserviceConversaoClient() {
        }
        
        public IserviceConversaoClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public IserviceConversaoClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IserviceConversaoClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IserviceConversaoClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.List<HLP.Entries.Model.Models.Gerais.ConversaoModel> getlConversao(int idProduto) {
            return base.Channel.getlConversao(idProduto);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<HLP.Entries.Model.Models.Gerais.ConversaoModel>> getlConversaoAsync(int idProduto) {
            return base.Channel.getlConversaoAsync(idProduto);
        }
        
        public void savelConversao(System.Collections.Generic.List<HLP.Entries.Model.Models.Gerais.ConversaoModel> lConversao) {
            base.Channel.savelConversao(lConversao);
        }
        
        public System.Threading.Tasks.Task savelConversaoAsync(System.Collections.Generic.List<HLP.Entries.Model.Models.Gerais.ConversaoModel> lConversao) {
            return base.Channel.savelConversaoAsync(lConversao);
        }
        
        public bool dellConversao(int idProduto) {
            return base.Channel.dellConversao(idProduto);
        }
        
        public System.Threading.Tasks.Task<bool> dellConversaoAsync(int idProduto) {
            return base.Channel.dellConversaoAsync(idProduto);
        }
    }
}
