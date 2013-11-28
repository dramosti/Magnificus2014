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

namespace HLP.Entries.View.WPF.Gerais
{
    /// <summary>
    /// Interaction logic for WinMoeda.xaml
    /// </summary>
    public partial class WinMoeda : WindowsBase
    {
        public WinMoeda()
        {
            InitializeComponent();
            this.ViewModel = new MoedaViewModel();
        }

        public MoedaViewModel ViewModel
        {
            get
            {
                return this.DataContext as MoedaViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
    }
}
