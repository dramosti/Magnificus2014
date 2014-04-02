using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace HLP.Components.View.WPF.Converter
{
    public class VisibilityDatePickerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch ((StFormatoDatePicker)value)
            {
                case StFormatoDatePicker.date:
                    {
                        if (parameter.ToString() == "txtHora")
                            return Visibility.Collapsed;
                        else
                            return Visibility.Visible;
                    }
                case StFormatoDatePicker.time:
                    {
                        if (parameter.ToString() == "txtHora")
                            return Visibility.Visible;
                        else
                            return Visibility.Collapsed;
                    }
                default:
                    {
                        return Visibility.Visible;
                    }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
