﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HLP.Entries.Services.wcf_Contato {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="modelBase", Namespace="http://schemas.datacontract.org/2004/07/HLP.Base.ClassesBases")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Services.wcf_Contato.modelComum))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Components.Model.Models.EnderecoModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Components.Model.Models.ContatoModel))]
    public partial class modelBase : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
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
    [System.Runtime.Serialization.DataContractAttribute(Name="modelComum", Namespace="http://schemas.datacontract.org/2004/07/HLP.Comum.Model.Models")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Components.Model.Models.EnderecoModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Components.Model.Models.ContatoModel))]
    public partial class modelComum : HLP.Entries.Services.wcf_Contato.modelBase {
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="wcf_Contato.Iwcf_Contato")]
    public interface Iwcf_Contato {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Contato/Save", ReplyAction="http://tempuri.org/Iwcf_Contato/SaveResponse")]
        HLP.Components.Model.Models.ContatoModel Save(HLP.Components.Model.Models.ContatoModel objContato);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Contato/Save", ReplyAction="http://tempuri.org/Iwcf_Contato/SaveResponse")]
        System.Threading.Tasks.Task<HLP.Components.Model.Models.ContatoModel> SaveAsync(HLP.Components.Model.Models.ContatoModel objContato);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Contato/Delete", ReplyAction="http://tempuri.org/Iwcf_Contato/DeleteResponse")]
        bool Delete(int idContato);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Contato/Delete", ReplyAction="http://tempuri.org/Iwcf_Contato/DeleteResponse")]
        System.Threading.Tasks.Task<bool> DeleteAsync(int idContato);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Contato/Copy", ReplyAction="http://tempuri.org/Iwcf_Contato/CopyResponse")]
        HLP.Components.Model.Models.ContatoModel Copy(HLP.Components.Model.Models.ContatoModel objContato);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Contato/Copy", ReplyAction="http://tempuri.org/Iwcf_Contato/CopyResponse")]
        System.Threading.Tasks.Task<HLP.Components.Model.Models.ContatoModel> CopyAsync(HLP.Components.Model.Models.ContatoModel objContato);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Contato/GetObject", ReplyAction="http://tempuri.org/Iwcf_Contato/GetObjectResponse")]
        HLP.Components.Model.Models.ContatoModel GetObject(int idContato);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Contato/GetObject", ReplyAction="http://tempuri.org/Iwcf_Contato/GetObjectResponse")]
        System.Threading.Tasks.Task<HLP.Components.Model.Models.ContatoModel> GetObjectAsync(int idContato);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Contato/GetContato_ByClienteFornec", ReplyAction="http://tempuri.org/Iwcf_Contato/GetContato_ByClienteFornecResponse")]
        System.Collections.Generic.List<HLP.Components.Model.Models.ContatoModel> GetContato_ByClienteFornec(int idContato);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Contato/GetContato_ByClienteFornec", ReplyAction="http://tempuri.org/Iwcf_Contato/GetContato_ByClienteFornecResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<HLP.Components.Model.Models.ContatoModel>> GetContato_ByClienteFornecAsync(int idContato);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface Iwcf_ContatoChannel : HLP.Entries.Services.wcf_Contato.Iwcf_Contato, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Iwcf_ContatoClient : System.ServiceModel.ClientBase<HLP.Entries.Services.wcf_Contato.Iwcf_Contato>, HLP.Entries.Services.wcf_Contato.Iwcf_Contato {
        
        public Iwcf_ContatoClient() {
        }
        
        public Iwcf_ContatoClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Iwcf_ContatoClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Iwcf_ContatoClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Iwcf_ContatoClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public HLP.Components.Model.Models.ContatoModel Save(HLP.Components.Model.Models.ContatoModel objContato) {
            return base.Channel.Save(objContato);
        }
        
        public System.Threading.Tasks.Task<HLP.Components.Model.Models.ContatoModel> SaveAsync(HLP.Components.Model.Models.ContatoModel objContato) {
            return base.Channel.SaveAsync(objContato);
        }
        
        public bool Delete(int idContato) {
            return base.Channel.Delete(idContato);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteAsync(int idContato) {
            return base.Channel.DeleteAsync(idContato);
        }
        
        public HLP.Components.Model.Models.ContatoModel Copy(HLP.Components.Model.Models.ContatoModel objContato) {
            return base.Channel.Copy(objContato);
        }
        
        public System.Threading.Tasks.Task<HLP.Components.Model.Models.ContatoModel> CopyAsync(HLP.Components.Model.Models.ContatoModel objContato) {
            return base.Channel.CopyAsync(objContato);
        }
        
        public HLP.Components.Model.Models.ContatoModel GetObject(int idContato) {
            return base.Channel.GetObject(idContato);
        }
        
        public System.Threading.Tasks.Task<HLP.Components.Model.Models.ContatoModel> GetObjectAsync(int idContato) {
            return base.Channel.GetObjectAsync(idContato);
        }
        
        public System.Collections.Generic.List<HLP.Components.Model.Models.ContatoModel> GetContato_ByClienteFornec(int idContato) {
            return base.Channel.GetContato_ByClienteFornec(idContato);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<HLP.Components.Model.Models.ContatoModel>> GetContato_ByClienteFornecAsync(int idContato) {
            return base.Channel.GetContato_ByClienteFornecAsync(idContato);
        }
    }
}
