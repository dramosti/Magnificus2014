using HLP.Base.ClassesBases;
using HLP.Base.EnumsBases;
using HLP.Base.Static;
using HLP.Dependencies;
using HLP.Entries.Model.Models.Financeiro;
using HLP.Entries.Model.Repository.Interfaces.Financeiro;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_Agencia" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_Agencia.svc or wcf_Agencia.svc.cs at the Solution Explorer and start debugging.
    public class wcf_Agencia : Iwcf_Agencia
    {
        [Inject]
        public IAgenciaRepository agenciaRepository { get; set; }

        [Inject]
        public IAgencia_ContatoRepository agencia_ContatoRepository { get; set; }

        [Inject]
        public IAgencia_EnderecoRepository agencia_EnderecoRepository { get; set; }

        public wcf_Agencia()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public AgenciaModel GetObject(int id)
        {
            try
            {
                HLP.Entries.Model.Models.Financeiro.AgenciaModel objAgencia =
                    this.agenciaRepository.GetAgencia(idAgencia: id);

                objAgencia.lAgencia_ContatoModel =
                    new ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Financeiro.Agencia_ContatoModel>(
                        list: this.agencia_ContatoRepository.GetAllAgencia_Contato(idAgencia: id));

                objAgencia.lAgencia_EnderecoModel =
                    new ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Financeiro.Agencia_EnderecoModel>(
                        list: this.agencia_EnderecoRepository.GetAllAgencia_Endereco(idAgencia: id));

                return objAgencia;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public AgenciaModel SaveObject(AgenciaModel obj)
        {
            try
            {
                agenciaRepository.BeginTransaction();

                agenciaRepository.Save(objAgencia: obj);


                foreach (HLP.Entries.Model.Models.Financeiro.Agencia_ContatoModel item
                    in obj.lAgencia_ContatoModel)
                {
                    switch (item.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            {
                                item.idAgencia = (int)obj.idAgencia;
                                this.agencia_ContatoRepository.Save(
                                    objAgencia_Contato: item);
                            }
                            break;
                        case statusModel.excluido:
                            {
                                this.agencia_ContatoRepository.Delete(
                                    idAgenciaContato: (int)item.idAgenciaContato);
                            }
                            break;
                    }
                }


                foreach (HLP.Entries.Model.Models.Financeiro.Agencia_EnderecoModel item
                    in obj.lAgencia_EnderecoModel)
                {
                    switch (item.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            {
                                item.idAgencia = (int)obj.idAgencia;
                                this.agencia_EnderecoRepository.Save(
                                    objAgencia_Endereco: item);
                            }
                            break;
                        case statusModel.excluido:
                            {
                                this.agencia_EnderecoRepository.Delete(
                                    idEnderecoAgencia: (int)item.idEndereco);
                            }
                            break;
                    }
                }
                agenciaRepository.CommitTransaction();
                return obj;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public bool DeleteObject(int id)
        {
            try
            {
                this.agenciaRepository.BeginTransaction();
                this.agencia_ContatoRepository.DeletePorAgencia(idAgencia: id);
                this.agencia_EnderecoRepository.DeletePorAgencia(idAgencia: id);
                this.agenciaRepository.Delete(idAgencia: id);
                this.agenciaRepository.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
                this.agenciaRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public AgenciaModel CopyObject(AgenciaModel Objeto)
        {
            try
            {
                this.agenciaRepository.BeginTransaction();
                this.agenciaRepository.Copy(objAgencia: Objeto);

                foreach (HLP.Entries.Model.Models.Financeiro.Agencia_ContatoModel item in Objeto.lAgencia_ContatoModel)
                {
                    item.idAgenciaContato = null;
                    item.idAgencia = (int)Objeto.idAgencia;
                    this.agencia_ContatoRepository.Copy(objAgencia_Contato: item);
                }

                foreach (HLP.Entries.Model.Models.Financeiro.Agencia_EnderecoModel item in Objeto.lAgencia_EnderecoModel)
                {
                    item.idEndereco = null;
                    item.idAgencia = (int)Objeto.idAgencia;
                    this.agencia_EnderecoRepository.Copy(objAgencia_Endereco: item);
                }

                return Objeto;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }
}