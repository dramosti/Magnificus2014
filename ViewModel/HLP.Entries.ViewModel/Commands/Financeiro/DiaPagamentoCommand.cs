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
        Dia_PagamentoService.IserviceDiaPagamentoClient servico = new Dia_PagamentoService.IserviceDiaPagamentoClient();

        public DiaPagamentoCommand(DiaPagamentoViewModel objViewModel)
        {
            this.objViewModel = objViewModel;
        }
    }
}
