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
using System.Windows.Markup;
using System.Globalization;
using System.ComponentModel;
using System.Configuration;
using System.ServiceModel.Configuration;
using HLP.Entries.View.WPF.RecursosHumanos;
using HLP.Base.Static;
using HLP.Base.EnumsBases;
using HLP.Base.ClassesBases;

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
            string xMessage = e.Exception.Message + Environment.NewLine + e.Exception.InnerException;
            string xInner = "";
            e.Handled = true;

            if (xMessage.Contains("Violation of UNIQUE KEY constraint"))
            {
                xMessage = "Não é possível inserir o valor '" + xMessage.Split('(')[1].Split(')')[0]
                    + "' porque ele já existe na base de dados.";
            }
            else if (xMessage.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
            {
                xMessage = "Não é possível excluir o cadastro porque ele está sendo utilizado nos cadastros";
            }
            else
            {
                xMessage = e.Exception.Message;
                if (e.Exception.InnerException != null)
                    xInner = e.Exception.InnerException.Message;
            }
            if (!xMessage.Contains("NewItemPlaceholderPosition"))
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
                

                bool bModificado = false;
                bModificado = this.SalvaTamanhoMensagensWcf();
                if (this.EmRedeLocal() != StConnection.OnlineNetwork)
                {
                    InternetCS internetUtil = new InternetCS();

                    if (internetUtil.Conexao())
                    {
                        Sistema.bOnline = StConnection.OnlineWeb;
                        bModificado = this.SalvaEndPoint(xUri: WcfData.xEnderWeb);
                    }
                    else
                    {
                        Sistema.bOnline = StConnection.Offline;
                        MessageBox.Show(messageBoxText: "Não foi possível iniciar sistema, sem conexão de rede e internet.");
                        Application.Current.Shutdown();
                    }
                }

                if (Sistema.bOnline != StConnection.Offline)
                {

                    if (bModificado)
                    {
                        System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                        Application.Current.Shutdown();
                    }

                    HLP.Magnificus.View.WPF.MainWindow wd = new MainWindow();
                    this.MainWindow = wd;

                    WinLogin wdLogin = new WinLogin(stModoInicial: ComumView.ViewModel.ViewModel.ModoInicial.padrao);
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
                    wd.WindowState = WindowState.Maximized;
                    wd.Show();
                    //WinEspelhoPonto win = new WinEspelhoPonto();
                    //win.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private StConnection EmRedeLocal()
        {
            System.Net.NetworkInformation.Ping p = new System.Net.NetworkInformation.Ping();
            System.Net.NetworkInformation.PingReply pr;

            try
            {
                pr = p.Send(WcfData.xIpServidor);

                if (pr.Status == System.Net.NetworkInformation.IPStatus.Success)
                    Sistema.bOnline = StConnection.OnlineNetwork;
                else
                    Sistema.bOnline = StConnection.OnlineWeb;
                return Sistema.bOnline;
            }
            catch (Exception)
            {
                return StConnection.Offline;
            }
        }

        public bool SalvaTamanhoMensagensWcf()
        {
            Configuration c = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            bool bModificado = false;

            int iTamanho = 2147483647;

            ServiceModelSectionGroup serviceModeGroup = ServiceModelSectionGroup.GetSectionGroup(c);
            //BindingCollectionElement be = serviceModeGroup.Bindings.BindingCollections.FirstOrDefault(i => i.BindingName == "basicHttpBinding");

            foreach (BasicHttpBindingElement item in serviceModeGroup.Bindings.BasicHttpBinding.Bindings
                )
            {
                if (item.MaxReceivedMessageSize != iTamanho)
                {
                    item.MaxReceivedMessageSize = iTamanho;
                    bModificado = true;
                }
                if (item.ReaderQuotas.MaxDepth != iTamanho)
                {
                    item.ReaderQuotas.MaxDepth = iTamanho;
                    bModificado = true;
                }
                if (item.ReaderQuotas.MaxStringContentLength != iTamanho)
                {
                    item.ReaderQuotas.MaxStringContentLength = iTamanho;
                    bModificado = true;
                }
                if (item.ReaderQuotas.MaxArrayLength != iTamanho)
                {
                    item.ReaderQuotas.MaxArrayLength = iTamanho;
                    bModificado = true;
                }
                if (item.ReaderQuotas.MaxBytesPerRead != iTamanho)
                {
                    item.ReaderQuotas.MaxBytesPerRead = iTamanho;
                    bModificado = true;
                }
                if (item.ReaderQuotas.MaxNameTableCharCount != iTamanho)
                {
                    item.ReaderQuotas.MaxNameTableCharCount = iTamanho;
                    bModificado = true;
                }
            }

            try
            {
                if (bModificado)
                    c.Save();

                return bModificado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private bool SalvaEndPoint(string xUri)
        {
            Configuration c = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ServiceModelSectionGroup serviceModeGroup = ServiceModelSectionGroup.GetSectionGroup(c);
            string xNomeServico;
            Uri _uri;
            bool bModificado = false;

            foreach (ChannelEndpointElement item in serviceModeGroup.Client.Endpoints)
            {
                xNomeServico = item.Address.ToString().Split('/').ToList().Last();
                _uri = new Uri(xUri + xNomeServico);
                if (_uri != item.Address)
                {
                    bModificado = true;
                    item.Address = _uri;
                }
            }

            try
            {
                if (bModificado)
                    c.Save();

                return bModificado;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
