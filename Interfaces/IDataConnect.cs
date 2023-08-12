using System.Data;

namespace ExpenseTrackerAPI.Interfaces
{
    public interface IDataConnect
    {
        IDbConnection GetSQLDataConnection();
        void Close(IDbConnection conn);

    }
}
