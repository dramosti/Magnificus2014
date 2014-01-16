using HLP.Entries.ViewModel.ViewModels.Gerais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace HLP.Entries.View.WPF.Validates
{
    public class ValidaUsuarioValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            BindingGroup bg = value as BindingGroup;
            foreach (var r in bg.Items)
            {
                if (r.GetType().GetProperty("xID") != null)
                {
                    object vlLogin = r.GetType().GetProperty("xID").GetValue(obj: r) ?? "";
                    object vlSenha = r.GetType().GetProperty("xSenha").GetValue(obj: r) ?? "";
                    object vlIdFuncionario = r.GetType().GetProperty("idFuncionario").GetValue(obj: r);
                    Funcionario_AcessoViewModel vm = (bg.Owner as WrapPanel).DataContext as Funcionario_AcessoViewModel;

                    if (!vm.ValidaUsuario(xLogin: vlLogin.ToString()
                        , xSenha: vlSenha.ToString(),
                        idFuncionario: (int)(vlIdFuncionario ?? 0)))
                    {
                        return new ValidationResult(isValid: false, errorContent: "Já existe um usuário com o mesmo login e senha");
                    }
                }
            }

            return ValidationResult.ValidResult;

        }
    }
}
