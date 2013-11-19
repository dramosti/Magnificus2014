using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Entries.Model.Comercial;

namespace HLP.Entries.Model.Repository.Interfaces.Comercial
{
  public  interface ITipo_produtoRepository
    {
        Tipo_produtoModel GetTipo(int idTipoProduto);
        void Save(Tipo_produtoModel tipo);
        void Delete(int idTipoProduto);
        int Copy(int idTipoProduto);
    }
}
