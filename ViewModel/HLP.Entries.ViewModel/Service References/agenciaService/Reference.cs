﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18051
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HLP.Entries.ViewModel.agenciaService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="modelBase", Namespace="http://schemas.datacontract.org/2004/07/HLP.Comum.Model.Models")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.Financeiro.Agencia_ContatoModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.Financeiro.Agencia_EnderecoModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.Financeiro.AgenciaModel))]
    public partial class modelBase : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.List<HLP.Entries.ViewModel.agenciaService.PesquisaPadraoModelContract> lcamposSqlNotNullField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private HLP.Entries.ViewModel.agenciaService.statusModel statusField;
        
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
        public System.Collections.Generic.List<HLP.Entries.ViewModel.agenciaService.PesquisaPadraoModelContract> lcamposSqlNotNull {
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
        public HLP.Entries.ViewModel.agenciaService.statusModel status {
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="agenciaService.IserviceAgencia")]
    public interface IserviceAgencia {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceAgencia/Save", ReplyAction="http://tempuri.org/IserviceAgencia/SaveResponse")]
        int Save(HLP.Entries.Model.Models.Financeiro.AgenciaModel Objeto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceAgencia/Save", ReplyAction="http://tempuri.org/IserviceAgencia/SaveResponse")]
        System.Threading.Tasks.Task<int> SaveAsync(HLP.Entries.Model.Models.Financeiro.AgenciaModel Objeto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceAgencia/GetObjeto", ReplyAction="http://tempuri.org/IserviceAgencia/GetObjetoResponse")]
        HLP.Entries.Model.Models.Financeiro.AgenciaModel GetObjeto(int idObjeto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceAgencia/GetObjeto", ReplyAction="http://tempuri.org/IserviceAgencia/GetObjetoResponse")]
        System.Threading.Tasks.Task<HLP.Entries.Model.Models.Financeiro.AgenciaModel> GetObjetoAsync(int idObjeto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceAgencia/Delete", ReplyAction="http://tempuri.org/IserviceAgencia/DeleteResponse")]
        bool Delete(HLP.Entries.Model.Models.Financeiro.AgenciaModel Objeto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceAgencia/Delete", ReplyAction="http://tempuri.org/IserviceAgencia/DeleteResponse")]
        System.Threading.Tasks.Task<bool> DeleteAsync(HLP.Entries.Model.Models.Financeiro.AgenciaModel Objeto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceAgencia/Copy", ReplyAction="http://tempuri.org/IserviceAgencia/CopyResponse")]
        int Copy(HLP.Entries.Model.Models.Financeiro.AgenciaModel Objeto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceAgencia/Copy", ReplyAction="http://tempuri.org/IserviceAgencia/CopyResponse")]
        System.Threading.Tasks.Task<int> CopyAsync(HLP.Entries.Model.Models.Financeiro.AgenciaModel Objeto);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IserviceAgenciaChannel : HLP.Entries.ViewModel.agenciaService.IserviceAgencia, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class IserviceAgenciaClient : System.ServiceModel.ClientBase<HLP.Entries.ViewModel.agenciaService.IserviceAgencia>, HLP.Entries.ViewModel.agenciaService.IserviceAgencia {
        
        public IserviceAgenciaClient() {
        }
        
        public IserviceAgenciaClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public IserviceAgenciaClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IserviceAgenciaClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IserviceAgenciaClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int Save(HLP.Entries.Model.Models.Financeiro.AgenciaModel Objeto) {
            return base.Channel.Save(Objeto);
        }
        
        public System.Threading.Tasks.Task<int> SaveAsync(HLP.Entries.Model.Models.Financeiro.AgenciaModel Objeto) {
            return base.Channel.SaveAsync(Objeto);
        }
        
        public HLP.Entries.Model.Models.Financeiro.AgenciaModel GetObjeto(int idObjeto) {
            return base.Channel.GetObjeto(idObjeto);
        }
        
        public System.Threading.Tasks.Task<HLP.Entries.Model.Models.Financeiro.AgenciaModel> GetObjetoAsync(int idObjeto) {
            return base.Channel.GetObjetoAsync(idObjeto);
        }
        
        public bool Delete(HLP.Entries.Model.Models.Financeiro.AgenciaModel Objeto) {
            return base.Channel.Delete(Objeto);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteAsync(HLP.Entries.Model.Models.Financeiro.AgenciaModel Objeto) {
            return base.Channel.DeleteAsync(Objeto);
        }
        
        public int Copy(HLP.Entries.Model.Models.Financeiro.AgenciaModel Objeto) {
            return base.Channel.Copy(Objeto);
        }
        
        public System.Threading.Tasks.Task<int> CopyAsync(HLP.Entries.Model.Models.Financeiro.AgenciaModel Objeto) {
            return base.Channel.CopyAsync(Objeto);
        }
    }
}
