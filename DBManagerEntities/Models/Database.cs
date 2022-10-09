using System.Collections.Generic;

namespace DBManager.Entities.Models
{
    public class Database
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public List<Table> Tables { get; set; } = new();
        public Database (string name, string path)
        {
            Name = name;
            Path = path;
        }
        public Database(){}
        public Database (Database database)
        {
            Name = database.Name;
            Path = database.Path;
        }
    }
}
