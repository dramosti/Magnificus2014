using HLP.Comum.Resources.Util;
using HLP.Dependencies;
using HLP.Entries.Model.Repository.Interfaces.Fiscal;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceTipo_Operacao" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceTipo_Operacao.svc or serviceTipo_Operacao.svc.cs at the Solution Explorer and start debugging.
    public class serviceTipo_Operacao : IserviceTipo_Operacao
    {
        [Inject]
        public ITipo_operacaoRepository tipo_operacaoRepository { get; set; }

        public serviceTipo_Operacao()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public int Save(HLP.Entries.Model.Models.Fiscal.Tipo_operacaoModel Objeto)
        {

            try
            {
                this.tipo_operacaoRepository.Begin();
                this.tipo_operacaoRepository.Save(operacao: Objeto);
                this.tipo_operacaoRepository.Commit();
                return (int)Objeto.idTipoOperacao;
            }
            catch (Exception ex)
            {
                this.tipo_operacaoRepository.RollBack();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public HLP.Entries.Model.Models.Fiscal.Tipo_operacaoModel GetObjeto(int idObjeto)
        {

            try
            {
                return this.tipo_operacaoRepository.GetOperacao(idTipoOperacao: idObjeto);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public bool Delete(HLP.Entries.Model.Models.Fiscal.Tipo_operacaoModel Objeto)
        {

            try
            {
                this.tipo_operacaoRepository.Begin();
                this.tipo_operacaoRepository.Delete(idTipoOperacao: (int)Objeto.idTipoOperacao);
                this.tipo_operacaoRepository.Commit();
                return true;
            }
            catch (Exception ex)
            {
                this.tipo_operacaoRepository.RollBack();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public int Copy(HLP.Entries.Model.Models.Fiscal.Tipo_operacaoModel Objeto)
        {

            try
            {
                this.tipo_operacaoRepository.Begin();
                int id = this.tipo_operacaoRepository.Copy(idTipoOperacao: (int)Objeto.idTipoOperacao);
                this.tipo_operacaoRepository.Commit();

                return id;
            }
            catch (Exception ex)
            {
                this.tipo_operacaoRepository.RollBack();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }
    }
}
