using HLP.Comum.Model.Models;
using HLP.Comum.Resources.Util;
using HLP.Dependencies;
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceTransportador" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceTransportador.svc or serviceTransportador.svc.cs at the Solution Explorer and start debugging.
    public class serviceTransportador : IserviceTransportador
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

        public serviceTransportador()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public HLP.Entries.Model.Models.Transportes.TransportadorModel getTransportador(int idTransportador)
        {
            HLP.Entries.Model.Models.Transportes.TransportadorModel objTransportador;
            try
            {
                objTransportador = this.transportadorRepository.GetTransportador(idTransportador: idTransportador);
                objTransportador.lTransportador_Contato =
                    new ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Transportes.Transportador_ContatoModel>(
                    list: this.transportador_ContatoRepository.GetAllTransportador_Contato(
                    idTransportador: idTransportador));
                objTransportador.lTransportador_Endereco =
                    new ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Transportes.Transportador_EnderecoModel>(
                        list: this.transportador_EnderecoRepository.GetAllTransportador_Endereco(
                        idTransportador: idTransportador));
                objTransportador.lTransportador_Motorista =
                    new ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Transportes.Transportador_MotoristaModel>(
                        list: this.transportador_MotoristaRepository.GetAllTransportador_Motorista(
                        idTransportador: idTransportador));
                objTransportador.lTransportador_Veiculos = new ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Transportes.Transportador_VeiculosModel>(
                    list: this.transportador_VeiculosRepository.GetAllTransportador_Veiculos(
                    idTransportador: idTransportador));
                return objTransportador;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public int saveTransportador(HLP.Entries.Model.Models.Transportes.TransportadorModel objTransportador)
        {

            try
            {
                this.transportadorRepository.BeginTransaction();
                this.transportadorRepository.Save(objTransportador: objTransportador);

                foreach (HLP.Entries.Model.Models.Transportes.Transportador_ContatoModel item in objTransportador.lTransportador_Contato)
                {
                    switch (item.status)
                    {
                        case HLP.Comum.Resources.RecursosBases.statusModel.criado:
                        case HLP.Comum.Resources.RecursosBases.statusModel.alterado:
                            {
                                this.transportador_ContatoRepository.Save(objTransportador_Contato:
                                    item);
                            }
                            break;
                        case HLP.Comum.Resources.RecursosBases.statusModel.excluido:
                            {
                                this.transportador_ContatoRepository.Delete(idTransportadorContato: (int)item.idTransportdorContato);
                            }
                            break;
                    }
                }

                foreach (HLP.Entries.Model.Models.Transportes.Transportador_EnderecoModel item in objTransportador.lTransportador_Endereco)
                {
                    switch (item.status)
                    {
                        case HLP.Comum.Resources.RecursosBases.statusModel.criado:
                        case HLP.Comum.Resources.RecursosBases.statusModel.alterado:
                            {
                                this.transportador_EnderecoRepository.Save(objTransportador_Endereco: item);
                            }
                            break;
                        case HLP.Comum.Resources.RecursosBases.statusModel.excluido:
                            {
                                this.transportador_EnderecoRepository.Delete(idTransportadorEndereco: (int)item.idEndereco);
                            }
                            break;
                    }
                }

                foreach (HLP.Entries.Model.Models.Transportes.Transportador_MotoristaModel item in objTransportador.lTransportador_Motorista)
                {
                    switch (item.status)
                    {
                        case HLP.Comum.Resources.RecursosBases.statusModel.criado:
                        case HLP.Comum.Resources.RecursosBases.statusModel.alterado:
                            {
                                this.transportador_MotoristaRepository.Save(objTransportador_Motorista: item);
                            }
                            break;
                        case HLP.Comum.Resources.RecursosBases.statusModel.excluido:
                            {
                                this.transportador_MotoristaRepository.Delete(idTransportadorMotorista: (int)item.idTransportdorMotorista);
                            }
                            break;
                    }
                }

                foreach (HLP.Entries.Model.Models.Transportes.Transportador_VeiculosModel item in objTransportador.lTransportador_Veiculos)
                {
                    switch (item.status)
                    {
                        case HLP.Comum.Resources.RecursosBases.statusModel.criado:
                        case HLP.Comum.Resources.RecursosBases.statusModel.alterado:
                            {
                                this.transportador_VeiculosRepository.Save(objTransportador_Veiculos: item);
                            }
                            break;
                        case HLP.Comum.Resources.RecursosBases.statusModel.excluido:
                            {
                                this.transportador_VeiculosRepository.Delete(idTransportadorVeiculo: (int)item.idTransportadorVeiculo);
                            }
                            break;
                    }
                }

                this.transportadorRepository.CommitTransaction();
                return (int)objTransportador.idTransportador;
            }
            catch (Exception ex)
            {
                this.transportadorRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public bool delTransportador(int idTransportador)
        {
            throw new NotImplementedException();
        }

        public int copyTransportador(int idTransportador)
        {
            throw new NotImplementedException();
        }
    }
}
