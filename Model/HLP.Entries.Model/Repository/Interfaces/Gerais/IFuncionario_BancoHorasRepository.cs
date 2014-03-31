using HLP.Entries.Model.Models.Gerais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Gerais
{
    public interface IFuncionario_BancoHorasRepository
    {
        TimeSpan GetTotalBancoHoras(int idFuncionario, DateTime dtMes);
        TimeSpan? GetTotalBancoHorasMesAtual(int idFuncionario, DateTime dtMes);
        void Save(Funcionario_BancoHorasModel objFuncionario_BancoHoras);
        void DeleteBancoHorasMes(int idFuncionario, DateTime dtMes);
    }
}
