﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.32559
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HLP.Entries.ViewModel.cargoService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="cargoService.IserviceCargo")]
    public interface IserviceCargo {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceCargo/getCargo", ReplyAction="http://tempuri.org/IserviceCargo/getCargoResponse")]
        HLP.Entries.Model.Models.RecursosHumanos.CargoModel getCargo(int idCargo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceCargo/getCargo", ReplyAction="http://tempuri.org/IserviceCargo/getCargoResponse")]
        System.Threading.Tasks.Task<HLP.Entries.Model.Models.RecursosHumanos.CargoModel> getCargoAsync(int idCargo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceCargo/saveCargo", ReplyAction="http://tempuri.org/IserviceCargo/saveCargoResponse")]
        int saveCargo(HLP.Entries.Model.Models.RecursosHumanos.CargoModel objCargo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceCargo/saveCargo", ReplyAction="http://tempuri.org/IserviceCargo/saveCargoResponse")]
        System.Threading.Tasks.Task<int> saveCargoAsync(HLP.Entries.Model.Models.RecursosHumanos.CargoModel objCargo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceCargo/delCargo", ReplyAction="http://tempuri.org/IserviceCargo/delCargoResponse")]
        bool delCargo(int idCargo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IserviceCargo/delCargo", ReplyAction="http://tempuri.org/IserviceCargo/delCargoResponse")]
        System.Threading.Tasks.Task<bool> delCargoAsync(int idCargo);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IserviceCargoChannel : HLP.Entries.ViewModel.cargoService.IserviceCargo, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class IserviceCargoClient : System.ServiceModel.ClientBase<HLP.Entries.ViewModel.cargoService.IserviceCargo>, HLP.Entries.ViewModel.cargoService.IserviceCargo {
        
        public IserviceCargoClient() {
        }
        
        public IserviceCargoClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public IserviceCargoClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IserviceCargoClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IserviceCargoClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public HLP.Entries.Model.Models.RecursosHumanos.CargoModel getCargo(int idCargo) {
            return base.Channel.getCargo(idCargo);
        }
        
        public System.Threading.Tasks.Task<HLP.Entries.Model.Models.RecursosHumanos.CargoModel> getCargoAsync(int idCargo) {
            return base.Channel.getCargoAsync(idCargo);
        }
        
        public int saveCargo(HLP.Entries.Model.Models.RecursosHumanos.CargoModel objCargo) {
            return base.Channel.saveCargo(objCargo);
        }
        
        public System.Threading.Tasks.Task<int> saveCargoAsync(HLP.Entries.Model.Models.RecursosHumanos.CargoModel objCargo) {
            return base.Channel.saveCargoAsync(objCargo);
        }
        
        public bool delCargo(int idCargo) {
            return base.Channel.delCargo(idCargo);
        }
        
        public System.Threading.Tasks.Task<bool> delCargoAsync(int idCargo) {
            return base.Channel.delCargoAsync(idCargo);
        }
    }
}
