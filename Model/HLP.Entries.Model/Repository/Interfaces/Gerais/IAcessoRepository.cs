using HLP.Entries.Model.Models.Gerais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Gerais
{
    public interface IAcessoRepository
    {
        void Save(Funcionario_AcessoModel objAcesso);
        void Delete(int idAcesso);
        void Delete(Funcionario_AcessoModel objAcesso);
        int Copy(Funcionario_AcessoModel objFuncionario_Acesso);
        Funcionario_AcessoModel GetAcesso(int idAcesso);
        List<Funcionario_AcessoModel> GetAllAcesso();
        List<Funcionario_AcessoModel> GetAllAcesso_Funcionario(int idFuncionario);
    }
}
