using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Entries.ViewModel.ViewModels.Fiscal;

namespace HLP.Entries.ViewModel.Commands.Fiscal
{
    public class CodigoIcmsCommand
    {
        CodigoIcmsViewModel objViewModel;
        CodigoIcmsService.IserviceCodigoIcmsClient servico = new CodigoIcmsService.IserviceCodigoIcmsClient();

        public CodigoIcmsCommand(CodigoIcmsViewModel objViewModel) 
        {

        }


    }
}
