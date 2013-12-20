using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using HLP.Comum.View.Formularios;
using HLP.Entries.ViewModel.ViewModels.Comercial;

namespace HLP.Entries.View.WPF.Comercial
{
    /// <summary>
    /// Interaction logic for WinCliente.xaml
    /// </summary>
    public partial class WinCliente : WindowsBase
    {
        public WinCliente()
        {
            InitializeComponent();
            this.ViewModel = new ClienteViewModel();
            #region TESTES
            //List<TabItem> lTabs = GetLogicalChildCollection<TabItem>(this);
            //foreach (TabItem item in lTabs)
            //    ((TabControl)item.Parent).SelectedItem = item;
            //((TabControl)lTabs[0].Parent).SelectedItem = lTabs[0];
            #endregion
        }

        #region TESTES
        public static List<T> GetLogicalChildCollection<T>(object parent) where T : DependencyObject
        {
            List<T> logicalCollection = new List<T>();
            GetLogicalChildCollection(parent as DependencyObject, logicalCollection);
            return logicalCollection;
        }
        private static void GetLogicalChildCollection<T>(DependencyObject parent, List<T> logicalCollection) where T : DependencyObject
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
        }
        #endregion


        public ClienteViewModel ViewModel
        {
            get
            {
                return this.DataContext as ClienteViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

        private void dgvEndereco_CurrentCellChanged(object sender, EventArgs e)
        {
            this.dgvEndereco.BindingGroup.UpdateSources();
        }

    }
}
