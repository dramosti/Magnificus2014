﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.32559
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HLP.Entries.ViewModel.rotaService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="modelBase", Namespace="http://schemas.datacontract.org/2004/07/HLP.Comum.Model.Models")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.Transportes.Rota_pracaModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.Transportes.RotaModel))]
    public partial class modelBase : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.List<HLP.Entries.ViewModel.rotaService.PesquisaPadraoModelContract> lcamposSqlNotNullField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private HLP.Entries.ViewModel.rotaService.statusModel statusField;
        
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
        public System.Collections.Generic.List<HLP.Entries.ViewModel.rotaService.PesquisaPadraoModelContract> lcamposSqlNotNull {
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
        public HLP.Entries.ViewModel.rotaService.statusModel status {
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="rotaService.IserviceRota")]
    public interface IserviceRota {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceRota/Save", ReplyAction="http://tempuri.org/IserviceRota/SaveResponse")]
        HLP.Entries.Model.Models.Transportes.RotaModel Save(HLP.Entries.Model.Models.Transportes.RotaModel objRota);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceRota/Save", ReplyAction="http://tempuri.org/IserviceRota/SaveResponse")]
        System.Threading.Tasks.Task<HLP.Entries.Model.Models.Transportes.RotaModel> SaveAsync(HLP.Entries.Model.Models.Transportes.RotaModel objRota);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceRota/Delete", ReplyAction="http://tempuri.org/IserviceRota/DeleteResponse")]
        void Delete(int idRota);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceRota/Delete", ReplyAction="http://tempuri.org/IserviceRota/DeleteResponse")]
        System.Threading.Tasks.Task DeleteAsync(int idRota);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceRota/Copy", ReplyAction="http://tempuri.org/IserviceRota/CopyResponse")]
        HLP.Entries.Model.Models.Transportes.RotaModel Copy(HLP.Entries.Model.Models.Transportes.RotaModel objRota);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceRota/Copy", ReplyAction="http://tempuri.org/IserviceRota/CopyResponse")]
        System.Threading.Tasks.Task<HLP.Entries.Model.Models.Transportes.RotaModel> CopyAsync(HLP.Entries.Model.Models.Transportes.RotaModel objRota);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceRota/GetObject", ReplyAction="http://tempuri.org/IserviceRota/GetObjectResponse")]
        HLP.Entries.Model.Models.Transportes.RotaModel GetObject(int idRota);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceRota/GetObject", ReplyAction="http://tempuri.org/IserviceRota/GetObjectResponse")]
        System.Threading.Tasks.Task<HLP.Entries.Model.Models.Transportes.RotaModel> GetObjectAsync(int idRota);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IserviceRotaChannel : HLP.Entries.ViewModel.rotaService.IserviceRota, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class IserviceRotaClient : System.ServiceModel.ClientBase<HLP.Entries.ViewModel.rotaService.IserviceRota>, HLP.Entries.ViewModel.rotaService.IserviceRota {
        
        public IserviceRotaClient() {
        }
        
        public IserviceRotaClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public IserviceRotaClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IserviceRotaClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IserviceRotaClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public HLP.Entries.Model.Models.Transportes.RotaModel Save(HLP.Entries.Model.Models.Transportes.RotaModel objRota) {
            return base.Channel.Save(objRota);
        }
        
        public System.Threading.Tasks.Task<HLP.Entries.Model.Models.Transportes.RotaModel> SaveAsync(HLP.Entries.Model.Models.Transportes.RotaModel objRota) {
            return base.Channel.SaveAsync(objRota);
        }
        
        public void Delete(int idRota) {
            base.Channel.Delete(idRota);
        }
        
        public System.Threading.Tasks.Task DeleteAsync(int idRota) {
            return base.Channel.DeleteAsync(idRota);
        }
        
        public HLP.Entries.Model.Models.Transportes.RotaModel Copy(HLP.Entries.Model.Models.Transportes.RotaModel objRota) {
            return base.Channel.Copy(objRota);
        }
        
        public System.Threading.Tasks.Task<HLP.Entries.Model.Models.Transportes.RotaModel> CopyAsync(HLP.Entries.Model.Models.Transportes.RotaModel objRota) {
            return base.Channel.CopyAsync(objRota);
        }
        
        public HLP.Entries.Model.Models.Transportes.RotaModel GetObject(int idRota) {
            return base.Channel.GetObject(idRota);
        }
        
        public System.Threading.Tasks.Task<HLP.Entries.Model.Models.Transportes.RotaModel> GetObjectAsync(int idRota) {
            return base.Channel.GetObjectAsync(idRota);
        }
    }
}
