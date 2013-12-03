﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HLP.Comum.ViewModel.ViewModels;
using HLP.Entries.Model.Models.Financeiro;
using HLP.Entries.ViewModel.Commands.Financeiro;

namespace HLP.Entries.ViewModel.ViewModels.Financeiro
{
    public class DescontosAvistaViewModel : ViewModelBase
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
        
        public DescontosAvistaViewModel() 
        {
            commands = new DescontosAvistaCommand(objViewModel: this);
        }
        DescontosAvistaCommand commands;
        
        private Descontos_AvistaModel _currentModel;

        public Descontos_AvistaModel currentModel
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