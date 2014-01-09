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
        public static clienteService.IserviceClienteClient clienteServico;
        public static contato_Service.IserviceContatoClient contatoServico;
        public static cidadeService.IserviceCidadeClient cidadeService;
        public static ufService.IserviceUfClient ufService;
        public static Canal_VendaService.IserviceCanal_VendaClient canal_VendaService;
        public static Tipo_Documento_Oper_ValidaService.IserviceTipo_documento_Operacao_ValidaClient tipo_Documento_Oper_ValidaService;
        public static OrcamentoCadastros objCadastros;
        public static produtoService.IserviceProdutoClient produtoService;
        public static Familia_ProdutoService.IserviceFamiliaProduto familiaProdutoService;
        public static Lista_PrecoService.IserviceLista_PrecoClient lista_PrecoService;
    }

    public class OrcamentoCadastros
    {
        public OrcamentoCadastros()
        {
            this.objCliente = new clienteService.Cliente_fornecedorModel();
            this.objContato = new contato_Service.ContatoModel();
            lProdutos = new List<produtoService.ProdutoModel>();
        }

        
        private clienteService.Cliente_fornecedorModel _objCliente;

        public clienteService.Cliente_fornecedorModel objCliente
        {
            get { return _objCliente; }
            set
            {
                _objCliente = value;
                this.NotifyPropertyChanged(propertyName: "objCliente");
            }
        }        

        public contato_Service.ContatoModel objContato;
        public List<produtoService.ProdutoModel> lProdutos;
        public int idTipoOperacao;

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
