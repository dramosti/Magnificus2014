using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Entries.ViewModel.ViewModels.Financeiro;

namespace HLP.Entries.ViewModel.Commands.Financeiro
{
    public class DiaPagamentoCommand
    {

        DiaPagamentoViewModel objViewModel;
        public DiaPagamentoCommand(DiaPagamentoViewModel objViewModel)
        {
            this.objViewModel = objViewModel;
        }
    }
}
