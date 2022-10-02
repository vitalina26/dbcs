
namespace DBManager
{
    partial class CreateColumn
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.availableValuesLabel = new System.Windows.Forms.Label();
            this.availableValuesTextBox = new System.Windows.Forms.TextBox();
            this.columnNameTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.columnTypeComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Column name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Column type";
            // 
            // availableValuesLabel
            // 
            this.availableValuesLabel.AutoSize = true;
            this.availableValuesLabel.Location = new System.Drawing.Point(12, 132);
            this.availableValuesLabel.Name = "availableValuesLabel";
            this.availableValuesLabel.Size = new System.Drawing.Size(210, 15);
            this.availableValuesLabel.TabIndex = 2;
            this.availableValuesLabel.Text = "Available values(separated by comma)";
            this.availableValuesLabel.Visible = false;
            // 
            // availableValuesTextBox
            // 
            this.availableValuesTextBox.Location = new System.Drawing.Point(12, 150);
            this.availableValuesTextBox.Name = "availableValuesTextBox";
            this.availableValuesTextBox.Size = new System.Drawing.Size(428, 23);
            this.availableValuesTextBox.TabIndex = 3;
            this.availableValuesTextBox.Visible = false;
            // 
            // columnNameTextBox
            // 
            this.columnNameTextBox.Location = new System.Drawing.Point(12, 38);
            this.columnNameTextBox.Name = "columnNameTextBox";
            this.columnNameTextBox.Size = new System.Drawing.Size(428, 23);
            this.columnNameTextBox.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(318, 210);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 44);
            this.button1.TabIndex = 6;
            this.button1.Text = "Create";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Create);
            // 
            // columnTypeComboBox
            // 
            this.columnTypeComboBox.FormattingEnabled = true;
            this.columnTypeComboBox.Location = new System.Drawing.Point(12, 95);
            this.columnTypeComboBox.Name = "columnTypeComboBox";
            this.columnTypeComboBox.Size = new System.Drawing.Size(428, 23);
            this.columnTypeComboBox.TabIndex = 7;
            this.columnTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.columnTypeComboBox_SelectedIndexChanged);
            // 
            // CreateColumn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 266);
            this.Controls.Add(this.columnTypeComboBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.columnNameTextBox);
            this.Controls.Add(this.availableValuesTextBox);
            this.Controls.Add(this.availableValuesLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateColumn";
            this.Text = "Create column";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label availableValuesLabel;
        private System.Windows.Forms.TextBox availableValuesTextBox;
        private System.Windows.Forms.TextBox columnNameTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox columnTypeComboBox;
    }
}