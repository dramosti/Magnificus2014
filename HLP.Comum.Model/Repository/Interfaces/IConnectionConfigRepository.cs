using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Comum.Model.Repository.Interfaces
{
    public interface IConnectionConfigRepository
    {
        DataTable GetServer();

        DataSet GetDatabases(string connectionString);

        bool TestConnection(string connectionString);
    }
}
