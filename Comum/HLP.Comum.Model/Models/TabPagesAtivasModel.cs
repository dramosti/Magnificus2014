using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using HLP.Comum.Infrastructure.Static;

namespace HLP.Comum.Model.Models
{
    public class TabPagesAtivasModel : modelBase
    {
        public TabPagesAtivasModel()
        {

        }

        private Window Windows;

        public Window _windows
        {
            get { return Windows; }
            set
            {
                Windows = value;
                (value.Content as Panel).PreviewKeyDown -= new KeyEventHandler(this.Components_PreviewKeyDown);
                (value.Content as Panel).PreviewKeyDown += new KeyEventHandler(this.Components_PreviewKeyDown);
                lControlesWindow = GetLogicalChildCollection<Control>(value.Content).Where(c => c.GetType().BaseType.Name == "BaseControl").ToList();
                try
                { this.NameView = value.GetPropertyValue("NameView").ToString(); }
                catch (Exception) { }
            }
        }

        private string _NameView = string.Empty;
        public string NameView
        {
            get { return _NameView; }
            set { _NameView = value; }
        }

        public string _header
        {
            get { return this.Windows.Title; }
        }

        public UIElement _content
        {
            get
            {
                UIElement e = _windows.Content as UIElement;
                (e as Panel).DataContext = this.Windows.DataContext;
                
                return e;
            }
        }

      
        /// <summary>
        /// Ainda não esta sendo usado, mas caso necessário ja existe a lista dos componentes da window
        /// </summary>
        public List<Control> lControlesWindow { get; set; }

        public object _currentDataContext
        {
            get
            {
                return this.Windows.DataContext;
            }
        }

        #region Events

        public void Components_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var uie = e.OriginalSource as UIElement;
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                uie.MoveFocus(
                new TraversalRequest(
                FocusNavigationDirection.Next));
            }
        }
        #endregion



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
        public void SecondComponentFocus(System.Windows.Controls.Panel _panel)
        {
            _panel.Focus();

            _panel.MoveFocus(new TraversalRequest(FocusNavigationDirection.First));
            System.Windows.Controls.Control ctr = (System.Windows.Controls.Control)Keyboard.FocusedElement;
            while (ctr.GetType() != typeof(System.Windows.Controls.TextBox))
            {
                ctr.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                ctr = (System.Windows.Controls.Control)Keyboard.FocusedElement;
                if (ctr.GetType() == typeof(System.Windows.Controls.ComboBox))
                    break;
            }
            if (ctr.GetType() == typeof(System.Windows.Controls.TextBox))
                ctr.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
        }
    }
}
