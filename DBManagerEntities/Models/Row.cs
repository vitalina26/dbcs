using System.Collections.Generic;

namespace DBManager.Entities.Models
{
    public class Row
    {
        public Row(){}
        public List<string> Values { get; set; } = new();
    }
}
