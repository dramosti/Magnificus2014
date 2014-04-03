using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Resources.RecursosBases;
using HLP.Base.ClassesBases;

namespace HLP.Entries.Model.Models.Gerais
{
    public partial class Plano_pagamentoModel : modelBase
    {
        public Plano_pagamentoModel()
            : base("Plano_pagamento")
        {
            this.lPlano_pagamento_linhasModel = new ObservableCollectionBaseCadastros<Plano_pagamento_linhasModel>();
        }

        public int? _idPlanoPagamento;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idPlanoPagamento
        {
            get { return _idPlanoPagamento; }
            set { _idPlanoPagamento = value; base.NotifyPropertyChanged("idPlanoPagamento"); }
        }
        [ParameterOrder(Order = 2)]
        public string xPlanoPagamento { get; set; }
        [ParameterOrder(Order = 3)]
        public string xDescricao { get; set; }
        [ParameterOrder(Order = 4)]
        public byte stAlocacao { get; set; }
        [ParameterOrder(Order = 5)]
        public byte stFormaPagamento { get; set; }
        [ParameterOrder(Order = 6)]
        public int nAlterar { get; set; }
        [ParameterOrder(Order = 7)]
        public int nNumerosPagamentos { get; set; }
        [ParameterOrder(Order = 8)]
        public decimal nValorMoeda { get; set; }
        [ParameterOrder(Order = 9)]
        public decimal nValorMinimo { get; set; }
        [ParameterOrder(Order = 10)]
        public byte stAlocacaoImpostos { get; set; }
        [ParameterOrder(Order = 11)]
        public string xNota { get; set; }

        private ObservableCollectionBaseCadastros<Plano_pagamento_linhasModel> _lPlano_pagamento_linhasModel;

        public ObservableCollectionBaseCadastros<Plano_pagamento_linhasModel> lPlano_pagamento_linhasModel
        {
            get { return _lPlano_pagamento_linhasModel; }
            set { _lPlano_pagamento_linhasModel = value; base.NotifyPropertyChanged("lPlano_pagamento_linhasModel"); }
        }
    }


    public partial class Plano_pagamento_linhasModel : modelBase
    {
        public Plano_pagamento_linhasModel() : base("Plano_pagamento_linhas") {  }

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
        private decimal? _nQuantidade;
        [ParameterOrder(Order = 2)]
        public decimal? nQuantidade
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


        private ValorOuPorcentagem _enumValorOuPorcentagem;
        public ValorOuPorcentagem enumValorOuPorcentagem
        {
            get { return _enumValorOuPorcentagem; }
            set
            {
                _enumValorOuPorcentagem = value;
                _stValorouPorcentagem = (byte)value;
            }
        }

        private byte _stValorouPorcentagem;
        [ParameterOrder(Order = 4)]
        public byte stValorouPorcentagem
        {
            get { return _stValorouPorcentagem; }
            set
            {
                _stValorouPorcentagem = value;
                _enumValorOuPorcentagem = (ValorOuPorcentagem)value;
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
                return base[columnName];
            }
        }
    }

    public partial class Plano_pagamento_linhasModel
    {
        public override string this[string columnName]
        {
            get
            {
                return base[columnName];
            }
        }
    }
    #endregion

}
