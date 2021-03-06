﻿using HLP.Entries.Model.Models.Comercial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Comercial
{
    public interface IProdutoRepository
    {
        List<ProdutoModel> GetByProdutoType(int idTipoProduto);
        ProdutoModel GetProduto(int idProduto);
        List<ProdutoModel> GetAll();
        void Save(ProdutoModel produto);
        void Delete(int idProduto);
        void Copy(ProdutoModel produto);
        object GetStCustoProduto(int idProduto);
        decimal? GetValorCompraProduto(int idProduto);

        void BeginTransaction();
        void CommitTransaction();
        void RollackTransaction();
    }
}
