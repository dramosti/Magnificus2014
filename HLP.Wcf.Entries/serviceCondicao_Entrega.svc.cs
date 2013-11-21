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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceCondicao_Entrega" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceCondicao_Entrega.svc or serviceCondicao_Entrega.svc.cs at the Solution Explorer and start debugging.
    public class serviceCondicao_Entrega : IserviceCondicao_Entrega
    {
        [Inject]
        public ICondicoes_entregaRepository condicoes_entregaRepository { get; set; }

        public serviceCondicao_Entrega()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public HLP.Entries.Model.Models.Gerais.Condicoes_entregaModel getCondicao_entrega(int idCondicao_entrega)
        {

            try
            {
                return this.condicoes_entregaRepository.GetCondicao(idCondicaoEntrega: idCondicao_entrega);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public int saveCondicao_entrega(HLP.Entries.Model.Models.Gerais.Condicoes_entregaModel objCondicao_entrega)
        {
            try
            {
                this.condicoes_entregaRepository.Save(condicao:
                    objCondicao_entrega);
                return (int)objCondicao_entrega.idCondicaoEntrega;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public bool delCondicao_entrega(int idCondicao_entrega)
        {
            try
            {
                this.condicoes_entregaRepository.Delete(idCondicaoEntrega:
                    idCondicao_entrega);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public int copyCondicao_entrega(int idCondicao_entrega)
        {
            try
            {
                return this.condicoes_entregaRepository.Copy(idCondicaoEntrega: idCondicao_entrega);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }
}
