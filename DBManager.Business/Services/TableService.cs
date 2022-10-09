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
        public bool DeleteTable(string tableName)
        {
            return _dBHelper.DeleteTable(tableName);
        }
        public Table Difference(string firstTableName, string secondTableName)
        {
            return _dBHelper.Difference(firstTableName, secondTableName);
        }
    }
}
