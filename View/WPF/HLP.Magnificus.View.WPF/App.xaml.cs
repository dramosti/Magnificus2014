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
using System.Windows.Markup;
using System.Globalization;
using System.ComponentModel;
using System.Configuration;
using System.ServiceModel.Configuration;
using HLP.Comum.Infrastructure.Util;
namespace HLP.Magnificus.View.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private bool unhandledException = false;
        empresaParametrosService.IserviceEmpresaParametrosClient empresaServico =
            new empresaParametrosService.IserviceEmpresaParametrosClient();

        public App()
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            CompanyData.idEmpresa = 1;
        }

        void bwParametrosEmpresa_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    throw new Exception(message: e.Error.Message);
                }
                else
                {
                    CompanyData.parametrosEmpresa = e.Result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void bwParametrosEmpresa_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = empresaServico.getEmpresaParametros(idEmpresa: CompanyData.idEmpresa);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool DoHandle { get; set; }
        private void Application_DispatcherUnhandledException(object sender,
                               System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            string xMessage = "";
            string xInner = "";
            e.Handled = true;

            if (e.Exception.Message.Contains("Violation of UNIQUE KEY constraint"))
            {
                xMessage = "Não é possível inserir o valor '" + e.Exception.Message.Split('(')[1].Split(')')[0]
                    + "' porque ele já existe na base de dados.";
            }
            else if (e.Exception.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
            {
                xMessage = "Não é possível excluir o cadastro porque ele está sendo utilizado nos cadastros";
            }
            else
            {
                xMessage = e.Exception.Message;
                xInner = e.Exception.InnerException.Message;
            }

            MessageBox.Show(messageBoxText: "Erro: " +
                xMessage + Environment.NewLine +
            "Inner Exception: " + xInner, caption: "Erro.",
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

        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                FrameworkElement.LanguageProperty.OverrideMetadata(
                typeof(FrameworkElement),
                new FrameworkPropertyMetadata(
                    XmlLanguage.GetLanguage(
                    CultureInfo.CurrentCulture.IetfLanguageTag)));

                if (!this.EmRedeLocal())
                {
                    InternetCS internetUtil = new InternetCS();

                    if (internetUtil.Conexao())
                        this.SalvaEndPoint(xUri: HLP.Comum.Infrastructure.Static.WcfData.xEnderWeb);
                }

                BackgroundWorker bwParametrosEmpresa = new BackgroundWorker();
                bwParametrosEmpresa.DoWork += bwParametrosEmpresa_DoWork;
                bwParametrosEmpresa.RunWorkerCompleted += bwParametrosEmpresa_RunWorkerCompleted;
                bwParametrosEmpresa.RunWorkerAsync();

                base.OnStartup(e);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private bool EmRedeLocal()
        {
            System.Net.NetworkInformation.Ping p = new System.Net.NetworkInformation.Ping();
            System.Net.NetworkInformation.PingReply pr;

            try
            {
                pr = p.Send(HLP.Comum.Infrastructure.Static.WcfData.xIpServidor);

                if (pr.Status == System.Net.NetworkInformation.IPStatus.Success)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void SalvaEndPoint(string xUri)
        {
            Configuration c = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ServiceModelSectionGroup serviceModeGroup = ServiceModelSectionGroup.GetSectionGroup(c);
            string xNomeServico;
            foreach (ChannelEndpointElement item in serviceModeGroup.Client.Endpoints)
            {
                xNomeServico = item.Address.ToString().Split('/').ToList().Last();
                item.Address = new Uri(xUri + xNomeServico);
            }

            try
            {
                c.Save();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
