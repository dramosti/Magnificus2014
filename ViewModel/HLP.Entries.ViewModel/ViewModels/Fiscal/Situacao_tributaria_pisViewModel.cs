﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HLP.Comum.ViewModel.ViewModels;
using HLP.Entries.Model.Models.Fiscal;
using HLP.Entries.ViewModel.Commands.Fiscal;

namespace HLP.Entries.ViewModel.ViewModels.Fiscal
{
    public class Situacao_tributaria_pisViewModel : ViewModelBase
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

        public Situacao_tributaria_pisViewModel() 
        {
            commands = new Situacao_tributaria_pisCommand(objViewModel: this);
        }

        Situacao_tributaria_pisCommand commands;
        
        private Situacao_tributaria_pisModel _currentModel;

        public Situacao_tributaria_pisModel currentModel
        {
            get { return _currentModel; }
            set
            {
                _currentModel = value;
                base.NotifyPropertyChanged(propertyName: "currentModel");
            }
        }
        

    }
}
