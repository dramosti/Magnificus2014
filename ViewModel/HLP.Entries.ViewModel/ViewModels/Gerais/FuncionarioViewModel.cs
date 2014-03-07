using HLP.Comum.Infrastructure.Static;
using HLP.Comum.ViewModel.ViewModels;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.ViewModel.Commands.Gerais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


        public FuncionarioViewModel()
        {
            FuncionarioCommands comm = new FuncionarioCommands(objViewModel: this);
        }

        public void GetListaFamiliaProduto()
        {
            Familia_ProdutoService.IserviceFamiliaProdutoClient servicoInternet;
            Wcf.Entries.serviceFamiliaProduto servicoRede;

            if (this.currentModel.lFamiliaProduto == null)
            {
                this.currentModel.lFamiliaProduto = new Comum.Model.Models.ObservableCollectionBaseCadastros<Familia_produtoModel>();
                if (Sistema.bOnline == TipoConexao.OnlineInternet)
                {
                    servicoInternet = new Familia_ProdutoService.IserviceFamiliaProdutoClient();
                }
                if (Sistema.bOnline == TipoConexao.OnlineRede)
                {
                    servicoRede = new Wcf.Entries.serviceFamiliaProduto();
                }
            }
        }
    }
}
