using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using DBManager.Entities.Enums;

namespace DBManager.Entities.Models
{
    public class Column
    {
        public Column(){}
        public Column(string name, ColumnType type, List<string> availableValues = null)
        {
            Name = name;
            Type = type;
            AvailableValues = availableValues ?? new List<string>();
        }
        public string Name { get; set; }
        public List<string> AvailableValues { get; set; }
        public ColumnType Type { get; set; }
        private const string EmailPattern = @"^[\d\w\._\-\+]+@([\d\w\._\-]+\.)+[\w]+$";
        public bool IsValid(string value)
        {
            return Type switch
            {
                ColumnType.Integer => Int32.TryParse(value, out _),
                ColumnType.Real => Double.TryParse(value, out _),
                ColumnType.Char => Char.TryParse(value, out _),
                ColumnType.String => true,
                ColumnType.Enum => (AvailableValues?.Contains(value) ?? false),
                ColumnType.Email => !string.IsNullOrEmpty(value) &&
                                    Regex.IsMatch(value, EmailPattern, RegexOptions.IgnoreCase),
                _ => false
            };
        }
    }
}
