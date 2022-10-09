using DBManager.Entities.Models;

namespace DBManager.Business.Interfaces
{
    public interface IRowService
    {
        Row GetRowByIndex(string tableName, int rowIndex);
        Row CreateRow(string tableName);
        bool DeleteRow(string tableName, int row);
        bool EditCell(string tableName, int column, int row, string newValue);
    }
}
