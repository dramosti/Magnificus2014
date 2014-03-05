using HLP.Comum.Infrastructure.Static;
using HLP.Sales.Model.Models.Comercial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Sales.ViewModel.Services
{
    public class OrcamentoService
    {
        Wcf.Sales.wcf_Orcamento servicoRede;
        wcf_Orcamento.Iwcf_OrcamentoClient servicoInternet;

        public OrcamentoService()
        {
            switch (Sistema.bOnline)
            {
                case TipoConexao.OnlineRede:
                    {
                        this.servicoRede = new Wcf.Sales.wcf_Orcamento();
                    }
                    break;
                case TipoConexao.OnlineInternet:
                    {
                        this.servicoInternet = new wcf_Orcamento.Iwcf_OrcamentoClient();
                    }
                    break;
            }
        }

        public Orcamento_ideModel Save(Orcamento_ideModel objModel)
        {
            switch (Sistema.bOnline)
            {
                case TipoConexao.OnlineRede:
                    {
                        return this.servicoRede.Save(objModel: objModel);
                    }
                case TipoConexao.OnlineInternet:
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
                case TipoConexao.OnlineRede:
                    {
                        return this.servicoRede.Delete(objModel: objModel);
                    }
                case TipoConexao.OnlineInternet:
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
                case TipoConexao.OnlineRede:
                    {
                        return this.servicoRede.Copy(objModel: objModel);
                    }
                case TipoConexao.OnlineInternet:
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
                case TipoConexao.OnlineRede:
                    {
                        return this.servicoRede.GetObjeto(idObjeto: id, idEmpresa: CompanyData.idEmpresa);
                    }
                case TipoConexao.OnlineInternet:
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
                case TipoConexao.OnlineRede:
                    {
                        return this.servicoRede.GerarVersao(objModel: objModel);
                    }
                case TipoConexao.OnlineInternet:
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
                case TipoConexao.OnlineRede:
                    {
                        return this.servicoRede.GetListaVersoes(idOrcamento: idOrcamento);
                    }
                case TipoConexao.OnlineInternet:
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
                case TipoConexao.OnlineRede:
                    {
                        return this.servicoRede.PossuiFilho(idOrcamento: idOrcamento);
                    }
                case TipoConexao.OnlineInternet:
                    {
                        return this.servicoInternet.PossuiFilho(idOrcamento: idOrcamento);
                    }
            }
            return false;
        }
    }
}
