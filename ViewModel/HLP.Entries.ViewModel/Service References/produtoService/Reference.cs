﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.32559
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HLP.Entries.ViewModel.produtoService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="modelBase", Namespace="http://schemas.datacontract.org/2004/07/HLP.Comum.Model.Models")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.Gerais.ConversaoModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.Comercial.Produto_Fornecedor_HomologadoModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.Comercial.Produto_RevisaoModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.Comercial.ProdutoModel))]
    public partial class modelBase : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.List<HLP.Entries.ViewModel.produtoService.PesquisaPadraoModelContract> lcamposSqlNotNullField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private HLP.Entries.ViewModel.produtoService.statusModel statusField;
        
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
        public System.Collections.Generic.List<HLP.Entries.ViewModel.produtoService.PesquisaPadraoModelContract> lcamposSqlNotNull {
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
        public HLP.Entries.ViewModel.produtoService.statusModel status {
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
    [System.Runtime.Serialization.DataContractAttribute(Name="TipoArredondamento", Namespace="http://schemas.datacontract.org/2004/07/HLP.Comum.Resources.RecursosBases")]
    public enum TipoArredondamento : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        PARABAIXO = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        PARACIMA = 1,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="produtoService.IserviceProduto")]
    public interface IserviceProduto {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceProduto/getProduto", ReplyAction="http://tempuri.org/IserviceProduto/getProdutoResponse")]
        HLP.Entries.Model.Models.Comercial.ProdutoModel getProduto(int idProduto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceProduto/getProduto", ReplyAction="http://tempuri.org/IserviceProduto/getProdutoResponse")]
        System.Threading.Tasks.Task<HLP.Entries.Model.Models.Comercial.ProdutoModel> getProdutoAsync(int idProduto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceProduto/saveProduto", ReplyAction="http://tempuri.org/IserviceProduto/saveProdutoResponse")]
        int saveProduto(HLP.Entries.Model.Models.Comercial.ProdutoModel objProduto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceProduto/saveProduto", ReplyAction="http://tempuri.org/IserviceProduto/saveProdutoResponse")]
        System.Threading.Tasks.Task<int> saveProdutoAsync(HLP.Entries.Model.Models.Comercial.ProdutoModel objProduto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceProduto/deleteProduto", ReplyAction="http://tempuri.org/IserviceProduto/deleteProdutoResponse")]
        bool deleteProduto(int idProduto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceProduto/deleteProduto", ReplyAction="http://tempuri.org/IserviceProduto/deleteProdutoResponse")]
        System.Threading.Tasks.Task<bool> deleteProdutoAsync(int idProduto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceProduto/copyProduto", ReplyAction="http://tempuri.org/IserviceProduto/copyProdutoResponse")]
        int copyProduto(HLP.Entries.Model.Models.Comercial.ProdutoModel objProduto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceProduto/copyProduto", ReplyAction="http://tempuri.org/IserviceProduto/copyProdutoResponse")]
        System.Threading.Tasks.Task<int> copyProdutoAsync(HLP.Entries.Model.Models.Comercial.ProdutoModel objProduto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceProduto/getAll", ReplyAction="http://tempuri.org/IserviceProduto/getAllResponse")]
        System.Collections.Generic.List<HLP.Entries.Model.Models.Comercial.ProdutoModel> getAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceProduto/getAll", ReplyAction="http://tempuri.org/IserviceProduto/getAllResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<HLP.Entries.Model.Models.Comercial.ProdutoModel>> getAllAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IserviceProdutoChannel : HLP.Entries.ViewModel.produtoService.IserviceProduto, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class IserviceProdutoClient : System.ServiceModel.ClientBase<HLP.Entries.ViewModel.produtoService.IserviceProduto>, HLP.Entries.ViewModel.produtoService.IserviceProduto {
        
        public IserviceProdutoClient() {
        }
        
        public IserviceProdutoClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public IserviceProdutoClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IserviceProdutoClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IserviceProdutoClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public HLP.Entries.Model.Models.Comercial.ProdutoModel getProduto(int idProduto) {
            return base.Channel.getProduto(idProduto);
        }
        
        public System.Threading.Tasks.Task<HLP.Entries.Model.Models.Comercial.ProdutoModel> getProdutoAsync(int idProduto) {
            return base.Channel.getProdutoAsync(idProduto);
        }
        
        public int saveProduto(HLP.Entries.Model.Models.Comercial.ProdutoModel objProduto) {
            return base.Channel.saveProduto(objProduto);
        }
        
        public System.Threading.Tasks.Task<int> saveProdutoAsync(HLP.Entries.Model.Models.Comercial.ProdutoModel objProduto) {
            return base.Channel.saveProdutoAsync(objProduto);
        }
        
        public bool deleteProduto(int idProduto) {
            return base.Channel.deleteProduto(idProduto);
        }
        
        public System.Threading.Tasks.Task<bool> deleteProdutoAsync(int idProduto) {
            return base.Channel.deleteProdutoAsync(idProduto);
        }
        
        public int copyProduto(HLP.Entries.Model.Models.Comercial.ProdutoModel objProduto) {
            return base.Channel.copyProduto(objProduto);
        }
        
        public System.Threading.Tasks.Task<int> copyProdutoAsync(HLP.Entries.Model.Models.Comercial.ProdutoModel objProduto) {
            return base.Channel.copyProdutoAsync(objProduto);
        }
        
        public System.Collections.Generic.List<HLP.Entries.Model.Models.Comercial.ProdutoModel> getAll() {
            return base.Channel.getAll();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<HLP.Entries.Model.Models.Comercial.ProdutoModel>> getAllAsync() {
            return base.Channel.getAllAsync();
        }
    }
}
