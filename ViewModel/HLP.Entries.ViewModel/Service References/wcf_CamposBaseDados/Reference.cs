﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34011
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HLP.Entries.ViewModel.wcf_CamposBaseDados {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="wcf_CamposBaseDados.Iwcf_CamposBaseDados")]
    public interface Iwcf_CamposBaseDados {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_CamposBaseDados/getCamposNotNull", ReplyAction="http://tempuri.org/Iwcf_CamposBaseDados/getCamposNotNullResponse")]
        System.Collections.Generic.List<HLP.Base.ClassesBases.PesquisaPadraoModelContract> getCamposNotNull(string xTabela);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_CamposBaseDados/getCamposNotNull", ReplyAction="http://tempuri.org/Iwcf_CamposBaseDados/getCamposNotNullResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<HLP.Base.ClassesBases.PesquisaPadraoModelContract>> getCamposNotNullAsync(string xTabela);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface Iwcf_CamposBaseDadosChannel : HLP.Entries.ViewModel.wcf_CamposBaseDados.Iwcf_CamposBaseDados, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Iwcf_CamposBaseDadosClient : System.ServiceModel.ClientBase<HLP.Entries.ViewModel.wcf_CamposBaseDados.Iwcf_CamposBaseDados>, HLP.Entries.ViewModel.wcf_CamposBaseDados.Iwcf_CamposBaseDados {
        
        public Iwcf_CamposBaseDadosClient() {
        }
        
        public Iwcf_CamposBaseDadosClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Iwcf_CamposBaseDadosClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Iwcf_CamposBaseDadosClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Iwcf_CamposBaseDadosClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.List<HLP.Base.ClassesBases.PesquisaPadraoModelContract> getCamposNotNull(string xTabela) {
            return base.Channel.getCamposNotNull(xTabela);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<HLP.Base.ClassesBases.PesquisaPadraoModelContract>> getCamposNotNullAsync(string xTabela) {
            return base.Channel.getCamposNotNullAsync(xTabela);
        }
    }
}
