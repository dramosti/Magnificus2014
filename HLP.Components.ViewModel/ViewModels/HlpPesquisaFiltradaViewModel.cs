using HLP.Base.ClassesBases;
using HLP.Components.Model.Models;
using HLP.Components.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HLP.Components.ViewModel.ViewModels
{
    public class HlpPesquisaFiltradaViewModel : ViewModelBase<PesquisaPadraoModel>
    {
        public ICommand filtrarCommand { get; set; }

        public HlpPesquisaFiltradaViewModel()
        {
            this.lFiltros = new ObservableCollection<PesquisaPadraoModel>();
            HlpPesquisaFiltradaCommands comm = new HlpPesquisaFiltradaCommands(objViewModel: this);
        }

        private List<string> _lCampos;

        public List<string> lCampos
        {
            get { return _lCampos; }
            set
            {
                _lCampos = value;
                base.NotifyPropertyChanged(propertyName: "lCampos");
            }
        }

        private string _campoSelecionado;

        public string campoSelecionado
        {
            get { return _campoSelecionado; }
            set { _campoSelecionado = value; }
        }


        private int _stOrdenacao;

        public int stOrdenacao
        {
            get { return _stOrdenacao; }
            set
            {
                _stOrdenacao = value;
                base.NotifyPropertyChanged(propertyName: "stOrdenacao");
            }
        }


        private ObservableCollection<PesquisaPadraoModel> _lFiltros;

        public ObservableCollection<PesquisaPadraoModel> lFiltros
        {
            get { return _lFiltros; }
            set
            {
                _lFiltros = value;

                if (value != null)
                {
                    this.lCampos = new List<string>();
                    foreach (PesquisaPadraoModel item in value)
                    {
                        this.lCampos.Add(item: item.COLUMN_NAME);
                    }
                }

                base.NotifyPropertyChanged(propertyName: "lFiltros");
            }
        }

    }
}
