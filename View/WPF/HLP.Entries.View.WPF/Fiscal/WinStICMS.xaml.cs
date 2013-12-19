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
    /// Interaction logic for WinStICMS.xaml
    /// </summary>
    public partial class WinStICMS : WindowsBase
    {
        public WinStICMS()
        {
            InitializeComponent();
            this.ViewModel = new StIcmsViewModel();
        }

        public StIcmsViewModel ViewModel
        {
            get
            {
                return this.DataContext as StIcmsViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
    }
}
