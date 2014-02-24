using HLP.Comum.ViewModel.Commands;
using HLP.Sales.ViewModel.ViewModel.Comercio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HLP.Sales.ViewModel.Commands.Comercio
{
    public class OrcamentoTrocarStatusCommands
    {
        OrcamentoTrocarStatusViewModel objViewModel;

        public OrcamentoTrocarStatusCommands(OrcamentoTrocarStatusViewModel objViewModel)
        {
            this.objViewModel = objViewModel;
            this.objViewModel.confirmarCommand = new RelayCommand(execute: execut => this.ConfirmarCommands(execut));
        }

        private void ConfirmarCommands(object o)
        {
            (o as Window).DialogResult = true;
            (o as Window).Close();
        }
    }
}
