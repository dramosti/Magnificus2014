using HLP.Base.ClassesBases;
using HLP.Comum.ViewModel.ViewModel;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.ViewModel.Commands.Gerais;
using HLP.Resources.View.WPF.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HLP.Entries.ViewModel.ViewModels.Gerais
{
    public class MoedaViewModel : viewModelComum<MoedaModel>
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

        private padraoMoeda _selectedMoeda;

        public padraoMoeda selectedMoeda
        {
            get { return _selectedMoeda; }
            set
            {
                _selectedMoeda = value;
                if (this.currentModel != null)
                {
                    if (this.currentModel.GetOperationModel() ==
                         Base.EnumsBases.OperationModel.updating)
                    {
                        this.currentModel.xSimbolo = value.xCodigo;
                        this.currentModel.xMoeda = value.xMoeda;
                    }
                }
            }
        }

        public MoedaViewModel()
        {
            MoedaCommands comm = new MoedaCommands(objViewModel: this);
        }

    }
}
