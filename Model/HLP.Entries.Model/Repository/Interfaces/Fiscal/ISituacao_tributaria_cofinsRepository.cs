using HLP.Entries.Model.Models.Fiscal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Fiscal
{
    public interface ISituacao_tributaria_cofinsRepository
    {
        Situacao_tributaria_cofinsModel GetStCofins(int idCSTCofins);
        void Save(Situacao_tributaria_cofinsModel cofins);
        void Delete(int idCSTCofins);
        int Copy(int idCSTCofins);
    }
}
