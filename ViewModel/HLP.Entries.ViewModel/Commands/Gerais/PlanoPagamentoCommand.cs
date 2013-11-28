using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Entries.ViewModel.ViewModels.Gerais;

namespace HLP.Entries.ViewModel.Commands.Gerais
{
    public class PlanoPagamentoCommand
    {
        PlanoPagamentoViewModel objViewModel;
        public PlanoPagamentoCommand(PlanoPagamentoViewModel objViewModel) 
        {
            this.objViewModel = objViewModel;

        }
    }
}
