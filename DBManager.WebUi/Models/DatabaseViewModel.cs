using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DBManager.WebUi.Models
{
    public class DatabaseViewModel
    {
        [Required(ErrorMessage = "Name cannot be empty")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Path cannot be empty")]
        public string Path { get; set; }
        public List<TableViewModel> Tables { get; set; } = new();
        public DatabaseViewModel(){}
        public DatabaseViewModel (string name, string path)
        {
            Name = name;
            Path = path;
        }
    }
}