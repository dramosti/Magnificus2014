﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HLP.Entries.Services.wcf_Funcionario {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="modelBase", Namespace="http://schemas.datacontract.org/2004/07/HLP.Base.ClassesBases")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Services.wcf_Funcionario.DocumentosModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Services.wcf_Funcionario.modelComum))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.Gerais.Familia_produtoModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.Gerais.Familia_Produto_ClassesModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.Gerais.Funcionario_AcessoModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.Gerais.Funcionario_ArquivoModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.Gerais.Funcionario_CertificacaoModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.Gerais.Funcionario_Comissao_ProdutoModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.Gerais.Funcionario_Margem_Lucro_ComissaoModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Components.Model.Models.EnderecoModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.Gerais.FuncionarioModel))]
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
    [System.Runtime.Serialization.DataContractAttribute(Name="DocumentosModel", Namespace="http://schemas.datacontract.org/2004/07/HLP.Comum.Model.Models")]
    [System.SerializableAttribute()]
    public partial class DocumentosModel : HLP.Entries.Services.wcf_Funcionario.modelBase {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idDocumentoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idEmpresaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idPkField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string xDocumentoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string xExtensaoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string xNameTableField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string xPathField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int idDocumento {
            get {
                return this.idDocumentoField;
            }
            set {
                if ((this.idDocumentoField.Equals(value) != true)) {
                    this.idDocumentoField = value;
                    this.RaisePropertyChanged("idDocumento");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int idEmpresa {
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
        public int idPk {
            get {
                return this.idPkField;
            }
            set {
                if ((this.idPkField.Equals(value) != true)) {
                    this.idPkField = value;
                    this.RaisePropertyChanged("idPk");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string xDocumento {
            get {
                return this.xDocumentoField;
            }
            set {
                if ((object.ReferenceEquals(this.xDocumentoField, value) != true)) {
                    this.xDocumentoField = value;
                    this.RaisePropertyChanged("xDocumento");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string xExtensao {
            get {
                return this.xExtensaoField;
            }
            set {
                if ((object.ReferenceEquals(this.xExtensaoField, value) != true)) {
                    this.xExtensaoField = value;
                    this.RaisePropertyChanged("xExtensao");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string xNameTable {
            get {
                return this.xNameTableField;
            }
            set {
                if ((object.ReferenceEquals(this.xNameTableField, value) != true)) {
                    this.xNameTableField = value;
                    this.RaisePropertyChanged("xNameTable");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string xPath {
            get {
                return this.xPathField;
            }
            set {
                if ((object.ReferenceEquals(this.xPathField, value) != true)) {
                    this.xPathField = value;
                    this.RaisePropertyChanged("xPath");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="modelComum", Namespace="http://schemas.datacontract.org/2004/07/HLP.Comum.Model.Models")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.Gerais.Familia_produtoModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.Gerais.Familia_Produto_ClassesModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.Gerais.Funcionario_AcessoModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.Gerais.Funcionario_ArquivoModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.Gerais.Funcionario_CertificacaoModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.Gerais.Funcionario_Comissao_ProdutoModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.Gerais.Funcionario_Margem_Lucro_ComissaoModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Components.Model.Models.EnderecoModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.Gerais.FuncionarioModel))]
    public partial class modelComum : HLP.Entries.Services.wcf_Funcionario.modelBase {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.List<HLP.Entries.Services.wcf_Funcionario.DocumentosModel> lDocumentosField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.List<HLP.Entries.Services.wcf_Funcionario.DocumentosModel> lDocumentos {
            get {
                return this.lDocumentosField;
            }
            set {
                if ((object.ReferenceEquals(this.lDocumentosField, value) != true)) {
                    this.lDocumentosField = value;
                    this.RaisePropertyChanged("lDocumentos");
                }
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="wcf_Funcionario.Iwcf_Funcionario")]
    public interface Iwcf_Funcionario {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Funcionario/getFuncionario", ReplyAction="http://tempuri.org/Iwcf_Funcionario/getFuncionarioResponse")]
        HLP.Entries.Model.Models.Gerais.FuncionarioModel getFuncionario(int idFuncionario, bool bGetChild);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Funcionario/getFuncionario", ReplyAction="http://tempuri.org/Iwcf_Funcionario/getFuncionarioResponse")]
        System.Threading.Tasks.Task<HLP.Entries.Model.Models.Gerais.FuncionarioModel> getFuncionarioAsync(int idFuncionario, bool bGetChild);
        
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
        HLP.Components.Model.Models.modelToTreeView GetHierarquiaFuncionario(int idFuncionario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Funcionario/GetHierarquiaFuncionario", ReplyAction="http://tempuri.org/Iwcf_Funcionario/GetHierarquiaFuncionarioResponse")]
        System.Threading.Tasks.Task<HLP.Components.Model.Models.modelToTreeView> GetHierarquiaFuncionarioAsync(int idFuncionario);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface Iwcf_FuncionarioChannel : HLP.Entries.Services.wcf_Funcionario.Iwcf_Funcionario, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Iwcf_FuncionarioClient : System.ServiceModel.ClientBase<HLP.Entries.Services.wcf_Funcionario.Iwcf_Funcionario>, HLP.Entries.Services.wcf_Funcionario.Iwcf_Funcionario {
        
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
        
        public HLP.Entries.Model.Models.Gerais.FuncionarioModel getFuncionario(int idFuncionario, bool bGetChild) {
            return base.Channel.getFuncionario(idFuncionario, bGetChild);
        }
        
        public System.Threading.Tasks.Task<HLP.Entries.Model.Models.Gerais.FuncionarioModel> getFuncionarioAsync(int idFuncionario, bool bGetChild) {
            return base.Channel.getFuncionarioAsync(idFuncionario, bGetChild);
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
        
        public HLP.Components.Model.Models.modelToTreeView GetHierarquiaFuncionario(int idFuncionario) {
            return base.Channel.GetHierarquiaFuncionario(idFuncionario);
        }
        
        public System.Threading.Tasks.Task<HLP.Components.Model.Models.modelToTreeView> GetHierarquiaFuncionarioAsync(int idFuncionario) {
            return base.Channel.GetHierarquiaFuncionarioAsync(idFuncionario);
        }
    }
}
