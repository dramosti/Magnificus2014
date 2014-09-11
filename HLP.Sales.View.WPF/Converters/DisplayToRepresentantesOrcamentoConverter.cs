using HLP.Entries.Model.Models.Gerais;
using HLP.Sales.Model.Models.Comercial;
using HLP.Sales.ViewModel.Commands.Comercio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace HLP.Sales.View.WPF.Converters
{
    public class DisplayToRepresentantesOrcamentoConverter : IMultiValueConverter
    {

        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0] != DependencyProperty.UnsetValue &&
                values[1] != DependencyProperty.UnsetValue)
            {
                IEnumerable<Orcamento_Item_RepresentantesModel> lRepresentantes = values[1] as IEnumerable<Orcamento_Item_RepresentantesModel>;

                if (lRepresentantes != null)
                {
                    if (lRepresentantes.Count() == 0)
                    {
                        return "Sem Representantes";
                    }
                    else if (lRepresentantes.Count() == 1)
                    {
                        Orcamento_Item_RepresentantesModel r = lRepresentantes.FirstOrDefault();
                        OrcamentoCommands comm = new OrcamentoCommands();

                        FuncionarioModel f = comm.GetFuncionario(idFuncionario: r.idRepresentante);

                        return string.Format(format: "Repr: {0}, Porc(%): {1}", arg0: f != null ? f.xNome : string.Empty, arg1: r.pComissao);
                    }
                    else
                        return string.Format(format: "Vários Repr. Porc(%) Total: {0}%", arg0: lRepresentantes.Sum(i => i.pComissao));
                }
                else
                    return string.Empty;
            }
            else
                return string.Empty;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
