﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.32559
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HLP.Comum.Model.camposBaseDadosService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="campoSqlModel", Namespace="http://schemas.datacontract.org/2004/07/HLP.Comum.Model.Models")]
    [System.SerializableAttribute()]
    public partial class campoSqlModel : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string COLUMN_NAMEField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TYPEField;
        
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
        public string TYPE {
            get {
                return this.TYPEField;
            }
            set {
                if ((object.ReferenceEquals(this.TYPEField, value) != true)) {
                    this.TYPEField = value;
                    this.RaisePropertyChanged("TYPE");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="camposBaseDadosService.IcamposBaseDadosService")]
    public interface IcamposBaseDadosService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IcamposBaseDadosService/getCamposNotNull", ReplyAction="http://tempuri.org/IcamposBaseDadosService/getCamposNotNullResponse")]
        HLP.Comum.Model.camposBaseDadosService.campoSqlModel[] getCamposNotNull(string xTabela);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IcamposBaseDadosService/getCamposNotNull", ReplyAction="http://tempuri.org/IcamposBaseDadosService/getCamposNotNullResponse")]
        System.Threading.Tasks.Task<HLP.Comum.Model.camposBaseDadosService.campoSqlModel[]> getCamposNotNullAsync(string xTabela);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IcamposBaseDadosServiceChannel : HLP.Comum.Model.camposBaseDadosService.IcamposBaseDadosService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class IcamposBaseDadosServiceClient : System.ServiceModel.ClientBase<HLP.Comum.Model.camposBaseDadosService.IcamposBaseDadosService>, HLP.Comum.Model.camposBaseDadosService.IcamposBaseDadosService {
        
        public IcamposBaseDadosServiceClient() {
        }
        
        public IcamposBaseDadosServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public IcamposBaseDadosServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IcamposBaseDadosServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IcamposBaseDadosServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public HLP.Comum.Model.camposBaseDadosService.campoSqlModel[] getCamposNotNull(string xTabela) {
            return base.Channel.getCamposNotNull(xTabela);
        }
        
        public System.Threading.Tasks.Task<HLP.Comum.Model.camposBaseDadosService.campoSqlModel[]> getCamposNotNullAsync(string xTabela) {
            return base.Channel.getCamposNotNullAsync(xTabela);
        }
    }
}
