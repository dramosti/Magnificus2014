﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HLP.Entries.Services.wcf_Cargo {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="modelBase", Namespace="http://schemas.datacontract.org/2004/07/HLP.Base.ClassesBases")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Services.wcf_Cargo.DocumentosModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Services.wcf_Cargo.modelComum))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.RecursosHumanos.CargoModel))]
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
    public partial class DocumentosModel : HLP.Entries.Services.wcf_Cargo.modelBase {
        
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
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(HLP.Entries.Model.Models.RecursosHumanos.CargoModel))]
    public partial class modelComum : HLP.Entries.Services.wcf_Cargo.modelBase {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.List<HLP.Entries.Services.wcf_Cargo.DocumentosModel> lDocumentosField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.List<HLP.Entries.Services.wcf_Cargo.DocumentosModel> lDocumentos {
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="wcf_Cargo.Iwcf_Cargo")]
    public interface Iwcf_Cargo {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Cargo/GetObject", ReplyAction="http://tempuri.org/Iwcf_Cargo/GetObjectResponse")]
        HLP.Entries.Model.Models.RecursosHumanos.CargoModel GetObject(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Cargo/GetObject", ReplyAction="http://tempuri.org/Iwcf_Cargo/GetObjectResponse")]
        System.Threading.Tasks.Task<HLP.Entries.Model.Models.RecursosHumanos.CargoModel> GetObjectAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Cargo/SaveObject", ReplyAction="http://tempuri.org/Iwcf_Cargo/SaveObjectResponse")]
        int SaveObject(HLP.Entries.Model.Models.RecursosHumanos.CargoModel obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Cargo/SaveObject", ReplyAction="http://tempuri.org/Iwcf_Cargo/SaveObjectResponse")]
        System.Threading.Tasks.Task<int> SaveObjectAsync(HLP.Entries.Model.Models.RecursosHumanos.CargoModel obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Cargo/DeleteObject", ReplyAction="http://tempuri.org/Iwcf_Cargo/DeleteObjectResponse")]
        bool DeleteObject(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Cargo/DeleteObject", ReplyAction="http://tempuri.org/Iwcf_Cargo/DeleteObjectResponse")]
        System.Threading.Tasks.Task<bool> DeleteObjectAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Cargo/CopyObject", ReplyAction="http://tempuri.org/Iwcf_Cargo/CopyObjectResponse")]
        HLP.Entries.Model.Models.RecursosHumanos.CargoModel CopyObject(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_Cargo/CopyObject", ReplyAction="http://tempuri.org/Iwcf_Cargo/CopyObjectResponse")]
        System.Threading.Tasks.Task<HLP.Entries.Model.Models.RecursosHumanos.CargoModel> CopyObjectAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface Iwcf_CargoChannel : HLP.Entries.Services.wcf_Cargo.Iwcf_Cargo, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Iwcf_CargoClient : System.ServiceModel.ClientBase<HLP.Entries.Services.wcf_Cargo.Iwcf_Cargo>, HLP.Entries.Services.wcf_Cargo.Iwcf_Cargo {
        
        public Iwcf_CargoClient() {
        }
        
        public Iwcf_CargoClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Iwcf_CargoClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Iwcf_CargoClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Iwcf_CargoClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public HLP.Entries.Model.Models.RecursosHumanos.CargoModel GetObject(int id) {
            return base.Channel.GetObject(id);
        }
        
        public System.Threading.Tasks.Task<HLP.Entries.Model.Models.RecursosHumanos.CargoModel> GetObjectAsync(int id) {
            return base.Channel.GetObjectAsync(id);
        }
        
        public int SaveObject(HLP.Entries.Model.Models.RecursosHumanos.CargoModel obj) {
            return base.Channel.SaveObject(obj);
        }
        
        public System.Threading.Tasks.Task<int> SaveObjectAsync(HLP.Entries.Model.Models.RecursosHumanos.CargoModel obj) {
            return base.Channel.SaveObjectAsync(obj);
        }
        
        public bool DeleteObject(int id) {
            return base.Channel.DeleteObject(id);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteObjectAsync(int id) {
            return base.Channel.DeleteObjectAsync(id);
        }
        
        public HLP.Entries.Model.Models.RecursosHumanos.CargoModel CopyObject(int id) {
            return base.Channel.CopyObject(id);
        }
        
        public System.Threading.Tasks.Task<HLP.Entries.Model.Models.RecursosHumanos.CargoModel> CopyObjectAsync(int id) {
            return base.Channel.CopyObjectAsync(id);
        }
    }
}
