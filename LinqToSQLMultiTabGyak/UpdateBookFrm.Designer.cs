﻿namespace LinqToSQLMultiTabGyak
{
    partial class UpdateBookFrm
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
            this.txBxUpdISBN = new System.Windows.Forms.TextBox();
            this.txBxUpdGenre = new System.Windows.Forms.TextBox();
            this.txBxUpdPbulisher = new System.Windows.Forms.TextBox();
            this.txBxUpdAuthor = new System.Windows.Forms.TextBox();
            this.txBxUpdTitle = new System.Windows.Forms.TextBox();
            this.txBxUpdPubDate = new System.Windows.Forms.TextBox();
            this.btnCancelUpdaeWindow = new System.Windows.Forms.Button();
            this.btnUpdateFromWindow = new System.Windows.Forms.Button();
            this.chckBxUpdLend = new System.Windows.Forms.CheckBox();
            this.chckBxUpdEbook = new System.Windows.Forms.CheckBox();
            this.chckBxUpdForeignLang = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txBxUpdISBN
            // 
            this.txBxUpdISBN.Location = new System.Drawing.Point(82, 118);
            this.txBxUpdISBN.Name = "txBxUpdISBN";
            this.txBxUpdISBN.Size = new System.Drawing.Size(361, 20);
            this.txBxUpdISBN.TabIndex = 33;
            // 
            // txBxUpdGenre
            // 
            this.txBxUpdGenre.Location = new System.Drawing.Point(230, 92);
            this.txBxUpdGenre.Name = "txBxUpdGenre";
            this.txBxUpdGenre.Size = new System.Drawing.Size(214, 20);
            this.txBxUpdGenre.TabIndex = 32;
            // 
            // txBxUpdPbulisher
            // 
            this.txBxUpdPbulisher.Location = new System.Drawing.Point(82, 64);
            this.txBxUpdPbulisher.Name = "txBxUpdPbulisher";
            this.txBxUpdPbulisher.Size = new System.Drawing.Size(361, 20);
            this.txBxUpdPbulisher.TabIndex = 31;
            // 
            // txBxUpdAuthor
            // 
            this.txBxUpdAuthor.Location = new System.Drawing.Point(82, 38);
            this.txBxUpdAuthor.Name = "txBxUpdAuthor";
            this.txBxUpdAuthor.Size = new System.Drawing.Size(361, 20);
            this.txBxUpdAuthor.TabIndex = 30;
      //      this.txBxUpdAuthor.TextChanged += new System.EventHandler(this.txBxUpdAuthor_TextChanged);
            // 
            // txBxUpdTitle
            // 
            this.txBxUpdTitle.Location = new System.Drawing.Point(82, 12);
            this.txBxUpdTitle.Name = "txBxUpdTitle";
            this.txBxUpdTitle.Size = new System.Drawing.Size(361, 20);
            this.txBxUpdTitle.TabIndex = 29;
       //     this.txBxUpdTitle.TextChanged += new System.EventHandler(this.txBxUpdTitle_TextChanged);
            // 
            // txBxUpdPubDate
            // 
            this.txBxUpdPubDate.Location = new System.Drawing.Point(82, 92);
            this.txBxUpdPubDate.Name = "txBxUpdPubDate";
            this.txBxUpdPubDate.Size = new System.Drawing.Size(100, 20);
            this.txBxUpdPubDate.TabIndex = 28;
            // 
            // btnCancelUpdaeWindow
            // 
            this.btnCancelUpdaeWindow.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelUpdaeWindow.Location = new System.Drawing.Point(364, 240);
            this.btnCancelUpdaeWindow.Name = "btnCancelUpdaeWindow";
            this.btnCancelUpdaeWindow.Size = new System.Drawing.Size(75, 23);
            this.btnCancelUpdaeWindow.TabIndex = 27;
            this.btnCancelUpdaeWindow.Text = "Mégse";
            this.btnCancelUpdaeWindow.UseVisualStyleBackColor = true;
            this.btnCancelUpdaeWindow.Click += new System.EventHandler(this.btnCancelUpdaeWindow_Click);
            // 
            // btnUpdateFromWindow
            // 
            this.btnUpdateFromWindow.Location = new System.Drawing.Point(16, 240);
            this.btnUpdateFromWindow.Name = "btnUpdateFromWindow";
            this.btnUpdateFromWindow.Size = new System.Drawing.Size(342, 23);
            this.btnUpdateFromWindow.TabIndex = 26;
            this.btnUpdateFromWindow.Text = "Módosítás";
            this.btnUpdateFromWindow.UseVisualStyleBackColor = true;
            this.btnUpdateFromWindow.Click += new System.EventHandler(this.btnUpdateFromWindow_Click);
            // 
            // chckBxUpdLend
            // 
            this.chckBxUpdLend.AutoSize = true;
            this.chckBxUpdLend.Location = new System.Drawing.Point(247, 144);
            this.chckBxUpdLend.Name = "chckBxUpdLend";
            this.chckBxUpdLend.Size = new System.Drawing.Size(91, 17);
            this.chckBxUpdLend.TabIndex = 25;
            this.chckBxUpdLend.Text = "Kölcsön adva";
            this.chckBxUpdLend.UseVisualStyleBackColor = true;
            // 
            // chckBxUpdEbook
            // 
            this.chckBxUpdEbook.AutoSize = true;
            this.chckBxUpdEbook.Location = new System.Drawing.Point(82, 144);
            this.chckBxUpdEbook.Name = "chckBxUpdEbook";
            this.chckBxUpdEbook.Size = new System.Drawing.Size(60, 17);
            this.chckBxUpdEbook.TabIndex = 24;
            this.chckBxUpdEbook.Text = "E-book";
            this.chckBxUpdEbook.UseVisualStyleBackColor = true;
            // 
            // chckBxUpdForeignLang
            // 
            this.chckBxUpdForeignLang.AutoSize = true;
            this.chckBxUpdForeignLang.Location = new System.Drawing.Point(148, 144);
            this.chckBxUpdForeignLang.Name = "chckBxUpdForeignLang";
            this.chckBxUpdForeignLang.Size = new System.Drawing.Size(93, 17);
            this.chckBxUpdForeignLang.TabIndex = 23;
            this.chckBxUpdForeignLang.Text = "Idegen nyelvű";
            this.chckBxUpdForeignLang.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "ISBN:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(188, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Műfaj:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Kiadás éve:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Kiadó:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Szerző:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Cím:";
            // 
            // UpdateBookFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 278);
            this.Controls.Add(this.txBxUpdISBN);
            this.Controls.Add(this.txBxUpdGenre);
            this.Controls.Add(this.txBxUpdPbulisher);
            this.Controls.Add(this.txBxUpdAuthor);
            this.Controls.Add(this.txBxUpdTitle);
            this.Controls.Add(this.txBxUpdPubDate);
            this.Controls.Add(this.btnCancelUpdaeWindow);
            this.Controls.Add(this.btnUpdateFromWindow);
            this.Controls.Add(this.chckBxUpdLend);
            this.Controls.Add(this.chckBxUpdEbook);
            this.Controls.Add(this.chckBxUpdForeignLang);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UpdateBookFrm";
            this.Text = "UpdateBookFrm";
            this.Load += new System.EventHandler(this.UpdateBookFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txBxUpdISBN;
        private System.Windows.Forms.TextBox txBxUpdGenre;
        private System.Windows.Forms.TextBox txBxUpdPbulisher;
        private System.Windows.Forms.TextBox txBxUpdAuthor;
        private System.Windows.Forms.TextBox txBxUpdTitle;
        private System.Windows.Forms.TextBox txBxUpdPubDate;
        private System.Windows.Forms.Button btnCancelUpdaeWindow;
        private System.Windows.Forms.Button btnUpdateFromWindow;
        private System.Windows.Forms.CheckBox chckBxUpdLend;
        private System.Windows.Forms.CheckBox chckBxUpdEbook;
        private System.Windows.Forms.CheckBox chckBxUpdForeignLang;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}