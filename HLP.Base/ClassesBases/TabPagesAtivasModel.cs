using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using HLP.Base.Static;
using HLP.Base.EnumsBases;
using System.Threading;
using System.Windows.Documents;
using System.Collections.ObjectModel;

namespace HLP.Base.ClassesBases
{
    public class TabPagesAtivasModel : modelBase
    {
        public TabPagesAtivasModel()
        {
            this.lComponents = new List<FrameworkElement>();
            this.lTextBlock = new List<FrameworkElement>();
            this.lDataGrids = new List<DataGrid>();
        }

        #region Properties
        private Window Windows;
        public Window _windows
        {
            get { return Windows; }
            set
            {
                Windows = value;
                try
                {
                    this.NameView = value.GetPropertyValue("NameView").ToString();

                }
                catch (Exception ex) { throw ex; }
            }
        }

        private string _NameView = string.Empty;
        public string NameView
        {
            get { return _NameView; }
            set { _NameView = value; }
        }
        public string _header
        {
            get { return this.Windows.Title; }
        }

        private StackPanel _Botoes;

        public StackPanel Botoes
        {
            get { return _Botoes; }
            set
            {
                _Botoes = value;
                base.NotifyPropertyChanged(propertyName: "Botoes");
            }
        }

        public UIElement _content
        {
            get
            {
                UIElement e = _windows.Content as UIElement;

                if (e.GetType().BaseType == typeof(Panel))
                {
                    (e as Panel).DataContext = this.Windows.DataContext;
                }
                else if (e.GetType() == typeof(Expander))
                {
                    (e as Expander).DataContext = this.Windows.DataContext;
                }
                else if (e.GetType() == typeof(TabControl))
                {
                    (e as TabControl).DataContext = this.Windows.DataContext;
                }
                else
                    throw new Exception(message: "Tela não está configurada com os padrões definidos. Contate o Suporte!");

                if (this.Windows.DataContext != null)
                    foreach (PropertyInfo item in this.Windows.DataContext.GetType().GetProperties())
                    {
                        if (item.PropertyType == typeof(StackPanel))
                        {
                            Type t = this.Windows.DataContext.GetType();
                            object parametro = Activator.CreateInstance(t);
                            parametro = this.Windows.DataContext;

                            this.Botoes = item.GetValue(obj: parametro) as StackPanel;
                        }
                    }

                return e;
            }
        }

        public object _currentDataContext
        {
            get
            {
                return this.Windows.DataContext;
            }
        }

        private List<FrameworkElement> _lComponents;

        public List<FrameworkElement> lComponents
        {
            get { return _lComponents; }
            set { _lComponents = value; }
        }

        private List<DataGrid> _lDataGrids;

        public List<DataGrid> lDataGrids
        {
            get { return _lDataGrids; }
            set { _lDataGrids = value; }
        }


        private List<FrameworkElement> _lTextBlocks;

        public List<FrameworkElement> lTextBlock
        {
            get { return _lTextBlocks; }
            set { _lTextBlocks = value; }
        }

        
        private ObservableCollection<ErrorsModel> _lErrorsToView;

        public ObservableCollection<ErrorsModel> lErrorsToView
        {
            get { return _lErrorsToView; }
            set
            {
                _lErrorsToView = value;
                base.NotifyPropertyChanged(propertyName: "lErrorsToView");
            }
        }

        private int _currentErrorsCount;

        public int currentErrorsCount
        {
            get { return _currentErrorsCount; }
            set
            {
                _currentErrorsCount = value;
                base.NotifyPropertyChanged(propertyName: "currentErrorsCount");
            }
        }

        #endregion

    }

    public class DetailsErrorModel
    {
        public string xLabelComp { get; set; }
        public string xError { get; set; }
        public bool isDataGridError { get; set; }
        public FrameworkElement comp { get; set; }
    }
}
