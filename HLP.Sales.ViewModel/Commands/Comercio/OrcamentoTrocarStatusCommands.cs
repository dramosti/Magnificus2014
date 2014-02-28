using HLP.Comum.ViewModel.Commands;
using HLP.Sales.ViewModel.ViewModel.Comercio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HLP.Sales.ViewModel.Commands.Comercio
{
    public class OrcamentoTrocarStatusCommands
    {
        OrcamentoTrocarStatusViewModel objViewModel;

        public OrcamentoTrocarStatusCommands(OrcamentoTrocarStatusViewModel objViewModel)
        {
            this.objViewModel = objViewModel;
            this.objViewModel.confirmarCommand = new RelayCommand(execute: execut => this.ConfirmarCommands(execut),
                canExecute: canExec => this.ConfirmarCanExecute(canExec));
            this.objViewModel.cancelarCommand = new RelayCommand(execute: exec => this.CancelarExecute(exec));
        }

        private void ConfirmarCommands(object o)
        {
            (o as Window).DialogResult = true;
            (o as Window).Close();
        }

        private bool ConfirmarCanExecute(object o)
        {
            if (this.objViewModel.IsValid((o as Window).FindName(name: "grid") as DataGrid))
                return true;

            return false;
        }

        private void CancelarExecute(object o)
        {
            (o as Window).Close();
        }
    }
}
