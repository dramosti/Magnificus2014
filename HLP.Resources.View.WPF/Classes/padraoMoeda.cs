using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HLP.Resources.View.WPF.Classes
{
    public class padraoMoeda : INotifyPropertyChanged
    {
        char[] caracters = new char[] { '\t', ' ' };


        private string _xCodigo;

        public string xCodigo
        {
            get { return _xCodigo; }
            set
            {
                //if (!string.IsNullOrEmpty("TheImageYouWantToShow"))
                //{
                //    var yourImage = new BitmapImage(new Uri(String.Format("Classes/Icons/{0}.jpg", TheImageYouWantToShow), UriKind.Relative));
                //    yourImage.Freeze(); // -> to prevent error: "Must create DependencySource on same Thread as the DependencyObject"
                //    YourImage = yourImage;
                //}
                //else
                //{
                //    YourImage = null;
                //}

                _xCodigo = value.TrimStart(caracters).TrimEnd(caracters);

                var img = new BitmapImage(new Uri(String.Format(format: "Classes/Icons/IconsMoeda/{0}", arg0: _xCodigo)));

                if (img != null)
                {
                    img.Freeze();
                    this._xPathImagem = img;
                }

                this.NotifyPropertyChanged(propertyName: "xCodigo");
            }
        }

        private long _nNumero;

        public long nNumero
        {
            get { return _nNumero; }
            set
            {
                _nNumero = value;
                this.NotifyPropertyChanged(propertyName: "nNumero");
            }
        }


        private decimal _dCasasDecimais;

        public decimal dCasasDecimais
        {
            get { return _dCasasDecimais; }
            set
            {
                _dCasasDecimais = value;
                this.NotifyPropertyChanged(propertyName: "dCasasDecimais");
            }
        }


        private string _xMoeda;

        public string xMoeda
        {
            get { return _xMoeda; }
            set
            {
                _xMoeda = value.TrimStart(caracters).TrimEnd(caracters);
                this.NotifyPropertyChanged(propertyName: "xMoeda");
            }
        }


        private string _xPais;

        public string xPais
        {
            get { return _xPais; }
            set
            {
                _xPais = value.TrimStart(caracters).TrimEnd(caracters);
                this.NotifyPropertyChanged(propertyName: "xPais");
            }
        }

        private ImageSource _xPathImagem;

        public ImageSource xPathImagem
        {
            get { return _xPathImagem; }
            set
            {
                _xPathImagem = value;
                this.NotifyPropertyChanged(propertyName: "xPathImagem");
            }
        }


        #region NotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
