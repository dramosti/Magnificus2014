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
using HLP.Entries.ViewModel.ViewModels.Financeiro;
using HLP.Components.View.WPF;

namespace HLP.Entries.View.WPF.GestãoAdministrativa.Financeiro
{
    /// <summary>
    /// Interaction logic for WinBanco.xaml
    /// </summary>
    public partial class WinBanco : WindowsBase
    {
        public WinBanco()
        {
            InitializeComponent();
            this.ViewModel = new BancoViewModel();
            tabHierarquia.GotFocus += new RoutedEventHandler(this.ViewModel.TabItem_GotFocus);

        }

        public BancoViewModel ViewModel
        {
            get
            {
                return this.DataContext as BancoViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
    }
}
