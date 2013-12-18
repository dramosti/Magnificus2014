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
using HLP.Entries.ViewModel.ViewModels.Financeiro;

namespace HLP.Entries.View.WPF.Gerais.Financeiro
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
