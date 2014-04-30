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
using HLP.Entries.ViewModel.ViewModels.Transportes;
using HLP.Components.View.WPF;

namespace HLP.Entries.View.WPF.GestãoDeLogística
{
    /// <summary>
    /// Interaction logic for WinCondicaoEntrega.xaml
    /// </summary>
    public partial class WinCondicaoEntrega : WindowsBase
    {
        public WinCondicaoEntrega()
        {
            InitializeComponent();
            this.DataContext = new Condicao_entregaViewModel();   
        }

        public Condicao_entregaViewModel ViewModel
        {
            get
            {
                return this.DataContext as Condicao_entregaViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
    }
}
