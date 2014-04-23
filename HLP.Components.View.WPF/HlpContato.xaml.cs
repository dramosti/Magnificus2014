using HLP.Components.Model.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public IEnumerable ItemsSourceContatos
        {
            get { return (IEnumerable)GetValue(ItemsSourceContatosProperty); }
            set { SetValue(ItemsSourceContatosProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemsSourceContatos.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsSourceContatosProperty =
            DependencyProperty.Register("ItemsSourceContatos", typeof(IEnumerable), typeof(HlpContato), new PropertyMetadata(null));
        
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

    }
}
