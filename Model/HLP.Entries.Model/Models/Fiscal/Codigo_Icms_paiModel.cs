using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Infrastructure;
using HLP.Comum.Model.Models;

namespace HLP.Entries.Model.Models.Fiscal
{
    public partial class Codigo_Icms_paiModel : modelBase
    {
        public Codigo_Icms_paiModel() : base("Codigo_Icms_pai")         
        {
            this.lCodigo_IcmsModel = new ObservableCollectionBaseCadastros<Codigo_IcmsModel>();
        }
        [ParameterOrder(Order = 1)]
        public int idEmpresa { get; set; }

        private int? _idCodigoIcmsPai;
        [ParameterOrder(Order = 2)]
        public int? idCodigoIcmsPai
        {
            get { return _idCodigoIcmsPai; }
            set
            {
                _idCodigoIcmsPai = value;
                base.NotifyPropertyChanged(propertyName: "idCodigoIcmsPai");
            }
        }

        [ParameterOrder(Order = 3)]
        public int cIcms { get; set; }

        
        private ObservableCollectionBaseCadastros<Codigo_IcmsModel> _lCodigo_IcmsModel;

        public ObservableCollectionBaseCadastros<Codigo_IcmsModel> lCodigo_IcmsModel
        {
            get { return _lCodigo_IcmsModel; }
            set
            {
                _lCodigo_IcmsModel = value;
                base.NotifyPropertyChanged(propertyName: "lCodigo_IcmsModel");
            }
        }
        
    }

    public partial class Codigo_IcmsModel : modelBase
    {
        public Codigo_IcmsModel() : base("Codigo_Icms") { }

        private int? _idCodigoIcms;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idCodigoIcms
        {
            get { return _idCodigoIcms; }
            set
            {
                _idCodigoIcms = value;
                base.NotifyPropertyChanged(propertyName: "idCodigoIcms");
            }
        }
        private int _idUf;
        [ParameterOrder(Order = 2)]
        public int idUf
        {
            get { return _idUf; }
            set
            {
                _idUf = value;
                base.NotifyPropertyChanged(propertyName: "idUf");
            }
        }
        private decimal _pIcmsEstado;
        [ParameterOrder(Order = 3)]
        public decimal pIcmsEstado
        {
            get { return _pIcmsEstado; }
            set
            {
                _pIcmsEstado = value;
                base.NotifyPropertyChanged(propertyName: "pIcmsEstado");
            }
        }
        private decimal _pIcmsInterna;
        [ParameterOrder(Order = 4)]
        public decimal pIcmsInterna
        {
            get { return _pIcmsInterna; }
            set
            {
                _pIcmsInterna = value;
                base.NotifyPropertyChanged(propertyName: "pIcmsInterna");
            }
        }
        private decimal _pIcmsSubstituicaoTributaria;
        [ParameterOrder(Order = 5)]
        public decimal pIcmsSubstituicaoTributaria
        {
            get { return _pIcmsSubstituicaoTributaria; }
            set
            {
                _pIcmsSubstituicaoTributaria = value;
                base.NotifyPropertyChanged(propertyName: "pIcmsSubstituicaoTributaria");
            }
        }
        private decimal _pIcmsNaoContribruinteForaEstado;
        [ParameterOrder(Order = 6)]
        public decimal pIcmsNaoContribruinteForaEstado
        {
            get { return _pIcmsNaoContribruinteForaEstado; }
            set
            {
                _pIcmsNaoContribruinteForaEstado = value;
                base.NotifyPropertyChanged(propertyName: "pIcmsNaoContribruinteForaEstado");
            }
        }
        private decimal _vCoeficienteIcms;
        [ParameterOrder(Order = 7)]
        public decimal vCoeficienteIcms
        {
            get { return _vCoeficienteIcms; }
            set
            {
                _vCoeficienteIcms = value;
                base.NotifyPropertyChanged(propertyName: "vCoeficienteIcms");
            }
        }
        private string _xFundamLegalCodTrib;
        [ParameterOrder(Order = 8)]
        public string xFundamLegalCodTrib
        {
            get { return _xFundamLegalCodTrib; }
            set
            {
                _xFundamLegalCodTrib = value;
                base.NotifyPropertyChanged(propertyName: "xFundamLegalCodTrib");
            }
        }
        private int _idCodigoIcmsPai;
        [ParameterOrder(Order = 9)]
        public int idCodigoIcmsPai
        {
            get { return _idCodigoIcmsPai; }
            set
            {
                _idCodigoIcmsPai = value;
                base.NotifyPropertyChanged(propertyName: "idCodigoIcmsPai");
            }
        }
        private decimal? _pMvaSubstituicaoTributaria;
        [ParameterOrder(Order = 10)]
        public decimal? pMvaSubstituicaoTributaria
        {
            get { return _pMvaSubstituicaoTributaria; }
            set
            {
                _pMvaSubstituicaoTributaria = value;
                base.NotifyPropertyChanged(propertyName: "pMvaSubstituicaoTributaria");
            }
        }
        private int? _idCSTIcms;
        [ParameterOrder(Order = 11)]
        public int? idCSTIcms
        {
            get { return _idCSTIcms; }
            set
            {
                _idCSTIcms = value;
                base.NotifyPropertyChanged(propertyName: "idCSTIcms");
            }
        }
    }

    public partial class Codigo_Icms_paiModel
    {
        public override string this[string columnName]
        {
            get
            {
                return base[columnName];
            }
        }
    }
    public partial class Codigo_IcmsModel
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
