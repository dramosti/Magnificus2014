﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HLP.Comum.Services.wcf_ConnectionConfig {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="wcf_ConnectionConfig.Iwcf_ConnectionConfig")]
    public interface Iwcf_ConnectionConfig {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_ConnectionConfig/GetServer", ReplyAction="http://tempuri.org/Iwcf_ConnectionConfig/GetServerResponse")]
        System.Data.DataTable GetServer();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_ConnectionConfig/GetServer", ReplyAction="http://tempuri.org/Iwcf_ConnectionConfig/GetServerResponse")]
        System.Threading.Tasks.Task<System.Data.DataTable> GetServerAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_ConnectionConfig/GetDatabases", ReplyAction="http://tempuri.org/Iwcf_ConnectionConfig/GetDatabasesResponse")]
        System.Data.DataSet GetDatabases(string connectionString);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_ConnectionConfig/GetDatabases", ReplyAction="http://tempuri.org/Iwcf_ConnectionConfig/GetDatabasesResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> GetDatabasesAsync(string connectionString);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_ConnectionConfig/TestConnection", ReplyAction="http://tempuri.org/Iwcf_ConnectionConfig/TestConnectionResponse")]
        bool TestConnection(string connectionString);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Iwcf_ConnectionConfig/TestConnection", ReplyAction="http://tempuri.org/Iwcf_ConnectionConfig/TestConnectionResponse")]
        System.Threading.Tasks.Task<bool> TestConnectionAsync(string connectionString);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface Iwcf_ConnectionConfigChannel : HLP.Comum.Services.wcf_ConnectionConfig.Iwcf_ConnectionConfig, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Iwcf_ConnectionConfigClient : System.ServiceModel.ClientBase<HLP.Comum.Services.wcf_ConnectionConfig.Iwcf_ConnectionConfig>, HLP.Comum.Services.wcf_ConnectionConfig.Iwcf_ConnectionConfig {
        
        public Iwcf_ConnectionConfigClient() {
        }
        
        public Iwcf_ConnectionConfigClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Iwcf_ConnectionConfigClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Iwcf_ConnectionConfigClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Iwcf_ConnectionConfigClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Data.DataTable GetServer() {
            return base.Channel.GetServer();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> GetServerAsync() {
            return base.Channel.GetServerAsync();
        }
        
        public System.Data.DataSet GetDatabases(string connectionString) {
            return base.Channel.GetDatabases(connectionString);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> GetDatabasesAsync(string connectionString) {
            return base.Channel.GetDatabasesAsync(connectionString);
        }
        
        public bool TestConnection(string connectionString) {
            return base.Channel.TestConnection(connectionString);
        }
        
        public System.Threading.Tasks.Task<bool> TestConnectionAsync(string connectionString) {
            return base.Channel.TestConnectionAsync(connectionString);
        }
    }
}
