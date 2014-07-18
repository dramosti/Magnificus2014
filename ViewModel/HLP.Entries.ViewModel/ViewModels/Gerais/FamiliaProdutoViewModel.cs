using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HLP.Base.ClassesBases;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.ViewModel.Commands.Gerais;
using HLP.Comum.ViewModel.ViewModel;

namespace HLP.Entries.ViewModel.ViewModels.Gerais
{
    public class FamiliaProdutoViewModel : viewModelComum<Familia_produtoModel>
    {
        #region Icommands
        public ICommand commandSalvar { get; set; }
        public ICommand commandDeletar { get; set; }
        public ICommand commandNovo { get; set; }
        public ICommand commandAlterar { get; set; }
        public ICommand commandCancelar { get; set; }
        public ICommand commandCopiar { get; set; }
        public ICommand commandPesquisar { get; set; }
        public ICommand navegarCommand { get; set; }
        #endregion

        FamiliaProdutoCommand commands;

        public FamiliaProdutoViewModel()
        {
            commands = new FamiliaProdutoCommand(objViewModel: this);
        }

        public string ReturnMaskcAlternativo(string value)
        {
            string _value = value.Replace(oldValue: ".", newValue: "");

            string xMask = string.Empty;
            int count = 0;
            List<object> lObjects = new List<object>();

            foreach (char car in (HLP.Base.Static.CompanyData.objEmpresaModel as EmpresaModel)
                .empresaParametros.ObjParametro_EstoqueModel.xMascaraFamiliaProduto)
            {
                if (car == '.')
                {
                    xMask += '.';
                }
                else
                {
                    xMask += "{" + count.ToString() + "}";
                    count++;
                }
            }

            for (int i = 0; i < count; i++)
            {
                if (i < _value.Length)
                    lObjects.Add(item: _value[index: i]);
                else
                    lObjects.Add(item: " ");
            }

            string xValueMasked = string.Format(format: xMask, args: lObjects.ToArray());

            int countSeparators = xValueMasked.Split(separator: '.').Count();
            if (countSeparators > 0)
            {
                string lastGroup = xValueMasked.Split(separator: '.')[countSeparators - 1];

                int vValido = 0;
                if (int.TryParse(s: lastGroup, result: out vValido))
                {
                    if (vValido == 0)
                        this.currentModel.stGrau = 1;
                    else
                        this.currentModel.stGrau = 0;
                }
            }

            return xValueMasked;
        }

        public int GetLengthMaskcAlternativo()
        {
            return (HLP.Base.Static.CompanyData.objEmpresaModel as EmpresaModel)
                .empresaParametros.ObjParametro_EstoqueModel.xMascaraFamiliaProduto.Replace(
                oldValue: ".", newValue: "").Length;
        }

    }
}
