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
using HLP.Entries.ViewModel.ViewModels.Comercial;
using HLP.Components.View.WPF;

namespace HLP.Entries.View.WPF.Comercial
{
    /// <summary>
    /// Interaction logic for WinCanalVenda.xaml
    /// </summary>
    public partial class WinCanalVenda : WindowsBase
    {
        public WinCanalVenda()
        {
            InitializeComponent();
            this.ViewModel = new Canal_VendaViewModel();
        }

        public Canal_VendaViewModel ViewModel
        {
            get
            {
                return this.DataContext as Canal_VendaViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
    }
}
