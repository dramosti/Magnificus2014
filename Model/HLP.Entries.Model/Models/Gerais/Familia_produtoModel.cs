using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Infrastructure;
using HLP.Comum.Model.Models;

namespace HLP.Entries.Model.Models.Gerais
{
    public partial class Familia_produtoModel : modelBase
    {
        public Familia_produtoModel() : base("Familia_produto") 
        {
            lFamilia_Produto_ClassesModel = new ObservableCollectionBaseCadastros<Familia_Produto_ClassesModel>();
        }



        private int? _idFamiliaProduto;
        [ParameterOrder(Order = 1)]
        public int? idFamiliaProduto
        {
            get { return _idFamiliaProduto; }
            set { _idFamiliaProduto = value; base.NotifyPropertyChanged("idFamiliaProduto"); }
        }
        [ParameterOrder(Order = 2)]
        public int idEmpresa { get; set; }
        [ParameterOrder(Order = 3)]
        public string xFamiliaProduto { get; set; }
        [ParameterOrder(Order = 4)]
        public string xDescricao { get; set; }
        [ParameterOrder(Order = 5)]
        public string xSigla { get; set; }
        [ParameterOrder(Order = 6)]
        public decimal pDescontoMaximo { get; set; }
        [ParameterOrder(Order = 7)]
        public decimal pAcressimoMaximo { get; set; }
        [ParameterOrder(Order = 8)]
        public decimal pComissaoAvista { get; set; }
        [ParameterOrder(Order = 9)]
        public decimal pComissaoAprazo { get; set; }
        [ParameterOrder(Order = 10)]
        public int? idContaContabil { get; set; }
        [ParameterOrder(Order = 11)]
        public int? idCentroCusto { get; set; }
        [ParameterOrder(Order = 12)]
        public int? idFamiliaProdutoBase { get; set; }
        [ParameterOrder(Order = 13)]
        public byte stGrau { get; set; }
        [ParameterOrder(Order = 14)]
        public byte stAlteraDescricaoComercialProdutoVenda { get; set; }

        private ObservableCollectionBaseCadastros<Familia_Produto_ClassesModel> _lFamilia_Produto_ClassesModel;
        public ObservableCollectionBaseCadastros<Familia_Produto_ClassesModel> lFamilia_Produto_ClassesModel
        {
            get { return _lFamilia_Produto_ClassesModel; }
            set { _lFamilia_Produto_ClassesModel = value; base.NotifyPropertyChanged("lFamilia_Produto_ClassesModel"); }
        }
    }


    public partial class Familia_Produto_ClassesModel : modelBase
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
                return base[columnName];
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
