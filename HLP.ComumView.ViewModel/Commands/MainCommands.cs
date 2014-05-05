using HLP.Base.ClassesBases;
using HLP.Base.Modules;
using HLP.Base.Static;
using HLP.ComumView.ViewModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HLP.ComumView.ViewModel.Commands
{
    public class MainCommands
    {
        MainViewModel objviewModel;

        public MainCommands(MainViewModel objTabPagesAtivasViewModel)
        {
            try
            {
                this.objviewModel = objTabPagesAtivasViewModel;

                this.objviewModel.AddWindowCommand = new RelayCommand(
                    execute: ex => AddWindow(xNomeForm: ex),
                    canExecute: ex => AddWindowCanExecute(xNomeForm: ex));
                this.objviewModel.DelWindowCommand = new RelayCommand(
                    execute: ex => DelWindow(tabItem: ex),
                    canExecute: ex => DelWindowCanExecute());
                this.objviewModel.OpenCtxCommand = new RelayCommand(execute: i => this.OpenCtx(ctx: i));
                this.objviewModel.fecharCommand = new RelayCommand(execute: i => this.Sair());
                this.objviewModel.ConnectionConfigCommand = new RelayCommand(execute: i => this.ShowConfigConnection());
                this.objviewModel.SobreCommand = new RelayCommand(execute: i => this.Sobre());
                this.objviewModel.FindAllCommand = new RelayCommand
                    (
                    execute: ex => objviewModel.FindAll(),
                    canExecute: can => true
                    );
                this.objviewModel.changeStConnection = new RelayCommand(
                    execute: i => this.ChangeStConnectionExec());


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #region Executes & CanExecutes

        private void ChangeStConnectionExec()
        {
            if (Sistema.bOnline == StConnection.OnlineNetwork)
                this.objviewModel.stConnection = Sistema.bOnline = StConnection.OnlineWeb;
            else
                if (Sistema.bOnline == StConnection.OnlineWeb)
                    this.objviewModel.stConnection = Sistema.bOnline = StConnection.OnlineNetwork;
        }

        private void ShowConfigConnection()
        {
            try
            {
                Window winConfig = GerenciadorModulo.Instancia.CarregaForm("WinConnectionConfig", Base.InterfacesBases.TipoExibeForm.Modal);
                winConfig.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                winConfig.ShowDialog();
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


        private void AddWindow(object xNomeForm)
        {
            try
            {
                Window form = GerenciadorModulo.Instancia.CarregaForm(nome: xNomeForm.ToString(), exibeForm: Base.InterfacesBases.TipoExibeForm.Modal);
                if (xNomeForm.ToString().Equals("WinConnectionConfig"))
                {
                    form.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    form.ShowDialog();
                }
                else
                {

                    TabPagesAtivasModel objTabPageAtivasModel = new TabPagesAtivasModel();
                    objTabPageAtivasModel._windows = form;

                    if (this.objviewModel.winMan._lTabPagesAtivas.Count(
                        i => i._windows.Name == form.Name) == 0)
                    {
                        this.objviewModel.winMan._lTabPagesAtivas.Add(item: objTabPageAtivasModel);
                    }
                    this.objviewModel.winMan._currentTab = objTabPageAtivasModel;
                    this.objviewModel.winMan.vToolBar = Visibility.Visible;
                    this.objviewModel.winMan.iHeightToolBar = 30;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private bool AddWindowCanExecute(object xNomeForm)
        {
            bool bReturn = true;
            if (this.objviewModel.winMan._currentTab != null)
                if (this.objviewModel.winMan._currentTab._windows != null)
                    if (this.objviewModel.winMan._currentTab._windows.Name == xNomeForm.ToString())
                        bReturn = false;
            return bReturn;
        }

        private void DelWindow(object tabItem)
        {
            try
            {
                this.objviewModel.winMan._lTabPagesAtivas.Remove(item: tabItem as TabPagesAtivasModel);
                if (objviewModel.winMan._lTabPagesAtivas.Count() == 0)
                {
                    this.objviewModel.winMan.vToolBar = Visibility.Collapsed;
                    this.objviewModel.winMan.iHeightToolBar = 0;
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


        #endregion
    }

}
