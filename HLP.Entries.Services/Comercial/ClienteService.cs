using HLP.Base.Static;
using HLP.Entries.Model.Models.Comercial;
using HLP.Entries.Services.Transportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Services.Comercial
{
    public class ClienteService
    {
        HLP.Wcf.Entries.wcf_Cliente servicoRede;
        wcf_Cliente.Iwcf_ClienteClient servicoInternet;

        RotaService objServico;

        public ClienteService()
        {
            objServico = new RotaService();

            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        this.servicoRede = new Wcf.Entries.wcf_Cliente();
                    }
                    break;
                case StConnection.OnlineWeb:
                    {
                        this.servicoInternet = new wcf_Cliente.Iwcf_ClienteClient();
                    }
                    break;
            }
        }

        public Cliente_fornecedorModel Save(Cliente_fornecedorModel objModel)
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
            }
            return null;
        }

        public bool Delete(Cliente_fornecedorModel objModel)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.servicoRede.Delete(id: (int)objModel.idClienteFornecedor);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.servicoInternet.Delete(id: (int)objModel.idClienteFornecedor);
                    }
            }
            return false;
        }

        public Cliente_fornecedorModel Copy(Cliente_fornecedorModel objModel)
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
            }
            return null;
        }

        public Cliente_fornecedorModel GetObjeto(int id)
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
            }
            return null;
        }

        public bool RotaPossuiListaPrecoPai(int idRota)
        {
            return this.objServico.PossuiListaPreco(id: idRota);
        }
    }
}
