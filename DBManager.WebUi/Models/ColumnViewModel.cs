using System.Collections.Generic;

namespace DBManager.WebUi.Models
{
    public class ColumnViewModel
    {
        public ColumnViewModel(){}
        public ColumnViewModel(string name, ColumnType type)
        {
            Name = name;
            Type = type;
           
        }
        public string Name { get; set; }
        
        public ColumnType Type { get; set; }
    }
}