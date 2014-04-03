using HLP.Base.ClassesBases;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.ViewModel.Commands.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HLP.Entries.ViewModel.ViewModels.Parametros
{
    public class Empresa_ParametrosViewModel : ViewModelBase<EmpresaModel>
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

        public Empresa_ParametrosViewModel()
        {
            Empresa_ParametrosCommands comm = new Empresa_ParametrosCommands(objViewModel: this);
            comm.ExecPesquisa();
            this.SetValorCurrentOp(op: Base.EnumsBases.OperacaoCadastro.pesquisando);
        }

    }
}
