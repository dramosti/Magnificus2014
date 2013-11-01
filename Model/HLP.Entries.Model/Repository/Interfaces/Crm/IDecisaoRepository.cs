using HLP.Entries.Model.Models.Crm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Crm
{
    public interface IDecisaoRepository
    {
        DecisaoModel GetDecisao(int idDecisao);
        void Save(DecisaoModel decisao);
        void Delete(int idDecisao);
        int Copy(int idDecisao);
    }
}
