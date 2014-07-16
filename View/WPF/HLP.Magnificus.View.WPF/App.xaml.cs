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
using HLP.Base.Modules;
using System.Xml;
using System.IO;
using HLP.Comum.View.WPF.Messages;
using System.Reflection;

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
        BackgroundWorker bwInitialize;


        public App()
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Util.CarregaSettingsAppConfig();
            this.bwInitialize = new BackgroundWorker();
            this.bwInitialize.DoWork += bwInitialize_DoWork;
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

            if (xMessage.Contains("Violação da restrição UNIQUE KEY"))
            {
                xMessage = "Não é possível inserir o valor '" + xMessage.Split('(')[1].Split(')')[0]
                    + "' porque ele já existe na base de dados.";
            }
            else if (xMessage.Contains(value: "statement conflicted with the FOREIGN KEY constraint"))
            {
                xMessage = String.Format(format: "Não é possível salvar o registro porque não existe um cadastro inserido na tabela {0} e "
                    + "coluna {1} com o valor informado", arg0: xMessage.Split(
                    separator: new string[] { "table" }
                    , options: StringSplitOptions.None)[1].ToString()
                    .Split(separator: '"')[1].ToString().Split('"')[0].ToString(),
                    arg1: xMessage.Split(separator: new string[] { "column" }, options: StringSplitOptions.None)[1].ToString().Split(separator: '\'')[1]);

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
                MessageHlp.Show(stMessage: StMessage.stError, xMessageToUser: xMessage,
                    xMessageFramework: e.Exception.StackTrace);
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

        /// <summary>
        /// Valida se existe conexão
        /// </summary>
        /// <returns></returns>
        private bool ValidaConnection()
        {
            Configuration c = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (c.ConnectionStrings.ConnectionStrings.Count <= 1)
            {
                WinSelectConnection winBases = new WinSelectConnection();
                winBases.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                winBases.ShowDialog();

                if (winBases.ViewModel.bProssegue != null)
                {
                    if (winBases.ViewModel.bProssegue == true)
                    {
                        System.Windows.Forms.Application.Restart();
                        return false;
                    }
                    else
                    {
                        // só para não iniciar o sistema
                        return false;
                    }
                }

            }
            return true;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                // Verificar se a maquina esta na Rede...
                Sistema.EmRedeLocal();
                // Adicionar todos os configs ao app.config principal ...
                Sistema.SetAllConfigService();
                // Validar se ja existe uma conexão
                if (this.ValidaConnection())
                {

                    bool bModificado = false;
                    bModificado = Sistema.SalvaTamanhoMensagensWcf();
                    if (Sistema.bOnline != StConnection.OnlineNetwork)
                    {
                        InternetCS internetUtil = new InternetCS();

                        if (internetUtil.Conexao())
                        {
                            Sistema.bOnline = StConnection.OnlineWeb;
                            bModificado = Sistema.SalvaEndPoint(xUri: Sistema.GetAppSettings("urlWebService"));
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

                        wdMain wd = new wdMain();
                        this.MainWindow = wd;

                        WinLogin wdLogin = new WinLogin(stModoInicial: ComumView.ViewModel.ViewModel.ModoInicial.padrao);

                        this.bwInitialize.RunWorkerAsync();

                        wdLogin.ShowDialog();
                        if (wdLogin.ViewModel.bLogado)
                        {
                            wd.ViewModel.CarregaDadosLogin();
                            FrameworkElement.LanguageProperty.OverrideMetadata(
                            typeof(FrameworkElement),
                            new FrameworkPropertyMetadata(
                                XmlLanguage.GetLanguage(
                                CultureInfo.CurrentCulture.IetfLanguageTag)));
                            base.OnStartup(e);
                            wd.WindowState = WindowState.Maximized;
                            wd.Show();
                        }
                        else
                        {
                            Application.Current.Shutdown();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void bwInitialize_DoWork(object sender, DoWorkEventArgs e)
        {
            Application.Current.Dispatcher.BeginInvoke((Action)(() =>
                {
                    (this.MainWindow as wdMain).ViewModel.PopulateStaticCidades();
                }));
        }
    }
}
