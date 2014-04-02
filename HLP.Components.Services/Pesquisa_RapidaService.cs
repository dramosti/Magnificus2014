using HLP.Base.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Components.Services
{
    public class Pesquisa_RapidaService
    {
        Wcf.Entries.wcf_PesquisaRapida serviceNetwork;
        wcf_PesquisaRapida.Iwcf_PesquisaRapidaClient serviceWeb;

        public Pesquisa_RapidaService()
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        serviceNetwork = new Wcf.Entries.wcf_PesquisaRapida();
                    }
                    break;
                case StConnection.OnlineWeb:
                    {
                        serviceWeb = new wcf_PesquisaRapida.Iwcf_PesquisaRapidaClient();
                    }
                    break;
                case StConnection.Offline:
                    break;
                default:
                    break;
            }
        }

        public string GetValorDisplay(string _TableView, string[] _Items, string _FieldPesquisa, int idEmpresa, int? _iValorPesquisa)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.serviceNetwork.GetValorDisplay(
                            _TableView: _TableView,
                            _Items: _Items,
                            _FieldPesquisa: _FieldPesquisa,
                            idEmpresa: idEmpresa,
                            _iValorPesquisa: _iValorPesquisa);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.serviceWeb.GetValorDisplay(
                            _TableView: _TableView,
                            _Items: _Items,
                            _FieldPesquisa: _FieldPesquisa,
                            idEmpresa: idEmpresa,
                            _iValorPesquisa: _iValorPesquisa);
                    }
                case StConnection.Offline:
                default:
                    {
                        return String.Empty;
                    };
            }
        }
    }
}
