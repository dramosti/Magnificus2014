using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HLP.Base.ClassesBases;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.ViewModel.Commands.Gerais;
using HLP.Components.Model.Models;
using System.Collections.ObjectModel;
using HLP.Comum.ViewModel.ViewModel;

namespace HLP.Entries.ViewModel.ViewModels.Gerais
{
    public class ContatoViewModel : viewModelComum<ContatoModel>
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
        #endregion

        ContatoCommand commands;
        public ContatoViewModel() 
        {
            commands = new ContatoCommand(this);
        }

        private ObservableCollection<ContatoModel> _lContatos;

        public ObservableCollection<ContatoModel> lContatos
        {
            get { return _lContatos; }
            set
            {
                _lContatos = value;
                base.NotifyPropertyChanged(propertyName: "lContatos");
            }
        }
        
    }
}
