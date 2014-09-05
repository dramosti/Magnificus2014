using HLP.Base.ClassesBases;
using HLP.Base.Static;
using HLP.Entries.Model.Models.Comercial;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.Services.Financeiro;
using HLP.Entries.Services.Gerais;
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
        DepositoService objDepositoService;
        RotaService objServico;
        const string xTabela = "Cliente_fornecedor;Contato;Cliente_Fornecedor_Alteracoes;Cliente_Fornecedor_Arquivo;Cliente_Fornecedor_Certificado;Enderecos;Cliente_fornecedor_fiscal;Cliente_Fornecedor_Observacao;Cliente_fornecedor_produto;Cliente_fornecedor_representante";
        HLP.Wcf.Entries.wcf_CamposBaseDados serviceCamposBaseDadosNetwork;
        wcf_CamposBaseDados.Iwcf_CamposBaseDadosClient serviceCamposBaseDadosWeb;

        public ClienteService()
        {
            objServico = new RotaService();
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        this.servicoRede = new Wcf.Entries.wcf_Cliente();
                        this.serviceCamposBaseDadosNetwork = new Wcf.Entries.wcf_CamposBaseDados();
                        #region Validação

                        foreach (string str in xTabela.Split(';').ToArray())
                        {
                            if (lCamposSqlNotNull._lCamposSql.Count(i => i.xTabela == str) == 0)
                            {
                                CamposSqlNotNullModel lCampos = new CamposSqlNotNullModel();
                                lCampos.xTabela = str;
                                lCampos.lCamposSqlModel = serviceCamposBaseDadosNetwork.getCamposNotNull(
                                    xTabela: str);
                                lCamposSqlNotNull.AddCampoSql(objCamposSqlNotNull: lCampos);
                            }
                        }

                        #endregion

                    }
                    break;
                case StConnection.OnlineWeb:
                    {
                        this.servicoInternet = new wcf_Cliente.Iwcf_ClienteClient();
                        this.serviceCamposBaseDadosWeb = new wcf_CamposBaseDados.Iwcf_CamposBaseDadosClient();
                        #region Validação

                        foreach (string str in xTabela.Split(';').ToArray())
                        {
                            if (lCamposSqlNotNull._lCamposSql.Count(i => i.xTabela == str) == 0)
                            {
                                CamposSqlNotNullModel lCampos = new CamposSqlNotNullModel();
                                lCampos.xTabela = str;
                                lCampos.lCamposSqlModel = serviceCamposBaseDadosWeb.getCamposNotNull(
                                    xTabela: str);
                                lCamposSqlNotNull.AddCampoSql(objCamposSqlNotNull: lCampos);
                            }
                        }

                        #endregion

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

        public Cliente_fornecedorModel GetObjeto(int id, bool loadOptionalParameters = false)
        {
            Cliente_fornecedorModel objCliente = null;
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        objCliente = this.servicoRede.GetObject(id: id);
                    }; break;
                case StConnection.OnlineWeb:
                    {
                        objCliente = this.servicoInternet.GetObject(id: id);
                    }; break;
            }

            if (loadOptionalParameters)
            {
                this.SetListaPrecoCliente(objClienteFornecedor: objCliente);
                this.SetDescontoCliente(objClienteFornecedor: objCliente);
            }
            return objCliente;
        }

        private void SetListaPrecoCliente(Cliente_fornecedorModel objClienteFornecedor)
        {
            Lista_PrecoService objListaPrecoService = new Lista_PrecoService();

            if (objClienteFornecedor != null)
                objClienteFornecedor.objListaPrecoPai = objListaPrecoService.GetObjeto(
                    id: objClienteFornecedor.idListaPrecoPai);

        }

        private void SetDescontoCliente(Cliente_fornecedorModel objClienteFornecedor)
        {
            Descontos_AvistaService objService = new Descontos_AvistaService();

            if (objClienteFornecedor != null)
                objClienteFornecedor.objDesconto = objService.GetObject(id: objClienteFornecedor.idDescontos ?? 0);
        }

        public int GetIdSiteByDeposito(int idDeposito)
        {
            objDepositoService = new DepositoService();

            DepositoModel objDeposito = objDepositoService.GetObject(id: idDeposito);

            if (objDeposito != null)
                return objDeposito.idSite;

            return 0;
        }

        public bool RotaPossuiListaPrecoPai(int idRota)
        {
            return this.objServico.PossuiListaPreco(id: idRota);
        }
    }
}
