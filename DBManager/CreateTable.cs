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
    public partial class CreateTable : Form
    {
        public string TableName { get; set; }
        public CreateTable(string tableName)
        {
            InitializeComponent();
            tableNameTextBox.Text = TableName = tableName;
        }
        private void Create(object sender, EventArgs e)
        {
            TableName = tableNameTextBox.Text;
        }
    }
}
