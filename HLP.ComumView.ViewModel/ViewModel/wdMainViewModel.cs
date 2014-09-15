using HLP.Base.ClassesBases;
using HLP.Base.Modules;
using HLP.Base.Static;
using HLP.Components.Model.Models;
using HLP.Comum.ViewModel.ViewModel;
using HLP.ComumView.Model.Model;
using HLP.ComumView.ViewModel.Commands;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.Services.Gerais;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HLP.ComumView.ViewModel.ViewModel
{
    public class wdMainViewModel : viewModelComum<mainMenuModel>
    {

        private Popup _popUpSearchField;

        public Popup popUpSearchField
        {
            get { return _popUpSearchField; }
            set { _popUpSearchField = value; }
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

        public bool VerifyErrorsWindow()
        {
            PropertyInfo pi = this.winMan._currentTab._currentDataContext.GetType().GetProperty(name: "currentModel");

            if (pi != null)
            {
                object currentModel = pi.GetValue(obj: this.winMan._currentTab._currentDataContext);

                MethodInfo miGetErros = currentModel.GetType().GetMethod(name: "GetErrors",
                    bindingAttr: BindingFlags.Instance | BindingFlags.NonPublic
                    );

                if (miGetErros != null)
                {
                    List<ErrorsModel> lErrors = miGetErros.Invoke(obj: currentModel, parameters: new object[] { }) as List<ErrorsModel>;

                    if (this.winMan._currentTab.lErrorsToView == null)
                    {
                        this.winMan._currentTab.lErrorsToView = new ObservableCollection<ErrorsModel>(
                            list: lErrors);
                    }
                    else if (this.winMan._currentTab.lErrorsToView.Count != lErrors.Count)
                        this.winMan._currentTab.lErrorsToView = new ObservableCollection<ErrorsModel>(
                            list: lErrors);

                    this.winMan._currentTab.currentErrorsCount = this.winMan._currentTab.lErrorsToView.Count;

                    if (this.winMan._currentTab.lErrorsToView.Count > 0)
                        return false;
                }


            }

            return true;
        }

        public void CleanListErrors()
        {
            this.winMan._currentTab.lErrorsToView = new ObservableCollection<ErrorsModel>();
            this.winMan._currentTab.currentErrorsCount = 0;
        }

        public void PopulateStaticCidades()
        {
            comm.PopulateStaticCidades();
        }

        public void FindAll()
        {
            Window win = GerenciadorModulo.Instancia.CarregaForm("WinFindAll", Base.InterfacesBases.TipoExibeForm.Modal);
            if (win != null)
            {
                win.SetPropertyValue("AddWindowCommand", this.AddWindowCommand);
                win.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                win.ShowDialog();
            }
            else
            {
                MessageHlp.Show(StMessage.stAlert, "Window não encontrado.");
            }
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

        public ICommand commOpenSubMenu { get; set; }
        public ICommand commOpenItem { get; set; }
        public ICommand commOpenItemNavegacao { get; set; }
        public ICommand commCloseWindow { get; set; }
        public ICommand commMinimizeWindow { get; set; }
        public ICommand commOpenPopUpSearchField { get; set; }
        public ICommand commCloseAllPopUps { get; set; }
        public ICommand commSearchComp { get; set; }
        public ICommand commOpenConfig { get; set; }

        wdMainCommands comm;

        private WinManModel _winMan;
        public WinManModel winMan
        {
            get { return _winMan; }
            set { _winMan = value; base.NotifyPropertyChanged("winMan"); }
        }

        private TabControl _tabWindows;

        public TabControl tabWindows
        {
            get { return _tabWindows; }
            set
            {
                _tabWindows = value;
                base.NotifyPropertyChanged(propertyName: "tabWindows");
            }
        }

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

        public void CarregaDadosLogin()
        {
            this.currentEmpresa = this.objService.GetObject(id: CompanyData.idEmpresa);
        }

        public bool bXSearchLabelsChanged { get; set; }

        private string _xSearchLabels;

        public string xSearchLabels
        {
            get { return _xSearchLabels; }
            set
            {
                _xSearchLabels = value;
                this.bXSearchLabelsChanged = true;
            }
        }


        public wdMainViewModel()
        {
            this.lMenu = new ObservableCollection<mainMenuModel>();
            objService = new EmpresaService();

            comm = new wdMainCommands(objVm: this);
            this.navegacao = new StackPanel();
            this.navegacao.Orientation = Orientation.Horizontal;

            string xNamespace = string.Empty;
            ObservableCollection<mainMenuModel> currentMenu = lMenu;
            mainMenuModel newMenu = null;
            int cont;

            #region Carregamento de Menus

            foreach (ObjectsModule m in Modulo.lobjectModulo)
            {
                foreach (objectForm win in m.lFormularios)
                {
                    xNamespace = win.xType.Split(separator: ',')[0].Replace(
                        oldValue: win.xType.Split(separator: ',')[1].Replace(oldValue: " ", newValue: "") + ".",
                        newValue: string.Empty);
                    cont = 0;

                    foreach (string subs in xNamespace.Split(separator: '.'))
                    {
                        cont++;
                        if (currentMenu.Count(i => i.nameWindow == subs) > 0)
                        {
                            currentMenu = currentMenu.FirstOrDefault(i => i.nameWindow == subs)
                                .lSubItens;
                        }
                        else
                        {
                            newMenu = new mainMenuModel
                            {
                                nameWindow = subs,
                                xCaption = cont == xNamespace.Split(separator: '.').Count() ?
                                string.Concat(win.xName.Replace('_', ' ').Select(c => char.IsUpper(c) ? " " + c.ToString() : c.ToString()))
                                        .TrimStart()
                                : string.Concat(subs.Select(c => char.IsUpper(c) ? " " + c.ToString() : c.ToString()))
                                        .TrimStart()
                            };

                            currentMenu.Add(item: newMenu);

                            currentMenu = newMenu.lSubItens;
                        }
                    }

                    currentMenu = lMenu;
                }
            }



            List<CustomPesquisaModel> _lItems = new List<CustomPesquisaModel>();

            this.PercorreItensMenu(l: _lItems, lMenu: this.lMenu.ToList(), xPath: string.Empty);

            this.lAllItemsMenu = _lItems;
            #endregion

            winMan = new WinManModel();
            this.tabWindows = new TabControl();

            this.bwFocus = new BackgroundWorker();
            this.bwFocus.WorkerSupportsCancellation = true;
            this.bwFocus.DoWork += bwFocus_DoWork;
            this.bwFocus.RunWorkerCompleted += bwFocus_RunWorkerCompleted;
        }

        private void PercorreItensMenu(List<CustomPesquisaModel> l, List<mainMenuModel> lMenu, string xPath)
        {
            foreach (mainMenuModel i in lMenu)
            {
                if (i.lSubItens.Count > 0)
                    this.PercorreItensMenu(l: l, lMenu: i.lSubItens.ToList(), xPath: string.Format(
                        format: @"{0}\{1}", arg0: xPath, arg1: i.xCaption));
                else
                    l.Add(item: new CustomPesquisaModel
                        {
                            xDisplay = string.Format(format: @"{0}\{1}", arg0: xPath, arg1: i.xCaption)
                        });
            }
        }

        public void FilterItensMenu(object sender, FilterEventArgs e)
        {
            if (this.xTextCbx == null)
                return;

            if ((e.Item as CustomPesquisaModel).xDisplay.ToUpper().Contains(
                value: this.xTextCbx.ToUpper()))
                e.Accepted = true;
            else
                e.Accepted = false;
        }

        private string _xTextCbx;

        public string xTextCbx
        {
            get { return _xTextCbx; }
            set
            {
                _xTextCbx = value;
                base.NotifyPropertyChanged(propertyName: "xTextCbx");

                CollectionViewSource cvs = Application.Current.MainWindow.FindResource(resourceKey: "cvsItensMenu")
                    as CollectionViewSource;

                cvs.Filter += this.FilterItensMenu;

                (Application.Current.MainWindow.FindName(name: "cbxItemsMenu") as ComboBox).IsDropDownOpen = true;
            }
        }

        private ObservableCollection<mainMenuModel> _lMenu;

        public ObservableCollection<mainMenuModel> lMenu
        {
            get { return _lMenu; }
            set
            {
                _lMenu = value;
                base.NotifyPropertyChanged(propertyName: "lMenu");
            }
        }

        private List<CustomPesquisaModel> _lAllItemsMenu;

        public List<CustomPesquisaModel> lAllItemsMenu
        {
            get { return _lAllItemsMenu; }
            set
            {
                _lAllItemsMenu = value;
                base.NotifyPropertyChanged(propertyName: "lAllItemsMenu");
            }
        }


        private CustomPesquisaModel _selectedFilteredItem;

        public CustomPesquisaModel selectedFilteredItem
        {
            get { return _selectedFilteredItem; }
            set
            {
                _selectedFilteredItem = value;
                base.NotifyPropertyChanged(propertyName: "selectedFilteredItem");

                if (value != null)
                {
                    int count = 0;
                    foreach (string x in value.xDisplay.Split(separator: '\\'))
                    {
                        if (x != "")
                        {
                            count++;

                            if (count == 1)
                            {
                                this.commOpenSubMenu.Execute(parameter: x);
                            }
                            else
                            {
                                this.commOpenItem.Execute(parameter: x);
                            }
                        }
                    }
                }
            }
        }


        private mainMenuModel _selectedMenu;

        public mainMenuModel selectedMenu
        {
            get { return _selectedMenu; }
            set
            {
                _selectedMenu = value;
                base.NotifyPropertyChanged(propertyName: "selectedMenu");
            }
        }

        private ObservableCollection<mainMenuModel> _lSubMenu;

        public ObservableCollection<mainMenuModel> lSubMenu
        {
            get { return _lSubMenu; }
            set
            {
                _lSubMenu = value;
                base.NotifyPropertyChanged(propertyName: "lSubMenu");
            }
        }

        private mainMenuModel _selectedSubMenu;

        public mainMenuModel selectedSubMenu
        {
            get { return _selectedSubMenu; }
            set
            {
                _selectedSubMenu = value;
                base.NotifyPropertyChanged(propertyName: "selectedSubMenu");
            }
        }

        private StackPanel _navegacao;

        public StackPanel navegacao
        {
            get { return _navegacao; }
            set
            {
                _navegacao = value;
                base.NotifyPropertyChanged(propertyName: "navegacao");
            }
        }

        #region Set Focus

        Stack<FrameworkElement> lTabControls;
        public BackgroundWorker bwFocus { get; set; }

        void bwFocus_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
                (e.Result as FrameworkElement).Focus();

        }

        void bwFocus_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument != null)
                this.GetAllParentsComp(comp: e.Argument as FrameworkElement);

            FrameworkElement f = null;

            while (lTabControls.Count > 0)
            {
                f = lTabControls.Pop();

                if (f.GetType() == typeof(TabControl))
                {
                    FrameworkElement fTabItem = null;
                    FrameworkElement fAux = null;

                    while (fTabItem == null && this.lTabControls.Count > 0)
                    {
                        fAux = lTabControls.Pop();
                        if (fAux.GetType() == typeof(TabItem))
                            fTabItem = fAux;
                    }

                    if (fTabItem != null)
                    {
                        Application.Current.Dispatcher.BeginInvoke((Action)(()
                            =>
                        {
                            (f as TabControl).SelectedItem = fTabItem;
                        }));
                        Thread.Sleep(millisecondsTimeout: 500);
                    }
                }
            }

            e.Result = e.Argument;
        }

        public void FocusOnComponent(object comp)
        {
            lTabControls = new Stack<FrameworkElement>();

            if (!bwFocus.IsBusy)
                this.bwFocus.RunWorkerAsync(argument: comp);
        }

        private void GetAllParentsComp(FrameworkElement comp)
        {
            if (comp.Parent == null)
                return;
            else
            {
                if (comp.GetType() == typeof(TabControl) || comp.GetType() == typeof(TabItem))
                    this.lTabControls.Push(item: comp as FrameworkElement);

                this.GetAllParentsComp(comp: comp.Parent as FrameworkElement);
            }
        }

        #endregion
    }
}
