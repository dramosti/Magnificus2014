using HLP.Base.ClassesBases;
using HLP.Base.Modules;
using HLP.Base.Static;
using HLP.Comum.ViewModel.ViewModel;
using HLP.ComumView.Model.Model;
using HLP.ComumView.ViewModel.ViewModel;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.Services.Gerais;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace HLP.ComumView.ViewModel.Commands
{
    public class wdMainCommands
    {
        wdMainViewModel vm;
        CidadeService objCidadeService;
        ResourceDictionary resource;

        public wdMainCommands(wdMainViewModel objVm)
        {
            resource = new ResourceDictionary
            {
                Source = new Uri("/HLP.Resources.View.WPF;component/Styles/Components/UserControlStyles.xaml", UriKind.RelativeOrAbsolute)
            };
            this.vm = objVm;
            objCidadeService = new CidadeService();

            vm.commOpenSubMenu = new RelayCommand(execute: e => this.OpenMenuExec(xNamespace: e));
            vm.commOpenItem = new RelayCommand(execute: e => this.OpenItemExec(xNamespace: e));
            vm.commOpenItemNavegacao = new RelayCommand(execute: e => this.OpenItemNavegacao(obj: e),
                canExecute: cE => this.OpenItemNavegacaoCanExec(obj: cE));
            this.vm.AddWindowCommand = new RelayCommand(
                    execute: ex => AddWindow(xForm: ex),
                    canExecute: ex => AddWindowCanExecute(xForm: ex));
            this.vm.DelWindowCommand = new RelayCommand(
                    execute: ex => DelWindow(tabItem: ex),
                    canExecute: ex => DelWindowCanExecute());
            this.vm.OpenCtxCommand = new RelayCommand(execute: i => this.OpenCtx(ctx: i));
            this.vm.fecharCommand = new RelayCommand(execute: i => this.Sair());
            this.vm.commMinimizeWindow = new RelayCommand(execute: i => this.MinimizeExecute());
            this.vm.ConnectionConfigCommand = new RelayCommand(execute: i => this.ShowConfigConnection(win: i));
            this.vm.SobreCommand = new RelayCommand(execute: i => this.Sobre());
            this.vm.FindAllCommand = new RelayCommand
                (
                execute: ex => vm.FindAll(),
                canExecute: can => true
                );
            this.vm.changeStConnection = new RelayCommand(
                execute: i => this.ChangeStConnectionExec());
            this.vm.commCloseWindow = new RelayCommand(execute: i => this.Sair(), canExecute: i => this.SairCanExecute());

            this.vm.commOpenPopUpSearchField = new RelayCommand(execute: ex => this.OpenPopUpSearchField());

            this.vm.commCloseAllPopUps = new RelayCommand(execute: ex => this.CloseAllPopUpsExecute());

            this.vm.commSearchComp = new RelayCommand(execute: ex => this.SearchCompExecute(), canExecute: canExec => this.SearchCompCanExecute());

            this.vm.commOpenConfig = new RelayCommand(execute: ex => this.OpenConfig());
        }

        private void OpenConfig()
        {
            Window form = GerenciadorModulo.Instancia.CarregaForm(nome: "wdConfig", exibeForm: Base.InterfacesBases.TipoExibeForm.Modal);

            if (form != null)
                if (form.ShowDialog() == true)
                {
                    System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                    Application.Current.Shutdown();
                }
        }

        private void OpenItemNavegacao(object obj)
        {
            if (obj != null)
            {
                vm.lSubMenu = ((obj as Button).Tag as mainMenuModel).lSubItens;

                int index = vm.navegacao.Children.IndexOf(element: obj as Button);

                vm.navegacao.Children.RemoveRange(index: index + 1,
                    count: vm.navegacao.Children.Count - (index + 1));
            }
        }
        private bool OpenItemNavegacaoCanExec(object obj)
        {
            if (vm.navegacao.Children.Count > 0)
            {
                return vm.navegacao.Children[index:
                vm.navegacao.Children.Count - 1] != obj;
            }

            return false;
        }

        private void OpenMenuExec(object xNamespace)
        {
            mainMenuModel m = vm.lMenu.FirstOrDefault(i => i.xCaption == xNamespace.ToString());

            vm.selectedMenu = m;
            vm.selectedSubMenu = null;

            vm.lSubMenu = m.lSubItens;

            this.vm.navegacao = new StackPanel();
            this.vm.navegacao.Orientation = Orientation.Horizontal;
            Button btn = new Button();

            btn.Content = vm.selectedMenu.xCaption;
            btn.Tag = vm.selectedMenu;
            btn.Command = this.vm.commOpenItemNavegacao;
            btn.CommandParameter = btn;
            btn.Style = resource[key: "Button_NAVEGACAO_MENU"] as Style;


            this.vm.navegacao.Children.Add(element: btn);
        }
        private void OpenItemExec(object xNamespace)
        {
            mainMenuModel m = null;

            if (vm.selectedMenu.lSubItens.Count(i => i.xCaption == xNamespace.ToString()) > 0)
            {
                m = vm.selectedMenu.lSubItens.FirstOrDefault(
                    i => i.xCaption == xNamespace.ToString());
            }
            else
            {
                m = ((vm.navegacao.Children[index: vm.navegacao.Children.Count - 1]
                    as Button).Tag as mainMenuModel).lSubItens.FirstOrDefault(i => i.xCaption == xNamespace.ToString());
            }


            if (m != null)
            {
                if (m.lSubItens.Count > 0)
                {
                    Button btn = new Button();
                    btn.Content = m.xCaption;
                    btn.Tag = m;
                    btn.Command = this.vm.commOpenItemNavegacao;
                    btn.CommandParameter = btn;
                    btn.Style = resource[key: "Button_NAVEGACAO_MENU"] as Style;
                    vm.navegacao.Children.Add(element: btn);
                    vm.lSubMenu = m.lSubItens;
                }
                vm.selectedSubMenu = m;
            }
        }

        #region Executes & CanExecutes

        private void ChangeStConnectionExec()
        {
            if (MessageBox.Show(messageBoxText: "Essa mudança necessita que todas as Janelas abertas sejam fechadas." + Environment.NewLine +
                    "Deseja continuar?", caption: "Atenção?", button: MessageBoxButton.YesNo,
                    icon: MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                this.vm.winMan._lTabPagesAtivas = new ObservableCollection<TabPagesAtivasModel>();
                if (Sistema.bOnline == StConnection.OnlineNetwork)
                    this.vm.stConnection = Sistema.bOnline = StConnection.OnlineWeb;
                else
                    if (Sistema.bOnline == StConnection.OnlineWeb)
                        this.vm.stConnection = Sistema.bOnline = StConnection.OnlineNetwork;
            }
            else
            {
                this.vm.stConnection = this.vm.stConnection;
            }
        }
        private void ShowConfigConnection(object win)
        {
            try
            {
                if (MessageBox.Show("A mudança de conexão irá reiniciar o sistema, deseja continuar ?", "A V I S O", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    Window winConfig = GerenciadorModulo.Instancia.CarregaForm("WinSelectConnection", Base.InterfacesBases.TipoExibeForm.Modal);
                    winConfig.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    winConfig.ShowDialog();

                    object bProssegue = winConfig.GetPropertyValue("bProssegue");
                    if ((bool)bProssegue)
                    {
                        Window winPrincipal = win as Window;
                        System.Windows.Forms.Application.Restart();
                        winPrincipal.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void Sobre()
        {
            Window win = GerenciadorModulo.Instancia.CarregaForm("WinSobre", Base.InterfacesBases.TipoExibeForm.Modal);
            win.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            win.ShowDialog();
        }

        private bool SobreCanExecute()
        {
            return true;
        }
        private void OpenCtx(object ctx)
        {
            if (ctx != null)
                (ctx as ContextMenu).IsOpen = true;
        }
        private bool OpenCtxCanExecute()
        {
            return true;
        }

        private void AddWindow(object xForm)
        {
            try
            {
                TabControl tc = Application.Current.MainWindow.FindName(name: "mainTabControl") as TabControl;

                tc.SelectedIndex = 1;

                Window form = GerenciadorModulo.Instancia.CarregaForm(nome: xForm != null ? xForm.ToString() :
                    this.vm.selectedSubMenu.nameWindow, exibeForm: Base.InterfacesBases.TipoExibeForm.Modal);

                if (form != null)
                {
                    if ((xForm != null ? xForm.ToString() :
                        this.vm.selectedSubMenu.nameWindow).Equals("WinConnectionConfig"))
                    {
                        form.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                        form.ShowDialog();
                    }
                    else
                    {
                        TabPagesAtivasModel objTabPageAtivasModel = new TabPagesAtivasModel();

                        objTabPageAtivasModel._windows = form;

                        //this.GetComponents(comp: form.Content as FrameworkElement, lComps: objTabPageAtivasModel.lComponents);

                        //foreach (FrameworkElement txt in objTabPageAtivasModel.lComponents
                        //.Where(i => i.GetType() == typeof(TextBlock)
                        //|| i.GetType().BaseType == typeof(TextBlock)).ToList())
                        //{
                        //    objTabPageAtivasModel.lTextBlock.Add(item: txt as TextBlock);
                        //}

                        //objTabPageAtivasModel.lComponents.RemoveAll(i => i.GetType().BaseType == typeof(TextBlock)
                        //    || i.GetType().BaseType == typeof(TextBlock));

                        //FrameworkElement compPriorComp = null;
                        //TabItem tiPriorComp = null;
                        //TabItem tiCurrentComp = null;
                        //PropertyInfo piIsReadOnly = null;

                        //foreach (FrameworkElement comp in objTabPageAtivasModel.lComponents)
                        //{
                        //    tiCurrentComp = Util.GetParent(comp: comp, t: typeof(TabItem)) as TabItem;

                        //    if (tiCurrentComp != tiPriorComp && compPriorComp != null)
                        //    {
                        //        PropertyInfo pi = compPriorComp.GetType().GetProperty(name: "actionOnLostFocus");

                        //        if (pi != null)
                        //        {
                        //            Action<object> actionFocusNextTabComp = this.vm.FocusOnComponent;

                        //            try
                        //            {
                        //                pi.SetValue(obj: compPriorComp, value: actionFocusNextTabComp);

                        //                piIsReadOnly = comp.GetType().GetProperty(name: "IsReadOnly");

                        //                if (piIsReadOnly != null)
                        //                    if ((bool)piIsReadOnly.GetValue(obj: comp) == false)
                        //                    {
                        //                        tiPriorComp = tiCurrentComp;

                        //                        PropertyInfo piParameterAction = compPriorComp.GetType().GetProperty(name: "actionParameter");

                        //                        if (piParameterAction != null)
                        //                        {
                        //                            piParameterAction.SetValue(obj: compPriorComp, value: comp);
                        //                        }
                        //                    }
                        //            }
                        //            catch (Exception ex)
                        //            {

                        //                throw ex;
                        //            }
                        //        }
                        //    }

                        //    compPriorComp = comp;
                        //}

                        //FrameworkElement fe = objTabPageAtivasModel.lComponents
                        //    .Where(i => i.GetType().Name == "CustomTextBox"
                        //    || i.GetType().Name == "CustomCheckBox"
                        //    || i.GetType().Name == "CustomComboBox"
                        //    || i.GetType().Name == "ucTextBoxIntellisense"
                        //    || i.GetType() == typeof(DataGrid)
                        //    || i.GetType().BaseType == typeof(DataGrid)).LastOrDefault();

                        //if (fe != null)
                        //{
                        //    PropertyInfo pi = fe.GetType().GetProperty(name: "actionOnLostFocus");

                        //    if (pi != null)
                        //    {
                        //        PropertyInfo piComm = objTabPageAtivasModel._currentDataContext.GetType().GetProperty(name: "commandSalvar");

                        //        if (piComm != null)
                        //        {
                        //            ICommand comm = piComm.GetValue(objTabPageAtivasModel._currentDataContext)
                        //                as ICommand;

                        //            if (comm != null)
                        //            {
                        //                pi.SetValue(obj: fe,
                        //                    value: comm);
                        //            }
                        //        }
                        //    }
                        //}

                        //Action<object> actionFocusFirstComponent = this.vm.FocusOnComponent;

                        //objTabPageAtivasModel._currentDataContext.GetType().GetProperty(name: "focusFirstComponent")
                        //    .SetValue(obj: objTabPageAtivasModel._currentDataContext,
                        //    value: actionFocusFirstComponent);

                        //piIsReadOnly = null;

                        //foreach (FrameworkElement item in objTabPageAtivasModel.lComponents)
                        //{
                        //    piIsReadOnly = item.GetType().GetProperty(name: "IsReadOnly");

                        //    if (piIsReadOnly != null)
                        //        if ((bool)piIsReadOnly.GetValue(obj: item) == false)
                        //        {
                        //            objTabPageAtivasModel._currentDataContext.GetType().GetProperty(name: "firstControl")
                        //    .SetValue(obj: objTabPageAtivasModel._currentDataContext,
                        //    value: item);
                        //            break;
                        //        }

                        //}

                        //foreach (DataGrid dg in objTabPageAtivasModel.lComponents.Where(i => i.GetType() == typeof(DataGrid)
                        //    || i.GetType().BaseType == typeof(DataGrid)))
                        //{
                        //    objTabPageAtivasModel.lDataGrids.Add(item: dg);
                        //}

                        //objTabPageAtivasModel.lComponents.RemoveAll(i => i.GetType() == typeof(DataGrid)
                        //    || i.GetType().BaseType == typeof(DataGrid));

                        if (this.vm.winMan._lTabPagesAtivas.Count(
                            i => i._windows.Name == form.Name) == 0)
                        {
                            this.vm.winMan._lTabPagesAtivas.Add(item: objTabPageAtivasModel);
                        }

                        this.vm.winMan._currentTab = objTabPageAtivasModel;
                        this.vm.winMan.vToolBar = Visibility.Visible;
                        this.vm.winMan.iHeightToolBar = 30;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void GetComponents(FrameworkElement comp, List<FrameworkElement> lComps)
        {
            Type tCompChield = null;
            Type tComp = comp.GetType();

            if (tComp.BaseType == typeof(Panel))
            {
                foreach (FrameworkElement compChield in (comp as Panel).Children)
                {
                    tCompChield = compChield.GetType();
                    if (tCompChield.BaseType != typeof(Panel)
                        && tCompChield != typeof(Expander)
                        && tCompChield != typeof(TabControl)
                        && tCompChield != typeof(Border)
                        && tCompChield != typeof(ScrollViewer)
                        && tCompChield.BaseType != typeof(UserControl)
                        && tCompChield != typeof(GridSplitter))
                    {
                        lComps.Add(item: compChield);
                    }

                    this.GetComponents(comp: compChield, lComps: lComps);
                }
            }
            else if (tComp == typeof(Expander))
            {
                this.GetComponents(comp: (comp as Expander).Content as FrameworkElement, lComps: lComps);
            }
            else if (tComp == typeof(TabControl))
            {
                foreach (FrameworkElement compChield in (comp as TabControl).Items)
                {
                    this.GetComponents(comp: compChield, lComps: lComps);
                }
            }
            else if (tComp == typeof(TabItem))
            {
                this.GetComponents(comp: (comp as TabItem).Content as FrameworkElement, lComps: lComps);
            }
            else if (tComp == typeof(AdornerDecorator))
            {
                this.GetComponents(comp: (comp as AdornerDecorator).Child as FrameworkElement,
                    lComps: lComps);
            }
            else if (tComp == typeof(ScrollViewer))
            {
                this.GetComponents(comp: (comp as ScrollViewer).Content as FrameworkElement, lComps: lComps);
            }
            //else if ()
            //{
            //    //this.GetComponents(comp: (comp as UserControl).Content as FrameworkElement, lComps: lComps);
            //    lComps.Add(item: comp);
            //}
            else if (tComp.BaseType == typeof(DataGrid)
                || tComp == typeof(DataGrid) || tComp.BaseType == typeof(UserControl))
            {
                lComps.Add(item: comp);
            }
        }

        private bool AddWindowCanExecute(object xForm)
        {
            if (this.vm.selectedSubMenu == null && xForm == null)
                return false;

            bool bReturn = true;
            if (this.vm.winMan._currentTab != null)
                if (this.vm.winMan._currentTab._windows != null)
                    if (this.vm.winMan._currentTab._windows.Name == (xForm != null ? xForm.ToString() :
                    this.vm.selectedSubMenu.nameWindow))
                        bReturn = false;
            return bReturn;
        }

        private void DelWindow(object tabItem)
        {
            try
            {
                this.vm.winMan._lTabPagesAtivas.Remove(item: tabItem as TabPagesAtivasModel);
                if (vm.winMan._lTabPagesAtivas.Count() == 0)
                {
                    this.vm.winMan.vToolBar = Visibility.Collapsed;
                    this.vm.winMan.iHeightToolBar = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool DelWindowCanExecute()
        {
            return true;
        }

        private void TrocarUsuario()
        {
        }

        private bool TrocarUsuarioCanExecute()
        {
            return true;
        }

        private void TrocarEmpresa()
        {
        }

        private bool TrocarEmpresaCanExecute()
        {
            return true;
        }

        private void Sair()
        {
            if (MessageHlp.Show(stMessage: StMessage.stYesNo, xMessageToUser: "Deseja encerrar a aplicação?")
                == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private bool SairCanExecute()
        {
            return true;
        }

        private void MinimizeExecute()
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private bool MinimizeCanExecute()
        {
            return true;
        }

        public void PopulateStaticCidades()
        {
            if (Sistema.lCidades == null)
                Sistema.lCidades = new List<BasicModel>();

            foreach (CidadeModel objCidade in this.objCidadeService.GetAllCidades())
            {
                Sistema.lCidades.Add(item:
                    new BasicModel
                    {
                        id = objCidade.idCidade ?? 0,
                        xDisplay = objCidade.xCidade
                    });
            }
        }

        #endregion

        private void OpenPopUpSearchField()
        {
            if (this.vm != null)
                if (this.vm.popUpSearchField != null && this.vm.winMan._currentTab != null)
                {
                    this.vm.popUpSearchField.IsOpen = true;

                    TextBox txt = this.vm.popUpSearchField.FindName(name: "txt") as TextBox;

                    if (txt != null)
                        txt.Focus();
                }
        }

        private void CloseAllPopUpsExecute()
        {
            if (this.vm != null)
                if (this.vm.popUpSearchField != null)
                    this.vm.popUpSearchField.IsOpen = false;
        }

        private List<FrameworkElement> lTextBlockSearched;
        private TextBlock focusedTextBlock;
        int currentIndexLTextBlockSearched;

        private void SearchCompExecute()
        {
            if (this.vm.winMan != null)
                if (this.vm.winMan._currentTab != null)
                    if (this.vm.winMan._currentTab.lTextBlock != null)
                    {
                        if (focusedTextBlock != null)
                            focusedTextBlock.Background = System.Windows.Media.Brushes.Transparent;

                        if (this.vm.bXSearchLabelsChanged)
                        {
                            this.lTextBlockSearched = this.vm.winMan._currentTab.lTextBlock.Where(
                                i => (i as TextBlock)
                                .Text.ToUpper().Contains(value: this.vm.xSearchLabels.ToUpper())).ToList();
                            this.currentIndexLTextBlockSearched = -1;
                        }
                        this.vm.bXSearchLabelsChanged = false;

                        if (lTextBlockSearched != null)
                        {
                            if ((this.currentIndexLTextBlockSearched + 1) == this.lTextBlockSearched.Count)
                                this.currentIndexLTextBlockSearched = 0;

                            focusedTextBlock = this.lTextBlockSearched[index: this.currentIndexLTextBlockSearched + 1] as TextBlock;

                            if (focusedTextBlock != null)
                            {
                                var bc = new BrushConverter();
                                focusedTextBlock.Background = (System.Windows.Media.Brush)bc.ConvertFrom(value: "#4876FF");

                                this.vm.FocusOnComponent(comp: focusedTextBlock);
                            }
                            this.currentIndexLTextBlockSearched += 1;
                        }
                    }
        }

        private bool SearchCompCanExecute()
        {
            if (this.vm.bwFocus != null)
            {
                return !this.vm.bwFocus.IsBusy;
            }
            return false;
        }
    }
}
