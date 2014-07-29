using HLP.Base.ClassesBases;
using HLP.Base.Modules;
using HLP.Base.Static;
using HLP.ComumView.Model.Model;
using HLP.ComumView.ViewModel.ViewModel;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.Services.Gerais;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HLP.ComumView.ViewModel.Commands
{
    public class wdMainCommands
    {
        wdMainViewModel vm;
        CidadeService objCidadeService;

        public wdMainCommands(wdMainViewModel objVm)
        {
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
            this.vm.ConnectionConfigCommand = new RelayCommand(execute: i => this.ShowConfigConnection(win: i));            
            this.vm.SobreCommand = new RelayCommand(execute: i => this.Sobre());
            this.vm.FindAllCommand = new RelayCommand
                (
                execute: ex => vm.FindAll(),
                canExecute: can => true
                );
            this.vm.changeStConnection = new RelayCommand(
                execute: i => this.ChangeStConnectionExec());
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
            catch (Exception ex)
            {
                throw ex;
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
            Application.Current.Shutdown();
        }

        private bool SairCanExecute()
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

    }
}
