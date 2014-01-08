using System;
using System.Collections.Generic;
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
    }

    public class OrcamentoCadastros
    {
        public OrcamentoCadastros()
        {
            this.objCliente = new clienteService.Cliente_fornecedorModel();
            this.objContato = new contato_Service.ContatoModel();
        }

        public clienteService.Cliente_fornecedorModel objCliente;
        public contato_Service.ContatoModel objContato;
        public int idTipoOperacao;
    }
}
