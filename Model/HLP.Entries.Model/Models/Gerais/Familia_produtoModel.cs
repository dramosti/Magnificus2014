using HLP.Base.ClassesBases;
using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.Gerais
{
    public partial class Familia_produtoModel : modelComum
    {
        public Familia_produtoModel()
            : base("Familia_produto")
        {
            lFamilia_Produto_ClassesModel = new ObservableCollectionBaseCadastros<Familia_Produto_ClassesModel>();
        }



        private int? _idFamiliaProduto;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idFamiliaProduto
        {
            get { return _idFamiliaProduto; }
            set
            {
                _idFamiliaProduto = value;
                base.NotifyPropertyChanged(propertyName: "idFamiliaProduto");
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
        private string _xFamiliaProduto;
        [ParameterOrder(Order = 3)]
        public string xFamiliaProduto
        {
            get { return _xFamiliaProduto; }
            set
            {
                _xFamiliaProduto = value;
                base.NotifyPropertyChanged(propertyName: "xFamiliaProduto");
            }
        }
        private string _xDescricao;
        [ParameterOrder(Order = 4)]
        public string xDescricao
        {
            get { return _xDescricao; }
            set
            {
                _xDescricao = value;
                base.NotifyPropertyChanged(propertyName: "xDescricao");
            }
        }
        private string _xSigla;
        [ParameterOrder(Order = 5)]
        public string xSigla
        {
            get { return _xSigla; }
            set
            {
                _xSigla = value;
                base.NotifyPropertyChanged(propertyName: "xSigla");
            }
        }
        private decimal _pDescontoMaximo;
        [ParameterOrder(Order = 6)]
        public decimal pDescontoMaximo
        {
            get { return _pDescontoMaximo; }
            set
            {
                _pDescontoMaximo = value;
                base.NotifyPropertyChanged(propertyName: "pDescontoMaximo");
            }
        }
        private decimal _pAcressimoMaximo;
        [ParameterOrder(Order = 7)]
        public decimal pAcressimoMaximo
        {
            get { return _pAcressimoMaximo; }
            set
            {
                _pAcressimoMaximo = value;
                base.NotifyPropertyChanged(propertyName: "pAcressimoMaximo");
            }
        }
        private decimal _pComissaoAvista;
        [ParameterOrder(Order = 8)]
        public decimal pComissaoAvista
        {
            get { return _pComissaoAvista; }
            set
            {
                _pComissaoAvista = value;
                base.NotifyPropertyChanged(propertyName: "pComissaoAvista");
            }
        }
        private decimal _pComissaoAprazo;
        [ParameterOrder(Order = 9)]
        public decimal pComissaoAprazo
        {
            get { return _pComissaoAprazo; }
            set
            {
                _pComissaoAprazo = value;
                base.NotifyPropertyChanged(propertyName: "pComissaoAprazo");
            }
        }
        private int? _idContaContabil;
        [ParameterOrder(Order = 10)]
        public int? idContaContabil
        {
            get { return _idContaContabil; }
            set
            {
                _idContaContabil = value;
                base.NotifyPropertyChanged(propertyName: "idContaContabil");
            }
        }
        private int? _idCentroCusto;
        [ParameterOrder(Order = 11)]
        public int? idCentroCusto
        {
            get { return _idCentroCusto; }
            set
            {
                _idCentroCusto = value;
                base.NotifyPropertyChanged(propertyName: "idCentroCusto");
            }
        }
        private int? _idFamiliaProdutoBase;
        [ParameterOrder(Order = 12)]
        public int? idFamiliaProdutoBase
        {
            get { return _idFamiliaProdutoBase; }
            set
            {
                _idFamiliaProdutoBase = value;
                base.NotifyPropertyChanged(propertyName: "idFamiliaProdutoBase");
            }
        }
        private byte _stGrau;
        [ParameterOrder(Order = 13)]
        public byte stGrau
        {
            get { return _stGrau; }
            set
            {
                _stGrau = value;
                base.NotifyPropertyChanged(propertyName: "stGrau");
            }
        }
        private byte _stAlteraDescricaoComercialProdutoVenda;
        [ParameterOrder(Order = 14)]
        public byte stAlteraDescricaoComercialProdutoVenda
        {
            get { return _stAlteraDescricaoComercialProdutoVenda; }
            set
            {
                _stAlteraDescricaoComercialProdutoVenda = value;
                base.NotifyPropertyChanged(propertyName: "stAlteraDescricaoComercialProdutoVenda");
            }
        }

        private ObservableCollectionBaseCadastros<Familia_Produto_ClassesModel> _lFamilia_Produto_ClassesModel;
        public ObservableCollectionBaseCadastros<Familia_Produto_ClassesModel> lFamilia_Produto_ClassesModel
        {
            get { return _lFamilia_Produto_ClassesModel; }
            set { _lFamilia_Produto_ClassesModel = value; base.NotifyPropertyChanged("lFamilia_Produto_ClassesModel"); }
        }
    }


    public partial class Familia_Produto_ClassesModel : modelComum
    {
        public Familia_Produto_ClassesModel() : base("Familia_Produto_Classes") { }

        private int? _idFamilia_Produto_Classes;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idFamilia_Produto_Classes
        {
            get { return _idFamilia_Produto_Classes; }
            set
            {
                _idFamilia_Produto_Classes = value;
                base.NotifyPropertyChanged(propertyName: "idFamilia_Produto_Classes");
            }
        }
        private int _idTipoOperacao;
        [ParameterOrder(Order = 2)]
        public int idTipoOperacao
        {
            get { return _idTipoOperacao; }
            set
            {
                _idTipoOperacao = value;
                base.NotifyPropertyChanged(propertyName: "idTipoOperacao");
            }
        }
        private int _idClasseFinanceira;
        [ParameterOrder(Order = 3)]
        public int idClasseFinanceira
        {
            get { return _idClasseFinanceira; }
            set
            {
                _idClasseFinanceira = value;
                base.NotifyPropertyChanged(propertyName: "idClasseFinanceira");
            }
        }
        private int _idFamiliaProduto;
        [ParameterOrder(Order = 4)]
        public int idFamiliaProduto
        {
            get { return _idFamiliaProduto; }
            set
            {
                _idFamiliaProduto = value;
                base.NotifyPropertyChanged(propertyName: "idFamiliaProduto");
            }
        }

    }


    #region Validacao

    public partial class Familia_produtoModel
    {
        public override string this[string columnName]
        {
            get
            {
                string _xError = base[columnName];

                if (string.IsNullOrEmpty(value: _xError))
                {
                    if (columnName == "xFamiliaProduto")
                    {
                        if (this.xFamiliaProduto.Replace(oldValue: " ", newValue: "").Length <
                            (HLP.Base.Static.CompanyData.objEmpresaModel as EmpresaModel)
                .empresaParametros.ObjParametro_EstoqueModel.xMascaraFamiliaProduto.Replace(
                oldValue: ".", newValue: "").Length)
                        {
                            _xError = "Código informado está fora de padrão da máscara de Código alternativo de produto definido em Parâmetros/Estoque/Mascara das Familias de Produto";
                        }
                    }
                }

                return _xError;
            }
        }
    }

    public partial class Familia_Produto_ClassesModel
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
