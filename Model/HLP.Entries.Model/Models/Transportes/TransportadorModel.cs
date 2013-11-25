using HLP.Comum.Infrastructure;
using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.Transportes
{
    public partial class TransportadorModel : modelBase
    {
        public TransportadorModel()
            : base(xTabela: "Transportador")
        {
        }

        private int? _idTransportador;

        [ParameterOrder(Order = 1)]
        public int? idTransportador
        {
            get { return _idTransportador; }
            set
            {
                _idTransportador = value;
                base.NotifyPropertyChanged(propertyName: "idTransportador");
            }
        }

        [ParameterOrder(Order = 2)]
        public string xCodigoAlternativo { get; set; }
        [ParameterOrder(Order = 3)]
        public byte stPessoa { get; set; }
        [ParameterOrder(Order = 4)]
        public string xCnpj { get; set; }
        [ParameterOrder(Order = 5)]
        public string xIe { get; set; }
        [ParameterOrder(Order = 6)]
        public string xIm { get; set; }
        [ParameterOrder(Order = 7)]
        public string xRg { get; set; }
        [ParameterOrder(Order = 8)]
        public string xNome { get; set; }
        [ParameterOrder(Order = 9)]
        public string xFantasia { get; set; }
        [ParameterOrder(Order = 10)]
        public string xTelefone1 { get; set; }
        [ParameterOrder(Order = 11)]
        public string xTelefone2 { get; set; }
        [ParameterOrder(Order = 12)]
        public string xFax { get; set; }
        [ParameterOrder(Order = 13)]
        public string xEmail { get; set; }
        [ParameterOrder(Order = 14)]
        public string xHttp { get; set; }
        [ParameterOrder(Order = 15)]
        public bool Ativo { get; set; }
        [ParameterOrder(Order = 16)]
        public string xObs { get; set; }
        [ParameterOrder(Order = 17)]
        public string xCpf { get; set; }
        [ParameterOrder(Order = 18)]
        public string xRntrc { get; set; }

        public ObservableCollectionBaseCadastros<Transportador_EnderecoModel> lTransportador_Endereco =
            new ObservableCollectionBaseCadastros<Transportador_EnderecoModel>();

        public ObservableCollectionBaseCadastros<Transportador_VeiculosModel> lTransportador_Veiculos =
            new ObservableCollectionBaseCadastros<Transportador_VeiculosModel>();

        public ObservableCollectionBaseCadastros<Transportador_ContatoModel> lTransportador_Contato =
            new ObservableCollectionBaseCadastros<Transportador_ContatoModel>();

        public ObservableCollectionBaseCadastros<Transportador_MotoristaModel> lTransportador_Motorista =
            new ObservableCollectionBaseCadastros<Transportador_MotoristaModel>();


    }

    public partial class Transportador_EnderecoModel : modelBase
    {
        public Transportador_EnderecoModel()
            : base(xTabela: "Transportador_Endereco")
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
        private byte? _stPrincipal;
        [ParameterOrder(Order = 2)]
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
        [ParameterOrder(Order = 3)]
        public string xNome
        {
            get { return _xNome; }
            set
            {
                _xNome = value;
                base.NotifyPropertyChanged(propertyName: "xNome");
            }
        }
        private byte _stTipoEndereco;
        [ParameterOrder(Order = 4)]
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
        [ParameterOrder(Order = 5)]
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
        [ParameterOrder(Order = 6)]
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
        [ParameterOrder(Order = 7)]
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
        [ParameterOrder(Order = 8)]
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
        [ParameterOrder(Order = 9)]
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
        [ParameterOrder(Order = 10)]
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
        [ParameterOrder(Order = 11)]
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
        [ParameterOrder(Order = 12)]
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
        [ParameterOrder(Order = 13)]
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
        [ParameterOrder(Order = 14)]
        public string xCaixaPostal
        {
            get { return _xCaixaPostal; }
            set
            {
                _xCaixaPostal = value;
                base.NotifyPropertyChanged(propertyName: "xCaixaPostal");
            }
        }
        private int _idTransportador;
        [ParameterOrder(Order = 15)]
        public int idTransportador
        {
            get { return _idTransportador; }
            set
            {
                _idTransportador = value;
                base.NotifyPropertyChanged(propertyName: "idTransportador");
            }
        }
        private int _idCidade;
        [ParameterOrder(Order = 16)]
        public int idCidade
        {
            get { return _idCidade; }
            set
            {
                _idCidade = value;
                base.NotifyPropertyChanged(propertyName: "idCidade");
            }
        }

    }

    public partial class Transportador_VeiculosModel : modelBase
    {
        public Transportador_VeiculosModel()
            : base(xTabela: "Transportador_Veiculos")
        {
        }
        private int? _idTransportadorVeiculo;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idTransportadorVeiculo
        {
            get { return _idTransportadorVeiculo; }
            set
            {
                _idTransportadorVeiculo = value;
                base.NotifyPropertyChanged(propertyName: "idTransportadorVeiculo");
            }
        }
        private string _xPlacaVeiculo;
        [ParameterOrder(Order = 2)]
        public string xPlacaVeiculo
        {
            get { return _xPlacaVeiculo; }
            set
            {
                _xPlacaVeiculo = value;
                base.NotifyPropertyChanged(propertyName: "xPlacaVeiculo");
            }
        }
        private int _idUf;
        [ParameterOrder(Order = 3)]
        public int idUf
        {
            get { return _idUf; }
            set
            {
                _idUf = value;
                base.NotifyPropertyChanged(propertyName: "idUf");
            }
        }
        private int _idTransportador;
        [ParameterOrder(Order = 4)]
        public int idTransportador
        {
            get { return _idTransportador; }
            set
            {
                _idTransportador = value;
                base.NotifyPropertyChanged(propertyName: "idTransportador");
            }
        }
        private string _xMarca;
        [ParameterOrder(Order = 5)]
        public string xMarca
        {
            get { return _xMarca; }
            set
            {
                _xMarca = value;
                base.NotifyPropertyChanged(propertyName: "xMarca");
            }
        }
        private string _xModelo;
        [ParameterOrder(Order = 6)]
        public string xModelo
        {
            get { return _xModelo; }
            set
            {
                _xModelo = value;
                base.NotifyPropertyChanged(propertyName: "xModelo");
            }
        }
    }

    public partial class Transportador_ContatoModel : modelBase
    {
        public Transportador_ContatoModel()
            : base(xTabela: "Transportador_Contato")
        {
        }

        private int? _idTransportdorContato;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idTransportdorContato
        {
            get { return _idTransportdorContato; }
            set
            {
                _idTransportdorContato = value;
                base.NotifyPropertyChanged(propertyName: "idTransportdorContato");
            }
        }
        private int _idTransportador;
        [ParameterOrder(Order = 2)]
        public int idTransportador
        {
            get { return _idTransportador; }
            set
            {
                _idTransportador = value;
                base.NotifyPropertyChanged(propertyName: "idTransportador");
            }
        }
        private int _idContato;
        [ParameterOrder(Order = 3)]
        public int idContato
        {
            get { return _idContato; }
            set
            {
                _idContato = value;
                base.NotifyPropertyChanged(propertyName: "idContato");
            }
        }
    }

    public partial class Transportador_MotoristaModel : modelBase
    {
        public Transportador_MotoristaModel()
            : base(xTabela: "Transportador_Motorista")
        {
        }
        private int? _idTransportdorMotorista;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idTransportdorMotorista
        {
            get { return _idTransportdorMotorista; }
            set
            {
                _idTransportdorMotorista = value;
                base.NotifyPropertyChanged(propertyName: "idTransportdorMotorista");
            }
        }
        private int? _idTransportador;
        [ParameterOrder(Order = 2)]
        public int? idTransportador
        {
            get { return _idTransportador; }
            set
            {
                _idTransportador = value;
                base.NotifyPropertyChanged(propertyName: "idTransportador");
            }
        }
        private int? _idContato;
        [ParameterOrder(Order = 3)]
        public int? idContato
        {
            get { return _idContato; }
            set
            {
                _idContato = value;
                base.NotifyPropertyChanged(propertyName: "idContato");
            }
        }
        private string _xRntrc;
        [ParameterOrder(Order = 4)]
        public string xRntrc
        {
            get { return _xRntrc; }
            set
            {
                _xRntrc = value;
                base.NotifyPropertyChanged(propertyName: "xRntrc");
            }
        }
    }

    #region Validações
    public partial class TransportadorModel
    {
        public override string this[string columnName]
        {
            get
            {
                return base[columnName];
            }
        }
    }

    public partial class Transportador_EnderecoModel
    {
        public override string this[string columnName]
        {
            get
            {
                return base[columnName];
            }
        }
    }

    public partial class Transportador_VeiculosModel
    {
        public override string this[string columnName]
        {
            get
            {
                return base[columnName];
            }
        }
    }

    public partial class Transportador_ContatoModel
    {
        public override string this[string columnName]
        {
            get
            {
                return base[columnName];
            }
        }
    }

    public partial class Transportador_MotoristaModel
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
