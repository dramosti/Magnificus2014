using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Infrastructure;
using HLP.Comum.Model.Models;
using HLP.Comum.Resources.RecursosBases;

namespace HLP.Entries.Model.Models.Financeiro
{
    public partial class Dia_pagamentoModel : modelBase
    {
        public Dia_pagamentoModel()
            : base("Dia_pagamento")
        {
            this.lDia_pagamento_linhas = new ObservableCollectionBaseCadastros<Dia_pagamento_linhasModel>();
        }
        public int? _idDiaPagamento;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idDiaPagamento
        {
            get { return _idDiaPagamento; }
            set { _idDiaPagamento = value; base.NotifyPropertyChanged("idDiaPagamento"); }
        }
        [ParameterOrder(Order = 2)]
        public string xDiaPagamento { get; set; }
        [ParameterOrder(Order = 3)]
        public string xDescricao { get; set; }


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

    public partial class Dia_pagamento_linhasModel : modelBase
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

        private SemanaOuMes _enumSemanaOuMes;
        public SemanaOuMes enumSemanaOuMes
        {
            get { return _enumSemanaOuMes; }
            set
            {
                _enumSemanaOuMes = value;
                _stSemanaMes = (byte)value;
            }
        }

        private byte _stSemanaMes;
        [ParameterOrder(Order = 2)]
        public byte stSemanaMes
        {
            get { return _stSemanaMes; }
            set
            {
                _stSemanaMes = value;
                _enumSemanaOuMes = (SemanaOuMes)value;
            }
        }


        private DiaUtil _enumDiaUtil;
        public DiaUtil enumDiaUtil
        {
            get { return _enumDiaUtil; }
            set
            {
                _enumDiaUtil = value;
                _stDiaUtil = (byte)value;
            }
        }

        private byte _stDiaUtil;
        [ParameterOrder(Order = 3)]
        public byte stDiaUtil
        {
            get { return _stDiaUtil; }
            set
            {
                _stDiaUtil = value;
                _enumDiaUtil = (DiaUtil)value;
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

                if (sValor == null)
                {
                    if (columnName == "stSemanaMes" || columnName == "stDiaUtil")
                    {
                        if (this.enumSemanaOuMes == SemanaOuMes.MES)
                        {
                            if (this.enumDiaUtil != DiaUtil.NAO_SE_APLICA)
                                this.enumDiaUtil = DiaUtil.NAO_SE_APLICA;
                        }
                        else
                            if (this.nDia != 0)
                                this.nDia = 0;
                    }
                    else if (columnName == "nDia")
                    {
                        if (this.enumSemanaOuMes == SemanaOuMes.SEMANA)
                            if (this.nDia != 0)
                                this.nDia = 0;
                    }
                }
                return sValor;
            }
        }
    }

}
