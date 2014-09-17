using HLP.Base.ClassesBases;
using HLP.Comum.ViewModel.ViewModel;
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
    public class Funcionario_AcessoViewModel : viewModelComum<FuncionarioModel>
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
            this.getEmpresa = comm.GetEmpresa;
            this.getSetor = comm.GetSetor;
        }


        public bool ValidaUsuario(string xLogin, string xSenha, int idFuncionario)
        {
            return this.comm.ValidaUsuario(xLogin: xLogin, xSenha: xSenha, idFuncionario: idFuncionario);
        }



        
        private string _xFuncionario;

        public string xFuncionario
        {
            get { return _xFuncionario; }
            set
            {
                _xFuncionario = value;
                base.NotifyPropertyChanged(propertyName: "xFuncionario");
            }
        }

        private Func<int, bool, object> _getEmpresa;
        public Func<int, bool, object> getEmpresa
        {
            get { return _getEmpresa; }
            set { _getEmpresa = value; }
        }


        private Func<int, bool, object> _getSetor;
        public Func<int, bool, object> getSetor
        {
            get { return _getSetor; }
            set { _getSetor = value; }
        }
        

        
    }
}
