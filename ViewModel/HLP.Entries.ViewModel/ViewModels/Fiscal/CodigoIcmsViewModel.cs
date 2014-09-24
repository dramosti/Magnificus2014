using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HLP.Base.ClassesBases;
using HLP.Entries.Model.Models.Fiscal;
using HLP.Entries.ViewModel.Commands.Fiscal;
using HLP.Comum.ViewModel.ViewModel;

namespace HLP.Entries.ViewModel.ViewModels.Fiscal
{
    public class CodigoIcmsViewModel : viewModelComum<Codigo_Icms_paiModel>
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

        private Func<int, bool, object> _getUf;

        public Func<int, bool, object> getUf
        {
            get { return _getUf; }
            set { _getUf = value; }
        }


        public CodigoIcmsViewModel()
        {
            commands = new CodigoIcmsCommand(this);
            this.getUf = commands.GetUf;
        }
        CodigoIcmsCommand commands;


    }
}
