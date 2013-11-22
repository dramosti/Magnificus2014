﻿using HLP.Comum.Infrastructure;
using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.Gerais
{
    public partial class FuncionarioModel : modelBase
    {
        public FuncionarioModel()
            : base(xTabela: "Funcionario")
        {
        }

        private int? _idFuncionario;

        [ParameterOrder(Order = 1)]
        public int? idFuncionario
        {
            get { return _idFuncionario; }
            set
            {
                _idFuncionario = value;
                base.NotifyPropertyChanged(propertyName: "idFuncionario");
            }
        }

        [ParameterOrder(Order = 2)]
        public string xCodigoAlternativo { get; set; }
        [ParameterOrder(Order = 3)]
        public bool Ativo { get; set; }
        [ParameterOrder(Order = 4)]
        public string xNome { get; set; }
        [ParameterOrder(Order = 5)]
        public string xSaudacao { get; set; }
        [ParameterOrder(Order = 6)]
        public DateTime dAniversario { get; set; }
        [ParameterOrder(Order = 7)]
        public byte stSexo { get; set; }
        [ParameterOrder(Order = 8)]
        public DateTime dFalecimento { get; set; }
        [ParameterOrder(Order = 9)]
        public string xFormacaoEducacional { get; set; }
        [ParameterOrder(Order = 10)]
        public int idSite { get; set; }
        [ParameterOrder(Order = 11)]
        public int idDeposito { get; set; }
        [ParameterOrder(Order = 12)]
        public byte stTipoContaContabil { get; set; }
        [ParameterOrder(Order = 13)]
        public decimal vDiaria { get; set; }
        [ParameterOrder(Order = 14)]
        public string xCpf { get; set; }
        [ParameterOrder(Order = 15)]
        public string xNota { get; set; }
        [ParameterOrder(Order = 16)]
        public byte stTipo { get; set; }
        [ParameterOrder(Order = 17)]
        public byte stEstadoCivil { get; set; }
        [ParameterOrder(Order = 18)]
        public int idDepartamento { get; set; }
        [ParameterOrder(Order = 19)]
        public int idEmpresa { get; set; }
        [ParameterOrder(Order = 20)]
        public int stPerfil { get; set; }
        [ParameterOrder(Order = 21)]
        public int idCargo { get; set; }
        [ParameterOrder(Order = 22)]
        public string xInformacaoAtencao { get; set; }
        [ParameterOrder(Order = 23)]
        public int? idCalendario { get; set; }
        [ParameterOrder(Order = 24)]
        public string xVisto { get; set; }
        [ParameterOrder(Order = 25)]
        public DateTime dFinalVisto { get; set; }
        [ParameterOrder(Order = 26)]
        public string xRg { get; set; }
        [ParameterOrder(Order = 27)]
        public string xVistoTrabalho { get; set; }
        [ParameterOrder(Order = 28)]
        public DateTime dFinalVistoTrabalho { get; set; }
        [ParameterOrder(Order = 29)]
        public string xTelefoneComercial { get; set; }
        [ParameterOrder(Order = 30)]
        public string xRamalComercial { get; set; }
        [ParameterOrder(Order = 31)]
        public string xCelularComercial { get; set; }
        [ParameterOrder(Order = 32)]
        public string xRadioFoneComercial { get; set; }
        [ParameterOrder(Order = 33)]
        public string xPagerComercial { get; set; }
        [ParameterOrder(Order = 34)]
        public string xFaxComercial { get; set; }
        [ParameterOrder(Order = 35)]
        public string xEmailComercial { get; set; }
        [ParameterOrder(Order = 36)]
        public string xSkypeComercial { get; set; }
        [ParameterOrder(Order = 37)]
        public string xHttpComercial { get; set; }
        [ParameterOrder(Order = 38)]
        public string xMsnComercial { get; set; }
        [ParameterOrder(Order = 39)]
        public string xTelefoneResidencial { get; set; }
        [ParameterOrder(Order = 40)]
        public string xCelularResidencial { get; set; }
        [ParameterOrder(Order = 41)]
        public string xEmailResidencial { get; set; }
        [ParameterOrder(Order = 42)]
        public string xSkypeResidencial { get; set; }
        [ParameterOrder(Order = 43)]
        public string xMsnResidencial { get; set; }
        [ParameterOrder(Order = 44)]
        public string xHttpPessoal { get; set; }
        [ParameterOrder(Order = 45)]
        public string xRadioFoneResidencial { get; set; }
        [ParameterOrder(Order = 46)]
        public string xFilhos { get; set; }
        [ParameterOrder(Order = 47)]
        public DateTime dAdmissao { get; set; }
        [ParameterOrder(Order = 48)]
        public string xConjugue { get; set; }
        [ParameterOrder(Order = 49)]
        public decimal vSalarioHora { get; set; }
        [ParameterOrder(Order = 50)]
        public TimeSpan dQtdHorasSegunda { get; set; }
        [ParameterOrder(Order = 51)]
        public TimeSpan dQtdHorasTerca { get; set; }
        [ParameterOrder(Order = 52)]
        public TimeSpan dQtdHorasQuarta { get; set; }
        [ParameterOrder(Order = 53)]
        public TimeSpan dQtdHorasQuinta { get; set; }
        [ParameterOrder(Order = 54)]
        public TimeSpan dQtdHorasSexta { get; set; }
        [ParameterOrder(Order = 55)]
        public TimeSpan dQtdHorasSabado { get; set; }
        [ParameterOrder(Order = 56)]
        public TimeSpan dQtdHorasDomingo { get; set; }
        [ParameterOrder(Order = 57)]
        public decimal vSalario { get; set; }
        [ParameterOrder(Order = 58)]
        public byte stSalario { get; set; }
        [ParameterOrder(Order = 59)]
        public int? idResponsavel { get; set; }
        [ParameterOrder(Order = 60)]
        public decimal pComissaoAvista { get; set; }
        [ParameterOrder(Order = 61)]
        public decimal pComissaoAprazo { get; set; }
        [ParameterOrder(Order = 62)]
        public byte stComissao { get; set; }
        [ParameterOrder(Order = 63)]
        public int idContaBancaria { get; set; }
        [ParameterOrder(Order = 64)]
        public string xID { get; set; }
        [ParameterOrder(Order = 65)]
        public string xSenha { get; set; }
        [ParameterOrder(Order = 66)]
        public byte? stUsuario { get; set; }
        [ParameterOrder(Order = 67)]
        public bool stUsuarioAtivo { get; set; }

        public ObservableCollectionBaseCadastros<Funcionario_ArquivoModel> lFuncionario_Arquivo =
            new ObservableCollectionBaseCadastros<Funcionario_ArquivoModel>();
        public ObservableCollectionBaseCadastros<Funcionario_CertificacaoModel> lFuncionario_Certificacao =
            new ObservableCollectionBaseCadastros<Funcionario_CertificacaoModel>();
        public ObservableCollectionBaseCadastros<Funcionario_Comissao_ProdutoModel> lFuncionario_Comissao_Produto =
            new ObservableCollectionBaseCadastros<Funcionario_Comissao_ProdutoModel>();
        public ObservableCollectionBaseCadastros<Funcionario_EnderecoModel> lFuncionario_Endereco =
            new ObservableCollectionBaseCadastros<Funcionario_EnderecoModel>();
        public ObservableCollectionBaseCadastros<Funcionario_Margem_Lucro_ComissaoModel> lFuncionario_Margem_Lucro_Comissao =
            new ObservableCollectionBaseCadastros<Funcionario_Margem_Lucro_ComissaoModel>();
        public ObservableCollectionBaseCadastros<Funcionario_AcessoModel> lFuncionario_Acesso =
            new ObservableCollectionBaseCadastros<Funcionario_AcessoModel>();
    }

    public partial class Funcionario_EnderecoModel : modelBase
    {


        public Funcionario_EnderecoModel()
            : base(xTabela: "Funcionario_Endereco")
        {
        }

        [ParameterOrder(Order = 1)]
        public int? idEndereco { get; set; }
        [ParameterOrder(Order = 2)]
        public byte stTipoEndereco { get; set; }
        [ParameterOrder(Order = 3)]
        public string xEndereco { get; set; }
        [ParameterOrder(Order = 4)]
        public string xCep { get; set; }
        [ParameterOrder(Order = 5)]
        public string xNumero { get; set; }
        [ParameterOrder(Order = 6)]
        public string xComplemento { get; set; }
        [ParameterOrder(Order = 7)]
        public string xBairro { get; set; }
        [ParameterOrder(Order = 8)]
        public string xLatitude { get; set; }
        [ParameterOrder(Order = 9)]
        public string xLongitude { get; set; }
        [ParameterOrder(Order = 10)]
        public string xFusoHorario { get; set; }
        [ParameterOrder(Order = 11)]
        public string xCaixaPostal { get; set; }
        [ParameterOrder(Order = 12)]
        public int idFuncionario { get; set; }
        [ParameterOrder(Order = 13)]
        public int idCidade { get; set; }
        [ParameterOrder(Order = 14)]
        public byte? stPrincipal { get; set; }
        [ParameterOrder(Order = 15)]
        public string xNome { get; set; }
    }

    public partial class Funcionario_ArquivoModel : modelBase
    {
        public Funcionario_ArquivoModel()
            : base(xTabela: "Funcionario_Arquivo")
        {
        }

        [ParameterOrder(Order = 1)]
        public int? idFuncionarioArquivo { get; set; }
        [ParameterOrder(Order = 2)]
        public string xArquivo { get; set; }
        [ParameterOrder(Order = 3)]
        public string xLink { get; set; }
        [ParameterOrder(Order = 4)]
        public int idFuncionario { get; set; }
    }

    public partial class Funcionario_CertificacaoModel : modelBase
    {
        public Funcionario_CertificacaoModel()
            : base("Funcionario_Certificacao")
        {
        }

        [ParameterOrder(Order = 1)]
        public int? idFuncionarioCertificacao { get; set; }
        [ParameterOrder(Order = 2)]
        public byte stCertificacao { get; set; }
        [ParameterOrder(Order = 3)]
        public string xCertificacao { get; set; }
        [ParameterOrder(Order = 4)]
        public DateTime dConclusao { get; set; }
        [ParameterOrder(Order = 5)]
        public DateTime dValidade { get; set; }
        [ParameterOrder(Order = 6)]
        public string xMemorando { get; set; }
        [ParameterOrder(Order = 7)]
        public int idFuncionario { get; set; }
    }

    public partial class Funcionario_Comissao_ProdutoModel : modelBase
    {
        public Funcionario_Comissao_ProdutoModel()
            : base("Funcionario_Comissao_Produto")
        {
        }

        [ParameterOrder(Order = 1)]
        public int? idFuncionarioComissaoProduto { get; set; }
        [ParameterOrder(Order = 2)]
        public decimal pComissaoAvista { get; set; }
        [ParameterOrder(Order = 3)]
        public decimal pComissaoAprazo { get; set; }
        [ParameterOrder(Order = 4)]
        public int idFuncionario { get; set; }
        [ParameterOrder(Order = 5)]
        public int idProduto { get; set; }

    }

    public partial class Funcionario_Margem_Lucro_ComissaoModel : modelBase
    {
        public Funcionario_Margem_Lucro_ComissaoModel()
            : base(xTabela: "Funcionario_Margem_Lucro_Comissao")
        {
        }

        [ParameterOrder(Order = 1)]
        public int? idFuncionarioMargemLucroComissao { get; set; }
        [ParameterOrder(Order = 2)]
        public decimal pDeMargemVenda { get; set; }
        [ParameterOrder(Order = 3)]
        public decimal pAteMargemVenda { get; set; }
        [ParameterOrder(Order = 4)]
        public decimal pComissaoAvista { get; set; }
        [ParameterOrder(Order = 5)]
        public decimal pComissaoAprazo { get; set; }
        [ParameterOrder(Order = 6)]
        public int idFuncionario { get; set; }
    }

    public partial class Funcionario_AcessoModel : modelBase
    {
        public Funcionario_AcessoModel()
            : base(xTabela: "Acesso")
        {
        }

        [ParameterOrder(Order = 1)]
        public int? idAcesso { get; set; }
        [ParameterOrder(Order = 2)]
        public int idEmpresa { get; set; }
        [ParameterOrder(Order = 3)]
        public int idSetor { get; set; }
        [ParameterOrder(Order = 4)]
        public int idFuncionario { get; set; }
        [ParameterOrder(Order = 5)]
        public decimal vCompraAprovaAuto { get; set; }
    }

    #region Validação Model
    public partial class FuncionarioModel
    {
        public override string this[string columnName]
        {
            get
            {
                return base[columnName];
            }
        }
    }

    public partial class Funcionario_EnderecoModel
    {
        public override string this[string columnName]
        {
            get
            {
                return base[columnName];
            }
        }
    }

    public partial class Funcionario_ArquivoModel
    {
        public override string this[string columnName]
        {
            get
            {
                return base[columnName];
            }
        }
    }

    public partial class Funcionario_CertificacaoModel
    {
        public override string this[string columnName]
        {
            get
            {
                return base[columnName];
            }
        }
    }

    public partial class Funcionario_Comissao_ProdutoModel
    {
        public override string this[string columnName]
        {
            get
            {
                return base[columnName];
            }
        }
    }

    public partial class Funcionario_Margem_Lucro_ComissaoModel
    {
        public override string this[string columnName]
        {
            get
            {
                return base[columnName];
            }
        }
    }

    public partial class Funcionario_AcessoModel
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