﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HLP.Comum.Facade.loginService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="loginService.IserviceLogin")]
    public interface IserviceLogin {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceLogin/ValidaUsuario", ReplyAction="http://tempuri.org/IserviceLogin/ValidaUsuarioResponse")]
        int ValidaUsuario(string xId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceLogin/ValidaUsuario", ReplyAction="http://tempuri.org/IserviceLogin/ValidaUsuarioResponse")]
        System.Threading.Tasks.Task<int> ValidaUsuarioAsync(string xId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceLogin/ValidaAcesso", ReplyAction="http://tempuri.org/IserviceLogin/ValidaAcessoResponse")]
        int ValidaAcesso(int idEmpresa, string xId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceLogin/ValidaAcesso", ReplyAction="http://tempuri.org/IserviceLogin/ValidaAcessoResponse")]
        System.Threading.Tasks.Task<int> ValidaAcessoAsync(int idEmpresa, string xId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceLogin/ValidaLogin", ReplyAction="http://tempuri.org/IserviceLogin/ValidaLoginResponse")]
        int ValidaLogin(string xId, string xSenha);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceLogin/ValidaLogin", ReplyAction="http://tempuri.org/IserviceLogin/ValidaLoginResponse")]
        System.Threading.Tasks.Task<int> ValidaLoginAsync(string xId, string xSenha);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceLogin/GetIdFuncionarioByXid", ReplyAction="http://tempuri.org/IserviceLogin/GetIdFuncionarioByXidResponse")]
        int GetIdFuncionarioByXid(string xId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceLogin/GetIdFuncionarioByXid", ReplyAction="http://tempuri.org/IserviceLogin/GetIdFuncionarioByXidResponse")]
        System.Threading.Tasks.Task<int> GetIdFuncionarioByXidAsync(string xId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceLogin/ValidaAdministrador", ReplyAction="http://tempuri.org/IserviceLogin/ValidaAdministradorResponse")]
        int ValidaAdministrador(string xID, string xSenha, int idEmpresa);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceLogin/ValidaAdministrador", ReplyAction="http://tempuri.org/IserviceLogin/ValidaAdministradorResponse")]
        System.Threading.Tasks.Task<int> ValidaAdministradorAsync(string xID, string xSenha, int idEmpresa);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IserviceLoginChannel : HLP.Comum.Facade.loginService.IserviceLogin, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class IserviceLoginClient : System.ServiceModel.ClientBase<HLP.Comum.Facade.loginService.IserviceLogin>, HLP.Comum.Facade.loginService.IserviceLogin {
        
        public IserviceLoginClient() {
        }
        
        public IserviceLoginClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public IserviceLoginClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IserviceLoginClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IserviceLoginClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int ValidaUsuario(string xId) {
            return base.Channel.ValidaUsuario(xId);
        }
        
        public System.Threading.Tasks.Task<int> ValidaUsuarioAsync(string xId) {
            return base.Channel.ValidaUsuarioAsync(xId);
        }
        
        public int ValidaAcesso(int idEmpresa, string xId) {
            return base.Channel.ValidaAcesso(idEmpresa, xId);
        }
        
        public System.Threading.Tasks.Task<int> ValidaAcessoAsync(int idEmpresa, string xId) {
            return base.Channel.ValidaAcessoAsync(idEmpresa, xId);
        }
        
        public int ValidaLogin(string xId, string xSenha) {
            return base.Channel.ValidaLogin(xId, xSenha);
        }
        
        public System.Threading.Tasks.Task<int> ValidaLoginAsync(string xId, string xSenha) {
            return base.Channel.ValidaLoginAsync(xId, xSenha);
        }
        
        public int GetIdFuncionarioByXid(string xId) {
            return base.Channel.GetIdFuncionarioByXid(xId);
        }
        
        public System.Threading.Tasks.Task<int> GetIdFuncionarioByXidAsync(string xId) {
            return base.Channel.GetIdFuncionarioByXidAsync(xId);
        }
        
        public int ValidaAdministrador(string xID, string xSenha, int idEmpresa) {
            return base.Channel.ValidaAdministrador(xID, xSenha, idEmpresa);
        }
        
        public System.Threading.Tasks.Task<int> ValidaAdministradorAsync(string xID, string xSenha, int idEmpresa) {
            return base.Channel.ValidaAdministradorAsync(xID, xSenha, idEmpresa);
        }
    }
}
