using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HLP.Base.ClassesBases;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.ViewModel.Commands.Gerais;

namespace HLP.Entries.ViewModel.ViewModels.Gerais
{
    public class CalendarioViewModel : ViewModelBase<CalendarioModel>
    {
        #region Icommands
        public ICommand commandSalvar { get; set; }
        public ICommand commandDeletar { get; set; }
        public ICommand commandNovo { get; set; }
        public ICommand commandAlterar { get; set; }
        public ICommand commandCancelar { get; set; }
        public ICommand commandCopiar { get; set; }
        public ICommand commandPesquisar { get; set; }
        public ICommand navegarCommand { get; set; }

        

        public ICommand gerarDetalhamentoCommand { get; set; }
        public ICommand gerarByCalendarioBaseCommand { get; set; }

        #endregion



        public CalendarioViewModel() 
        {
            //this.currentModel = new CalendarioModel();
            commands = new CalendarioCommand(objViewModel: this);
        }

        CalendarioCommand commands;      
       
        

    }
}
