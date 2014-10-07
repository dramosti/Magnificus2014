using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace HLP.Comum.Model.Models
{
    public class FindAllModel : modelBase
    {
        private string _xNome;
        public string xNome
        {
            get { return _xNome; }
            set
            {
                _xNome = value; base.NotifyPropertyChanged("xNome");
                string sPath = System.AppDomain.CurrentDomain.BaseDirectory + @"Icones\" + value + ".png";
                if (File.Exists(path: sPath))
                {
                    this.icon = new BitmapImage(new Uri(sPath));
                }
            }
        }


        private string _xHeader;

        public string xHeader
        {
            get { return _xHeader; }
            set { _xHeader = value; base.NotifyPropertyChanged("xHeader"); }
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


    }
}
