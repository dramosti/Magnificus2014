using HLP.Base.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HLP.Components.View.WPF.Converter
{
    public class MoedaConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            decimal d;
            if (value == null)
            {
                d = decimal.Zero;
            }
            else if (!decimal.TryParse(s: value.ToString(), result: out d))
            {
                d = decimal.Zero;
            }

            string sFormat = "{0:C2}";

            if (parameter != null)
            {
                object objEmpresa = CompanyData.objEmpresaModel;

                if (objEmpresa != null)
                {
                    object objParametrosEmpresa = objEmpresa.GetType().GetProperty(name: "empresaParametros").GetValue(obj: objEmpresa);

                    if (objParametrosEmpresa != null)
                    {
                        object objParametrosComercial = objParametrosEmpresa.GetType().GetProperty(name: "ObjParametro_ComercialModel")
                            .GetValue(obj: objParametrosEmpresa);

                        string xNameProperty = "";

                        if (objParametrosComercial != null)
                        {
                            xNameProperty = parameter.ToString();
                            byte vCasasDecimais = objParametrosComercial.GetType().
                                GetProperty(name: xNameProperty).GetValue(obj: objParametrosComercial) as byte? ?? 0;

                            sFormat = "{0:C" + vCasasDecimais.ToString() + "}";
                        }
                    }
                }
            }


            return String.Format(sFormat, d);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            decimal valor;

            if (value != null)
            {
                if (decimal.TryParse(value.ToString(), out valor))
                    return valor;
            }

            return decimal.Zero;
        }
    }
}
