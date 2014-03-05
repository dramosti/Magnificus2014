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

        CidadeComumService.IserviceCidadeClient cidadeService = new CidadeComumService.IserviceCidadeClient();

        public EnderecoModel()
            : base(xTabela: "Enderecos")
        {
        }
        private int? _idEndereco;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idEndereco
        {
            get { return _idEndereco; }
            set { _idEndereco = value; base.NotifyPropertyChanged(propertyName: "idEndereco"); }
        }

        private byte? _stPrincipal = 0;
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

        [ParameterOrder(Order = 13)]
        public int? idClienteFornecedor { get; set; }
        [ParameterOrder(Order = 14)]
        public int? idContato { get; set; }
        [ParameterOrder(Order = 15)]
        public int? idEmpresa { get; set; }
        [ParameterOrder(Order = 16)]
        public int? idFuncionario { get; set; }
        [ParameterOrder(Order = 17)]
        public int? idSite { get; set; }
        [ParameterOrder(Order = 18)]
        public int? idTransportador { get; set; }
        [ParameterOrder(Order = 19)]
        public int? idAgencia { get; set; }
    }

    public partial class EnderecoModel
    {
        public override string this[string columnName]
        {
            get
            {
                string sReturn = base[columnName];
                
                if (columnName == "xCEP" && sReturn == null)
                {
                    object valor = this.GetType().GetProperty(columnName).GetValue(this);
                    if (valor != null)
                    {
                        HLP.WebServices.Cep ws = new HLP.WebServices.Cep();
                        HLP.WebServices.Endereco end = ws.BuscaEndereco(valor.ToString());
                        if (end != null)
                        {
                            xEndereco = end.Logradouro;
                            xBairro = end.Bairro;
                            
                             int? icidade = cidadeService.GetCidadeByName(end.Cidade);
                            if (icidade != null)
                            {
                                idCidade = (int)icidade;
                            }
                        }
                    }
                }
                return sReturn;
            }
        }
    }
}
