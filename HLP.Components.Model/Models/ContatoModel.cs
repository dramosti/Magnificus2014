using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Base.ClassesBases;

namespace HLP.Components.Model.Models
{
    public partial class ContatoModel : modelBase
    {
        public ContatoModel()
            : base("Contato")
        {
            this.lContato_EnderecoModel = new ObservableCollectionBaseCadastros<Contato_EnderecoModel>();
        }

        private int? _idContato;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idContato
        {
            get { return _idContato; }
            set
            {
                _idContato = value;
                base.NotifyPropertyChanged(propertyName: "idContato");
            }
        }
        private string _xNome;
        [ParameterOrder(Order = 2)]
        public string xNome
        {
            get { return _xNome; }
            set
            {
                _xNome = value;
                base.NotifyPropertyChanged(propertyName: "xNome");
            }
        }
        private string _xCargo;
        [ParameterOrder(Order = 3)]
        public string xCargo
        {
            get { return _xCargo; }
            set
            {
                _xCargo = value;
                base.NotifyPropertyChanged(propertyName: "xCargo");
            }
        }
        private string _xFuncao;
        [ParameterOrder(Order = 4)]
        public string xFuncao
        {
            get { return _xFuncao; }
            set
            {
                _xFuncao = value;
                base.NotifyPropertyChanged(propertyName: "xFuncao");
            }
        }
        private string _xProfissao;
        [ParameterOrder(Order = 5)]
        public string xProfissao
        {
            get { return _xProfissao; }
            set
            {
                _xProfissao = value;
                base.NotifyPropertyChanged(propertyName: "xProfissao");
            }
        }
        private bool? _Ativo;
        [ParameterOrder(Order = 6)]
        public bool? Ativo
        {
            get { return _Ativo; }
            set
            {
                _Ativo = value;
                base.NotifyPropertyChanged(propertyName: "Ativo");
            }
        }
        private string _xTitulo;
        [ParameterOrder(Order = 7)]
        public string xTitulo
        {
            get { return _xTitulo; }
            set
            {
                _xTitulo = value;
                base.NotifyPropertyChanged(propertyName: "xTitulo");
            }
        }
        private string _xApelido;
        [ParameterOrder(Order = 8)]
        public string xApelido
        {
            get { return _xApelido; }
            set
            {
                _xApelido = value;
                base.NotifyPropertyChanged(propertyName: "xApelido");
            }
        }
        private byte? _stSexo;
        [ParameterOrder(Order = 9)]
        public byte? stSexo
        {
            get { return _stSexo; }
            set
            {
                _stSexo = value;
                base.NotifyPropertyChanged(propertyName: "stSexo");
            }
        }
        private byte? _stSensibilidade;
        [ParameterOrder(Order = 10)]
        public byte? stSensibilidade
        {
            get { return _stSensibilidade; }
            set
            {
                _stSensibilidade = value;
                base.NotifyPropertyChanged(propertyName: "stSensibilidade");
            }
        }
        private TimeSpan? _dDisponivelaPartir;
        [ParameterOrder(Order = 11)]
        public TimeSpan? dDisponivelaPartir
        {
            get { return _dDisponivelaPartir; }
            set
            {
                _dDisponivelaPartir = value;
                base.NotifyPropertyChanged(propertyName: "dDisponivelaPartir");
            }
        }
        private TimeSpan? _dDisponivelAte;
        [ParameterOrder(Order = 12)]
        public TimeSpan? dDisponivelAte
        {
            get { return _dDisponivelAte; }
            set
            {
                _dDisponivelAte = value;
                base.NotifyPropertyChanged(propertyName: "dDisponivelAte");
            }
        }
        private byte? _stVip;
        [ParameterOrder(Order = 13)]
        public byte? stVip
        {
            get { return _stVip; }
            set
            {
                _stVip = value;
                base.NotifyPropertyChanged(propertyName: "stVip");
            }
        }
        private byte? _stMalaDireta;
        [ParameterOrder(Order = 14)]
        public byte? stMalaDireta
        {
            get { return _stMalaDireta; }
            set
            {
                _stMalaDireta = value;
                base.NotifyPropertyChanged(propertyName: "stMalaDireta");
            }
        }
        private string _xMemorando;
        [ParameterOrder(Order = 15)]
        public string xMemorando
        {
            get { return _xMemorando; }
            set
            {
                _xMemorando = value;
                base.NotifyPropertyChanged(propertyName: "xMemorando");
            }
        }
        private string _xTelefoneComercial;
        [ParameterOrder(Order = 16)]
        public string xTelefoneComercial
        {
            get { return _xTelefoneComercial; }
            set
            {
                _xTelefoneComercial = value;
                base.NotifyPropertyChanged(propertyName: "xTelefoneComercial");
            }
        }
        private string _xRamalComercial;
        [ParameterOrder(Order = 17)]
        public string xRamalComercial
        {
            get { return _xRamalComercial; }
            set
            {
                _xRamalComercial = value;
                base.NotifyPropertyChanged(propertyName: "xRamalComercial");
            }
        }
        private string _xCelularComercial;
        [ParameterOrder(Order = 18)]
        public string xCelularComercial
        {
            get { return _xCelularComercial; }
            set
            {
                _xCelularComercial = value;
                base.NotifyPropertyChanged(propertyName: "xCelularComercial");
            }
        }
        private string _xRadioFoneComercial;
        [ParameterOrder(Order = 19)]
        public string xRadioFoneComercial
        {
            get { return _xRadioFoneComercial; }
            set
            {
                _xRadioFoneComercial = value;
                base.NotifyPropertyChanged(propertyName: "xRadioFoneComercial");
            }
        }
        private string _xPagerComercial;
        [ParameterOrder(Order = 20)]
        public string xPagerComercial
        {
            get { return _xPagerComercial; }
            set
            {
                _xPagerComercial = value;
                base.NotifyPropertyChanged(propertyName: "xPagerComercial");
            }
        }
        private string _xFaxComercial;
        [ParameterOrder(Order = 21)]
        public string xFaxComercial
        {
            get { return _xFaxComercial; }
            set
            {
                _xFaxComercial = value;
                base.NotifyPropertyChanged(propertyName: "xFaxComercial");
            }
        }
        private string _xEmailComercial;
        [ParameterOrder(Order = 22)]
        public string xEmailComercial
        {
            get { return _xEmailComercial; }
            set
            {
                _xEmailComercial = value;
                base.NotifyPropertyChanged(propertyName: "xEmailComercial");
            }
        }
        private string _xSkypeComercial;
        [ParameterOrder(Order = 23)]
        public string xSkypeComercial
        {
            get { return _xSkypeComercial; }
            set
            {
                _xSkypeComercial = value;
                base.NotifyPropertyChanged(propertyName: "xSkypeComercial");
            }
        }
        private string _xHttpComercial;
        [ParameterOrder(Order = 24)]
        public string xHttpComercial
        {
            get { return _xHttpComercial; }
            set
            {
                _xHttpComercial = value;
                base.NotifyPropertyChanged(propertyName: "xHttpComercial");
            }
        }
        private string _xMsnComercial;
        [ParameterOrder(Order = 25)]
        public string xMsnComercial
        {
            get { return _xMsnComercial; }
            set
            {
                _xMsnComercial = value;
                base.NotifyPropertyChanged(propertyName: "xMsnComercial");
            }
        }
        private string _xTelefoneResidencial;
        [ParameterOrder(Order = 26)]
        public string xTelefoneResidencial
        {
            get { return _xTelefoneResidencial; }
            set
            {
                _xTelefoneResidencial = value;
                base.NotifyPropertyChanged(propertyName: "xTelefoneResidencial");
            }
        }
        private string _xCelularResidencial;
        [ParameterOrder(Order = 27)]
        public string xCelularResidencial
        {
            get { return _xCelularResidencial; }
            set
            {
                _xCelularResidencial = value;
                base.NotifyPropertyChanged(propertyName: "xCelularResidencial");
            }
        }
        private string _xEmailResidencial;
        [ParameterOrder(Order = 28)]
        public string xEmailResidencial
        {
            get { return _xEmailResidencial; }
            set
            {
                _xEmailResidencial = value;
                base.NotifyPropertyChanged(propertyName: "xEmailResidencial");
            }
        }
        private string _xSkypeResidencial;
        [ParameterOrder(Order = 29)]
        public string xSkypeResidencial
        {
            get { return _xSkypeResidencial; }
            set
            {
                _xSkypeResidencial = value;
                base.NotifyPropertyChanged(propertyName: "xSkypeResidencial");
            }
        }
        private string _xMsnResidencial;
        [ParameterOrder(Order = 30)]
        public string xMsnResidencial
        {
            get { return _xMsnResidencial; }
            set
            {
                _xMsnResidencial = value;
                base.NotifyPropertyChanged(propertyName: "xMsnResidencial");
            }
        }
        private string _xHttpPessoal;
        [ParameterOrder(Order = 31)]
        public string xHttpPessoal
        {
            get { return _xHttpPessoal; }
            set
            {
                _xHttpPessoal = value;
                base.NotifyPropertyChanged(propertyName: "xHttpPessoal");
            }
        }
        private string _xRadioFoneResidencial;
        [ParameterOrder(Order = 32)]
        public string xRadioFoneResidencial
        {
            get { return _xRadioFoneResidencial; }
            set
            {
                _xRadioFoneResidencial = value;
                base.NotifyPropertyChanged(propertyName: "xRadioFoneResidencial");
            }
        }
        private string _xFilhos;
        [ParameterOrder(Order = 33)]
        public string xFilhos
        {
            get { return _xFilhos; }
            set
            {
                _xFilhos = value;
                base.NotifyPropertyChanged(propertyName: "xFilhos");
            }
        }
        private DateTime? _dAniversario;
        [ParameterOrder(Order = 34)]
        public DateTime? dAniversario
        {
            get { return _dAniversario; }
            set
            {
                _dAniversario = value;
                base.NotifyPropertyChanged(propertyName: "dAniversario");
            }
        }
        private DateTime? _dAniversarioTempoServico;
        [ParameterOrder(Order = 35)]
        public DateTime? dAniversarioTempoServico
        {
            get { return _dAniversarioTempoServico; }
            set
            {
                _dAniversarioTempoServico = value;
                base.NotifyPropertyChanged(propertyName: "dAniversarioTempoServico");
            }
        }
        private string _xConjuge;
        [ParameterOrder(Order = 36)]
        public string xConjuge
        {
            get { return _xConjuge; }
            set
            {
                _xConjuge = value;
                base.NotifyPropertyChanged(propertyName: "xConjuge");
            }
        }
        private string _xHobbies;
        [ParameterOrder(Order = 37)]
        public string xHobbies
        {
            get { return _xHobbies; }
            set
            {
                _xHobbies = value;
                base.NotifyPropertyChanged(propertyName: "xHobbies");
            }
        }
        private byte? _stEstadoCivil;
        [ParameterOrder(Order = 38)]
        public byte? stEstadoCivil
        {
            get { return _stEstadoCivil; }
            set
            {
                _stEstadoCivil = value;
                base.NotifyPropertyChanged(propertyName: "stEstadoCivil");
            }
        }
        private string _xCPF;
        [ParameterOrder(Order = 39)]
        public string xCPF
        {
            get { return _xCPF; }
            set
            {
                _xCPF = value;
                base.NotifyPropertyChanged(propertyName: "xCPF");
            }
        }
        private int? _idDecisao;
        [ParameterOrder(Order = 40)]
        public int? idDecisao
        {
            get { return _idDecisao; }
            set
            {
                _idDecisao = value;
                base.NotifyPropertyChanged(propertyName: "idDecisao");
            }
        }
        private int? _idPersonalidade;
        [ParameterOrder(Order = 41)]
        public int? idPersonalidade
        {
            get { return _idPersonalidade; }
            set
            {
                _idPersonalidade = value;
                base.NotifyPropertyChanged(propertyName: "idPersonalidade");
            }
        }
        private string _xDepartamento;
        [ParameterOrder(Order = 42)]
        public string xDepartamento
        {
            get { return _xDepartamento; }
            set
            {
                _xDepartamento = value;
                base.NotifyPropertyChanged(propertyName: "xDepartamento");
            }
        }
        private int? _idContatoGerente;
        [ParameterOrder(Order = 43)]
        public int? idContatoGerente
        {
            get { return _idContatoGerente; }
            set
            {
                _idContatoGerente = value;
                base.NotifyPropertyChanged(propertyName: "idContatoGerente");
            }
        }
        private int? _idFuncionario;
        [ParameterOrder(Order = 44)]
        public int? idFuncionario
        {
            get { return _idFuncionario; }
            set
            {
                _idFuncionario = value;
                base.NotifyPropertyChanged(propertyName: "idFuncionario");
            }
        }
        private int? _idFidelidade;
        [ParameterOrder(Order = 45)]
        public int? idFidelidade
        {
            get { return _idFidelidade; }
            set
            {
                _idFidelidade = value;
                base.NotifyPropertyChanged(propertyName: "idFidelidade");
            }
        }
        private int? _idContatoTransportador;
        [ParameterOrder(Order = 46)]
        public int? idContatoTransportador
        {
            get { return _idContatoTransportador; }
            set
            {
                _idContatoTransportador = value;
                base.NotifyPropertyChanged(propertyName: "idContatoTransportador");
            }
        }

        private string _xRntrc;
        [ParameterOrder(Order = 47)]
        public string xRntrc
        {
            get { return _xRntrc; }
            set
            {
                _xRntrc = value;
                base.NotifyPropertyChanged(propertyName: "xRntrc");
            }
        }
        private int? _idContatoMotorista;
        [ParameterOrder(Order = 48)]
        public int? idContatoMotorista
        {
            get { return _idContatoMotorista; }
            set
            {
                _idContatoMotorista = value;
                base.NotifyPropertyChanged(propertyName: "idContatoMotorista");
            }
        }

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
        private byte _stTipoEndereco;
        [ParameterOrder(Order = 2)]
        public byte stTipoEndereco
        {
            get { return _stTipoEndereco; }
            set
            {
                _stTipoEndereco = value;
                base.NotifyPropertyChanged(propertyName: "stTipoEndereco");
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
        private byte _stLogradouro;
        [ParameterOrder(Order = 4)]
        public byte stLogradouro
        {
            get { return _stLogradouro; }
            set
            {
                _stLogradouro = value;
                base.NotifyPropertyChanged(propertyName: "stLogradouro");
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
