using HLP.Comum.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HLP.Comum.ViewModel.ViewModels.Commands
{
    public class HlpPesquisaInsertCommands
    {
        HlpPesquisaInsertViewModel objViewModel;

        public HlpPesquisaInsertCommands(HlpPesquisaInsertViewModel objViewModel)
        {
            this.objViewModel = objViewModel;
            this.objViewModel.salvarCommand = new RelayCommand(execute: e => this.SalvarExecute());
        }

        private void SalvarExecute()
        {
            Type t = this.objViewModel.currentModel.objDataContext.GetType();
            ConstructorInfo constr = t.GetConstructor(Type.EmptyTypes);
            object inst = constr.Invoke(new object[] { });
            MethodInfo met = t.GetMethod(name: "Save");
            met.Invoke(inst, new object[] { this.objViewModel.currentModel.objContent });
        }
    }
}
