using HLP.Base.ClassesBases;
using HLP.Sales.ViewModel.ViewModel.Comercio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HLP.Sales.ViewModel.Commands.Comercio
{
    public class OrcamentoItensRepresentanteCommands
    {
        OrcamentoItensRepresentanteViewModel objViewModel;

        public OrcamentoItensRepresentanteCommands(OrcamentoItensRepresentanteViewModel objViewModel)
        {
            this.objViewModel = objViewModel;
            this.objViewModel.applyCommand = new RelayCommand(execute: ex => this.ApplyExecute(o: ex));
        }

        public void ApplyExecute(object o)
        {
            this.objViewModel.bSave = true;
            (o as Window).Close();
        }
    }
}
