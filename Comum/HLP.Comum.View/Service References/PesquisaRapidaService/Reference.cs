﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18051
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HLP.Comum.View.PesquisaRapidaService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="PesquisaRapidaService.IservicePesquisaRapida")]
    public interface IservicePesquisaRapida {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IservicePesquisaRapida/GetValorDisplay", ReplyAction="http://tempuri.org/IservicePesquisaRapida/GetValorDisplayResponse")]
        string GetValorDisplay(string _TableView, string[] _Items, string _FieldPesquisa, System.Nullable<int> _iValorPesquisa);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IservicePesquisaRapida/GetValorDisplay", ReplyAction="http://tempuri.org/IservicePesquisaRapida/GetValorDisplayResponse")]
        System.Threading.Tasks.Task<string> GetValorDisplayAsync(string _TableView, string[] _Items, string _FieldPesquisa, System.Nullable<int> _iValorPesquisa);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IservicePesquisaRapidaChannel : HLP.Comum.View.PesquisaRapidaService.IservicePesquisaRapida, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class IservicePesquisaRapidaClient : System.ServiceModel.ClientBase<HLP.Comum.View.PesquisaRapidaService.IservicePesquisaRapida>, HLP.Comum.View.PesquisaRapidaService.IservicePesquisaRapida {
        
        public IservicePesquisaRapidaClient() {
        }
        
        public IservicePesquisaRapidaClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public IservicePesquisaRapidaClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IservicePesquisaRapidaClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IservicePesquisaRapidaClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetValorDisplay(string _TableView, string[] _Items, string _FieldPesquisa, System.Nullable<int> _iValorPesquisa) {
            return base.Channel.GetValorDisplay(_TableView, _Items, _FieldPesquisa, _iValorPesquisa);
        }
        
        public System.Threading.Tasks.Task<string> GetValorDisplayAsync(string _TableView, string[] _Items, string _FieldPesquisa, System.Nullable<int> _iValorPesquisa) {
            return base.Channel.GetValorDisplayAsync(_TableView, _Items, _FieldPesquisa, _iValorPesquisa);
        }
    }
}
