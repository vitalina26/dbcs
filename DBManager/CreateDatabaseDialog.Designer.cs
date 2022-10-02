
namespace DBManager
{
    partial class CreateDatabaseDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.databaseNameLabel = new System.Windows.Forms.Label();
            this.pathToSaveLabel = new System.Windows.Forms.Label();
            this.databaseNameTextBox = new System.Windows.Forms.TextBox();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.selectPathButton = new System.Windows.Forms.Button();
            this.createButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // databaseNameLabel
            // 
            this.databaseNameLabel.AutoSize = true;
            this.databaseNameLabel.Location = new System.Drawing.Point(12, 9);
            this.databaseNameLabel.Name = "databaseNameLabel";
            this.databaseNameLabel.Size = new System.Drawing.Size(88, 15);
            this.databaseNameLabel.TabIndex = 0;
            this.databaseNameLabel.Text = "Database name";
            // 
            // pathToSaveLabel
            // 
            this.pathToSaveLabel.AutoSize = true;
            this.pathToSaveLabel.Location = new System.Drawing.Point(12, 92);
            this.pathToSaveLabel.Name = "pathToSaveLabel";
            this.pathToSaveLabel.Size = new System.Drawing.Size(71, 15);
            this.pathToSaveLabel.TabIndex = 1;
            this.pathToSaveLabel.Text = "Path to save";
            // 
            // databaseNameTextBox
            // 
            this.databaseNameTextBox.Location = new System.Drawing.Point(12, 39);
            this.databaseNameTextBox.Name = "databaseNameTextBox";
            this.databaseNameTextBox.Size = new System.Drawing.Size(418, 23);
            this.databaseNameTextBox.TabIndex = 2;
            // 
            // pathTextBox
            // 
            this.pathTextBox.Enabled = false;
            this.pathTextBox.Location = new System.Drawing.Point(12, 124);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(386, 23);
            this.pathTextBox.TabIndex = 3;
            // 
            // selectPathButton
            // 
            this.selectPathButton.Location = new System.Drawing.Point(404, 124);
            this.selectPathButton.Name = "selectPathButton";
            this.selectPathButton.Size = new System.Drawing.Size(26, 23);
            this.selectPathButton.TabIndex = 4;
            this.selectPathButton.Text = "...";
            this.selectPathButton.UseVisualStyleBackColor = true;
            this.selectPathButton.Click += new System.EventHandler(this.SelectDatabasePath);
            // 
            // createButton
            // 
            this.createButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.createButton.Location = new System.Drawing.Point(313, 189);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(117, 38);
            this.createButton.TabIndex = 5;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.CreateDatabase);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileName = "database.txt";
            // 
            // CreateDatabaseDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 239);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.selectPathButton);
            this.Controls.Add(this.pathTextBox);
            this.Controls.Add(this.databaseNameTextBox);
            this.Controls.Add(this.pathToSaveLabel);
            this.Controls.Add(this.databaseNameLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateDatabaseDialog";
            this.Text = "Create database";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label databaseNameLabel;
        private System.Windows.Forms.Label pathToSaveLabel;
        private System.Windows.Forms.TextBox databaseNameTextBox;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.Button selectPathButton;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}