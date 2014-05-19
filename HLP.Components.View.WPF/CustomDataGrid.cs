using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using HLP.Base.Static;
using System.Reflection;

namespace HLP.Components.View.WPF
{
    public class CustomDataGrid : DataGrid
    {
        public CustomDataGrid()
        {
        }

        protected override void OnExecutedBeginEdit(System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            base.OnExecutedBeginEdit(e);
            try
            {
                if (this.CurrentCell.Column != null)
                    if (this.CurrentCell.Column.Header.ToString().ToUpper().Equals("CEP"))
                        if (this.CurrentItem != null)
                            this.CurrentItem.SetPropertyValue("bCanFindCep", true);
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
                    if (this.CurrentCell.Column.Header.ToString().ToUpper().Equals("CEP"))
                    {
                        if (this.CurrentItem != null)
                        {
                            this.CurrentItem.SetPropertyValue("bCanFindCep", false);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
