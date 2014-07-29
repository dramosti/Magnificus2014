using HLP.Base.ClassesBases;
using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.Parametros
{
    public partial class Parametro_EstoqueModel : modelComum
    {
        public Parametro_EstoqueModel()
            : base(xTabela: "Parametro_Estoque")
        {
        }
        [ParameterOrder(Order = 1)]
        public int idEmpresa { get; set; }
        [ParameterOrder(Order = 2), PrimaryKey(isPrimary = true)]
        public int? idParametroEstoque { get; set; }
        [ParameterOrder(Order = 3)]
        public byte stEstoqueMinimo { get; set; }
        [ParameterOrder(Order = 4)]
        public byte stEstoqueMaximo { get; set; }
        [ParameterOrder(Order = 5)]
        public byte stMediaConsumo { get; set; }
        [ParameterOrder(Order = 6)]
        public byte stVendasGera { get; set; }
        [ParameterOrder(Order = 7)]
        public byte stGradeEstoque { get; set; }
        [ParameterOrder(Order = 8)]
        public byte stRastreabilidadeMaterial { get; set; }
        [ParameterOrder(Order = 9)]
        public byte stRastreabilidadeProdutoAcabado { get; set; }
        private string _xMascaraFamiliaProduto;
        [ParameterOrder(Order = 10)]
        public string xMascaraFamiliaProduto
        {
            get { return _xMascaraFamiliaProduto; }
            set
            {
                _xMascaraFamiliaProduto = value;
                base.NotifyPropertyChanged(propertyName: "xMascaraFamiliaProduto");
            }
        }
    }

    public partial class Parametro_EstoqueModel
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
