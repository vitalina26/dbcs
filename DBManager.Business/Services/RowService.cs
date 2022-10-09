using DBManager.Business.Interfaces;
using DBManager.Entities.Models;

namespace DBManager.Business.Services
{
    public class RowService : IRowService
    {
        private readonly DBHelper _dBHelper = DBHelper.Instance;

        public Row GetRowByIndex(string tableName, int rowIndex)
        {
            return _dBHelper.GetRowByIndex(tableName, rowIndex);
        }
        public Row CreateRow(string tableName)
        {
            return _dBHelper.CreateRow(tableName);
        }
        public bool DeleteRow(string tableName, int row)
        {
            return _dBHelper.DeleteRow(tableName, row);
        }
        public bool EditCell(string tableName, int column, int row, string newValue)
        {
            return _dBHelper.EditCell(tableName, column, row, newValue);
        }
    }
}
