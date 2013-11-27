﻿using HLP.Comum.ViewModel.ViewModels;
using HLP.Entries.Model.Models.Comercial;
using HLP.Entries.ViewModel.Commands.Comercial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HLP.Entries.ViewModel.ViewModels.Comercial
{
    public class ClienteViewModel : ViewModelBase
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
        
        public ClienteViewModel()
        {
            ClienteCommands comm = new ClienteCommands(
                objViewModel: this);
        }

        private Cliente_fornecedorModel _currentModel;

        public Cliente_fornecedorModel currentModel
        {
            get { return _currentModel; }
            set
            {
                _currentModel = value;
                base.NotifyPropertyChanged(
                    propertyName: "currentModel");
            }
        }


    }
}