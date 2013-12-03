using HLP.Entries.Model.Models.Gerais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Gerais
{
    public interface IFuncionario_Margem_Lucro_ComissaoRepository
    {
        void Save(Funcionario_Margem_Lucro_ComissaoModel objFuncionario_Margem_Lucro_Comissao);
        void Delete(Funcionario_Margem_Lucro_ComissaoModel objFuncionario_Margem_Lucro_Comissao);
        void Delete(int idFuncionario);
        void Copy(Funcionario_Margem_Lucro_ComissaoModel objFuncionario_Margem_Lucro_Comissao);
        Funcionario_Margem_Lucro_ComissaoModel GetFuncionario_Margem_Lucro_Comissao(int idFuncionarioMargemLucroComissao);
        List<Funcionario_Margem_Lucro_ComissaoModel> GetAllFuncionario_Margem_Lucro_Comissao(int idFuncionario);
    }
}
