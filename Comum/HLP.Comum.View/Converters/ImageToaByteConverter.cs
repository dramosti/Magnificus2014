using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace HLP.Comum.View.Converters
{
    public class ImageToaByteConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                BitmapImage bi = null;
                if (value != null)
                {
                    bi = new BitmapImage();
                    bi.BeginInit();
                    bi.StreamSource = new MemoryStream(buffer: value as byte[]);
                    bi.EndInit();
                }

                return bi;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
