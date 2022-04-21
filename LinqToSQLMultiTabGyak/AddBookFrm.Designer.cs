namespace LinqToSQLMultiTabGyak
{
    partial class AddBookFrm
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.chckBxForeignLang = new System.Windows.Forms.CheckBox();
            this.chckBxEbook = new System.Windows.Forms.CheckBox();
            this.chckBxLend = new System.Windows.Forms.CheckBox();
            this.btnAddFromWindow = new System.Windows.Forms.Button();
            this.btnCancelWindow = new System.Windows.Forms.Button();
            this.txBxAddPubDate = new System.Windows.Forms.TextBox();
            this.txBxAddTitle = new System.Windows.Forms.TextBox();
            this.txBxAddAuthor = new System.Windows.Forms.TextBox();
            this.txBxAddPublisher = new System.Windows.Forms.TextBox();
            this.txBxAddGenre = new System.Windows.Forms.TextBox();
            this.txBxAddISBN = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cím:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Szerző:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Kiadó:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Kiadás éve:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(188, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Műfaj:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "ISBN:";
            // 
            // chckBxForeignLang
            // 
            this.chckBxForeignLang.AutoSize = true;
            this.chckBxForeignLang.Location = new System.Drawing.Point(82, 144);
            this.chckBxForeignLang.Name = "chckBxForeignLang";
            this.chckBxForeignLang.Size = new System.Drawing.Size(93, 17);
            this.chckBxForeignLang.TabIndex = 6;
            this.chckBxForeignLang.Text = "Idegen nyelvű";
            this.chckBxForeignLang.UseVisualStyleBackColor = true;
            // 
            // chckBxEbook
            // 
            this.chckBxEbook.AutoSize = true;
            this.chckBxEbook.Location = new System.Drawing.Point(180, 144);
            this.chckBxEbook.Name = "chckBxEbook";
            this.chckBxEbook.Size = new System.Drawing.Size(60, 17);
            this.chckBxEbook.TabIndex = 7;
            this.chckBxEbook.Text = "E-book";
            this.chckBxEbook.UseVisualStyleBackColor = true;
            // 
            // chckBxLend
            // 
            this.chckBxLend.AutoSize = true;
            this.chckBxLend.Location = new System.Drawing.Point(246, 144);
            this.chckBxLend.Name = "chckBxLend";
            this.chckBxLend.Size = new System.Drawing.Size(91, 17);
            this.chckBxLend.TabIndex = 8;
            this.chckBxLend.Text = "Kölcsön adva";
            this.chckBxLend.UseVisualStyleBackColor = true;
            // 
            // btnAddFromWindow
            // 
            this.btnAddFromWindow.Image = global::LinqToSQLMultiTabGyak.Properties.Resources.ikon_add;
            this.btnAddFromWindow.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddFromWindow.Location = new System.Drawing.Point(60, 234);
            this.btnAddFromWindow.Name = "btnAddFromWindow";
            this.btnAddFromWindow.Size = new System.Drawing.Size(220, 35);
            this.btnAddFromWindow.TabIndex = 9;
            this.btnAddFromWindow.Text = "Hozzáadás";
            this.btnAddFromWindow.UseVisualStyleBackColor = true;
            this.btnAddFromWindow.Click += new System.EventHandler(this.btnAddFromWindow_Click);
            // 
            // btnCancelWindow
            // 
            this.btnCancelWindow.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelWindow.Image = global::LinqToSQLMultiTabGyak.Properties.Resources.ikon_delete;
            this.btnCancelWindow.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelWindow.Location = new System.Drawing.Point(300, 234);
            this.btnCancelWindow.Name = "btnCancelWindow";
            this.btnCancelWindow.Size = new System.Drawing.Size(110, 35);
            this.btnCancelWindow.TabIndex = 10;
            this.btnCancelWindow.Text = "Mégse";
            this.btnCancelWindow.UseVisualStyleBackColor = true;
            this.btnCancelWindow.Click += new System.EventHandler(this.btnCancelWindow_Click);
            // 
            // txBxAddPubDate
            // 
            this.txBxAddPubDate.Location = new System.Drawing.Point(82, 92);
            this.txBxAddPubDate.Name = "txBxAddPubDate";
            this.txBxAddPubDate.Size = new System.Drawing.Size(100, 20);
            this.txBxAddPubDate.TabIndex = 11;
            // 
            // txBxAddTitle
            // 
            this.txBxAddTitle.Location = new System.Drawing.Point(82, 12);
            this.txBxAddTitle.Name = "txBxAddTitle";
            this.txBxAddTitle.Size = new System.Drawing.Size(360, 20);
            this.txBxAddTitle.TabIndex = 12;
            // 
            // txBxAddAuthor
            // 
            this.txBxAddAuthor.Location = new System.Drawing.Point(82, 38);
            this.txBxAddAuthor.Name = "txBxAddAuthor";
            this.txBxAddAuthor.Size = new System.Drawing.Size(360, 20);
            this.txBxAddAuthor.TabIndex = 13;
            // 
            // txBxAddPublisher
            // 
            this.txBxAddPublisher.Location = new System.Drawing.Point(82, 64);
            this.txBxAddPublisher.Name = "txBxAddPublisher";
            this.txBxAddPublisher.Size = new System.Drawing.Size(360, 20);
            this.txBxAddPublisher.TabIndex = 14;
            // 
            // txBxAddGenre
            // 
            this.txBxAddGenre.Location = new System.Drawing.Point(15, 186);
            this.txBxAddGenre.Name = "txBxAddGenre";
            this.txBxAddGenre.Size = new System.Drawing.Size(213, 20);
            this.txBxAddGenre.TabIndex = 15;
            this.txBxAddGenre.Text = "név: txBxAddGenre";
            // 
            // txBxAddISBN
            // 
            this.txBxAddISBN.Location = new System.Drawing.Point(82, 118);
            this.txBxAddISBN.Name = "txBxAddISBN";
            this.txBxAddISBN.Size = new System.Drawing.Size(360, 20);
            this.txBxAddISBN.TabIndex = 16;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(229, 92);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(213, 21);
            this.comboBox1.Sorted = true;
            this.comboBox1.TabIndex = 17;
            this.comboBox1.Text = "Kérem válasszon!";
            // 
            // AddBookFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelWindow;
            this.ClientSize = new System.Drawing.Size(454, 281);
            this.ControlBox = false;
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.txBxAddISBN);
            this.Controls.Add(this.txBxAddGenre);
            this.Controls.Add(this.txBxAddPublisher);
            this.Controls.Add(this.txBxAddAuthor);
            this.Controls.Add(this.txBxAddTitle);
            this.Controls.Add(this.txBxAddPubDate);
            this.Controls.Add(this.btnCancelWindow);
            this.Controls.Add(this.btnAddFromWindow);
            this.Controls.Add(this.chckBxLend);
            this.Controls.Add(this.chckBxEbook);
            this.Controls.Add(this.chckBxForeignLang);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddBookFrm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Könyv hozzáadása a könyvtárhoz";
            this.Load += new System.EventHandler(this.AddBookFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chckBxForeignLang;
        private System.Windows.Forms.CheckBox chckBxEbook;
        private System.Windows.Forms.CheckBox chckBxLend;
        private System.Windows.Forms.Button btnAddFromWindow;
        private System.Windows.Forms.Button btnCancelWindow;
        private System.Windows.Forms.TextBox txBxAddPubDate;
        private System.Windows.Forms.TextBox txBxAddTitle;
        private System.Windows.Forms.TextBox txBxAddAuthor;
        private System.Windows.Forms.TextBox txBxAddPublisher;
        private System.Windows.Forms.TextBox txBxAddGenre;
        private System.Windows.Forms.TextBox txBxAddISBN;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}