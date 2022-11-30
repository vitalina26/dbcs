using System;
using System.Collections.Generic;
using DBManager.GrpcService;
using System.Text.RegularExpressions;

namespace DBManager.GrpcService
{
    public partial class Column
    {
        public Column(string name, ColumnType type)
        {
            Name = name;
            Type = type;
           
        }
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
                ColumnType.Integer => int.TryParse(value, out _),
                ColumnType.Real => double.TryParse(value, out _),
                ColumnType.Char => char.TryParse(value, out _),
                ColumnType.String => true,
                ColumnType.Htmlfile => value.ToLower().EndsWith(".html") && File.Exists(value),
                ColumnType.Stringintv => Column.ValidationofStringInvl(value),
                _ => false
            };
        }
    }
}
