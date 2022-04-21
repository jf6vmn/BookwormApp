﻿using System;
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

        DataSet dataSet=new DataSet();
        int authCount =0, pubCount = 0;


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



         //   using (SqlConnection conn = new SqlConnection(@"Data Source=VLZ_ASUS;Initial Catalog=BookwormDB;Integrated Security=True"))     //combox feltötés
            {
                try
                {

                    sqlConnectionUpdate.Open();


                   // conn.Open();
                    SqlCommand comd = sqlConnectionUpdate.CreateCommand();
                    comd.CommandType = CommandType.Text;
                    comd.CommandText = "select Genre from dbo.Genres";
                    comd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(comd);
                    da.Fill(dt);

                    foreach (DataRow dr in dt.Rows)
                    {
                        comboBox1.Items.Add(dr["Genre"].ToString());
                    }

                    comboBox1.Text = GetGenre;
                    //conn.Close(); 
                    sqlConnectionUpdate.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }
            }
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
                if (txBxUpdTitle.Text != GetTitle)                       //címek
                {
                    sqlDataAdapterUpdate.UpdateCommand = new SqlCommand("update Books set books.Title  = '" + txBxUpdTitle.Text + "' where books.Title='" + GetTitle + "' and Books.ISBN='" + GetISBN + "'", sqlConnectionUpdate);
                    sqlConnectionUpdate.Open();
                    sqlDataAdapterUpdate.UpdateCommand.ExecuteNonQuery();
                    sqlConnectionUpdate.Close();
                }                  

                if (txBxUpdAuthor.Text != GetAuthor)                  //szerzők update + ellenőrzés
                {
                    string checkID = "";

                    sqlConnectionUpdate.Open();
                    SqlCommand cmda = new SqlCommand("select count(*) from authors where authors.author='" + txBxUpdAuthor.Text + "'",sqlConnectionUpdate);
                    int count = (int)cmda.ExecuteScalar();
                    
                    if (count > 0)
                    {
                       // MessageBox.Show("Vótmá!");
                       
                        SqlCommand comandGetID= new SqlCommand("select id from authors where author='" + txBxUpdAuthor.Text + "'", sqlConnectionUpdate);
                        SqlDataReader dataReader = comandGetID.ExecuteReader();

                        if (dataReader.Read())
                        {
                            checkID = dataReader.GetValue(0).ToString();
                            sqlConnectionUpdate.Close();
                        }

                        sqlDataAdapterUpdate.UpdateCommand = new SqlCommand("update Books set Books.Author_id  = '"+ checkID + "'  where  Books.ISBN='" + GetISBN + "'", sqlConnectionUpdate);
                        sqlConnectionUpdate.Open();
                        sqlDataAdapterUpdate.UpdateCommand.ExecuteNonQuery();
                        sqlConnectionUpdate.Close();
                        MessageBox.Show(checkID);
                    }
                    else
                    {
                        MessageBox.Show("NEM VÓT MÉG!");
                        sqlDataAdapterUpdate.InsertCommand = new SqlCommand("insert into dbo.Authors (Author) values ('"+txBxUpdAuthor.Text+"') select books.author_id, authors.id from Authors inner join[dbo].Books on Books.Author_id = Authors.ID where  Books.ISBN='" + GetISBN + "'", sqlConnectionUpdate);
                        sqlDataAdapterUpdate.InsertCommand.ExecuteNonQuery();

                        SqlCommand scAuth = new SqlCommand("select id from authors where author='" + txBxUpdAuthor.Text + "'", sqlConnectionUpdate);
                        SqlDataReader dataReader = scAuth.ExecuteReader();
                        if (dataReader.Read()) { checkID = dataReader.GetValue(0).ToString(); sqlConnectionUpdate.Close(); }
                        sqlDataAdapterUpdate.UpdateCommand = new SqlCommand("update Books set Books.Author_id  = '" + checkID + "'  where  Books.ISBN='" + GetISBN + "'", sqlConnectionUpdate);

                        sqlConnectionUpdate.Open();
                        sqlDataAdapterUpdate.UpdateCommand.ExecuteNonQuery();
                        

                        sqlConnectionUpdate.Close();
                    }

                    #region

                    /*   for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                       {
                           if (dataSet.Tables[0].Rows[i][0].ToString() == txBxUpdAuthor.Text)
                           {
                            authCount = i + 1;
                            MessageBox.Show(dataSet.Tables[0].Rows[i][0].ToString()+"\n"+authCount.ToString());

                            sqlDataAdapterUpdate.SelectCommand = new SqlCommand("Update books set books.author_id = @authCount  from Authors inner join[dbo].Books on Books.Author_id = Authors.ID where  Books.ISBN='" + GetISBN + "'", sqlConnectionUpdate);
                            sqlConnectionUpdate.Open();
                            sqlDataAdapterUpdate.UpdateCommand.ExecuteNonQuery();
                            sqlConnectionUpdate.Close();
                        }
                           //textBox1.Text = dataSet.Tables[0].Rows[i][0].ToString();
                       }
                       // sqlConnectionUpdate.Close();


                       /*sqlDataAdapterUpdate.UpdateCommand = new SqlCommand("update Authors set Authors.Author  = '" + txBxUpdAuthor.Text + "' from Authors inner join[dbo].Books on Books.Author_id = Authors.ID where  Books.ISBN='" + GetISBN + "' and  Authors.Author='" + GetAuthor + "'", sqlConnectionUpdate);
                        sqlConnectionUpdate.Open();
                        sqlDataAdapterUpdate.UpdateCommand.ExecuteNonQuery();
                        sqlConnectionUpdate.Close();*/
                    // MessageBox.Show(dataSet.Tables[0].Rows[1][0].ToString());
                }
                /*    else
                    {
                        sqlDataAdapterUpdate.UpdateCommand = new SqlCommand("select ID from Authors where AutorsAuthor='" + GetAuthor + "'", sqlConnectionUpdate);
                        sqlConnectionUpdate.Open();
                        sqlDataAdapterUpdate.UpdateCommand.ExecuteNonQuery();
                        sqlDataAdapterUpdate.Fill(dataSet);

                        string authorUpdateHelp = dataSet.Tables[0].Rows[0][0].ToString();
                        sqlDataAdapterUpdate.UpdateCommand = new SqlCommand("update Authors set Authors.ID  = '" + authorUpdateHelp + "' from Authors inner join[dbo].Books on Books.Author_id = Authors.ID where  Books.ISBN='" + GetISBN + "' and  Authors.Author='" + GetAuthor + "'", sqlConnectionUpdate);
                        sqlDataAdapterUpdate.UpdateCommand.ExecuteNonQuery();
                        sqlConnectionUpdate.Close();
                    }*/
                #endregion

                if (txBxUpdPbulisher.Text  != GetPublishser)            //kiadó update + ellenőrzés
                {
                    string checkAuth = "";
                    sqlConnectionUpdate.Open();
                    SqlCommand cmda = new SqlCommand("select count(*) from publishers where publishers.publisher='" + txBxUpdPbulisher.Text + "'", sqlConnectionUpdate);
                    int count = (int)cmda.ExecuteScalar();

                    if (count > 0)
                    {
                        SqlCommand scPub = new SqlCommand("select id from publishers where publisher='" + txBxUpdPbulisher.Text + "'", sqlConnectionUpdate);
                        SqlDataReader dataReader = scPub.ExecuteReader();
                        if (dataReader.Read()) { checkAuth = dataReader.GetValue(0).ToString(); sqlConnectionUpdate.Close(); }

                        sqlDataAdapterUpdate.UpdateCommand = new SqlCommand("update Books set Books.publisher_id  = '" + checkAuth + "'  where  Books.ISBN='" + GetISBN + "'", sqlConnectionUpdate);
                        sqlConnectionUpdate.Open();
                        sqlDataAdapterUpdate.UpdateCommand.ExecuteNonQuery();
                        sqlConnectionUpdate.Close();
                        MessageBox.Show(checkAuth);
                    }

                    else
                    {
                        sqlDataAdapterUpdate.InsertCommand = new SqlCommand("insert into dbo.Publishers (Publisher) values ('" + txBxUpdPbulisher.Text + "') select books.pubblisher_id, publishers.id from Publishers inner join[dbo].Books on Books.Publisher_id = Publishers.ID where  Books.ISBN='" + GetISBN + "'", sqlConnectionUpdate);
                        sqlDataAdapterUpdate.InsertCommand.ExecuteNonQuery();

                        SqlCommand scAuth = new SqlCommand("select id from publishers where publisher='" + txBxUpdPbulisher.Text + "'", sqlConnectionUpdate);
                        SqlDataReader dataReader = scAuth.ExecuteReader();
                        if (dataReader.Read()) { checkAuth = dataReader.GetValue(0).ToString(); sqlConnectionUpdate.Close(); }
                        sqlDataAdapterUpdate.UpdateCommand = new SqlCommand("update Books set Books.Author_id  = '" + checkAuth + "'  where  Books.ISBN='" + GetISBN + "'", sqlConnectionUpdate);

                        sqlConnectionUpdate.Open();
                        sqlDataAdapterUpdate.UpdateCommand.ExecuteNonQuery();
                        sqlConnectionUpdate.Close();
                    }

                    /*  sqlDataAdapterUpdate.UpdateCommand = new SqlCommand("update Publishers set Publishers.Publisher  = '" + txBxUpdPbulisher.Text + "' from Publishers inner join[dbo].Books on Books.Publisher_id = Publishers.ID where  Books.ISBN='" + GetISBN + "' and  Publishers.Publisher='" + GetPublishser + "'", sqlConnectionUpdate);
                      sqlConnectionUpdate.Open();
                      sqlDataAdapterUpdate.UpdateCommand.ExecuteNonQuery();
                      sqlConnectionUpdate.Close();*/
                }       //kiadók

                if (txBxUpdPubDate.Text != GetPubDAte)
                { 
                    sqlDataAdapterUpdate.UpdateCommand = new SqlCommand("update Books set books.Release_Date  = '" + txBxUpdPubDate.Text + "' where books.Release_date='" + GetPubDAte + "' and Books.ISBN='" + GetISBN + "'", sqlConnectionUpdate);
                    sqlConnectionUpdate.Open();
                    sqlDataAdapterUpdate.UpdateCommand.ExecuteNonQuery();
                    sqlConnectionUpdate.Close();
                }             //kiadás éve

                if (comboBox1.SelectedItem.ToString() != GetGenre)                //if (txBxUpdGenre.Text != GetGenre)
                {
                    //   sqlDataAdapterUpdate.UpdateCommand = new SqlCommand("update Genres set Genres.Genre  = '" + comboBox1.SelectedItem + "' from Genres inner join[dbo].Books on Books.Genre_id = Genres.ID where  Books.ISBN='" + GetISBN + "' and  Genres.Genre='" + GetGenre + "'", sqlConnectionUpdate);

                    sqlDataAdapterUpdate.UpdateCommand = new SqlCommand("update Books set Books.Genre_id  = '" + (comboBox1.SelectedIndex+1) + "' from Genres inner join[dbo].Books on Books.Genre_id = Genres.ID where  Books.ISBN='" + GetISBN + "' and  Genres.Genre='" + GetGenre + "'", sqlConnectionUpdate);


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