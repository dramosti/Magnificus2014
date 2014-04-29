using HLP.Comum.ViewModel.ViewModel;
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

namespace HLP.Comum.View.WPF
{
    /// <summary>
    /// Interaction logic for WinConnectionConfig.xaml
    /// </summary>
    public partial class WinConnectionConfig : Window
    {
        public WinConnectionConfig()
        {
            InitializeComponent();
            this.ViewModel = new ConnectionConfigViewModel();

            txtPassword.LostFocus += this.ViewModel.txtPassword_LostFocus;
        }

        public ConnectionConfigViewModel ViewModel
        {
            get { return this.DataContext as ConnectionConfigViewModel; }
            set { this.DataContext = value; }
        }



    }
}
