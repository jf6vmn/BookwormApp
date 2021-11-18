using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;

namespace LinqToSQLMultiTabGyak
{
    public partial class UpdateBookFrm : Form
    {
        public string GetTitle { get; set; }
        public string GetAuthor { get; set; }
        public string GetPublishser { get; set; }
        public string GetPubDAte { get; set; }
        public string GetGenre { get; set; }
        public string GetISBN { get; set; }
        public bool GetEbook { get; set; }
        public bool GetForeign { get; set; }
        public bool GetBorrowed { get; set; }


        SqlConnection sqlConnectionUpdate = new SqlConnection("Data Source=VLZ_ASUS;Initial Catalog=BookwormDB;Integrated Security=True");
        SqlDataAdapter sqlDataAdapterUpdate = new SqlDataAdapter();

        public UpdateBookFrm()
        {
            InitializeComponent();
        }

        private void UpdateBookFrm_Load(object sender, EventArgs e)
        {
            Form1 mainFrm = new Form1();
            txBxUpdTitle.Text = GetTitle;
            txBxUpdAuthor.Text = GetAuthor;
            txBxUpdPbulisher.Text = GetPublishser;
            txBxUpdPubDate.Text = GetPubDAte;
            txBxUpdGenre.Text = GetGenre;
            txBxUpdISBN.Text = GetISBN;
            chckBxUpdEbook.Checked = GetEbook;
            chckBxUpdForeignLang.Checked = GetForeign;
            if (GetBorrowed == true) { chckBxUpdLend.Checked = true; } else { chckBxUpdLend.Checked = false; }
        }

        private void btnCancelUpdaeWindow_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       public bool changeTitle = false, changeAuthor=false;
        
        
        #region update figyelős metódus

        /*        private void TxBxStuffed()
                {
                 //   txBxUpdTitle.TextChanged += new System.EventHandler(this.txBxUpdTitle_TextChanged);
                    txBxUpdAuthor.TextChanged += new System.EventHandler(this.txBxUpdAuthor_TextChanged);
                //    txBxUpdPbulisher.TextChanged += new System.EventHandler(this.txBxTextChanged);
               //     txBxUpdPubDate.TextChanged += new System.EventHandler(this.txBxTextChanged);
               //     txBxUpdGenre.TextChanged += new System.EventHandler(this.txBxTextChanged);
               //     txBxUpdISBN.TextChanged += new System.EventHandler(this.txBxTextChanged);

                    }

                //private void txBxTextChanged(object sender, EventArgs e) { txBxWasChanged = true; }




               // private void txBxUpdTitle_TextChanged(object sender, EventArgs e)   { changeTitle = true;}
                private void txBxUpdAuthor_TextChanged(object sender, EventArgs e)  { changeAuthor = true; }

        */
        #endregion


