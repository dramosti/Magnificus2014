using HLP.Components.View.WPF;
using HLP.Sales.ViewModel.ViewModel.Comercio;
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

namespace HLP.Sales.View.WPF.GestãoAdministrativa.Comercial
{
    /// <summary>
    /// Interaction logic for WinOrcamento.xaml
    /// </summary>
    public partial class WinOrcamento : WindowsBase
    {
        public WinOrcamento()
        {
            InitializeComponent();
            this.ViewModel = new OrcamentoViewModel();
            this.tcPrincipal.KeyUp += base.TabControl_KeyUp;
        }

        public OrcamentoViewModel ViewModel
        {
            get
            {
                return this.DataContext as OrcamentoViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

        private void TabItem_GotFocus(object sender, RoutedEventArgs e)
        {
            this.ViewModel.GenerateItensComissoes();
        }
    }
}
