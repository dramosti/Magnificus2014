using HLP.Base.ClassesBases;
using HLP.Base.EnumsBases;
using HLP.Comum.Resources.Util;
using HLP.Dependencies;
using HLP.Entries.Model.Models.Transportes;
using HLP.Entries.Model.Repository.Interfaces.Transportes;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_Transportadora" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_Transportadora.svc or wcf_Transportadora.svc.cs at the Solution Explorer and start debugging.

    public class wcf_Transportadora : Iwcf_Transportadora
    {
        [Inject]
        public ITransportadorReposiroty transportadorRepository { get; set; }
        [Inject]
        public ITransportador_ContatoRepository transportador_ContatoRepository { get; set; }
        [Inject]
        public ITransportador_EnderecoRepository transportador_EnderecoRepository { get; set; }
        [Inject]
        public ITransportador_MotoristaRepository transportador_MotoristaRepository { get; set; }
        [Inject]
        public ITransportador_VeiculosRepository transportador_VeiculosRepository { get; set; }        

        public wcf_Transportadora()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public TransportadorModel GetObject(int id)
        {
            TransportadorModel objTransportador;
            try
            {
                objTransportador = this.transportadorRepository.GetTransportador(idTransportador: id);
                objTransportador.lTransportador_Endereco =
                    new ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Transportes.Transportador_EnderecoModel>(
                        list: this.transportador_EnderecoRepository.GetAllTransportador_Endereco(
                        idTransportador: id));
                objTransportador.lTransportador_Motorista =
                    new ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Transportes.Transportador_MotoristaModel>(
                        list: this.transportador_MotoristaRepository.GetAllTransportador_Motorista(
                        idTransportador: id));
                objTransportador.lTransportador_Veiculos = new ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Transportes.Transportador_VeiculosModel>(
                    list: this.transportador_VeiculosRepository.GetAllTransportador_Veiculos(
                    idTransportador: id));
                return objTransportador;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public TransportadorModel SaveObject(TransportadorModel obj)
        {
            try
            {
                this.transportadorRepository.BeginTransaction();
                this.transportadorRepository.Save(objTransportador: obj);

                foreach (HLP.Entries.Model.Models.Transportes.Transportador_EnderecoModel item in obj.lTransportador_Endereco)
                {
                    switch (item.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            {
                                item.idTransportador = (int)obj.idTransportador;
                                this.transportador_EnderecoRepository.Save(objTransportador_Endereco: item);
                            }
                            break;
                        case statusModel.excluido:
                            {
                                this.transportador_EnderecoRepository.Delete(idTransportadorEndereco: (int)item.idEndereco);
                            }
                            break;
                    }
                }

                foreach (HLP.Entries.Model.Models.Transportes.Transportador_MotoristaModel item in obj.lTransportador_Motorista)
                {
                    switch (item.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            {
                                item.idTransportador = (int)obj.idTransportador;
                                this.transportador_MotoristaRepository.Save(objTransportador_Motorista: item);
                            }
                            break;
                        case statusModel.excluido:
                            {
                                this.transportador_MotoristaRepository.Delete(idTransportadorMotorista: (int)item.idTransportdorMotorista);
                            }
                            break;
                    }
                }

                foreach (HLP.Entries.Model.Models.Transportes.Transportador_VeiculosModel item in obj.lTransportador_Veiculos)
                {
                    switch (item.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            {
                                item.idTransportador = (int)obj.idTransportador;
                                this.transportador_VeiculosRepository.Save(objTransportador_Veiculos: item);
                            }
                            break;
                        case statusModel.excluido:
                            {
                                this.transportador_VeiculosRepository.Delete(idTransportadorVeiculo: (int)item.idTransportadorVeiculo);
                            }
                            break;
                    }
                }
                this.transportadorRepository.CommitTransaction();
                return obj;
            }
            catch (Exception ex)
            {
                this.transportadorRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public bool DeleteObject(int id)
        {
            try
            {
                this.transportadorRepository.BeginTransaction();
                this.transportador_ContatoRepository.DeletePorTransportador(idTransportador: id);
                this.transportador_EnderecoRepository.DeletePorTransportador(idTransportador: id);
                this.transportador_MotoristaRepository.DeletePorTransportador(idTransportador: id);
                this.transportador_VeiculosRepository.DeletePorTransportador(idTransportador: id);
                this.transportadorRepository.Delete(idTransportador: id);
                this.transportadorRepository.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
                this.transportadorRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public TransportadorModel CopyObject(TransportadorModel obj)
        {
            try
            {
                this.transportadorRepository.BeginTransaction();
                this.transportadorRepository.Copy(objTransportador: obj);
                foreach (HLP.Entries.Model.Models.Transportes.Transportador_EnderecoModel item in obj.lTransportador_Endereco)
                {
                    item.idTransportador = (int)obj.idTransportador;
                    this.transportador_EnderecoRepository.Copy(objTransportador_Endereco: item);
                }
                foreach (HLP.Entries.Model.Models.Transportes.Transportador_MotoristaModel item in obj.lTransportador_Motorista)
                {
                    item.idTransportador = (int)obj.idTransportador;
                    this.transportador_MotoristaRepository.Copy(objTransportador_Motorista: item);
                }
                foreach (HLP.Entries.Model.Models.Transportes.Transportador_VeiculosModel item in obj.lTransportador_Veiculos)
                {
                    item.idTransportador = (int)obj.idTransportador;
                    this.transportador_VeiculosRepository.Copy(objTransportador_Veiculos: item);
                }
                this.transportadorRepository.CommitTransaction();
                return obj;
            }
            catch (Exception ex)
            {
                this.transportadorRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }
        
}
