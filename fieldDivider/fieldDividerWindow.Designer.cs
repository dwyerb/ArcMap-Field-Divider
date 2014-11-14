namespace fieldDivider
{
    partial class fieldDividerWindow
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
            this.button1 = new System.Windows.Forms.Button();
            this.cmbFields = new System.Windows.Forms.ComboBox();
            this.txtDelimiter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Delimiter = new System.Windows.Forms.Label();
            this.btnValues = new System.Windows.Forms.Button();
            this.dgvColumns = new System.Windows.Forms.DataGridView();
            this.btnValidate = new System.Windows.Forms.Button();
            this.btnMakeFields = new System.Windows.Forms.Button();
            this.btnPopulate = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumns)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(113, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Get Layer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbFields
            // 
            this.cmbFields.FormattingEnabled = true;
            this.cmbFields.Location = new System.Drawing.Point(90, 71);
            this.cmbFields.Name = "cmbFields";
            this.cmbFields.Size = new System.Drawing.Size(121, 21);
            this.cmbFields.TabIndex = 1;
            // 
            // txtDelimiter
            // 
            this.txtDelimiter.Location = new System.Drawing.Point(88, 114);
            this.txtDelimiter.MaxLength = 1;
            this.txtDelimiter.Name = "txtDelimiter";
            this.txtDelimiter.Size = new System.Drawing.Size(124, 20);
            this.txtDelimiter.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(101, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Get Selected Layer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Select Field";
            // 
            // Delimiter
            // 
            this.Delimiter.AutoSize = true;
            this.Delimiter.Location = new System.Drawing.Point(88, 95);
            this.Delimiter.Name = "Delimiter";
            this.Delimiter.Size = new System.Drawing.Size(124, 13);
            this.Delimiter.TabIndex = 5;
            this.Delimiter.Text = "Enter Delimiter Character";
            // 
            // btnValues
            // 
            this.btnValues.Location = new System.Drawing.Point(113, 158);
            this.btnValues.Name = "btnValues";
            this.btnValues.Size = new System.Drawing.Size(75, 23);
            this.btnValues.TabIndex = 6;
            this.btnValues.Text = "Get Values";
            this.btnValues.UseVisualStyleBackColor = true;
            this.btnValues.UseWaitCursor = true;
            this.btnValues.Click += new System.EventHandler(this.btnValues_Click);
            // 
            // dgvColumns
            // 
            this.dgvColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColumns.Location = new System.Drawing.Point(3, 197);
            this.dgvColumns.Name = "dgvColumns";
            this.dgvColumns.Size = new System.Drawing.Size(294, 183);
            this.dgvColumns.TabIndex = 7;
            // 
            // btnValidate
            // 
            this.btnValidate.Location = new System.Drawing.Point(113, 414);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(75, 23);
            this.btnValidate.TabIndex = 8;
            this.btnValidate.Text = "Validate";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.btnCreateFields_Click);
            // 
            // btnMakeFields
            // 
            this.btnMakeFields.Enabled = false;
            this.btnMakeFields.Location = new System.Drawing.Point(113, 456);
            this.btnMakeFields.Name = "btnMakeFields";
            this.btnMakeFields.Size = new System.Drawing.Size(75, 23);
            this.btnMakeFields.TabIndex = 9;
            this.btnMakeFields.Text = "Make Fields";
            this.btnMakeFields.UseVisualStyleBackColor = true;
            this.btnMakeFields.Click += new System.EventHandler(this.btnMakeFields_Click);
            // 
            // btnPopulate
            // 
            this.btnPopulate.Enabled = false;
            this.btnPopulate.Location = new System.Drawing.Point(113, 501);
            this.btnPopulate.Name = "btnPopulate";
            this.btnPopulate.Size = new System.Drawing.Size(75, 23);
            this.btnPopulate.TabIndex = 10;
            this.btnPopulate.Text = "Populate Fields";
            this.btnPopulate.UseVisualStyleBackColor = true;
            this.btnPopulate.Click += new System.EventHandler(this.btnPopulate_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Get Values Using Delimiter";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(99, 395);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Validate Data Types";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(116, 440);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Create Fields";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(110, 485);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Calculate Fields";
            // 
            // fieldDividerWindow
            // 
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnPopulate);
            this.Controls.Add(this.btnMakeFields);
            this.Controls.Add(this.btnValidate);
            this.Controls.Add(this.dgvColumns);
            this.Controls.Add(this.btnValues);
            this.Controls.Add(this.Delimiter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDelimiter);
            this.Controls.Add(this.cmbFields);
            this.Controls.Add(this.button1);
            this.Name = "fieldDividerWindow";
            this.Size = new System.Drawing.Size(300, 552);
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumns)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbFields;
        private System.Windows.Forms.TextBox txtDelimiter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Delimiter;
        private System.Windows.Forms.Button btnValues;
        private System.Windows.Forms.DataGridView dgvColumns;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.Button btnMakeFields;
        private System.Windows.Forms.Button btnPopulate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;

    }
}
