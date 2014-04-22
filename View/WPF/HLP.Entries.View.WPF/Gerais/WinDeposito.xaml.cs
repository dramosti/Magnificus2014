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
using HLP.Entries.ViewModel.ViewModels.Gerais;

namespace HLP.Entries.View.WPF.GestãoDeMateriais
{
    /// <summary>
    /// Interaction logic for WinDeposito.xaml
    /// </summary>
    public partial class WinDeposito : WindowsBase
    {
        public WinDeposito()
        {
            InitializeComponent();
            this.ViewModel = new depositoViewModel();
        }

        public depositoViewModel ViewModel
        {
            get
            {
                return this.DataContext as depositoViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
    }
}
