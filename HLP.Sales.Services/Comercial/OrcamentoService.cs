using HLP.Base.ClassesBases;
using HLP.Base.Static;
using HLP.Sales.Model.Models.Comercial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Sales.Services.Comercial
{
    public class OrcamentoService
    {
        const string xTabela = "Orcamento_ide;Orcamento_retTransp;Orcamento_Total_Impostos;";
        HLP.Wcf.Entries.wcf_CamposBaseDados serviceCamposBaseDadosNetwork;
        wcf_CamposBaseDados.Iwcf_CamposBaseDadosClient serviceCamposBaseDadosWeb;


        Wcf.Sales.wcf_Orcamento servicoRede;
        wcf_Orcamento.Iwcf_OrcamentoClient servicoInternet;

        public OrcamentoService()
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
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
                        this.servicoRede = new Wcf.Sales.wcf_Orcamento();
                    }
                    break;
                case StConnection.OnlineWeb:
                    {
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

                        this.servicoInternet = new wcf_Orcamento.Iwcf_OrcamentoClient();
                    }
                    break;
            }
        }

        public Orcamento_ideModel Save(Orcamento_ideModel objModel)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.servicoRede.Save(objModel: objModel);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.servicoInternet.Save(objModel: objModel);
                    }
            }
            return null;
        }

        public bool Delete(Orcamento_ideModel objModel)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.servicoRede.Delete(objModel: objModel);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.servicoInternet.Delete(objModel: objModel);
                    }
            }
            return false;
        }

        public Orcamento_ideModel Copy(Orcamento_ideModel objModel)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.servicoRede.Copy(objModel: objModel);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.servicoInternet.Copy(objModel: objModel);
                    }
            }
            return null;
        }

        public Orcamento_ideModel GetObjeto(int id)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.servicoRede.GetObjeto(idObjeto: id, idEmpresa: CompanyData.idEmpresa);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.servicoInternet.GetObjeto(idObjeto: id, idEmpresa: CompanyData.idEmpresa);
                    }
            }
            return null;
        }

        public Orcamento_ideModel GerarVersao(Orcamento_ideModel objModel)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.servicoRede.GerarVersao(objModel: objModel);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.servicoInternet.GerarVersao(objModel: objModel);
                    }
            }
            return null;
        }

        public List<int> GetIdVersoes(int idOrcamento)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.servicoRede.GetListaVersoes(idOrcamento: idOrcamento);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.servicoInternet.GetListaVersoes(idOrcamento: idOrcamento);
                    }
            }
            return null;
        }

        public bool PossuiFilho(int idOrcamento)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.servicoRede.PossuiFilho(idOrcamento: idOrcamento);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.servicoInternet.PossuiFilho(idOrcamento: idOrcamento);
                    }
            }
            return false;
        }
    }

}
