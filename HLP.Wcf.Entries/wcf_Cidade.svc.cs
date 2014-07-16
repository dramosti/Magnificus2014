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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_Cidade" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_Cidade.svc or wcf_Cidade.svc.cs at the Solution Explorer and start debugging.

    public class wcf_Cidade : Iwcf_Cidade
    {
        [Inject]
        public ICidadeRepository cidadeRepository { get; set; }

        public wcf_Cidade()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public List<CidadeModel> GetAllCidades()
        {
            return this.cidadeRepository.GetAllCidade();
        }

        public CidadeModel GetObject(int id)
        {
            try
            {
                return this.cidadeRepository.GetCidade(idCidade: id);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public int SaveObject(CidadeModel obj)
        {
            try
            {
                cidadeRepository.Save(cidade: obj);
                return obj.idCidade ?? 0;
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
                cidadeRepository.Delete(idCidade: id);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public int CopyObject(int id)
        {
            try
            {
                return this.cidadeRepository.Copy(idCidade: id);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public int? GetCidadeByName(string xName)
        {
            try
            {
                return cidadeRepository.GetCidadeByName(xName);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }

}
