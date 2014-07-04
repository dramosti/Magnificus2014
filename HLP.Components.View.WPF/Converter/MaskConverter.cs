using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HLP.Components.View.WPF.Converter
{
    public class MaskConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return null;

            if (parameter == null)
                return null;

            value = value.ToString().Replace(oldValue: ".", newValue: "")
                            .Replace(oldValue: ",", newValue: "")
                            .Replace(oldValue: "-", newValue: "")
                            .Replace(oldValue: "/", newValue: "")
                            .Replace(oldValue: "\\", newValue: "")
                            .Replace(oldValue: " ", newValue: "");

            if (parameter.ToString() == "cpfcnpj")
            {
                if (value.ToString().Length < 14)
                    parameter = "cpf";
                else
                    parameter = "cnpj";
            }

            switch (parameter.ToString())
            {
                case "cnpj":
                    {
                        value = value.ToString().Replace(oldValue: " ", newValue: "");
                        if (value.ToString().Length > 14)
                            value = value.ToString().Substring(startIndex: 0, length: 14);

                        long valor;
                        if (long.TryParse(s: value.ToString(), result: out valor))
                        {
                            return String.Format(@"{0:00\.000\.000\/0000\-00}", valor);
                        }

                    }
                    break;
                case "placa":
                    {
                        value = value.ToString().Replace(oldValue: " ", newValue: "");
                        if (value.ToString().Length > 7)
                            value = value.ToString().Substring(startIndex: 0, length: 7);
                        if (value.ToString().Length <= 3)
                            value = value.ToString().PadLeft(7, '0');
                        string sReturn = (string)value;

                        return sReturn.Insert(3, "-");
                    }
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
                        if (value.ToString().Count() > 0)
                        {
                            if (value.ToString()[0] == '0')
                                value = value.ToString().Remove(startIndex: 0, count: 1);

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
                            }
                        }
                    } break;
                case "date":
                    {
                        DateTime dValue;

                        if (DateTime.TryParse(s: value.ToString(), result: out dValue))
                            return String.Format(format: "{0:dd/MM/yyyy}", arg0: dValue);

                        return DateTime.MinValue;
                    }
                case "cpf":
                    {
                        string ret = "";
                        int cont = 0;
                        value = value.ToString().Replace(oldValue: " ", newValue: "");
                        value = value.ToString().Replace(oldValue: ".", newValue: "");
                        value = value.ToString().Replace(oldValue: "-", newValue: "");
                        value = value.ToString().Replace(oldValue: ",", newValue: "");

                        foreach (char c in value.ToString())
                        {
                            ret += c;

                            if (cont == 2 || cont == 5)
                                ret += '.';
                            else if (cont == 8)
                                ret += '-';

                            cont++;
                        }

                        return ret;
                    }
                case "rg":
                    {
                        string ret = "";
                        int cont = 0;
                        value = value.ToString().Replace(oldValue: " ", newValue: "");
                        value = value.ToString().Replace(oldValue: ".", newValue: "");
                        value = value.ToString().Replace(oldValue: "-", newValue: "");
                        value = value.ToString().Replace(oldValue: ",", newValue: "");

                        foreach (char c in value.ToString())
                        {
                            ret += c;

                            if (cont == 1 || cont == 4)
                                ret += '.';
                            else if (cont == 7)
                                ret += '-';

                            cont++;
                        }
                        return ret;
                    }

            }
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return "";
            }
            switch (parameter.ToString())
            {
                case "cnpj":
                    {
                        string valor;
                        valor = value.ToString().Replace(oldValue: "-", newValue: "").Replace(oldValue: "/", newValue: "").Replace(oldValue: ".", newValue: "");
                        if (valor.ToString().Length > 14)
                            valor = valor.ToString().Substring(startIndex: 0, length: 14);
                        return valor;
                    }
                case "placa":
                    {
                        string valor;
                        valor = value.ToString().Replace(oldValue: "-", newValue: "");
                        return valor;
                    }
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
