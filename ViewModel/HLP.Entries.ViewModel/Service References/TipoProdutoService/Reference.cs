﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18051
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HLP.Entries.ViewModel.TipoProdutoService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="modelBase", Namespace="http://schemas.datacontract.org/2004/07/HLP.Comum.Model.Models")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Comercial.Tipo_produtoModel))]
    public partial class modelBase : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private HLP.Entries.ViewModel.TipoProdutoService.PesquisaPadraoModelContract[] lcamposSqlNotNullField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private HLP.Entries.ViewModel.TipoProdutoService.statusModel statusField;
        
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
        public HLP.Entries.ViewModel.TipoProdutoService.PesquisaPadraoModelContract[] lcamposSqlNotNull {
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
        public HLP.Entries.ViewModel.TipoProdutoService.statusModel status {
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="TipoProdutoService.IserviceTipoProduto")]
    public interface IserviceTipoProduto {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceTipoProduto/GetTipo", ReplyAction="http://tempuri.org/IserviceTipoProduto/GetTipoResponse")]
        HLP.Entries.Model.Comercial.Tipo_produtoModel GetTipo(int idTipoProduto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceTipoProduto/GetTipo", ReplyAction="http://tempuri.org/IserviceTipoProduto/GetTipoResponse")]
        System.Threading.Tasks.Task<HLP.Entries.Model.Comercial.Tipo_produtoModel> GetTipoAsync(int idTipoProduto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceTipoProduto/Save", ReplyAction="http://tempuri.org/IserviceTipoProduto/SaveResponse")]
        void Save(HLP.Entries.Model.Comercial.Tipo_produtoModel tipo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceTipoProduto/Save", ReplyAction="http://tempuri.org/IserviceTipoProduto/SaveResponse")]
        System.Threading.Tasks.Task SaveAsync(HLP.Entries.Model.Comercial.Tipo_produtoModel tipo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceTipoProduto/Delete", ReplyAction="http://tempuri.org/IserviceTipoProduto/DeleteResponse")]
        void Delete(int idTipoProduto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceTipoProduto/Delete", ReplyAction="http://tempuri.org/IserviceTipoProduto/DeleteResponse")]
        System.Threading.Tasks.Task DeleteAsync(int idTipoProduto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceTipoProduto/Copy", ReplyAction="http://tempuri.org/IserviceTipoProduto/CopyResponse")]
        int Copy(int idTipoProduto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceTipoProduto/Copy", ReplyAction="http://tempuri.org/IserviceTipoProduto/CopyResponse")]
        System.Threading.Tasks.Task<int> CopyAsync(int idTipoProduto);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IserviceTipoProdutoChannel : HLP.Entries.ViewModel.TipoProdutoService.IserviceTipoProduto, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class IserviceTipoProdutoClient : System.ServiceModel.ClientBase<HLP.Entries.ViewModel.TipoProdutoService.IserviceTipoProduto>, HLP.Entries.ViewModel.TipoProdutoService.IserviceTipoProduto {
        
        public IserviceTipoProdutoClient() {
        }
        
        public IserviceTipoProdutoClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public IserviceTipoProdutoClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IserviceTipoProdutoClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IserviceTipoProdutoClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public HLP.Entries.Model.Comercial.Tipo_produtoModel GetTipo(int idTipoProduto) {
            return base.Channel.GetTipo(idTipoProduto);
        }
        
        public System.Threading.Tasks.Task<HLP.Entries.Model.Comercial.Tipo_produtoModel> GetTipoAsync(int idTipoProduto) {
            return base.Channel.GetTipoAsync(idTipoProduto);
        }
        
        public void Save(HLP.Entries.Model.Comercial.Tipo_produtoModel tipo) {
            base.Channel.Save(tipo);
        }
        
        public System.Threading.Tasks.Task SaveAsync(HLP.Entries.Model.Comercial.Tipo_produtoModel tipo) {
            return base.Channel.SaveAsync(tipo);
        }
        
        public void Delete(int idTipoProduto) {
            base.Channel.Delete(idTipoProduto);
        }
        
        public System.Threading.Tasks.Task DeleteAsync(int idTipoProduto) {
            return base.Channel.DeleteAsync(idTipoProduto);
        }
        
        public int Copy(int idTipoProduto) {
            return base.Channel.Copy(idTipoProduto);
        }
        
        public System.Threading.Tasks.Task<int> CopyAsync(int idTipoProduto) {
            return base.Channel.CopyAsync(idTipoProduto);
        }
    }
}
