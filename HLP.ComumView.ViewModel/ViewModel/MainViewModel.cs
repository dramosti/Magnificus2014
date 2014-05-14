using HLP.Base.ClassesBases;
using HLP.Base.Modules;
using HLP.Base.Static;
using HLP.ComumView.Model.Model;
using HLP.ComumView.ViewModel.Commands;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.Services.Gerais;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace HLP.ComumView.ViewModel.ViewModel
{
    public class MainViewModel : ViewModelBase<WinManModel>
    {

        EmpresaService objService;
        wcf_Funcionario.Iwcf_FuncionarioClient funcionarioService = new wcf_Funcionario.Iwcf_FuncionarioClient();


        private StConnection _stConnection;

        public StConnection stConnection
        {
            get { return _stConnection; }
            set
            {
                _stConnection = value;
                base.NotifyPropertyChanged(propertyName: "stConnection");                
            }
        }


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
            objService = new EmpresaService();
            winMan = new WinManModel();
           
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
            //this.currentFuncionario = funcionarioService.getFuncionario(idFuncionario: UserData.idUser);
            this.currentEmpresa = this.objService.GetObject(id: CompanyData.idEmpresa);
            //this.sizeColunaDados = this.currentFuncionario.xNome.Length * 10;
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
        public ICommand FindAllCommand { get; set; }
        public ICommand SobreCommand { get; set; }
        public ICommand OpenCtxCommand { get; set; }
        public ICommand TrocarUsuarioCommand { get; set; }
        public ICommand TrocarEmpresaCommand { get; set; }
        public ICommand SairCommand { get; set; }
        public ICommand ConnectionConfigCommand { get; set; }
        public ICommand changeStConnection { get; set; }

        #endregion

        #region Informações Usuário e Empresa


        private EmpresaModel _currentEmpresa;

        public EmpresaModel currentEmpresa
        {
            get { return _currentEmpresa; }
            set
            {
                _currentEmpresa = value;
                base.NotifyPropertyChanged(propertyName: "currentEmpresa");
            }
        }

        private wcf_Funcionario.FuncionarioModel _currentFuncionario;

        public wcf_Funcionario.FuncionarioModel currentFuncionario
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
            string header = bLast ? string.Concat(xHeader.Select(c => char.IsUpper(c) ? " " + c.ToString() : c.ToString()))
                .TrimStart() : string.Concat(xNome.Select(c => char.IsUpper(c) ? " " + c.ToString() : c.ToString()))
                .TrimStart();

            if (currentMenu.Count(i => i.xName == xNome) < 1)
            {
                this.currentMenu.Add(item:
                    new MenuItemModel
                    {
                        xHeader = header,
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
                            Source = new Uri(uriString: "pack://application:,,,/HLP.Resources.View.WPF;component/Styles/Components/UserControlStyles.xaml")
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
            Window win = GerenciadorModulo.Instancia.CarregaForm("WinFindAll", Base.InterfacesBases.TipoExibeForm.Modal);
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
                    exibeForm: Base.InterfacesBases.TipoExibeForm.Modal);
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
