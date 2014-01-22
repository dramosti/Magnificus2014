using System;
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
                e.PreviewKeyDown += new KeyEventHandler(this.Components_PreviewKeyDown);
                return e;
            }
        }

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

    }
}
