using HLP.Comum.Infrastructure.Static;
using HLP.Comum.Model.Models;
using HLP.Comum.Resources.Models;
using HLP.Entries.Model.Models.Gerais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.ViewModel.Services.GestaoMateriais
{
    public class SiteService
    {
        HLP.Wcf.Entries.wcf_Site servicoRede;
        wcf_Site.Iwcf_SiteClient servicoInternet;

        public SiteService()
        {
            switch (Sistema.bOnline)
            {
                case TipoConexao.OnlineRede:
                    {
                        this.servicoRede = new Wcf.Entries.wcf_Site();
                    }
                    break;
                case TipoConexao.OnlineInternet:
                    {
                        this.servicoInternet = new wcf_Site.Iwcf_SiteClient();
                    }
                    break;
            }
        }

        public SiteModel Save(SiteModel objModel)
        {
            switch (Sistema.bOnline)
            {
                case TipoConexao.OnlineRede:
                    {
                        return this.servicoRede.Save(obj: objModel);
                    }
                case TipoConexao.OnlineInternet:
                    {
                        return this.servicoInternet.Save(obj: objModel);
                    }
            }
            return null;
        }

        public bool Delete(SiteModel objModel)
        {
            switch (Sistema.bOnline)
            {
                case TipoConexao.OnlineRede:
                    {
                        return this.servicoRede.Delete(id: objModel.idSite ?? 0);
                    }
                case TipoConexao.OnlineInternet:
                    {
                        return this.servicoInternet.Delete(id: objModel.idSite ?? 0);
                    }
            }
            return false;
        }

        public SiteModel Copy(SiteModel objModel)
        {
            switch (Sistema.bOnline)
            {
                case TipoConexao.OnlineRede:
                    {
                        return this.servicoRede.Copy(obj: objModel);
                    }
                case TipoConexao.OnlineInternet:
                    {
                        return this.servicoInternet.Copy(obj: objModel);
                    }
            }
            return null;
        }

        public SiteModel GetObjeto(int id)
        {
            switch (Sistema.bOnline)
            {
                case TipoConexao.OnlineRede:
                    {
                        return this.servicoRede.GetObject(id: id);
                    }
                case TipoConexao.OnlineInternet:
                    {
                        return this.servicoInternet.GetObject(id: id);
                    }
            }
            return null;
        }

        public List<modelToTreeView> GetHierarquia(int idSite)
        {
            switch (Sistema.bOnline)
            {
                case TipoConexao.OnlineRede:
                    {
                        return this.servicoRede.GetHierarquiaSite(idSite: idSite);
                    }
                case TipoConexao.OnlineInternet:
                    {                        
                        return this.servicoInternet.GetHierarquiaSite(idSite: idSite);                        
                    }
            }
            return null;
        }
    }
}
