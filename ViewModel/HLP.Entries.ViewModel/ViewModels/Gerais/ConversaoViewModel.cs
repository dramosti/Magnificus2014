using HLP.Base.ClassesBases;
using HLP.Comum.ViewModel.ViewModel;
using HLP.Entries.Model.Models.Comercial;
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
    public class ConversaoViewModel : viewModelComum<ProdutoModel>
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

        ConversaoCommands comm;
        public ConversaoViewModel()
        {
            comm = new ConversaoCommands(objViewModel: this);
            this.getUnidadeMedida = comm.getUnidadeMedida;
        }

        private ConversaoModel _currentConversao;

        public ConversaoModel currentConversao
        {
            get { return _currentConversao; }
            set
            {
                _currentConversao = value;

                if (value != null)
                    this.comm.BuildConversaoDetail();
            }
        }

        private string _conversaoDetail;

        public string conversaoDetail
        {
            get { return _conversaoDetail; }
            set
            {
                _conversaoDetail = value;
                base.NotifyPropertyChanged(propertyName: "conversaoDetail");
            }
        }

        int _idProdutoSelecionado;
        public int idProdutoSelecionado
        {
            get { return _idProdutoSelecionado; }
            set
            {
                _idProdutoSelecionado = value;
                base.NotifyPropertyChanged("idProdutoSelecionado");
            }
        }
        private Func<int, bool, object> _getUnidadeMedida;

        public Func<int, bool, object> getUnidadeMedida
        {
            get { return _getUnidadeMedida; }
            set { _getUnidadeMedida = value; }
        }
        
    }
}
