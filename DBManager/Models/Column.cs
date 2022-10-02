using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DBManager.Models
{
    public class Column
    {
        public Column(string name, ColumnType type, List<string> availableValues = null)
        {
            Name = name;
            Type = type;
            AvailableValues = availableValues ?? new List<string>();
        }
        public string Name { get; set; }
        public List<string> AvailableValues { get; set; } = new List<string>();
        public ColumnType Type { get; set; }
        private const string _emailPattern = @"^[\d\w\._\-\+]+@([\d\w\._\-]+\.)+[\w]+$";
        public bool IsValid(string value)
        {
            switch (Type)
            {
                case ColumnType.Integer:
                    return Int32.TryParse(value, out _);
                case ColumnType.Real:
                    return Double.TryParse(value, out _);
                case ColumnType.Char:
                    return Char.TryParse(value, out _);
                case ColumnType.String:
                    return true;
                case ColumnType.Enum:
                    return (AvailableValues?.Contains(value) ?? false);
                case ColumnType.Email:
                    return !string.IsNullOrEmpty(value) && Regex.IsMatch(value, _emailPattern, RegexOptions.IgnoreCase);
                default:
                    return false;
            }
        }
    }
}
