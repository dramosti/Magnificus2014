using HLP.Base.ClassesBases;
using HLP.Base.Static;
using HLP.Comum.View.WPF.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HLP.Magnificus.View.WPF
{
    /// <summary>
    /// Interaction logic for wdSplash.xaml
    /// </summary>
    public partial class wdSplash : Window, INotifyPropertyChanged
    {
        BackgroundWorker bwSplash;
        bool bPermiteModoWeb = false;
        public wdSplash()
        {
            InitializeComponent();
            bwSplash = new BackgroundWorker();
            bwSplash.DoWork += bwSplash_DoWork;
            bwSplash.RunWorkerCompleted += bwSplash_RunWorkerCompleted;
            this.Loaded += wdSplash_Loaded;

            this.KeyUp += wdSplash_KeyUp;
        }

        void wdSplash_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.SystemKey == Key.F10 && bPermiteModoWeb)
                Sistema.bOnline = StConnection.OnlineWeb;
        }

        void wdSplash_Loaded(object sender, RoutedEventArgs e)
        {
            string xUriWcf = Sistema.GetAppSettings("urlWebService");

            if (string.IsNullOrEmpty(value: xUriWcf))
            {
                if (HlpMessageYesNo.ShowMessage(xMessageToUser: "Para inicialização é necessário algumas configurações, deseja configurar agora? " +
                    Environment.NewLine + "Caso escolha não, sistema será fechado.")
                    == MessageBoxResult.Yes)
                {
                    wdConfig configuracao = new wdConfig();
                    configuracao.ShowDialog();

                    System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                }
                
                Application.Current.Shutdown();                
            }

            this.bwSplash.RunWorkerAsync();
        }

        void bwSplash_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                HlpMessageError.ShowMessage(xErrorCode: "", xErrorMessageToUser: "Não foi possível iniciar o sistema." +
                    Environment.NewLine + e.Error.Message
                    , xErrorMessageFramework:
                    e.Error.StackTrace + Environment.NewLine +
                    (e.Error.InnerException != null ? e.Error.InnerException.ToString() : string.Empty));
                App.Current.Shutdown(exitCode: 0);
            }
            else
                if (Sistema.bOnline != StConnection.Offline)
                {
                    if ((bool)e.Result)
                    {
                        System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                        Application.Current.Shutdown();
                    }

                    WinLogin wdLogin = new WinLogin(stModoInicial: ComumView.ViewModel.ViewModel.ModoInicial.padrao);
                    wdLogin.ShowDialog();
                    if (wdLogin.ViewModel.bLogado)
                    {
                        wdMain wd = new wdMain();
                        App.Current.MainWindow = wd;
                        wd.ViewModel.CarregaDadosLogin();
                        FrameworkElement.LanguageProperty.OverrideMetadata(
                        typeof(FrameworkElement),
                        new FrameworkPropertyMetadata(
                            XmlLanguage.GetLanguage(
                            CultureInfo.CurrentCulture.IetfLanguageTag)));
                        wd.WindowState = WindowState.Maximized;
                        wd.Show();
                        this.DialogResult = true;
                        this.Close();
                    }
                    else
                    {
                        if (Application.Current != null)
                            Application.Current.Shutdown();
                    }
                }
        }

        void bwSplash_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                int timeToWait = 1000;

                // Verificar se a maquina esta na Rede...    

                this.Dispatcher.BeginInvoke((Action)(() =>
                    {
                        this.txt.Text = "Carregando configurações de rede...";
                    }));
                Thread.Sleep(millisecondsTimeout: timeToWait);

                Sistema.EmRedeLocal();

                if (Sistema.bOnline == StConnection.Offline)
                {
                    throw new Exception(message: "Sistema sem acesso a rede/internet, verifique!!");
                }

                if (Sistema.bOnline == StConnection.OnlineNetwork)
                {
                    bPermiteModoWeb = true;
                    this.Dispatcher.BeginInvoke((Action)(() =>
                    {
                        this.txt.Text = "Aperte (F10) para ativar modo web <--Recomendado para testes/desenvolvedores-->...";
                    }));
                    Thread.Sleep(millisecondsTimeout: 3000);
                }

                // Adicionar todos os configs ao app.config principal ...  
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    this.txt.Text = "Carregando configurações de serviços...";
                }));
                Thread.Sleep(millisecondsTimeout: timeToWait);
                Sistema.SetAllConfigService();

                // Validar se ja existe uma conexão
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    this.txt.Text = "Validando conexão...";
                }));
                Thread.Sleep(millisecondsTimeout: timeToWait);
                if (this.ValidaConnection())
                {
                    bool bModificado = false;
                    this.Dispatcher.BeginInvoke((Action)(() =>
                    {
                        this.txt.Text = "Configurando serviços...";
                    }));

                    Thread.Sleep(millisecondsTimeout: timeToWait);
                    bModificado = Sistema.SalvaTamanhoMensagensWcf();

                    if (Sistema.bOnline != StConnection.OnlineNetwork)
                    {
                        this.Dispatcher.BeginInvoke((Action)(() =>
                        {
                            this.txt.Text = "Carregando modo via web...";
                        }));
                        Thread.Sleep(millisecondsTimeout: timeToWait);
                        InternetCS internetUtil = new InternetCS();
                        if (internetUtil.Conexao())
                        {
                            Sistema.bOnline = StConnection.OnlineWeb;
                            this.Dispatcher.BeginInvoke((Action)(() =>
                            {
                                this.txt.Text = "Configurando endereço de serviços...";
                            }));
                            Thread.Sleep(millisecondsTimeout: timeToWait);

                            bModificado = Sistema.SalvaEndPoint(xUri: Sistema.GetAppSettings("urlWebService"));
                        }
                        else
                        {
                            Sistema.bOnline = StConnection.Offline;
                            MessageBox.Show(messageBoxText: "Não foi possível iniciar sistema, sem conexão de rede e internet.");
                            Application.Current.Shutdown();
                        }
                    }

                    if (bModificado)
                    {
                        this.Dispatcher.BeginInvoke((Action)(() =>
                        {
                            this.txt.Text = "Definições de configuração foram atualizadas, sistema será reiniciado...";
                        }));
                        Thread.Sleep(millisecondsTimeout: timeToWait);
                    }
                    else
                    {
                        this.Dispatcher.BeginInvoke((Action)(() =>
                        {
                            this.txt.Text = "Sistema configurado. Inicializando...";
                        }));
                        Thread.Sleep(millisecondsTimeout: timeToWait);
                    }
                    e.Result = bModificado;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

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

        #region NotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
