using HLP.Comum.Infrastructure;
using HLP.Comum.Model.Models;
using HLP.Comum.Resources.RecursosBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace HLP.Entries.Model.Models.Gerais
{
    public partial class FuncionarioModel : modelBase
    {
        public FuncionarioModel()
            : base(xTabela: "Funcionario")
        {
            this.lFuncionario_Endereco =
                new ObservableCollectionBaseCadastros<EnderecoModel>();
            this.lFuncionario_Certificacao =
                new ObservableCollectionBaseCadastros<Funcionario_CertificacaoModel>();
            this.lFuncionario_Comissao_Produto =
                new ObservableCollectionBaseCadastros<Funcionario_Comissao_ProdutoModel>();
            this.lFuncionario_Margem_Lucro_Comissao =
                new ObservableCollectionBaseCadastros<Funcionario_Margem_Lucro_ComissaoModel>();
            this.lFuncionario_Arquivo =
                new ObservableCollectionBaseCadastros<Funcionario_ArquivoModel>();
            this.lFuncionario_Acesso =
                new ObservableCollectionBaseCadastros<Funcionario_AcessoModel>();
            this.Ativo = true;
            this.stComissao = 0;
        }

        private int? _idFuncionario;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idFuncionario
        {
            get { return _idFuncionario; }
            set
            {
                _idFuncionario = value;
                base.NotifyPropertyChanged(propertyName: "idFuncionario");
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
        private bool? _Ativo;
        [ParameterOrder(Order = 3)]
        public bool? Ativo
        {
            get { return _Ativo; }
            set
            {
                _Ativo = value;
                base.NotifyPropertyChanged(propertyName: "Ativo");
            }
        }
        private string _xNome;
        [ParameterOrder(Order = 4)]
        public string xNome
        {
            get { return _xNome; }
            set
            {
                _xNome = value;
                base.NotifyPropertyChanged(propertyName: "xNome");
            }
        }
        private string _xSaudacao;
        [ParameterOrder(Order = 5)]
        public string xSaudacao
        {
            get { return _xSaudacao; }
            set
            {
                _xSaudacao = value;
                base.NotifyPropertyChanged(propertyName: "xSaudacao");
            }
        }
        private DateTime? _dAniversario;
        [ParameterOrder(Order = 6)]
        public DateTime? dAniversario
        {
            get { return _dAniversario; }
            set
            {
                _dAniversario = value;
                base.NotifyPropertyChanged(propertyName: "dAniversario");
            }
        }
        private byte? _stSexo;
        [ParameterOrder(Order = 7)]
        public byte? stSexo
        {
            get { return _stSexo; }
            set
            {
                _stSexo = value;
                base.NotifyPropertyChanged(propertyName: "stSexo");
            }
        }
        private DateTime? _dFalecimento;
        [ParameterOrder(Order = 8)]
        public DateTime? dFalecimento
        {
            get { return _dFalecimento; }
            set
            {
                _dFalecimento = value;
                base.NotifyPropertyChanged(propertyName: "dFalecimento");
            }
        }
        private string _xFormacaoEducacional;
        [ParameterOrder(Order = 9)]
        public string xFormacaoEducacional
        {
            get { return _xFormacaoEducacional; }
            set
            {
                _xFormacaoEducacional = value;
                base.NotifyPropertyChanged(propertyName: "xFormacaoEducacional");
            }
        }
        private int _idSite;
        [ParameterOrder(Order = 10)]
        public int idSite
        {
            get { return _idSite; }
            set
            {
                _idSite = value;
                base.NotifyPropertyChanged(propertyName: "idSite");
            }
        }
        private int _idDeposito;
        [ParameterOrder(Order = 11)]
        public int idDeposito
        {
            get { return _idDeposito; }
            set
            {
                _idDeposito = value;
                base.NotifyPropertyChanged(propertyName: "idDeposito");
            }
        }
        private byte? _stTipoContaContabil;
        [ParameterOrder(Order = 12)]
        public byte? stTipoContaContabil
        {
            get { return _stTipoContaContabil; }
            set
            {
                _stTipoContaContabil = value;
                base.NotifyPropertyChanged(propertyName: "stTipoContaContabil");
            }
        }
        private decimal? _vDiaria;
        [ParameterOrder(Order = 13)]
        public decimal? vDiaria
        {
            get { return _vDiaria; }
            set
            {
                _vDiaria = value;
                base.NotifyPropertyChanged(propertyName: "vDiaria");
            }
        }
        private string _xCpf;
        [ParameterOrder(Order = 14)]
        public string xCpf
        {
            get { return _xCpf; }
            set
            {
                _xCpf = value;
                base.NotifyPropertyChanged(propertyName: "xCpf");
            }
        }
        private string _xNota;
        [ParameterOrder(Order = 15)]
        public string xNota
        {
            get { return _xNota; }
            set
            {
                _xNota = value;
                base.NotifyPropertyChanged(propertyName: "xNota");
            }
        }
        private byte? _stTipo;
        [ParameterOrder(Order = 16)]
        public byte? stTipo
        {
            get { return _stTipo; }
            set
            {
                _stTipo = value;
                base.NotifyPropertyChanged(propertyName: "stTipo");
            }
        }
        private byte? _stEstadoCivil;
        [ParameterOrder(Order = 17)]
        public byte? stEstadoCivil
        {
            get { return _stEstadoCivil; }
            set
            {
                _stEstadoCivil = value;
                base.NotifyPropertyChanged(propertyName: "stEstadoCivil");
            }
        }
        private int _idDepartamento;
        [ParameterOrder(Order = 18)]
        public int idDepartamento
        {
            get { return _idDepartamento; }
            set
            {
                _idDepartamento = value;
                base.NotifyPropertyChanged(propertyName: "idDepartamento");
            }
        }
        private int _idEmpresa;
        [ParameterOrder(Order = 19)]
        public int idEmpresa
        {
            get { return _idEmpresa; }
            set
            {
                _idEmpresa = value;
                base.NotifyPropertyChanged(propertyName: "idEmpresa");
            }
        }
        private int _stPerfil;
        [ParameterOrder(Order = 20)]
        public int stPerfil
        {
            get { return _stPerfil; }
            set
            {
                _stPerfil = value;
                base.NotifyPropertyChanged(propertyName: "stPerfil");
            }
        }
        private int _idCargo;
        [ParameterOrder(Order = 21)]
        public int idCargo
        {
            get { return _idCargo; }
            set
            {
                _idCargo = value;
                base.NotifyPropertyChanged(propertyName: "idCargo");
            }
        }
        private string _xInformacaoAtencao;
        [ParameterOrder(Order = 22)]
        public string xInformacaoAtencao
        {
            get { return _xInformacaoAtencao; }
            set
            {
                _xInformacaoAtencao = value;
                base.NotifyPropertyChanged(propertyName: "xInformacaoAtencao");
            }
        }
        private int? _idCalendario;
        [ParameterOrder(Order = 23)]
        public int? idCalendario
        {
            get { return _idCalendario; }
            set
            {
                _idCalendario = value;
                base.NotifyPropertyChanged(propertyName: "idCalendario");
            }
        }
        private string _xVisto;
        [ParameterOrder(Order = 24)]
        public string xVisto
        {
            get { return _xVisto; }
            set
            {
                _xVisto = value;
                base.NotifyPropertyChanged(propertyName: "xVisto");
            }
        }
        private DateTime? _dFinalVisto;
        [ParameterOrder(Order = 25)]
        public DateTime? dFinalVisto
        {
            get { return _dFinalVisto; }
            set
            {
                _dFinalVisto = value;
                base.NotifyPropertyChanged(propertyName: "dFinalVisto");
            }
        }
        private string _xRg;
        [ParameterOrder(Order = 26)]
        public string xRg
        {
            get { return _xRg; }
            set
            {
                _xRg = value;
                base.NotifyPropertyChanged(propertyName: "xRg");
            }
        }
        private string _xVistoTrabalho;
        [ParameterOrder(Order = 27)]
        public string xVistoTrabalho
        {
            get { return _xVistoTrabalho; }
            set
            {
                _xVistoTrabalho = value;
                base.NotifyPropertyChanged(propertyName: "xVistoTrabalho");
            }
        }
        private DateTime? _dFinalVistoTrabalho;
        [ParameterOrder(Order = 28)]
        public DateTime? dFinalVistoTrabalho
        {
            get { return _dFinalVistoTrabalho; }
            set
            {
                _dFinalVistoTrabalho = value;
                base.NotifyPropertyChanged(propertyName: "dFinalVistoTrabalho");
            }
        }
        private string _xTelefoneComercial;
        [ParameterOrder(Order = 29)]
        public string xTelefoneComercial
        {
            get { return _xTelefoneComercial; }
            set
            {
                _xTelefoneComercial = value;
                base.NotifyPropertyChanged(propertyName: "xTelefoneComercial");
            }
        }
        private string _xRamalComercial;
        [ParameterOrder(Order = 30)]
        public string xRamalComercial
        {
            get { return _xRamalComercial; }
            set
            {
                _xRamalComercial = value;
                base.NotifyPropertyChanged(propertyName: "xRamalComercial");
            }
        }
        private string _xCelularComercial;
        [ParameterOrder(Order = 31)]
        public string xCelularComercial
        {
            get { return _xCelularComercial; }
            set
            {
                _xCelularComercial = value;
                base.NotifyPropertyChanged(propertyName: "xCelularComercial");
            }
        }
        private string _xRadioFoneComercial;
        [ParameterOrder(Order = 32)]
        public string xRadioFoneComercial
        {
            get { return _xRadioFoneComercial; }
            set
            {
                _xRadioFoneComercial = value;
                base.NotifyPropertyChanged(propertyName: "xRadioFoneComercial");
            }
        }
        private string _xPagerComercial;
        [ParameterOrder(Order = 33)]
        public string xPagerComercial
        {
            get { return _xPagerComercial; }
            set
            {
                _xPagerComercial = value;
                base.NotifyPropertyChanged(propertyName: "xPagerComercial");
            }
        }
        private string _xFaxComercial;
        [ParameterOrder(Order = 34)]
        public string xFaxComercial
        {
            get { return _xFaxComercial; }
            set
            {
                _xFaxComercial = value;
                base.NotifyPropertyChanged(propertyName: "xFaxComercial");
            }
        }
        private string _xEmailComercial;
        [ParameterOrder(Order = 35)]
        public string xEmailComercial
        {
            get { return _xEmailComercial; }
            set
            {
                _xEmailComercial = value;
                base.NotifyPropertyChanged(propertyName: "xEmailComercial");
            }
        }
        private string _xSkypeComercial;
        [ParameterOrder(Order = 36)]
        public string xSkypeComercial
        {
            get { return _xSkypeComercial; }
            set
            {
                _xSkypeComercial = value;
                base.NotifyPropertyChanged(propertyName: "xSkypeComercial");
            }
        }
        private string _xHttpComercial;
        [ParameterOrder(Order = 37)]
        public string xHttpComercial
        {
            get { return _xHttpComercial; }
            set
            {
                _xHttpComercial = value;
                base.NotifyPropertyChanged(propertyName: "xHttpComercial");
            }
        }
        private string _xMsnComercial;
        [ParameterOrder(Order = 38)]
        public string xMsnComercial
        {
            get { return _xMsnComercial; }
            set
            {
                _xMsnComercial = value;
                base.NotifyPropertyChanged(propertyName: "xMsnComercial");
            }
        }
        private string _xTelefoneResidencial;
        [ParameterOrder(Order = 39)]
        public string xTelefoneResidencial
        {
            get { return _xTelefoneResidencial; }
            set
            {
                _xTelefoneResidencial = value;
                base.NotifyPropertyChanged(propertyName: "xTelefoneResidencial");
            }
        }
        private string _xCelularResidencial;
        [ParameterOrder(Order = 40)]
        public string xCelularResidencial
        {
            get { return _xCelularResidencial; }
            set
            {
                _xCelularResidencial = value;
                base.NotifyPropertyChanged(propertyName: "xCelularResidencial");
            }
        }
        private string _xEmailResidencial;
        [ParameterOrder(Order = 41)]
        public string xEmailResidencial
        {
            get { return _xEmailResidencial; }
            set
            {
                _xEmailResidencial = value;
                base.NotifyPropertyChanged(propertyName: "xEmailResidencial");
            }
        }
        private string _xSkypeResidencial;
        [ParameterOrder(Order = 42)]
        public string xSkypeResidencial
        {
            get { return _xSkypeResidencial; }
            set
            {
                _xSkypeResidencial = value;
                base.NotifyPropertyChanged(propertyName: "xSkypeResidencial");
            }
        }
        private string _xMsnResidencial;
        [ParameterOrder(Order = 43)]
        public string xMsnResidencial
        {
            get { return _xMsnResidencial; }
            set
            {
                _xMsnResidencial = value;
                base.NotifyPropertyChanged(propertyName: "xMsnResidencial");
            }
        }
        private string _xHttpPessoal;
        [ParameterOrder(Order = 44)]
        public string xHttpPessoal
        {
            get { return _xHttpPessoal; }
            set
            {
                _xHttpPessoal = value;
                base.NotifyPropertyChanged(propertyName: "xHttpPessoal");
            }
        }
        private string _xRadioFoneResidencial;
        [ParameterOrder(Order = 45)]
        public string xRadioFoneResidencial
        {
            get { return _xRadioFoneResidencial; }
            set
            {
                _xRadioFoneResidencial = value;
                base.NotifyPropertyChanged(propertyName: "xRadioFoneResidencial");
            }
        }
        private string _xFilhos;
        [ParameterOrder(Order = 46)]
        public string xFilhos
        {
            get { return _xFilhos; }
            set
            {
                _xFilhos = value;
                base.NotifyPropertyChanged(propertyName: "xFilhos");
            }
        }
        private DateTime? _dAdmissao;
        [ParameterOrder(Order = 47)]
        public DateTime? dAdmissao
        {
            get { return _dAdmissao; }
            set
            {
                _dAdmissao = value;
                base.NotifyPropertyChanged(propertyName: "dAdmissao");
            }
        }
        private string _xConjugue;
        [ParameterOrder(Order = 48)]
        public string xConjugue
        {
            get { return _xConjugue; }
            set
            {
                _xConjugue = value;
                base.NotifyPropertyChanged(propertyName: "xConjugue");
            }
        }
        private decimal? _vSalarioHora;
        [ParameterOrder(Order = 49)]
        public decimal? vSalarioHora
        {
            get { return _vSalarioHora; }
            set
            {
                _vSalarioHora = value;
                base.NotifyPropertyChanged(propertyName: "vSalarioHora");
            }
        }
        private TimeSpan _dQtdHorasSegunda;
        [ParameterOrder(Order = 50)]
        public TimeSpan dQtdHorasSegunda
        {
            get { return _dQtdHorasSegunda; }
            set
            {
                _dQtdHorasSegunda = value;
                base.NotifyPropertyChanged(propertyName: "dQtdHorasSegunda");
            }
        }
        private TimeSpan _dQtdHorasTerca;
        [ParameterOrder(Order = 51)]
        public TimeSpan dQtdHorasTerca
        {
            get { return _dQtdHorasTerca; }
            set
            {
                _dQtdHorasTerca = value;
                base.NotifyPropertyChanged(propertyName: "dQtdHorasTerca");
            }
        }
        private TimeSpan _dQtdHorasQuarta;
        [ParameterOrder(Order = 52)]
        public TimeSpan dQtdHorasQuarta
        {
            get { return _dQtdHorasQuarta; }
            set
            {
                _dQtdHorasQuarta = value;
                base.NotifyPropertyChanged(propertyName: "dQtdHorasQuarta");
            }
        }
        private TimeSpan _dQtdHorasQuinta;
        [ParameterOrder(Order = 53)]
        public TimeSpan dQtdHorasQuinta
        {
            get { return _dQtdHorasQuinta; }
            set
            {
                _dQtdHorasQuinta = value;
                base.NotifyPropertyChanged(propertyName: "dQtdHorasQuinta");
            }
        }
        private TimeSpan _dQtdHorasSexta;
        [ParameterOrder(Order = 54)]
        public TimeSpan dQtdHorasSexta
        {
            get { return _dQtdHorasSexta; }
            set
            {
                _dQtdHorasSexta = value;
                base.NotifyPropertyChanged(propertyName: "dQtdHorasSexta");
            }
        }
        private TimeSpan _dQtdHorasSabado;
        [ParameterOrder(Order = 55)]
        public TimeSpan dQtdHorasSabado
        {
            get { return _dQtdHorasSabado; }
            set
            {
                _dQtdHorasSabado = value;
                base.NotifyPropertyChanged(propertyName: "dQtdHorasSabado");
            }
        }
        private TimeSpan _dQtdHorasDomingo;
        [ParameterOrder(Order = 56)]
        public TimeSpan dQtdHorasDomingo
        {
            get { return _dQtdHorasDomingo; }
            set
            {
                _dQtdHorasDomingo = value;
                base.NotifyPropertyChanged(propertyName: "dQtdHorasDomingo");
            }
        }
        private decimal? _vSalario;
        [ParameterOrder(Order = 57)]
        public decimal? vSalario
        {
            get { return _vSalario; }
            set
            {
                _vSalario = value;
                base.NotifyPropertyChanged(propertyName: "vSalario");
            }
        }
        private byte _stSalario;
        [ParameterOrder(Order = 58)]
        public byte stSalario
        {
            get { return _stSalario; }
            set
            {
                _stSalario = value;
                base.NotifyPropertyChanged(propertyName: "stSalario");
            }
        }
        private int? _idResponsavel;
        [ParameterOrder(Order = 59)]
        public int? idResponsavel
        {
            get { return _idResponsavel; }
            set
            {
                _idResponsavel = value;
                base.NotifyPropertyChanged(propertyName: "idResponsavel");
            }
        }
        private decimal? _pComissaoAvista;
        [ParameterOrder(Order = 60)]
        public decimal? pComissaoAvista
        {
            get { return _pComissaoAvista; }
            set
            {
                _pComissaoAvista = value;
                base.NotifyPropertyChanged(propertyName: "pComissaoAvista");
            }
        }
        private decimal? _pComissaoAprazo;
        [ParameterOrder(Order = 61)]
        public decimal? pComissaoAprazo
        {
            get { return _pComissaoAprazo; }
            set
            {
                _pComissaoAprazo = value;
                base.NotifyPropertyChanged(propertyName: "pComissaoAprazo");
            }
        }
        private byte? _stComissao;
        [ParameterOrder(Order = 62)]
        public byte? stComissao
        {
            get { return _stComissao; }
            set
            {
                _stComissao = value;

                if (value == 2)
                {
                    Window w = HLP.Comum.Infrastructure.Static.Sistema.GetOpenWindow(xName: "WinFuncionario");

                    if (w != null)
                    {
                        if (this.lFamiliaProduto == null)
                        {
                            Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, (Action)(() =>
                            {
                                Type t = w.DataContext.GetType();
                                ConstructorInfo constr = t.GetConstructor(Type.EmptyTypes);
                                object inst = constr.Invoke(new object[] { });
                                MethodInfo met = t.GetMethod(name: "GetListaFamiliaProduto");
                                List<Familia_produtoModel> lFamiliaProduto = met.Invoke(inst, new object[] { }) as List<Familia_produtoModel>;

                                if (lFamiliaProduto != null)
                                    this.lFamiliaProduto = new ObservableCollectionBaseCadastros<Familia_produtoModel>(list:
                                        lFamiliaProduto);
                            }));

                        }
                    }
                }

                base.NotifyPropertyChanged(propertyName: "stComissao");
            }
        }
        private int _idContaBancaria;
        [ParameterOrder(Order = 63)]
        public int idContaBancaria
        {
            get { return _idContaBancaria; }
            set
            {
                _idContaBancaria = value;
                base.NotifyPropertyChanged(propertyName: "idContaBancaria");
            }
        }
        private string _xID;
        [ParameterOrder(Order = 64)]
        public string xID
        {
            get { return _xID; }
            set
            {
                _xID = value;
                base.NotifyPropertyChanged(propertyName: "xID");
            }
        }
        private string _xSenha;
        [ParameterOrder(Order = 65)]
        public string xSenha
        {
            get { return _xSenha; }
            set
            {
                _xSenha = value;
                base.NotifyPropertyChanged(propertyName: "xSenha");
            }
        }
        private byte? _stUsuario;
        [ParameterOrder(Order = 66)]
        public byte? stUsuario
        {
            get { return _stUsuario; }
            set
            {
                _stUsuario = value;
                base.NotifyPropertyChanged(propertyName: "stUsuario");
            }
        }
        private bool _stUsuarioAtivo;
        [ParameterOrder(Order = 67)]
        public bool stUsuarioAtivo
        {
            get { return _stUsuarioAtivo; }
            set
            {
                _stUsuarioAtivo = value;
                base.NotifyPropertyChanged(propertyName: "stUsuarioAtivo");
            }
        }
        private byte _stLiberaHoraExtra;
        [ParameterOrder(Order = 68)]
        public byte stLiberaHoraExtra
        {
            get { return _stLiberaHoraExtra; }
            set
            {
                _stLiberaHoraExtra = value;
                base.NotifyPropertyChanged(propertyName: "stLiberaHoraExtra");
            }
        }

        private Byte[] _imgFoto;
        [ParameterOrder(Order = 69)]
        public Byte[] imgFoto
        {
            get { return _imgFoto; }
            set
            {
                _imgFoto = value;
                base.NotifyPropertyChanged(propertyName: "imgFoto");
            }
        }

        private ObservableCollectionBaseCadastros<EnderecoModel> _lFuncionario_Endereco;

        public ObservableCollectionBaseCadastros<EnderecoModel> lFuncionario_Endereco
        {
            get { return _lFuncionario_Endereco; }
            set
            {
                _lFuncionario_Endereco = value;
                base.NotifyPropertyChanged(propertyName: "lFuncionario_Endereco");
            }
        }


        private ObservableCollectionBaseCadastros<Funcionario_CertificacaoModel> _lFuncionario_Certificacao;

        public ObservableCollectionBaseCadastros<Funcionario_CertificacaoModel> lFuncionario_Certificacao
        {
            get { return _lFuncionario_Certificacao; }
            set
            {
                _lFuncionario_Certificacao = value;
                base.NotifyPropertyChanged(propertyName: "lFuncionario_Certificacao");
            }
        }


        private ObservableCollectionBaseCadastros<Funcionario_Comissao_ProdutoModel> _lFuncionario_Comissao_Produto;

        public ObservableCollectionBaseCadastros<Funcionario_Comissao_ProdutoModel> lFuncionario_Comissao_Produto
        {
            get { return _lFuncionario_Comissao_Produto; }
            set
            {
                _lFuncionario_Comissao_Produto = value;
                base.NotifyPropertyChanged(propertyName: "lFuncionario_Comissao_Produto");
            }
        }


        private ObservableCollectionBaseCadastros<Funcionario_Margem_Lucro_ComissaoModel> _lFuncionario_Margem_Lucro_Comissao;

        public ObservableCollectionBaseCadastros<Funcionario_Margem_Lucro_ComissaoModel> lFuncionario_Margem_Lucro_Comissao
        {
            get { return _lFuncionario_Margem_Lucro_Comissao; }
            set
            {
                _lFuncionario_Margem_Lucro_Comissao = value;
                base.NotifyPropertyChanged(propertyName: "lFuncionario_Margem_Lucro_Comissao");
            }
        }


        private ObservableCollectionBaseCadastros<Funcionario_ArquivoModel> _lFuncionario_Arquivo;

        public ObservableCollectionBaseCadastros<Funcionario_ArquivoModel> lFuncionario_Arquivo
        {
            get { return _lFuncionario_Arquivo; }
            set
            {
                _lFuncionario_Arquivo = value;
                base.NotifyPropertyChanged(propertyName: "lFuncionario_Arquivo");
            }
        }


        private ObservableCollectionBaseCadastros<Funcionario_AcessoModel> _lFuncionario_Acesso;

        public ObservableCollectionBaseCadastros<Funcionario_AcessoModel> lFuncionario_Acesso
        {
            get { return _lFuncionario_Acesso; }
            set
            {
                _lFuncionario_Acesso = value;
                base.NotifyPropertyChanged(propertyName: "lFuncionario_Acesso");
            }
        }


        private ObservableCollectionBaseCadastros<Familia_produtoModel> _lFamiliaProduto;

        public ObservableCollectionBaseCadastros<Familia_produtoModel> lFamiliaProduto
        {
            get { return _lFamiliaProduto; }
            set
            {
                _lFamiliaProduto = value;
                base.NotifyPropertyChanged(propertyName: "lFamiliaProduto");
            }
        }

    }


    public partial class Funcionario_ArquivoModel : modelBase
    {
        public Funcionario_ArquivoModel()
            : base(xTabela: "Funcionario_Arquivo")
        {
        }

        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
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

        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idFuncionarioCertificacao { get; set; }

        private TipoCertificacao _enumTipoCertificacao;
        public TipoCertificacao enumTipoCertificacao
        {
            get { return _enumTipoCertificacao; }
            set
            {
                _enumTipoCertificacao = value;
                _stCertificacao = (byte)value;
            }
        }

        private byte _stCertificacao;
        [ParameterOrder(Order = 2)]
        public byte stCertificacao
        {
            get { return _stCertificacao; }
            set
            {
                _stCertificacao = value;
                _enumTipoCertificacao = (TipoCertificacao)value;
            }
        }

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

        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
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

        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
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

        private int? _idAcesso;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idAcesso
        {
            get { return _idAcesso; }
            set
            {
                _idAcesso = value;
                base.NotifyPropertyChanged(propertyName: "idAcesso");
            }
        }
        private int _idEmpresa;
        [ParameterOrder(Order = 2)]
        public int idEmpresa
        {
            get { return _idEmpresa; }
            set
            {
                _idEmpresa = value;
                base.NotifyPropertyChanged(propertyName: "idEmpresa");
            }
        }
        private int _idSetor;
        [ParameterOrder(Order = 3)]
        public int idSetor
        {
            get { return _idSetor; }
            set
            {
                _idSetor = value;
                base.NotifyPropertyChanged(propertyName: "idSetor");
            }
        }
        private int _idFuncionario;
        [ParameterOrder(Order = 4)]
        public int idFuncionario
        {
            get { return _idFuncionario; }
            set
            {
                _idFuncionario = value;
                base.NotifyPropertyChanged(propertyName: "idFuncionario");
            }
        }
        private decimal _vCompraAprovaAuto;
        [ParameterOrder(Order = 5)]
        public decimal vCompraAprovaAuto
        {
            get { return _vCompraAprovaAuto; }
            set
            {
                _vCompraAprovaAuto = value;
                base.NotifyPropertyChanged(propertyName: "vCompraAprovaAuto");
            }
        }
    }

    #region Validação Model
    public partial class FuncionarioModel
    {
        public override string this[string columnName]
        {
            get
            {
                string s = base[columnName];

                return s;
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
