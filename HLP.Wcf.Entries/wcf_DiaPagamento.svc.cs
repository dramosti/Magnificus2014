using HLP.Base.ClassesBases;
using HLP.Base.EnumsBases;
using HLP.Comum.Resources.Util;
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_DiaPagamento" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_DiaPagamento.svc or wcf_DiaPagamento.svc.cs at the Solution Explorer and start debugging.

    public class wcf_DiaPagamento : Iwcf_DiaPagamento
    {
        [Inject]
        public IDia_PagamentoRepository dia_PagamentoRepository { get; set; }

        [Inject]
        public IDia_pagamento_linhasRepository dia_pagamento_linhasRepository { get; set; }

        public wcf_DiaPagamento()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public Dia_pagamentoModel GetObject(int id)
        {
            try
            {
                HLP.Entries.Model.Models.Financeiro.Dia_pagamentoModel objret = this.dia_PagamentoRepository.GetDia_pagamento(idDiaPagamento: id);
                if (objret != null)
                {
                    objret.lDia_pagamento_linhas = new ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Financeiro.Dia_pagamento_linhasModel>(dia_pagamento_linhasRepository.GetAllDia_pagamento_linhas(idDiaPagamento: id));
                }
                return objret;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public Dia_pagamentoModel SaveObject(Dia_pagamentoModel obj)
        {
            try
            {
                dia_PagamentoRepository.BeginTransaction();

                dia_PagamentoRepository.Save(objDia_pagamento: obj);

                foreach (var item in obj.lDia_pagamento_linhas)
                {
                    switch (item.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            {
                                item.idDiaPagamento = (int)obj.idDiaPagamento;
                                dia_pagamento_linhasRepository.Save(item);
                            }
                            break;
                        case statusModel.excluido:
                            dia_pagamento_linhasRepository.Delete(item);
                            break;
                    }
                }
                dia_PagamentoRepository.CommitTransaction();
                return obj;
            }
            catch (Exception ex)
            {
                dia_PagamentoRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public bool DeleteObject(int id)
        {
            try
            {
                dia_PagamentoRepository.BeginTransaction();
                dia_pagamento_linhasRepository.DeleteLinhasByDia(idDiaPagamento: id);
                dia_PagamentoRepository.Delete(id: id);
                dia_PagamentoRepository.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
                dia_PagamentoRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public Dia_pagamentoModel CopyObject(Dia_pagamentoModel obj)
        {
            try
            {
                dia_PagamentoRepository.BeginTransaction();
                dia_PagamentoRepository.Copy(objDia_pagamento: obj);
                foreach (var item in obj.lDia_pagamento_linhas)
                {
                    item.idDiaPagamentoLinhas = null;
                    item.idDiaPagamento = (int)obj.idDiaPagamento;
                    dia_pagamento_linhasRepository.Copy(item);
                }
                dia_PagamentoRepository.CommitTransaction();
                return obj;
            }
            catch (Exception ex)
            {
                dia_PagamentoRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }

}
