using HLP.Comum.Model.Models;
using HLP.Comum.Resources.RecursosBases;
using HLP.Comum.Resources.Util;
using HLP.Dependencies;
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceAgencia" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceAgencia.svc or serviceAgencia.svc.cs at the Solution Explorer and start debugging.
    public class serviceAgencia : IserviceAgencia
    {
        [Inject]
        public IAgenciaRepository agenciaRepository { get; set; }

        [Inject]
        public IAgencia_ContatoRepository agencia_ContatoRepository { get; set; }

        [Inject]
        public IAgencia_EnderecoRepository agencia_EnderecoRepository { get; set; }

        public serviceAgencia()
        {

            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";

        }

        public int Save(HLP.Entries.Model.Models.Financeiro.AgenciaModel Objeto)
        {

            try
            {
                agenciaRepository.BeginTransaction();

                agenciaRepository.Save(objAgencia: Objeto);


                foreach (HLP.Entries.Model.Models.Financeiro.Agencia_ContatoModel item
                    in Objeto.lAgencia_ContatoModel)
                {
                    switch (item.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            {
                                item.idAgencia = (int)Objeto.idAgencia;
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
                    in Objeto.lAgencia_EnderecoModel)
                {
                    switch (item.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            {
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
                return (int)Objeto.idAgencia;
            }
            catch (Exception ex)
            {
                agenciaRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public HLP.Entries.Model.Models.Financeiro.AgenciaModel GetObjeto(int idObjeto)
        {

            try
            {
                HLP.Entries.Model.Models.Financeiro.AgenciaModel objAgencia =
                    this.agenciaRepository.GetAgencia(idAgencia: idObjeto);

                objAgencia.lAgencia_ContatoModel =
                    new ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Financeiro.Agencia_ContatoModel>(
                        list: this.agencia_ContatoRepository.GetAllAgencia_Contato(idAgencia: idObjeto));

                objAgencia.lAgencia_EnderecoModel =
                    new ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Financeiro.Agencia_EnderecoModel>(
                        list: this.agencia_EnderecoRepository.GetAllAgencia_Endereco(idAgencia: idObjeto));

                return objAgencia;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public bool Delete(HLP.Entries.Model.Models.Financeiro.AgenciaModel Objeto)
        {

            try
            {
                this.agenciaRepository.BeginTransaction();
                this.agencia_ContatoRepository.DeletePorAgencia(idAgencia: (int)Objeto.idAgencia);
                this.agencia_EnderecoRepository.DeletePorAgencia(idAgencia: (int)Objeto.idAgencia);
                this.agenciaRepository.Delete(idAgencia: (int)Objeto.idAgencia);
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

        public int Copy(HLP.Entries.Model.Models.Financeiro.AgenciaModel Objeto)
        {
            try
            {
                this.agenciaRepository.BeginTransaction();
                this.agenciaRepository.Copy(objAgencia: Objeto);

                foreach (HLP.Entries.Model.Models.Financeiro.Agencia_ContatoModel item in Objeto.lAgencia_ContatoModel)
                {
                    item.idAgencia = (int)Objeto.idAgencia;
                    this.agencia_ContatoRepository.Copy(objAgencia_Contato: item);
                }

                foreach (HLP.Entries.Model.Models.Financeiro.Agencia_EnderecoModel item in Objeto.lAgencia_EnderecoModel)
                {
                    item.idAgencia = (int)Objeto.idAgencia;
                    this.agencia_EnderecoRepository.Copy(objAgencia_Endereco: item);
                }

                return (int)Objeto.idAgencia;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }
}
