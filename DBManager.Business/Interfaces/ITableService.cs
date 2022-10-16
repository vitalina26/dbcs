using DBManager.Entities.Models;

namespace DBManager.Business.Interfaces
{
    public interface ITableService
    {
        Table GetTableByName(string tableName);
        Table CreateTable(string tableName);
        bool RenameTable(string oldName, string newName);
        bool DeleteTable(string tableName);
        Table Difference(string firstTableName, string secondTableName);
    }
}
