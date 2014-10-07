using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace HLP.Comum.Resources
{
    public class GotFocusBeginEditDataGridCell
    {

        //     <Style TargetType="{x:Type DataGridCell}">
        //    <Setter Property="Util:GotFocusBeginEditDataGridCell.BeginEdit" Value="True"/>
        //</Style>

        public static bool GetBeginEdit(DependencyObject obj)
        {
            return (bool)obj.GetValue(BeginEditProperty);
        }

        public static void SetBeginEdit(DependencyObject obj, bool value)
        {
            obj.SetValue(BeginEditProperty, value);
        }

        // Using a DependencyProperty as the backing store for BeginEdit.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BeginEditProperty =
            DependencyProperty.RegisterAttached("BeginEdit", typeof(bool), typeof(GotFocusBeginEditDataGridCell),
                                                new FrameworkPropertyMetadata(false, new PropertyChangedCallback(
                                                                                  OnAutoSelectChanged)));


        private static void OnAutoSelectChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataGridCell cell = (DataGridCell)d;

            if (cell != null)
            {
                //cell.GotFocus -= cell_GotFocus;
                //cell.GotFocus += cell_GotFocus;

                //DataGrid dataGrid = FindVisualParent<DataGrid>(cell);

                //dataGrid.LostFocus -= dataGrid_LostFocus;
                //dataGrid.LostFocus += dataGrid_LostFocus;
            }
        }

        static void dataGrid_LostFocus(object sender, RoutedEventArgs e)
        {
            DataGrid dataGrid = FindVisualParent<DataGrid>(Keyboard.FocusedElement as Control);

            if (dataGrid == null)
            {
                (sender as DataGrid).CommitEdit(editingUnit: DataGridEditingUnit.Row, exitEditingMode: true);
            }
           // throw new NotImplementedException();
        }

        static void cell_GotFocus(object sender, RoutedEventArgs e)
        {
            DataGridCell cell = sender as DataGridCell;
            DataGrid dataGrid = FindVisualParent<DataGrid>(cell);

            if (!cell.IsEditing)
                if (cell.Column != null)
                    if (cell.Column.GetType() == typeof(DataGridComboBoxColumn) || cell.Column.GetType() == typeof(DataGridTemplateColumn))
                    {
                        dataGrid.BeginEdit();
                        cell.IsEditing = true;
                    }
        }
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
    }
}
