﻿using HLP.Base.ClassesBases;
using HLP.Components.Model.Models;
using HLP.Comum.ViewModel.ViewModel;
using HLP.Entries.Model.Models.Financeiro;
using HLP.Entries.Services.Financeiro;
using HLP.Entries.ViewModel.Commands.Financeiro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HLP.Entries.ViewModel.ViewModels.Financeiro
{
    public class Conta_BancariaViewModel : viewModelComum<Conta_bancariaModel>
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

        Conta_BancariaCommands comm;
        public bool bTreeCarregada = true;

        public Conta_BancariaViewModel()
        {
            comm = new Conta_BancariaCommands(objViewModel: this);
        }

        private object _hierarquiaConta;
        public object hierarquiaConta
        {
            get { return _hierarquiaConta; }
            set
            {
                _hierarquiaConta = value;
                base.NotifyPropertyChanged(propertyName: "hierarquiaConta");
            }
        }

        private modelToTreeView _lObjHierarquia;
        public modelToTreeView lObjHierarquia
        {
            get { return _lObjHierarquia; }
            set { _lObjHierarquia = value; }
        }

        public void MontaTreeView()
        {
            if (!bTreeCarregada)
            {
                this.comm.MontraTreeView();
            }
        }

        public int GetAgencia(int idAgencia)
        {
            return comm.GetAgencia(idAgencia: idAgencia).idBanco;
        }
    }
}
