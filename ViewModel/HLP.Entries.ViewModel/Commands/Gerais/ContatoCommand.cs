using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Entries.ViewModel.ViewModels.Gerais;

namespace HLP.Entries.ViewModel.Commands.Gerais
{
    public class ContatoCommand
    {
        ContatoViewModel objViewModel;
        contato_Service.IserviceContatoClient servico = new contato_Service.IserviceContatoClient();
        public ContatoCommand(ContatoViewModel objViewModel)
        {

        }



        //contatocommand

    }
}
