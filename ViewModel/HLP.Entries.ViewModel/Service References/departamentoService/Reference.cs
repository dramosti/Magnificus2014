﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.32559
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HLP.Entries.ViewModel.departamentoService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="departamentoService.IserviceDepartamento")]
    public interface IserviceDepartamento {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceDepartamento/getDepartamento", ReplyAction="http://tempuri.org/IserviceDepartamento/getDepartamentoResponse")]
        HLP.Entries.Model.Models.RecursosHumanos.DepartamentoModel getDepartamento(int idDepartamento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceDepartamento/getDepartamento", ReplyAction="http://tempuri.org/IserviceDepartamento/getDepartamentoResponse")]
        System.Threading.Tasks.Task<HLP.Entries.Model.Models.RecursosHumanos.DepartamentoModel> getDepartamentoAsync(int idDepartamento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceDepartamento/saveDepartamento", ReplyAction="http://tempuri.org/IserviceDepartamento/saveDepartamentoResponse")]
        int saveDepartamento(HLP.Entries.Model.Models.RecursosHumanos.DepartamentoModel objDepartamento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceDepartamento/saveDepartamento", ReplyAction="http://tempuri.org/IserviceDepartamento/saveDepartamentoResponse")]
        System.Threading.Tasks.Task<int> saveDepartamentoAsync(HLP.Entries.Model.Models.RecursosHumanos.DepartamentoModel objDepartamento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceDepartamento/deleteDepartamento", ReplyAction="http://tempuri.org/IserviceDepartamento/deleteDepartamentoResponse")]
        bool deleteDepartamento(int idDepartamento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceDepartamento/deleteDepartamento", ReplyAction="http://tempuri.org/IserviceDepartamento/deleteDepartamentoResponse")]
        System.Threading.Tasks.Task<bool> deleteDepartamentoAsync(int idDepartamento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceDepartamento/copyDepartamento", ReplyAction="http://tempuri.org/IserviceDepartamento/copyDepartamentoResponse")]
        int copyDepartamento(int idDepartamento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceDepartamento/copyDepartamento", ReplyAction="http://tempuri.org/IserviceDepartamento/copyDepartamentoResponse")]
        System.Threading.Tasks.Task<int> copyDepartamentoAsync(int idDepartamento);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IserviceDepartamentoChannel : HLP.Entries.ViewModel.departamentoService.IserviceDepartamento, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class IserviceDepartamentoClient : System.ServiceModel.ClientBase<HLP.Entries.ViewModel.departamentoService.IserviceDepartamento>, HLP.Entries.ViewModel.departamentoService.IserviceDepartamento {
        
        public IserviceDepartamentoClient() {
        }
        
        public IserviceDepartamentoClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public IserviceDepartamentoClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IserviceDepartamentoClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IserviceDepartamentoClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public HLP.Entries.Model.Models.RecursosHumanos.DepartamentoModel getDepartamento(int idDepartamento) {
            return base.Channel.getDepartamento(idDepartamento);
        }
        
        public System.Threading.Tasks.Task<HLP.Entries.Model.Models.RecursosHumanos.DepartamentoModel> getDepartamentoAsync(int idDepartamento) {
            return base.Channel.getDepartamentoAsync(idDepartamento);
        }
        
        public int saveDepartamento(HLP.Entries.Model.Models.RecursosHumanos.DepartamentoModel objDepartamento) {
            return base.Channel.saveDepartamento(objDepartamento);
        }
        
        public System.Threading.Tasks.Task<int> saveDepartamentoAsync(HLP.Entries.Model.Models.RecursosHumanos.DepartamentoModel objDepartamento) {
            return base.Channel.saveDepartamentoAsync(objDepartamento);
        }
        
        public bool deleteDepartamento(int idDepartamento) {
            return base.Channel.deleteDepartamento(idDepartamento);
        }
        
        public System.Threading.Tasks.Task<bool> deleteDepartamentoAsync(int idDepartamento) {
            return base.Channel.deleteDepartamentoAsync(idDepartamento);
        }
        
        public int copyDepartamento(int idDepartamento) {
            return base.Channel.copyDepartamento(idDepartamento);
        }
        
        public System.Threading.Tasks.Task<int> copyDepartamentoAsync(int idDepartamento) {
            return base.Channel.copyDepartamentoAsync(idDepartamento);
        }
    }
}
