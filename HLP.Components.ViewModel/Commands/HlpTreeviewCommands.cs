using HLP.Components.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Components.ViewModel.Commands
{
    public class HlpTreeviewCommands
    {
        HlpTreeviewViewModel objViewModel;        

        public HlpTreeviewCommands(HlpTreeviewViewModel objViewModel)
        {
            this.objViewModel = objViewModel;            
        }
    }
}
