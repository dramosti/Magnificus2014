﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18051
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HLP.Entries.ViewModel.Tipo_documentoService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Tipo_documentoService.IserviceTipo_documento")]
    public interface IserviceTipo_documento {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceTipo_documento/DoWork", ReplyAction="http://tempuri.org/IserviceTipo_documento/DoWorkResponse")]
        void DoWork();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceTipo_documento/DoWork", ReplyAction="http://tempuri.org/IserviceTipo_documento/DoWorkResponse")]
        System.Threading.Tasks.Task DoWorkAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceTipo_documento/GetDocumento", ReplyAction="http://tempuri.org/IserviceTipo_documento/GetDocumentoResponse")]
        HLP.Entries.Model.Fiscal.Tipo_documentoModel GetDocumento(int idTipoDocumento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceTipo_documento/GetDocumento", ReplyAction="http://tempuri.org/IserviceTipo_documento/GetDocumentoResponse")]
        System.Threading.Tasks.Task<HLP.Entries.Model.Fiscal.Tipo_documentoModel> GetDocumentoAsync(int idTipoDocumento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceTipo_documento/Save", ReplyAction="http://tempuri.org/IserviceTipo_documento/SaveResponse")]
        void Save(HLP.Entries.Model.Fiscal.Tipo_documentoModel documento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceTipo_documento/Save", ReplyAction="http://tempuri.org/IserviceTipo_documento/SaveResponse")]
        System.Threading.Tasks.Task SaveAsync(HLP.Entries.Model.Fiscal.Tipo_documentoModel documento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceTipo_documento/Delete", ReplyAction="http://tempuri.org/IserviceTipo_documento/DeleteResponse")]
        void Delete(int idTipoDocumento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceTipo_documento/Delete", ReplyAction="http://tempuri.org/IserviceTipo_documento/DeleteResponse")]
        System.Threading.Tasks.Task DeleteAsync(int idTipoDocumento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceTipo_documento/Begin", ReplyAction="http://tempuri.org/IserviceTipo_documento/BeginResponse")]
        void Begin();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceTipo_documento/Begin", ReplyAction="http://tempuri.org/IserviceTipo_documento/BeginResponse")]
        System.Threading.Tasks.Task BeginAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceTipo_documento/Commit", ReplyAction="http://tempuri.org/IserviceTipo_documento/CommitResponse")]
        void Commit();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceTipo_documento/Commit", ReplyAction="http://tempuri.org/IserviceTipo_documento/CommitResponse")]
        System.Threading.Tasks.Task CommitAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceTipo_documento/RollBack", ReplyAction="http://tempuri.org/IserviceTipo_documento/RollBackResponse")]
        void RollBack();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceTipo_documento/RollBack", ReplyAction="http://tempuri.org/IserviceTipo_documento/RollBackResponse")]
        System.Threading.Tasks.Task RollBackAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceTipo_documento/Copy", ReplyAction="http://tempuri.org/IserviceTipo_documento/CopyResponse")]
        int Copy(int idTipoDocumento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceTipo_documento/Copy", ReplyAction="http://tempuri.org/IserviceTipo_documento/CopyResponse")]
        System.Threading.Tasks.Task<int> CopyAsync(int idTipoDocumento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceTipo_documento/GetTipo_documentoAll", ReplyAction="http://tempuri.org/IserviceTipo_documento/GetTipo_documentoAllResponse")]
        HLP.Entries.Model.Fiscal.Tipo_documentoModel[] GetTipo_documentoAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceTipo_documento/GetTipo_documentoAll", ReplyAction="http://tempuri.org/IserviceTipo_documento/GetTipo_documentoAllResponse")]
        System.Threading.Tasks.Task<HLP.Entries.Model.Fiscal.Tipo_documentoModel[]> GetTipo_documentoAllAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IserviceTipo_documentoChannel : HLP.Entries.ViewModel.Tipo_documentoService.IserviceTipo_documento, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class IserviceTipo_documentoClient : System.ServiceModel.ClientBase<HLP.Entries.ViewModel.Tipo_documentoService.IserviceTipo_documento>, HLP.Entries.ViewModel.Tipo_documentoService.IserviceTipo_documento {
        
        public IserviceTipo_documentoClient() {
        }
        
        public IserviceTipo_documentoClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public IserviceTipo_documentoClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IserviceTipo_documentoClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IserviceTipo_documentoClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void DoWork() {
            base.Channel.DoWork();
        }
        
        public System.Threading.Tasks.Task DoWorkAsync() {
            return base.Channel.DoWorkAsync();
        }
        
        public HLP.Entries.Model.Fiscal.Tipo_documentoModel GetDocumento(int idTipoDocumento) {
            return base.Channel.GetDocumento(idTipoDocumento);
        }
        
        public System.Threading.Tasks.Task<HLP.Entries.Model.Fiscal.Tipo_documentoModel> GetDocumentoAsync(int idTipoDocumento) {
            return base.Channel.GetDocumentoAsync(idTipoDocumento);
        }
        
        public void Save(HLP.Entries.Model.Fiscal.Tipo_documentoModel documento) {
            base.Channel.Save(documento);
        }
        
        public System.Threading.Tasks.Task SaveAsync(HLP.Entries.Model.Fiscal.Tipo_documentoModel documento) {
            return base.Channel.SaveAsync(documento);
        }
        
        public void Delete(int idTipoDocumento) {
            base.Channel.Delete(idTipoDocumento);
        }
        
        public System.Threading.Tasks.Task DeleteAsync(int idTipoDocumento) {
            return base.Channel.DeleteAsync(idTipoDocumento);
        }
        
        public void Begin() {
            base.Channel.Begin();
        }
        
        public System.Threading.Tasks.Task BeginAsync() {
            return base.Channel.BeginAsync();
        }
        
        public void Commit() {
            base.Channel.Commit();
        }
        
        public System.Threading.Tasks.Task CommitAsync() {
            return base.Channel.CommitAsync();
        }
        
        public void RollBack() {
            base.Channel.RollBack();
        }
        
        public System.Threading.Tasks.Task RollBackAsync() {
            return base.Channel.RollBackAsync();
        }
        
        public int Copy(int idTipoDocumento) {
            return base.Channel.Copy(idTipoDocumento);
        }
        
        public System.Threading.Tasks.Task<int> CopyAsync(int idTipoDocumento) {
            return base.Channel.CopyAsync(idTipoDocumento);
        }
        
        public HLP.Entries.Model.Fiscal.Tipo_documentoModel[] GetTipo_documentoAll() {
            return base.Channel.GetTipo_documentoAll();
        }
        
        public System.Threading.Tasks.Task<HLP.Entries.Model.Fiscal.Tipo_documentoModel[]> GetTipo_documentoAllAsync() {
            return base.Channel.GetTipo_documentoAllAsync();
        }
    }
}