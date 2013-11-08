using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
