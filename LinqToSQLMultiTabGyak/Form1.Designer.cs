namespace LinqToSQLMultiTabGyak
{
    partial class Form1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txBxSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comBox = new System.Windows.Forms.ComboBox();
            this.dataSet = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.label2 = new System.Windows.Forms.Label();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chckBxLend = new System.Windows.Forms.CheckBox();
            this.chckBxForeignLang = new System.Windows.Forms.CheckBox();
            this.chckBxEbook = new System.Windows.Forms.CheckBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuStripHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripExport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripExportCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripExportPDF = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripExporAsTxt = new System.Windows.Forms.ToolStripMenuItem();
            this.btnInsUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 27);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1040, 319);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefresh.Location = new System.Drawing.Point(174, 352);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(98, 23);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Rács frissítése";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(959, 22);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Keresés";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txBxSearch
            // 
            this.txBxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txBxSearch.Location = new System.Drawing.Point(350, 19);
            this.txBxSearch.Name = "txBxSearch";
            this.txBxSearch.Size = new System.Drawing.Size(239, 20);
            this.txBxSearch.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(246, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Keresendő szöveg:";
            // 
            // comBox
            // 
            this.comBox.FormattingEnabled = true;
            this.comBox.Items.AddRange(new object[] {
            "Cím",
            "Szerző",
            "Műfaj",
            "Kiadó",
            "Kiadás éve",
            "ISBN",
            "Idegen nyelv",
            "E-book",
            "Kölcsönadott"});
            this.comBox.Location = new System.Drawing.Point(119, 19);
            this.comBox.Name = "comBox";
            this.comBox.Size = new System.Drawing.Size(121, 21);
            this.comBox.TabIndex = 5;
            this.comBox.Text = "Kérem válasszon!";
            // 
            // dataSet
            // 
            this.dataSet.DataSetName = "DataSetLibrary";
            this.dataSet.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1});
            // 
            // dataTable1
            // 
            this.dataTable1.TableName = "Table1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Keresett tulajdonság:";
            // 
            // btnInsert
            // 
            this.btnInsert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInsert.Location = new System.Drawing.Point(12, 352);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 23);
            this.btnInsert.TabIndex = 0;
            this.btnInsert.Text = "Hozzáad";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Location = new System.Drawing.Point(362, 352);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Törlés";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.chckBxLend);
            this.groupBox2.Controls.Add(this.chckBxForeignLang);
            this.groupBox2.Controls.Add(this.chckBxEbook);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.txBxSearch);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.comBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 381);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1043, 57);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Keresés";
            // 
            // chckBxLend
            // 
            this.chckBxLend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chckBxLend.AutoSize = true;
            this.chckBxLend.Location = new System.Drawing.Point(778, 21);
            this.chckBxLend.Name = "chckBxLend";
            this.chckBxLend.Size = new System.Drawing.Size(102, 17);
            this.chckBxLend.TabIndex = 9;
            this.chckBxLend.Text = "Kölcsön adtam?";
            this.chckBxLend.UseVisualStyleBackColor = true;
            // 
            // chckBxForeignLang
            // 
            this.chckBxForeignLang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chckBxForeignLang.AutoSize = true;
            this.chckBxForeignLang.Location = new System.Drawing.Point(673, 21);
            this.chckBxForeignLang.Name = "chckBxForeignLang";
            this.chckBxForeignLang.Size = new System.Drawing.Size(99, 17);
            this.chckBxForeignLang.TabIndex = 8;
            this.chckBxForeignLang.Text = "Idegen nyelvű?";
            this.chckBxForeignLang.UseVisualStyleBackColor = true;
            // 
            // chckBxEbook
            // 
            this.chckBxEbook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chckBxEbook.AutoSize = true;
            this.chckBxEbook.Location = new System.Drawing.Point(596, 22);
            this.chckBxEbook.Name = "chckBxEbook";
            this.chckBxEbook.Size = new System.Drawing.Size(71, 17);
            this.chckBxEbook.TabIndex = 7;
            this.chckBxEbook.Text = "E-könyv?";
            this.chckBxEbook.UseVisualStyleBackColor = true;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStripHelp,
            this.menuStripExport});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1064, 24);
            this.menuStrip.TabIndex = 10;
            this.menuStrip.Text = "menuStrip1";
            // 
            // menuStripHelp
            // 
            this.menuStripHelp.Name = "menuStripHelp";
            this.menuStripHelp.Size = new System.Drawing.Size(46, 20);
            this.menuStripHelp.Text = "Súgó";
            // 
            // menuStripExport
            // 
            this.menuStripExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStripExportCSV,
            this.menuStripExportPDF,
            this.menuStripExporAsTxt});
            this.menuStripExport.Name = "menuStripExport";
            this.menuStripExport.Size = new System.Drawing.Size(73, 20);
            this.menuStripExport.Text = "Exportálás";
            // 
            // menuStripExportCSV
            // 
            this.menuStripExportCSV.Name = "menuStripExportCSV";
            this.menuStripExportCSV.Size = new System.Drawing.Size(218, 22);
            this.menuStripExportCSV.Text = "Exportálás Excel-be (.csv)";
            this.menuStripExportCSV.Click += new System.EventHandler(this.menuStripExportCSV_Click);
            // 
            // menuStripExportPDF
            // 
            this.menuStripExportPDF.Name = "menuStripExportPDF";
            this.menuStripExportPDF.Size = new System.Drawing.Size(218, 22);
            this.menuStripExportPDF.Text = "Exportálás PDF-be (.pdf)";
            this.menuStripExportPDF.Click += new System.EventHandler(this.menuStripExportPDF_Click);
            // 
            // menuStripExporAsTxt
            // 
            this.menuStripExporAsTxt.Name = "menuStripExporAsTxt";
            this.menuStripExporAsTxt.Size = new System.Drawing.Size(218, 22);
            this.menuStripExporAsTxt.Text = "Exportálás szövegként (.txt)";
            this.menuStripExporAsTxt.Click += new System.EventHandler(this.menuStripExporAsTxt_Click);
            // 
            // btnInsUpdate
            // 
            this.btnInsUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInsUpdate.Location = new System.Drawing.Point(93, 352);
            this.btnInsUpdate.Name = "btnInsUpdate";
            this.btnInsUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnInsUpdate.TabIndex = 10;
            this.btnInsUpdate.Text = "Módosítás";
            this.btnInsUpdate.UseVisualStyleBackColor = true;
            this.btnInsUpdate.Click += new System.EventHandler(this.btnInsUpdate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 450);
            this.Controls.Add(this.btnInsUpdate);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.btnInsert);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txBxSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comBox;
        private System.Data.DataSet dataSet;
        private System.Data.DataTable dataTable1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chckBxLend;
        private System.Windows.Forms.CheckBox chckBxForeignLang;
        private System.Windows.Forms.CheckBox chckBxEbook;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuStripHelp;
        private System.Windows.Forms.ToolStripMenuItem menuStripExport;
        private System.Windows.Forms.ToolStripMenuItem menuStripExportCSV;
        private System.Windows.Forms.ToolStripMenuItem menuStripExportPDF;
        private System.Windows.Forms.ToolStripMenuItem menuStripExporAsTxt;
        private System.Windows.Forms.Button btnInsUpdate;
    }
}

