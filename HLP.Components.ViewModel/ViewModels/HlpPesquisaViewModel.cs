using HLP.Components.Services;
using HLP.Components.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HLP.Components.ViewModel.ViewModels
{
    public class HlpPesquisaViewModel
    {
        private ICommand PesquisarCommand { get; set; }
        private ICommand InserirCommand { get; set; }

        private HlpPesquisaCommands comm;
        Pesquisa_RapidaService objService;

        public HlpPesquisaViewModel()
        {
            this.comm = new HlpPesquisaCommands(objViewModel: this);
            objService = new Pesquisa_RapidaService();
        }

        public string GetValorDisplay(string _TableView, string[] _Items, string _FieldPesquisa, int idEmpresa, int? _iValorPesquisa)
        {
            return objService.GetValorDisplay(
                _TableView: _TableView,
                _Items: _Items,
                _FieldPesquisa: _FieldPesquisa,
                idEmpresa: idEmpresa,
                _iValorPesquisa: _iValorPesquisa);
        }
    }
}
