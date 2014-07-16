using HLP.Base.ClassesBases;
using HLP.Base.Static;
using HLP.Comum.Model.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HLP.Components.Model.Models
{
    public partial class EnderecoModel : modelComum
    {
        public EnderecoModel()
            : base(xTabela: "Enderecos")
        {
            Window currentWindow = Sistema.GetOpenWindow();

            if (currentWindow != null)
            {
                Application.Current.Dispatcher.BeginInvoke((Action)(() =>
                    {
                        object currentModel = currentWindow.DataContext.GetType().GetProperty(name: "currentModel")
                    .GetValue(obj: currentWindow.DataContext);

                        if (currentModel != null)
                        {
                            if ((currentModel as modelComum).GetOperationModel() ==
                                 Base.EnumsBases.OperationModel.updating)
                            {
                                PropertyInfo pilEnderecos = currentModel.GetType().GetProperties().ToList().FirstOrDefault(
                                    i => i.ToString().ToUpper().Contains(value: "ENDERECO"));

                                if (pilEnderecos != null)
                                {
                                    ObservableCollectionBaseCadastros<EnderecoModel> list = pilEnderecos.GetValue(obj: currentModel) as ObservableCollectionBaseCadastros<EnderecoModel>;

                                    if (list != null)
                                        if (list.Count < 1)
                                            this.stPrincipal = (byte)1;
                                }
                            }
                        }
                    }));
            }
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

        private string _xCEP = "";
        [ParameterOrder(Order = 5)]
        public string xCEP
        {
            get { return _xCEP; }
            set
            {
                if (value != "")
                    if (this.ws == null)
                        this.ws = new WebServices.Cep();
                _xCEP = value;
                base.NotifyPropertyChanged(propertyName: "xCEP");
            }
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
        private int? _idClienteFornecedor;
        [ParameterOrder(Order = 13)]
        public int? idClienteFornecedor
        {
            get { return _idClienteFornecedor; }
            set
            {
                _idClienteFornecedor = value;
                base.NotifyPropertyChanged(propertyName: "idClienteFornecedor");
            }
        }
        private int? _idContato;
        [ParameterOrder(Order = 14)]
        public int? idContato
        {
            get { return _idContato; }
            set
            {
                _idContato = value;
                base.NotifyPropertyChanged(propertyName: "idContato");
            }
        }
        private int? _idEmpresa;
        [ParameterOrder(Order = 15)]
        public int? idEmpresa
        {
            get { return _idEmpresa; }
            set
            {
                _idEmpresa = value;
                base.NotifyPropertyChanged(propertyName: "idEmpresa");
            }
        }
        private int? _idFuncionario;
        [ParameterOrder(Order = 16)]
        public int? idFuncionario
        {
            get { return _idFuncionario; }
            set
            {
                _idFuncionario = value;
                base.NotifyPropertyChanged(propertyName: "idFuncionario");
            }
        }
        private int? _idSite;
        [ParameterOrder(Order = 17)]
        public int? idSite
        {
            get { return _idSite; }
            set
            {
                _idSite = value;
                base.NotifyPropertyChanged(propertyName: "idSite");
            }
        }
        private int? _idTransportador;
        [ParameterOrder(Order = 18)]
        public int? idTransportador
        {
            get { return _idTransportador; }
            set
            {
                _idTransportador = value;
                base.NotifyPropertyChanged(propertyName: "idTransportador");
            }
        }
        private int? _idAgencia;
        [ParameterOrder(Order = 19)]
        public int? idAgencia
        {
            get { return _idAgencia; }
            set
            {
                _idAgencia = value;
                base.NotifyPropertyChanged(propertyName: "idAgencia");
            }
        }

        private HLP.WebServices.Cep ws;

        private HLP.WebServices.Endereco _end;

        private HLP.WebServices.Endereco end
        {
            get { return _end; }
            set { _end = value; }
        }

        private string _xCepOld = "";

        private bool _bCanFindCep = false;

        public bool bCanFindCep
        {
            get { return _bCanFindCep; }
            set { _bCanFindCep = value; }
        }

        #region Propriedades não mapeadas


        private string _xCidade;

        public string xCidade
        {
            get { return _xCidade; }
            set
            {
                _xCidade = value;
                base.NotifyPropertyChanged(propertyName: "xCidade");
            }
        }


        #endregion

    }

    public partial class EnderecoModel
    {
        public override string this[string columnName]
        {
            get
            {
                string sReturn = base[columnName];

                if (columnName == "xCEP" && sReturn == null && this.bCanFindCep)
                {
                    if (!string.IsNullOrEmpty(this.xCEP))
                    {
                        if (this.xCEP != this._xCepOld)
                        {
                            this._xCepOld = this.xCEP;
                            this.end = ws.BuscaEndereco(this.xCEP);
                            if (end != null && this.status != Base.EnumsBases.statusModel.nenhum)
                            {
                                xEndereco = end.Logradouro;
                                xBairro = end.Bairro;

                                if (Sistema.lCidades != null)
                                {
                                    var res = Sistema.lCidades.FirstOrDefault(
                                        i => i.xDisplay == end.Cidade);

                                    if (res != null)
                                    {
                                        idCidade = res.id;
                                    }
                                }
                            }
                        }
                    }
                }
                return sReturn;
            }
        }
    }

}
