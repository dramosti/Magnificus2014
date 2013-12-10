using HLP.Comum.Infrastructure;
using HLP.Comum.Model.Models;
using HLP.Comum.Resources.RecursosBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.Gerais
{
    public partial class ConversaoModel : modelBase
    {
        public ConversaoModel()
            : base(xTabela: "Conversao")
        {
        }

        private int? _idConversao;

        [ParameterOrder(Order = 1)]
        public int? idConversao
        {
            get { return _idConversao; }
            set
            {
                _idConversao = value;
                base.NotifyPropertyChanged(propertyName: "idConversao");
            }
        }

        private int _idEmpresa;

        [ParameterOrder(Order = 2)]
        public int idEmpresa
        {
            get { return _idEmpresa; }
            set
            {
                _idEmpresa = value;
                base.NotifyPropertyChanged(propertyName: "idEmpresa");
            }
        }

        private int _idProduto;

        [ParameterOrder(Order = 3)]
        public int idProduto
        {
            get { return _idProduto; }
            set
            {
                _idProduto = value;
                base.NotifyPropertyChanged(propertyName: "idProduto");
            }
        }


        private decimal? _nQuantidadeAdicional;

        [ParameterOrder(Order = 4)]
        public decimal? nQuantidadeAdicional
        {
            get { return _nQuantidadeAdicional; }
            set
            {
                _nQuantidadeAdicional = value;
                base.NotifyPropertyChanged(propertyName: "nQuantidadeAdicional");
            }
        }


        private decimal _nFator;

        [ParameterOrder(Order = 5)]
        public decimal nFator
        {
            get { return _nFator; }
            set
            {
                _nFator = value;
                base.NotifyPropertyChanged(propertyName: "nFator");
            }
        }


        private TipoArredondamento _enumTipoArredondamento;
        public TipoArredondamento enumTipoArredondamento
        {
            get { return _enumTipoArredondamento; }
            set
            {
                _enumTipoArredondamento = value;
                _stArredondar = (byte)value;
            }
        }

        private byte _stArredondar;
        [ParameterOrder(Order = 6)]
        public byte stArredondar
        {
            get { return _stArredondar; }
            set
            {
                _stArredondar = value;
                _enumTipoArredondamento = (TipoArredondamento)value;
            }
        }

        private int _idDeUnidadeMedida;

        [ParameterOrder(Order = 7)]
        public int idDeUnidadeMedida
        {
            get { return _idDeUnidadeMedida; }
            set
            {
                _idDeUnidadeMedida = value;
                base.NotifyPropertyChanged(propertyName: "idDeUnidadeMedida");
            }
        }

        private int _idParaUnidadeMedida;

        [ParameterOrder(Order = 8)]
        public int idParaUnidadeMedida
        {
            get { return _idParaUnidadeMedida; }
            set
            {
                _idParaUnidadeMedida = value;
                base.NotifyPropertyChanged(propertyName: "idParaUnidadeMedida");
            }
        }
    }

    public partial class ConversaoModel
    {
        public override string this[string columnName]
        {
            get
            {
                return base[columnName];
            }
        }
    }
}
