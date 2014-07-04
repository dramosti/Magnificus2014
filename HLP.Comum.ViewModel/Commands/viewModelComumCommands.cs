using HLP.Base.ClassesBases;
using HLP.Base.EnumsBases;
using HLP.Base.InterfacesBases;
using HLP.Base.Modules;
using HLP.Base.Static;
using HLP.Comum.Model.Models;
using HLP.Comum.Services;
using HLP.Comum.ViewModel.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HLP.Comum.ViewModel.Commands
{
    public class viewModelComumCommands<T> : INotifyPropertyChanged where T : class
    {
        BackgroundWorker bwFocus;
        public viewModelComum<T> objviewModel;
        DocumentosService objDocumentosService;

        #region NotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        public statusModel status { get; set; }
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            if (this.status == statusModel.nenhum)
                this.status = statusModel.alterado;
        }

        #endregion

        public viewModelComumCommands(object vViewModel)
        {
            this.objviewModel = vViewModel as viewModelComum<T>;
            this.objviewModel.novoBaseCommand = new RelayCommand(execute: pExec => this.novoBase(),
                canExecute: pCanExec => this.novoBaseCanExecute());
            this.objviewModel.alterarBaseCommand = new RelayCommand(execute: pExec => this.alterarBase(),
                canExecute: pCanExec => this.GenericCanExecute());
            this.objviewModel.deletarBaseCommand = new RelayCommand(execute: pExec => this.delBase(iRemoved: pExec),
                canExecute: pCanExec => this.GenericCanExecute());
            this.objviewModel.salvarBaseCommand = new RelayCommand(execute: pExec => this.salvarBase(),
                canExecute: pCanExec => this.salvarBaseCanExecute());
            this.objviewModel.cancelarBaseCommand = new RelayCommand(execute: pExec => this.cancelarBase(),
                canExecute: pCanExec => this.cancelarBaseCanExecute());
            this.objviewModel.copyBaseCommand = new RelayCommand(execute: pExec => this.CopyExecute(),
                canExecute: pCanExec => this.GenericCanExecute());
            this.objviewModel.fecharCommand = new RelayCommand(execute: pExec => this.Fechar(wd: pExec),
                canExecute: pCanExec => this.FecharCanExecute(wd: pCanExec));

            this.objviewModel.pesquisarBaseCommand = new RelayCommand(
                 execute: ex => ShowPesquisaExecute(),
                 canExecute: canExecute => ShowPesquisaCanEcexute());

            this.objviewModel.navegarBaseCommand = new RelayCommand(
               execute: exec => ExecAcao(ContentBotao: exec),
               canExecute: CanExec => CanExecAcao(ContentBotao: CanExec));

            bwFocus = new BackgroundWorker();
            bwFocus.DoWork += bwFocus_DoWork;
            bwFocus.RunWorkerCompleted += bwFocus_RunWorkerCompleted;

            this.objviewModel.bWorkerPesquisa.DoWork += bWorkerPesquisa_DoWork;
            this.objviewModel.bWorkerPesquisa.RunWorkerCompleted += bWorkerPesquisa_RunWorkerCompleted;

            this.objviewModel.bWorkerSave.DoWork += bWorkerSave_DoWork;
            this.objviewModel.bWorkerSave.RunWorkerCompleted += bWorkerSave_RunWorkerCompleted;

            this.objviewModel.bWorkerCopy.RunWorkerCompleted += bWorkerCopy_RunWorkerCompleted;

            this.objDocumentosService = new DocumentosService();
        }

        void bWorkerSave_DoWork(object sender, DoWorkEventArgs e)
        {
            this.objviewModel.loading = true;
        }

        void bWorkerPesquisa_DoWork(object sender, DoWorkEventArgs e)
        {
            this.objviewModel.loading = true;
        }

        void bWorkerCopy_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.objviewModel.loading = false;
        }

        void bWorkerSave_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.objviewModel.loading = false;
        }

        void bWorkerPesquisa_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (this.objviewModel.currentModel != null)
                (this.objviewModel.currentModel as modelComum).lDocumentos = new ObservableCollectionBaseCadastros<
                DocumentosModel>(list: this.objDocumentosService.GetObject(xNameTabela: this.objviewModel.currentModel.GetType().Name
                    .ToUpper().Replace(oldValue: "MODEL", newValue: ""), idPk: this.objviewModel.currentID));

            this.objviewModel.loading = false;
        }


        List<UIElement> lControls = null;

        #region Executes & CanExecutes

        private void Fechar(object wd)
        {
            ((Window)wd).Close();
        }
        private bool FecharCanExecute(object wd)
        {
            return true;
        }

        private OperationModel GetOperationModel
            ()
        {
            if (this.objviewModel.currentModel == null)
                return OperationModel.noAction;

            return (objviewModel.currentModel as modelComum).GetOperationModel();
        }

        private void ShowPesquisaExecute()
        {
            Window winPesquisa = GerenciadorModulo.Instancia.CarregaForm("WinPesquisaPadrao", TipoExibeForm.Normal);
            winPesquisa.WindowState = WindowState.Maximized;
            winPesquisa.SetPropertyValue("NameView", objviewModel.NameView);

            if (winPesquisa != null)
            {
                winPesquisa.ShowDialog();

                if ((winPesquisa.GetPropertyValue("lResult") as List<int>).Count > 0)
                {
                    objviewModel.navigatePesquisa = new MyObservableCollection<int>((winPesquisa.GetPropertyValue("lResult") as List<int>));
                    //MessageBox.Show(this.delBaseCanExecute().ToString());
                    objviewModel.navegarBaseCommand.Execute("Primeiro");
                    objviewModel.visibilityNavegacao = Visibility.Visible;
                }
            }
        }
        private bool ShowPesquisaCanEcexute()
        {
            bool bReturn = false;

            if ((objviewModel.NameView != string.Empty) && ((this.GetOperationModel() == OperationModel.noAction) || (this.GetOperationModel() == OperationModel.searching)))
                bReturn = true;
            else
                bReturn = false;

            return bReturn;
        }

        public void ExecAcao(object ContentBotao)
        {
            try
            {
                string parameter = "";
                if (ContentBotao.GetType() == typeof(string))
                    parameter = ContentBotao.ToString();
                else
                    parameter = ((Button)ContentBotao).Name.ToString();

                switch (parameter)
                {
                    case "btnPrimeiro":
                        objviewModel.navigatePesquisa.MoveFirst();
                        break;
                    case "btnAnterior":
                        objviewModel.navigatePesquisa.MovePrevious();
                        break;
                    case "btnProximo":
                        objviewModel.navigatePesquisa.MoveNext();
                        break;
                    case "btnUltimo":
                        objviewModel.navigatePesquisa.MoveLast();
                        break;
                    default:
                        break;
                }
                if (objviewModel.navigatePesquisa != null)
                {
                    try
                    {
                        //int i =  objviewModel.currentID;

                        if (objviewModel.navigatePesquisa.Count > 0)
                        {
                            objviewModel.iPositionCollection = objviewModel.navigatePesquisa.CurrentPosition;
                            objviewModel.currentID = (int)objviewModel.navigatePesquisa.CurrentValue;
                        }
                        objviewModel.sText = (objviewModel.navigatePesquisa.CurrentPosition + 1).ToString() + " de " + objviewModel.navigatePesquisa.Count.ToString();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public bool CanExecAcao(object ContentBotao)
        {
            string parameter = "";
            if (ContentBotao.GetType() == typeof(string))
                parameter = ContentBotao.ToString();
            else
                parameter = ((Button)ContentBotao).Name.ToString();

            bool bCanExecute = false;
            int currentPosition;
            int lastIndex;

            if (objviewModel.navigatePesquisa != null)
            {
                if (objviewModel.navigatePesquisa.Count() > 0)
                {
                    switch (parameter)
                    {
                        case "btnPrimeiro":
                            bCanExecute = true;
                            break;
                        case "btnAnterior":
                            currentPosition = objviewModel.navigatePesquisa.CurrentPosition;
                            bCanExecute = currentPosition > 0;
                            break;
                        case "btnProximo":
                            {
                                currentPosition = objviewModel.navigatePesquisa.CurrentPosition;
                                lastIndex = objviewModel.navigatePesquisa.Count - 1;
                                bCanExecute = currentPosition < lastIndex;
                            }
                            break;
                        case "btnUltimo":
                            bCanExecute = true;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    objviewModel.sText = (objviewModel.navigatePesquisa.CurrentPosition + 1).ToString() + " de " + objviewModel.navigatePesquisa.Count.ToString();
                }
            }
            return bCanExecute;
        }

        private void novoBase()
        {
            this.objviewModel.loading = true;
            this.objviewModel.bIsEnabled = true;
            this.objviewModel.navigatePesquisa = new MyObservableCollection<int>(new List<int>());
            objviewModel.currentID = 0;
            objviewModel.lItensHierarquia = new List<int>();
            this.SetFocusFirstControl();

            (this.objviewModel.currentModel as modelComum).SetOperationModel(_value: OperationModel.updating);

            PropertyInfo pi = this.objviewModel.currentModel.GetType().GetProperty(name: "Ativo");

            if (pi != null)
                pi.SetValue(obj: this.objviewModel.currentModel, value: true);

            this.objviewModel.loading = false;
        }

        public void SetFocusFirstControl()
        {
            if (lControls == null)
            {
                this.LoadComponentsWindow();
            }

            foreach (UIElement c in lControls)
            {
                PropertyInfo pi = c.GetType().GetProperty("stCompPosicao");

                if (pi != null)
                {

                    if ((HLP.Base.EnumsBases.statusComponentePosicao)pi.GetValue(obj: c) == statusComponentePosicao.first)
                    {
                        Stack<UIElement> lTabControlsTabItem = new Stack<UIElement>();

                        lTabControlsTabItem.Push(item: c);

                        this.SearchTabControlsTabItemToFocus(lTabControlsTabItem: lTabControlsTabItem,
                            ctrl: c as FrameworkElement);

                        while (bwFocus.IsBusy)
                        {
                            Thread.Sleep(millisecondsTimeout: 300);
                        }
                        bwFocus.RunWorkerAsync(argument: lTabControlsTabItem);

                    }
                }
            }
        }

        private void LoadComponentsWindow()
        {
            object o = Application.Current.MainWindow.DataContext.GetType().GetProperty(
                        name: "winMan").GetValue(obj: Application.Current.MainWindow.DataContext);

            object currentTabPage = o.GetType().GetProperty(name: "_currentTab").GetValue(
                obj: o);

            if (currentTabPage != null)
            {
                object contentUI = currentTabPage.GetType().GetProperty(name: "_content").GetValue(obj: currentTabPage);

                List<Expander> lExpanders = Util.GetLogicalChildCollection<Expander>(parent: contentUI);
                lControls = new List<UIElement>();

                foreach (Expander exp in lExpanders)
                {
                    lControls.AddRange(collection:
                        Util.GetLogicalChildCollection<UIElement>(parent: exp));
                }
            }
        }

        void bwFocus_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null && e.Error == null)
            {
                Application.Current.Dispatcher.BeginInvoke((Action)(() =>
                {
                    UIElement comp = ((Stack<UIElement>)e.Result).Pop();

                    comp.Focus();
                }));
            }
        }

        void bwFocus_DoWork(object sender, DoWorkEventArgs e)
        {
            Stack<UIElement> lTabControlsTabItem = e.Argument as Stack<UIElement>;

            bool bFocado = false;



            while (lTabControlsTabItem.Count > 1)
            {
                UIElement comp = lTabControlsTabItem.Pop();

                if (comp.GetType() == typeof(TabItem))
                {
                    Application.Current.Dispatcher.BeginInvoke((Action)(() =>
                       {
                           ((comp as TabItem).Parent as TabControl).SelectedItem = comp;
                       }));
                }
            }
            bFocado = true;

            do
            {
                e.Result = lTabControlsTabItem;
                Thread.Sleep(millisecondsTimeout: 300);
            } while (!bFocado);

        }

        private void SearchTabControlsTabItemToFocus(Stack<UIElement> lTabControlsTabItem, FrameworkElement ctrl)
        {
            if (ctrl.Parent == null)
            {
                return;
            }

            if (ctrl.Parent.GetType() == typeof(TabItem))
            {
                lTabControlsTabItem.Push(item: ctrl.Parent as UIElement);
            }

            SearchTabControlsTabItemToFocus(lTabControlsTabItem: lTabControlsTabItem, ctrl: ctrl.Parent as FrameworkElement);
        }

        private bool novoBaseCanExecute()
        {
            return (this.GetOperationModel() != OperationModel.updating
                || this.GenericCanExecute());
        }
        private void alterarBase()
        {
            this.objviewModel.bIsEnabled = true;
            (this.objviewModel.currentModel as modelComum).SetOperationModel(_value: OperationModel.updating);
        }
        private void delBase(object iRemoved)
        {
            this.objviewModel.loading = true;
            if (this.objviewModel.navigatePesquisa != null)
            {
                if (iRemoved == null)
                {
                    throw new Exception("É necessário corrigir o método de Excluir!");
                }
                else
                {
                    if (objviewModel.navigatePesquisa.Where(c => c == (int)iRemoved).Count() > 0)
                    {
                        objviewModel.navigatePesquisa.Remove((int)iRemoved);
                    }

                    if (objviewModel.navigatePesquisa.Count() > 0)
                    {
                        if (this.objviewModel.currentModel != null)
                            (this.objviewModel.currentModel as modelComum).SetOperationModel(_value: OperationModel.searching);
                    }
                    this.ExecAcao("");

                }
            }

            if (this.objviewModel.currentModel != null)
                if ((this.objviewModel.currentModel as modelComum).lDocumentos != null)
                    this.objDocumentosService.DeleteObject(xNameTabela: this.objviewModel.currentModel.GetType().Name
                        .ToUpper().Replace(oldValue: "MODEL", newValue: ""), idPk: this.objviewModel.currentID);

            this.objviewModel.loading = false;
        }
        private void salvarBase()
        {
            (this.objviewModel.currentModel as modelComum).SetOperationModel(_value: OperationModel.searching);
            this.objviewModel.bIsEnabled = false;

            if (lControls == null)
            {
                this.LoadComponentsWindow();
            }

            foreach (UIElement c in lControls)
            {
                PropertyInfo pi = c.GetType().GetProperty("stCompPosicao");

                if (pi != null)
                {

                    if ((HLP.Base.EnumsBases.statusComponentePosicao)pi.GetValue(obj: c) == statusComponentePosicao.fieldId)
                    {
                        Stack<UIElement> lTabControlsTabItem = new Stack<UIElement>();

                        lTabControlsTabItem.Push(item: c);

                        this.SearchTabControlsTabItemToFocus(lTabControlsTabItem: lTabControlsTabItem,
                            ctrl: c as FrameworkElement);

                        while (bwFocus.IsBusy)
                        {
                            Thread.Sleep(millisecondsTimeout: 300);
                        }
                        bwFocus.RunWorkerAsync(argument: lTabControlsTabItem);
                    }
                }
            }
            if ((this.objviewModel.currentModel as modelComum).lDocumentos != null)
                this.objDocumentosService.SaveObject(obj:
                    (this.objviewModel.currentModel as modelComum).lDocumentos.ToList(),
                    xNameTabela: this.objviewModel.currentModel.GetType().Name.ToUpper().Replace(oldValue: "MODEL", newValue: ""),
                    idPk: this.objviewModel.currentID);

        }
        private bool salvarBaseCanExecute()
        {
            if (this.GetOperationModel() ==
                 OperationModel.updating)
                return true;
            else
                return false;
        }
        private void cancelarBase()
        {
            this.objviewModel.loading = true;
            System.Threading.Thread.Sleep(200);
            if (objviewModel.currentID != 0)
            {
                (this.objviewModel.currentModel as modelComum).SetOperationModel(_value: OperationModel.searching);
            }
            this.objviewModel.bIsEnabled = false;
            this.objviewModel.loading = false;

        }
        private bool cancelarBaseCanExecute()
        {
            return (this.GetOperationModel()
                == OperationModel.updating);
        }
        private bool GenericCanExecute()
        {
            return this.GetOperationModel() == OperationModel.searching;
        }
        private void CopyExecute()
        {
            this.objviewModel.loading = true;

            object pk;
            if (this.objviewModel.currentModel == null)
                return;

            foreach (var item in this.objviewModel.currentModel.GetType().GetProperties())
            {
                try
                {
                    pk = item.GetCustomAttributes(true).FirstOrDefault(i => i.GetType() == typeof(PrimaryKey));

                    if (pk != null)
                    {
                        if (((PrimaryKey)pk).isPrimary)
                        {
                            item.SetValue(obj: this.objviewModel.currentModel, value: null);
                        }
                    }
                    else if (item.PropertyType.BaseType.Name == "modelComum")
                    {
                        foreach (var propItem in item.PropertyType.GetProperties())
                        {
                            pk = propItem.GetCustomAttributes(true).FirstOrDefault(i => i.GetType() == typeof(PrimaryKey));

                            if (pk != null)
                            {
                                if (((PrimaryKey)pk).isPrimary)
                                {
                                    object v = this.objviewModel.currentModel.GetType().GetProperty(name: item.Name)
                                        .GetValue(obj: this.objviewModel.currentModel);
                                    if (v != null)
                                        propItem.SetValue(obj: v, value: null);
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (PropertyInfo pi in item.PropertyType.GetProperties())
                        {
                            try
                            {
                                if (pi.PropertyType.BaseType != null)
                                    if (pi.PropertyType.BaseType.Name == "modelComum")
                                    {
                                        var m = this.objviewModel.currentModel.GetType().
                                GetProperty(name: item.Name).GetValue(obj: this.objviewModel.currentModel);
                                        if (m != null)
                                        {
                                            if ((m as ICollection).Count > 0)
                                            {

                                                foreach (var subItem in m as ICollection)
                                                {
                                                    foreach (var propSubItem in subItem.GetType().GetProperties())
                                                    {
                                                        pk = propSubItem.GetCustomAttributes(true).FirstOrDefault(i => i.GetType() == typeof(PrimaryKey));

                                                        if (pk != null)
                                                        {

                                                            if (((PrimaryKey)pk).isPrimary)
                                                            {
                                                                propSubItem.SetValue(obj: subItem, value: null);
                                                            }
                                                        }
                                                    }

                                                    subItem.GetType().GetProperty(name: "status").SetValue(obj: subItem, value: statusModel.criado);
                                                }
                                            }
                                        }
                                    }
                            }
                            catch (Exception)
                            {

                                throw;
                            }

                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }

            }

            (this.objviewModel.currentModel as modelComum).SetOperationModel(_value: OperationModel.updating);
            this.objviewModel.bIsEnabled = true;
            this.objviewModel.navigatePesquisa = new MyObservableCollection<int>(new List<int>());
            objviewModel.currentID = 0;
            objviewModel.lItensHierarquia = new List<int>();

            if ((this.objviewModel.currentModel as modelComum).lDocumentos != null)
                this.objDocumentosService.CopyObject(lDocumentos:
                    (this.objviewModel.currentModel as modelComum).lDocumentos.ToList());
        }

        #endregion
    }
}
