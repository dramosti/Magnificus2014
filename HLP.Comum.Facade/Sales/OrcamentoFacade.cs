using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Comum.Facade.Sales
{
    public static class OrcamentoFacade
    {
        public static contato_Service.IserviceContatoClient contatoServico;
        public static cidadeService.IserviceCidadeClient cidadeService;
        public static ufService.IserviceUfClient ufService;
        public static Canal_VendaService.IserviceCanal_VendaClient canal_VendaService;
        public static Tipo_Documento_Oper_ValidaService.IserviceTipo_documento_Operacao_ValidaClient tipo_Documento_Oper_ValidaService;
        private static OrcamentoCadastros _objCadastros;
        public static OrcamentoCadastros objCadastros
        {
            get
            {
                return _objCadastros ?? new OrcamentoCadastros();
            }
            set
            {
                _objCadastros = value;
            }
        }
        public static produtoService.IserviceProdutoClient produtoService;
        public static Familia_ProdutoService.IserviceFamiliaProduto familiaProdutoService;
        public static Lista_PrecoService.IserviceLista_PrecoClient lista_PrecoService;
    }

    public class OrcamentoCadastros
    {
        public OrcamentoCadastros()
        {
            this.objContato = new contato_Service.ContatoModel();
            this.objListaPreco = new Lista_PrecoService.Lista_Preco_PaiModel();
            lProdutos = new List<produtoService.ProdutoModel>();
        }

        public contato_Service.ContatoModel objContato;
        public List<produtoService.ProdutoModel> lProdutos;
        public int idTipoOperacao;
        public Lista_PrecoService.Lista_Preco_PaiModel objListaPreco;

        #region NotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
