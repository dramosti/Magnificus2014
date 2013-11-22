using HLP.Entries.Model.Models.Transportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Transportes
{
    public interface ICondicoes_entregaRepository
    {
        Condicoes_entregaModel GetCondicao(int idCondicaoEntrega);
        void Save(Condicoes_entregaModel condicao);
        void Delete(int idCondicaoEntrega);
        int Copy(int idCondicaoEntrega);
    }
}
