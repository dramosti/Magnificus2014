using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace HLP.Comum.View.Validates
{
    public class ListUniqueValuesValidationRule : ValidationRule
    {
        public string xCampos { get; set; }

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value == null)
                return ValidationResult.ValidResult;

            BindingGroup bg = value as BindingGroup;
            DataGrid dgv = bg.Owner as DataGrid;
            string[] aCampos = xCampos.Split('-');
            List<string> lValoresCurrent = null;
            List<string> lValores = null;
            List<bool> lDuplicados = new List<bool>();

            if (dgv.Items != null)
                if (dgv.CurrentItem == null)
                    return ValidationResult.ValidResult;

            foreach (var item in dgv.Items)
            {
                if (dgv.CurrentItem != CollectionView.NewItemPlaceholder &&
                    item != CollectionView.NewItemPlaceholder && item != dgv.CurrentItem 
                    && dgv.Items.IndexOf(item: dgv.CurrentItem) >= 0)
                {

                    if (lValoresCurrent == null)
                    {
                        lValoresCurrent = new List<string>();
                        foreach (string c in aCampos)
                        {
                            lValoresCurrent.Add(item:
                                dgv.CurrentItem.GetType().GetProperty(name: c).GetValue(dgv.CurrentItem).ToString());
                        }

                    }

                    lValores = new List<string>();
                    foreach (string c in aCampos)
                    {
                        lValores.Add(item:
                            item.GetType().GetProperty(name: c).GetValue(item).ToString());
                    }

                    if (lValoresCurrent.SequenceEqual(lValores))
                        return new ValidationResult(isValid: false,
                errorContent: "Já existe um item inserido com os mesmos valores");
                }
            }

            return ValidationResult.ValidResult;
        }
    }
}
