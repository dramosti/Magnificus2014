using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.ViewModel.Commands.Gerais;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HLP.Entries.ViewModel.ViewModels.Gerais
{
    public class HlpCalendarioPontoViewModel : INotifyPropertyChanged
    {
        public HlpCalendarioPontoCommand command;
        public ICommand LancamentoManualCommand { get; set; }
        public Action actionAtualizaWindowPrincipal;
        ResourceDictionary resource;

        public HlpCalendarioPontoViewModel()
        {
            command = new HlpCalendarioPontoCommand(this);
            resource = new ResourceDictionary
                    {
                        Source = new Uri("/HLP.Comum.Resources;component/Styles/Components/ComponentsStyles.xaml", UriKind.RelativeOrAbsolute)
                    };
        }

        private ObservableCollection<EspelhoPontoModel> _lPonto = new ObservableCollection<EspelhoPontoModel>();
        public ObservableCollection<EspelhoPontoModel> lPonto
        {
            get { return _lPonto; }
            set
            {
                _lPonto = value;
                this.NotifyPropertyChanged("lPonto");
                if (value != null)
                {
                    this.hTotal = new TimeSpan();
                    foreach (var item in value)
                    {
                        this.hTotal = this.hTotal.Add(item.tTotal);
                    }
                }


            }
        }

        private TimeSpan _hTotal = new TimeSpan();
        public TimeSpan hTotal
        {
            get { return _hTotal; }
            set { _hTotal = value; this.NotifyPropertyChanged("hTotal"); }
        }

        private int _idFuncionario;
        public int idFuncionario
        {
            get { return _idFuncionario; }
            set { _idFuncionario = value; this.NotifyPropertyChanged("idFuncionario"); }
        }

        private string _dataPonto;
        public string dataPonto
        {
            get { return _dataPonto; }
            set
            {
                _dataPonto = value;
                this.NotifyPropertyChanged("dataPonto");
                if (value != "")
                    iDia = Convert.ToDateTime(value).Day.ToString().PadLeft(2, '0');
            }
        }

        private string _iDia;
        public string iDia
        {
            get { return _iDia; }
            set { _iDia = value; this.NotifyPropertyChanged("iDia"); }
        }

        public bool _bMesFechado = false;

        public bool _bFalta = false;

        #region NotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion


        private StatusDia _stDia;

        public StatusDia stDia
        {
            get { return _stDia; }
            set
            {
                if (value == StatusDia.EMBRANCO)
                {
                    this.styleDia = resource["EllipsePreta"] as Style;
                }
                else if (value == StatusDia.FALTOU)
                {
                    this.styleDia = resource["EllipseVermelha"] as Style;
                }
                else if (value== StatusDia.ABONO)
                {
                    this.styleDia = resource["EllipseAzul"] as Style;
                }
                else if (value== StatusDia.ABONO)
                {
                    this.styleDia = resource["EllipseVerde"] as Style;
                }
                else if (value == StatusDia.NORMAL)
                {
                    this.styleDia = resource["EllipseVerde"] as Style;
                }
                else if (value == StatusDia.DSR)
                {
                    this.styleDia = resource["EllipseVerde"] as Style;
                }
                _stDia = value;
            }
        }

        private Style _styleDia;
        public Style styleDia
        {
            get { return _styleDia; }
            set
            {
                _styleDia = value;
                this.NotifyPropertyChanged(propertyName: "styleDia");
            }
        }

        private Style _styleDSF;
        public Style styleDSF
        {
            get { return _styleDSF; }
            set
            {
                _styleDSF = value; this.NotifyPropertyChanged(propertyName: "styleDSF");
            }
        }


        private bool _isDSR;

        public bool isDSR
        {
            get { return _isDSR; }
            set
            {
                _isDSR = value;
                this.styleDSF = resource["EllipseVerde"] as Style;
            }

        }




        public enum StatusDia { NORMAL, FALTOU, ABONO, EMBRANCO, DSR };
    }
}
