﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.ViewModel.Commands.Gerais;

namespace HLP.Entries.ViewModel.ViewModels.Gerais
{
    public class ContatoViewModel
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

        private ContatoModel _currentModel;

        public ContatoModel currentModel
        {
            get { return _currentModel; }
            set { _currentModel = value; }
        }

    }
}