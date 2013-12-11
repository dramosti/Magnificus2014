using HLP.Comum.Infrastructure;
using HLP.Comum.Infrastructure.Static;
using HLP.Comum.Model.Models;
using HLP.Comum.Resources.RecursosBases;
using HLP.Entries.Model.Models.Parametros;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.Gerais
{
    public partial class EmpresaModel : modelBase
    {
        public EmpresaModel()
            : base(xTabela: "Empresa")
        {
            lEmpresa_endereco = new ObservableCollectionBaseCadastros<Empresa_EnderecoModel>();
        }

        private int? _idEmpresa;
        [ParameterOrder(Order = 1)]
        public int? idEmpresa
        {
            get
            {
                return _idEmpresa;
            }
            set
            {
                this._idEmpresa = value;
                base.NotifyPropertyChanged(propertyName: "idEmpresa");
            }
        }
        [ParameterOrder(Order = 2)]
        public string xNome { get; set; }
        [ParameterOrder(Order = 3)]
        public string xFantasia { get; set; }
        [ParameterOrder(Order = 4)]
        public string xCNPJ { get; set; }
        [ParameterOrder(Order = 5)]
        public string xIE { get; set; }
        [ParameterOrder(Order = 6)]
        public string xIM { get; set; }
        [ParameterOrder(Order = 7)]
        public string xSuframa { get; set; }
        [ParameterOrder(Order = 8)]
        public string xTelefone { get; set; }
        [ParameterOrder(Order = 9)]
        public string xFax { get; set; }
        [ParameterOrder(Order = 10)]
        public string xEmail { get; set; }
        [ParameterOrder(Order = 11)]
        public string xHttp { get; set; }
        [ParameterOrder(Order = 12)]
        public bool Ativo { get; set; }
        [ParameterOrder(Order = 13)]
        public string xLinkLogoEmpresa { get; set; }
        [ParameterOrder(Order = 14)]
        public string xLinkPastas { get; set; }
        [ParameterOrder(Order = 15)]
        public int idRamoAtividade { get; set; }
        [ParameterOrder(Order = 16)]
        public byte stCodigoRegimeTributario { get; set; }

        private ObservableCollectionBaseCadastros<Empresa_EnderecoModel> _lEmpresa_endereco;

        public ObservableCollectionBaseCadastros<Empresa_EnderecoModel> lEmpresa_endereco
        {
            get { return _lEmpresa_endereco; }
            set
            {
                _lEmpresa_endereco = value;
                base.NotifyPropertyChanged(propertyName: "lEmpresa_endereco");
            }
        }

        EmpresaParametrosModel _empresaParametros;

        public EmpresaParametrosModel empresaParametros
        {
            get { return _empresaParametros; }
            set { _empresaParametros = value; }
        }
    }

    public partial class Empresa_EnderecoModel : modelBase
    {
        public Empresa_EnderecoModel()
            : base(xTabela: "Empresa_endereco")
        {
        }

        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idEmpresaEndereco { get; set; }

        private int _idEmpresa { get; set; }
        [ParameterOrder(Order = 2)]
        public int idEmpresa
        {
            get { return _idEmpresa; }
            set
            {
                _idEmpresa = value;
            }
        }

        private TipoEndereco _enumTipoEnder;

        public TipoEndereco enumTipoEnder
        {
            get { return _enumTipoEnder; }
            set { _enumTipoEnder = value; base.NotifyPropertyChanged("enumTipoEnder"); _StTipoEnd = (int)value; }
        }


        private int _StTipoEnd;
        [ParameterOrder(Order = 3)]
        public int StTipoEnd
        {
            get { return _StTipoEnd; }
            set { _StTipoEnd = value; base.NotifyPropertyChanged(propertyName: "StTipoEnd"); _enumTipoEnder = (TipoEndereco)value; }
        }



        private string _xLgr;
        [ParameterOrder(Order = 4)]
        public string xLgr
        {
            get
            {
                return this._xLgr;
            }
            set
            {
                this._xLgr = value;
                base.NotifyPropertyChanged(propertyName: "xLgr");
            }
        }

        private string _nro;
        [ParameterOrder(Order = 5)]
        public string nro
        {
            get
            {
                return this._nro;
            }
            set
            {
                this._nro = value;
                base.NotifyPropertyChanged(propertyName: "nro");
            }
        }

        private string _xCpl;
        [ParameterOrder(Order = 6)]
        public string xCpl
        {
            get
            {
                return this._xCpl;
            }
            set
            {
                this._xCpl = value;
                base.NotifyPropertyChanged(propertyName: "xCpl");
            }
        }

        private string _xBairro;
        [ParameterOrder(Order = 7)]
        public string xBairro
        {
            get
            {
                return this._xBairro;
            }
            set
            {
                this._xBairro = value;
                base.NotifyPropertyChanged(propertyName: "xBairro");
            }
        }

        private string _Cep;
        [ParameterOrder(Order = 8)]
        public string Cep
        {
            get
            {
                return this._Cep;
            }
            set
            {
                this._Cep = value;
                base.NotifyPropertyChanged(propertyName: "Cep");
            }
        }
        private string _xCxPostal;
        [ParameterOrder(Order = 9)]
        public string xCxPostal
        {
            get
            {
                return this._xCxPostal;
            }
            set
            {
                this._xCxPostal = value;
                base.NotifyPropertyChanged(propertyName: "xCxPostal");
            }
        }
        private int _idCidade;
        [ParameterOrder(Order = 10)]
        public int idCidade
        {
            get
            {
                return this._idCidade;
            }
            set
            {
                this._idCidade = value;
                base.NotifyPropertyChanged(propertyName: "idCidade");
            }
        }

        private byte? _stPrincipal;
        [ParameterOrder(Order = 11)]
        public byte? stPrincipal
        {
            get
            {
                return this._stPrincipal;
            }
            set
            {
                this._stPrincipal = value;
                base.NotifyPropertyChanged(propertyName: "stPrincipal");
            }
        }
    }

    public partial class EmpresaParametrosModel : modelBase
    {
        public EmpresaParametrosModel()
        {
            this.objParametro_ComercialModel = new Parametro_ComercialModel();
            this.ObjParametro_ComprasModel = new Parametro_ComprasModel();
            this.ObjParametro_CustosModel = new Parametro_CustosModel();
            this.ObjParametro_EstoqueModel = new Parametro_EstoqueModel();
            this.ObjParametro_FinanceiroModel = new Parametro_FinanceiroModel();
            this.ObjParametro_FiscalModel = new Parametro_FiscalModel();
            this.ObjParametro_Ordem_ProducaoModel = new Parametro_Ordem_ProducaoModel();
        }

        private Parametro_EstoqueModel objParametro_EstoqueModel;

        public Parametro_EstoqueModel ObjParametro_EstoqueModel
        {
            get { return objParametro_EstoqueModel; }
            set
            {
                objParametro_EstoqueModel = value;
                base.NotifyPropertyChanged(propertyName: "ObjParametro_EstoqueModel");
            }
        }

        private Parametro_CustosModel objParametro_CustosModel;

        public Parametro_CustosModel ObjParametro_CustosModel
        {
            get { return objParametro_CustosModel; }
            set
            {
                objParametro_CustosModel = value;
                base.NotifyPropertyChanged(propertyName: "ObjParametro_CustosModel");
            }
        }

        private Parametro_ComprasModel objParametro_ComprasModel;

        public Parametro_ComprasModel ObjParametro_ComprasModel
        {
            get { return objParametro_ComprasModel; }
            set
            {
                objParametro_ComprasModel = value;
                base.NotifyPropertyChanged(propertyName: "ObjParametro_ComprasModel");
            }
        }

        private Parametro_Ordem_ProducaoModel objParametro_Ordem_ProducaoModel;

        public Parametro_Ordem_ProducaoModel ObjParametro_Ordem_ProducaoModel
        {
            get { return objParametro_Ordem_ProducaoModel; }
            set
            {
                objParametro_Ordem_ProducaoModel = value;
                base.NotifyPropertyChanged(propertyName: "ObjParametro_Ordem_ProducaoModel");
            }
        }

        private Parametro_FiscalModel objParametro_FiscalModel;

        public Parametro_FiscalModel ObjParametro_FiscalModel
        {
            get { return objParametro_FiscalModel; }
            set
            {
                objParametro_FiscalModel = value;
                base.NotifyPropertyChanged(propertyName: "ObjParametro_FiscalModel");
            }
        }

        private Parametro_ComercialModel objParametro_ComercialModel;

        public Parametro_ComercialModel ObjParametro_ComercialModel
        {
            get { return objParametro_ComercialModel; }
            set
            {
                objParametro_ComercialModel = value;
                base.NotifyPropertyChanged(propertyName: "ObjParametro_ComercialModel");
            }
        }

        private Parametro_FinanceiroModel objParametro_FinanceiroModel;

        public Parametro_FinanceiroModel ObjParametro_FinanceiroModel
        {
            get { return objParametro_FinanceiroModel; }
            set
            {
                objParametro_FinanceiroModel = value;
                base.NotifyPropertyChanged(propertyName: "ObjParametro_FinanceiroModel");
            }
        }
    }


    #region Validações
    public partial class EmpresaModel
    {
        public override string this[string columnName]
        {
            get
            {
                return base[columnName];
            }
        }
    }

    public partial class Empresa_EnderecoModel
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
