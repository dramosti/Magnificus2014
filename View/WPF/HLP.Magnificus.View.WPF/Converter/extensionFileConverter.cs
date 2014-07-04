using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace HLP.Magnificus.View.WPF.Converter
{
    public class extensionFileConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            BitmapImage logo = new BitmapImage();

            if (value != null)
            {

                string xIcon = "iconAnyFile";

                switch (value.ToString())
                {
                    case ".doc":
                    case ".docx":
                        xIcon = "iconWord"; break;

                }

                Image finalImage = new Image();
                logo.BeginInit();
                logo.UriSource = new Uri(
                    string.Format(format: "pack://application:,,,/HLP.Resources.View.WPF;component/Images/{0}.png",
                    arg0: xIcon));
                logo.DecodePixelHeight =
                    logo.DecodePixelWidth = 25;
                logo.EndInit();
            }
            return logo;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
