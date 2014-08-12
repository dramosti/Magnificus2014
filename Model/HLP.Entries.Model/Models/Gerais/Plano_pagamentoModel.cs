using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Base.ClassesBases;
using HLP.Comum.Model.Models;
using System.Collections.ObjectModel;
using System.Windows;

namespace HLP.Entries.Model.Models.Gerais
{
    public partial class Plano_pagamentoModel : modelComum
    {
        private static Plano_pagamentoModel _currentPlano;

        public static Plano_pagamentoModel currentPlano
        {
            get { return _currentPlano; }
            set { _currentPlano = value; }
        }

        #region Propriedades apenas para Visualização na Tela

        private bool _bColumnStValorPorcentagem;

        public bool bColumnStValorPorcentagem
        {
            get { return _bColumnStValorPorcentagem; }
            set
            {
                _bColumnStValorPorcentagem = value;
                base.NotifyPropertyChanged(propertyName: "bColumnStValorPorcentagem");
            }
        }

        #endregion

        public Plano_pagamentoModel()
            : base("Plano_pagamento")
        {
            this.lPlano_pagamento_linhasModel = new ObservableCollectionBaseCadastros<Plano_pagamento_linhasModel>();
            currentPlano = this;
            this.stAlocacao = this.stAlocacaoImpostos = 1;
            this.bColumnStValorPorcentagem = false;
        }

