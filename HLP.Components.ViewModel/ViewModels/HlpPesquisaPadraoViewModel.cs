﻿using HLP.Base.ClassesBases;
using HLP.Components.Model.Models;
using HLP.Components.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HLP.Components.ViewModel.ViewModels
{
    public class HlpPesquisaPadraoViewModel : modelBase
    {
        HlpPesquisaPadraoCommands objCommands;

        public ICommand commandPesquisar { get; set; }
        public ICommand commandLimpar { get; set; }
        public ICommand commandAdd { get; set; }
        public ICommand commandPesquisaFiltrada { get; set; }

        private bool _bIniciaFocusFirstRow = true;

        public bool bIniciaFocusFirstRow
        {
            get { return _bIniciaFocusFirstRow; }
            set { _bIniciaFocusFirstRow = value; base.NotifyPropertyChanged("bIniciaFocusFirstRow"); }
        }

        private List<PesquisaPadraoModel> _lFiltroAtivo;

        public List<PesquisaPadraoModel> lFiltroAtivo
        {
            get { return _lFiltroAtivo; }
            set { _lFiltroAtivo = value; }
        }

        private ObservableCollection<PesquisaPadraoModel> _lFilers;

        public ObservableCollection<PesquisaPadraoModel> lFilers
        {
            get { return _lFilers; }
            set
            {
                _lFilers = value;
                base.NotifyPropertyChanged("lFilers");
            }
        }

        private DataTable _Result;

        public DataTable Result
        {
            get { return _Result; }
            set
            {
                _Result = value; base.NotifyPropertyChanged("Result");
                if (_Result != null)
                    this.sTotalRegistro = _Result.Rows.Count.ToString();
            }
        }

        private string _sTotalRegistro = "0 Registro(s)";

        public string sTotalRegistro
        {
            get { return _sTotalRegistro; }
            set { _sTotalRegistro = string.Format("{0} Registro(s)", value); base.NotifyPropertyChanged("sTotalRegistro"); }
        }

        private string _sView = string.Empty;
        public string sView
        {

            get { return _sView; }
            set { _sView = value; }
        }

        public HlpPesquisaPadraoViewModel(string sView)
        {
            this.sView = sView;
            objCommands = new HlpPesquisaPadraoCommands(objViewModel: this);
        }

        private List<PesquisaPadraoModel> _lFiltros;

        public List<PesquisaPadraoModel> lFiltros
        {
            get { return _lFiltros; }
            set { _lFiltros = value; }
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

    }

}
