using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Comum.Resources.RecursosBases
{
    public enum OperacaoCadastro
    {
        livre,
        criando,
        alterando,
        pesquisando
    }

    public enum statusModel
    {
        nenhum,
        criado,
        alterado,
        excluido
    }

    #region Enum to DataGrid

    public enum SEXO { FEMININO, MASCULINO };

    public enum TipoEndereco
    {
        [Description("0-COMERCIAL")]
        COMERCIAL,
        [Description("1-ENTREGA")]
        ENTREGA,
        [Description("2-ENTREGA ALT")]
        ENTREGA_ALT,
        [Description("3-NOTA FISCAL")]
        NOTA_FISCAL,
        [Description("4-RESIDÊNCIA")]
        RESIDÊNCIA,
        [Description("5-SERVIÇO")]
        SERVICO,
        [Description("6-SWIFT")]
        SWIFT,
        [Description("7-PAGAMENTO")]
        PAGAMENTO,
        [Description("9-OUTRO")]
        OUTRO
    };

    public enum TipoCertificacao
    {
        [Description("0-ENSINO MÉDIO")]
        ENSINOMEDIO,
        [Description("1-ENSINO SUPERIOR")]
        ENSINOSUPERIOR,
        [Description("2-MBA/PÓS-GRADUAÇÃO")]
        MBAPOSGRADUACAO,
        [Description("3-MESTRADO")]
        MESTRADO,
        [Description("4-DOUTORADO")]
        DOUTORADO,
        [Description("5-PÓS-DOUTORADO")]
        POSDOUTORADO,
        [Description("6-CURSOS COMPLEMENTARES")]
        CURSOSCOMPLEMENTARES,
        [Description("7-OUTROS")]
        OUTROS
    }

    public enum TipoComissao
    {
        [Description("0-Por Representante (Default)")]
        REPRESENTANTE,
        [Description("1-Por Lista de Preço")]
        LISTAPREDEPRECO,
        [Description("2-Por Família de Produto")]
        FAMILIAPRODUTO,
        [Description("3-Por Produto")]
        PRODUTO,
        [Description("4-Por Faixa Margem de Venda")]
        FAIXAMARGEMVENDA
    }
    #endregion
}
