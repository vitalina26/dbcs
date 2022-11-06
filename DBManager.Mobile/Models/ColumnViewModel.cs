namespace DBManager.Mobile.Models
{
    public class ColumnViewModel
    {
        public ColumnViewModel(){}
        public ColumnViewModel(string name, ColumnType type, List<string> availableValues = null)
        {
            Name = name;
            Type = type;
            AvailableValues = availableValues ?? new List<string>();
        }
        public string Name { get; set; }
        public List<string> AvailableValues { get; set; }
        public ColumnType Type { get; set; }
    }
}