using HLP.Base.ClassesBases;
using HLP.Base.EnumsBases;
using HLP.Components.Model.Models;
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_Site" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_Site.svc or wcf_Site.svc.cs at the Solution Explorer and start debugging.
    public class wcf_Site : Iwcf_Site
    {
        [Inject]
        public ISiteRepository siteRepository { get; set; }

        [Inject]
        public ISite_enderecoRepository site_enderecoRepository { get; set; }

        [Inject]
        public IDepositoRepository depositoRepository { get; set; }

        public wcf_Site()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public HLP.Entries.Model.Models.Gerais.SiteModel GetObject(int id)
        {

            try
            {
                HLP.Entries.Model.Models.Gerais.SiteModel objSite = this.siteRepository.GetSite(idSite: id);
                objSite.lSite_Endereco = new ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Gerais.Site_enderecoModel>
                (list: this.site_enderecoRepository.GetAllSite_Endereco(idSite: id));
                return objSite;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public HLP.Entries.Model.Models.Gerais.SiteModel Save(HLP.Entries.Model.Models.Gerais.SiteModel obj)
        {

            try
            {
                this.siteRepository.BeginTransaction();
                this.siteRepository.Save(objSite: obj);
                foreach (HLP.Entries.Model.Models.Gerais.Site_enderecoModel item in obj.lSite_Endereco)
                {
                    switch (item.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            {
                                item.idSite = (int)obj.idSite;
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
                return obj;
            }
            catch (Exception ex)
            {
                this.siteRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public bool Delete(int id)
        {
            try
            {
                this.siteRepository.BeginTransaction();
                this.site_enderecoRepository.DeletePorSite(idSite: id);
                this.siteRepository.Delete(idSite: id);
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

        public HLP.Entries.Model.Models.Gerais.SiteModel Copy(HLP.Entries.Model.Models.Gerais.SiteModel obj)
        {
            try
            {
                this.siteRepository.BeginTransaction();
                this.siteRepository.Copy(objSite: obj);
                foreach (HLP.Entries.Model.Models.Gerais.Site_enderecoModel item in obj.lSite_Endereco)
                {
                    item.idSite = (int)obj.idSite;
                    this.site_enderecoRepository.Copy(objSite_Endereco: item);
                }
                this.siteRepository.CommitTransaction();
                return obj;
            }
            catch (Exception ex)
            {
                this.siteRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public modelToTreeView GetHierarquiaSite(int idSite)
        {
            try
            {
                modelToTreeView TreeView = new modelToTreeView();
                HLP.Entries.Model.Models.Gerais.SiteModel objSite = this.siteRepository.GetSite(idSite: idSite);

                TreeView.id = objSite.idSite ?? 0;
                TreeView.xDisplay = objSite.xSite + " - " + objSite.xDescricao;
                TreeView.lFilhos = new List<modelToTreeView>();

                foreach (var item in this.depositoRepository.GetBySite(idSite: idSite))
                {
                    TreeView.lFilhos.Add(
                        item: new modelToTreeView
                        {
                            id = item.idDeposito ?? 0,
                            xDisplay = item.xDeposito + " - " + item.xDescricao
                        });
                }
                return TreeView;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
