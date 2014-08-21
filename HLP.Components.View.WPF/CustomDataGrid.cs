using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using HLP.Base.Static;
using System.Reflection;
using System.Windows.Controls.Primitives;

namespace HLP.Components.View.WPF
{
    public class CustomDataGrid : DataGrid
    {
        private bool bIsLastColumn;
        public CustomDataGrid()
        {
            bIsLastColumn = false;
        }

        protected override void OnCellEditEnding(DataGridCellEditEndingEventArgs e)
        {
            base.OnCellEditEnding(e);

            if (e.Column.GetType() == typeof(DataGridTemplateColumn))
            {
                var popup = Util.GetVisualChild<Popup>(e.EditingElement);
                if (popup != null && popup.IsOpen)
                {
                    e.Cancel = true;
                }
            }
        }        

        protected override void OnExecutedBeginEdit(System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            base.OnExecutedBeginEdit(e);
            try
            {
                if (this.CurrentCell.Column != null)
                {
                    if (this.CurrentCell.Column.Header != null)
                    {
                        if (this.CurrentCell.Column.Header.ToString().ToUpper().Equals("CEP"))
                            if (this.CurrentItem != null)
                                this.CurrentItem.SetPropertyValue("bCanFindCep", true);
                    }                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected override void OnExecutedCommitEdit(System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            base.OnExecutedCommitEdit(e);
            try
            {
                if (this.CurrentCell.Column != null)
                {
                    if (this.CurrentCell.Column.Header != null)
                    {
                        if (this.CurrentCell.Column.Header.ToString().ToUpper().Equals("CEP"))
                        {
                            if (this.CurrentItem != null)
                            {
                                this.CurrentItem.SetPropertyValue("bCanFindCep", false);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected override void OnSelectedCellsChanged(SelectedCellsChangedEventArgs e)
        {
            base.OnSelectedCellsChanged(e);

            if (!this.IsReadOnly)
            {
                if (e.AddedCells.Count == 0) return;

                var currentCell = e.AddedCells[0];
                string header = (string)currentCell.Column.Header;
                this.BeginEdit();                
            }
        }

        protected override void OnKeyDown(System.Windows.Input.KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.Key == System.Windows.Input.Key.Tab)
            {
                if(this.bIsLastColumn)
                {

                }

                this.bIsLastColumn = this.lastColumn == this.CurrentCell.Column;
            }
        }



        public DataGridColumn lastColumn
        {
            get { return (DataGridColumn)GetValue(lastColumnProperty); }
            set { SetValue(lastColumnProperty, value); }
        }

        // Using a DependencyProperty as the backing store for lastColumn.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty lastColumnProperty =
            DependencyProperty.Register("lastColumn", typeof(DataGridColumn),
            typeof(CustomDataGrid), new PropertyMetadata(null));


    }
}
