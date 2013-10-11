using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HLP.Comum.Model.Models
{
    public class TabPagesAtivasModel : ModelBase
    {
        public TabPagesAtivasModel()
        {
        }

        private Window openWindow;

        public Window _openWindow
        {
            get { return openWindow; }
            set
            {
                openWindow = value;
                base.NotifyPropertyChanged(propertyName: "_openWindows");
            }
        }
    }
}
