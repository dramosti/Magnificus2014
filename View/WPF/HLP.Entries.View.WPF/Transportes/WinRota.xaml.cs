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

namespace HLP.Entries.View.WPF.Transportes
{
    /// <summary>
    /// Interaction logic for WinRota.xaml
    /// </summary>
    public partial class WinRota : WindowsBase
    {
        public WinRota()
        {
            InitializeComponent();
            this.ViewModel = new RotaViewModel();
        }

        public RotaViewModel ViewModel
        {
            get { return this.DataContext as RotaViewModel; }
            set { this.DataContext = value; }
        }
    }
}
