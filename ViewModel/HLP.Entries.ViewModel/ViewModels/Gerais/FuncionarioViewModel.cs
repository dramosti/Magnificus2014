﻿using HLP.Base.ClassesBases;
using HLP.Components.Model.Models;
using HLP.Comum.ViewModel.ViewModel;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.Services.Gerais;
using HLP.Entries.ViewModel.Commands.Gerais;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace HLP.Entries.ViewModel.ViewModels.Gerais
{
    public class FuncionarioViewModel : viewModelComum<FuncionarioModel>
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

        FamiliaProdutoService objService = new FamiliaProdutoService();
        FuncionarioCommands comm;
        public BackgroundWorker bwHierarquia;
        public bool bTreeCarregada = true;

        private Func<int, bool, object> _getProduto;

        public Func<int, bool, object> getProduto
        {
            get { return _getProduto; }
            set
            {
                _getProduto = value;
                base.NotifyPropertyChanged(propertyName: "getProduto");
            }
        }

        public FuncionarioViewModel()
        {
            comm = new FuncionarioCommands(objViewModel: this);
            this.getProduto = comm.GetProduto;
        }

        public List<Familia_produtoModel> GetListaFamiliaProduto()
        {
            return this.objService.GetAll();
        }


        private object _hierarquiaFunc;

        public object hierarquiaFunc
        {
            get { return _hierarquiaFunc; }
            set
            {
                _hierarquiaFunc = value;
                base.NotifyPropertyChanged(propertyName: "hierarquiaFunc");
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
    }
}
