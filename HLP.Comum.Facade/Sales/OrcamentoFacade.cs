using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Comum.Facade.Sales
{
    public static class OrcamentoFacade
    {
        public static clienteService.IserviceClienteClient clienteServico = new clienteService.IserviceClienteClient();
        public static contatoService.IserviceContatoClient contatoServico = new contatoService.IserviceContatoClient();
        public static OrcamentoCadastros objCadastros = new OrcamentoCadastros();
    }

    public class OrcamentoCadastros
    {
        public OrcamentoCadastros()
        {
            this.objCliente = new clienteService.Cliente_fornecedorModel();
            this.objContato = new contatoService.ContatoModel();
        }

        public clienteService.Cliente_fornecedorModel objCliente;
        public contatoService.ContatoModel objContato;
    }
}
