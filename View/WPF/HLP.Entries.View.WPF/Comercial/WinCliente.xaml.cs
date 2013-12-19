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

namespace HLP.Entries.View.WPF.Comercial
{
    /// <summary>
    /// Interaction logic for WinCliente.xaml
    /// </summary>
    public partial class WinCliente : WindowsBase   
    {
        public WinCliente()
        {
            InitializeComponent();

            this.ViewModel = new ClienteViewModel();
        }

        public ClienteViewModel ViewModel
        {
            get
            {
                return this.DataContext as ClienteViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
    }
}
