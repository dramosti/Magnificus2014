﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HLP.Comum.ViewModel.ViewModels;
using HLP.Entries.Model.Models.Gerais;

namespace HLP.Entries.ViewModel.ViewModels.Gerais
{
    public class FamiliaProdutoViewModel : ViewModelBase
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


        public FamiliaProdutoViewModel() 
        {
            
        }

        private Familia_produtoModel _currentModel;

        public Familia_produtoModel currentModel
        {
            get { return _currentModel; }
            set { _currentModel = value; base.NotifyPropertyChanged(propertyName: "currentModel"); }
        }

                
    }
}