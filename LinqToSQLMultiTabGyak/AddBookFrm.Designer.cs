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
            this.chckBxForeignLangAdd = new System.Windows.Forms.CheckBox();
            this.chckBxEbookAdd = new System.Windows.Forms.CheckBox();
            this.chckBxLendAdd = new System.Windows.Forms.CheckBox();
            this.btnAddFromWindow = new System.Windows.Forms.Button();
            this.btnCancelWindow = new System.Windows.Forms.Button();
            this.txBxAddPubDate = new System.Windows.Forms.TextBox();
            this.txBxAddTitle = new System.Windows.Forms.TextBox();
            this.txBxAddAuthor = new System.Windows.Forms.TextBox();
            this.txBxAddPublisher = new System.Windows.Forms.TextBox();
            this.txBxAddISBN = new System.Windows.Forms.TextBox();
            this.addComBox = new System.Windows.Forms.ComboBox();
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
            // chckBxForeignLangAdd
            // 
            this.chckBxForeignLangAdd.AutoSize = true;
            this.chckBxForeignLangAdd.Location = new System.Drawing.Point(82, 144);
            this.chckBxForeignLangAdd.Name = "chckBxForeignLangAdd";
            this.chckBxForeignLangAdd.Size = new System.Drawing.Size(93, 17);
            this.chckBxForeignLangAdd.TabIndex = 7;
            this.chckBxForeignLangAdd.Text = "Idegen nyelvű";
            this.chckBxForeignLangAdd.UseVisualStyleBackColor = true;
            // 
            // chckBxEbookAdd
            // 
            this.chckBxEbookAdd.AutoSize = true;
            this.chckBxEbookAdd.Location = new System.Drawing.Point(180, 144);
            this.chckBxEbookAdd.Name = "chckBxEbookAdd";
            this.chckBxEbookAdd.Size = new System.Drawing.Size(60, 17);
            this.chckBxEbookAdd.TabIndex = 8;
            this.chckBxEbookAdd.Text = "E-book";
            this.chckBxEbookAdd.UseVisualStyleBackColor = true;
            // 
            // chckBxLendAdd
            // 
            this.chckBxLendAdd.AutoSize = true;
            this.chckBxLendAdd.Location = new System.Drawing.Point(246, 144);
            this.chckBxLendAdd.Name = "chckBxLendAdd";
            this.chckBxLendAdd.Size = new System.Drawing.Size(91, 17);
            this.chckBxLendAdd.TabIndex = 9;
            this.chckBxLendAdd.Text = "Kölcsön adva";
            this.chckBxLendAdd.UseVisualStyleBackColor = true;
            // 
            // btnAddFromWindow
            // 
            this.btnAddFromWindow.Image = global::LinqToSQLMultiTabGyak.Properties.Resources.ikon_add;
            this.btnAddFromWindow.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddFromWindow.Location = new System.Drawing.Point(60, 234);
            this.btnAddFromWindow.Name = "btnAddFromWindow";
            this.btnAddFromWindow.Size = new System.Drawing.Size(220, 35);
            this.btnAddFromWindow.TabIndex = 10;
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
            this.btnCancelWindow.TabIndex = 11;
            this.btnCancelWindow.Text = "Mégse";
            this.btnCancelWindow.UseVisualStyleBackColor = true;
            this.btnCancelWindow.Click += new System.EventHandler(this.btnCancelWindow_Click);
            // 
            // txBxAddPubDate
            // 
            this.txBxAddPubDate.Location = new System.Drawing.Point(82, 92);
            this.txBxAddPubDate.MaxLength = 4;
            this.txBxAddPubDate.Name = "txBxAddPubDate";
            this.txBxAddPubDate.Size = new System.Drawing.Size(100, 20);
            this.txBxAddPubDate.TabIndex = 4;
            // 
            // txBxAddTitle
            // 
            this.txBxAddTitle.Location = new System.Drawing.Point(82, 12);
            this.txBxAddTitle.Name = "txBxAddTitle";
            this.txBxAddTitle.Size = new System.Drawing.Size(360, 20);
            this.txBxAddTitle.TabIndex = 1;
            // 
            // txBxAddAuthor
            // 
            this.txBxAddAuthor.Location = new System.Drawing.Point(82, 38);
            this.txBxAddAuthor.Name = "txBxAddAuthor";
            this.txBxAddAuthor.Size = new System.Drawing.Size(360, 20);
            this.txBxAddAuthor.TabIndex = 2;
            // 
            // txBxAddPublisher
            // 
            this.txBxAddPublisher.Location = new System.Drawing.Point(82, 64);
            this.txBxAddPublisher.Name = "txBxAddPublisher";
            this.txBxAddPublisher.Size = new System.Drawing.Size(360, 20);
            this.txBxAddPublisher.TabIndex = 3;
            // 
            // txBxAddISBN
            // 
            this.txBxAddISBN.Location = new System.Drawing.Point(82, 118);
            this.txBxAddISBN.Name = "txBxAddISBN";
            this.txBxAddISBN.Size = new System.Drawing.Size(360, 20);
            this.txBxAddISBN.TabIndex = 6;
            // 
            // addComBox
            // 
            this.addComBox.FormattingEnabled = true;
            this.addComBox.Location = new System.Drawing.Point(229, 92);
            this.addComBox.Name = "addComBox";
            this.addComBox.Size = new System.Drawing.Size(213, 21);
            this.addComBox.TabIndex = 5;
            this.addComBox.Text = "Kérem válasszon!";
            // 
            // AddBookFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelWindow;
            this.ClientSize = new System.Drawing.Size(454, 281);
            this.ControlBox = false;
            this.Controls.Add(this.addComBox);
            this.Controls.Add(this.txBxAddISBN);
            this.Controls.Add(this.txBxAddPublisher);
            this.Controls.Add(this.txBxAddAuthor);
            this.Controls.Add(this.txBxAddTitle);
            this.Controls.Add(this.txBxAddPubDate);
            this.Controls.Add(this.btnCancelWindow);
            this.Controls.Add(this.btnAddFromWindow);
            this.Controls.Add(this.chckBxLendAdd);
            this.Controls.Add(this.chckBxEbookAdd);
            this.Controls.Add(this.chckBxForeignLangAdd);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(470, 320);
            this.MinimumSize = new System.Drawing.Size(470, 320);
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
        private System.Windows.Forms.CheckBox chckBxForeignLangAdd;
        private System.Windows.Forms.CheckBox chckBxEbookAdd;
        private System.Windows.Forms.CheckBox chckBxLendAdd;
        private System.Windows.Forms.Button btnAddFromWindow;
        private System.Windows.Forms.Button btnCancelWindow;
        private System.Windows.Forms.TextBox txBxAddPubDate;
        private System.Windows.Forms.TextBox txBxAddTitle;
        private System.Windows.Forms.TextBox txBxAddAuthor;
        private System.Windows.Forms.TextBox txBxAddPublisher;
        private System.Windows.Forms.TextBox txBxAddISBN;
        private System.Windows.Forms.ComboBox addComBox;
    }
}