        void UpdateDatabase()
        {
       //     TxBxStuffed();
            try
            {
                #region //checkbox-ok update-je
                if (chckBxUpdEbook.Checked == true)
                {
                    sqlDataAdapterUpdate.UpdateCommand = new SqlCommand("update Books set books.E_book  = '" + 1 + "' where books.ISBN='" + GetISBN + "'", sqlConnectionUpdate);
                    sqlConnectionUpdate.Open();
                    sqlDataAdapterUpdate.UpdateCommand.ExecuteNonQuery();
                    sqlConnectionUpdate.Close();
                }
                else
                {
                    sqlDataAdapterUpdate.UpdateCommand = new SqlCommand("update Books set books.E_book  = '" + 0 + "' where books.ISBN='" + GetISBN + "'", sqlConnectionUpdate);
                    sqlConnectionUpdate.Open();
                    sqlDataAdapterUpdate.UpdateCommand.ExecuteNonQuery();
                    sqlConnectionUpdate.Close();
                }

                if (chckBxUpdForeignLang.Checked == true)
                {
                    sqlDataAdapterUpdate.UpdateCommand = new SqlCommand("update Books set books.Foreign_language  = '" + 1 + "' where books.ISBN='" + GetISBN + "'", sqlConnectionUpdate);
                    sqlConnectionUpdate.Open();
                    sqlDataAdapterUpdate.UpdateCommand.ExecuteNonQuery();
                    sqlConnectionUpdate.Close();
                }
                else
                {
                    sqlDataAdapterUpdate.UpdateCommand = new SqlCommand("update Books set books.Foreign_language  = '" + 0 + "' where books.ISBN='" + GetISBN + "'", sqlConnectionUpdate);
                    sqlConnectionUpdate.Open();
                    sqlDataAdapterUpdate.UpdateCommand.ExecuteNonQuery();
                    sqlConnectionUpdate.Close();
                }

                if (chckBxUpdLend.Checked == true)
                {
                    sqlDataAdapterUpdate.UpdateCommand = new SqlCommand("update Books set books.Borrowed  = '" + 1 + "' where books.ISBN='" + GetISBN + "'", sqlConnectionUpdate);
                    sqlConnectionUpdate.Open();
                    sqlDataAdapterUpdate.UpdateCommand.ExecuteNonQuery();
                    sqlConnectionUpdate.Close();
                }
                else
                {
                    sqlDataAdapterUpdate.UpdateCommand = new SqlCommand("update Books set books.Borrowed  = '" + 0 + "' where books.ISBN='" + GetISBN + "'", sqlConnectionUpdate);
                    sqlConnectionUpdate.Open();
                    sqlDataAdapterUpdate.UpdateCommand.ExecuteNonQuery();
                    sqlConnectionUpdate.Close();
                }

                #endregion


                #region //textbox-ok update-je
                if (txBxUpdTitle.Text != GetTitle)
                {
                    sqlDataAdapterUpdate.UpdateCommand = new SqlCommand("update Books set books.Title  = '" + txBxUpdTitle.Text + "' where books.Title='" + GetTitle + "' and Books.ISBN='" + GetISBN + "'", sqlConnectionUpdate);
                    sqlConnectionUpdate.Open();
                    sqlDataAdapterUpdate.UpdateCommand.ExecuteNonQuery();
                    sqlConnectionUpdate.Close();
                }
                if (txBxUpdAuthor.Text != GetAuthor)
                {
                    sqlDataAdapterUpdate.UpdateCommand = new SqlCommand("update Authors set Authors.Author  = '" + txBxUpdAuthor.Text + "' from Authors inner join[dbo].Books on Books.Author_id = Authors.ID where  Books.ISBN='" + GetISBN + "' and  Authors.Author='" + GetAuthor + "'", sqlConnectionUpdate);
                    sqlConnectionUpdate.Open();
                    sqlDataAdapterUpdate.UpdateCommand.ExecuteNonQuery();
                    sqlConnectionUpdate.Close();
                }

                if (txBxUpdPbulisher.Text  != GetPublishser)
                {
                    sqlDataAdapterUpdate.UpdateCommand = new SqlCommand("update Publishers set Publishers.Publisher  = '" + txBxUpdPbulisher.Text + "' from Publishers inner join[dbo].Books on Books.Publisher_id = Publishers.ID where  Books.ISBN='" + GetISBN + "' and  Publishers.Publisher='" + GetPublishser + "'", sqlConnectionUpdate);
                    sqlConnectionUpdate.Open();
                    sqlDataAdapterUpdate.UpdateCommand.ExecuteNonQuery();
                    sqlConnectionUpdate.Close();
                }
                if (txBxUpdPubDate.Text != GetPubDAte)
                { 
                    sqlDataAdapterUpdate.UpdateCommand = new SqlCommand("update Books set books.Release_Date  = '" + txBxUpdPubDate.Text + "' where books.Release_date='" + GetPubDAte + "' and Books.ISBN='" + GetISBN + "'", sqlConnectionUpdate);
                    sqlConnectionUpdate.Open();
                    sqlDataAdapterUpdate.UpdateCommand.ExecuteNonQuery();
                    sqlConnectionUpdate.Close();
                }
                if (txBxUpdGenre.Text != GetGenre)
                {
                    sqlDataAdapterUpdate.UpdateCommand = new SqlCommand("update Genres set Genres.Genre  = '" + txBxUpdGenre.Text + "' from Genres inner join[dbo].Books on Books.Genre_id = Genres.ID where  Books.ISBN='" + GetISBN + "' and  Genres.Genre='" + GetGenre + "'", sqlConnectionUpdate);
                    sqlConnectionUpdate.Open();
                    sqlDataAdapterUpdate.UpdateCommand.ExecuteNonQuery();
                    sqlConnectionUpdate.Close();
                }

                if (txBxUpdISBN.Text != GetISBN)
                {
                    sqlDataAdapterUpdate.UpdateCommand = new SqlCommand("update Books set books.ISBN  = '" + txBxUpdISBN.Text + "' where books.ISBN='" + GetISBN + "'", sqlConnectionUpdate);
                    sqlConnectionUpdate.Open();
                    sqlDataAdapterUpdate.UpdateCommand.ExecuteNonQuery();
                    sqlConnectionUpdate.Close();
                }
                #endregion

            
                MessageBox.Show("Sikeres módosítás!");
                this.Close();
              }

              catch (Exception ex)
              {
                    MessageBox.Show("Hiba történt módosítás közben:\n" + ex);
              }
        }


        private void btnUpdateFromWindow_Click(object sender, EventArgs e)
        {
            UpdateDatabase();          
        }
    }
}