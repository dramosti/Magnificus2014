using HLP.Entries.Model.Models.Gerais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HLP.Entries.View.WPF.Gerais.Converters
{
    public class cAlternativoMaskToTreeViewConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return null;

            return HLP.Base.Static.Util.ReturnValueMasked(xMask:
                (HLP.Base.Static.CompanyData.objEmpresaModel as EmpresaModel).empresaParametros.ObjParametro_EstoqueModel.xMascaraFamiliaProduto,
                _value: value.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}
