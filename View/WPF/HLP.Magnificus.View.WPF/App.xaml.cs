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
namespace HLP.Magnificus.View.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private bool unhandledException = false;

        public App()
        {
            CompanyData.idEmpresa = 1;
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
        }

        public bool DoHandle { get; set; }
        private void Application_DispatcherUnhandledException(object sender,
                               System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            string xMessage = "";
            e.Handled = true;

            if (e.Exception.Message.Contains("Violation of UNIQUE KEY constraint"))
            {
                xMessage = "Não é possível inserir o valor '" + e.Exception.Message.Split('(')[1].Split(')')[0]
                    + "' porque ele já existe na base de dados.";
            }
            else
            {
                xMessage = e.Exception.Message;
            }

            MessageBox.Show(messageBoxText: "Erro: " +
                xMessage, caption: "Erro.",
                button: MessageBoxButton.OK, icon: MessageBoxImage.Exclamation);
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            this.HandleUnhandledException(e.ExceptionObject as Exception);
            this.unhandledException = true;
        }

        private void HandleUnhandledException(Exception target)
        {
            if (false == unhandledException)
            {
            }
        }
    }
}
