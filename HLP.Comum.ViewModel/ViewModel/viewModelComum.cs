using HLP.Base.ClassesBases;
using HLP.Base.EnumsBases;
using HLP.Base.Static;
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
using System.Windows.Media;
using System.Windows.Threading;

namespace HLP.Comum.ViewModel.ViewModel
{
    public class viewModelComum<T> : INotifyPropertyChanged where T : class
    {

        private bool _loading;

        public bool loading
        {
            get { return _loading; }
            set
            {
                _loading = value;
                this.NotifyPropertyChanged(propertyName: "loading");
            }
        }


        private string _xDescLoading;

        public string xDescLoading
        {
            get { return _xDescLoading; }
            set
            {
                _xDescLoading = value;
                this.NotifyPropertyChanged(propertyName: "xDescLoading");
            }
        }


        public MessageHlp message { get; set; }
        public viewModelComum()
        {
            this.bIsEnabled = false;
            message = new MessageHlp();
            viewModelComumCommands = new viewModelComumCommands<T>(this);
            this.Botoes = new StackPanel();
            this.xDescLoading = "Loading";
        }

        private T _currentModel;
        public T currentModel
        {
            get { return _currentModel; }
            set
            {
                _currentModel = value;
                NotifyPropertyChanged("currentModel");
            }
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

        private viewModelComumCommands<T> _viewModelComumCommands;

        public viewModelComumCommands<T> viewModelComumCommands
        {
            get { return _viewModelComumCommands; }
            set { _viewModelComumCommands = value; }
        }

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
                if (_bWorkerSave == null)
                    _bWorkerSave = new BackgroundWorker();
                return _bWorkerSave;
            }
            set { _bWorkerSave = value; }
        }


        private BackgroundWorker _bWorkerPrint;

        public BackgroundWorker bWorkerPrint
        {
            get
            {
                if (_bWorkerPrint == null)
                    _bWorkerPrint = new BackgroundWorker();
                return _bWorkerPrint;
            }
            set { _bWorkerPrint = value; }
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
                {
                    if (this.iPositionCollection < this.navigatePesquisa.Count)
                        if (this.navigatePesquisa[this.iPositionCollection] != _currentID)
                            _currentID = this.navigatePesquisa[this.iPositionCollection];
                }

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
            return true;
            //ATENÇÃO **
            //Para não ser necessário repassar todas as telas retirando essa validação, deixei retornando sempre true,
            //porém, como pode ver este método não está fazendo nada, apenas retornando true,
            //já que a validação já está sendo feita na viewmodelcomum


            // The dependency object is valid if it has no errors, 
            //and all of its children (that are dependency objects) are error-free.
            //if (obj == null)
            //    return true;
            //bool resultado = ((!Validation.GetHasError(obj)
            //    ) &&
            //    LogicalTreeHelper.GetChildren(obj)
            //    .OfType<DependencyObject>()
            //    .All(child => IsValid(child)));
            //return resultado &&
            //    obj.GetType() == typeof(System.Windows.Controls.DataGrid) ?
            //    !this.GridObjectsIsValid(obj: obj as System.Windows.Controls.DataGrid)
            //    : resultado;
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


        private stAcoesHierarquia _loadTreeView;

        public stAcoesHierarquia loadTreeView
        {
            get { return _loadTreeView; }
            set
            {
                _loadTreeView = value;
                this.NotifyPropertyChanged(propertyName: "loadTreeView");
            }
        }

    }
}
