using HLP.Entries.Model.Models.Transportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Transportes
{
    public interface ITransportadorReposiroty
    {
        void Save(TransportadorModel objTransportador);
        void Delete(TransportadorModel objTransportador);
        void Copy(TransportadorModel objTransportador);
        TransportadorModel GetTransportador(int idTransportador);

        void BeginTransaction();
        void CommitTransaction();
        void RollackTransaction();
    }
}
