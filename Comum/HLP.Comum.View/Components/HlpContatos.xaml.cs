using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HLP.Comum.ViewModel.ViewModels;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace HLP.Comum.View.Components
{
    /// <summary>
    /// Interaction logic for HlpContatos.xaml
    /// </summary>
    public partial class HlpContatos : UserControl
    {
        public HlpContatos()
        {
            InitializeComponent();

            this.viewModel = new HlpContatosViewModel();
        }

        public HlpContatosViewModel viewModel
        {
            get
            {
                return this.DataContext as HlpContatosViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
    }

    public class VisibilityToColumns
    {

        private bool _isVisible;

        public bool isVisible
        {
            get { return _isVisible; }
            set
            {
                _isVisible = value;
                NotifyPropertyChanged(propertyName: "isVisible");
            }
        }

        private string _xCampos;

        public string xCampos
        {
            get { return _xCampos; }
            set
            {
                _xCampos = value;
                NotifyPropertyChanged(propertyName: "xCampos");
            }
        }

        #region NotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }


    public class HlpContatosViewModel
    {
        public HlpContatosViewModel()
        {
            #region criação de collection Columns

            this.lColumns = new ObservableCollection<VisibilityToColumns>
            {
                new VisibilityToColumns
                {
                    isVisible = false, xCampos = "idUser"
                },
                new VisibilityToColumns
                {
                    isVisible = true, xCampos = "xNome"
                },
                new VisibilityToColumns
                {
                    isVisible = false, xCampos = "xCargo"
                },
                new VisibilityToColumns
                {
                    isVisible = false, xCampos = "xFuncao"
                },
                new VisibilityToColumns
                {
                    isVisible = false, xCampos = "xProfissao"
                },
                new VisibilityToColumns
                {
                    isVisible = false, xCampos = "Ativo"
                },
                new VisibilityToColumns
                {
                    isVisible = false, xCampos = "xTitulo"
                },
                new VisibilityToColumns
                {
                    isVisible = false, xCampos = "xApelido"
                },
                new VisibilityToColumns
                {
                    isVisible = false, xCampos = "stSexo"
                },
                new VisibilityToColumns
                {
                    isVisible = false, xCampos = "stSensibilidade"
                },
                new VisibilityToColumns
                {
                    isVisible = false, xCampos = "dDisponivelaPartir"
                },
                new VisibilityToColumns
                {
                    isVisible = false, xCampos = "dDisponivelAte"
                },   
                new VisibilityToColumns
                {
                    isVisible = false, xCampos = "stVip"
                },
                new VisibilityToColumns
                {
                    isVisible = false, xCampos = "stMalaDireta"
                },
                new VisibilityToColumns
                {
                    isVisible = false, xCampos = "xMemorando"
                },
                new VisibilityToColumns
                {
                    isVisible = true, xCampos = "xTelefoneComercial"
                },
                new VisibilityToColumns
                {
                    isVisible = false, xCampos = "xRamalComercial"
                },
                new VisibilityToColumns
                {
                    isVisible = false, xCampos = "xCelularComercial"
                },
                new VisibilityToColumns
                {
                    isVisible = false, xCampos = "xRadioFoneComercial"
                },
                new VisibilityToColumns
                {
                    isVisible = false, xCampos = "xPagerComercial"
                },
                new VisibilityToColumns
                {
                    isVisible = false, xCampos = "xFaxComercial"
                },
                new VisibilityToColumns
                {
                    isVisible = false, xCampos = "xEmailComercial"
                },
                new VisibilityToColumns
                {
                    isVisible = false, xCampos = "xSkypeComercial"
                },
                new VisibilityToColumns
                {
                    isVisible = false, xCampos = "xHttpComercial"
                },
                new VisibilityToColumns
                {
                    isVisible = false, xCampos = "xMsnComercial"
                },
                new VisibilityToColumns
                {
                    isVisible = false, xCampos = "xTelefoneResidencial"
                },
                new VisibilityToColumns
                {
                    isVisible = false, xCampos = "xCelularResidencial"
                },
                new VisibilityToColumns
                {
                    isVisible = false, xCampos = "xEmailResidencial"
                },
                new VisibilityToColumns
                {
                    isVisible = false, xCampos = "xSkypeResidencial"
                },
                new VisibilityToColumns
                {
                    isVisible = false, xCampos = "xMsnResidencial"
                },
                new VisibilityToColumns
                {
                    isVisible = false, xCampos = "xHttpPessoal"
                },
                new VisibilityToColumns
                {
                    isVisible = false, xCampos = "xRadioFoneResidencial"
                },
                new VisibilityToColumns
                {
                    isVisible = false, xCampos = "xFilhos"
                },
                new VisibilityToColumns
                {
                    isVisible = false, xCampos = "dAniversario"
                },
                new VisibilityToColumns
                {
                    isVisible = false, xCampos = "dAniversarioTempoServico"
                },
                new VisibilityToColumns
                {
                    isVisible = false, xCampos = "xConjuge"
                },
                new VisibilityToColumns
                {
                    isVisible = false, xCampos = "xHobbies"
                },
                new VisibilityToColumns
                {
                    isVisible = false, xCampos = "stEstadoCivil"
                },
                new VisibilityToColumns
                {
                    isVisible = false, xCampos = "xCPF"
                },
                new VisibilityToColumns
                {
                    isVisible = false, xCampos = "idDecisao"
                },
                new VisibilityToColumns
                {
                    isVisible = false, xCampos = "idPersonalidade"
                },
                new VisibilityToColumns
                {
                    isVisible = false, xCampos = "xDepartamento"
                },
                new VisibilityToColumns
                {
                    isVisible = false, xCampos = "idContatoGerente"
                },
                new VisibilityToColumns
                {
                    isVisible = false, xCampos = "idFuncionario"
                },
                new VisibilityToColumns
                {
                    isVisible = false, xCampos = "idFidelidade"
                }
            };
            #endregion

        }

        private ObservableCollection<VisibilityToColumns> _lColumns;

        public ObservableCollection<VisibilityToColumns> lColumns
        {
            get { return _lColumns; }
            set
            {
                _lColumns = value;
                this.NotifyPropertyChanged(propertyName: "lColumns");
            }
        }

        private ObservableCollectionBaseCadastros<ContatoModel> _lContatos;

        public ObservableCollectionBaseCadastros<ContatoModel> lContatos
        {
            get { return _lContatos; }
            set
            {
                _lContatos = value;
                this.NotifyPropertyChanged(propertyName: "lContatos");
            }
        }

        #region NotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
