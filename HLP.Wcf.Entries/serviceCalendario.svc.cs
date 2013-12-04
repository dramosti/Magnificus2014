using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HLP.Comum.Resources.Util;
using HLP.Dependencies;
using HLP.Entries.Model.Repository.Interfaces.Gerais;
using Ninject;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceCalendario" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceCalendario.svc or serviceCalendario.svc.cs at the Solution Explorer and start debugging.
    public class serviceCalendario : IserviceCalendario
    {
        [Inject]
        public ICalendarioRepository iCalendarioRepository { get; set; }
        [Inject]
        public ICalendario_DetalheRepository iCalendario_DetalheRepository { get; set; }

        public serviceCalendario()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public HLP.Entries.Model.Models.Gerais.CalendarioModel Save(HLP.Entries.Model.Models.Gerais.CalendarioModel objModel)
        {
            try
            {
                iCalendarioRepository.BeginTransaction();
                iCalendarioRepository.Save(objModel);
                foreach (var item in objModel.lCalendario_DetalheModel)
                {
                    switch (item.status)
                    {
                        case HLP.Comum.Resources.RecursosBases.statusModel.criado:
                        case HLP.Comum.Resources.RecursosBases.statusModel.alterado:
                            iCalendario_DetalheRepository.Save(item);
                            break;
                        case HLP.Comum.Resources.RecursosBases.statusModel.excluido:
                            iCalendario_DetalheRepository.Delete(item);
                            break;
                    }
                }
                iCalendarioRepository.CommitTransaction();
                return objModel;
            }
            catch (Exception ex)
            {
                iCalendarioRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public HLP.Entries.Model.Models.Gerais.CalendarioModel GetObjeto(int idObjeto)
        {
            try
            {
                HLP.Entries.Model.Models.Gerais.CalendarioModel objRet = iCalendarioRepository.GetCalendario(idObjeto);
                if (objRet != null)
                {
                    objRet.lCalendario_DetalheModel = new Comum.Model.Models.ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Gerais.Calendario_DetalheModel>(iCalendario_DetalheRepository.GetAllCalendario_Detalhe(idObjeto));
                }
                return objRet;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public bool Delete(HLP.Entries.Model.Models.Gerais.CalendarioModel objModel)
        {
            try
            {
                iCalendarioRepository.BeginTransaction();
                iCalendario_DetalheRepository.DeleteDetalhesByCalendario((int)objModel.idCalendario);
                iCalendarioRepository.Delete(objModel);
                iCalendarioRepository.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
                iCalendarioRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public HLP.Entries.Model.Models.Gerais.CalendarioModel Copy(HLP.Entries.Model.Models.Gerais.CalendarioModel objModel)
        {
            try
            {
                iCalendarioRepository.BeginTransaction();
                iCalendarioRepository.Copy(objModel);
                foreach (var item in objModel.lCalendario_DetalheModel)
                {
                    item.idCalendario = (int)objModel.idCalendario;
                    iCalendario_DetalheRepository.Copy(item);                    
                }
                iCalendarioRepository.CommitTransaction();

                return this.GetObjeto((int)objModel.idCalendario);

            }
            catch (Exception ex)
            {
                iCalendarioRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }
}
