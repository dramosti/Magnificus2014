using HLP.Base.ClassesBases;
using HLP.Base.EnumsBases;
using HLP.Base.Static;
using HLP.Dependencies;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.Model.Repository.Interfaces.Gerais;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_PlanoPagamento" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_PlanoPagamento.svc or wcf_PlanoPagamento.svc.cs at the Solution Explorer and start debugging.

    public class wcf_PlanoPagamento : Iwcf_PlanoPagamento
    {
        [Inject]
        public IPlano_pagamentoRepository iPlano_pagamentoRepository { get; set; }

        [Inject]
        public IPlano_pagamento_linhasRepository iPlano_pagamento_linhasRepository { get; set; }

        public wcf_PlanoPagamento()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public Plano_pagamentoModel GetObject(int id)
        {
            try
            {
                HLP.Entries.Model.Models.Gerais.Plano_pagamentoModel objRet = iPlano_pagamentoRepository.GetPlano_pagamento(idPlanoPagamento: id);
                if (objRet != null)
                {
                    objRet.lPlano_pagamento_linhasModel = new ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Gerais.Plano_pagamento_linhasModel>(iPlano_pagamento_linhasRepository.GetAllPlano_pagamento_linhas(id));
                }
                return objRet;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public Plano_pagamentoModel SaveObject(Plano_pagamentoModel obj)
        {
            iPlano_pagamentoRepository.BeginTransaction();

            iPlano_pagamentoRepository.Save(obj);

            foreach (var item in obj.lPlano_pagamento_linhasModel)
            {
                switch (item.status)
                {
                    case statusModel.criado:
                    case statusModel.alterado:
                        {
                            item.idPlanoPagamento = (int)obj.idPlanoPagamento;
                            iPlano_pagamento_linhasRepository.Save(item);
                        }
                        break;
                    case statusModel.excluido:
                        {
                            iPlano_pagamento_linhasRepository.Delete((int)item.idLinhasPagamento);
                        }
                        break;
                }
            }
            iPlano_pagamentoRepository.CommitTransaction();
            return obj;
        }

        public bool DeleteObject(Plano_pagamentoModel obj)
        {
            try
            {
                iPlano_pagamentoRepository.BeginTransaction();
                iPlano_pagamento_linhasRepository.DeleteLinhasByPlano(obj.idPlanoPagamento ?? 0);
                iPlano_pagamentoRepository.Delete(obj);
                iPlano_pagamentoRepository.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
                iPlano_pagamentoRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public Plano_pagamentoModel CopyObject(Plano_pagamentoModel obj)
        {
            try
            {
                iPlano_pagamentoRepository.BeginTransaction();
                iPlano_pagamentoRepository.Copy(objPlano_pagamento: obj);
                foreach (var item in obj.lPlano_pagamento_linhasModel)
                {
                    item.idPlanoPagamento = (int)obj.idPlanoPagamento;
                    item.idLinhasPagamento = null;
                    iPlano_pagamento_linhasRepository.Copy(item);
                }
                iPlano_pagamentoRepository.CommitTransaction();
                return obj;
            }
            catch (Exception ex)
            {
                iPlano_pagamentoRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }

}
