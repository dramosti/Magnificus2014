using HLP.Comum.Resources.RecursosBases;
using HLP.Comum.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using HLP.Comum.Model.Models;
using System.Windows.Controls.Primitives;
using HLP.Comum.Resources.Util;
using System.Windows.Threading;
using System.Collections;
using HLP.Comum.Infrastructure.Static;
using HLP.Comum.Infrastructure;


namespace HLP.Comum.ViewModel.ViewModels
{
    public class ViewModelBase<T> : INotifyPropertyChanged where T : class
    {

        private T _currentModel;
        public T currentModel
        {
            get { return _currentModel; }
            set { _currentModel = value; NotifyPropertyChanged("currentModel"); }
        }


        public ViewModelBase()
        {
            this.bIsEnabled = false;

            viewModelBaseCommands = new ViewModelBaseCommands<T>(this);
        }
        public ViewModelBaseCommands<T> viewModelBaseCommands;
        BackgroundWorker bwFocus = new BackgroundWorker();
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

        //private int _currentID;
        //public int currentID
        //{
        //    get { return _currentID; }
        //    set
        //    {
        //        if (value == -1)
        //        {
        //            _currentID = 0;
        //        }
        //        else if ((value != _currentID) && (value != 0))
        //        {
        //            _currentID = value;
        //        }

        //    }
        //}

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

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Validação
        public bool IsValid(DependencyObject obj)
        {
            // The dependency object is valid if it has no errors, 
            //and all of its children (that are dependency objects) are error-free.
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
            if (p.GetType().BaseType == typeof(Window))
            {
                try
                {
                    ((Window)p).Close();
                }
                catch (Exception)
                {

                }

            }
            else
            {
                try
                { FechaForm(p: ((System.Windows.Controls.Panel)p).Parent); }
                catch (Exception) { ((Window)p).Close(); }

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
                        o = StaticUtil.GetCell(grid: obj, row: row, column: c.DisplayIndex).Content;
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
                    List<Control> lControlesWindow = GetLogicalChildCollection<Control>(content).Where(c => c.GetType().BaseType.Name == "BaseControl").ToList();
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

                if (GetLogicalChildCollection<TabControl>(_panel).ToList().Count() > 0)
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
            Control ctr;
            if (SecondControl == null)
                FindFirstAndSecondComponente(_panel);

            if (foco == Util.focoComponente.Primeiro)
                ctr = FirstControl;
            else
                ctr = SecondControl;

            if (ctr != null)
            {
                SetFocus(_panel, ctr);
            }
        }



        public List<T> GetLogicalChildCollection<T>(object parent) where T : DependencyObject
        {
            List<T> logicalCollection = new List<T>();
            GetLogicalChildCollection(parent as DependencyObject, logicalCollection);
            return logicalCollection;
        }
        private void GetLogicalChildCollection<T>(DependencyObject parent, List<T> logicalCollection) where T : DependencyObject
        {
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, (Action)(() =>
           {
               IEnumerable children = LogicalTreeHelper.GetChildren(parent);
               foreach (object child in children)
               {
                   if (child is DependencyObject)
                   {
                       DependencyObject depChild = child as DependencyObject;
                       if (child is T)
                       {
                           logicalCollection.Add(child as T);
                       }
                       GetLogicalChildCollection(depChild, logicalCollection);
                   }
               }
           }));
        }


    }
}
