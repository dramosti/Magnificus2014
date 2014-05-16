using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Resources.RecursosBases;
using HLP.Base.ClassesBases;
using HLP.Components.Model.Models;

namespace HLP.Entries.Model.Models.Transportes
{
    public partial class TransportadorModel : modelBase
    {
        public TransportadorModel()
            : base(xTabela: "Transportador")
        {
            this.lTransportador_Endereco = new ObservableCollectionBaseCadastros<EnderecoModel>();
            this.lTransportador_Motorista = new ObservableCollectionBaseCadastros<ContatoModel>();
            this.lTransportador_Veiculos = new ObservableCollectionBaseCadastros<Transportador_VeiculosModel>();
            this.lTransportador_Contato = new ObservableCollectionBaseCadastros<ContatoModel>();
            this.Ativo = true;
        }

        private int? _idTransportador;

        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
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
        public byte _stPessoa = 0;
        [ParameterOrder(Order = 3)]
        public byte stPessoa
        {
            get { return _stPessoa; }
            set { _stPessoa = value; }
        }
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
        private bool _Ativo;
        [ParameterOrder(Order = 15)]
        public bool Ativo
        {
            get { return _Ativo; }
            set
            {
                _Ativo = value;
                base.NotifyPropertyChanged(propertyName: "Ativo");
            }
        }
        [ParameterOrder(Order = 16)]
        public string xObs { get; set; }
        [ParameterOrder(Order = 17)]
        public string xCpf { get; set; }
        [ParameterOrder(Order = 18)]
        public string xRntrc { get; set; }

        private ObservableCollectionBaseCadastros<ContatoModel> _lTransportador_Contato;

        public ObservableCollectionBaseCadastros<ContatoModel> lTransportador_Contato
        {
            get { return _lTransportador_Contato; }
            set
            {
                _lTransportador_Contato = value;
                base.NotifyPropertyChanged(propertyName: "lTransportador_Contato");
            }
        }

        private ObservableCollectionBaseCadastros<EnderecoModel> _lTransportador_Endereco;

        public ObservableCollectionBaseCadastros<EnderecoModel> lTransportador_Endereco
        {
            get { return _lTransportador_Endereco; }
            set
            {
                _lTransportador_Endereco = value;
                base.NotifyPropertyChanged(propertyName: "lTransportador_Endereco");
            }
        }

        private ObservableCollectionBaseCadastros<Transportador_VeiculosModel> _lTransportador_Veiculos;

        public ObservableCollectionBaseCadastros<Transportador_VeiculosModel> lTransportador_Veiculos
        {
            get { return _lTransportador_Veiculos; }
            set
            {
                _lTransportador_Veiculos = value;
                base.NotifyPropertyChanged(propertyName: "lTransportador_Veiculos");
            }
        }

        private ObservableCollectionBaseCadastros<ContatoModel> _lTransportador_Motorista;

        public ObservableCollectionBaseCadastros<ContatoModel> lTransportador_Motorista
        {
            get { return _lTransportador_Motorista; }
            set
            {
                _lTransportador_Motorista = value;
                base.NotifyPropertyChanged(propertyName: "lTransportador_Motorista");
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
            : base(xTabela: "Contato")
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
            : base(xTabela: "Contato")
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
                string sRet = base[columnName];

                return sRet;
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
