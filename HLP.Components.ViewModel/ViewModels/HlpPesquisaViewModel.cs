using HLP.Components.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HLP.Components.ViewModel.ViewModels
{
    public class HlpPesquisaViewModel
    {
        private ICommand PesquisarCommand { get; set; }
        private ICommand InserirCommand { get; set; }

        private HlpPesquisaCommands comm;

        public HlpPesquisaViewModel()
        {
            this.comm = new HlpPesquisaCommands(objViewModel: this);
        }
    }
}
