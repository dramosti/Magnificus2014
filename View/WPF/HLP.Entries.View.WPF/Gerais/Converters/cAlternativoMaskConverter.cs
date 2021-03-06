﻿using HLP.Base.Static;
using HLP.Entries.ViewModel.ViewModels.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HLP.Entries.View.WPF.Gerais.Converters
{
    public class cAlternativoMaskConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return string.Empty;

            WinFamiliaProduto wFamiliaProduto = Sistema.GetOpenWindow(xName: "WinFamiliaProduto") as WinFamiliaProduto;

            if (wFamiliaProduto == null)
                return string.Empty;

            if (wFamiliaProduto.ViewModel.GetLengthMaskcAlternativo() == 0)
                return value.ToString();

            return wFamiliaProduto.ViewModel.ReturnMaskcAlternativo(value: value.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            List<char> specialChars = new List<char>
            {
                '.', ',', '(', ')', '-', '_', '{', '}', '[', ']', '\\', '/'
            };

            if (value == null)
                return string.Empty;

            foreach (char c in specialChars)
            {
                value = value.ToString().Replace(oldValue: c.ToString(), newValue: "");
            }

            WinFamiliaProduto wFamiliaProduto = Sistema.GetOpenWindow(xName: "WinFamiliaProduto") as WinFamiliaProduto;

            if (wFamiliaProduto == null)
                return string.Empty;

            int maskLength = wFamiliaProduto.ViewModel.GetLengthMaskcAlternativo();

            return maskLength > 0 ? (value.ToString().Length > maskLength ? value.ToString().Substring(startIndex: 0, length: maskLength)
                : value.ToString()) : value.ToString();
        }
    }
}
