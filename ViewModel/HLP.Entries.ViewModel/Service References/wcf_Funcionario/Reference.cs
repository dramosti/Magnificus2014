﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34011
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HLP.Entries.ViewModel.wcf_Funcionario {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="modelBase", Namespace="http://schemas.datacontract.org/2004/07/HLP.Comum.Model.Models")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.ViewModel.wcf_Funcionario.EnderecoModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.Gerais.Familia_produtoModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.Gerais.Familia_Produto_ClassesModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.Gerais.Funcionario_AcessoModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.Gerais.Funcionario_ArquivoModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.Gerais.Funcionario_CertificacaoModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.Gerais.Funcionario_Comissao_ProdutoModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.Gerais.Funcionario_Margem_Lucro_ComissaoModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.Gerais.FuncionarioModel))]
    public partial class modelBase : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.List<HLP.Entries.ViewModel.wcf_Funcionario.PesquisaPadraoModelContract> lcamposSqlNotNullField;
        
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
        public System.Collections.Generic.List<HLP.Entries.ViewModel.wcf_Funcionario.PesquisaPadraoModelContract> lcamposSqlNotNull {
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
    [System.Runtime.Serialization.DataContractAttribute(Name="EnderecoModel", Namespace="http://schemas.datacontract.org/2004/07/HLP.Comum.Model.Models")]
    [System.SerializableAttribute()]
    public partial class EnderecoModel : HLP.Entries.ViewModel.wcf_Funcionario.modelBase {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> idAgenciaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idCidadeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> idClienteFornecedorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> idContatoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> idEmpresaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> idEnderecoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> idFuncionarioField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> idSiteField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> idTransportadorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nNumeroField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private byte stLogradouroField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<byte> stPrincipalField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private byte stTipoEnderecoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string xBairroField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string xCEPField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string xCaixaPostalField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string xComplementoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string xEnderecoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string xNomeField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> idAgencia {
            get {
                return this.idAgenciaField;
            }
            set {
                if ((this.idAgenciaField.Equals(value) != true)) {
                    this.idAgenciaField = value;
                    this.RaisePropertyChanged("idAgencia");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int idCidade {
            get {
                return this.idCidadeField;
            }
            set {
                if ((this.idCidadeField.Equals(value) != true)) {
                    this.idCidadeField = value;
                    this.RaisePropertyChanged("idCidade");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> idClienteFornecedor {
            get {
                return this.idClienteFornecedorField;
            }
            set {
                if ((this.idClienteFornecedorField.Equals(value) != true)) {
                    this.idClienteFornecedorField = value;
                    this.RaisePropertyChanged("idClienteFornecedor");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> idContato {
            get {
                return this.idContatoField;
            }
            set {
                if ((this.idContatoField.Equals(value) != true)) {
                    this.idContatoField = value;
                    this.RaisePropertyChanged("idContato");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> idEmpresa {
            get {
                return this.idEmpresaField;
            }
            set {
                if ((this.idEmpresaField.Equals(value) != true)) {
                    this.idEmpresaField = value;
                    this.RaisePropertyChanged("idEmpresa");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> idEndereco {
            get {
                return this.idEnderecoField;
            }
            set {
                if ((this.idEnderecoField.Equals(value) != true)) {
                    this.idEnderecoField = value;
                    this.RaisePropertyChanged("idEndereco");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> idFuncionario {
            get {
                return this.idFuncionarioField;
            }
            set {
                if ((this.idFuncionarioField.Equals(value) != true)) {
                    this.idFuncionarioField = value;
                    this.RaisePropertyChanged("idFuncionario");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> idSite {
            get {
                return this.idSiteField;
            }
            set {
                if ((this.idSiteField.Equals(value) != true)) {
                    this.idSiteField = value;
                    this.RaisePropertyChanged("idSite");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> idTransportador {
            get {
                return this.idTransportadorField;
            }
            set {
                if ((this.idTransportadorField.Equals(value) != true)) {
                    this.idTransportadorField = value;
                    this.RaisePropertyChanged("idTransportador");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string nNumero {
            get {
                return this.nNumeroField;
            }
            set {
                if ((object.ReferenceEquals(this.nNumeroField, value) != true)) {
                    this.nNumeroField = value;
                    this.RaisePropertyChanged("nNumero");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte stLogradouro {
            get {
                return this.stLogradouroField;
            }
            set {
                if ((this.stLogradouroField.Equals(value) != true)) {
                    this.stLogradouroField = value;
                    this.RaisePropertyChanged("stLogradouro");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<byte> stPrincipal {
            get {
                return this.stPrincipalField;
            }
            set {
                if ((this.stPrincipalField.Equals(value) != true)) {
                    this.stPrincipalField = value;
                    this.RaisePropertyChanged("stPrincipal");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte stTipoEndereco {
            get {
                return this.stTipoEnderecoField;
            }
            set {
                if ((this.stTipoEnderecoField.Equals(value) != true)) {
                    this.stTipoEnderecoField = value;
                    this.RaisePropertyChanged("stTipoEndereco");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string xBairro {
            get {
                return this.xBairroField;
            }
            set {
                if ((object.ReferenceEquals(this.xBairroField, value) != true)) {
                    this.xBairroField = value;
                    this.RaisePropertyChanged("xBairro");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string xCEP {
            get {
                return this.xCEPField;
            }
            set {
                if ((object.ReferenceEquals(this.xCEPField, value) != true)) {
                    this.xCEPField = value;
                    this.RaisePropertyChanged("xCEP");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string xCaixaPostal {
            get {
                return this.xCaixaPostalField;
            }
            set {
                if ((object.ReferenceEquals(this.xCaixaPostalField, value) != true)) {
                    this.xCaixaPostalField = value;
                    this.RaisePropertyChanged("xCaixaPostal");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string xComplemento {
            get {
                return this.xComplementoField;
            }
            set {
                if ((object.ReferenceEquals(this.xComplementoField, value) != true)) {
                    this.xComplementoField = value;
                    this.RaisePropertyChanged("xComplemento");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string xEndereco {
            get {
                return this.xEnderecoField;
            }
            set {
                if ((object.ReferenceEquals(this.xEnderecoField, value) != true)) {
                    this.xEnderecoField = value;
                    this.RaisePropertyChanged("xEndereco");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string xNome {
            get {
                return this.xNomeField;
            }
            set {
                if ((object.ReferenceEquals(this.xNomeField, value) != true)) {
                    this.xNomeField = value;
                    this.RaisePropertyChanged("xNome");
                }
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="wcf_Funcionario.Iwcf_Funcionario")]
    public interface Iwcf_Funcionario {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Funcionario/getFuncionario", ReplyAction="http://tempuri.org/Iwcf_Funcionario/getFuncionarioResponse")]
        HLP.Entries.Model.Models.Gerais.FuncionarioModel getFuncionario(int idFuncionario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Funcionario/getFuncionario", ReplyAction="http://tempuri.org/Iwcf_Funcionario/getFuncionarioResponse")]
        System.Threading.Tasks.Task<HLP.Entries.Model.Models.Gerais.FuncionarioModel> getFuncionarioAsync(int idFuncionario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Funcionario/saveFuncionario", ReplyAction="http://tempuri.org/Iwcf_Funcionario/saveFuncionarioResponse")]
        HLP.Entries.Model.Models.Gerais.FuncionarioModel saveFuncionario(HLP.Entries.Model.Models.Gerais.FuncionarioModel objFuncionario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Funcionario/saveFuncionario", ReplyAction="http://tempuri.org/Iwcf_Funcionario/saveFuncionarioResponse")]
        System.Threading.Tasks.Task<HLP.Entries.Model.Models.Gerais.FuncionarioModel> saveFuncionarioAsync(HLP.Entries.Model.Models.Gerais.FuncionarioModel objFuncionario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Funcionario/deleteFuncionario", ReplyAction="http://tempuri.org/Iwcf_Funcionario/deleteFuncionarioResponse")]
        bool deleteFuncionario(int idFuncionario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Funcionario/deleteFuncionario", ReplyAction="http://tempuri.org/Iwcf_Funcionario/deleteFuncionarioResponse")]
        System.Threading.Tasks.Task<bool> deleteFuncionarioAsync(int idFuncionario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Funcionario/copyFuncionario", ReplyAction="http://tempuri.org/Iwcf_Funcionario/copyFuncionarioResponse")]
        HLP.Entries.Model.Models.Gerais.FuncionarioModel copyFuncionario(HLP.Entries.Model.Models.Gerais.FuncionarioModel objFuncionario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Funcionario/copyFuncionario", ReplyAction="http://tempuri.org/Iwcf_Funcionario/copyFuncionarioResponse")]
        System.Threading.Tasks.Task<HLP.Entries.Model.Models.Gerais.FuncionarioModel> copyFuncionarioAsync(HLP.Entries.Model.Models.Gerais.FuncionarioModel objFuncionario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Funcionario/GetHierarquiaFuncionario", ReplyAction="http://tempuri.org/Iwcf_Funcionario/GetHierarquiaFuncionarioResponse")]
        HLP.Comum.Resources.Models.modelToTreeView GetHierarquiaFuncionario(int idFuncionario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Funcionario/GetHierarquiaFuncionario", ReplyAction="http://tempuri.org/Iwcf_Funcionario/GetHierarquiaFuncionarioResponse")]
        System.Threading.Tasks.Task<HLP.Comum.Resources.Models.modelToTreeView> GetHierarquiaFuncionarioAsync(int idFuncionario);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface Iwcf_FuncionarioChannel : HLP.Entries.ViewModel.wcf_Funcionario.Iwcf_Funcionario, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Iwcf_FuncionarioClient : System.ServiceModel.ClientBase<HLP.Entries.ViewModel.wcf_Funcionario.Iwcf_Funcionario>, HLP.Entries.ViewModel.wcf_Funcionario.Iwcf_Funcionario {
        
        public Iwcf_FuncionarioClient() {
        }
        
        public Iwcf_FuncionarioClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Iwcf_FuncionarioClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Iwcf_FuncionarioClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Iwcf_FuncionarioClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public HLP.Entries.Model.Models.Gerais.FuncionarioModel getFuncionario(int idFuncionario) {
            return base.Channel.getFuncionario(idFuncionario);
        }
        
        public System.Threading.Tasks.Task<HLP.Entries.Model.Models.Gerais.FuncionarioModel> getFuncionarioAsync(int idFuncionario) {
            return base.Channel.getFuncionarioAsync(idFuncionario);
        }
        
        public HLP.Entries.Model.Models.Gerais.FuncionarioModel saveFuncionario(HLP.Entries.Model.Models.Gerais.FuncionarioModel objFuncionario) {
            return base.Channel.saveFuncionario(objFuncionario);
        }
        
        public System.Threading.Tasks.Task<HLP.Entries.Model.Models.Gerais.FuncionarioModel> saveFuncionarioAsync(HLP.Entries.Model.Models.Gerais.FuncionarioModel objFuncionario) {
            return base.Channel.saveFuncionarioAsync(objFuncionario);
        }
        
        public bool deleteFuncionario(int idFuncionario) {
            return base.Channel.deleteFuncionario(idFuncionario);
        }
        
        public System.Threading.Tasks.Task<bool> deleteFuncionarioAsync(int idFuncionario) {
            return base.Channel.deleteFuncionarioAsync(idFuncionario);
        }
        
        public HLP.Entries.Model.Models.Gerais.FuncionarioModel copyFuncionario(HLP.Entries.Model.Models.Gerais.FuncionarioModel objFuncionario) {
            return base.Channel.copyFuncionario(objFuncionario);
        }
        
        public System.Threading.Tasks.Task<HLP.Entries.Model.Models.Gerais.FuncionarioModel> copyFuncionarioAsync(HLP.Entries.Model.Models.Gerais.FuncionarioModel objFuncionario) {
            return base.Channel.copyFuncionarioAsync(objFuncionario);
        }
        
        public HLP.Comum.Resources.Models.modelToTreeView GetHierarquiaFuncionario(int idFuncionario) {
            return base.Channel.GetHierarquiaFuncionario(idFuncionario);
        }
        
        public System.Threading.Tasks.Task<HLP.Comum.Resources.Models.modelToTreeView> GetHierarquiaFuncionarioAsync(int idFuncionario) {
            return base.Channel.GetHierarquiaFuncionarioAsync(idFuncionario);
        }
    }
}
