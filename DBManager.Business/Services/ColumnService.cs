using DBManager.Business.Interfaces;
using DBManager.Entities.Models;

namespace DBManager.Business.Services
{
    public class ColumnService : IColumnService
    {
        private readonly DBHelper _dBHelper = DBHelper.Instance;

        public Column GetColumnByIndex(string tableName, int columnIndex)
        {
            return _dBHelper.GetColumnByIndex(tableName, columnIndex);
        }
        public Column CreateColumn(string tableName, Column column)
        {
            return _dBHelper.CreateColumn(tableName, column);
        }
        public bool RenameColumn(string tableName, string oldName, string newName)
        {
            return _dBHelper.RenameColumn(tableName, oldName, newName);
        }
        public bool DeleteColumn(string tableName, int column)
        {
            return _dBHelper.DeleteColumn(tableName, column);
        }
    }
}
