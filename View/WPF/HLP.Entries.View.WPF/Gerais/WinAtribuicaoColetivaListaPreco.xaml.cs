using HLP.Entries.ViewModel.ViewModels.Gerais;
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
using System.Windows.Shapes;

namespace HLP.Entries.View.WPF.Gerais
{
    /// <summary>
    /// Interaction logic for WinAtribuicaoColetivaListaPreco.xaml
    /// </summary>
    public partial class WinAtribuicaoColetivaListaPreco : Window
    {
        public WinAtribuicaoColetivaListaPreco()
        {
            InitializeComponent();
            this.ViewModel = new AtribuicaoColetivaListaPrecoViewModel();
        }

        public AtribuicaoColetivaListaPrecoViewModel ViewModel
        {
            get
            {
                return this.DataContext as AtribuicaoColetivaListaPrecoViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
    }
}
