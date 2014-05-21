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
using HLP.Entries.View.WPF.Gerais;
using HLP.Base.Modules;
using HLP.Base.Static;
using HLP.ComumView.ViewModel.ViewModel;

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
                this._viewModel.tabWindows = this.tabControlItens;
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
            ctxLogin.PlacementTarget = exLogin;
            ctxLogin.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            ctxLogin.IsOpen = true;
            exLogin.IsExpanded = false;
        }

        private void trocarUsuario_Click(object sender, RoutedEventArgs e)
        {
            WinLogin wdLogin = new WinLogin(ModoInicial.trocaUsuario);
            wdLogin.ShowDialog();
            this._viewModel.CarregaDadosLogin();
        }

        private void trocarEmpresa_Click(object sender, RoutedEventArgs e)
        {
            WinLogin wdLogin = new WinLogin(ModoInicial.trocaEmpresa);
            wdLogin.ShowDialog();
            this._viewModel.CarregaDadosLogin();
        }

        private void manWin_StateChanged(object sender, EventArgs e)
        {

        }

        private void manWin_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this._viewModel.heightWindow = this.dockPrinc.ActualHeight - this.statusBarPrinc.ActualHeight;
        }
    }
}