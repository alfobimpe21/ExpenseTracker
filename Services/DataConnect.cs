using ExpenseTrackerAPI.Interfaces;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;

namespace ExpenseTrackerAPI.Services
{
    public class DataConnect : IDataConnect
    {
        ILogger<DataConnect> _logger;
        ConnectionStrings _connectionStrings;

        public DataConnect(IOptions<ConnectionStrings> connectionStrings, ILogger<DataConnect> logger)
        {
            _connectionStrings = connectionStrings.Value;
            _logger = logger;
        }
        public IDbConnection GetSQLDataConnection()
        {
            SqlConnection? conn = null;
            try
            {
                conn = new SqlConnection(_connectionStrings.CertifiedPayDB);
                conn.Open();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return conn!;
        }

        public void Close(IDbConnection conn)
        {
            try
            {
                if (conn != null)
                    conn.Close();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }
    public class ConnectionStrings
    {
        public string? CertifiedPayDB { get; set; }

    }
}