        private int? _idPlanoPagamento;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idPlanoPagamento
        {
            get { return _idPlanoPagamento; }
            set
            {
                _idPlanoPagamento = value;
                base.NotifyPropertyChanged(propertyName: "idPlanoPagamento");
            }
        }
        private string _xPlanoPagamento;
        [ParameterOrder(Order = 2)]
        public string xPlanoPagamento
        {
            get { return _xPlanoPagamento; }
            set
            {
                _xPlanoPagamento = value;
                base.NotifyPropertyChanged(propertyName: "xPlanoPagamento");
            }
        }
        private string _xDescricao;
        [ParameterOrder(Order = 3)]
        public string xDescricao
        {
            get { return _xDescricao; }
            set
            {
                _xDescricao = value;
                base.NotifyPropertyChanged(propertyName: "xDescricao");
            }
        }
        private byte _stAlocacao;
        [ParameterOrder(Order = 4)]
        public byte stAlocacao
        {
            get { return _stAlocacao; }
            set
            {
                var _originalValue = _stAlocacao;

                _stAlocacao = value;
                base.NotifyPropertyChanged(propertyName: "stAlocacao");

                if (this.GetOperationModel() == Base.EnumsBases.OperationModel.updating)
                {
                    if (value != (byte)0 && this.lPlano_pagamento_linhasModel.Count > 0)
                    {
                        if (MessageHlp.Show(stMessage: StMessage.stYesNo, xMessageToUser: "As linha do plano de pagamento serão perdidas, deseja continuar?")
                           != MessageBoxResult.Yes)
                        {
                            Application.Current.Dispatcher.BeginInvoke(method: new Action(()
                                =>
                                {
                                    this._stAlocacao = _originalValue;
                                    base.NotifyPropertyChanged(propertyName: "stAlocacao");
                                    return;
                                }),
                                priority: System.Windows.Threading.DispatcherPriority.ContextIdle, args: null);
                        }
                        else
                        {
                            switch (value)
                            {
                                case 0:
                                    {
                                        this.vFixoPagamento = this.vPagamentoMinimo = this.nNumerosPagamentos = this.nAlterarFormaPagamento = null;
                                    } break;
                                case 1:
                                    {
                                        this.vFixoPagamento = null;
                                        this.lPlano_pagamento_linhasModel = new ObservableCollectionBaseCadastros<Plano_pagamento_linhasModel>();
                                    } break;
                                case 2:
                                    {
                                        this.vFixoPagamento = null;
                                        this.lPlano_pagamento_linhasModel = new ObservableCollectionBaseCadastros<Plano_pagamento_linhasModel>();
                                    } break;
                                case 3:
                                    {
                                        this.vPagamentoMinimo = null;
                                        this.lPlano_pagamento_linhasModel = new ObservableCollectionBaseCadastros<Plano_pagamento_linhasModel>();
                                    } break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }
        }
        private byte _stFormaPagamento;
        [ParameterOrder(Order = 5)]
        public byte stFormaPagamento
        {
            get { return _stFormaPagamento; }
            set
            {
                _stFormaPagamento = value;



                base.NotifyPropertyChanged(propertyName: "stFormaPagamento");
            }
        }
        private int? _nAlterarFormaPagamento;
        [ParameterOrder(Order = 6)]
        public int? nAlterarFormaPagamento
        {
            get { return _nAlterarFormaPagamento; }
            set
            {
                _nAlterarFormaPagamento = value;
                base.NotifyPropertyChanged(propertyName: "nAlterarFormaPagamento");
            }
        }
        private int? _nNumerosPagamentos;
        [ParameterOrder(Order = 7)]
        public int? nNumerosPagamentos
        {
            get { return _nNumerosPagamentos; }
            set
            {
                _nNumerosPagamentos = value;
                base.NotifyPropertyChanged(propertyName: "nNumerosPagamentos");
            }
        }
        private decimal? _vFixoPagamento;
        [ParameterOrder(Order = 8)]
        public decimal? vFixoPagamento
        {
            get { return _vFixoPagamento; }
            set
            {
                _vFixoPagamento = value;
                base.NotifyPropertyChanged(propertyName: "vFixoPagamento");
            }
        }
        private decimal? _vPagamentoMinimo;
        [ParameterOrder(Order = 9)]
        public decimal? vPagamentoMinimo
        {
            get { return _vPagamentoMinimo; }
            set
            {
                _vPagamentoMinimo = value;
                base.NotifyPropertyChanged(propertyName: "vPagamentoMinimo");
            }
        }
        private byte _stAlocacaoImpostos;
        [ParameterOrder(Order = 10)]
        public byte stAlocacaoImpostos
        {
            get { return _stAlocacaoImpostos; }
            set
            {
                _stAlocacaoImpostos = value;
                base.NotifyPropertyChanged(propertyName: "stAlocacaoImpostos");
            }
        }
        private string _xNota;
        [ParameterOrder(Order = 11)]
        public string xNota
        {
            get { return _xNota; }
            set
            {
                _xNota = value;
                base.NotifyPropertyChanged(propertyName: "xNota");
            }
        }

        private ObservableCollectionBaseCadastros<Plano_pagamento_linhasModel> _lPlano_pagamento_linhasModel;

        public ObservableCollectionBaseCadastros<Plano_pagamento_linhasModel> lPlano_pagamento_linhasModel
        {
            get { return _lPlano_pagamento_linhasModel; }
            set
            {
                _lPlano_pagamento_linhasModel = value;
                base.NotifyPropertyChanged("lPlano_pagamento_linhasModel");
            }
        }
    }


    public partial class Plano_pagamento_linhasModel : modelComum
    {
        public Plano_pagamento_linhasModel()
        {

            if (Plano_pagamentoModel.currentPlano.GetOperationModel()
                == Base.EnumsBases.OperationModel.updating)
            {
                if (Plano_pagamentoModel.currentPlano.lPlano_pagamento_linhasModel.Count > 0)
                {
                    Plano_pagamentoModel.currentPlano.bColumnStValorPorcentagem = true;

                    Plano_pagamento_linhasModel _it = Plano_pagamentoModel.currentPlano.lPlano_pagamento_linhasModel.FirstOrDefault();

                    this.stValorouPorcentagem = _it.stValorouPorcentagem;

                    if (this._stValorouPorcentagem == (byte)0)
                        this.nValorouPorcentagem = 100 - Plano_pagamentoModel.currentPlano.lPlano_pagamento_linhasModel
                            .Sum(i => i.nValorouPorcentagem);
                }
                else
                {
                    this.stValorouPorcentagem = (byte)0;
                    this.nValorouPorcentagem = 100;

                }
            }
        }

        private int? _idLinhasPagamento;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idLinhasPagamento
        {
            get { return _idLinhasPagamento; }
            set
            {
                _idLinhasPagamento = value;
                base.NotifyPropertyChanged(propertyName: "idLinhasPagamento");
            }
        }
        private int? _nQuantidade;
        [ParameterOrder(Order = 2)]
        public int? nQuantidade
        {
            get { return _nQuantidade; }
            set
            {
                _nQuantidade = value;
                base.NotifyPropertyChanged(propertyName: "nQuantidade");
            }
        }
        private decimal? _nValorouPorcentagem;
        [ParameterOrder(Order = 3)]
        public decimal? nValorouPorcentagem
        {
            get { return _nValorouPorcentagem; }
            set
            {
                _nValorouPorcentagem = value;
                base.NotifyPropertyChanged(propertyName: "nValorouPorcentagem");
            }
        }
        private byte? _stValorouPorcentagem;
        [ParameterOrder(Order = 4)]
        public byte? stValorouPorcentagem
        {
            get { return _stValorouPorcentagem; }
            set
            {
                _stValorouPorcentagem = value;
                base.NotifyPropertyChanged(propertyName: "stValorouPorcentagem");
            }
        }
        private int _idPlanoPagamento;
        [ParameterOrder(Order = 5)]
        public int idPlanoPagamento
        {
            get { return _idPlanoPagamento; }
            set
            {
                _idPlanoPagamento = value;
                base.NotifyPropertyChanged(propertyName: "idPlanoPagamento");
            }
        }

    }


    #region validações

    public partial class Plano_pagamentoModel
    {
        public override string this[string columnName]
        {
            get
            {
                string xResult = base[columnName];

                if (string.IsNullOrEmpty(value: xResult))
                {
                    if (columnName == "vFixoPagamento")
                    {
                        if (this.stAlocacao == 3 && (this.vFixoPagamento == null))
                        {
                            xResult = "Necessário que campo possua valor";
                        }
                    }
                    else if (columnName == "stAlocacao")
                    {
                        base.NotifyPropertyChanged(propertyName: "vFixoPagamento");
                    }
                }
                return xResult;
            }
        }
    }

    public partial class Plano_pagamento_linhasModel
    {
        public override string this[string columnName]
        {
            get
            {
                string xResult = base[columnName];

                if (string.IsNullOrEmpty(value: xResult))
                {
                    if (columnName == "nValorouPorcentagem")
                    {
                        if (this.stValorouPorcentagem == 0 && Plano_pagamentoModel.currentPlano.lPlano_pagamento_linhasModel.Where(
                            i => i.stValorouPorcentagem == 0).Sum(
                            i => i.nValorouPorcentagem) > 100)
                        {
                            xResult = "Soma dos valores da coluna Porcentagem ultrapassam 100%. Favor Corrigir!";
                        }
                    }
                }
                return xResult;
            }
        }
    }
    #endregion

}
