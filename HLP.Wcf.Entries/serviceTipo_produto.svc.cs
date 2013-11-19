using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HLP.Entries.Model.Comercial;
using HLP.Entries.Model.Repository.Interfaces.Comercial;
using Ninject;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceTipo_produto" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceTipo_produto.svc or serviceTipo_produto.svc.cs at the Solution Explorer and start debugging.
    public class serviceTipo_produto : IserviceTipo_produto
    {
        [Inject]
        public ITipo_produtoRepository iTipo_produtoRepository { get; set; }

        public Tipo_produtoModel GetTipo(int idTipoProduto)
        {
            return iTipo_produtoRepository.GetTipo(idTipoProduto);
        }

        public void Save(Tipo_produtoModel tipo)
        {
            iTipo_produtoRepository.Save(tipo);
        }

        public void Delete(int idTipoProduto)
        {
            iTipo_produtoRepository.Delete(idTipoProduto);
        }

        public int Copy(int idTipoProduto)
        {
           return iTipo_produtoRepository.Copy(idTipoProduto);
        }
    }
}
