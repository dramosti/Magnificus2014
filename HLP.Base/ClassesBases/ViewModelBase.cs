﻿using HLP.Base.EnumsBases;
using HLP.Base.InterfacesBases;
using HLP.Base.Modules;
using HLP.Base.Static;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace HLP.Base.ClassesBases
{
    public class ViewModelBase<T> : INotifyPropertyChanged where T : class
    {
        public MessageHlp message { get; set; }
        public ViewModelBase()
        {
            this.bIsEnabled = false;
            message = new MessageHlp();
            viewModelBaseCommands = new ViewModelBaseCommands<T>(this);
            this.Botoes = new StackPanel();
        }
        private T _currentModel;
        public T currentModel
        {
            get { return _currentModel; }
            set { _currentModel = value; NotifyPropertyChanged("currentModel"); }
        }

        private List<int> _lIds;
        public List<int> lIds
        {
            get { return _lIds; }
            set
            {
                _lIds = value;
            }
        }

        private int _selectedId;
        public int selectedId
        {
            get { return _selectedId; }
            set
            {
                _selectedId = value;
                this.NotifyPropertyChanged(propertyName: "selectedId");
            }
        }

        private List<int> _lItensHierarquia;
        public List<int> lItensHierarquia
        {
            get { return _lItensHierarquia; }
            set
            {
                _lItensHierarquia = value;
                NotifyPropertyChanged(propertyName: "lItensHierarquia");
            }
        }
        private StackPanel _botoes;
        public StackPanel Botoes
        {
            get { return _botoes; }
            set { _botoes = value; }
        }
        public ViewModelBaseCommands<T> viewModelBaseCommands;
        private BackgroundWorker bwFocus = new BackgroundWorker();
        public ICommand salvarBaseCommand { get; set; }
        public ICommand deletarBaseCommand { get; set; }
        public ICommand novoBaseCommand { get; set; }
        public ICommand alterarBaseCommand { get; set; }
        public ICommand cancelarBaseCommand { get; set; }
        public ICommand copyBaseCommand { get; set; }
        public ICommand pesquisarBaseCommand { get; set; }
        public ICommand navegarBaseCommand { get; set; }
        public ICommand fecharCommand { get; set; }
        public void SetValorCurrentOp(OperacaoCadastro op)
        {
            viewModelBaseCommands.currentOp = op;
        }
        private string _sText = "0 de 0";
        public string sText
        {
            get { return _sText; }
            set { _sText = value; this.NotifyPropertyChanged("sText"); }

        }
        public int iPositionCollection { get; set; }

        #region BackgroundWorker
        private BackgroundWorker _bWorkerSave;
        public BackgroundWorker bWorkerSave
        {
            get
            {
                if (_bWorkerHierarquia == null)
                    _bWorkerHierarquia = new BackgroundWorker();
                return _bWorkerHierarquia;
            }
            set { _bWorkerHierarquia = value; }
        }

        private BackgroundWorker _bWorkerNovo;
        public BackgroundWorker bWorkerNovo
        {
            get
            {
                if (_bWorkerNovo == null)
                    _bWorkerNovo = new BackgroundWorker();
                return _bWorkerNovo;
            }
            set { _bWorkerNovo = value; }
        }

        private BackgroundWorker _bWorkerAlterar;
        public BackgroundWorker bWorkerAlterar
        {
            get
            {
                if (_bWorkerAlterar == null)
                    _bWorkerAlterar = new BackgroundWorker();
                return _bWorkerAlterar;
            }
            set { _bWorkerAlterar = value; }
        }

        private BackgroundWorker _bWorkerCopy;
        public BackgroundWorker bWorkerCopy
        {
            get
            {
                if (_bWorkerCopy == null)
                    _bWorkerCopy = new BackgroundWorker();
                return _bWorkerCopy;
            }
            set { _bWorkerCopy = value; }
        }

        private BackgroundWorker _bWorkerPesquisa;
        public BackgroundWorker bWorkerPesquisa
        {
            get
            {
                if (_bWorkerPesquisa == null)
                    _bWorkerPesquisa = new BackgroundWorker();
                return _bWorkerPesquisa;
            }
            set { _bWorkerPesquisa = value; }
        }

        private BackgroundWorker _bWorkerHierarquia;
        public BackgroundWorker bWorkerHierarquia
        {
            get
            {
                if (_bWorkerHierarquia == null)
                    _bWorkerHierarquia = new BackgroundWorker();
                return _bWorkerHierarquia;
            }
            set { _bWorkerHierarquia = value; }
        }

        #endregion




        private MyObservableCollection<int> _navigatePesquisa;
        public MyObservableCollection<int> navigatePesquisa
        {
            get { return _navigatePesquisa; }
            set { _navigatePesquisa = value; this.NotifyPropertyChanged("navigatePesquisa"); }
        }

        private Visibility _visibilityNavegacao = Visibility.Collapsed;
        public Visibility visibilityNavegacao
        {
            get { return _visibilityNavegacao; }
            set { _visibilityNavegacao = value; this.NotifyPropertyChanged("visibilityNavegacao"); }
        }

        private int _currentID = 0;
        public int currentID
        {
            set
            {
                _currentID = value;
            }

            get
            {
                if (navigatePesquisa == null)
                    navigatePesquisa = new MyObservableCollection<int>(new List<int>());
                if (this.currentModel != null)
                {
                    object pk;
                    foreach (var property in this.currentModel.GetType().GetProperties())
                    {
                        pk = property.GetCustomAttributes(true).FirstOrDefault(t => t.GetType() == typeof(PrimaryKey));
                        if (pk != null)
                        {
                            if (((PrimaryKey)pk).isPrimary)
                            {
                                int? value = (int?)(property.GetValue(obj: this.currentModel));
                                if (value != null)
                                    _currentID = (int)value;
                                break;
                            }
                        }
                    }
                }
                else if (this.navigatePesquisa.Count() > 0 && _currentID == 0)
                {
                    _currentID = this.navigatePesquisa[this.iPositionCollection];
                }



                if (navigatePesquisa.Count > 0)
                    if (this.navigatePesquisa[this.iPositionCollection] != _currentID)
                        _currentID = this.navigatePesquisa[this.iPositionCollection];

                return _currentID;
            }
        }

        private bool _bIsEnabled;
        public bool bIsEnabled
        {
            get
            {
                return this._bIsEnabled;
            }
            set
            {
                this._bIsEnabled = value;
                this.NotifyPropertyChanged(propertyName: "bIsEnabled");
            }
        }

        private string _NameView = string.Empty;
        public string NameView
        {
            get { return _NameView; }
            set { _NameView = value; }
        }

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

        #region Validação
        public bool IsValid(DependencyObject obj)
        {
            // The dependency object is valid if it has no errors, 
            //and all of its children (that are dependency objects) are error-free.
            if (obj == null)
                return true;
            bool resultado = ((!Validation.GetHasError(obj)
                ) &&
                LogicalTreeHelper.GetChildren(obj)
                .OfType<DependencyObject>()
                .All(child => IsValid(child)));
            return resultado &&
                obj.GetType() == typeof(System.Windows.Controls.DataGrid) ?
                !this.GridObjectsIsValid(obj: obj as System.Windows.Controls.DataGrid)
                : resultado;
        }



        public void FechaForm(object p)
        {
            try
            {
                ((Window)p).Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool GridObjectsIsValid(System.Windows.Controls.DataGrid obj)
        {
            object o;

            if (obj.ItemsSource != null)
            {
                foreach (object i in obj.ItemsSource)
                {
                    DataGridRow row = obj.ItemContainerGenerator.ContainerFromItem(i) as DataGridRow;
                    if (row == null)
                        return false;
                    foreach (DataGridColumn c in obj.Columns)
                    {
                        DataGridCell _cell = Util.GetCell(grid: obj, row: row, column: c.DisplayIndex);
                        if (_cell == null)
                            return false;
                        o = _cell.Content;
                        if (o != null)
                        {
                            if (o.GetType() == typeof(System.Windows.Controls.TextBlock))
                            {
                                if (Validation.GetHasError(element: o as TextBlock))
                                    return true;
                            }
                            else if (o.GetType() == typeof(System.Windows.Controls.ComboBox))
                            {
                                if (Validation.GetHasError(element: o as System.Windows.Controls.ComboBox))
                                    return true;
                            }
                            else if (o.GetType() == typeof(System.Windows.Controls.TextBox))
                            {
                                if (Validation.GetHasError(element: o as System.Windows.Controls.TextBox))
                                    return true;
                            }
                            else if (o.GetType().Name.ToString() == "TextBlockComboBox")
                            {
                                if (Validation.GetHasError(element: o as System.Windows.Controls.ComboBox))
                                    return true;
                            }
                            else if (o.GetType().Name.ToString() == "ContentPresenter")
                            {

                                for (int cont = 0; cont < VisualTreeHelper.GetChildrenCount(reference: (o as ContentPresenter)); cont++)
                                {
                                    object child = VisualTreeHelper.GetChild(o as ContentPresenter, cont);

                                    if (child.GetType().Name.ToString() == "TextBlock")
                                        if (Validation.GetHasError(child as TextBlock))
                                            return true;
                                }

                            }
                        }
                    }
                }
            }
            return false;
        }

        #endregion


        public Control FirstControl { get; set; }
        public Control SecondControl { get; set; }

        void FindFirstAndSecondComponente(Panel content)
        {
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, (Action)(() =>
            {
                if (FirstControl == null)
                {
                    List<Control> lControlesWindow = Util.GetLogicalChildCollection<Control>(content).Where(c => c.GetType().BaseType.Name == "BaseControl").ToList();
                    if (lControlesWindow.Count > 0)
                    {
                        FirstControl = lControlesWindow.FirstOrDefault();

                        for (int i = 1; i < lControlesWindow.Count; i++)
                        {
                            if (lControlesWindow[i].IsEnabled)
                            {
                                SecondControl = lControlesWindow[i];
                                break;
                            }
                        }
                        if (SecondControl == null)
                        {
                            SecondControl = FirstControl;
                        }
                    }
                }
            }));
        }

        void SetFocus(Panel content, Control ctrFocus)
        {
            List<Control> lDestalhesControle = TabPagesAtivasModel.GetLogicalChildCollection<Control>(ctrFocus);
            content.MoveFocus(new TraversalRequest(FocusNavigationDirection.First));
            System.Windows.Controls.Control ctr = (System.Windows.Controls.Control)Keyboard.FocusedElement;

            // caso retorne nesse componente ctrValidacao é pq esta em looping e deve sair do while.
            System.Windows.Controls.Control ctrValidacao = (System.Windows.Controls.Control)Keyboard.FocusedElement;
            while (!lDestalhesControle.Contains((System.Windows.Controls.Control)Keyboard.FocusedElement))
            {
                ctr.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                ctr = (System.Windows.Controls.Control)Keyboard.FocusedElement;
                if (ctr == ctrValidacao)
                    break;
            }
        }

        public void SetFocusFirstTab(System.Windows.Controls.Panel _panel)
        {
            System.Windows.Controls.Control ctr = (System.Windows.Controls.Control)Keyboard.FocusedElement;
            if (ctr != null)
                ctr.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));

            Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, (Action)(() =>
            {
                if (SecondControl == null || FirstControl == null)
                    FindFirstAndSecondComponente(_panel);

                if (Util.GetLogicalChildCollection<TabControl>(_panel).ToList().Count() > 0)
                {
                    TabItem tb;
                    TabPagesAtivasModel.GetTabItemByControl((FirstControl as FrameworkElement), out tb);
                    if (tb != null)
                        (tb.Parent as TabControl).SelectedItem = tb;
                }
            }));
        }

        public void FocusToComponente(System.Windows.Controls.Panel _panel, Util.focoComponente foco)
        {
            //Control ctr;
            //if (SecondControl == null)
            //    FindFirstAndSecondComponente(_panel);

            //if (foco == Util.focoComponente.Primeiro)
            //    ctr = FirstControl;
            //else
            //    ctr = SecondControl;

            //if (ctr != null)
            //{
            //    SetFocus(_panel, ctr);
            //}
        }

        public object GetParentWindow(object comp)
        {
            object o = null;

            while (true)
            {
                if (comp == null)
                    break;

                if (comp.GetType().BaseType == typeof(Window))
                {
                    o = comp;
                    break;
                }
                else
                {
                    comp = (comp as FrameworkElement).Parent;
                }
            }

            return o;
        }
    }

    public class ViewModelBaseCommands<T> where T : class
    {
        public ViewModelBase<T> objviewModel;
        private OperacaoCadastro _currentOp;
        public OperacaoCadastro currentOp
        {
            get
            { return this._currentOp; }
            set
            {
                this._currentOp = value;
            }
        }


        public ViewModelBaseCommands(object vViewModel)
        {
            this.objviewModel = vViewModel as ViewModelBase<T>;
            this.objviewModel.novoBaseCommand = new RelayCommand(execute: pExec => this.novoBase(panel: pExec),
                canExecute: pCanExec => this.novoBaseCanExecute());
            this.objviewModel.alterarBaseCommand = new RelayCommand(execute: pExec => this.alterarBase(panel: pExec),
                canExecute: pCanExec => this.GenericCanExecute());
            this.objviewModel.deletarBaseCommand = new RelayCommand(execute: pExec => this.delBase(iRemoved: pExec),
                canExecute: pCanExec => this.GenericCanExecute());
            this.objviewModel.salvarBaseCommand = new RelayCommand(execute: pExec => this.salvarBase(panel: pExec),
                canExecute: pCanExec => this.salvarBaseCanExecute());
            this.objviewModel.cancelarBaseCommand = new RelayCommand(execute: pExec => this.cancelarBase(),
                canExecute: pCanExec => this.cancelarBaseCanExecute());
            this.objviewModel.copyBaseCommand = new RelayCommand(execute: pExec => this.GenericCanExecute(),
                canExecute: pCanExec => this.GenericCanExecute());
            this.objviewModel.fecharCommand = new RelayCommand(execute: pExec => this.Fechar(wd: pExec),
                canExecute: pCanExec => this.FecharCanExecute(wd: pCanExec));

            this.currentOp = OperacaoCadastro.livre;

            this.objviewModel.pesquisarBaseCommand = new RelayCommand(
                 execute: ex => ShowPesquisaExecute(),
                 canExecute: canExecute => ShowPesquisaCanEcexute());

            this.objviewModel.navegarBaseCommand = new RelayCommand(
               execute: exec => ExecAcao(ContentBotao: exec),
               canExecute: CanExec => CanExecAcao(ContentBotao: CanExec));

        }

        #region Executes & CanExecutes

        private void Fechar(object wd)
        {
            ((Window)wd).Close();
        }
        private bool FecharCanExecute(object wd)
        {
            return true;
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
                    this.currentOp = OperacaoCadastro.pesquisando;
                }
            }
        }
        private bool ShowPesquisaCanEcexute()
        {
            bool bReturn = false;

            if ((objviewModel.NameView != string.Empty) && ((this.currentOp == OperacaoCadastro.livre) || (this.currentOp == OperacaoCadastro.pesquisando)))
                bReturn = true;
            else
                bReturn = false;

            return bReturn;
        }

        public void ExecAcao(object ContentBotao)
        {
            try
            {
                switch (ContentBotao.ToString())
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

            bool bCanExecute = false;
            int currentPosition;
            int lastIndex;

            if (objviewModel.navigatePesquisa != null)
            {
                if (objviewModel.navigatePesquisa.Count() > 0)
                {
                    switch (ContentBotao.ToString())
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

        private void novoBase(object panel)
        {
            object o = Application.Current.MainWindow.DataContext.GetType().GetProperty(
                name: "winMan").GetValue(obj: Application.Current.MainWindow.DataContext);

            object currentTabPage = o.GetType().GetProperty(name: "_currentTab").GetValue(
                obj: o);

            if (currentTabPage != null)
            {
                object contentUI = currentTabPage.GetType().GetProperty(name: "_content").GetValue(obj: currentTabPage);

                List<Expander> lExpanders = Util.GetLogicalChildCollection<Expander>(parent: contentUI);
                List<UIElement> lControls = new List<UIElement>();

                foreach (Expander exp in lExpanders)
                {
                    lControls.AddRange(collection:
                        Util.GetLogicalChildCollection<UIElement>(parent: exp));
                }

                foreach (UIElement c in lControls)
                {
                    PropertyInfo pi = c.GetType().GetProperty("stCompPosicao");

                    if (pi != null)
                    {
                        if ((HLP.Base.EnumsBases.statusComponentePosicao)pi.GetValue(obj: pi) == statusComponentePosicao.first)
                        {
                            c.Focus();
                        }
                    }
                }
            }

            this.currentOp = OperacaoCadastro.criando;
            this.objviewModel.bIsEnabled = true;
            this.objviewModel.navigatePesquisa = new MyObservableCollection<int>(new List<int>());
            objviewModel.currentID = 0;
            objviewModel.lItensHierarquia = new List<int>();
            objviewModel.SetFocusFirstTab(panel as Panel);
        }
        private bool novoBaseCanExecute()
        {
            return (this.currentOp == OperacaoCadastro.livre
                || this.GenericCanExecute());
        }
        private void alterarBase(object panel)
        {
            this.objviewModel.bIsEnabled = true;
            this.currentOp = OperacaoCadastro.alterando;
            this.objviewModel.SetFocusFirstTab(panel as Panel);
        }
        private void delBase(object iRemoved)
        {
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
                        this.currentOp = OperacaoCadastro.pesquisando;
                    }
                    else
                    {
                        this.currentOp = OperacaoCadastro.livre;
                    }
                    this.ExecAcao("");

                }
            }
        }
        private void salvarBase(object panel)
        {
            this.currentOp = OperacaoCadastro.pesquisando;
            this.objviewModel.bIsEnabled = false;

            if (panel != null)
            {
                objviewModel.FocusToComponente(panel as Panel, Util.focoComponente.Primeiro);
            }
        }
        private bool salvarBaseCanExecute()
        {
            if (this.currentOp != OperacaoCadastro.criando &&
                this.currentOp != OperacaoCadastro.alterando)
                return false;
            else
                return true;
        }
        private void cancelarBase()
        {
            System.Threading.Thread.Sleep(200);
            if (objviewModel.currentID == 0)
            {
                this.currentOp = OperacaoCadastro.livre;
            }
            else
            {
                this.currentOp = OperacaoCadastro.pesquisando;
            }
            this.objviewModel.bIsEnabled = false;

        }
        private bool cancelarBaseCanExecute()
        {
            return (this.currentOp == OperacaoCadastro.criando ||
                this.currentOp == OperacaoCadastro.alterando);
        }
        private bool GenericCanExecute()
        {
            return this.currentOp == OperacaoCadastro.pesquisando;
        }


        #endregion

    }

}
