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
    public partial class CreateColumn : Form
    {
        public string ColumnName { get; set; }
        public ColumnType ColumnType { get; set; }
        public List<string> AvailableValues { get; set; } = new List<string>();
        public CreateColumn(string columnName, ColumnType columnType, List<string> availablesValues)
        {
            InitializeComponent();
            columnNameTextBox.Text = ColumnName = columnName;
            columnTypeComboBox.Items.Clear();
            foreach (var type in Enum.GetNames(typeof(ColumnType)))
                columnTypeComboBox.Items.Add(type);
            columnTypeComboBox.SelectedItem = columnType.ToString();
            ColumnType = columnType;
            AvailableValues = availablesValues;
            availableValuesTextBox.Text = string.Join(',', availablesValues);
        }
        private void Create(object sender, EventArgs e)
        {
            ColumnName = columnNameTextBox.Text;
            ColumnType = (ColumnType)Enum.Parse(typeof(ColumnType), columnTypeComboBox.SelectedItem.ToString());
            AvailableValues = availableValuesTextBox.Text.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        private void columnTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var visibility = columnTypeComboBox.SelectedItem == ColumnType.Enum.ToString();
            availableValuesTextBox.Visible = visibility;
            availableValuesLabel.Visible = visibility;

        }
    }
}
