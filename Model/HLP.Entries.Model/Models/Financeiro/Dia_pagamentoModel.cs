using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Base.ClassesBases;
using HLP.Comum.Model.Models;

namespace HLP.Entries.Model.Models.Financeiro
{
    public partial class Dia_pagamentoModel : modelComum
    {
        public Dia_pagamentoModel()
            : base("Dia_pagamento")
        {
            this.lDia_pagamento_linhas = new ObservableCollectionBaseCadastros<Dia_pagamento_linhasModel>();
        }

        private int? _idDiaPagamento;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idDiaPagamento
        {
            get { return _idDiaPagamento; }
            set
            {
                _idDiaPagamento = value;
                base.NotifyPropertyChanged(propertyName: "idDiaPagamento");
            }
        }
        private string _xDiaPagamento;
        [ParameterOrder(Order = 2)]
        public string xDiaPagamento
        {
            get { return _xDiaPagamento; }
            set
            {
                _xDiaPagamento = value;
                base.NotifyPropertyChanged(propertyName: "xDiaPagamento");
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

        private ObservableCollectionBaseCadastros<Dia_pagamento_linhasModel> _lDia_pagamento_linhas;

        public ObservableCollectionBaseCadastros<Dia_pagamento_linhasModel> lDia_pagamento_linhas
        {
            get { return _lDia_pagamento_linhas; }
            set
            {
                _lDia_pagamento_linhas = value;
                base.NotifyPropertyChanged(propertyName: "lDia_pagamento_linhas");
            }
        }

    }

    public partial class Dia_pagamento_linhasModel : modelComum
    {
        public Dia_pagamento_linhasModel() : base("Dia_pagamento_linhas") { }

        private int? _idDiaPagamentoLinhas;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idDiaPagamentoLinhas
        {
            get { return _idDiaPagamentoLinhas; }
            set
            {
                _idDiaPagamentoLinhas = value;
                base.NotifyPropertyChanged(propertyName: "idDiaPagamentoLinhas");
            }
        }
        private byte? _stSemanaMes;
        [ParameterOrder(Order = 2)]
        public byte? stSemanaMes
        {
            get { return _stSemanaMes; }
            set
            {
                _stSemanaMes = value;
                base.NotifyPropertyChanged(propertyName: "stSemanaMes");
            }
        }
        private byte? _stDiaUtil;
        [ParameterOrder(Order = 3)]
        public byte? stDiaUtil
        {
            get { return _stDiaUtil; }
            set
            {
                _stDiaUtil = value;
                base.NotifyPropertyChanged(propertyName: "stDiaUtil");
            }
        }
        private int? _nDia;
        [ParameterOrder(Order = 4)]
        public int? nDia
        {
            get { return _nDia; }
            set
            {
                _nDia = value;
                base.NotifyPropertyChanged(propertyName: "nDia");
            }
        }
        private int _idDiaPagamento;
        [ParameterOrder(Order = 5)]
        public int idDiaPagamento
        {
            get { return _idDiaPagamento; }
            set
            {
                _idDiaPagamento = value;
                base.NotifyPropertyChanged(propertyName: "idDiaPagamento");
            }
        }
    }

    public partial class Dia_pagamentoModel
    {
        public override string this[string columnName]
        {
            get
            {
                return base[columnName];
            }
        }
    }

    public partial class Dia_pagamento_linhasModel
    {
        public override string this[string columnName]
        {
            get
            {
                string sValor = base[columnName];

                //if (sValor == null)
                //{
                //    if (columnName == "stSemanaMes" || columnName == "stDiaUtil")
                //    {
                //        if (this.enumSemanaOuMes == SemanaOuMes.MES)
                //        {
                //            if (this.enumDiaUtil != DiaUtil.NAO_SE_APLICA)
                //                this.enumDiaUtil = DiaUtil.NAO_SE_APLICA;
                //        }
                //        else
                //            if (this.nDia != 0)
                //                this.nDia = 0;
                //    }
                //    else if (columnName == "nDia")
                //    {
                //        if (this.enumSemanaOuMes == SemanaOuMes.SEMANA)
                //            if (this.nDia != 0)
                //                this.nDia = 0;
                //    }
                //}
                return sValor;
            }
        }
    }

}
