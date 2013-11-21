﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using HLP.Comum.ViewModel.ViewModels;
using HLP.Entries.Model.Comercial;
using HLP.Entries.ViewModel.Commands.Comercial;

namespace HLP.Entries.ViewModel.ViewModels.Comercial
{
    public class Tipo_ProdutoViewModel : ViewModelBase
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

        private Tipo_ProdutoCommands objCommands;

        public Tipo_ProdutoViewModel()
        {
            objCommands = new Tipo_ProdutoCommands(_objViewModel: this);
        }

        private Tipo_produtoModel _currentModel;

        public Tipo_produtoModel currentModel
        {
            get { return _currentModel; }
            set { _currentModel = value; base.NotifyPropertyChanged("currentModel"); }
        }
    }
}
