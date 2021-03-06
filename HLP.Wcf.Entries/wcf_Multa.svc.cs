﻿using HLP.Base.Static;
using HLP.Dependencies;
using HLP.Entries.Model.Models.Comercial;
using HLP.Entries.Model.Repository.Interfaces.Comercial;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_Multa" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_Multa.svc or wcf_Multa.svc.cs at the Solution Explorer and start debugging.
    public class wcf_Multa : Iwcf_Multa
    {
        [Inject]
        public IMultasRepository multasRepository { get; set; }

        public wcf_Multa()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public MultasModel GetObject(int id)
        {
            try
            {
                //IMPLEMENTAR GET
                return this.multasRepository.GetMulta(idMultas: id);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public int SaveObject(MultasModel obj)
        {
            try
            {
                //IMPLEMENTAR SAVE
                multasRepository.Save(multa: obj);
                return obj.idMultas ?? 0;
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
                //IMPLEMENTAR DELETE
                multasRepository.Delete(idMultas: id);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public MultasModel CopyObject(int id)
        {
            try
            {
                //IMPLEMENTAR COPY
                return this.GetObject(id:
                    this.multasRepository.Copy(idMultas: id));
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }

}
