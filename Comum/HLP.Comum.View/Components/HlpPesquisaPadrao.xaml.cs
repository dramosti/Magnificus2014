using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
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
using HLP.Comum.ViewModel.ViewModels.Components;

namespace HLP.Comum.View.Components
{
    /// <summary>
    /// Interaction logic for HlpPesquisaPadrao.xaml
    /// </summary>
    public partial class HlpPesquisaPadrao : UserControl
    {
        public HlpPesquisaPadraoViewModel ViewModel
        {
            get { return this.DataContext as HlpPesquisaPadraoViewModel; }
            set { this.DataContext = value; }
        }
        public HlpPesquisaPadrao()
        {
            InitializeComponent();

            DataGridCell cell = new DataGridCell();

            //cell.GotFocus += cell_GotFocus;

        }

        #region Property
        [Category("HLP.Owner")]
        public string NameView
        {
            get { return (string)GetValue(NameViewProperty); }
            set { SetValue(NameViewProperty, value); }
        }
        // Using a DependencyProperty as the backing store for NameView.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NameViewProperty =
            DependencyProperty.Register("NameView", typeof(string), typeof(HlpPesquisaPadrao), new PropertyMetadata(string.Empty));

        [Browsable(false)]
        [Category("HLP.Owner")]
        public List<int> lResult
        {
            get { return (List<int>)GetValue(lResultProperty); }
            set { SetValue(lResultProperty, value); }
        }
        // Using a DependencyProperty as the backing store for lResult.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty lResultProperty =
            DependencyProperty.Register("lResult", typeof(List<int>), typeof(HlpPesquisaPadrao), new PropertyMetadata(new List<int>()));
        #endregion

        #region Events
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.ViewModel = new HlpPesquisaPadraoViewModel(NameView);
        }
        private void DataGridCell_GotFocus(object sender, RoutedEventArgs e)
        {
            DataGridCell cell = sender as DataGridCell;
            if (cell != null && !cell.IsEditing && !cell.IsReadOnly)
            {
                if (!cell.IsFocused)
                {
                    cell.Focus();
                }
                DataGrid dataGrid = FindVisualParent<DataGrid>(cell);
                if (dataGrid != null)
                {
                    if (dataGrid.SelectionUnit != DataGridSelectionUnit.FullRow)
                    {
                        if (!cell.IsSelected)
                        {
                            cell.IsSelected = true;
                            cell.IsEditing = true;
                        }

                    }
                    else
                    {
                        DataGridRow row = FindVisualParent<DataGridRow>(cell);
                        if (row != null && !row.IsSelected)
                        {
                            row.IsSelected = true;
                        }
                    }
                }
            }
        }
       
        #endregion


        #region Methods
        static T FindVisualParent<T>(UIElement element) where T : UIElement
        {
            UIElement parent = element;
            while (parent != null)
            {
                T correctlyTyped = parent as T;
                if (correctlyTyped != null)
                {
                    return correctlyTyped;
                }

                parent = VisualTreeHelper.GetParent(parent) as UIElement;
            }
            return null;
        }
        #endregion

        private void dgvResult_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {                
                lResult = (from c in dgvResult.SelectedItems.Cast<DataRowView>()
                           select (int)c.Row["ID"]).ToList<int>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

      
        private void dgvResult_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            Window win = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == this.Name);
            win.Close();           

            
        }



    }
}
