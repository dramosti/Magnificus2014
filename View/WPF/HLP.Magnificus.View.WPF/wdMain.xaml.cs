using HLP.Base.Modules;
using HLP.Base.Static;
using HLP.ComumView.ViewModel.ViewModel;
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

namespace HLP.Magnificus.View.WPF
{
    /// <summary>
    /// Interaction logic for wdMain.xaml
    /// </summary>
    public partial class wdMain : Window
    {
        public wdMain()
        {
            InitializeComponent();
            GerenciadorModulo.Instancia.InicializaSistema();
            this.ViewModel = new wdMainViewModel();

        }

        public wdMainViewModel ViewModel
        {
            get
            {
                return this.DataContext as wdMainViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        //private void exLogin_Expanded(object sender, RoutedEventArgs e)
        //{
        //    ctxLogin.PlacementTarget = exLogin;
        //    ctxLogin.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
        //    ctxLogin.IsOpen = true;
        //    exLogin.IsExpanded = false;
        //}

        private void trocarUsuario_Click(object sender, RoutedEventArgs e)
        {
            WinLogin wdLogin = new WinLogin(ModoInicial.trocaUsuario);
            wdLogin.ShowDialog();
            this.ViewModel.CarregaDadosLogin();
        }

        private void trocarEmpresa_Click(object sender, RoutedEventArgs e)
        {
            WinLogin wdLogin = new WinLogin(ModoInicial.trocaEmpresa);
            wdLogin.ShowDialog();
            this.ViewModel.CarregaDadosLogin();
        }

        private void manWin_StateChanged(object sender, EventArgs e)
        {

        }

        //private void manWin_SizeChanged(object sender, SizeChangedEventArgs e)
        //{
        //    this.ViewModel.heightWindow = this.dockPrinc.ActualHeight - this.statusBarPrinc.ActualHeight;
        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                FileStatic.ExecuteFile(xPath: (sender as TextBlock).Text);
            }
        }

        private void ComboBox_GotFocus(object sender, RoutedEventArgs e)
        {
            (sender as ComboBox).IsDropDownOpen = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = System.Windows.WindowState.Minimized;
        }
    }
}
