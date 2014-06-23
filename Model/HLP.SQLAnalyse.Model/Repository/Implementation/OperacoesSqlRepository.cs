using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.SQLAnalyse.Model.Repository.Implementation
{
    public class OperacoesSqlRepository
    {
        public OperacoesSqlRepository()
        {
        }
        private SqlConnection conn;
        public void SetStringConnection(string sString)
        {
            conn = new SqlConnection(sString);
        }


        public DataTable GetTabelas()
        {
            DataTable dt = new DataTable();
            if (conn != null)
                try
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    // tras todas as tabelas do banco que esta conectado...
                    SqlDataAdapter adapter = new SqlDataAdapter("select * from INFORMATION_SCHEMA.Tables where TABLE_TYPE = 'BASE TABLE' order by TABLE_NAME", conn);
                    adapter.Fill(dt);
                }
                catch (SqlException se)
                {
                    throw new Exception(se.Message);
                }
                finally
                {
                    conn.Close();
                }
            return dt;

        }

        public List<TabelaModel> GetDetalhes(string sNomeTabela)
        {
            List<TabelaModel> _tabelasDetalhes = new List<TabelaModel>();
            if (conn != null)
                try
                {
                    DataTable dt = new DataTable();
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    SqlCommand command = new SqlCommand("sp_columns", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@table_name", sNomeTabela);

                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {

                        _tabelasDetalhes.Add(new TabelaModel
                        {
                            NomeTabela = row[2].ToString(),
                            TabelaOwner = row[1].ToString(),
                            NomeColuna = row[3].ToString(),
                            TipoColuna = row[5].ToString(),
                            Tamanho = row[7].ToString(),
                            CasasDecimais = row[8].ToString(),
                            Precisao = row[6].ToString(),
                            IsNullable = row[10].ToString()
                        });
                    }
                    dt.Dispose();

                }
                catch (SqlException se)
                {
                    throw new Exception(se.Message);
                }
                finally
                {
                    conn.Close();
                }
            return _tabelasDetalhes;
        }

        public DataTable GetListaTabFilha(string nmTabPai)
        {
            DataTable dt = new DataTable();
            if (conn != null)
                try
                {

                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT    OBJECT_NAME(constid) FK, OBJECT_NAME(FKEYID) Tabela_Filha, OBJECT_NAME(rKEYID) Tabela_Pai, COL_NAME(Rkeyid, Rkey) Colunas_Pai, COL_NAME(fkeyid, fkey) Colunas_Filha" +
                                                                " FROM    SYSFOREIGNKEYS where OBJECT_NAME(rKEYID) = '" + nmTabPai + "'", conn);
                    adapter.Fill(dt);
                }
                catch (SqlException se)
                {
                    throw new Exception(se.Message);
                }
                finally
                {
                    conn.Close();
                }
            return dt;
        }
    }
}
