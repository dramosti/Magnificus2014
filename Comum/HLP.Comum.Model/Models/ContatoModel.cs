using HLP.Comum.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Comum.Model.Models
{
    public partial class ContatoModel
    {
        public ContatoModel()
        {
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
    }

    #region Validação

    //public partial class ContatoModel
    //{
    //    public override string this[string columnName]
    //    {
    //        get
    //        {
    //            return base[columnName];
    //        }
    //    }
    //}

    #endregion
}
