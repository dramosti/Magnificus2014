﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18051
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HLP.Comum.ViewModel.HlpPesquisaPadraoService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="HlpPesquisaPadraoService.IserviceHlpPesquisaPadrao")]
    public interface IserviceHlpPesquisaPadrao {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceHlpPesquisaPadrao/DoWork", ReplyAction="http://tempuri.org/IserviceHlpPesquisaPadrao/DoWorkResponse")]
        void DoWork();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceHlpPesquisaPadrao/DoWork", ReplyAction="http://tempuri.org/IserviceHlpPesquisaPadrao/DoWorkResponse")]
        System.Threading.Tasks.Task DoWorkAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceHlpPesquisaPadrao/GetData", ReplyAction="http://tempuri.org/IserviceHlpPesquisaPadrao/GetDataResponse")]
        System.Data.DataTable GetData(string sSelect, bool addDefault, string sWhere, bool bOrdena);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceHlpPesquisaPadrao/GetData", ReplyAction="http://tempuri.org/IserviceHlpPesquisaPadrao/GetDataResponse")]
        System.Threading.Tasks.Task<System.Data.DataTable> GetDataAsync(string sSelect, bool addDefault, string sWhere, bool bOrdena);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceHlpPesquisaPadrao/GetTableInformation", ReplyAction="http://tempuri.org/IserviceHlpPesquisaPadrao/GetTableInformationResponse")]
        HLP.Comum.Model.Components.PesquisaPadraoModel[] GetTableInformation(string sViewName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceHlpPesquisaPadrao/GetTableInformation", ReplyAction="http://tempuri.org/IserviceHlpPesquisaPadrao/GetTableInformationResponse")]
        System.Threading.Tasks.Task<HLP.Comum.Model.Components.PesquisaPadraoModel[]> GetTableInformationAsync(string sViewName);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IserviceHlpPesquisaPadraoChannel : HLP.Comum.ViewModel.HlpPesquisaPadraoService.IserviceHlpPesquisaPadrao, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class IserviceHlpPesquisaPadraoClient : System.ServiceModel.ClientBase<HLP.Comum.ViewModel.HlpPesquisaPadraoService.IserviceHlpPesquisaPadrao>, HLP.Comum.ViewModel.HlpPesquisaPadraoService.IserviceHlpPesquisaPadrao {
        
        public IserviceHlpPesquisaPadraoClient() {
        }
        
        public IserviceHlpPesquisaPadraoClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public IserviceHlpPesquisaPadraoClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IserviceHlpPesquisaPadraoClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IserviceHlpPesquisaPadraoClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void DoWork() {
            base.Channel.DoWork();
        }
        
        public System.Threading.Tasks.Task DoWorkAsync() {
            return base.Channel.DoWorkAsync();
        }
        
        public System.Data.DataTable GetData(string sSelect, bool addDefault, string sWhere, bool bOrdena) {
            return base.Channel.GetData(sSelect, addDefault, sWhere, bOrdena);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> GetDataAsync(string sSelect, bool addDefault, string sWhere, bool bOrdena) {
            return base.Channel.GetDataAsync(sSelect, addDefault, sWhere, bOrdena);
        }
        
        public HLP.Comum.Model.Components.PesquisaPadraoModel[] GetTableInformation(string sViewName) {
            return base.Channel.GetTableInformation(sViewName);
        }
        
        public System.Threading.Tasks.Task<HLP.Comum.Model.Components.PesquisaPadraoModel[]> GetTableInformationAsync(string sViewName) {
            return base.Channel.GetTableInformationAsync(sViewName);
        }
    }
}
