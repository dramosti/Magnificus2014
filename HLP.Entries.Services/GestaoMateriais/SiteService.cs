using HLP.Base.Static;
using HLP.Components.Model.Models;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.Services.Gerais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Services.GestaoMateriais
{
    public class SiteService
    {
        HLP.Wcf.Entries.wcf_Site servicoRede;
        wcf_Site.Iwcf_SiteClient servicoInternet;
        DepositoService objServiceDeposito;


        public SiteService()
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        this.servicoRede = new Wcf.Entries.wcf_Site();
                    }
                    break;
                case StConnection.OnlineWeb:
                    {
                        this.servicoInternet = new wcf_Site.Iwcf_SiteClient();
                    }
                    break;
            }

            objServiceDeposito = new DepositoService();
        }

        public SiteModel Save(SiteModel objModel)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.servicoRede.Save(obj: objModel);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.servicoInternet.Save(obj: objModel);
                    }
                case StConnection.Offline:
                default:
                    {
                        return null;
                    }
            }
        }

        public bool Delete(SiteModel objModel)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.servicoRede.Delete(id: objModel.idSite ?? 0);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.servicoInternet.Delete(id: objModel.idSite ?? 0);
                    }
                case StConnection.Offline:
                default:
                    {
                        return false;
                    }
            }
        }

        public SiteModel Copy(SiteModel objModel)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.servicoRede.Copy(obj: objModel);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.servicoInternet.Copy(obj: objModel);
                    }
                case StConnection.Offline:
                default:
                    {
                        return null;
                    }
            }
        }

        public SiteModel GetObjeto(int id)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.servicoRede.GetObject(id: id);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.servicoInternet.GetObject(id: id);
                    }
                case StConnection.Offline:
                default:
                    {
                        return null;
                    }
            }
        }

        public modelToTreeView GetHierarquia(int idSite)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.servicoRede.GetHierarquiaSite(idSite: idSite);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.servicoInternet.GetHierarquiaSite(idSite: idSite);
                    }
                case StConnection.Offline:
                default:
                    {
                        return null;
                    }
            }
        }
    }
}
