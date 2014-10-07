using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace HLP.Comum.Resources
{
    public class ComumEvents
    {
        public void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGridCell c = ((sender as ComboBox).TemplatedParent as ContentPresenter).Parent as DataGridCell;

            if (c != null)
            {
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
