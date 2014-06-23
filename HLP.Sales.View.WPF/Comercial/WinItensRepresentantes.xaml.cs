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

namespace HLP.Sales.View.WPF.Comercial
{
    /// <summary>
    /// Interaction logic for WinItensRepresentantes.xaml
    /// </summary>
    public partial class WinItensRepresentantes : Window
    {
        public static object WindowShowDialog(object lRepresentates)
        {
            WinItensRepresentantes wd = new WinItensRepresentantes(lRepresentantes: lRepresentates);

            wd.ShowDialog();

            if ((wd.DataContext as OrcamentoItensRepresentanteViewModel).bSave)
                return wd.DataContext;
            else
                return null;
        }

        public WinItensRepresentantes(object lRepresentantes)
        {
            InitializeComponent();
            this.ViewModel = new OrcamentoItensRepresentanteViewModel(lRepresentantes: lRepresentantes);
        }

        public OrcamentoItensRepresentanteViewModel ViewModel
        {
            get
            {
                return this.DataContext as OrcamentoItensRepresentanteViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
    }
}
