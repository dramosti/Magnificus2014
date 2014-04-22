using HLP.Base.Static;
using HLP.Components.Model.Models;
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_ContaBancaria" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_ContaBancaria.svc or wcf_ContaBancaria.svc.cs at the Solution Explorer and start debugging.

    public class wcf_ContaBancaria : Iwcf_ContaBancaria
    {
        [Inject]
        public IConta_bancariaRepository conta_BancariaRepository { get; set; }

        [Inject]
        public IAgenciaRepository agenciaRepository { get; set; }

        [Inject]
        public IBancoRepository bancoRepository { get; set; }

        public wcf_ContaBancaria()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public Conta_bancariaModel GetObject(int id)
        {
            try
            {
                return this.conta_BancariaRepository.GetConta(idContaBancaria: id);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public int SaveObject(Conta_bancariaModel obj)
        {
            try
            {
                conta_BancariaRepository.Save(conta: obj);
                return obj.idContaBancaria ?? 0;
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
                conta_BancariaRepository.Delete(idContaBancaria: id);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public Conta_bancariaModel CopyObject(int id)
        {
            try
            {
                return this.GetObject(id:
                    this.conta_BancariaRepository.Copy(idContaBancaria: id));
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public modelToTreeView GetHierarquia(int idAgencia)
        {
            modelToTreeView t = new modelToTreeView();

            AgenciaModel a = this.agenciaRepository.GetAgencia(idAgencia: idAgencia);

            if (a != null)
            {
                BancoModel b = this.bancoRepository.GetBanco(idBanco: a.idBanco);

                List<modelToTreeView> lContas = new List<modelToTreeView>();


                try
                {
                    foreach (var c in this.conta_BancariaRepository.GetByAgencia(idAgencia: idAgencia))
                    {
                        lContas.Add(item:
                            new modelToTreeView
                            {
                                id = c.idContaBancaria ?? 0,
                                xDisplay = c.xNumeroConta + " - " + c.xDescricao
                            });
                    }
                }
                catch (Exception ex)
                {
                    throw new FaultException(reason: ex.Message);
                }                

                t.id = b.idBanco ?? 0;
                t.xDisplay = b.cBanco + " - " + b.xBanco;

                t.lFilhos = new List<modelToTreeView>
            {
                new modelToTreeView
                {
                    id = a.idAgencia ?? 0,
                    xDisplay = a.cAgencia + " - "+a.xAgencia,
                    lFilhos = lContas
                }
            };
            }
            return t;
        }
    }

}
