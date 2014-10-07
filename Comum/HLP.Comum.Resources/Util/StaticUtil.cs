using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Threading;

namespace HLP.Comum.Resources.Util
{
    public static class StaticUtil
    {
        public static Window GetParentWindow(DependencyObject child)
        {
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);

            if (parentObject == null)
            {
                return null;
            }

            Window parent = parentObject as Window;
            if (parent != null)
            {
                return parent;
            }
            else
            {
                return GetParentWindow(parentObject);
            }
        }

        public static T GetVisualChild<T>(Visual parent) where T : Visual
        {
            T child = default(T);
            int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < numVisuals; i++)
            {
                Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);
                child = v as T;
                if (child == null)
                {
                    child = GetVisualChild<T>(v);
                }
                if (child != null)
                {
                    break;
                }
            }
            return child;
        }

        public static System.Windows.Controls.DataGridCell GetCell(this System.Windows.Controls.DataGrid grid, DataGridRow row, int column)
        {
            if (row != null)
            {
                DataGridCellsPresenter presenter = StaticUtil.GetVisualChild<DataGridCellsPresenter>(row);
                System.Windows.Controls.DataGridCell cell = null;

                if (presenter != null)
                    cell =
                        (System.Windows.Controls.DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(column);
                return cell;
            }
            return null;
        }

        public static List<T> GetLogicalChildCollection<T>(object parent) where T : DependencyObject
        {
            List<T> logicalCollection = new List<T>();
            GetLogicalChildCollection(parent as DependencyObject, logicalCollection);
            return logicalCollection;
        }

        private static void GetLogicalChildCollection<T>(DependencyObject parent, List<T> logicalCollection) where T : DependencyObject
        {
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, (Action)(() =>
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
            }));
        }

         


    }
}
