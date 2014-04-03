using HLP.Base.ClassesBases;
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
    public class Funcionario_AcessoViewModel : ViewModelBase<FuncionarioModel>
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

        Funcionario_AcessoCommands comm;
        public Funcionario_AcessoViewModel()
        {
            comm = new Funcionario_AcessoCommands(objViewModel: this);
        }


        public bool ValidaUsuario(string xLogin, string xSenha, int idFuncionario)
        {
            return this.comm.ValidaUsuario(xLogin: xLogin, xSenha: xSenha, idFuncionario: idFuncionario);
        }
    }
}
