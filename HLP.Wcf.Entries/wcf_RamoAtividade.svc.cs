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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_RamoAtividade" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_RamoAtividade.svc or wcf_RamoAtividade.svc.cs at the Solution Explorer and start debugging.

    public class wcf_RamoAtividade : Iwcf_RamoAtividade
    {
        [Inject]
        public IRamo_atividadeRepository ramo_AtividadeRepository { get; set; }

        public wcf_RamoAtividade()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public Ramo_atividadeModel GetObject(int id)
        {
            try
            {
                return this.ramo_AtividadeRepository.GetRamo(idRamoAtividade: id);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public int SaveObject(Ramo_atividadeModel obj)
        {
            try
            {
                ramo_AtividadeRepository.Save(ramo: obj);
                return obj.idRamoAtividade ?? 0;
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
                ramo_AtividadeRepository.Delete(idRamoAtividade: id);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public Ramo_atividadeModel CopyObject(int id)
        {
            try
            {
                return this.GetObject(id:
                    this.ramo_AtividadeRepository.Copy(idRamoAtividade: id));
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }

}
