using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Model.Models;
using HLP.Entries.Model.Models.Comercial;
using HLP.Comum.ViewModel.ViewModels;
using HLP.Entries.ViewModel.Commands.Gerais;
using System.Windows.Input;
using HLP.Entries.Model.Models.Gerais;

namespace HLP.Entries.ViewModel.ViewModels.Gerais
{
    public class AtribuicaoColetivaListaPrecoViewModel : ViewModelBase<CalendarioModel>
    {
        public ICommand commAplicarAtribuicaoColetiva { get; set; }


        private decimal _valor;

        public decimal valor
        {
            get { return _valor; }
            set
            {
                _valor = value;
                base.NotifyPropertyChanged(propertyName: "valor");
            }
        }


        private int _selectedIndex;

        public int selectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                _selectedIndex = value;
                base.NotifyPropertyChanged(propertyName: "selectedIndex");
            }
        }

        private byte _stAtualizacaoLista;

        public byte stAtualizacaoLista
        {
            get { return _stAtualizacaoLista; }
            set
            {
                _stAtualizacaoLista = value;
                List<string> lItens = new List<string>();
                lItens.Add(item: "Desconto Máximo"); //0
                lItens.Add(item: "Acréscimo Máximo"); //1
                lItens.Add(item: "Comissão A vista"); //2
                lItens.Add(item: "Comissão A prazo"); //3
                if (value == (byte)1)
                {
                    lItens.Add(item: "Custo do Produto"); //4
                    lItens.Add(item: "Porc. de Comissão"); //5
                    lItens.Add(item: "Porc. de desconto"); //6
                    lItens.Add(item: "Outros"); //7
                    lItens.Add(item: "Margem de Lucro"); //8
                    lItens.Add(item: "Valor de Venda"); //9
                }
                this._lItensCbx = lItens;
            }
        }


        private List<string> _lItensCbx;

        public List<string> lItensCbx
        {
            get { return _lItensCbx; }
            set
            {
                _lItensCbx = value;
                base.NotifyPropertyChanged(propertyName: "lItensCbx");
            }
        }


        public AtribuicaoColetivaListaPrecoViewModel()
        {
            AtribuicaoColetivaListaPrecoCommands comm = new AtribuicaoColetivaListaPrecoCommands(objViewModel: this);
        }

        private ObservableCollectionBaseCadastros<Lista_precoModel> _currentList;

        public ObservableCollectionBaseCadastros<Lista_precoModel> currentList
        {
            get { return _currentList; }
            set
            {
                _currentList = value;
                base.NotifyPropertyChanged(propertyName: "currentList");
            }
        }
    }
}