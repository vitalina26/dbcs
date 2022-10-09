using System.Collections.Generic;

namespace DBManager.Entities.Models
{
    public class Table
    {
        public Table(){}
        public string Name { get; set; }
        public List<Column> Columns { get; set; } = new();
        public List<Row> Rows { get; set; } = new();
        public Table(string name)
        {
            Name = name;
        }
    }
}
