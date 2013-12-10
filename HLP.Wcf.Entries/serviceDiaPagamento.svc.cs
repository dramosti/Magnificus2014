using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HLP.Comum.Resources.Util;
using HLP.Dependencies;
using HLP.Entries.Model.Repository.Interfaces.Financeiro;
using Ninject;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceDiaPagamento" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceDiaPagamento.svc or serviceDiaPagamento.svc.cs at the Solution Explorer and start debugging.
    public class serviceDiaPagamento : IserviceDiaPagamento
    {
        [Inject]
        public IDia_PagamentoRepository iDia_PagamentoRepository { get; set; }
        [Inject]
        public IDia_pagamento_linhasRepository iDia_pagamento_linhasRepository { get; set; }


        public serviceDiaPagamento() 
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";

        }

        public HLP.Entries.Model.Models.Financeiro.Dia_pagamentoModel Save(HLP.Entries.Model.Models.Financeiro.Dia_pagamentoModel objDia_pagamento)
        {
            try
            {
                iDia_PagamentoRepository.BeginTransaction();

                iDia_PagamentoRepository.Save(objDia_pagamento);

                foreach (var item in objDia_pagamento.lDia_pagamento_linhas)
                {
                    switch (item.status)
                    {
                        case HLP.Comum.Resources.RecursosBases.statusModel.criado:
                        case HLP.Comum.Resources.RecursosBases.statusModel.alterado:
                            {
                                item.idDiaPagamento = (int)objDia_pagamento.idDiaPagamento;
                                iDia_pagamento_linhasRepository.Save(item);
                            }
                            break;
                        case HLP.Comum.Resources.RecursosBases.statusModel.excluido:
                            iDia_pagamento_linhasRepository.Delete(item);
                            break;
                    }
                }
                iDia_PagamentoRepository.CommitTransaction();
                return objDia_pagamento;
            }
            catch (Exception ex)
            {
                iDia_PagamentoRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        
        }

        public bool Delete(HLP.Entries.Model.Models.Financeiro.Dia_pagamentoModel objDia_pagamento)
        {
            try
            {
                iDia_PagamentoRepository.BeginTransaction();
                iDia_pagamento_linhasRepository.DeleteLinhasByDia((int)objDia_pagamento.idDiaPagamento);
                iDia_PagamentoRepository.Delete(objDia_pagamento);
                iDia_PagamentoRepository.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
                iDia_PagamentoRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public int Copy(HLP.Entries.Model.Models.Financeiro.Dia_pagamentoModel objDia_pagamento)
        {
            try
            {
                iDia_PagamentoRepository.BeginTransaction();
                iDia_PagamentoRepository.Copy(objDia_pagamento);

                foreach (var item in objDia_pagamento.lDia_pagamento_linhas)
                {
                    item.idDiaPagamento = (int)objDia_pagamento.idDiaPagamento;
                    iDia_pagamento_linhasRepository.Copy(item);
                }
                iDia_PagamentoRepository.CommitTransaction();
                return (int)objDia_pagamento.idDiaPagamento;
            }
            catch (Exception ex)
            {
                iDia_PagamentoRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public HLP.Entries.Model.Models.Financeiro.Dia_pagamentoModel GetObect(int idDiaPagamento)
        {

            try
            {
                HLP.Entries.Model.Models.Financeiro.Dia_pagamentoModel objret = iDia_PagamentoRepository.GetDia_pagamento(idDiaPagamento);
                if (objret != null)
                {
                    objret.lDia_pagamento_linhas = new Comum.Model.Models.ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Financeiro.Dia_pagamento_linhasModel>(iDia_pagamento_linhasRepository.GetAllDia_pagamento_linhas(idDiaPagamento));
                }
                return objret;

            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        
        }
    }
}
