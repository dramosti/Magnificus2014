using HLP.Base.ClassesBases;
using HLP.Components.Model.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HLP.Components.View.WPF
{
    /// <summary>
    /// Interaction logic for HlpContato.xaml
    /// </summary>
    public partial class HlpContato : UserControl
    {
        public HlpContato()
        {
            InitializeComponent();
            this.lColumns = new ObservableCollection<string>();
            this.lColumns.CollectionChanged += lColumns_CollectionChanged;
        }

        public bool IsReadOnlyUserControl
        {
            get { return (bool)GetValue(IsReadOnlyProperty); }
            set { SetValue(IsReadOnlyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsReadOnly.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsReadOnlyProperty =
            DependencyProperty.Register("IsReadOnlyUserControl", typeof(bool), typeof(HlpContato), new PropertyMetadata(false));

        public IEnumerable ItemsSourceContatos
        {
            get { return (IEnumerable)GetValue(ItemsSourceContatosProperty); }
            set { SetValue(ItemsSourceContatosProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemsSourceContatos.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsSourceContatosProperty =
            DependencyProperty.Register("ItemsSourceContatos", typeof(IEnumerable), typeof(HlpContato), new PropertyMetadata());

        #region Collection para manipulação de visibilidade de colunas

        void lColumns_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems == null)
                return;
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                foreach (string item in e.NewItems)
                {
                    foreach (var col in this.dgv.Columns)
                    {
                        PropertyInfo pi = col.GetType().GetProperty(name: "Binding");
                        if (pi != null)
                        {
                            object o = pi.GetValue(col);

                            if (o != null)
                            {
                                Binding b = o as Binding;

                                PropertyPath p = b.GetType().GetProperty(name: "Path").GetValue(obj: b) as PropertyPath;

                                if (p.Path == item)
                                    col.Visibility = System.Windows.Visibility.Visible;
                            }
                        }
                    }
                }
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                foreach (string item in e.OldItems)
                {
                    foreach (var col in this.dgv.Columns)
                    {
                        PropertyInfo pi = col.GetType().GetProperty(name: "Binding");
                        if (pi != null)
                        {
                            object o = pi.GetValue(col);

                            if (o != null)
                            {
                                Binding b = o as Binding;

                                PropertyPath p = b.GetType().GetProperty(name: "Path").GetValue(obj: b) as PropertyPath;

                                if (p.Path == item)
                                    col.Visibility = System.Windows.Visibility.Collapsed;
                            }
                        }
                    }
                }
            }
        }

        private ObservableCollection<string> _lColumns;

        public ObservableCollection<string> lColumns
        {
            get { return _lColumns; }
            set
            {
                _lColumns = value;
            }
        }

        #endregion

        private void Row_DoubleClick(object sender, MouseButtonEventArgs eventArgs)
        {
            ICommand AddCommand = Application.Current.MainWindow.DataContext.GetType()
                    .GetProperty(name: "AddWindowCommand").GetValue(obj: Application.Current.MainWindow.DataContext) as ICommand;


            if (AddCommand != null)
            {
                AddCommand.Execute(parameter: "WinContato");
                int id = 0;
                object objModel = (dgv.Items[index: dgv.SelectedIndex]);

                if (objModel != null)
                {

                    PropertyInfo pi = objModel.GetType().GetProperty(name: "idContato");

                    if (pi != null)
                    {
                        object _id = pi.GetValue(obj: objModel);

                        if (_id != null)
                        {
                            if (int.TryParse(s: _id.ToString(), result: out id))
                            {
                                object winManPropertyValue = Application.Current.MainWindow.DataContext.GetType()
                                    .GetProperty(name: "winMan").GetValue(obj: Application.Current.MainWindow.DataContext);

                                object _currentTab = winManPropertyValue.GetType().GetProperty(name: "_currentTab")
                                    .GetValue(obj: winManPropertyValue);

                                object _DataContext = _currentTab.GetType().GetProperty(name: "_currentDataContext")
                                    .GetValue(obj: _currentTab);

                                _DataContext.GetType().GetProperty(name: "currentID").SetValue(obj: _DataContext, value: id);


                                object currentModel =
                                    _DataContext.GetType().GetProperty(name: "currentModel").GetValue(obj: _DataContext);

                                if (currentModel != null)
                                {

                                    if (MessageHlp.Show(stMessage: StMessage.stYesNo,
                                        xMessageToUser: "Window está sendo utilizada no momento, deseja cancelar a operação corrente " +
                                        " e pesquisar o registro?") != MessageBoxResult.Yes)
                                    {
                                        return;
                                    }

                                    _DataContext.GetType().GetProperty(name: "currentModel").SetValue(obj:
                                        _DataContext, value: null);
                                }

                                //MethodInfo miSetOp = _DataContext.GetType().GetMethod(
                                //    name: "SetValorCurrentOp");

                                //object[] _params = new object[] { OperationModel.searching };

                                //miSetOp.Invoke(obj: _DataContext, parameters: _params);

                                _DataContext.GetType().GetProperty(name: "bIsEnabled")
                                    .SetValue(obj: _DataContext, value: false);

                                BackgroundWorker bw = _DataContext.GetType().GetProperty(
                                    name: "bWorkerPesquisa").GetValue(obj: _DataContext) as BackgroundWorker;

                                if (bw != null)
                                {
                                    bw.RunWorkerAsync();
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
