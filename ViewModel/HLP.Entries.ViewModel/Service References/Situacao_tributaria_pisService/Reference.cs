﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18051
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HLP.Entries.ViewModel.Situacao_tributaria_pisService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="modelBase", Namespace="http://schemas.datacontract.org/2004/07/HLP.Comum.Model.Models")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.Fiscal.Situacao_tributaria_pisModel))]
    public partial class modelBase : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.List<HLP.Entries.ViewModel.Situacao_tributaria_pisService.PesquisaPadraoModelContract> lcamposSqlNotNullField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private HLP.Entries.ViewModel.Situacao_tributaria_pisService.statusModel statusField;
        
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
        public System.Collections.Generic.List<HLP.Entries.ViewModel.Situacao_tributaria_pisService.PesquisaPadraoModelContract> lcamposSqlNotNull {
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
        public HLP.Entries.ViewModel.Situacao_tributaria_pisService.statusModel status {
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Situacao_tributaria_pisService.IserviceSituacao_tributaria_pis")]
    public interface IserviceSituacao_tributaria_pis {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceSituacao_tributaria_pis/Save", ReplyAction="http://tempuri.org/IserviceSituacao_tributaria_pis/SaveResponse")]
        int Save(HLP.Entries.Model.Models.Fiscal.Situacao_tributaria_pisModel objModel);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceSituacao_tributaria_pis/Save", ReplyAction="http://tempuri.org/IserviceSituacao_tributaria_pis/SaveResponse")]
        System.Threading.Tasks.Task<int> SaveAsync(HLP.Entries.Model.Models.Fiscal.Situacao_tributaria_pisModel objModel);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceSituacao_tributaria_pis/GetObjeto", ReplyAction="http://tempuri.org/IserviceSituacao_tributaria_pis/GetObjetoResponse")]
        HLP.Entries.Model.Models.Fiscal.Situacao_tributaria_pisModel GetObjeto(int idObjeto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceSituacao_tributaria_pis/GetObjeto", ReplyAction="http://tempuri.org/IserviceSituacao_tributaria_pis/GetObjetoResponse")]
        System.Threading.Tasks.Task<HLP.Entries.Model.Models.Fiscal.Situacao_tributaria_pisModel> GetObjetoAsync(int idObjeto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceSituacao_tributaria_pis/Delete", ReplyAction="http://tempuri.org/IserviceSituacao_tributaria_pis/DeleteResponse")]
        bool Delete(HLP.Entries.Model.Models.Fiscal.Situacao_tributaria_pisModel objModel);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceSituacao_tributaria_pis/Delete", ReplyAction="http://tempuri.org/IserviceSituacao_tributaria_pis/DeleteResponse")]
        System.Threading.Tasks.Task<bool> DeleteAsync(HLP.Entries.Model.Models.Fiscal.Situacao_tributaria_pisModel objModel);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceSituacao_tributaria_pis/Copy", ReplyAction="http://tempuri.org/IserviceSituacao_tributaria_pis/CopyResponse")]
        int Copy(HLP.Entries.Model.Models.Fiscal.Situacao_tributaria_pisModel objModel);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceSituacao_tributaria_pis/Copy", ReplyAction="http://tempuri.org/IserviceSituacao_tributaria_pis/CopyResponse")]
        System.Threading.Tasks.Task<int> CopyAsync(HLP.Entries.Model.Models.Fiscal.Situacao_tributaria_pisModel objModel);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IserviceSituacao_tributaria_pisChannel : HLP.Entries.ViewModel.Situacao_tributaria_pisService.IserviceSituacao_tributaria_pis, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class IserviceSituacao_tributaria_pisClient : System.ServiceModel.ClientBase<HLP.Entries.ViewModel.Situacao_tributaria_pisService.IserviceSituacao_tributaria_pis>, HLP.Entries.ViewModel.Situacao_tributaria_pisService.IserviceSituacao_tributaria_pis {
        
        public IserviceSituacao_tributaria_pisClient() {
        }
        
        public IserviceSituacao_tributaria_pisClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public IserviceSituacao_tributaria_pisClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IserviceSituacao_tributaria_pisClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IserviceSituacao_tributaria_pisClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int Save(HLP.Entries.Model.Models.Fiscal.Situacao_tributaria_pisModel objModel) {
            return base.Channel.Save(objModel);
        }
        
        public System.Threading.Tasks.Task<int> SaveAsync(HLP.Entries.Model.Models.Fiscal.Situacao_tributaria_pisModel objModel) {
            return base.Channel.SaveAsync(objModel);
        }
        
        public HLP.Entries.Model.Models.Fiscal.Situacao_tributaria_pisModel GetObjeto(int idObjeto) {
            return base.Channel.GetObjeto(idObjeto);
        }
        
        public System.Threading.Tasks.Task<HLP.Entries.Model.Models.Fiscal.Situacao_tributaria_pisModel> GetObjetoAsync(int idObjeto) {
            return base.Channel.GetObjetoAsync(idObjeto);
        }
        
        public bool Delete(HLP.Entries.Model.Models.Fiscal.Situacao_tributaria_pisModel objModel) {
            return base.Channel.Delete(objModel);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteAsync(HLP.Entries.Model.Models.Fiscal.Situacao_tributaria_pisModel objModel) {
            return base.Channel.DeleteAsync(objModel);
        }
        
        public int Copy(HLP.Entries.Model.Models.Fiscal.Situacao_tributaria_pisModel objModel) {
            return base.Channel.Copy(objModel);
        }
        
        public System.Threading.Tasks.Task<int> CopyAsync(HLP.Entries.Model.Models.Fiscal.Situacao_tributaria_pisModel objModel) {
            return base.Channel.CopyAsync(objModel);
        }
    }
}
