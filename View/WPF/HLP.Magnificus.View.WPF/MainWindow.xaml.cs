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
using System.Windows.Navigation;
using System.Windows.Shapes;
using HLP.Comum.Modules;
using HLP.Comum.Modules.Infrastructure;
using HLP.Comum.Infrastructure.Static;
using HLP.Comum.ViewModel.ViewModels;
using HLP.Entries.View.WPF.Gerais;

namespace HLP.Magnificus.View.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GerenciadorModulo.Instancia.InicializaSistema();
            try
            {
                this._viewModel = new MainViewModel();
                this._viewModel.CarregaMenu(m: this.menuPrincipal);
            }
            catch (Exception)
            {

                throw;
            }
            CompanyData.idEmpresa = 1;
        }

        public MainViewModel _viewModel
        {
            get { return this.DataContext as MainViewModel; }
            set { this.DataContext = value; }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void exLogin_Expanded(object sender, RoutedEventArgs e)
        {
            ContextMenuService.SetPlacement(element: exLogin, value: System.Windows.Controls.Primitives.PlacementMode.Bottom);
            this._viewModel.OpenCtxCommand.Execute(parameter: exLogin.ContextMenu);
            exLogin.IsExpanded = false;
        }

        private void exLogin_MouseEnter(object sender, MouseEventArgs e)
        {
        }
    }
}