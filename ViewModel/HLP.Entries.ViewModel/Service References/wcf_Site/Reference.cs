﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34011
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HLP.Entries.ViewModel.wcf_Site {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="modelBase", Namespace="http://schemas.datacontract.org/2004/07/HLP.Comum.Model.Models")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.Gerais.Site_enderecoModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.Gerais.SiteModel))]
    public partial class modelBase : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.List<HLP.Entries.ViewModel.wcf_Site.PesquisaPadraoModelContract> lcamposSqlNotNullField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private HLP.Comum.Resources.RecursosBases.statusModel statusField;
        
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
        public System.Collections.Generic.List<HLP.Entries.ViewModel.wcf_Site.PesquisaPadraoModelContract> lcamposSqlNotNull {
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
        public HLP.Comum.Resources.RecursosBases.statusModel status {
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="wcf_Site.Iwcf_Site")]
    public interface Iwcf_Site {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Site/Copy", ReplyAction="http://tempuri.org/Iwcf_Site/CopyResponse")]
        HLP.Entries.Model.Models.Gerais.SiteModel Copy(HLP.Entries.Model.Models.Gerais.SiteModel obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Site/Copy", ReplyAction="http://tempuri.org/Iwcf_Site/CopyResponse")]
        System.Threading.Tasks.Task<HLP.Entries.Model.Models.Gerais.SiteModel> CopyAsync(HLP.Entries.Model.Models.Gerais.SiteModel obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Site/Delete", ReplyAction="http://tempuri.org/Iwcf_Site/DeleteResponse")]
        bool Delete(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Site/Delete", ReplyAction="http://tempuri.org/Iwcf_Site/DeleteResponse")]
        System.Threading.Tasks.Task<bool> DeleteAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Site/Save", ReplyAction="http://tempuri.org/Iwcf_Site/SaveResponse")]
        HLP.Entries.Model.Models.Gerais.SiteModel Save(HLP.Entries.Model.Models.Gerais.SiteModel obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Site/Save", ReplyAction="http://tempuri.org/Iwcf_Site/SaveResponse")]
        System.Threading.Tasks.Task<HLP.Entries.Model.Models.Gerais.SiteModel> SaveAsync(HLP.Entries.Model.Models.Gerais.SiteModel obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Site/GetObject", ReplyAction="http://tempuri.org/Iwcf_Site/GetObjectResponse")]
        HLP.Entries.Model.Models.Gerais.SiteModel GetObject(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Site/GetObject", ReplyAction="http://tempuri.org/Iwcf_Site/GetObjectResponse")]
        System.Threading.Tasks.Task<HLP.Entries.Model.Models.Gerais.SiteModel> GetObjectAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Site/GetHierarquiaSite", ReplyAction="http://tempuri.org/Iwcf_Site/GetHierarquiaSiteResponse")]
        HLP.Comum.Resources.Models.modelToTreeView GetHierarquiaSite(int idSite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Site/GetHierarquiaSite", ReplyAction="http://tempuri.org/Iwcf_Site/GetHierarquiaSiteResponse")]
        System.Threading.Tasks.Task<HLP.Comum.Resources.Models.modelToTreeView> GetHierarquiaSiteAsync(int idSite);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface Iwcf_SiteChannel : HLP.Entries.ViewModel.wcf_Site.Iwcf_Site, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Iwcf_SiteClient : System.ServiceModel.ClientBase<HLP.Entries.ViewModel.wcf_Site.Iwcf_Site>, HLP.Entries.ViewModel.wcf_Site.Iwcf_Site {
        
        public Iwcf_SiteClient() {
        }
        
        public Iwcf_SiteClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Iwcf_SiteClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Iwcf_SiteClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Iwcf_SiteClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public HLP.Entries.Model.Models.Gerais.SiteModel Copy(HLP.Entries.Model.Models.Gerais.SiteModel obj) {
            return base.Channel.Copy(obj);
        }
        
        public System.Threading.Tasks.Task<HLP.Entries.Model.Models.Gerais.SiteModel> CopyAsync(HLP.Entries.Model.Models.Gerais.SiteModel obj) {
            return base.Channel.CopyAsync(obj);
        }
        
        public bool Delete(int id) {
            return base.Channel.Delete(id);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteAsync(int id) {
            return base.Channel.DeleteAsync(id);
        }
        
        public HLP.Entries.Model.Models.Gerais.SiteModel Save(HLP.Entries.Model.Models.Gerais.SiteModel obj) {
            return base.Channel.Save(obj);
        }
        
        public System.Threading.Tasks.Task<HLP.Entries.Model.Models.Gerais.SiteModel> SaveAsync(HLP.Entries.Model.Models.Gerais.SiteModel obj) {
            return base.Channel.SaveAsync(obj);
        }
        
        public HLP.Entries.Model.Models.Gerais.SiteModel GetObject(int id) {
            return base.Channel.GetObject(id);
        }
        
        public System.Threading.Tasks.Task<HLP.Entries.Model.Models.Gerais.SiteModel> GetObjectAsync(int id) {
            return base.Channel.GetObjectAsync(id);
        }
        
        public HLP.Comum.Resources.Models.modelToTreeView GetHierarquiaSite(int idSite) {
            return base.Channel.GetHierarquiaSite(idSite);
        }
        
        public System.Threading.Tasks.Task<HLP.Comum.Resources.Models.modelToTreeView> GetHierarquiaSiteAsync(int idSite) {
            return base.Channel.GetHierarquiaSiteAsync(idSite);
        }
    }
}
