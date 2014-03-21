﻿using HLP.Comum.Infrastructure.Static;
using HLP.Entries.Model.Models.Comercial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.ViewModel.Services.Comercial
{
    public class ClienteService
    {
        HLP.Wcf.Entries.wcf_Cliente servicoRede;
        wcf_Cliente.Iwcf_ClienteClient servicoInternet;

        public ClienteService()
        {
            switch (Sistema.bOnline)
            {
                case TipoConexao.OnlineRede:
                    {
                        this.servicoRede = new Wcf.Entries.wcf_Cliente();
                    }
                    break;
                case TipoConexao.OnlineInternet:
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

        public bool Delete(Cliente_fornecedorModel objModel)
        {
            switch (Sistema.bOnline)
            {
                case TipoConexao.OnlineRede:
                    {
                        return this.servicoRede.Delete(id: (int)objModel.idClienteFornecedor);
                    }
                case TipoConexao.OnlineInternet:
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

        public Cliente_fornecedorModel GetObjeto(int id)
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
    }
}