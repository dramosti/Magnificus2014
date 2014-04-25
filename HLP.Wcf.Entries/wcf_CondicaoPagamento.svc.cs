using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HLP.Entries.Model.Models.Gerais;
using Ninject;
using HLP.Dependencies;
using HLP.Base.Static;
using HLP.Entries.Model.Repository.Interfaces.Gerais;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_CondicaoPagamento" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_CondicaoPagamento.svc or wcf_CondicaoPagamento.svc.cs at the Solution Explorer and start debugging.


    public class wcf_CondicaoPagamento : Iwcf_CondicaoPagamento
    {
        [Inject]
        public ICondicao_pagamentoRepository condicao_pagamentoRepository { get; set; }

        public wcf_CondicaoPagamento()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public Condicao_pagamentoModel GetObject(int id)
        {
            try
            {
                return this.condicao_pagamentoRepository.GetCondicao(idCondicaoPagamento: id);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw;
            }
        }

        public int SaveObject(Condicao_pagamentoModel obj)
        {
            try
            {
                condicao_pagamentoRepository.Save(condicao: obj);
                return obj.idCondicaoPagamento ?? 0;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw;
            }
        }

        public bool DeleteObject(int id)
        {
            try
            {
                condicao_pagamentoRepository.Delete(idCondicaoPagamento: id);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public Condicao_pagamentoModel CopyObject(int id)
        {
            try
            {
                return this.condicao_pagamentoRepository.GetCondicao(idCondicaoPagamento:
                    this.condicao_pagamentoRepository.Copy(idCondicaoPagamento: id));
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }

}
