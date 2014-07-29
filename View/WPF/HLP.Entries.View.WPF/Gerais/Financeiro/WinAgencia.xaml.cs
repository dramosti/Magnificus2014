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
using HLP.Entries.ViewModel.ViewModels.Financeiro;
using HLP.Components.View.WPF;

namespace HLP.Entries.View.WPF.GestãoAdministrativa.Financeiro
{
    /// <summary>
    /// Interaction logic for WinAgencia.xaml
    /// </summary>
    public partial class WinAgencia : WindowsBase
    {
        public WinAgencia()
        {
            InitializeComponent();
            this.ViewModel = new AgenciaViewModel();
            tabHierarquia.GotFocus += new RoutedEventHandler(this.ViewModel.TabItem_GotFocus);
        }


        public AgenciaViewModel ViewModel
        {
            get
            {
                return this.DataContext as AgenciaViewModel;
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
    }
}
