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
using HLP.Base.Static;
using HLP.Components.Model.Models;

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
            this.getClasseFinanceira = commands.getClasseFinanceira;
            this.getOperacao = commands.getOperacao;
        }

        public string ReturnMaskcAlternativo(string value)
        {
            string xValueMasked = Util.ReturnValueMasked(xMask: (HLP.Base.Static.CompanyData.objEmpresaModel as EmpresaModel)
                .empresaParametros.ObjParametro_EstoqueModel.xMascaraFamiliaProduto,
                _value: value);

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

        public List<modelToTreeView> GetHierarquia()
        {
            if (this.currentModel != null)
                return this.commands.GetHierarquia(xCodAlt: this.currentModel.xFamiliaProduto,
                    xMask: (HLP.Base.Static.CompanyData.objEmpresaModel as EmpresaModel)
                    .empresaParametros.ObjParametro_EstoqueModel.xMascaraFamiliaProduto);
            else
                return null;
        }


        private Func<int, bool, object> _getOperacao;

        public Func<int, bool, object> getOperacao
        {
            get { return _getOperacao; }
            set { _getOperacao = value; }
        }

        private Func<int, bool, object> _getClasseFinanceira;

        public Func<int, bool, object> getClasseFinanceira
        {
            get { return _getClasseFinanceira; }
            set { _getClasseFinanceira = value; }
        }
        
        

    }
}
