using DBManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            firstTableComboBox.Items.AddRange(tablesNames);
            secondTableComboBox.Items.AddRange(tablesNames);
        }

        private void SearchDifference(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(firstTableComboBox.SelectedItem.ToString()) || string.IsNullOrEmpty(secondTableComboBox.SelectedItem.ToString()))
                return;
            var res = _dBManager.Difference(_dBManager.Database.Tables.FirstOrDefault(i => i.Name == firstTableComboBox.SelectedItem.ToString()),
                (_dBManager.Database.Tables.FirstOrDefault(i => i.Name == secondTableComboBox.SelectedItem.ToString())));
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
                        cell.Items.AddRange(table.Columns[i].AvailableValues);
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
