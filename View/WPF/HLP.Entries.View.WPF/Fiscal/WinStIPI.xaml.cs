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
using HLP.Entries.ViewModel.ViewModels.Fiscal;
using HLP.Components.View.WPF;

namespace HLP.Entries.View.WPF.Fiscal
{
    /// <summary>
    /// Interaction logic for WinStIPI.xaml
    /// </summary>
    public partial class WinStIPI : WindowsBase
    {
        public WinStIPI()
        {
            InitializeComponent();
            this.ViewModel = new StIpiViewModel();
        }

        public StIpiViewModel ViewModel
        {
            get
            {
                return this.DataContext as StIpiViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
    }
}
