using HLP.Comum.ViewModel.ViewModels;
using HLP.Entries.Model.Models.Comercial;
using HLP.Entries.ViewModel.Commands.Comercial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        public ICommand AumVlrVendaCustoCommand { get; set; }
        public ICommand ConfAumVlrVendaCommand { get; set; }
        public ICommand CancAumVlrVendaCommand { get; set; }
        #endregion


        public Lista_PrecoViewModel()
        {
            Lista_PrecoCommands comm = new Lista_PrecoCommands(
                objViewModel: this);

            this.visAumentoVlr = Visibility.Collapsed;
            Button btnAtribuicaoColetiva = new Button();
            btnAtribuicaoColetiva.Content = "Atribuição Coletiva";
            btnAtribuicaoColetiva.Command = this.AtribuicaoColetivaCommand;
            btnAtribuicaoColetiva.CommandParameter = "WinAtribuicaoColetivaListaPreco";

            Button btnAumVlr = new Button();
            btnAumVlr.Content = "Aumento Vlr Preco/Custo";
            btnAumVlr.Command = this.AumVlrVendaCustoCommand;

            this.Botoes.Children.Add(element: btnAtribuicaoColetiva);
            this.Botoes.Children.Add(element: btnAumVlr);                        
        }

        #region Propriedades utilizadas na View

        private Visibility _visAumentoVlr;

        public Visibility visAumentoVlr
        {
            get { return _visAumentoVlr; }
            set
            {
                _visAumentoVlr = value;
                base.NotifyPropertyChanged(propertyName: "visAumentoVlr");
            }
        }

        private byte _byteIndex;

        public byte byteIndex
        {
            get { return _byteIndex; }
            set
            {
                _byteIndex = value;
                base.NotifyPropertyChanged(propertyName: "byteIndex");
            }
        }


        private decimal _dPorcAumento;

        public decimal dPorcAumento
        {
            get { return _dPorcAumento; }
            set
            {
                _dPorcAumento = value;

                foreach (Lista_precoModel item in this.currentModel.lLista_preco)
                {
                    if (this.byteIndex == 0)
                        item.vlrEsperado = item.vVenda * (1 + (value / 100));
                    else if (this.byteIndex == 1)
                        item.vlrEsperado = item.vCustoProduto * (1 + (value / 100));
                }

                base.NotifyPropertyChanged(propertyName: "dPorcAumento");
            }
        }


        private bool _bCheckAll;

        public bool bCheckAll
        {
            get { return _bCheckAll; }
            set
            {
                _bCheckAll = value;
                foreach (Lista_precoModel item in this.currentModel.lLista_preco)
                {
                    item.bChecked = value;
                }
                base.NotifyPropertyChanged(propertyName: "bCheckAll");
            }
        }

        #endregion

    }
}
