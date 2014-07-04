using HLP.Base.ClassesBases;
using HLP.Base.Static;
using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HLP.Entries.Model.Models.Financeiro
{
    public partial class Conta_bancariaModel : modelComum
    {


        public Conta_bancariaModel()
            : base(xTabela: "Conta_bancaria")
        {
            this.stConta = 1;
        }


        private int? _idContaBancaria;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idContaBancaria
        {
            get { return _idContaBancaria; }
            set
            {
                _idContaBancaria = value;
                base.NotifyPropertyChanged(propertyName: "idContaBancaria");
            }
        }

        [ParameterOrder(Order = 2)]
        public int idEmpresa { get; set; }
        [ParameterOrder(Order = 3)]
        public string xNumeroConta { get; set; }

        private byte _stConta;
        [ParameterOrder(Order = 4)]
        public byte stConta
        {
            get { return _stConta; }
            set
            {
                _stConta = value;
                base.NotifyPropertyChanged(propertyName: "stConta");
            }
        }

        [ParameterOrder(Order = 5)]
        public string xTitular { get; set; }
        [ParameterOrder(Order = 6)]
        public string xCNPJouCPFTitular { get; set; }

        private int _idAgencia;
        [ParameterOrder(Order = 7)]
        public int idAgencia
        {
            get { return _idAgencia; }
            set
            {
                _idAgencia = value;

                Window wd = Sistema.GetOpenWindow(xName: "WinContaBancaria");

                if (wd != null)
                {

                    Application.Current.Dispatcher.BeginInvoke((Action)(() =>
                        {
                            MethodInfo miGetAgencia = wd.DataContext.GetType().GetMethod(name: "GetAgencia");

                            if (miGetAgencia != null)
                                this.idBanco = (miGetAgencia.Invoke(obj: wd.DataContext,
                                    parameters: new object[] { idAgencia }) as int?) ?? 0;
                        }));
                }

                base.NotifyPropertyChanged(propertyName: "idAgencia");
            }
        }

        [ParameterOrder(Order = 8)]
        public string xNumeroContaHomeBanking { get; set; }
        [ParameterOrder(Order = 9)]
        public byte stBloquete { get; set; }
        [ParameterOrder(Order = 10)]
        public int nDiasProtesto { get; set; }
        [ParameterOrder(Order = 11)]
        public int nSequenciaNossoNumero { get; set; }
        [ParameterOrder(Order = 12)]
        public byte stZeraNossoNumero { get; set; }
        [ParameterOrder(Order = 13)]
        public int nCarteira { get; set; }
        [ParameterOrder(Order = 14)]
        public int nVariacaoCarteira { get; set; }
        [ParameterOrder(Order = 15)]
        public byte stAceite { get; set; }
        [ParameterOrder(Order = 16)]
        public int nConvenio { get; set; }
        [ParameterOrder(Order = 17)]
        public string xCodigoEmpresaHomeBanking { get; set; }
        [ParameterOrder(Order = 18)]
        public int nDigitosConvenio { get; set; }
        [ParameterOrder(Order = 19)]
        public string xEspecie { get; set; }
        [ParameterOrder(Order = 20)]
        public int nRemessaHomeBanking { get; set; }
        [ParameterOrder(Order = 21)]
        public string xDescricao { get; set; }


        private int _idBanco;

        public int idBanco
        {
            get { return _idBanco; }
            set
            {
                _idBanco = value;
                base.NotifyPropertyChanged(propertyName: "idBanco");
            }
        }

    }

    public partial class Conta_bancariaModel
    {
        public override string this[string columnName]
        {
            get
            {
                string xValidacao = base[columnName];
                bool bValidado = true;

                if (columnName == "xCNPJouCPFTitular")
                {
                    if (string.IsNullOrEmpty(value: xValidacao))
                    {
                        string xCPFCNPJSemMascara =
                            this.xCNPJouCPFTitular.Replace(oldValue: ".", newValue: "")
                            .Replace(oldValue: ",", newValue: "")
                            .Replace(oldValue: "-", newValue: "")
                            .Replace(oldValue: "/", newValue: "")
                            .Replace(oldValue: "\\", newValue: "")
                            .Replace(oldValue: " ", newValue: "");

                        if(xCPFCNPJSemMascara.Length == 14)
                        {
                            bValidado = HLP.Base.Static.Util.ValidaCnpj(strCnpj: xCPFCNPJSemMascara);
                        }
                        else
                        {
                            bValidado = HLP.Base.Static.Util.ValidaCpf(strCpf: xCPFCNPJSemMascara);
                        }

                        if (!bValidado)
                            xValidacao = "CPF/CNPJ inválido";
                    }
                }

                return xValidacao;
            }
        }
    }
}
