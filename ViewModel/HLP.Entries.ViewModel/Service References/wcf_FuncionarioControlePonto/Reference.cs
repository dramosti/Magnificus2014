﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34011
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HLP.Entries.ViewModel.wcf_FuncionarioControlePonto {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="modelBase", Namespace="http://schemas.datacontract.org/2004/07/HLP.Comum.Model.Models")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.Gerais.Funcionario_Controle_Horas_PontoModel))]
    public partial class modelBase : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.List<HLP.Entries.ViewModel.wcf_FuncionarioControlePonto.PesquisaPadraoModelContract> lcamposSqlNotNullField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private HLP.Entries.ViewModel.wcf_FuncionarioControlePonto.statusModel statusField;
        
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
        public System.Collections.Generic.List<HLP.Entries.ViewModel.wcf_FuncionarioControlePonto.PesquisaPadraoModelContract> lcamposSqlNotNull {
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
        public HLP.Entries.ViewModel.wcf_FuncionarioControlePonto.statusModel status {
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="wcf_FuncionarioControlePonto.Iwcf_Funcionario_Controle_Horas_Ponto")]
    public interface Iwcf_Funcionario_Controle_Horas_Ponto {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Funcionario_Controle_Horas_Ponto/Save", ReplyAction="http://tempuri.org/Iwcf_Funcionario_Controle_Horas_Ponto/SaveResponse")]
        System.Collections.Generic.List<HLP.Entries.Model.Models.Gerais.Funcionario_Controle_Horas_PontoModel> Save(int idFuncionario, System.Collections.Generic.List<HLP.Entries.Model.Models.Gerais.Funcionario_Controle_Horas_PontoModel> lobjFuncionario_Controle_Horas_Ponto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Funcionario_Controle_Horas_Ponto/Save", ReplyAction="http://tempuri.org/Iwcf_Funcionario_Controle_Horas_Ponto/SaveResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<HLP.Entries.Model.Models.Gerais.Funcionario_Controle_Horas_PontoModel>> SaveAsync(int idFuncionario, System.Collections.Generic.List<HLP.Entries.Model.Models.Gerais.Funcionario_Controle_Horas_PontoModel> lobjFuncionario_Controle_Horas_Ponto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Funcionario_Controle_Horas_Ponto/Delete", ReplyAction="http://tempuri.org/Iwcf_Funcionario_Controle_Horas_Ponto/DeleteResponse")]
        void Delete(int idFuncionarioControleHorasPonto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Funcionario_Controle_Horas_Ponto/Delete", ReplyAction="http://tempuri.org/Iwcf_Funcionario_Controle_Horas_Ponto/DeleteResponse")]
        System.Threading.Tasks.Task DeleteAsync(int idFuncionarioControleHorasPonto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Funcionario_Controle_Horas_Ponto/GetFuncionario_Controle_" +
            "Horas_Ponto", ReplyAction="http://tempuri.org/Iwcf_Funcionario_Controle_Horas_Ponto/GetFuncionario_Controle_" +
            "Horas_PontoResponse")]
        HLP.Entries.Model.Models.Gerais.Funcionario_Controle_Horas_PontoModel GetFuncionario_Controle_Horas_Ponto(int idFuncionarioControleHorasPonto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Funcionario_Controle_Horas_Ponto/GetFuncionario_Controle_" +
            "Horas_Ponto", ReplyAction="http://tempuri.org/Iwcf_Funcionario_Controle_Horas_Ponto/GetFuncionario_Controle_" +
            "Horas_PontoResponse")]
        System.Threading.Tasks.Task<HLP.Entries.Model.Models.Gerais.Funcionario_Controle_Horas_PontoModel> GetFuncionario_Controle_Horas_PontoAsync(int idFuncionarioControleHorasPonto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Funcionario_Controle_Horas_Ponto/GetAllFuncionario_Contro" +
            "le_Horas_Ponto", ReplyAction="http://tempuri.org/Iwcf_Funcionario_Controle_Horas_Ponto/GetAllFuncionario_Contro" +
            "le_Horas_PontoResponse")]
        System.Collections.Generic.List<HLP.Entries.Model.Models.Gerais.Funcionario_Controle_Horas_PontoModel> GetAllFuncionario_Controle_Horas_Ponto(int idFuncionario, System.DateTime data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Funcionario_Controle_Horas_Ponto/GetAllFuncionario_Contro" +
            "le_Horas_Ponto", ReplyAction="http://tempuri.org/Iwcf_Funcionario_Controle_Horas_Ponto/GetAllFuncionario_Contro" +
            "le_Horas_PontoResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<HLP.Entries.Model.Models.Gerais.Funcionario_Controle_Horas_PontoModel>> GetAllFuncionario_Controle_Horas_PontoAsync(int idFuncionario, System.DateTime data);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface Iwcf_Funcionario_Controle_Horas_PontoChannel : HLP.Entries.ViewModel.wcf_FuncionarioControlePonto.Iwcf_Funcionario_Controle_Horas_Ponto, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Iwcf_Funcionario_Controle_Horas_PontoClient : System.ServiceModel.ClientBase<HLP.Entries.ViewModel.wcf_FuncionarioControlePonto.Iwcf_Funcionario_Controle_Horas_Ponto>, HLP.Entries.ViewModel.wcf_FuncionarioControlePonto.Iwcf_Funcionario_Controle_Horas_Ponto {
        
        public Iwcf_Funcionario_Controle_Horas_PontoClient() {
        }
        
        public Iwcf_Funcionario_Controle_Horas_PontoClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Iwcf_Funcionario_Controle_Horas_PontoClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Iwcf_Funcionario_Controle_Horas_PontoClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Iwcf_Funcionario_Controle_Horas_PontoClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.List<HLP.Entries.Model.Models.Gerais.Funcionario_Controle_Horas_PontoModel> Save(int idFuncionario, System.Collections.Generic.List<HLP.Entries.Model.Models.Gerais.Funcionario_Controle_Horas_PontoModel> lobjFuncionario_Controle_Horas_Ponto) {
            return base.Channel.Save(idFuncionario, lobjFuncionario_Controle_Horas_Ponto);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<HLP.Entries.Model.Models.Gerais.Funcionario_Controle_Horas_PontoModel>> SaveAsync(int idFuncionario, System.Collections.Generic.List<HLP.Entries.Model.Models.Gerais.Funcionario_Controle_Horas_PontoModel> lobjFuncionario_Controle_Horas_Ponto) {
            return base.Channel.SaveAsync(idFuncionario, lobjFuncionario_Controle_Horas_Ponto);
        }
        
        public void Delete(int idFuncionarioControleHorasPonto) {
            base.Channel.Delete(idFuncionarioControleHorasPonto);
        }
        
        public System.Threading.Tasks.Task DeleteAsync(int idFuncionarioControleHorasPonto) {
            return base.Channel.DeleteAsync(idFuncionarioControleHorasPonto);
        }
        
        public HLP.Entries.Model.Models.Gerais.Funcionario_Controle_Horas_PontoModel GetFuncionario_Controle_Horas_Ponto(int idFuncionarioControleHorasPonto) {
            return base.Channel.GetFuncionario_Controle_Horas_Ponto(idFuncionarioControleHorasPonto);
        }
        
        public System.Threading.Tasks.Task<HLP.Entries.Model.Models.Gerais.Funcionario_Controle_Horas_PontoModel> GetFuncionario_Controle_Horas_PontoAsync(int idFuncionarioControleHorasPonto) {
            return base.Channel.GetFuncionario_Controle_Horas_PontoAsync(idFuncionarioControleHorasPonto);
        }
        
        public System.Collections.Generic.List<HLP.Entries.Model.Models.Gerais.Funcionario_Controle_Horas_PontoModel> GetAllFuncionario_Controle_Horas_Ponto(int idFuncionario, System.DateTime data) {
            return base.Channel.GetAllFuncionario_Controle_Horas_Ponto(idFuncionario, data);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<HLP.Entries.Model.Models.Gerais.Funcionario_Controle_Horas_PontoModel>> GetAllFuncionario_Controle_Horas_PontoAsync(int idFuncionario, System.DateTime data) {
            return base.Channel.GetAllFuncionario_Controle_Horas_PontoAsync(idFuncionario, data);
        }
    }
}
