using System.Collections.Generic;
using DBManager.Entities.Models;

namespace DBManager.Business.Interfaces
{
    public interface IDatabaseService
    {
        List<Database> GetAllDatabases();
        Database GetDatabaseByPath(string databasePath);
        Database GetCurrentDatabase();
        Database OpenDatabase(string path);
        Database CreateDatabase(Database database);
        bool SaveDatabase();
        bool DeleteDataBase();
        bool DeleteDatabaseByPath(string databasePath);
    }
}
