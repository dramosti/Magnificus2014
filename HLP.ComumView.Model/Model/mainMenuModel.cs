using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace HLP.ComumView.Model.Model
{
    public class mainMenuModel : modelComum
    {
        public mainMenuModel()
        {
            this.lSubItens = new ObservableCollection<mainMenuModel>();
        }

        private string _nameWindow;

        public string nameWindow
        {
            get { return _nameWindow; }
            set
            {
                _nameWindow = value;
                base.NotifyPropertyChanged(propertyName: "nameWindow");

                string sPath = System.AppDomain.CurrentDomain.BaseDirectory + @"Icones\" + value + ".png";
                if (File.Exists(path: sPath))
                {
                    this.icon = new BitmapImage(new Uri(sPath));
                }
            }
        }

        private string _xCaption;

        public string xCaption
        {
            get { return _xCaption; }
            set
            {
                _xCaption = value;
                base.NotifyPropertyChanged(propertyName: "xCaption");
            }
        }

        private BitmapImage _icon;
        public BitmapImage icon
        {
            get { return _icon; }
            set
            {
                _icon = value; base.NotifyPropertyChanged("icon");
            }
        }

        private ObservableCollection<mainMenuModel> _lSubItens;

        public ObservableCollection<mainMenuModel> lSubItens
        {
            get { return _lSubItens; }
            set
            {
                _lSubItens = value;
                base.NotifyPropertyChanged(propertyName: "lSubItens");
            }
        }


    }
}
