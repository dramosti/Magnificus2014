﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34003
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HLP.Comum.Facade.Carga_trib_media_st_icmsServico {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="modelBase", Namespace="http://schemas.datacontract.org/2004/07/HLP.Comum.Model.Models")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Comum.Facade.Carga_trib_media_st_icmsServico.Carga_trib_media_st_icmsModel))]
    public partial class modelBase : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private HLP.Comum.Facade.Carga_trib_media_st_icmsServico.PesquisaPadraoModelContract[] lcamposSqlNotNullField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private HLP.Comum.Facade.Carga_trib_media_st_icmsServico.statusModel statusField;
        
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
        public HLP.Comum.Facade.Carga_trib_media_st_icmsServico.PesquisaPadraoModelContract[] lcamposSqlNotNull {
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
        public HLP.Comum.Facade.Carga_trib_media_st_icmsServico.statusModel status {
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Carga_trib_media_st_icmsModel", Namespace="http://schemas.datacontract.org/2004/07/HLP.Entries.Model.Models.Fiscal")]
    [System.SerializableAttribute()]
    public partial class Carga_trib_media_st_icmsModel : HLP.Comum.Facade.Carga_trib_media_st_icmsServico.modelBase {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> idCargaTribMediaStIcmsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idRamoAtividadeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idUfField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal pCargaTributariaMediaField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> idCargaTribMediaStIcms {
            get {
                return this.idCargaTribMediaStIcmsField;
            }
            set {
                if ((this.idCargaTribMediaStIcmsField.Equals(value) != true)) {
                    this.idCargaTribMediaStIcmsField = value;
                    this.RaisePropertyChanged("idCargaTribMediaStIcms");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int idRamoAtividade {
            get {
                return this.idRamoAtividadeField;
            }
            set {
                if ((this.idRamoAtividadeField.Equals(value) != true)) {
                    this.idRamoAtividadeField = value;
                    this.RaisePropertyChanged("idRamoAtividade");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int idUf {
            get {
                return this.idUfField;
            }
            set {
                if ((this.idUfField.Equals(value) != true)) {
                    this.idUfField = value;
                    this.RaisePropertyChanged("idUf");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal pCargaTributariaMedia {
            get {
                return this.pCargaTributariaMediaField;
            }
            set {
                if ((this.pCargaTributariaMediaField.Equals(value) != true)) {
                    this.pCargaTributariaMediaField = value;
                    this.RaisePropertyChanged("pCargaTributariaMedia");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Carga_trib_media_st_icmsServico.IserviceCarga_trib_media_st_icms")]
    public interface IserviceCarga_trib_media_st_icms {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceCarga_trib_media_st_icms/Save", ReplyAction="http://tempuri.org/IserviceCarga_trib_media_st_icms/SaveResponse")]
        int Save(HLP.Comum.Facade.Carga_trib_media_st_icmsServico.Carga_trib_media_st_icmsModel objModel);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceCarga_trib_media_st_icms/Save", ReplyAction="http://tempuri.org/IserviceCarga_trib_media_st_icms/SaveResponse")]
        System.Threading.Tasks.Task<int> SaveAsync(HLP.Comum.Facade.Carga_trib_media_st_icmsServico.Carga_trib_media_st_icmsModel objModel);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceCarga_trib_media_st_icms/GetObjeto", ReplyAction="http://tempuri.org/IserviceCarga_trib_media_st_icms/GetObjetoResponse")]
        HLP.Comum.Facade.Carga_trib_media_st_icmsServico.Carga_trib_media_st_icmsModel GetObjeto(int idObjeto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceCarga_trib_media_st_icms/GetObjeto", ReplyAction="http://tempuri.org/IserviceCarga_trib_media_st_icms/GetObjetoResponse")]
        System.Threading.Tasks.Task<HLP.Comum.Facade.Carga_trib_media_st_icmsServico.Carga_trib_media_st_icmsModel> GetObjetoAsync(int idObjeto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceCarga_trib_media_st_icms/Delete", ReplyAction="http://tempuri.org/IserviceCarga_trib_media_st_icms/DeleteResponse")]
        bool Delete(HLP.Comum.Facade.Carga_trib_media_st_icmsServico.Carga_trib_media_st_icmsModel objModel);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceCarga_trib_media_st_icms/Delete", ReplyAction="http://tempuri.org/IserviceCarga_trib_media_st_icms/DeleteResponse")]
        System.Threading.Tasks.Task<bool> DeleteAsync(HLP.Comum.Facade.Carga_trib_media_st_icmsServico.Carga_trib_media_st_icmsModel objModel);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceCarga_trib_media_st_icms/Copy", ReplyAction="http://tempuri.org/IserviceCarga_trib_media_st_icms/CopyResponse")]
        int Copy(HLP.Comum.Facade.Carga_trib_media_st_icmsServico.Carga_trib_media_st_icmsModel objModel);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceCarga_trib_media_st_icms/Copy", ReplyAction="http://tempuri.org/IserviceCarga_trib_media_st_icms/CopyResponse")]
        System.Threading.Tasks.Task<int> CopyAsync(HLP.Comum.Facade.Carga_trib_media_st_icmsServico.Carga_trib_media_st_icmsModel objModel);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceCarga_trib_media_st_icms/GetAllCarga_trib_media_st_icm" +
            "s", ReplyAction="http://tempuri.org/IserviceCarga_trib_media_st_icms/GetAllCarga_trib_media_st_icm" +
            "sResponse")]
        HLP.Comum.Facade.Carga_trib_media_st_icmsServico.Carga_trib_media_st_icmsModel[] GetAllCarga_trib_media_st_icms();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceCarga_trib_media_st_icms/GetAllCarga_trib_media_st_icm" +
            "s", ReplyAction="http://tempuri.org/IserviceCarga_trib_media_st_icms/GetAllCarga_trib_media_st_icm" +
            "sResponse")]
        System.Threading.Tasks.Task<HLP.Comum.Facade.Carga_trib_media_st_icmsServico.Carga_trib_media_st_icmsModel[]> GetAllCarga_trib_media_st_icmsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceCarga_trib_media_st_icms/GetCarga_trib_media_st_icmsBy" +
            "Uf", ReplyAction="http://tempuri.org/IserviceCarga_trib_media_st_icms/GetCarga_trib_media_st_icmsBy" +
            "UfResponse")]
        HLP.Comum.Facade.Carga_trib_media_st_icmsServico.Carga_trib_media_st_icmsModel GetCarga_trib_media_st_icmsByUf(int idUf);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceCarga_trib_media_st_icms/GetCarga_trib_media_st_icmsBy" +
            "Uf", ReplyAction="http://tempuri.org/IserviceCarga_trib_media_st_icms/GetCarga_trib_media_st_icmsBy" +
            "UfResponse")]
        System.Threading.Tasks.Task<HLP.Comum.Facade.Carga_trib_media_st_icmsServico.Carga_trib_media_st_icmsModel> GetCarga_trib_media_st_icmsByUfAsync(int idUf);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IserviceCarga_trib_media_st_icmsChannel : HLP.Comum.Facade.Carga_trib_media_st_icmsServico.IserviceCarga_trib_media_st_icms, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class IserviceCarga_trib_media_st_icmsClient : System.ServiceModel.ClientBase<HLP.Comum.Facade.Carga_trib_media_st_icmsServico.IserviceCarga_trib_media_st_icms>, HLP.Comum.Facade.Carga_trib_media_st_icmsServico.IserviceCarga_trib_media_st_icms {
        
        public IserviceCarga_trib_media_st_icmsClient() {
        }
        
        public IserviceCarga_trib_media_st_icmsClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public IserviceCarga_trib_media_st_icmsClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IserviceCarga_trib_media_st_icmsClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IserviceCarga_trib_media_st_icmsClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int Save(HLP.Comum.Facade.Carga_trib_media_st_icmsServico.Carga_trib_media_st_icmsModel objModel) {
            return base.Channel.Save(objModel);
        }
        
        public System.Threading.Tasks.Task<int> SaveAsync(HLP.Comum.Facade.Carga_trib_media_st_icmsServico.Carga_trib_media_st_icmsModel objModel) {
            return base.Channel.SaveAsync(objModel);
        }
        
        public HLP.Comum.Facade.Carga_trib_media_st_icmsServico.Carga_trib_media_st_icmsModel GetObjeto(int idObjeto) {
            return base.Channel.GetObjeto(idObjeto);
        }
        
        public System.Threading.Tasks.Task<HLP.Comum.Facade.Carga_trib_media_st_icmsServico.Carga_trib_media_st_icmsModel> GetObjetoAsync(int idObjeto) {
            return base.Channel.GetObjetoAsync(idObjeto);
        }
        
        public bool Delete(HLP.Comum.Facade.Carga_trib_media_st_icmsServico.Carga_trib_media_st_icmsModel objModel) {
            return base.Channel.Delete(objModel);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteAsync(HLP.Comum.Facade.Carga_trib_media_st_icmsServico.Carga_trib_media_st_icmsModel objModel) {
            return base.Channel.DeleteAsync(objModel);
        }
        
        public int Copy(HLP.Comum.Facade.Carga_trib_media_st_icmsServico.Carga_trib_media_st_icmsModel objModel) {
            return base.Channel.Copy(objModel);
        }
        
        public System.Threading.Tasks.Task<int> CopyAsync(HLP.Comum.Facade.Carga_trib_media_st_icmsServico.Carga_trib_media_st_icmsModel objModel) {
            return base.Channel.CopyAsync(objModel);
        }
        
        public HLP.Comum.Facade.Carga_trib_media_st_icmsServico.Carga_trib_media_st_icmsModel[] GetAllCarga_trib_media_st_icms() {
            return base.Channel.GetAllCarga_trib_media_st_icms();
        }
        
        public System.Threading.Tasks.Task<HLP.Comum.Facade.Carga_trib_media_st_icmsServico.Carga_trib_media_st_icmsModel[]> GetAllCarga_trib_media_st_icmsAsync() {
            return base.Channel.GetAllCarga_trib_media_st_icmsAsync();
        }
        
        public HLP.Comum.Facade.Carga_trib_media_st_icmsServico.Carga_trib_media_st_icmsModel GetCarga_trib_media_st_icmsByUf(int idUf) {
            return base.Channel.GetCarga_trib_media_st_icmsByUf(idUf);
        }
        
        public System.Threading.Tasks.Task<HLP.Comum.Facade.Carga_trib_media_st_icmsServico.Carga_trib_media_st_icmsModel> GetCarga_trib_media_st_icmsByUfAsync(int idUf) {
            return base.Channel.GetCarga_trib_media_st_icmsByUfAsync(idUf);
        }
    }
}
