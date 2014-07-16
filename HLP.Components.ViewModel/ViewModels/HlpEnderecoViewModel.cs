using HLP.Components.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Components.ViewModel.ViewModels
{
    public class HlpEnderecoViewModel
    {
        HlpEnderecoCommands comm;
        public HlpEnderecoViewModel()
        {
            comm = new HlpEnderecoCommands(this);
        }

        public int? GetIdCidadeByDesc(string xDesc)
        {
            return comm.GetIdCidadeByDesc(xDesc: xDesc);
        }
    }
}
