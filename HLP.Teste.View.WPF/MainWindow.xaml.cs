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
using HLP.Comum.ViewModel.ViewModel;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.Services.Gerais;
using System.Collections.ObjectModel;

namespace HLP.Teste.View.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.viewModel = new MainWindowViewModel();            
        }

        public MainWindowViewModel viewModel
        {
            get
            {
                return this.DataContext as MainWindowViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
    }

    public class MainWindowViewModel : viewModelComum<Unidade_medidaModel>
    {
        Unidade_MedidaService objService;
        public MainWindowViewModel()
        {
            this.lUnidadesMedidas = new ObservableCollection<Unidade_medidaModel>();
            this.lUnidadesMedidasTk = new ObservableCollection<Unidade_medidaModel>();            

            this.objService = new Unidade_MedidaService();
        }

        private ObservableCollection<Unidade_medidaModel> _lUnidadesMedidas;

        public ObservableCollection<Unidade_medidaModel> lUnidadesMedidas
        {
            get { return _lUnidadesMedidas; }
            set
            {
                _lUnidadesMedidas = value;
                base.NotifyPropertyChanged(propertyName: "lUfs");
            }
        }


        private ObservableCollection<Unidade_medidaModel> _lUnidadesMedidasTk;

        public ObservableCollection<Unidade_medidaModel> lUnidadesMedidasTk
        {
            get { return _lUnidadesMedidasTk; }
            set
            {
                _lUnidadesMedidasTk = value;
                base.NotifyPropertyChanged(propertyName: "lUnidadesMedidasTk");
            }
        }

    }
}
