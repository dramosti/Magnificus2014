using HLP.Base.ClassesBases;
using HLP.Base.EnumsBases;
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceSite" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceSite.svc or serviceSite.svc.cs at the Solution Explorer and start debugging.
    public class serviceSite : IserviceSite
    {
        [Inject]
        public ISiteRepository siteRepository { get; set; }

        [Inject]
        public ISite_enderecoRepository site_enderecoRepository { get; set; }
        
        public serviceSite()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public HLP.Entries.Model.Models.Gerais.SiteModel getSite(int idSite)
        {

            try
            {
                HLP.Entries.Model.Models.Gerais.SiteModel objSite = this.siteRepository.GetSite(idSite: idSite);
                objSite.lSite_Endereco = new ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Gerais.Site_enderecoModel>
                (list: this.site_enderecoRepository.GetAllSite_Endereco(idSite: idSite));

                return objSite;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public HLP.Entries.Model.Models.Gerais.SiteModel saveSite(HLP.Entries.Model.Models.Gerais.SiteModel objSite)
        {

            try
            {
                this.siteRepository.BeginTransaction();
                this.siteRepository.Save(objSite: objSite);
                foreach (HLP.Entries.Model.Models.Gerais.Site_enderecoModel item in objSite.lSite_Endereco)
                {
                    switch (item.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            {
                                item.idSite = (int)objSite.idSite;
                                this.site_enderecoRepository.Save(objSite_Endereco: item);
                            }
                            break;
                        case statusModel.excluido:
                            {
                                this.site_enderecoRepository.Delete((int)item.idEndereco);
                            }
                            break;
                    }
                }
                this.siteRepository.CommitTransaction();
                return objSite;
            }
            catch (Exception ex)
            {
                this.siteRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public bool deleteSite(int idSite)
        {
            try
            {
                this.siteRepository.BeginTransaction();
                this.site_enderecoRepository.DeletePorSite(idSite: idSite);
                this.siteRepository.Delete(idSite: idSite);
                this.siteRepository.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
                this.siteRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public int copySite(HLP.Entries.Model.Models.Gerais.SiteModel objSite)
        {
            try
            {
                this.siteRepository.BeginTransaction();
                this.siteRepository.Copy(objSite: objSite);
                foreach (HLP.Entries.Model.Models.Gerais.Site_enderecoModel item in objSite.lSite_Endereco)
                {
                    item.idSite = (int)objSite.idSite;
                    this.site_enderecoRepository.Copy(objSite_Endereco: item);
                }
                this.siteRepository.CommitTransaction();
                return (int)objSite.idSite;
            }
            catch (Exception ex)
            {
                this.siteRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }        
    }
}
