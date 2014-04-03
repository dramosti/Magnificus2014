using HLP.Base.Static;
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
                case StConnection.OnlineNetwork:
                    {
                        this.servicoRede = new Wcf.Entries.wcf_Rota();
                    } break;
                case StConnection.OnlineWeb:
                    {
                        this.servicoInternet = new wcf_Rota.Iwcf_RotaClient();
                    } break;
            }
        }

        public RotaModel Save(RotaModel objModel)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.servicoRede.Save(objRota: objModel);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.servicoInternet.Save(objRota: objModel);
                    }
                case StConnection.Offline:
                default:
                    {
                        return null;
                    }
            }
        }

        public bool Delete(RotaModel objModel)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.servicoRede.Delete(idRota: objModel.idRota ?? 0);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.servicoInternet.Delete(idRota: objModel.idRota ?? 0);
                    }
                case StConnection.Offline:
                default:
                    {
                        return false;
                    }
            }
        }

        public RotaModel Copy(RotaModel objModel)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.servicoRede.Copy(objRota: objModel);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.servicoInternet.Copy(objRota: objModel);
                    }
                case StConnection.Offline:
                default:
                    {
                        return null;
                    }
            }
        }

        public RotaModel GetObjeto(int id)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.servicoRede.GetObject(idRota: id);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.servicoInternet.GetObject(idRota: id);
                    }
                case StConnection.Offline:
                default:
                    {
                        return null;
                    }
            }
        }

        public bool PossuiListaPreco(int id)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.servicoRede.PossuiListaPreco(idRota: id);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.servicoInternet.PossuiListaPreco(idRota: id);
                    }
                case StConnection.Offline:
                default:
                    {
                        return false;
                    }
            }
        }
    }
}
