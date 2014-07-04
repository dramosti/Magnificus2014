using HLP.Base.ClassesBases;
using HLP.Base.EnumsBases;
using HLP.Base.Static;
using HLP.Components.Model.Models;
using HLP.Components.Model.Repository.Interfaces;
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
        public IContatoRepository agencia_ContatoRepository { get; set; }

        [Inject]
        public IHlpEnderecoRepository agencia_EnderecoRepository { get; set; }

        [Inject]
        public IBancoRepository bancoRepository { get; set; }

        [Inject]
        public IConta_bancariaRepository conta_BancariaRepository { get; set; }

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

                if (objAgencia != null)
                {
                    objAgencia.lAgencia_ContatoModel =
                        new ObservableCollectionBaseCadastros<ContatoModel>(
                            list: this.agencia_ContatoRepository.GetContato_ByForeignKey(
                            id: id, xForeignKey: "idContatoAgencia"));

                    objAgencia.lAgencia_EnderecoModel =
                        new ObservableCollectionBaseCadastros<EnderecoModel>(
                            list: this.agencia_EnderecoRepository
                            .GetAllObjetos(idPK: id, sPK: "idAgencia"));
                }

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


                foreach (ContatoModel item
                    in obj.lAgencia_ContatoModel)
                {
                    switch (item.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            {
                                item.idContatoAgencia = (int)obj.idAgencia;
                                this.agencia_ContatoRepository.Save(objContato: item);
                            }
                            break;
                        case statusModel.excluido:
                            {
                                this.agencia_ContatoRepository.Delete(idContato: item.idContato ?? 0);
                            }
                            break;
                    }
                }


                foreach (EnderecoModel item
                    in obj.lAgencia_EnderecoModel)
                {
                    switch (item.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            {
                                item.idAgencia = (int)obj.idAgencia;
                                this.agencia_EnderecoRepository.Save(
                                    objEnderecoModel: item);
                            }
                            break;
                        case statusModel.excluido:
                            {
                                this.agencia_EnderecoRepository.Delete(objEnderecoModel: item);
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
                this.agencia_ContatoRepository.DeleteContato_ByForeignKey(id: id, xForeignKey: "idAgencia");
                this.agencia_EnderecoRepository.Delete(idFK: id, sNameFK: "idAgencia");
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

                foreach (ContatoModel item in Objeto.lAgencia_ContatoModel)
                {
                    item.idContato = null;
                    item.idContatoAgencia = (int)Objeto.idAgencia;
                    this.agencia_ContatoRepository.Copy(obj: item);
                }

                foreach (EnderecoModel item in Objeto.lAgencia_EnderecoModel)
                {
                    item.idEndereco = null;
                    item.idAgencia = (int)Objeto.idAgencia;
                    this.agencia_EnderecoRepository.Copy(objEnderecoModel: item);
                }

                return Objeto;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public HLP.Components.Model.Models.modelToTreeView GetHierarquia(int idAgencia)
        {
            HLP.Components.Model.Models.modelToTreeView objHierAg = new Components.Model.Models.modelToTreeView();
            HLP.Components.Model.Models.modelToTreeView objHierBanco = new Components.Model.Models.modelToTreeView();

            AgenciaModel ag = agenciaRepository.GetAgencia(idAgencia: idAgencia);

            if (ag != null)
            {
                objHierAg.id = ag.idAgencia ?? 0;
                objHierAg.xDisplay = ag.cAgencia + " - " + ag.xAgencia;
                objHierAg.xNameImage = "Agencia";

                HLP.Entries.Model.Models.Financeiro.BancoModel objBanco = bancoRepository.GetBanco(ag.idBanco);

                if (objBanco != null)
                {
                    objHierBanco.id = objBanco.idBanco ?? 0;
                    objHierBanco.xDisplay = objBanco.cBanco + " - " + objBanco.xBanco;
                    objHierBanco.xNameImage = "Banco";
                    objHierBanco.lFilhos.Add(
                        item: objHierAg);

                    HLP.Components.Model.Models.modelToTreeView objHierConta;
                    foreach (var ct in conta_BancariaRepository.GetByAgencia(ag.idAgencia ?? 0))
                    {
                        objHierConta = new Components.Model.Models.modelToTreeView();
                        objHierConta.id = (int)ct.idContaBancaria;
                        objHierConta.xDisplay = ct.xNumeroConta + " - " + ct.xDescricao;
                        objHierConta.xNameImage = "Conta_Bancaria";
                        objHierAg.lFilhos.Add(item: objHierConta);
                    }
                }
            }

            return objHierBanco;
        }
    }
}