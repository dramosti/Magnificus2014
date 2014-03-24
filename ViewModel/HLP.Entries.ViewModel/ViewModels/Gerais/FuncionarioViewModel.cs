using HLP.Comum.Infrastructure.Static;
using HLP.Comum.Model.Models;
using HLP.Comum.Resources.Models;
using HLP.Comum.ViewModel.ViewModels;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.ViewModel.Commands.Gerais;
using HLP.Entries.ViewModel.Services.Gerais;
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
    public class FuncionarioViewModel : ViewModelBase<FuncionarioModel>
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
        public FuncionarioViewModel()
        {
            comm = new FuncionarioCommands(objViewModel: this);
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
