using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using HLP.Base.Static;


namespace HLP.Comum.View.Validates
{
    public class ListUniqueValueTrueValidationRule : ValidationRule
    {
        public string xCampo { get; set; }
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value == null || xCampo == null)
                return ValidationResult.ValidResult;

            BindingGroup bg = value as BindingGroup;
            DataGrid dgv = bg.Owner as DataGrid;

            if (dgv.CurrentItem == null)
                return ValidationResult.ValidResult;

            if (dgv.Items.IndexOf(dgv.CurrentItem) >= 0)
            {
                if (dgv.Items.Count > 1)
                {
                    if (dgv.CurrentItem != CollectionView.NewItemPlaceholder)
                    {
                        object currentValor = dgv.CurrentItem.GetPropertyValue(xCampo);

                        if (currentValor != null)
                        {
                            if (Convert.ToByte(currentValor) == 1)
                                foreach (var item in dgv.Items)
                                {
                                    if (item != CollectionView.NewItemPlaceholder)
                                        if (item != dgv.CurrentItem)
                                            item.SetPropertyValue(xCampo, ((byte)0));
                                }
                        }
                        else
                        {
                            dgv.CurrentItem.SetPropertyValue(xCampo, ((byte)0));
                        }
                    }
                }
            }
            return ValidationResult.ValidResult;
        }
    }
}
