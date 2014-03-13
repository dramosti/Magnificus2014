using HLP.Comum.ViewModel.ViewModels;
using HLP.Entries.Model.Models.Comercial;
using HLP.Entries.ViewModel.Commands.Comercial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace HLP.Entries.ViewModel.ViewModels.Comercial
{
    public class Lista_PrecoViewModel : ViewModelBase<Lista_Preco_PaiModel>
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
        public ICommand gerarListaCommand { get; set; }
        public ICommand AtribuicaoColetivaCommand { get; set; }
        public ICommand CarregarProdutosCommand { get; set; }
        public ICommand AtribuirPercentualCommand { get; set; }
        #endregion


        public Lista_PrecoViewModel()
        {
            Lista_PrecoCommands comm = new Lista_PrecoCommands(
                objViewModel: this);

            Button btnAtribuicaoColetiva = new Button();
            btnAtribuicaoColetiva.Content = "Atribuição Coletiva";
            btnAtribuicaoColetiva.Command = this.AtribuicaoColetivaCommand;
            btnAtribuicaoColetiva.CommandParameter = "WinAtribuicaoColetivaListaPreco";
            this.Botoes.Children.Add(element: btnAtribuicaoColetiva);
        }


    }
}
