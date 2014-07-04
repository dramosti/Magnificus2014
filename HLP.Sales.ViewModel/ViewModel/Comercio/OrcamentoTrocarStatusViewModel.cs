using HLP.Base.ClassesBases;
using HLP.Comum.ViewModel.ViewModel;
using HLP.Sales.Model.Models.Comercial;
using HLP.Sales.ViewModel.Commands.Comercio;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HLP.Sales.ViewModel.ViewModel.Comercio
{
    public class OrcamentoTrocarStatusViewModel : viewModelComum<TrocaStatus_Orcamento_Itens>
    {
        public ICommand confirmarCommand { get; set; }
        public ICommand cancelarCommand { get; set; }

        public OrcamentoTrocarStatusViewModel()
        {
            OrcamentoTrocarStatusCommands comm = new OrcamentoTrocarStatusCommands(objViewModel: this);
        }

        private ObservableCollection<TrocaStatus_Orcamento_Itens> _lOrcamento_Itens;

        public ObservableCollection<TrocaStatus_Orcamento_Itens> lOrcamento_Itens
        {
            get { return _lOrcamento_Itens; }
            set { _lOrcamento_Itens = value; }
        }

        #region propriedades para manipulação da window

        private byte _statusItens;

        public byte statusItens
        {
            get { return _statusItens; }
            set
            {
                _statusItens = value;
                switch (value)
                {
                    case 2:
                        {
                            this.xHeaderQuant = "Qtd. Confirm.";
                            this.visibNumPedidoCliente = true;
                            this.visibMotivoPerdaCancel = false;
                        } break;
                    case 3:
                        {
                            this.xHeaderQuant = "Qtd. Perdida";
                            this.visibNumPedidoCliente = false;
                            this.visibMotivoPerdaCancel = true;
                        } break;
                    case 4:
                        {
                            this.xHeaderQuant = "Qtd. Cancelada";
                            this.visibNumPedidoCliente = false;
                            this.visibMotivoPerdaCancel = true;
                        } break;
                }

                base.NotifyPropertyChanged(propertyName: "statusItens");
            }
        }


        private bool _visibNumPedidoCliente;

        public bool visibNumPedidoCliente
        {
            get { return _visibNumPedidoCliente; }
            set
            {
                _visibNumPedidoCliente = value;
                base.NotifyPropertyChanged(propertyName: "visibNumPedidoCliente");
            }
        }

        private bool _visibMotivoPerdaCancel;

        public bool visibMotivoPerdaCancel
        {
            get { return _visibMotivoPerdaCancel; }
            set
            {
                _visibMotivoPerdaCancel = value;
                base.NotifyPropertyChanged(propertyName: "visibMotivoPerdaCancel");
            }
        }

        private string _xHeaderQuant;

        public string xHeaderQuant
        {
            get { return _xHeaderQuant; }
            set
            {
                _xHeaderQuant = value;
                base.NotifyPropertyChanged(propertyName: "xHeaderQuant");
            }
        }

        #endregion

    }
}
