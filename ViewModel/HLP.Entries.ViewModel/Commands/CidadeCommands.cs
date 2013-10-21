using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Dependencies;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.Model.Repository.Interfaces.Gerais;
using HLP.Entries.ViewModel.ViewModels;
using Ninject;

namespace HLP.Entries.ViewModel.Commands
{
   public class CidadeCommands
    {

       [Inject]
       public ICidadeRepository iCidadeRepository { get; set; }

       CidadeViewModel objCidadeViewModel ;

       public CidadeCommands(CidadeViewModel objCidadeViewModel ) 
       {
           this.objCidadeViewModel = objCidadeViewModel;

            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);

       }

       public void GetCidadeByUf(int idUF)
       {
           this.objCidadeViewModel.lCidade = iCidadeRepository.GetCidadeByUf(idUf:idUF);
       }

    }
}
