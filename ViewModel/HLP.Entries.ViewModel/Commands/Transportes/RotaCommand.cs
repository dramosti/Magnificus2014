using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Entries.ViewModel.ViewModels.Transportes;

namespace HLP.Entries.ViewModel.Commands.Transportes
{
    public class RotaCommand
    {
        RotaViewModel objViewModel;
        rotaService.IserviceRotaClient servico = new rotaService.IserviceRotaClient();
        public RotaCommand(RotaViewModel objViewModel)
        {
            this.objViewModel = objViewModel;
        }

        
    }
}
