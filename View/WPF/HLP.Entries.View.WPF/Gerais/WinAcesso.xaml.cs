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
    /// Interaction logic for WinAcesso.xaml
    /// </summary>
    public partial class WinAcesso : WindowsBase
    {
        public WinAcesso()
        {
            InitializeComponent();
            try
            {
                this.ViewModel = new Funcionario_AcessoViewModel();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Funcionario_AcessoViewModel ViewModel
        {
            get
            {
                return this.DataContext as Funcionario_AcessoViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

        private void gridAcessos_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            this.gridAcessos.BindingGroup.UpdateSources();
        }

        private void controlsBgLogin_LostFocus(object sender, RoutedEventArgs e)
        {
            this.bgLogin.UpdateSources();
        }
    }
}
