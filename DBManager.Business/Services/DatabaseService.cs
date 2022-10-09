using DBManager.Business.Interfaces;
using System.Collections.Generic;
using System.Linq;
using DBManager.Entities.Models;

namespace DBManager.Business.Services
{
    public class DatabaseService : IDatabaseService
    {
        private readonly DBHelper _dBHelper = DBHelper.Instance;
        public List<Database> GetAllDatabases()
        {
            return _dBHelper.GetAllDatabases();
        }
        public Database GetDatabaseByPath(string databasePath)
        {
            var databases = GetAllDatabases();
            return databases.FirstOrDefault(i => i.Path == databasePath);
        }
        public Database GetCurrentDatabase()
        {
            return _dBHelper.Database;
        }
        public Database OpenDatabase(string path)
        {
            return _dBHelper.OpenDatabase(path);
        }
        public Database CreateDatabase(Database database)
        {
            return _dBHelper.CreateDatabase(database);
        }
        public bool SaveDatabase()
        {
            return _dBHelper.SaveDatabase();
        }
        public bool DeleteDataBase()
        {
            return _dBHelper.DeleteDataBase();
        }
        public bool DeleteDatabaseByPath(string databasePath)
        {
            return _dBHelper.DeleteDataBase();
        }
    }
}
