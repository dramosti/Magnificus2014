using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.Model.Repository.Interfaces.Gerais;
using HLP.Entries.ViewModel.ViewModels;
using Ninject;
using HLP.Dependencies;
using HLP.Comum.ViewModel.Commands;

namespace HLP.Entries.ViewModel.Commands
{
    public class CidadeCommands
    {

        [Inject]
        public ICidadeRepository iCidadeRepository { get; set; }

        CidadeViewModel objCidadeViewModel;

        public CidadeCommands(CidadeViewModel objCidadeViewModel)
        {
            this.objCidadeViewModel = objCidadeViewModel;

            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);

            this.objCidadeViewModel.commandNovo = new RelayCommand(execute:
                pExec => this.Novo(), canExecute: pCanExec => this.NovoCanExecute());
        }

        public void GetCidadeByUf(int idUF)
        {
            this.objCidadeViewModel.lCidade = iCidadeRepository.GetCidadeByUf(idUf: idUF);
        }


        private void Novo()
        {
            this.objCidadeViewModel._currentCidade = new CidadeModel();
        }

        private bool NovoCanExecute()
        {
            return true;
        }


    }
}
