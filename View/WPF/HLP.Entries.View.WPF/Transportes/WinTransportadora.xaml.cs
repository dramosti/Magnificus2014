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
    /// Interaction logic for WinTransportadora.xaml
    /// </summary>
    public partial class WinTransportadora : WindowsBase
    {
        public WinTransportadora()
        {            
            InitializeComponent();
            this.ViewModel = new TransportadorViewModel();              
        }

        public TransportadorViewModel ViewModel
        {
            get { return this.DataContext as TransportadorViewModel; }
            set { this.DataContext = value; }
        }

        private void dgvEndereco_CurrentCellChanged(object sender, EventArgs e)
        {
            this.dgvEndereco.BindingGroup.UpdateSources();
        }
    }




}
