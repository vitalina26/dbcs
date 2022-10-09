using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBManager.Entities.Enums;
using DBManager.Entities.Models;

namespace DBManager
{
    public partial class TablesDifference : Form
    {
        public Table Result { get; set; }
        private readonly DBManager _dBManager = DBManager.Instance;
        public TablesDifference()
        {
            InitializeComponent();
            var tablesNames = _dBManager.Database.Tables.Select(i => i.Name).ToArray();
            foreach (var value in tablesNames)
            {
                firstTableComboBox.Items.Add(value);
                secondTableComboBox.Items.Add(value);
            }
        }

        private void SearchDifference(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(firstTableComboBox.SelectedItem.ToString()) || string.IsNullOrEmpty(secondTableComboBox.SelectedItem.ToString()))
                return;
            var res = _dBManager.Difference(_dBManager.Database.Tables.FirstOrDefault(i => i.Name == firstTableComboBox.SelectedItem.ToString()),
                (_dBManager.Database.Tables.FirstOrDefault(i => i.Name == secondTableComboBox.SelectedItem.ToString())));
            RenderTable(res);
        }
        private void RenderTable(Table table)
        {
            ClearTable();
            if (table == null)
                return;
            foreach (var column in table.Columns)
            {
                if (column.Type == ColumnType.Enum)
                {
                    dataGridView1.Columns.Add(new DataGridViewComboBoxColumn() { Name = column.Name, HeaderText = $"{column.Name} ({column.Type})" });
                }
                else
                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = column.Name, HeaderText = $"{column.Name} ({column.Type})" });
            }
            foreach (var row in table.Rows)
            {
                var newRow = new DataGridViewRow();
                for (int i = 0; i < row.Values.Count; i++)
                {
                    if (table.Columns[i].Type == ColumnType.Enum)
                    {
                        var cell = new DataGridViewComboBoxCell();
                        foreach (var value in table.Columns[i].AvailableValues)
                        {
                            cell.Items.Add(value);
                        }
                        cell.Value = row.Values[i];
                        newRow.Cells.Add(cell);
                    }
                    else
                        newRow.Cells.Add(new DataGridViewTextBoxCell() { Value = row.Values[i] });
                }
                dataGridView1.Rows.Add(newRow);
            }
        }
        private void ClearTable()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
        }
    }
}
