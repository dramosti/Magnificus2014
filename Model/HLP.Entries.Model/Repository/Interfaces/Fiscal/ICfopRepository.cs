using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Entries.Model.Models.Fiscal;

namespace HLP.Entries.Model.Repository.Interfaces.Fiscal
{
    public interface ICfopRepository
    {
        CfopModel GetCfop(int idCfop);
        void Save(CfopModel cfop);
        void Delete(int idCfop);
        int Copy(int idCfop);
    }
}
