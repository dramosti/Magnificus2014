using HLP.Entries.Model.Models.Gerais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Gerais
{
    public interface IFuncionario_Comissao_ProdutoRepository
    {
        void Save(Funcionario_Comissao_ProdutoModel objFuncionario_Comissao_Produto);
        void Delete(Funcionario_Comissao_ProdutoModel objFuncionario_Comissao_Produto);
        void Delete(int idFuncionario);
        void Copy(Funcionario_Comissao_ProdutoModel objFuncionario_Comissao_Produto);
        Funcionario_Comissao_ProdutoModel GetFuncionario_Comissao_Produto(int idFuncionarioComissaoProduto);
        List<Funcionario_Comissao_ProdutoModel> GetAllFuncionario_Comissao_Produto(int idFuncionario);
    }
}
