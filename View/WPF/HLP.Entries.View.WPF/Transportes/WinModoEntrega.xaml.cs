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
using HLP.Entries.ViewModel.ViewModels.Transportes;

namespace HLP.Entries.View.WPF.GestãoDeLogística
{
    /// <summary>
    /// Interaction logic for WinModoEntrega.xaml
    /// </summary>
    public partial class WinModoEntrega : WindowsBase
    {
        public WinModoEntrega()
        {
            InitializeComponent();
            this.ViewModel = new ModoEntregaViewModel();
        }


        public ModoEntregaViewModel ViewModel
        {
            get { return this.DataContext as ModoEntregaViewModel; }
            set { this.DataContext = value; }
        }

    }
}
