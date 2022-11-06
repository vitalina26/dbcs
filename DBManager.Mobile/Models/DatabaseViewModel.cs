using System.ComponentModel.DataAnnotations;

namespace DBManager.Mobile.Models
{
    public class DatabaseViewModel
    {
        [Required(ErrorMessage = "Name cannot be empty")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Path cannot be empty")]
        [RegularExpression(@"^.*\.(txt)$", ErrorMessage = "Incorrect format")]

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