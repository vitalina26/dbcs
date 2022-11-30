using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using DBManager.Entities.Enums;
using System.IO;

namespace DBManager.Entities.Models
{
    public class Column
    {
        public Column(){}
        public Column(string name, ColumnType type)
        {
            Name = name;
            Type = type;
           
        }
        public string Name { get; set; }
        public ColumnType Type { get; set; }
    

        static public bool ValidationofStringInvl(string v)
        {
            string[] t = v.Replace(" ", "").Split(',');
            if (t.Length == 2 && String.Compare(t[1], t[2]) > 0)
                return true;
            else
                return false;
        }

        public bool IsValid(string value)
        {
            return Type switch
            {
                ColumnType.Integer => Int32.TryParse(value, out _),
                ColumnType.Real => Double.TryParse(value, out _),
                ColumnType.Char => Char.TryParse(value, out _),
                ColumnType.String => true,
                ColumnType.HtmlFile => value.ToLower().EndsWith(".html") && File.Exists(value),
                ColumnType.StringInvl => Column.ValidationofStringInvl(value),
                _ => false
            };
        }
    }
}
