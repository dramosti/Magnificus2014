using HLP.Base.ClassesBases;
using HLP.Base.EnumsBases;
using HLP.Components.Model.Models;
using HLP.Components.Model.Repository.Interfaces;
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
using System.Windows.Threading;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_Transportadora" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_Transportadora.svc or wcf_Transportadora.svc.cs at the Solution Explorer and start debugging.

    public class wcf_Transportadora : Iwcf_Transportadora
    {
        [Inject]
        public ITransportadorReposiroty transportadorRepository { get; set; }
        [Inject]
        public IHlpEnderecoRepository hlpEnderecoRepository { get; set; }
        [Inject]
        public ITransportador_VeiculosRepository transportador_VeiculosRepository { get; set; }
        [Inject]
        public IContatoRepository contatoRepository { get; set; }

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
                    new ObservableCollectionBaseCadastros<EnderecoModel>(
                        list: this.hlpEnderecoRepository.GetAllObjetos(idPK: id, sPK: "idTransportador"));

                objTransportador.lTransportador_Veiculos = new ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Transportes.Transportador_VeiculosModel>(
                    list: this.transportador_VeiculosRepository.GetAllTransportador_Veiculos(
                    idTransportador: id));

                var listContatos = contatoRepository.GetContato_ByForeignKey(id: objTransportador.idTransportador ?? 0, xForeignKey: "idContatoTransportador");

                if (listContatos != null)
                    objTransportador.lTransportador_Contato = new ObservableCollectionBaseCadastros<Components.Model.Models.ContatoModel>(
                        list: listContatos);

                var listMotoristas = contatoRepository.GetContato_ByForeignKey(id: objTransportador.idTransportador ?? 0,
                    xForeignKey: "idContatoMotorista");

                if (listMotoristas != null)
                    objTransportador.lTransportador_Motorista = new ObservableCollectionBaseCadastros<ContatoModel>(
                        list: listMotoristas);

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

                foreach (EnderecoModel item in obj.lTransportador_Endereco)
                {
                    switch (item.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            {
                                item.idTransportador = (int)obj.idTransportador;
                                this.hlpEnderecoRepository.Save(objEnderecoModel: item);
                            }
                            break;
                        case statusModel.excluido:
                            {
                                this.hlpEnderecoRepository.Delete(objEnderecoModel: item);
                            }
                            break;
                    }
                }

                foreach (ContatoModel item in obj.lTransportador_Motorista)
                {
                    switch (item.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            {
                                item.idContatoMotorista = obj.idTransportador ?? 0;
                                this.contatoRepository.Save(objContato: item);
                            }
                            break;
                        case statusModel.excluido:
                            {
                                this.contatoRepository.Delete(idContato: item.idContato ?? 0);
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

                foreach (ContatoModel item in obj.lTransportador_Contato)
                {
                    item.idContatoTransportador = obj.idTransportador;

                    switch (item.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            {
                                contatoRepository.Save(objContato: item);
                            }
                            break;
                        case statusModel.excluido:
                            {
                                contatoRepository.Delete(idContato: item.idContato ?? 0);
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
                this.hlpEnderecoRepository.Delete(idFK: id, sNameFK: "idTransportador");
                this.contatoRepository.DeleteContato_ByForeignKey(id: id, xForeignKey: "idContatoMotorista");
                this.transportador_VeiculosRepository.DeletePorTransportador(idTransportador: id);
                this.contatoRepository.DeleteContato_ByForeignKey(id: id, xForeignKey: "idContatoTransportador");
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
                foreach (EnderecoModel item in obj.lTransportador_Endereco)
                {
                    item.idEndereco = null;
                    item.idTransportador = (int)obj.idTransportador;
                    this.hlpEnderecoRepository.Copy(objEnderecoModel: item);
                }
                foreach (ContatoModel item in obj.lTransportador_Motorista)
                {
                    item.idContato = null;
                    item.idContatoMotorista = obj.idTransportador;
                    this.contatoRepository.Copy(idContato: item.idContato ?? 0);
                }
                foreach (HLP.Entries.Model.Models.Transportes.Transportador_VeiculosModel item in obj.lTransportador_Veiculos)
                {
                    item.idTransportadorVeiculo = null;
                    item.idTransportador = (int)obj.idTransportador;
                    this.transportador_VeiculosRepository.Copy(objTransportador_Veiculos: item);
                }
                foreach (ContatoModel c in obj.lTransportador_Contato)
                {
                    c.idContato = null;
                    c.idContatoTransportador = obj.idTransportador ?? 0;
                    this.contatoRepository.Copy(idContato: c.idContato ?? 0);
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
