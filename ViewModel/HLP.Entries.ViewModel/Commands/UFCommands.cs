using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.ViewModel.Commands;
using HLP.Dependencies;
using HLP.Entries.Model.Models;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.Model.Repository.Interfaces;
using HLP.Entries.Model.Repository.Interfaces.Gerais;
using HLP.Entries.ViewModel.ViewModels;
using Ninject;

namespace HLP.Entries.ViewModel.Commands
{
    public class UFCommands
    {
        [Inject]
        public IUFRepository iUFRepository { get; set; }

        UFViewModel objViewModel;

        public UFCommands(UFViewModel objViewModel) 
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);

            this.objViewModel = objViewModel;

            this.objViewModel.commandDeletar = new RelayCommand(paramExec => Delete(this.objViewModel.currentUF),
                paramCanExec => DeleteCanExecute());

            this.objViewModel.commandSalvar = new RelayCommand(paramExec => Save(this.objViewModel.currentUF),
                paramCanExec => SaveCanExecute());
        }

        public void Save(object objUFModel) 
        {
            iUFRepository.Save(objUFModel as UFModel);
        }
        private bool SaveCanExecute()
        {
            return true;
        }


        public void Delete(object objUFModel)
        {
           iUFRepository.Delete(Convert.ToInt32((objUFModel as UFModel).idUF));
        }
        private bool DeleteCanExecute()
        {
            return true;
        }
    }
}
