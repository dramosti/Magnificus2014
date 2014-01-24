using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace HLP.Comum.View.Components
{
    public class CustomComboBox : ComboBox
    {
        public CustomComboBox()
        {
            this.PreviewMouseDown += new MouseButtonEventHandler(this.ComboBox_PreviewMouseDown);
        }

        private void ComboBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            DataGridCell c = ((sender as ComboBox).TemplatedParent as ContentPresenter).Parent as DataGridCell;

            if (!c.IsEditing)
            {
                if (c != null)
                {
                    if (c.IsFocused == false)
                    {
                        c.Focus();
                        var parent = VisualTreeHelper.GetParent(c);
                        while (parent != null && parent.GetType() != typeof(DataGrid))
                        {
                            parent = VisualTreeHelper.GetParent(parent);
                        }
                        (parent as DataGrid).BeginEdit();                        
                    }
                }
            }
        }
    }
}
