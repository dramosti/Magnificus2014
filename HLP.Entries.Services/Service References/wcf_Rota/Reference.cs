﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HLP.Entries.Services.wcf_Rota {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="modelBase", Namespace="http://schemas.datacontract.org/2004/07/HLP.Base.ClassesBases")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Services.wcf_Rota.DocumentosModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Services.wcf_Rota.modelComum))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.Transportes.Rota_pracaModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.Transportes.RotaModel))]
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
    public partial class DocumentosModel : HLP.Entries.Services.wcf_Rota.modelBase {
        
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
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.Transportes.Rota_pracaModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.Transportes.RotaModel))]
    public partial class modelComum : HLP.Entries.Services.wcf_Rota.modelBase {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private HLP.Entries.Services.wcf_Rota.DocumentosModel[] lDocumentosField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public HLP.Entries.Services.wcf_Rota.DocumentosModel[] lDocumentos {
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="wcf_Rota.Iwcf_Rota")]
    public interface Iwcf_Rota {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Rota/Save", ReplyAction="http://tempuri.org/Iwcf_Rota/SaveResponse")]
        HLP.Entries.Model.Models.Transportes.RotaModel Save(HLP.Entries.Model.Models.Transportes.RotaModel objRota);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Rota/Save", ReplyAction="http://tempuri.org/Iwcf_Rota/SaveResponse")]
        System.Threading.Tasks.Task<HLP.Entries.Model.Models.Transportes.RotaModel> SaveAsync(HLP.Entries.Model.Models.Transportes.RotaModel objRota);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Rota/Delete", ReplyAction="http://tempuri.org/Iwcf_Rota/DeleteResponse")]
        bool Delete(int idRota);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Rota/Delete", ReplyAction="http://tempuri.org/Iwcf_Rota/DeleteResponse")]
        System.Threading.Tasks.Task<bool> DeleteAsync(int idRota);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Rota/Copy", ReplyAction="http://tempuri.org/Iwcf_Rota/CopyResponse")]
        HLP.Entries.Model.Models.Transportes.RotaModel Copy(HLP.Entries.Model.Models.Transportes.RotaModel objRota);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Rota/Copy", ReplyAction="http://tempuri.org/Iwcf_Rota/CopyResponse")]
        System.Threading.Tasks.Task<HLP.Entries.Model.Models.Transportes.RotaModel> CopyAsync(HLP.Entries.Model.Models.Transportes.RotaModel objRota);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Rota/GetObject", ReplyAction="http://tempuri.org/Iwcf_Rota/GetObjectResponse")]
        HLP.Entries.Model.Models.Transportes.RotaModel GetObject(int idRota);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Rota/GetObject", ReplyAction="http://tempuri.org/Iwcf_Rota/GetObjectResponse")]
        System.Threading.Tasks.Task<HLP.Entries.Model.Models.Transportes.RotaModel> GetObjectAsync(int idRota);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Rota/PossuiListaPreco", ReplyAction="http://tempuri.org/Iwcf_Rota/PossuiListaPrecoResponse")]
        bool PossuiListaPreco(int idRota);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Rota/PossuiListaPreco", ReplyAction="http://tempuri.org/Iwcf_Rota/PossuiListaPrecoResponse")]
        System.Threading.Tasks.Task<bool> PossuiListaPrecoAsync(int idRota);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface Iwcf_RotaChannel : HLP.Entries.Services.wcf_Rota.Iwcf_Rota, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Iwcf_RotaClient : System.ServiceModel.ClientBase<HLP.Entries.Services.wcf_Rota.Iwcf_Rota>, HLP.Entries.Services.wcf_Rota.Iwcf_Rota {
        
        public Iwcf_RotaClient() {
        }
        
        public Iwcf_RotaClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Iwcf_RotaClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Iwcf_RotaClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Iwcf_RotaClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public HLP.Entries.Model.Models.Transportes.RotaModel Save(HLP.Entries.Model.Models.Transportes.RotaModel objRota) {
            return base.Channel.Save(objRota);
        }
        
        public System.Threading.Tasks.Task<HLP.Entries.Model.Models.Transportes.RotaModel> SaveAsync(HLP.Entries.Model.Models.Transportes.RotaModel objRota) {
            return base.Channel.SaveAsync(objRota);
        }
        
        public bool Delete(int idRota) {
            return base.Channel.Delete(idRota);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteAsync(int idRota) {
            return base.Channel.DeleteAsync(idRota);
        }
        
        public HLP.Entries.Model.Models.Transportes.RotaModel Copy(HLP.Entries.Model.Models.Transportes.RotaModel objRota) {
            return base.Channel.Copy(objRota);
        }
        
        public System.Threading.Tasks.Task<HLP.Entries.Model.Models.Transportes.RotaModel> CopyAsync(HLP.Entries.Model.Models.Transportes.RotaModel objRota) {
            return base.Channel.CopyAsync(objRota);
        }
        
        public HLP.Entries.Model.Models.Transportes.RotaModel GetObject(int idRota) {
            return base.Channel.GetObject(idRota);
        }
        
        public System.Threading.Tasks.Task<HLP.Entries.Model.Models.Transportes.RotaModel> GetObjectAsync(int idRota) {
            return base.Channel.GetObjectAsync(idRota);
        }
        
        public bool PossuiListaPreco(int idRota) {
            return base.Channel.PossuiListaPreco(idRota);
        }
        
        public System.Threading.Tasks.Task<bool> PossuiListaPrecoAsync(int idRota) {
            return base.Channel.PossuiListaPrecoAsync(idRota);
        }
    }
}
