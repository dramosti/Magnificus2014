﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18051
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HLP.Entries.ViewModel.tipoServicoService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="tipoServicoService.IserviceTipoServico")]
    public interface IserviceTipoServico {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceTipoServico/GetTipo", ReplyAction="http://tempuri.org/IserviceTipoServico/GetTipoResponse")]
        HLP.Entries.Model.Models.Gerais.Tipo_servicoModel GetTipo(int idTipoServico);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceTipoServico/GetTipo", ReplyAction="http://tempuri.org/IserviceTipoServico/GetTipoResponse")]
        System.Threading.Tasks.Task<HLP.Entries.Model.Models.Gerais.Tipo_servicoModel> GetTipoAsync(int idTipoServico);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceTipoServico/Save", ReplyAction="http://tempuri.org/IserviceTipoServico/SaveResponse")]
        void Save(HLP.Entries.Model.Models.Gerais.Tipo_servicoModel tipo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceTipoServico/Save", ReplyAction="http://tempuri.org/IserviceTipoServico/SaveResponse")]
        System.Threading.Tasks.Task SaveAsync(HLP.Entries.Model.Models.Gerais.Tipo_servicoModel tipo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceTipoServico/Delete", ReplyAction="http://tempuri.org/IserviceTipoServico/DeleteResponse")]
        bool Delete(int idTipoServico);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceTipoServico/Delete", ReplyAction="http://tempuri.org/IserviceTipoServico/DeleteResponse")]
        System.Threading.Tasks.Task<bool> DeleteAsync(int idTipoServico);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceTipoServico/Copy", ReplyAction="http://tempuri.org/IserviceTipoServico/CopyResponse")]
        int Copy(int idTipoServico);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceTipoServico/Copy", ReplyAction="http://tempuri.org/IserviceTipoServico/CopyResponse")]
        System.Threading.Tasks.Task<int> CopyAsync(int idTipoServico);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IserviceTipoServicoChannel : HLP.Entries.ViewModel.tipoServicoService.IserviceTipoServico, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class IserviceTipoServicoClient : System.ServiceModel.ClientBase<HLP.Entries.ViewModel.tipoServicoService.IserviceTipoServico>, HLP.Entries.ViewModel.tipoServicoService.IserviceTipoServico {
        
        public IserviceTipoServicoClient() {
        }
        
        public IserviceTipoServicoClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public IserviceTipoServicoClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IserviceTipoServicoClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IserviceTipoServicoClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public HLP.Entries.Model.Models.Gerais.Tipo_servicoModel GetTipo(int idTipoServico) {
            return base.Channel.GetTipo(idTipoServico);
        }
        
        public System.Threading.Tasks.Task<HLP.Entries.Model.Models.Gerais.Tipo_servicoModel> GetTipoAsync(int idTipoServico) {
            return base.Channel.GetTipoAsync(idTipoServico);
        }
        
        public void Save(HLP.Entries.Model.Models.Gerais.Tipo_servicoModel tipo) {
            base.Channel.Save(tipo);
        }
        
        public System.Threading.Tasks.Task SaveAsync(HLP.Entries.Model.Models.Gerais.Tipo_servicoModel tipo) {
            return base.Channel.SaveAsync(tipo);
        }
        
        public bool Delete(int idTipoServico) {
            return base.Channel.Delete(idTipoServico);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteAsync(int idTipoServico) {
            return base.Channel.DeleteAsync(idTipoServico);
        }
        
        public int Copy(int idTipoServico) {
            return base.Channel.Copy(idTipoServico);
        }
        
        public System.Threading.Tasks.Task<int> CopyAsync(int idTipoServico) {
            return base.Channel.CopyAsync(idTipoServico);
        }
    }
}