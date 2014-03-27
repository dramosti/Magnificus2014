using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HLP.Entries.View.WPF.Converters
{
    public class dataEspelhoPontoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                if (value != null)
                {
                    return ((DateTime)value).ToString("MM/yyyy");
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                if (value != null)
                {
                    value = value.ToString().Replace(oldValue: "/", newValue: "");
                    value = value.ToString().Replace(oldValue: ".", newValue: "");

                    int iAno;
                    int iMes;

                    int ivalidDate;
                    int.TryParse(value.ToString(), out ivalidDate);
                    if (ivalidDate != 0)
                    {
                        if (value.ToString().Length == 4)
                        {
                            iAno = System.Convert.ToInt32("20" + value.ToString().Substring(2, 2));
                            iMes = System.Convert.ToInt32(value.ToString().Substring(0, 2));
                            return new DateTime(iAno, iMes, 1);
                        }
                        else if (value.ToString().Length == 6)
                        {
                            iAno = System.Convert.ToInt32(value.ToString().Substring(2, 4));
                            iMes = System.Convert.ToInt32(value.ToString().Substring(0, 2));
                            return new DateTime(iAno, iMes, 1);
                        }
                    }

                }
                return DateTime.Today;
            }
            catch (Exception)
            {
                return DateTime.Today;
            }
        }
    }
}
