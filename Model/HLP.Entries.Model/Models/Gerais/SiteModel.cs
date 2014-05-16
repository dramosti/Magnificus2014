using HLP.Base.ClassesBases;
using HLP.Comum.Resources.RecursosBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.Gerais
{
    public partial class SiteModel : modelBase
    {

        public SiteModel()
            : base(xTabela: "Site")
        {
            this.lSite_Endereco = new ObservableCollectionBaseCadastros<Site_enderecoModel>();
        }

        private int? _idSite;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idSite
        {
            get { return _idSite; }
            set
            {
                _idSite = value;
                base.NotifyPropertyChanged(propertyName: "idSite");
            }
        }
        private string _xSite;
        [ParameterOrder(Order = 2)]
        public string xSite
        {
            get { return _xSite; }
            set
            {
                _xSite = value;
                base.NotifyPropertyChanged(propertyName: "xSite");
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


        private ObservableCollectionBaseCadastros<Site_enderecoModel> _lSite_Endereco;

        public ObservableCollectionBaseCadastros<Site_enderecoModel> lSite_Endereco
        {
            get { return _lSite_Endereco; }
            set
            {
                _lSite_Endereco = value;
                base.NotifyPropertyChanged(propertyName: "lSite_Endereco");
            }
        }
    }

    public partial class Site_enderecoModel : modelBase
    {

        public Site_enderecoModel()
            : base(xTabela: "Site_Endereco")
        {
            this.enumTipoEndereco = TipoEndereco.COMERCIAL;
            this.enumTipoLogradouro = TipoLogradouro.RUA;
        }

        private int? _idEndereco;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idEndereco
        {
            get { return _idEndereco; }
            set
            {
                _idEndereco = value;
                base.NotifyPropertyChanged(propertyName: "idEndereco");
            }
        }


        private TipoEndereco _enumTipoEndereco;
        public TipoEndereco enumTipoEndereco
        {
            get { return _enumTipoEndereco; }
            set
            {
                _enumTipoEndereco = value;
                _stTipoEndereco = (byte)value;
            }
        }

        private byte _stTipoEndereco;
        [ParameterOrder(Order = 2)]
        public byte stTipoEndereco
        {
            get { return _stTipoEndereco; }
            set
            {
                _stTipoEndereco = value;
                _enumTipoEndereco = (TipoEndereco)value;
            }
        }

        private string _xCEP;
        [ParameterOrder(Order = 3)]
        public string xCEP
        {
            get { return _xCEP; }
            set
            {
                _xCEP = value;
                base.NotifyPropertyChanged(propertyName: "xCEP");
            }
        }


        private TipoLogradouro _enumTipoLogradouro;
        public TipoLogradouro enumTipoLogradouro
        {
            get { return _enumTipoLogradouro; }
            set
            {
                _enumTipoLogradouro = value;
                _stLogradouro = (byte)value;
            }
        }

        private byte _stLogradouro;
        [ParameterOrder(Order = 4)]
        public byte stLogradouro
        {
            get { return _stLogradouro; }
            set
            {
                _stLogradouro = value;
                _enumTipoLogradouro = (TipoLogradouro)value;
            }
        }

        private string _xEndereco;
        [ParameterOrder(Order = 5)]
        public string xEndereco
        {
            get { return _xEndereco; }
            set
            {
                _xEndereco = value;
                base.NotifyPropertyChanged(propertyName: "xEndereco");
            }
        }
        private string _nNumero;
        [ParameterOrder(Order = 6)]
        public string nNumero
        {
            get { return _nNumero; }
            set
            {
                _nNumero = value;
                base.NotifyPropertyChanged(propertyName: "nNumero");
            }
        }
        private string _xComplemento;
        [ParameterOrder(Order = 7)]
        public string xComplemento
        {
            get { return _xComplemento; }
            set
            {
                _xComplemento = value;
                base.NotifyPropertyChanged(propertyName: "xComplemento");
            }
        }
        private string _xBairro;
        [ParameterOrder(Order = 8)]
        public string xBairro
        {
            get { return _xBairro; }
            set
            {
                _xBairro = value;
                base.NotifyPropertyChanged(propertyName: "xBairro");
            }
        }
        private string _xLatitude;
        [ParameterOrder(Order = 9)]
        public string xLatitude
        {
            get { return _xLatitude; }
            set
            {
                _xLatitude = value;
                base.NotifyPropertyChanged(propertyName: "xLatitude");
            }
        }
        private string _xLongitude;
        [ParameterOrder(Order = 10)]
        public string xLongitude
        {
            get { return _xLongitude; }
            set
            {
                _xLongitude = value;
                base.NotifyPropertyChanged(propertyName: "xLongitude");
            }
        }
        private string _xFusoHorario;
        [ParameterOrder(Order = 11)]
        public string xFusoHorario
        {
            get { return _xFusoHorario; }
            set
            {
                _xFusoHorario = value;
                base.NotifyPropertyChanged(propertyName: "xFusoHorario");
            }
        }
        private string _xCaixaPostal;
        [ParameterOrder(Order = 12)]
        public string xCaixaPostal
        {
            get { return _xCaixaPostal; }
            set
            {
                _xCaixaPostal = value;
                base.NotifyPropertyChanged(propertyName: "xCaixaPostal");
            }
        }
        private int _idSite;
        [ParameterOrder(Order = 13)]
        public int idSite
        {
            get { return _idSite; }
            set
            {
                _idSite = value;
                base.NotifyPropertyChanged(propertyName: "idSite");
            }
        }
        private int _idCidade;
        [ParameterOrder(Order = 14)]
        public int idCidade
        {
            get { return _idCidade; }
            set
            {
                _idCidade = value;
                base.NotifyPropertyChanged(propertyName: "idCidade");
            }
        }
        private byte? _stPrincipal;
        [ParameterOrder(Order = 15)]
        public byte? stPrincipal
        {
            get { return _stPrincipal; }
            set
            {
                _stPrincipal = value;
                base.NotifyPropertyChanged(propertyName: "stPrincipal");
            }
        }
        private string _xNome;
        [ParameterOrder(Order = 16)]
        public string xNome
        {
            get { return _xNome; }
            set
            {
                _xNome = value;
                base.NotifyPropertyChanged(propertyName: "xNome");
            }
        }
    }

    public partial class SiteModel
    {
        public override string this[string columnName]
        {
            get
            {
                return base[columnName];
            }
        }
    }

    public partial class Site_enderecoModel
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
