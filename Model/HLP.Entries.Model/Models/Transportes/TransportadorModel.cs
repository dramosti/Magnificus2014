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
            }
        }
        [ParameterOrder(Order = 2)]
        public byte? stPrincipal { get; set; }
        [ParameterOrder(Order = 3)]
        public string xNome { get; set; }
        [ParameterOrder(Order = 4)]
        public byte stTipoEndereco { get; set; }
        [ParameterOrder(Order = 5)]
        public string xCEP { get; set; }
        [ParameterOrder(Order = 6)]
        public byte stLogradouro { get; set; }
        [ParameterOrder(Order = 7)]
        public string xEndereco { get; set; }
        [ParameterOrder(Order = 8)]
        public string nNumero { get; set; }
        [ParameterOrder(Order = 9)]
        public string xComplemento { get; set; }
        [ParameterOrder(Order = 10)]
        public string xBairro { get; set; }
        [ParameterOrder(Order = 11)]
        public string xLatitude { get; set; }
        [ParameterOrder(Order = 12)]
        public string xLongitude { get; set; }
        [ParameterOrder(Order = 13)]
        public string xFusoHorario { get; set; }
        [ParameterOrder(Order = 14)]
        public string xCaixaPostal { get; set; }
        [ParameterOrder(Order = 15)]
        public int idTransportador { get; set; }
        [ParameterOrder(Order = 16)]
        public int idCidade { get; set; }

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
            }
        }
        [ParameterOrder(Order = 2)]
        public string xPlacaVeiculo { get; set; }
        [ParameterOrder(Order = 3)]
        public int idUf { get; set; }
        [ParameterOrder(Order = 4)]
        public int idTransportador { get; set; }
        [ParameterOrder(Order = 5)]
        public string xMarca { get; set; }
        [ParameterOrder(Order = 6)]
        public string xModelo { get; set; }
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
            }
        }
        [ParameterOrder(Order = 2)]
        public int idTransportador { get; set; }
        [ParameterOrder(Order = 3)]
        public int idContato { get; set; }
    }

    public partial class Transportador_MotoristaModel : modelBase
    {
        public Transportador_MotoristaModel()
            : base(xTabela: "Transportador_Motorista")
        {
        }
        private int? _idTransportdorMotorista;
        [ParameterOrder(Order = 1)]
        public int? idTransportdorMotorista
        {
            get { return _idTransportdorMotorista; }
            set
            {
                _idTransportdorMotorista = value;
            }
        }
        [ParameterOrder(Order = 2)]
        public int? idTransportador { get; set; }
        [ParameterOrder(Order = 3)]
        public int? idContato { get; set; }
        [ParameterOrder(Order = 4)]
        public string xRntrc { get; set; }
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
