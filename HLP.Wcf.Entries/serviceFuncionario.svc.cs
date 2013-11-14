using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.Model.Repository.Interfaces.Gerais;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceFuncionario" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceFuncionario.svc or serviceFuncionario.svc.cs at the Solution Explorer and start debugging.
    public class serviceFuncionario : IserviceFuncionario
    {
        [Inject]
        public IFuncionarioRepository funcionarioRepository { get; set; }

        [Inject]
        public IFuncionario_ArquivoRepository funcionario_ArquivoRepository { get; set; }

        [Inject]
        public IFuncionario_CertificacaoRepository funcionario_CertificacaoRepository { get; set; }

        [Inject]
        public IFuncionario_Comissao_ProdutoRepository funcionario_Comissao_ProdutoRepository { get; set; }

        [Inject]
        public IFuncionario_EnderecoRepository funcionario_EnderecoRepository { get; set; }

        [Inject]
        public IFuncionario_Margem_Lucro_ComissaoRepository funcionario_Margem_Lucro_ComissaoRepository { get; set; }

        public serviceFuncionario()
        {
        }

        public FuncionarioModel getFuncionario(int idFuncionario)
        {
            throw new NotImplementedException();
        }

        public int saveFuncionario(FuncionarioModel objFuncionario)
        {
            throw new NotImplementedException();
        }

        public bool deleteFuncionario(int idFuncionario)
        {
            throw new NotImplementedException();
        }

        public int copyFuncionario(int idFuncionario)
        {
            throw new NotImplementedException();
        }
    }
}
