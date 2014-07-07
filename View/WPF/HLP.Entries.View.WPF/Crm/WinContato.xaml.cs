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
using HLP.Entries.ViewModel.ViewModels.Gerais;
using HLP.Components.View.WPF;

namespace HLP.Entries.View.WPF.GestãoComercial.Crm
{
    /// <summary>
    /// Interaction logic for WinContato.xaml
    /// </summary>
    public partial class WinContato : WindowsBase
    {
        public WinContato()
        {
            try
            {
                InitializeComponent();
                this.ViewModel = new ContatoViewModel();
            }
            catch (Exception ex)
            {                
                throw ex;
            }            
        }

        public ContatoViewModel ViewModel
        {
            get { return this.DataContext as ContatoViewModel; }
            set { this.DataContext = value; }
        }

     
        private void dgvEndereco_CurrentCellChanged(object sender, EventArgs e)
        {
            this.dgvEndereco.BindingGroup.UpdateSources();
        }
    }
}
