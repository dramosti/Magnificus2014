using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Base.ClassesBases;
using HLP.Components.Model.Models;
using HLP.Comum.Model.Models;

namespace HLP.Entries.Model.Models.Transportes
{
    public partial class TransportadorModel : modelComum
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
        private string _xCodigoAlternativo;
        [ParameterOrder(Order = 2)]
        public string xCodigoAlternativo
        {
            get { return _xCodigoAlternativo; }
            set
            {
                _xCodigoAlternativo = value;
                base.NotifyPropertyChanged(propertyName: "xCodigoAlternativo");
            }
        }
        private byte _stPessoa;
        [ParameterOrder(Order = 3)]
        public byte stPessoa
        {
            get { return _stPessoa; }
            set
            {
                _stPessoa = value;
                base.NotifyPropertyChanged(propertyName: "stPessoa");
            }
        }
        private string _xCpfCnpj;
        [ParameterOrder(Order = 4)]
        public string xCpfCnpj
        {
            get { return _xCpfCnpj; }
            set
            {
                _xCpfCnpj = value;
                base.NotifyPropertyChanged(propertyName: "xCpfCnpj");
            }
        }
        private string _xRgIe;
        [ParameterOrder(Order = 5)]
        public string xRgIe
        {
            get { return _xRgIe; }
            set
            {
                _xRgIe = value;
                base.NotifyPropertyChanged(propertyName: "xRgIe");
            }
        }
        private string _xIm;
        [ParameterOrder(Order = 6)]
        public string xIm
        {
            get { return _xIm; }
            set
            {
                _xIm = value;
                base.NotifyPropertyChanged(propertyName: "xIm");
            }
        }
        private string _xNome;
        [ParameterOrder(Order = 7)]
        public string xNome
        {
            get { return _xNome; }
            set
            {
                _xNome = value;
                base.NotifyPropertyChanged(propertyName: "xNome");
            }
        }
        private string _xFantasia;
        [ParameterOrder(Order = 8)]
        public string xFantasia
        {
            get { return _xFantasia; }
            set
            {
                _xFantasia = value;
                base.NotifyPropertyChanged(propertyName: "xFantasia");
            }
        }
        private string _xTelefone1;
        [ParameterOrder(Order = 9)]
        public string xTelefone1
        {
            get { return _xTelefone1; }
            set
            {
                _xTelefone1 = value;
                base.NotifyPropertyChanged(propertyName: "xTelefone1");
            }
        }
        private string _xTelefone2;
        [ParameterOrder(Order = 10)]
        public string xTelefone2
        {
            get { return _xTelefone2; }
            set
            {
                _xTelefone2 = value;
                base.NotifyPropertyChanged(propertyName: "xTelefone2");
            }
        }
        private string _xFax;
        [ParameterOrder(Order = 11)]
        public string xFax
        {
            get { return _xFax; }
            set
            {
                _xFax = value;
                base.NotifyPropertyChanged(propertyName: "xFax");
            }
        }
        private string _xEmail;
        [ParameterOrder(Order = 12)]
        public string xEmail
        {
            get { return _xEmail; }
            set
            {
                _xEmail = value;
                base.NotifyPropertyChanged(propertyName: "xEmail");
            }
        }
        private string _xHttp;
        [ParameterOrder(Order = 13)]
        public string xHttp
        {
            get { return _xHttp; }
            set
            {
                _xHttp = value;
                base.NotifyPropertyChanged(propertyName: "xHttp");
            }
        }
        private bool _Ativo;
        [ParameterOrder(Order = 14)]
        public bool Ativo
        {
            get { return _Ativo; }
            set
            {
                _Ativo = value;
                base.NotifyPropertyChanged(propertyName: "Ativo");
            }
        }
        private string _xObs;
        [ParameterOrder(Order = 15)]
        public string xObs
        {
            get { return _xObs; }
            set
            {
                _xObs = value;
                base.NotifyPropertyChanged(propertyName: "xObs");
            }
        }
        private string _xRntrc;
        [ParameterOrder(Order = 16)]
        public string xRntrc
        {
            get { return _xRntrc; }
            set
            {
                _xRntrc = value;
                base.NotifyPropertyChanged(propertyName: "xRntrc");
            }
        }


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

    public partial class Transportador_VeiculosModel : modelComum
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
    #endregion

}
    
