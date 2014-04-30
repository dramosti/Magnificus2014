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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_TipoServico" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_TipoServico.svc or wcf_TipoServico.svc.cs at the Solution Explorer and start debugging.

    public class wcf_TipoServico : Iwcf_TipoServico
    {
        [Inject]
        public ITipo_servicoRepository tipo_ServicoRepository { get; set; }

        public wcf_TipoServico()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public Tipo_servicoModel GetObject(int id)
        {
            try
            {
                return this.tipo_ServicoRepository.GetTipo(idTipoServico: id);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public int SaveObject(Tipo_servicoModel obj)
        {
            try
            {
                tipo_ServicoRepository.Save(tipo: obj);
                return obj.idTipoServico ?? 0;
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
                tipo_ServicoRepository.Delete(idTipoServico: id);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public Tipo_servicoModel CopyObject(int id)
        {
            try
            {
                //IMPLEMENTAR COPY
                return this.GetObject(id:
                    this.tipo_ServicoRepository.Copy(idTipoServico: id));
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }

}
