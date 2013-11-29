using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Entries.ViewModel.ViewModels.Financeiro;

namespace HLP.Entries.ViewModel.Commands.Financeiro
{
    public class DescontosAvistaCommand
    {
        DescontosAvistaViewModel objViewModel;

        public DescontosAvistaCommand(DescontosAvistaViewModel objViewModel)
        {
            this.objViewModel = objViewModel;
        }

    }
}
