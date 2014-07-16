using HLP.Components.Services;
using HLP.Components.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Components.ViewModel.Commands
{
    public class HlpEnderecoCommands
    {
        HlpEnderecoViewModel objViewModel;
        HlpEnderecoService objService;


        public HlpEnderecoCommands(HlpEnderecoViewModel objViewModel)
        {
            this.objViewModel = objViewModel;
            objService = new HlpEnderecoService();
        }

        public int? GetIdCidadeByDesc(string xDesc)
        {
            return objService.GetIdCidadeByDesc(xDesc: xDesc);
        }
    }
}
