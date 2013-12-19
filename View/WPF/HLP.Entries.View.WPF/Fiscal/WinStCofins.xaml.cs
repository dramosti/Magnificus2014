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
using HLP.Entries.ViewModel.ViewModels.Fiscal;

namespace HLP.Entries.View.WPF.Fiscal
{
    /// <summary>
    /// Interaction logic for WinStCofins.xaml
    /// </summary>
    public partial class WinStCofins : WindowsBase
    {
        public WinStCofins()
        {
            InitializeComponent();
            this.ViewModel = new StCofinsViewModel();
        }

        public StCofinsViewModel ViewModel
        {
            get
            {
                return this.DataContext as StCofinsViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
    }
}
