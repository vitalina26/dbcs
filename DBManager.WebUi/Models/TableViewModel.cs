using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DBManager.WebUi.Models
{
    public class TableViewModel
    {
        [Required(ErrorMessage = "Name cannot be empty")]
        public string Name { get; set; }
        public List<ColumnViewModel> Columns { get; set; } = new();
        public List<RowViewModel> Rows { get; set; } = new();
        public TableViewModel(){}
        public TableViewModel(string name)
        {
            Name = name;
        }
    }
}