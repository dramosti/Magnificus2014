using HLP.Entries.Model.Models.Gerais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Gerais
{
    public interface IFuncionario_ArquivoRepository
    {
        void Save(Funcionario_ArquivoModel objFuncionario_Arquivo);
        void Delete(Funcionario_ArquivoModel objFuncionario_Arquivo);
        void Delete(int idFuncionario);
        void Copy(Funcionario_ArquivoModel objFuncionario_Arquivo);
        Funcionario_ArquivoModel GetFuncionario_Arquivo(int idFuncionarioArquivo);
        List<Funcionario_ArquivoModel> GetAllFuncionario_Arquivo(int idFuncionario);
    }
}
