using HLP.Comum.Model.Models;
using HLP.Comum.Modules;
using HLP.Comum.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Forms;
using HLP.Comum.Infrastructure.Static;
using System.IO;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.Reflection;

namespace HLP.Comum.ViewModel.ViewModels
{
    public class MainViewModel : ViewModelBase<WinManModel>
    {
        empresaService.IserviceEmpresaClient empresaService = new empresaService.IserviceEmpresaClient();
        funcionarioService.IserviceFuncionarioClient funcionarioService = new funcionarioService.IserviceFuncionarioClient();


        private double _heightWindow;

        public double heightWindow
        {
            get { return _heightWindow; }
            set
            {
                _heightWindow = value;
                base.NotifyPropertyChanged(propertyName: "heightWindow");
            }
        }


        private int _sizeColunaDados;

        public int sizeColunaDados
        {
            get { return _sizeColunaDados; }
            set
            {
                _sizeColunaDados = value;
                base.NotifyPropertyChanged(propertyName: "sizeColunaDados");
            }
        }

        private string _xVersao;

        public string xVersao
        {
            get { return "Versão: " + _xVersao; }
            set
            {
                _xVersao = value;
                base.NotifyPropertyChanged(propertyName: "xVersao");
            }
        }


        public MainViewModel()
        {
            winMan = new WinManModel();
            string sPath = "";

            if (Sistema.bOnline == TipoConexao.OnlineInternet)
            {
                sPath = System.AppDomain.CurrentDomain.BaseDirectory + @"Icones\" + "rede_online" + ".png";
                this.winMan.sToolTipConexao = "Online pela internet";
            }
            else if (Sistema.bOnline == TipoConexao.OnlineRede)
            {
                sPath = System.AppDomain.CurrentDomain.BaseDirectory + @"Icones\" + "rede_interna" + ".png";
                this.winMan.sToolTipConexao = "Online via rede interna.";
            }

            if (File.Exists(path: sPath))
            {
                this.winMan.iconConexao = new BitmapImage(new Uri(sPath));
            }

            MainCommands objCommands = new MainCommands(objTabPagesAtivasViewModel: this);
            this.winMan._lTabPagesAtivas = new ObservableCollection<TabPagesAtivasModel>();
            this.winMan._lWindows = new ObservableCollection<windowsModel>();
            windowsModel objWindow;

            foreach (var item in Modulo.lobjectModulo)
            {
                foreach (var win in item.lFormularios)
                {
                    objWindow = new windowsModel();
                    objWindow.xName = win.xId;
                    objWindow.xHeader = win.xName.Replace('_', ' ');
                    this.winMan._lWindows.Add(item: objWindow);
                }
            }

            this.lMenu = new List<MenuItemModel>();
            string s;
            bool v = true;
            string header;
            int count = 0;
            try
            {
                foreach (var item in Modulo.lobjectModulo)
                {
                    foreach (var win in item.lFormularios)
                    {
                        List<string> lSeparadores = win.xType.ToString().Split(',')[0].Split('.').ToList();
                        header = win.xName;
                        v = true;
                        s = lSeparadores.FirstOrDefault(i => i.ToString() == "HLP");
                        if (s != null)
                            lSeparadores.RemoveAt(lSeparadores.IndexOf(s));
                        else
                            v = false;

                        s = lSeparadores.FirstOrDefault(i => i.ToString() == "View");
                        if (s != null)
                            lSeparadores.RemoveAt(lSeparadores.IndexOf(s));
                        else
                            v = false;

                        s = lSeparadores.FirstOrDefault(i => i.ToString() == "WPF");
                        if (s != null)
                            lSeparadores.RemoveAt(lSeparadores.IndexOf(s));
                        else
                            v = false;

                        if (v)
                        {
                            this.currentMenu = this.lMenu;
                            count = 0;
                            foreach (string menuItem in lSeparadores)
                            {
                                count++;
                                AddMenuItem(xNome: menuItem, xHeader: header, bLast: count < lSeparadores.Count ? false : true);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            this.xVersao = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        public void CarregaDadosLogin()
        {
            this.currentEmpresa = empresaService.getEmpresa(idEmpresa: CompanyData.idEmpresa);
            this.currentFuncionario = funcionarioService.getFuncionario(idFuncionario: UserData.idUser);
            this.sizeColunaDados = this.currentFuncionario.xNome.Length * 10;
        }

        private WinManModel _winMan;
        public WinManModel winMan
        {
            get { return _winMan; }
            set { _winMan = value; base.NotifyPropertyChanged("winMan"); }
        }

        #region Assinatura de comandos
        public ICommand AddWindowCommand { get; set; }
        public ICommand DelWindowCommand { get; set; }
        public ICommand pesquisarBaseCommand { get; set; }
        public ICommand FindAllCommand { get; set; }
        public ICommand SobreCommand { get; set; }
        public ICommand OpenCtxCommand { get; set; }
        public ICommand TrocarUsuarioCommand { get; set; }
        public ICommand TrocarEmpresaCommand { get; set; }
        public ICommand SairCommand { get; set; }
        #endregion

        #region Informações Usuário e Empresa

        private empresaService.EmpresaModel _currentEmpresa;

        public empresaService.EmpresaModel currentEmpresa
        {
            get { return _currentEmpresa; }
            set
            {
                _currentEmpresa = value;
                base.NotifyPropertyChanged(propertyName: "currentEmpresa");
            }
        }

        private funcionarioService.FuncionarioModel _currentFuncionario;

        public funcionarioService.FuncionarioModel currentFuncionario
        {
            get { return _currentFuncionario; }
            set
            {
                _currentFuncionario = value;
                base.NotifyPropertyChanged(propertyName: "currentFuncionario");
            }
        }


        #endregion

        #region Methods
        #region Criação de Menu

        private List<MenuItemModel> currentMenu;

        private List<MenuItemModel> _lMenus;

        public List<MenuItemModel> lMenu
        {
            get { return _lMenus; }
            set { _lMenus = value; }
        }

        private void AddMenuItem(string xNome, string xHeader, bool bLast)
        {
            if (currentMenu.Count(i => i.xName == xNome) < 1)
            {
                this.currentMenu.Add(item:
                    new MenuItemModel
                    {
                        xHeader = bLast ? xHeader : xNome,
                        xName = xNome,
                        lItens = new List<MenuItemModel>()
                    });
            }

            this.currentMenu = this.currentMenu.FirstOrDefault(i => i.xName == xNome).lItens;
        }

        public void CarregaMenu(System.Windows.Controls.Menu m)
        {
            try
            {
                this.AddMenusItens(lMenuItens: this.lMenu, menuItem: m.Items);
                Stack<object> listaMenus = new Stack<object>();

                foreach (var item in m.Items)
                {
                    listaMenus.Push(item);
                }
                foreach (var item in listaMenus)
                {
                    m.Items.Remove(item);
                }
                int icount = 0;
                foreach (var item in listaMenus)
                {
                    if (item.GetType() == typeof(System.Windows.Controls.MenuItem))
                    {
                        (item as System.Windows.Controls.MenuItem).Focusable = false;
                        ResourceDictionary rs = new ResourceDictionary
                        {
                            Source = new Uri(uriString: "pack://application:,,,/HLP.Comum.Resources;component/Styles/mainStyle.xaml")
                        };
                        (item as System.Windows.Controls.MenuItem).Style = rs["MenuItemPrincipal"] as Style;
                    }

                    m.Items.Insert(icount, item);
                    icount++;
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void AddMenusItens(List<MenuItemModel> lMenuItens, ItemCollection menuItem)
        {
            foreach (MenuItemModel it in lMenuItens)
            {
                System.Windows.Controls.MenuItem mi = new System.Windows.Controls.MenuItem();

                string sPath = System.AppDomain.CurrentDomain.BaseDirectory + @"Icones\" + it.xName + ".png";
                if (File.Exists(path: sPath))
                {
                    mi.Icon =
                    new System.Windows.Controls.Image
                    {
                        Source = new BitmapImage(new Uri(sPath))
                    };
                }

                mi.Header = it.xHeader;
                mi.Command = this.AddWindowCommand;
                mi.CommandParameter = it.xName;
                menuItem.Add(newItem: mi);
                if (it.lItens.Count > 0)
                    AddMenusItens(lMenuItens: it.lItens, menuItem: mi.Items);
            }
        }

        #endregion

        public void FindAll()
        {
            Window win = GerenciadorModulo.Instancia.CarregaForm("WinFindAll", Modules.Interface.TipoExibeForm.Modal);
            win.SetPropertyValue("AddWindowCommand", this.AddWindowCommand);
            win.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            win.ShowDialog();
        }
        private string getHeaderWindow(string xNomeForm)
        {
            Window w;
            try
            {
                w = GerenciadorModulo.Instancia.CarregaForm(nome: xNomeForm.ToString(),
                exibeForm: Modules.Interface.TipoExibeForm.Modal);
                return w != null ? w.Title : xNomeForm;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                w = null;
            }
        }
        #endregion

    }
}
