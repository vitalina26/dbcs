using DBManager.Entities.Models;

namespace DBManager.Business.Interfaces
{
    public interface IColumnService
    {
        Column GetColumnByIndex(string tableName, int columnIndex);
        Column CreateColumn(string tableName, Column column);
        bool RenameColumn(string tableName, string oldName, string newName);
        bool DeleteColumn(string tableName, int column);
    }
}
