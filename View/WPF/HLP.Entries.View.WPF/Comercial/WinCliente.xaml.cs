using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using HLP.Entries.ViewModel.ViewModels.Comercial;
using HLP.Components.View.WPF;

namespace HLP.Entries.View.WPF.GestãoAdministrativa
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

            base.SetEventsTabControl(tabControl: this.tbPrincipal);

            
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

        private void dgvEndereco_CurrentCellChanged(object sender, EventArgs e)
        {
            this.dgvEndereco.BindingGroup.UpdateSources();
        }

        private void dgvContato_FocusableChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void dgvContato_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

        }

        private void HlpTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // tabPessoal.SelectedItem = tabFiliacao;
        }

    }
}
