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
using System.Collections;
using System.Windows.Data;

namespace HLP.Entries.ViewModel.ViewModels.Gerais
{
    public class PlanoPagamentoViewModel : viewModelComum<Plano_pagamentoModel>
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

        PlanoPagamentoCommand commands;

        public PlanoPagamentoViewModel()
        {
            commands = new PlanoPagamentoCommand(objViewModel: this);
        }

        public void PlanoSort()
        {
            ListCollectionView lcv = (ListCollectionView)CollectionViewSource.GetDefaultView(source: this.currentModel.lPlano_pagamento_linhasModel);

            lcv.CustomSort = new PlanoPagamentoSort();
        }

    }

    public class PlanoPagamentoSort : IComparer
    {

        public int Compare(object x, object y)
        {
            if ((x as Plano_pagamento_linhasModel).nQuantidade < (y as Plano_pagamento_linhasModel).nQuantidade) return -1;
            else if ((x as Plano_pagamento_linhasModel).nQuantidade > (y as Plano_pagamento_linhasModel).nQuantidade) return 1;
            else return 0;
        }
    }
}
