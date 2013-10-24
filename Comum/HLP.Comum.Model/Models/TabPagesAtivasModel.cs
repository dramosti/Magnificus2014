using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HLP.Comum.Model.Models
{
    public class TabPagesAtivasModel
    {
        public TabPagesAtivasModel()
        {
        }

        private Window Windows;

        public Window _windows
        {
            get { return Windows; }
            set { Windows = value; }
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
                (e as Grid).DataContext = this.Windows.DataContext;
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
    }
}
