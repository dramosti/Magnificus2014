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
using HLP.Entries.ViewModel.ViewModels.Comercial;

namespace HLP.Entries.View.WPF.GestãoAdministrativa.Financeiro
{
    /// <summary>
    /// Interaction logic for WinMulta.xaml
    /// </summary>
    public partial class WinMulta : WindowsBase
    {
        public WinMulta()
        {
            InitializeComponent();
            this.ViewModel = new MultaViewModel();
        }

        public MultaViewModel ViewModel
        {
            get
            {
                return this.DataContext as MultaViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
    }
}
