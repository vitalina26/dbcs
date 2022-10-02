using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBManager
{
    public partial class CreateDatabaseDialog : Form
    {
        public string DatabaseName { get; set; } = "";
        public string Path { get; set; } = "";
        public CreateDatabaseDialog(string databaseName, string path)
        {
            InitializeComponent();
            pathTextBox.Text = Path = path;
            databaseNameTextBox.Text = DatabaseName = databaseName;
        }
        private void SelectDatabasePath(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Stream stream;
                if (( stream = saveFileDialog.OpenFile()) != null)
                {
                    stream.Close();
                    Path = saveFileDialog.FileName;
                    pathTextBox.Text = Path;
                }
            }
        }
        private void CreateDatabase(object sender, EventArgs e)
        {
            DatabaseName = databaseNameTextBox.Text;
        }
    }
}
