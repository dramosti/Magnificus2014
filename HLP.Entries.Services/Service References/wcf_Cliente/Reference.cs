﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34011
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HLP.Entries.Services.wcf_Cliente {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="modelBase", Namespace="http://schemas.datacontract.org/2004/07/HLP.Base.ClassesBases")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.Comercial.Cliente_fornecedor_fiscalModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.Comercial.Cliente_Fornecedor_ObservacaoModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.Comercial.Cliente_fornecedor_EnderecoModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.Comercial.Cliente_fornecedor_arquivoModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.Comercial.Cliente_fornecedor_contatoModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.Comercial.Cliente_fornecedor_produtoModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.Comercial.Cliente_fornecedor_representanteModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.Comercial.Cliente_fornecedorModel))]
    public partial class modelBase : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private HLP.Entries.Services.wcf_Cliente.PesquisaPadraoModelContract[] lcamposSqlNotNullField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private HLP.Entries.Services.wcf_Cliente.statusModel statusField;
        
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
        public HLP.Entries.Services.wcf_Cliente.PesquisaPadraoModelContract[] lcamposSqlNotNull {
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
        public HLP.Entries.Services.wcf_Cliente.statusModel status {
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
    [System.Runtime.Serialization.DataContractAttribute(Name="PesquisaPadraoModelContract", Namespace="http://schemas.datacontract.org/2004/07/HLP.Base.ClassesBases")]
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
    [System.Runtime.Serialization.DataContractAttribute(Name="statusModel", Namespace="http://schemas.datacontract.org/2004/07/HLP.Base.EnumsBases")]
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
    [System.Runtime.Serialization.DataContractAttribute(Name="TipoEndereco", Namespace="http://schemas.datacontract.org/2004/07/HLP.Comum.Resources.RecursosBases")]
    public enum TipoEndereco : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        COMERCIAL = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ENTREGA = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ENTREGA_ALT = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        NOTA_FISCAL = 3,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        RESIDÊNCIA = 4,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        SERVICO = 5,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        SWIFT = 6,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        PAGAMENTO = 7,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        OUTRO = 8,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TipoLogradouro", Namespace="http://schemas.datacontract.org/2004/07/HLP.Comum.Resources.RecursosBases")]
    public enum TipoLogradouro : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        AEROPORTO = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ALAMEDA = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        APARTAMENTO = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        AVENIDA = 3,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        BECO = 4,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        BLOCO = 5,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        CAMINHO = 6,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ESCADINHA = 7,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ESTAÇÃO = 8,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ESTRADA = 9,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        FAZENDA = 10,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        FORTALEZA = 11,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        GALERIA = 12,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        LADEIRA = 13,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        LARGO = 14,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        PRAÇA = 15,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        PRAIA = 16,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        PARQUE = 17,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        QUADRA = 18,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        QUILÔMETRO = 19,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        QUINTA = 20,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        RODOVIA = 21,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        RUA = 22,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        SUPER_QUADRA = 23,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        TRAVESSA = 24,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="wcf_Cliente.Iwcf_Cliente")]
    public interface Iwcf_Cliente {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Cliente/GetObject", ReplyAction="http://tempuri.org/Iwcf_Cliente/GetObjectResponse")]
        HLP.Entries.Model.Models.Comercial.Cliente_fornecedorModel GetObject(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Cliente/GetObject", ReplyAction="http://tempuri.org/Iwcf_Cliente/GetObjectResponse")]
        System.Threading.Tasks.Task<HLP.Entries.Model.Models.Comercial.Cliente_fornecedorModel> GetObjectAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Cliente/Save", ReplyAction="http://tempuri.org/Iwcf_Cliente/SaveResponse")]
        HLP.Entries.Model.Models.Comercial.Cliente_fornecedorModel Save(HLP.Entries.Model.Models.Comercial.Cliente_fornecedorModel obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Cliente/Save", ReplyAction="http://tempuri.org/Iwcf_Cliente/SaveResponse")]
        System.Threading.Tasks.Task<HLP.Entries.Model.Models.Comercial.Cliente_fornecedorModel> SaveAsync(HLP.Entries.Model.Models.Comercial.Cliente_fornecedorModel obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Cliente/Delete", ReplyAction="http://tempuri.org/Iwcf_Cliente/DeleteResponse")]
        bool Delete(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Cliente/Delete", ReplyAction="http://tempuri.org/Iwcf_Cliente/DeleteResponse")]
        System.Threading.Tasks.Task<bool> DeleteAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Cliente/Copy", ReplyAction="http://tempuri.org/Iwcf_Cliente/CopyResponse")]
        HLP.Entries.Model.Models.Comercial.Cliente_fornecedorModel Copy(HLP.Entries.Model.Models.Comercial.Cliente_fornecedorModel obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Cliente/Copy", ReplyAction="http://tempuri.org/Iwcf_Cliente/CopyResponse")]
        System.Threading.Tasks.Task<HLP.Entries.Model.Models.Comercial.Cliente_fornecedorModel> CopyAsync(HLP.Entries.Model.Models.Comercial.Cliente_fornecedorModel obj);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface Iwcf_ClienteChannel : HLP.Entries.Services.wcf_Cliente.Iwcf_Cliente, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Iwcf_ClienteClient : System.ServiceModel.ClientBase<HLP.Entries.Services.wcf_Cliente.Iwcf_Cliente>, HLP.Entries.Services.wcf_Cliente.Iwcf_Cliente {
        
        public Iwcf_ClienteClient() {
        }
        
        public Iwcf_ClienteClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Iwcf_ClienteClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Iwcf_ClienteClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Iwcf_ClienteClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public HLP.Entries.Model.Models.Comercial.Cliente_fornecedorModel GetObject(int id) {
            return base.Channel.GetObject(id);
        }
        
        public System.Threading.Tasks.Task<HLP.Entries.Model.Models.Comercial.Cliente_fornecedorModel> GetObjectAsync(int id) {
            return base.Channel.GetObjectAsync(id);
        }
        
        public HLP.Entries.Model.Models.Comercial.Cliente_fornecedorModel Save(HLP.Entries.Model.Models.Comercial.Cliente_fornecedorModel obj) {
            return base.Channel.Save(obj);
        }
        
        public System.Threading.Tasks.Task<HLP.Entries.Model.Models.Comercial.Cliente_fornecedorModel> SaveAsync(HLP.Entries.Model.Models.Comercial.Cliente_fornecedorModel obj) {
            return base.Channel.SaveAsync(obj);
        }
        
        public bool Delete(int id) {
            return base.Channel.Delete(id);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteAsync(int id) {
            return base.Channel.DeleteAsync(id);
        }
        
        public HLP.Entries.Model.Models.Comercial.Cliente_fornecedorModel Copy(HLP.Entries.Model.Models.Comercial.Cliente_fornecedorModel obj) {
            return base.Channel.Copy(obj);
        }
        
        public System.Threading.Tasks.Task<HLP.Entries.Model.Models.Comercial.Cliente_fornecedorModel> CopyAsync(HLP.Entries.Model.Models.Comercial.Cliente_fornecedorModel obj) {
            return base.Channel.CopyAsync(obj);
        }
    }
}