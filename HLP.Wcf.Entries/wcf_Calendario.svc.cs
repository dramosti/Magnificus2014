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
using HLP.Base.EnumsBases;
using HLP.Base.ClassesBases;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceCalendario" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceCalendario.svc or serviceCalendario.svc.cs at the Solution Explorer and start debugging.
    public class wcf_Calendario : Iwcf_Calendario
    {
        [Inject]
        public ICalendarioRepository iCalendarioRepository { get; set; }
        [Inject]
        public ICalendario_DetalheRepository iCalendario_DetalheRepository { get; set; }
        [Inject]
        public ICalendario_IntervaloRepository iCalendario_IntervaloRepository { get; set; }

        public wcf_Calendario()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public HLP.Entries.Model.Models.Gerais.CalendarioModel Save(HLP.Entries.Model.Models.Gerais.CalendarioModel objModel, int idUsuario)
        {
            try
            {
                iCalendarioRepository.BeginTransaction();
                iCalendarioRepository.Save(objModel);
                foreach (var item in objModel.lCalendario_DetalheModel)
                {
                    switch (item.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            item.idCalendario = (int)objModel.idCalendario;
                            iCalendario_DetalheRepository.Save(item);
                            break;
                        case statusModel.excluido:
                            iCalendario_DetalheRepository.Delete(item);
                            break;
                    }
                }
                foreach (var item in objModel.lCalendario_IntervaloModel)
                {
                    switch (item.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            item.idCalendario = (int)objModel.idCalendario;
                            iCalendario_IntervaloRepository.Save(item);
                            break;
                        case statusModel.excluido:
                            iCalendario_IntervaloRepository.Delete(item, idUsuario);
                            break;
                    }
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

        public List<HLP.Entries.Model.Models.Gerais.Calendario_IntervalosModel> GetIntervalos(int idCalendario) 
        {
            return iCalendario_IntervaloRepository.GetIntervalos(idCalendario);
        }


        public HLP.Entries.Model.Models.Gerais.CalendarioModel GetObjeto(int idObjeto, bool bGetChild= true)
        {
            try
            {
                HLP.Entries.Model.Models.Gerais.CalendarioModel objRet = iCalendarioRepository.GetCalendario(idObjeto);
                if (objRet != null && bGetChild)
                {
                    objRet.lCalendario_DetalheModel = new ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Gerais.Calendario_DetalheModel>(iCalendario_DetalheRepository.GetAllCalendario_Detalhe(idObjeto));

                    objRet.lCalendario_IntervaloModel = new ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Gerais.Calendario_IntervalosModel>(iCalendario_IntervaloRepository.GetIntervalos(idObjeto));
                }
                return objRet;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public bool Delete(HLP.Entries.Model.Models.Gerais.CalendarioModel objModel, int idUsuario)
        {
            try
            {
                iCalendarioRepository.BeginTransaction();
                iCalendario_DetalheRepository.DeleteDetalhesByCalendario((int)objModel.idCalendario);
                iCalendario_IntervaloRepository.DeleteIntervalosByCalendario((int)objModel.idCalendario);
                iCalendarioRepository.Delete(objModel, idUsuario);
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

       
    }
}
