using System;
using System.Windows;
using HLP.Entries.ViewModel.ViewModels.RecursosHumanos;

namespace HLP.Entries.View.WPF.RecursosHumanos
{
    /// <summary>
    /// Interaction logic for WinCorrigirUltimoPonto.xaml
    /// </summary>
    public partial class WinCorrigirUltimoPonto : Window
    {
        public WinCorrigirUltimoPonto(DateTime dtMes, int idFuncionario)
        {
            InitializeComponent();
            this.ViewModel = new CorrigirUltimoPontoViewModel(dtMes, idFuncionario);
        }

        public static object ShowWindow(DateTime dtMes, int idFuncionario)
        {
            WinCorrigirUltimoPonto win = new WinCorrigirUltimoPonto(dtMes, idFuncionario);
            //win.WindowState = WindowState.Maximized;
            win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            win.Show();
            return win;
        }


        public CorrigirUltimoPontoViewModel ViewModel
        {
            get { return this.DataContext as CorrigirUltimoPontoViewModel; }
            set { this.DataContext = value; }
        }

        public void RefreshWindowPrincipal(Action method)
        {
            this.ViewModel.actionAtualizaWindowPrincipal = method;
        }
    }
}
