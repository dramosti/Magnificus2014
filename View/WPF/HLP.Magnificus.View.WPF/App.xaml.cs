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
            Util.CarregaSettingsAppConfig();
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
                string x = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
                this.SalvaTamanhoMensagensWcf();
                if (this.EmRedeLocal() != TipoConexao.OnlineRede)
                {
                    InternetCS internetUtil = new InternetCS();

                    if (internetUtil.Conexao())
                    {
                        Sistema.bOnline = TipoConexao.OnlineInternet;
                        this.SalvaEndPoint(xUri: HLP.Comum.Infrastructure.Static.WcfData.xEnderWeb);
                    }
                    else
                    {
                        Sistema.bOnline = TipoConexao.Offline;
                        MessageBox.Show(messageBoxText: "Não foi possível iniciar sistema, sem conexão de rede e internet.");
                        Application.Current.Shutdown();
                    }
                }

                if (Sistema.bOnline != TipoConexao.Offline)
                {

                    HLP.Magnificus.View.WPF.MainWindow wd = new MainWindow();
                    this.MainWindow = wd;

                    WinLogin wdLogin = new WinLogin(stModoInicial: Comum.ViewModel.ViewModels.ModoInicial.padrao);
                    wdLogin.ShowDialog();

                    wd._viewModel.CarregaDadosLogin();
                    FrameworkElement.LanguageProperty.OverrideMetadata(
                    typeof(FrameworkElement),
                    new FrameworkPropertyMetadata(
                        XmlLanguage.GetLanguage(
                        CultureInfo.CurrentCulture.IetfLanguageTag)));

                    BackgroundWorker bwParametrosEmpresa = new BackgroundWorker();
                    bwParametrosEmpresa.DoWork += bwParametrosEmpresa_DoWork;
                    bwParametrosEmpresa.RunWorkerCompleted += bwParametrosEmpresa_RunWorkerCompleted;
                    bwParametrosEmpresa.RunWorkerAsync();

                    base.OnStartup(e);
                    wd.Show();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private TipoConexao EmRedeLocal()
        {
            System.Net.NetworkInformation.Ping p = new System.Net.NetworkInformation.Ping();
            System.Net.NetworkInformation.PingReply pr;

            try
            {
                pr = p.Send(HLP.Comum.Infrastructure.Static.WcfData.xIpServidor);

                if (pr.Status == System.Net.NetworkInformation.IPStatus.Success)
                    Sistema.bOnline = TipoConexao.OnlineRede;
                else
                    Sistema.bOnline = TipoConexao.OnlineInternet;
                return Sistema.bOnline;
            }
            catch (Exception)
            {
                return TipoConexao.Offline;
            }
        }

        public void SalvaTamanhoMensagensWcf()
        {            
            Configuration c = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            ServiceModelSectionGroup serviceModeGroup = ServiceModelSectionGroup.GetSectionGroup(c);
            //BindingCollectionElement be = serviceModeGroup.Bindings.BindingCollections.FirstOrDefault(i => i.BindingName == "basicHttpBinding");

            foreach (BasicHttpBindingElement item in serviceModeGroup.Bindings.BasicHttpBinding.Bindings
                )
            {
                item.MaxReceivedMessageSize = 2147483647;
                item.ReaderQuotas.MaxDepth = 2147483647;
                item.ReaderQuotas.MaxStringContentLength = 2147483647;
                item.ReaderQuotas.MaxArrayLength = 2147483647;
                item.ReaderQuotas.MaxBytesPerRead = 2147483647;
                item.ReaderQuotas.MaxNameTableCharCount = 2147483647;
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
