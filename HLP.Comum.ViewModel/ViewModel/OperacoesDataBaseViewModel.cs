using HLP.Base.ClassesBases;
using HLP.Comum.Model.Models;
using HLP.Comum.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Comum.ViewModel.ViewModel
{
    public class OperacoesDataBaseViewModel : viewModelComum<RecordsSqlModel>
    {
        OperacoesDataBaseCommands comm;
        public OperacoesDataBaseViewModel()
        {
            comm = new OperacoesDataBaseCommands();
        }

        public void ShowWinExclusionDenied(string xMessage, string xValor)
        {
            comm.ShowWinExclusionDenied(xMessage: xMessage, xValor: xValor);
        }
    }
}
