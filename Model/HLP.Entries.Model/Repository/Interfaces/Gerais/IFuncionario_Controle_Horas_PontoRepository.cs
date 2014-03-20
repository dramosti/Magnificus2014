using HLP.Entries.Model.Models.Gerais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Gerais
{
    public interface IFuncionario_Controle_Horas_PontoRepository
    {
        void Save(Funcionario_Controle_Horas_PontoModel objFuncionario_Controle_Horas_Ponto);
        void Delete(int idFuncionarioControleHorasPonto);
        void DeleteByFuncionario(int idFuncionario);
        Funcionario_Controle_Horas_PontoModel GetFuncionario_Controle_Horas_Ponto(int idFuncionarioControleHorasPonto);
        List<Funcionario_Controle_Horas_PontoModel> GetAllFuncionario_Controle_Horas_Ponto(int idFuncionario, DateTime data);
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
