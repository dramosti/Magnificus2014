using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.ViewModel.Commands;
using HLP.Entries.Model.Repository.Interfaces.Gerais;
using HLP.Entries.ViewModel.ViewModels;

namespace HLP.Entries.ViewModel.Commands.Gerais
{
    public class RegiaoCommands
    {
        public IRegiaoRepository iRegiaoRepository { get; set; }

        RegiaoViewModel objRegiaoViewModel;
        public RegiaoCommands(RegiaoViewModel objRegiaoViewModel)
        {
            this.objRegiaoViewModel = objRegiaoViewModel;
        }
        public void GetAll()
        {
            objRegiaoViewModel.lRegiao = iRegiaoRepository.GetAll();
        }
    }
}
