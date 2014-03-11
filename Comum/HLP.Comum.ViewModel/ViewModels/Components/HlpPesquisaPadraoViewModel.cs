using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HLP.Comum.Model.Components;
using HLP.Comum.Model.Models;
using HLP.Comum.Model.Repository.Interfaces.Components;
using HLP.Comum.ViewModel.Commands.Components;
using HLP.Dependencies;

namespace HLP.Comum.ViewModel.ViewModels.Components
{
    public class HlpPesquisaPadraoViewModel : modelBase
    {
        HlpPesquisaPadraoCommands objCommands;

        public ICommand commandPesquisar { get; set; }
        public ICommand commandLimpar { get; set; }
        public ICommand commandAdd { get; set; }
        private bool _bIniciaFocusFirstRow = true;

        public bool bIniciaFocusFirstRow
        {
            get { return _bIniciaFocusFirstRow; }
            set { _bIniciaFocusFirstRow = value; base.NotifyPropertyChanged("bIniciaFocusFirstRow"); }
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







    }
}
