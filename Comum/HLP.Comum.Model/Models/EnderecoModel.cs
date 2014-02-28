using HLP.Comum.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Comum.Model.Models
{
    public partial class EnderecoModel : modelBase
    {
        public EnderecoModel()
            : base(xTabela: "EnderecoModel")
        {
        }
        private int? _idEndereco;
        [ParameterOrder(Order = 1)]
        public int? idEndereco
        {
            get { return _idEndereco; }
            set { _idEndereco = value; base.NotifyPropertyChanged(propertyName: "idEndereco"); }
        }

        private byte? _stPrincipal;
        [ParameterOrder(Order = 2)]
        public byte? stPrincipal
        {
            get { return _stPrincipal; }
            set { _stPrincipal = value; base.NotifyPropertyChanged(propertyName: "stPrincipal"); }
        }

        private string _xNome;
        [ParameterOrder(Order = 3)]
        public string xNome
        {
            get { return _xNome; }
            set { _xNome = value; base.NotifyPropertyChanged(propertyName: "xNome"); }
        }

        private byte _stTipoEndereco;
        [ParameterOrder(Order = 4)]
        public byte stTipoEndereco
        {
            get { return _stTipoEndereco; }
            set { _stTipoEndereco = value; base.NotifyPropertyChanged(propertyName: "stTipoEndereco"); }
        }

        private string _xCEP;
        [ParameterOrder(Order = 5)]
        public string xCEP
        {
            get { return _xCEP; }
            set { _xCEP = value; base.NotifyPropertyChanged(propertyName: "xCEP"); }
        }

        private byte _stLogradouro;
        [ParameterOrder(Order = 6)]
        public byte stLogradouro
        {
            get { return _stLogradouro; }
            set { _stLogradouro = value; base.NotifyPropertyChanged(propertyName: "stLogradouro"); }
        }

        private string _xEndereco;
        [ParameterOrder(Order = 7)]
        public string xEndereco
        {
            get { return _xEndereco; }
            set { _xEndereco = value; base.NotifyPropertyChanged(propertyName: "xEndereco"); }
        }

        private string _nNumero;
        [ParameterOrder(Order = 8)]
        public string nNumero
        {
            get { return _nNumero; }
            set { _nNumero = value; base.NotifyPropertyChanged(propertyName: "nNumero"); }
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


        private string _xCaixaPostal;
        [ParameterOrder(Order = 11)]
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
        [ParameterOrder(Order = 12)]
        public int idCidade
        {
            get { return _idCidade; }
            set
            {
                _idCidade = value;
                base.NotifyPropertyChanged(propertyName: "idCidade");
            }
        }

        private string _xLatitude;
        [ParameterOrder(Order = 13)]
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
        [ParameterOrder(Order = 14)]
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
        [ParameterOrder(Order = 15)]
        public string xFusoHorario
        {
            get { return _xFusoHorario; }
            set
            {
                _xFusoHorario = value;
                base.NotifyPropertyChanged(propertyName: "xFusoHorario");
            }
        }

        [ParameterOrder(Order = 16)]
        public int? idClienteFornecedor { get; set; }
        [ParameterOrder(Order = 17)]
        public int? idContato { get; set; }
        [ParameterOrder(Order = 18)]
        public int? idEmpresa { get; set; }
        [ParameterOrder(Order = 19)]
        public int? idFuncionario { get; set; }
        [ParameterOrder(Order = 20)]
        public int? idSite { get; set; }
        [ParameterOrder(Order = 21)]
        public int? idTransportador { get; set; }
        [ParameterOrder(Order = 22)]
        public int? idAgencia { get; set; }
    }

    public partial class EnderecoModel
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
