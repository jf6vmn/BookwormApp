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
        public string GetIktSzam { get; set; }

       // DataSet dataSet=new DataSet();
        int authCount =0, pubCount = 0;

        SqlConnection sqlConnectionUpdate = new SqlConnection("Data Source=VLZASUS;Initial Catalog=Bookworm;Integrated Security=True");
        SqlDataAdapter sqlDataAdapterUpdate = new SqlDataAdapter();

        public UpdateBookFrm()
        {
            InitializeComponent();
        }

        private void UpdateBookFrm_Load(object sender, EventArgs e)
        {
            //Form1 mainFrm = new Form1();
            txBxUpdTitle.Text = GetTitle;
            txBxUpdAuthor.Text = GetAuthor;
            txBxUpdPbulisher.Text = GetPublishser;
            txBxUpdPubDate.Text = GetPubDAte;
            txBxUpdISBN.Text = GetISBN;
            chckBxUpdEbook.Checked = GetEbook;
            chckBxUpdForeignLang.Checked = GetForeign;
            if (GetBorrowed == true) { chckBxUpdLend.Checked = true; } else { chckBxUpdLend.Checked = false; }

         //   using (SqlConnection conn = new SqlConnection(@"Data Source=VLZ_ASUS;Initial Catalog=BookwormDB;Integrated Security=True"))     //combox feltötés
            {
                try
                {
                    // conn.Open();
                    sqlConnectionUpdate.Open();
                    SqlCommand comd = sqlConnectionUpdate.CreateCommand();
                    comd.CommandType = CommandType.Text;
                    comd.CommandText = "select Genre from dbo.Genres";
                    comd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(comd);
                    da.Fill(dt);

                    foreach (DataRow dr in dt.Rows)
                    {
                        updtComBox.Items.Add(dr["Genre"].ToString());
                    }

                    updtComBox.Text = GetGenre;
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

        void UpdateDatabase()
        {

            try
            {
                #region //checkbox-ok update-je
                if (chckBxUpdEbook.Checked == true)
                {
                    sqlDataAdapterUpdate.UpdateCommand = new SqlCommand("update Books set books.E_book  = '" + 1 + "' where books.ID='" + GetIktSzam + "'", sqlConnectionUpdate);
                    sqlConnectionUpdate.Open();
                    sqlDataAdapterUpdate.UpdateCommand.ExecuteNonQuery();
                    sqlConnectionUpdate.Close();
                }
                else
                {
                    sqlDataAdapterUpdate.UpdateCommand = new SqlCommand("update Books set books.E_book  = '" + 0 + "' where books.ID='" + GetIktSzam + "'", sqlConnectionUpdate);
                    sqlConnectionUpdate.Open();
                    sqlDataAdapterUpdate.UpdateCommand.ExecuteNonQuery();
                    sqlConnectionUpdate.Close();
                }

                if (chckBxUpdForeignLang.Checked == true)
                {
                    sqlDataAdapterUpdate.UpdateCommand = new SqlCommand("update Books set books.Foreign_language  = '" + 1 + "'where books.ID='" + GetIktSzam + "'", sqlConnectionUpdate);
                    sqlConnectionUpdate.Open();
                    sqlDataAdapterUpdate.UpdateCommand.ExecuteNonQuery();
                    sqlConnectionUpdate.Close();
                }
                else
                {
                    sqlDataAdapterUpdate.UpdateCommand = new SqlCommand("update Books set books.Foreign_language  = '" + 0 + "'where books.ID='" + GetIktSzam + "'", sqlConnectionUpdate);
                    sqlConnectionUpdate.Open();
                    sqlDataAdapterUpdate.UpdateCommand.ExecuteNonQuery();
                    sqlConnectionUpdate.Close();
                }

                if (chckBxUpdLend.Checked == true)
                {
                    sqlDataAdapterUpdate.UpdateCommand = new SqlCommand("update Books set books.Borrowed  = '" + 1 + "' where books.ID='" + GetIktSzam + "'", sqlConnectionUpdate);
                    sqlConnectionUpdate.Open();
                    sqlDataAdapterUpdate.UpdateCommand.ExecuteNonQuery();
                    sqlConnectionUpdate.Close();
                }
                else
                {
                    sqlDataAdapterUpdate.UpdateCommand = new SqlCommand("update Books set books.Borrowed  = '" + 0 + "'where books.ID='" + GetIktSzam + "'", sqlConnectionUpdate);
                    sqlConnectionUpdate.Open();
                    sqlDataAdapterUpdate.UpdateCommand.ExecuteNonQuery();
                    sqlConnectionUpdate.Close();
                }

                #endregion

                #region //textbox-ok update-je
                if (txBxUpdTitle.Text != GetTitle)                       //címek
                {
                    sqlDataAdapterUpdate.UpdateCommand = new SqlCommand("update Books set books.Title  = '" + txBxUpdTitle.Text + "' where books.Title='" + GetTitle + "' and books.ID='" + GetIktSzam + "'", sqlConnectionUpdate);
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

                        sqlDataAdapterUpdate.UpdateCommand = new SqlCommand("update Books set Books.Author_id  = '"+ checkID + "'  where   books.ID='" + GetIktSzam + "'", sqlConnectionUpdate);
                        sqlConnectionUpdate.Open();
                        sqlDataAdapterUpdate.UpdateCommand.ExecuteNonQuery();
                        sqlConnectionUpdate.Close();
                        MessageBox.Show(checkID);
                    }
                    else
                    {
                        MessageBox.Show("NEM VÓT MÉG!");
                        sqlDataAdapterUpdate.InsertCommand = new SqlCommand("insert into dbo.Authors (Author) values ('"+txBxUpdAuthor.Text+ "') select books.author_id, authors.id from Authors inner join[dbo].Books on Books.Author_id = Authors.ID where   books.ID='" + GetIktSzam + "'", sqlConnectionUpdate);
                        sqlDataAdapterUpdate.InsertCommand.ExecuteNonQuery();

                        SqlCommand scAuth = new SqlCommand("select id from authors where author='" + txBxUpdAuthor.Text + "'", sqlConnectionUpdate);
                        SqlDataReader dataReader = scAuth.ExecuteReader();
                        if (dataReader.Read()) { checkID = dataReader.GetValue(0).ToString(); sqlConnectionUpdate.Close(); }
                        sqlDataAdapterUpdate.UpdateCommand = new SqlCommand("update Books set Books.Author_id  = '" + checkID + "'  where   books.ID='" + GetIktSzam + "'", sqlConnectionUpdate);

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
                        sqlDataAdapterUpdate.InsertCommand = new SqlCommand("insert into dbo.Publishers (Publisher) values ('" + txBxUpdPbulisher.Text + "') select books.publisher_id, publishers.id from Publishers inner join[dbo].Books on Books.Publisher_id = Publishers.ID where books.ID='" + GetIktSzam + "'", sqlConnectionUpdate);
                        sqlDataAdapterUpdate.InsertCommand.ExecuteNonQuery();

                        SqlCommand scAuth = new SqlCommand("select id from publishers where publisher='" + txBxUpdPbulisher.Text + "'", sqlConnectionUpdate);
                        SqlDataReader dataReader = scAuth.ExecuteReader();
                        if (dataReader.Read()) { checkAuth = dataReader.GetValue(0).ToString(); sqlConnectionUpdate.Close(); }
                        sqlDataAdapterUpdate.UpdateCommand = new SqlCommand("update Books set Books.Author_id  = '" + checkAuth + "'  where   books.ID='" + GetIktSzam + "'", sqlConnectionUpdate);

                        sqlConnectionUpdate.Open();
                        sqlDataAdapterUpdate.InsertCommand.ExecuteNonQuery();
                        sqlConnectionUpdate.Close();                   
                    }
                }       //kiadók

                if (txBxUpdPubDate.Text != GetPubDAte)
                {             
                        sqlDataAdapterUpdate.UpdateCommand = new SqlCommand("update Books set books.Release_Date  = '" + txBxUpdPubDate.Text + "' where books.Release_date='" + GetPubDAte + "' and  books.ID='" + GetIktSzam + "'", sqlConnectionUpdate);
                        sqlConnectionUpdate.Open();
                        sqlDataAdapterUpdate.UpdateCommand.ExecuteNonQuery();
                        sqlConnectionUpdate.Close();                   
                }             //kiadás éve

                if (updtComBox.SelectedItem.ToString() != GetGenre)                //if (txBxUpdGenre.Text != GetGenre)
                {
                    sqlDataAdapterUpdate.UpdateCommand = new SqlCommand("update Books set Books.Genre_id  = '" + (updtComBox.SelectedIndex+1) + "' from Genres inner join[dbo].Books on Books.Genre_id = Genres.ID where   books.ID='" + GetIktSzam + "' and  Genres.Genre='" + GetGenre + "'", sqlConnectionUpdate);

                    sqlConnectionUpdate.Open();
                    sqlDataAdapterUpdate.UpdateCommand.ExecuteNonQuery();
                    sqlConnectionUpdate.Close();
                }

                if (txBxUpdISBN.Text != GetISBN)
                {
                    sqlDataAdapterUpdate.UpdateCommand = new SqlCommand("update Books set books.ISBN  = '" + txBxUpdISBN.Text + "' where  books.ID='" + GetIktSzam + "'", sqlConnectionUpdate);
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
            try
            {
                int validDAte = Int32.Parse(txBxUpdPubDate.Text);
                if (validDAte < 1000 || validDAte > DateTime.Now.Year || txBxUpdISBN.Text == "")
                {
                    MessageBox.Show("Elenőrizze az adatokat!");
                }
                else
                {
                    //   MessageBox.Show("Jó a dátum!");
                    UpdateDatabase();
                }
            }

            catch(Exception ex) { MessageBox.Show("Hiba történt a módosítás közben! \n" + ex); }            
        }
    }
}