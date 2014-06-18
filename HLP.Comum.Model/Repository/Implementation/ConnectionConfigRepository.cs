using HLP.Base.ClassesBases;
using HLP.Comum.Model.Repository.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Comum.Model.Repository.Implementation
{
    public class ConnectionConfigRepository : IConnectionConfigRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        public DataTable GetServer()
        {
            try
            {
                DataTable dt = new DataTable();
                DbProviderFactory dbProviderFactory = DbProviderFactories.GetFactory("System.Data.SqlClient");

                if (dbProviderFactory.CanCreateDataSourceEnumerator)
                {
                    DbDataSourceEnumerator dbDataSourceEnumerator = dbProviderFactory.CreateDataSourceEnumerator();

                    if (dbDataSourceEnumerator != null)
                    {
                        dt = dbDataSourceEnumerator.GetDataSources();
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetDatabases(string connectionString)
        {
            try
            {
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = connectionString;
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = new SqlCommand("SELECT name FROM sys.Databases", connection);
                da.Fill(ds, "sys.Databases");
                connection.Close();
                return ds;

            }
            catch (Exception)
            {
                return new DataSet();
            }
        }

        public bool TestConnection(string connectionString)
        {
            bool ret = false;
            SqlConnection connection = new SqlConnection();
            try
            {
                connection.ConnectionString = connectionString;
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                        ret = true;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return ret;
        }
    }
}
