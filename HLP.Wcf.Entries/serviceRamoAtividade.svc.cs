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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceRamoAtividade" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceRamoAtividade.svc or serviceRamoAtividade.svc.cs at the Solution Explorer and start debugging.
    public class serviceRamoAtividade : IserviceRamoAtividade
    {
        [Inject]
        public IRamo_atividadeRepository ramo_AtividadeRempository { get; set; }

        public serviceRamoAtividade()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public HLP.Entries.Model.Models.Gerais.Ramo_atividadeModel getRamo_atividade(int idRamo_atividade)
        {

            try
            {
                return this.ramo_AtividadeRempository.GetRamo(idRamoAtividade: idRamo_atividade);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public int saveRamo_atividade(HLP.Entries.Model.Models.Gerais.Ramo_atividadeModel objRamo_atividade)
        {

            try
            {
                this.ramo_AtividadeRempository.Save(ramo: objRamo_atividade);
                return (int)objRamo_atividade.idRamoAtividade;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public bool deleteRamo_atividade(int idRamo_atividade)
        {

            try
            {
                this.ramo_AtividadeRempository.Delete(idRamoAtividade: idRamo_atividade);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public int copyRamo_atividade(int idRamo_atividade)
        {

            try
            {
                return this.ramo_AtividadeRempository.Copy(idRamoAtividade: idRamo_atividade);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }
    }
}
