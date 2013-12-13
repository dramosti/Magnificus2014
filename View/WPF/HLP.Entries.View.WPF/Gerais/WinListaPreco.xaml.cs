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
using HLP.Comum.View.Formularios;
using HLP.Entries.ViewModel.ViewModels.Comercial;
using HLP.Entries.ViewModel.ViewModels.Gerais;
using System.Collections;

namespace HLP.Entries.View.WPF.Gerais
{
    /// <summary>
    /// Interaction logic for WinListaPreco.xaml
    /// </summary>
    public partial class WinListaPreco : WindowsBase
    {
        public WinListaPreco()
        {
            InitializeComponent();
            this.ViewModel = new Lista_PrecoViewModel();
        }

        public Lista_PrecoViewModel ViewModel
        {
            get
            {
                return this.DataContext as Lista_PrecoViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

        private void btnAtribuicaoColetiva_Click(object sender, RoutedEventArgs e)
        {
            WinAtribuicaoColetivaListaPreco winAtrib = new WinAtribuicaoColetivaListaPreco();
            this.ViewModel.AtribuicaoColetivaCommand.Execute(parameter: winAtrib);
        }
    }
}
