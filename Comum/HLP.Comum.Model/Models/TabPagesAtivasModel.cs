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
    public class TabPagesAtivasModel : ModelBase
    {
        public TabPagesAtivasModel()
        {
        }

        private TabItem openTab;

        public TabItem _openTab
        {
            get { return openTab; }
            set
            {
                openTab = value;
                base.NotifyPropertyChanged(propertyName: "_openTab");
            }
        }

        private string xNomeTab;

        public string _xNomeTab
        {
            get { return _xNomeTab; }
            set
            {
                xNomeTab = value;
                base.NotifyPropertyChanged(propertyName: "_xNomeTab");
            }
        }
    }
}
