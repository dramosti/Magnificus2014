using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HLP.Comum.Resources.Util;
using HLP.Dependencies;
using HLP.Entries.Model.Repository.Interfaces.Gerais;
using Ninject;
using HLP.Base.ClassesBases;
using HLP.Base.EnumsBases;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "servicePlanoPagamento" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select servicePlanoPagamento.svc or servicePlanoPagamento.svc.cs at the Solution Explorer and start debugging.
    public class servicePlanoPagamento : IservicePlanoPagamento
    {
        [Inject]
        public IPlano_pagamentoRepository iPlano_pagamentoRepository { get; set; }

        [Inject]
        public IPlano_pagamento_linhasRepository iPlano_pagamento_linhasRepository { get; set; }
        
        public servicePlanoPagamento() 
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public HLP.Entries.Model.Models.Gerais.Plano_pagamentoModel Save(HLP.Entries.Model.Models.Gerais.Plano_pagamentoModel objPlano_pagamento)
        {
            try
            {
                iPlano_pagamentoRepository.BeginTransaction();

                iPlano_pagamentoRepository.Save(objPlano_pagamento);

                foreach (var item in objPlano_pagamento.lPlano_pagamento_linhasModel)
                {
                    switch (item.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            {
                                item.idPlanoPagamento = (int)objPlano_pagamento.idPlanoPagamento;
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
                return objPlano_pagamento;

            }
            catch (Exception ex)
            {
                iPlano_pagamentoRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        
        }

        public bool Delete(HLP.Entries.Model.Models.Gerais.Plano_pagamentoModel objPlano_pagamento)
        {
            try
            {
                iPlano_pagamentoRepository.BeginTransaction();
                iPlano_pagamento_linhasRepository.DeleteLinhasByPlano((int)objPlano_pagamento.idPlanoPagamento);
                iPlano_pagamentoRepository.Delete(objPlano_pagamento);
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

        public HLP.Entries.Model.Models.Gerais.Plano_pagamentoModel Copy(HLP.Entries.Model.Models.Gerais.Plano_pagamentoModel objPlano_pagamento)
        {
            try
            {
                iPlano_pagamentoRepository.BeginTransaction();
                iPlano_pagamentoRepository.Copy(objPlano_pagamento);
                foreach (var item in objPlano_pagamento.lPlano_pagamento_linhasModel)
                {
                    item.idPlanoPagamento = (int)objPlano_pagamento.idPlanoPagamento;
                    item.idLinhasPagamento = null;
                    iPlano_pagamento_linhasRepository.Copy(item);
                }
                iPlano_pagamentoRepository.CommitTransaction();
                return this.GetObject((int)objPlano_pagamento.idPlanoPagamento);
            }
            catch (Exception ex)
            {
                iPlano_pagamentoRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public HLP.Entries.Model.Models.Gerais.Plano_pagamentoModel GetObject(int idPlanoPagamento)
        {

            try
            {
                HLP.Entries.Model.Models.Gerais.Plano_pagamentoModel objRet = iPlano_pagamentoRepository.GetPlano_pagamento(idPlanoPagamento);
                if (objRet != null)
                {
                    objRet.lPlano_pagamento_linhasModel = new ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Gerais.Plano_pagamento_linhasModel>(iPlano_pagamento_linhasRepository.GetAllPlano_pagamento_linhas(idPlanoPagamento));
                }
                return objRet;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        
        }
    }
}
