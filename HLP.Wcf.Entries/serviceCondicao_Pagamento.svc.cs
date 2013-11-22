using HLP.Comum.Resources.Util;
using HLP.Dependencies;
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceCondicao_Pagamento" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceCondicao_Pagamento.svc or serviceCondicao_Pagamento.svc.cs at the Solution Explorer and start debugging.
    public class serviceCondicao_Pagamento : IserviceCondicao_Pagamento
    {
        [Inject]
        public ICondicao_pagamentoRepository condicao_PagamentoRepository { get; set; }

        public serviceCondicao_Pagamento()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public HLP.Entries.Model.Models.Gerais.Condicao_pagamentoModel getCondicao_pagamento(int idCondicao_pagamento)
        {

            try
            {
                return this.condicao_PagamentoRepository.GetCondicao(
                    idCondicaoPagamento: idCondicao_pagamento);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public int saveCondicao_pagamento(HLP.Entries.Model.Models.Gerais.Condicao_pagamentoModel objCondicao_pagamento)
        {

            try
            {
                this.condicao_PagamentoRepository.Save(condicao:
                     objCondicao_pagamento);
                return (int)objCondicao_pagamento.idCondicaoPagamento;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public bool deleteCondicao_pagamento(int idCondicao_pagamento)
        {

            try
            {
                this.condicao_PagamentoRepository.Delete(idCondicaoPagamento:
                    idCondicao_pagamento);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public int copyCondicao_pagamento(int idCondicao_pagamento)
        {

            try
            {
                return this.condicao_PagamentoRepository.Copy(idCondicaoPagamento:
                    idCondicao_pagamento);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }
    }
}
