using HLP.Base.Static;
using HLP.Dependencies;
using HLP.Entries.Model.Repository.Interfaces.Financeiro;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceBanco" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceBanco.svc or serviceBanco.svc.cs at the Solution Explorer and start debugging.
    public class wcf_Banco : Iwcf_Banco
    {
        [Inject]
        public IBancoRepository bancoRepository { get; set; }
        [Inject]
        public IAgenciaRepository agenciaRepository { get; set; }
        [Inject]
        public IConta_bancariaRepository conta_BancariaRepository { get; set; }

        public wcf_Banco()
        {

            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public int Save(HLP.Entries.Model.Models.Financeiro.BancoModel Objeto)
        {
            try
            {
                bancoRepository.Save(banco: Objeto);
                return (int)Objeto.idBanco;
            }
            catch (SqlException sEx)
            {
                throw sEx;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public HLP.Entries.Model.Models.Financeiro.BancoModel GetObjeto(int idObjeto)
        {

            try
            {
                return this.bancoRepository.GetBanco(idBanco: idObjeto);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public bool Delete(HLP.Entries.Model.Models.Financeiro.BancoModel Objeto)
        {

            try
            {
                this.bancoRepository.Delete(idBanco: (int)(Objeto.idBanco));
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public int Copy(HLP.Entries.Model.Models.Financeiro.BancoModel Objeto)
        {

            try
            {
                return this.bancoRepository.Copy(idBanco: (int)Objeto.idBanco);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public HLP.Components.Model.Models.modelToTreeView GetHierarquia(int idBanco)
        {
            try
            {


                HLP.Components.Model.Models.modelToTreeView b = new Components.Model.Models.modelToTreeView();
                HLP.Entries.Model.Models.Financeiro.BancoModel objBanco = bancoRepository.GetBanco(idBanco);
                if (objBanco != null)
                {
                    b.id = (int)objBanco.idBanco;
                    b.xDisplay = objBanco.cBanco + " - " + objBanco.xBanco;
                    b.xNameImage = "Banco";

                    HLP.Components.Model.Models.modelToTreeView agencia;
                    HLP.Components.Model.Models.modelToTreeView conta;
                    foreach (var ag in agenciaRepository.GetByBanco((int)objBanco.idBanco))
                    {
                        agencia = new Components.Model.Models.modelToTreeView();
                        agencia.id = (int)ag.idAgencia;
                        agencia.xDisplay = ag.cAgencia + " - " + ag.xAgencia;
                        agencia.xNameImage = "Agencia";

                        foreach (var ct in conta_BancariaRepository.GetByAgencia(agencia.id))
                        {
                            conta = new Components.Model.Models.modelToTreeView();
                            conta.id = (int)ct.idContaBancaria;
                            conta.xDisplay = ct.xNumeroConta + " - " + ct.xDescricao;
                            conta.xNameImage = "Conta_Bancaria";
                            agencia.lFilhos.Add(conta);
                        }
                        b.lFilhos.Add(agencia);
                    }
                }
                return b;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }
}
