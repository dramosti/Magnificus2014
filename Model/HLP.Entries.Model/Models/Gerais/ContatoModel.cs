using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Infrastructure;
using HLP.Comum.Model.Models;
using HLP.Comum.Resources.RecursosBases;

namespace HLP.Entries.Model.Models.Gerais
{
    public partial class ContatoModel : modelBase
    {
        public ContatoModel()
            : base("Contato")
        {
            this.lContato_EnderecoModel = new ObservableCollectionBaseCadastros<Contato_EnderecoModel>();
        }

        public int? _idContato;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idContato
        {
            get { return _idContato; }
            set { _idContato = value; }
        }
        [ParameterOrder(Order = 2)]
        public string xNome { get; set; }
        [ParameterOrder(Order = 3)]
        public string xCargo { get; set; }
        [ParameterOrder(Order = 4)]
        public string xFuncao { get; set; }
        [ParameterOrder(Order = 5)]
        public string xProfissao { get; set; }
        [ParameterOrder(Order = 6)]
        public bool Ativo { get; set; }
        [ParameterOrder(Order = 7)]
        public string xTitulo { get; set; }
        [ParameterOrder(Order = 8)]
        public string xApelido { get; set; }
        [ParameterOrder(Order = 9)]
        public byte stSexo { get; set; }
        [ParameterOrder(Order = 10)]
        public byte stSensibilidade { get; set; }
        [ParameterOrder(Order = 11)]
        public TimeSpan dDisponivelaPartir { get; set; }
        [ParameterOrder(Order = 12)]
        public TimeSpan dDisponivelAte { get; set; }
        [ParameterOrder(Order = 13)]
        public byte stVip { get; set; }
        [ParameterOrder(Order = 14)]
        public byte stMalaDireta { get; set; }
        [ParameterOrder(Order = 15)]
        public string xMemorando { get; set; }
        [ParameterOrder(Order = 16)]
        public string xTelefoneComercial { get; set; }
        [ParameterOrder(Order = 17)]
        public string xRamalComercial { get; set; }
        [ParameterOrder(Order = 18)]
        public string xCelularComercial { get; set; }
        [ParameterOrder(Order = 19)]
        public string xRadioFoneComercial { get; set; }
        [ParameterOrder(Order = 20)]
        public string xPagerComercial { get; set; }
        [ParameterOrder(Order = 21)]
        public string xFaxComercial { get; set; }
        [ParameterOrder(Order = 22)]
        public string xEmailComercial { get; set; }
        [ParameterOrder(Order = 23)]
        public string xSkypeComercial { get; set; }
        [ParameterOrder(Order = 24)]
        public string xhttpComercial { get; set; }
        [ParameterOrder(Order = 25)]
        public string xMSNComercial { get; set; }
        [ParameterOrder(Order = 26)]
        public string xTelefoneResidencial { get; set; }
        [ParameterOrder(Order = 27)]
        public string xCelularResidencial { get; set; }
        [ParameterOrder(Order = 28)]
        public string xEmailResidencial { get; set; }
        [ParameterOrder(Order = 29)]
        public string xSkypeResidencial { get; set; }
        [ParameterOrder(Order = 30)]
        public string xMsnResidencial { get; set; }
        [ParameterOrder(Order = 31)]
        public string XhttpPessoal { get; set; }
        [ParameterOrder(Order = 32)]
        public string xRadioFoneResidencial { get; set; }
        [ParameterOrder(Order = 33)]
        public string xFilhos { get; set; }
        [ParameterOrder(Order = 34)]
        public DateTime dAniversario { get; set; }
        [ParameterOrder(Order = 35)]
        public DateTime dAniversarioTempoServico { get; set; }
        [ParameterOrder(Order = 36)]
        public string xConjuge { get; set; }
        [ParameterOrder(Order = 37)]
        public string xHobbies { get; set; }
        [ParameterOrder(Order = 38)]
        public byte stEstadoCivil { get; set; }
        [ParameterOrder(Order = 39)]
        public string xCPF { get; set; }
        [ParameterOrder(Order = 40)]
        public int? idDecisao { get; set; }
        [ParameterOrder(Order = 41)]
        public int? idPersonalidade { get; set; }
        [ParameterOrder(Order = 42)]
        public string xDepartamento { get; set; }
        [ParameterOrder(Order = 43)]
        public int? idContatoGerente { get; set; }
        [ParameterOrder(Order = 44)]
        public int? idFuncionario { get; set; }
        [ParameterOrder(Order = 45)]
        public int? idFidelidade { get; set; }

        private ObservableCollectionBaseCadastros<Contato_EnderecoModel> _lContato_EnderecoModel;

        public ObservableCollectionBaseCadastros<Contato_EnderecoModel> lContato_EnderecoModel
        {
            get { return _lContato_EnderecoModel; }
            set { _lContato_EnderecoModel = value; base.NotifyPropertyChanged("lContato_EnderecoModel"); }
        }
    }
    public partial class Contato_EnderecoModel : modelBase
    {
        public Contato_EnderecoModel()
            : base("Contato_Endereco")
        {
            enumTipoEndereco = TipoEndereco.COMERCIAL;
            enumTipoLogradouro = TipoLogradouro.AEROPORTO;
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
        private int _idCidade;
        [ParameterOrder(Order = 13)]
        public int idCidade
        {
            get { return _idCidade; }
            set
            {
                _idCidade = value;
                base.NotifyPropertyChanged(propertyName: "idCidade");
            }
        }
        private int _idContato;
        [ParameterOrder(Order = 14)]
        public int idContato
        {
            get { return _idContato; }
            set
            {
                _idContato = value;
                base.NotifyPropertyChanged(propertyName: "idContato");
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


    #region validacao

    public partial class ContatoModel
    {
        public override string this[string columnName]
        {
            get
            {
                return base[columnName];
            }
        }
    }
    public partial class Contato_EnderecoModel
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
