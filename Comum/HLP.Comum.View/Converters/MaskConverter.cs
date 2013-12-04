using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HLP.Comum.View.Converters
{
    public class MaskConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return null;


            switch (parameter.ToString())
            {
                case "cep":
                    {
                        value = value.ToString().Replace(oldValue: " ", newValue: "");
                        if (value.ToString().Length > 8)
                            value = value.ToString().Substring(startIndex: 0, length: 8);

                        long valor;
                        if (long.TryParse(s: value.ToString(), result: out valor))
                        {
                            return String.Format(@"{0:##\.###\-###}", valor);
                        }
                    } break;
                case "tel":
                case "cel":
                    {
                        value = value.ToString().Replace(oldValue: " ", newValue: "");
                        if (value.ToString().Length > 11)
                            value = value.ToString().Substring(startIndex: 0, length: 10);

                        long valor;
                        if (long.TryParse(s: value.ToString(), result: out valor))
                        {
                            switch (valor.ToString().Length)
                            {
                                case 8:
                                    {
                                        return String.Format(@"{0:####\-####}", valor);
                                    }
                                case 9:
                                    {
                                        return String.Format(@"{0:#####\-####}", valor);
                                    }
                                case 10:
                                    {
                                        return String.Format(@"{0:\(##\) ####\-####}", valor);
                                    }
                                case 11:
                                    {
                                        return String.Format(@"{0:\(##\) #####\-####}", valor);
                                    }
                            }
                        } break;
                    }
                case "date":
                    {
                        DateTime dValue;

                        if (DateTime.TryParse(s: value.ToString(), result: out dValue))
                            return String.Format(format: "{0:dd/MM/yyyy}", arg0: dValue);

                        return DateTime.MinValue;
                    }
            }
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch (parameter.ToString())
            {
                case "cep":
                    {
                        string valor;
                        valor = value.ToString().Replace(oldValue: ".", newValue: "").Replace(oldValue: "-", newValue: "");
                        return valor;
                    }
                case "tel":
                case "cel":
                    {
                        string valor;
                        valor = value.ToString().Replace(oldValue: "(", newValue: "").Replace(oldValue: ")", newValue: "")
                            .Replace(oldValue: "-", newValue: "");
                        return valor;
                    }
                case "date":
                    {
                        DateTime dValor;

                        if (DateTime.TryParse(s: value.ToString(), result: out dValor))
                        {
                            return dValor;
                        }
                        return DateTime.MinValue;
                    }
            }
            return value.ToString();
        }
    }
}
