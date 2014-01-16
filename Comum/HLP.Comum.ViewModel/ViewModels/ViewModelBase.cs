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
using System.Windows.Forms;
using HLP.Comum.Model.Models;
using System.Windows.Controls.Primitives;
using HLP.Comum.Resources.Util;


namespace HLP.Comum.ViewModel.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
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

        private int _currentID;
        public int currentID
        {
            get { return _currentID; }
            set
            {
                if (value == -1)
                {
                    _currentID = 0;
                }
                else if ((value != _currentID) && (value != 0))
                {
                    _currentID = value;
                }

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


        public ViewModelBaseCommands viewModelBaseCommands;

        public ViewModelBase()
        {
            this.bIsEnabled = false;
            viewModelBaseCommands = new ViewModelBaseCommands(vViewModel: this);
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

        public void SecondComponentFocus(System.Windows.Controls.Panel _panel)
        {
            _panel.MoveFocus(new TraversalRequest(FocusNavigationDirection.First));
            System.Windows.Controls.Control ctr = (System.Windows.Controls.Control)Keyboard.FocusedElement;
            while (ctr.GetType() != typeof(System.Windows.Controls.TextBox))
            {
                ctr.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                ctr = (System.Windows.Controls.Control)Keyboard.FocusedElement;
                if (ctr.GetType() == typeof(System.Windows.Controls.ComboBox))
                    break;
            }
            if (ctr.GetType() == typeof(System.Windows.Controls.TextBox))
                ctr.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
        }
        public void FirstComponentFocus(System.Windows.Controls.Panel _panel)
        {
            _panel.MoveFocus(new TraversalRequest(FocusNavigationDirection.First));
            System.Windows.Controls.Control ctr = (System.Windows.Controls.Control)Keyboard.FocusedElement;
            while (ctr.GetType() != typeof(System.Windows.Controls.TextBox))
            {
                ctr.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                ctr = (System.Windows.Controls.Control)Keyboard.FocusedElement;
                if (ctr.GetType() == typeof(System.Windows.Controls.ComboBox))
                    break;
            }
        }
    }
}
