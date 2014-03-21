using HLP.Comum.Infrastructure.Static;
using HLP.Entries.Model.Models.Transportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.ViewModel.Services.Transportes
{
    public class RotaService
    {
        HLP.Wcf.Entries.wcf_Rota servicoRede;
        wcf_Rota.Iwcf_RotaClient servicoInternet;
        public RotaService()
        {
            switch (Sistema.bOnline)
            {
                case TipoConexao.OnlineRede:
                    {
                        this.servicoRede = new Wcf.Entries.wcf_Rota();
                    }
                    break;
                case TipoConexao.OnlineInternet:
                    {
                        this.servicoInternet = new wcf_Rota.Iwcf_RotaClient();
                    }
                    break;
            }
        }

        public RotaModel Save(RotaModel objModel)
        {
            switch (Sistema.bOnline)
            {
                case TipoConexao.OnlineRede:
                    {
                        return this.servicoRede.Save(objRota: objModel);
                    }
                case TipoConexao.OnlineInternet:
                    {
                        return this.servicoInternet.Save(objRota: objModel);
                    }
            }
            return null;
        }

        public bool Delete(RotaModel objModel)
        {
            switch (Sistema.bOnline)
            {
                case TipoConexao.OnlineRede:
                    {
                        return this.servicoRede.Delete(idRota: objModel.idRota ?? 0);
                    }
                case TipoConexao.OnlineInternet:
                    {
                        return this.servicoInternet.Delete(idRota: objModel.idRota ?? 0);
                    }
            }
            return false;
        }

        public RotaModel Copy(RotaModel objModel)
        {
            switch (Sistema.bOnline)
            {
                case TipoConexao.OnlineRede:
                    {
                        return this.servicoRede.Copy(objRota: objModel);
                    }
                case TipoConexao.OnlineInternet:
                    {
                        return this.servicoInternet.Copy(objRota: objModel);
                    }
            }
            return null;
        }

        public RotaModel GetObjeto(int id)
        {
            switch (Sistema.bOnline)
            {
                case TipoConexao.OnlineRede:
                    {
                        return this.servicoRede.GetObject(idRota: id);
                    }
                case TipoConexao.OnlineInternet:
                    {
                        return this.servicoInternet.GetObject(idRota: id);
                    }
            }
            return null;
        }

        //public bool PossuiListaPreco(int id)
        //{
        //    switch (Sistema.bOnline)
        //    {
        //        case TipoConexao.OnlineRede:
        //            {
        //                return this.servicoRede.GetObject(idRota: id);
        //            }
        //        case TipoConexao.OnlineInternet:
        //            {
        //                return this.servicoInternet.GetObject(idRota: id);
        //            }
        //    }
        //    return false;
        //}
    }
}
