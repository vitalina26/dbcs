using DBManager.Business.Interfaces;
using DBManager.Entities.Models;

namespace DBManager.Business.Services
{
    public class TableService : ITableService
    {
        private readonly DBHelper _dBHelper = DBHelper.Instance;

        public Table GetTableByName(string tableName)
        {
            return _dBHelper.GetTableByName(tableName);
        }
        public Table CreateTable(string tableName)
        {
            return _dBHelper.CreateTable(tableName);
        }
        public bool RenameTable(string oldName, string newName)
        {
            return _dBHelper.RenameTable(oldName, newName);
        }
        public bool DeleteTable(string tableName)
        {
            return _dBHelper.DeleteTable(tableName);
        }
        public Table Difference(string firstTableName, string secondTableName)
        {
            return _dBHelper.Union(firstTableName, secondTableName);
        }
    }
}
