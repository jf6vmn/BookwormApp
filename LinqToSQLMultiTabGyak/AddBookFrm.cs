using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections.Generic;

namespace LinqToSQLMultiTabGyak
{
    public partial class AddBookFrm : Form
    {
        public AddBookFrm()
        {
            InitializeComponent();
        }
        //SqlConnection connAdd = new SqlConnection(@"Data Source=VLZ_ASUS;Initial Catalog=bookwormdb;Integrated Security=True");
        SqlConnection connAdd = new SqlConnection("Data Source=VLZASUS;Initial Catalog=Bookworm;Integrated Security=True");
        SqlDataAdapter sqlDataAdapterAdd = new SqlDataAdapter();

        private void AddBookFrm_Load(object sender, EventArgs e)
        {
              try
              {
                    connAdd.Open();
                    SqlCommand comd = connAdd.CreateCommand();
                    comd.CommandType = CommandType.Text;
                    comd.CommandText = "select Genre from dbo.Genres";
                    comd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(comd);
                    da.Fill(dt);

                    foreach (DataRow dr in dt.Rows)
                    {
                        comboBox1.Items.Add(dr["Genre"].ToString());
                        //   frPop.comSzoveg.Add(dr["Genre"].ToString());
                        //    frPop.cumiBox.Items.Add(dr["Genre"].ToString()); //muszik de rusnya
                    }
                connAdd.Close();
              }

              catch (Exception ex)
              {
                    // write exception info to log or anything else
                    MessageBox.Show("" + ex);
              }
        }

      /*  private void checkAuthAndPub()
        {
            string checkID = "";
       
                    SqlCommand cmda = new SqlCommand("select count(*) from authors where authors.author='" + txBxAddAuthor.Text + "'", conn);
                    conn.Open();
                    int counta = (int)cmda.ExecuteScalar();

                    if (counta > 0)
                    {
                        SqlCommand commAuthID = new SqlCommand("select id from authors where author='" + txBxAddAuthor.Text + "'", conn);
                        SqlDataReader dataReader = commAuthID.ExecuteReader();
                        if (dataReader.Read())
                        {
                            checkID = dataReader.GetValue(0).ToString();
                           // conn.Close();                           
                        }
                     //   conn.Open();
                        sqlDataAdapterAdd.UpdateCommand = new SqlCommand("update Books set Books.Author_id  = '" + checkID + "'from Authors inner join[dbo].Books on Books.Author_id = Authors.ID  where authors.author'" + txBxAddAuthor.Text + "' and books.ISBN='" +txBxAddISBN.Text +"'", conn);

                        sqlDataAdapterAdd.UpdateCommand.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show(checkID);
                    }

            //else { }

            SqlCommand cmdp = new SqlCommand("select count(*) from publishers where publishers.publisher='" + txBxAddPublisher.Text + "'", conn);
            conn.Open();
            int countp = (int)cmdp.ExecuteScalar();

            if (countp > 0)
            {
                SqlCommand commPubID = new SqlCommand("select id from authors where author='" + txBxAddPublisher.Text + "'", conn);
                SqlDataReader dataReader = commPubID.ExecuteReader();
                if (dataReader.Read())
                {
                    checkID = dataReader.GetValue(0).ToString();
                    conn.Close();
                }
                conn.Open();
                sqlDataAdapterAdd.UpdateCommand = new SqlCommand("update Books set Books.Author_id  = '" + checkID + "'from publishers inner join[dbo].Books on Books.publisher_id = Publishers.ID  where publishers.publisher'" + txBxAddPublisher.Text + "' and books.ISBN='" + txBxAddISBN.Text + "'", conn);

                sqlDataAdapterAdd.UpdateCommand.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show(checkID);
            }

        }*/


    private void addDataToDB()                   //adatbevitel v1 
        {
             BWModelDataContext dataContext = new BWModelDataContext();
            int bookDate = Convert.ToInt16(txBxAddPubDate);

            try
            {
                if (txBxAddISBN.Text == "")
                {
                    MessageBox.Show("Az ISBN mező nem lehet üres!");
                }
                else
                {
                    {
                        Publisher insPub = new Publisher
                        {
                            Publisher1 = txBxAddPublisher.Text
                        };

                        dataContext.Publishers.InsertOnSubmit(insPub);
                        dataContext.SubmitChanges();

                        Author insAuthor = new Author
                        {
                            Author1 = txBxAddAuthor.Text
                        };
                       
                        dataContext.Authors.InsertOnSubmit(insAuthor);
                        dataContext.SubmitChanges();

                        //insAuthor.ID = insAuthor.ID;*/

                        /*  Genre insGen = new Genre                                                  // a megadott szöveget teszi táblába sok-sok duplikáció
                          {
                              Genre1 =  comboBox1.SelectedItem.ToString() //txBxAddGenre.Text
                          };
                          dataContext.Genres.InsertOnSubmit(insGen);
                          dataContext.SubmitChanges();
                          */
                        bool lend, foreign, ebook;
                        lend = foreign = ebook = false;

                        if (chckBxLend.Checked == true) { lend = true; } else lend = false;
                        if (chckBxForeignLang.Checked == true) { foreign = true; } else foreign = false;
                        if (chckBxEbook.Checked == true) { ebook = true; } else ebook = false;

                        Book insBook = new Book
                        {
                            Author_id = insAuthor.ID,
                            Publisher_id = insPub.ID,
                            Genre_id = comboBox1.SelectedIndex,//insGen.ID,                      //komplett szöveg helyett csak sorszám alapján
                            Title = txBxAddTitle.Text,
                            ISBN = txBxAddISBN.Text,
                            Borrowed = lend,
                            Foreign_language = foreign,
                            E_book = ebook,
                            Release_date = Convert.ToInt16(txBxAddPubDate.Text)
                            
                        };

                        dataContext.Books.InsertOnSubmit(insBook);
                        dataContext.SubmitChanges();
            
                        // btnInsert.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($" Hiba az adatok rögzítésében:\n\n {ex}");
            }
        }



        private void DatasToDB()                //adatbevitel v2 (SQL) 
        {
            try
            {
                string checkAuthID = null, checkAuthMax = "", checkPubID = null, checkPubMax = "";
                int lendChk = 0, foreignChk = 0, ebookChk = 0, genId=comboBox1.SelectedIndex;
                if (chckBxEbook.Checked == true) { ebookChk = 1; }
                if (chckBxForeignLang.Checked == true) { foreignChk = 1; }
                if (chckBxLend.Checked == true) { lendChk = 1; }
/*
                sqlDataAdapterAdd.InsertCommand = new SqlCommand("insert into Authors values ('" + txBxAddAuthor.Text + "')", connAdd);
                connAdd.Open();
                sqlDataAdapterAdd.InsertCommand.ExecuteNonQuery();
                connAdd.Close();

                sqlDataAdapterAdd.InsertCommand = new SqlCommand("insert into Publishers values ('" + txBxAddPublisher.Text + "')", connAdd);
                connAdd.Open();
                sqlDataAdapterAdd.InsertCommand.ExecuteNonQuery();
                connAdd.Close();
*/
                connAdd.Open();                                                     //van-e ilyen szerző?
                SqlCommand cmda = new SqlCommand("select count(*) from authors where authors.author='" + txBxAddAuthor.Text + "'", connAdd);
                int counta = (int)cmda.ExecuteScalar();
                connAdd.Close();

                if (counta > 0)
                {
                    connAdd.Open();
                    SqlCommand commandGetAuthID = new SqlCommand("select id from authors where Author='" + txBxAddAuthor.Text + "'", connAdd);
                    SqlDataReader dataReader = commandGetAuthID.ExecuteReader();

                    if (dataReader.Read())                                          //a szerző ID-je
                    {
                        checkAuthID = dataReader.GetValue(0).ToString();

                        //       MessageBox.Show("Auth ID:\t", checkAuthID);
                    }
                    connAdd.Close();
                }

                else                                                                // nincs ilyen szerző, manuális ID növelés
                {
                    sqlDataAdapterAdd.InsertCommand = new SqlCommand("insert into Authors values ('" + txBxAddAuthor.Text + "')", connAdd);
                    connAdd.Open();
                    sqlDataAdapterAdd.InsertCommand.ExecuteNonQuery();
                    connAdd.Close();

                    connAdd.Open();
                    SqlCommand comandGetAuthID = new SqlCommand("select max(id) from authors", connAdd);
                    SqlDataReader dataReader = comandGetAuthID.ExecuteReader();
                    if (dataReader.Read()) checkAuthMax = dataReader.GetValue(0).ToString();
                    connAdd.Close();
                }

                connAdd.Open();
                SqlCommand cmdp = new SqlCommand("select count(*) from publishers where publishers.publisher='" + txBxAddPublisher.Text + "'", connAdd);
                int countp = (int)cmdp.ExecuteScalar();
                connAdd.Close();

                if (countp > 0)
                {
                    connAdd.Open();
                    SqlCommand commandGetPubID = new SqlCommand("select id from publishers where publisher='" + txBxAddPublisher.Text + "'", connAdd);
                    SqlDataReader dataReader = commandGetPubID.ExecuteReader();

                    if (dataReader.Read())                                          //a kiadó ID-je
                    {
                        checkPubID = dataReader.GetValue(0).ToString();

                        // MessageBox.Show("Pub ID:\t", checkPubID);
                    }
                    connAdd.Close();
                }

                else                                                            // nincs ilyen kiadó, manuális ID növelés
                {
                    sqlDataAdapterAdd.InsertCommand = new SqlCommand("insert into Publishers values ('" + txBxAddPublisher.Text + "')", connAdd);
                    connAdd.Open();
                    sqlDataAdapterAdd.InsertCommand.ExecuteNonQuery();
                    connAdd.Close();

                    connAdd.Open();
                    SqlCommand comandGetPubID = new SqlCommand("select max(id) from publishers", connAdd);
                    SqlDataReader dataReader = comandGetPubID.ExecuteReader();
                    if (dataReader.Read()) checkPubMax = dataReader.GetValue(0).ToString();
                    connAdd.Close();
                }
                /*
                            if (chckBxEbook.Checked == true)
                            {
                                sqlDataAdapterAdd.InsertCommand = new SqlCommand("insert into Books (books.E_book)  values ('" + 1 + "') ", connAdd);
                                connAdd.Open();
                                sqlDataAdapterAdd.UpdateCommand.ExecuteNonQuery();
                                connAdd.Close();
                            }

                            if (chckBxForeignLang.Checked == true)
                            {
                                sqlDataAdapterAdd.UpdateCommand = new SqlCommand("insert into Books  (books.Foreign_language)  values ('" + 1 + "')", connAdd);
                                connAdd.Open();
                                sqlDataAdapterAdd.UpdateCommand.ExecuteNonQuery();
                                connAdd.Close();
                            }

                            if (chckBxLend.Checked == true)
                            {
                                sqlDataAdapterAdd.UpdateCommand = new SqlCommand("insert into Books  (books.Borrowed)  values ('" + 1 + "')", connAdd);
                                connAdd.Open();
                                sqlDataAdapterAdd.UpdateCommand.ExecuteNonQuery();
                                connAdd.Close();
                            }
                            */
                if (checkAuthID != null && checkPubID != null)
                {

                    sqlDataAdapterAdd.InsertCommand = new SqlCommand("Insert into Books  (books.Title, books.ISBN, books.Release_date, books.author_id, books.publisher_id, books.genre_id, books.foreign_language, books.e_book, books.borrowed) " +
                        " values ('" + txBxAddTitle.Text + "','" + txBxAddISBN.Text + "','" + txBxAddPubDate.Text + "','" + Convert.ToInt64(checkAuthID) + "','" + Convert.ToInt64(checkPubID) + "','" + (comboBox1.SelectedIndex + 1) + "','" + foreignChk + "','" + ebookChk + "','" + lendChk + "') ", connAdd);
                    connAdd.Open();
                    sqlDataAdapterAdd.InsertCommand.ExecuteNonQuery();
                    connAdd.Close();
                }
                else if (checkAuthID != null && checkPubID == null)
                {
                    sqlDataAdapterAdd.InsertCommand = new SqlCommand("Insert into Books  (books.Title, books.ISBN, books.Release_date, books.author_id, books.publisher_id, books.genre_id, books.foreign_language, books.e_book, books.borrowed)  " +
                        "values ('" + txBxAddTitle.Text + "','" + txBxAddISBN.Text + "','" + txBxAddPubDate.Text + "','" + Convert.ToInt64(checkAuthID) + "','" + Convert.ToInt64(checkPubMax + 1) + "','" + (comboBox1.SelectedIndex+1) + "','" + foreignChk + "','" + ebookChk + "','" + lendChk + "') ", connAdd);
                    connAdd.Open();
                    sqlDataAdapterAdd.InsertCommand.ExecuteNonQuery();
                    connAdd.Close();
                }
                else if (checkAuthID == null && checkPubID != null)
                {
                    sqlDataAdapterAdd.InsertCommand = new SqlCommand("Insert into Books  (books.Title, books.ISBN, books.Release_date, books.author_id, books.publisher_id, books.genre_id, books.foreign_language, books.e_book, books.borrowed)  " +
                        "values ('" + txBxAddTitle.Text + "','" + txBxAddISBN.Text + "','" + txBxAddPubDate.Text + "','" + Convert.ToInt64(checkAuthMax + 1) + "','" + Convert.ToInt64(checkPubID) + "','" + (comboBox1.SelectedIndex + 1) + "','" + foreignChk + "','" + ebookChk + "','" + lendChk + "') ", connAdd);
                    connAdd.Open();
                    sqlDataAdapterAdd.InsertCommand.ExecuteNonQuery();
                    connAdd.Close();
                }
                else
                {
                    sqlDataAdapterAdd.InsertCommand = new SqlCommand("Insert into Books  (books.Title, books.ISBN, books.Release_date, books.author_id, books.publisher_id, books.genre_id, books.foreign_language, books.e_book, books.borrowed) " +
                        " values ('" + txBxAddTitle.Text + "','" + txBxAddISBN.Text + "','" + txBxAddPubDate.Text + "','" + Convert.ToInt64(checkAuthMax + 1) + "','" + Convert.ToInt64(checkAuthMax + 1) + "','" + (genId) + "','" + foreignChk + "','" + ebookChk + "','" + lendChk + "') ", connAdd);
                    connAdd.Open();
                    sqlDataAdapterAdd.InsertCommand.ExecuteNonQuery();
                    connAdd.Close();
                }

                MessageBox.Show(""+genId);
            }
            catch(Exception ex) { MessageBox.Show("Probléma az adatok rögzítésében!"+ ex); }

            }

        private void btnAddFromWindow_Click(object sender, EventArgs e)
        {
            try
            {
              /*  int checkAddDAte = Int16.Parse(txBxAddPubDate.Text);

                if (checkAddDAte < 1000 || checkAddDAte > DateTime.Now.Year || txBxAddISBN.Text == ""|| txBxAddAuthor.Text=="" || txBxAddPublisher.Text==""||txBxAddTitle.Text=="")
                {
                    MessageBox.Show("Elenőrizze az adatokat!");
                }
                else*/
                {
                    //  MessageBox.Show("Jó a dátum!");
                    //   addDataToDB();
                    if (txBxAddAuthor.Text == "" || txBxAddISBN.Text == "" || txBxAddPubDate.Text == "" || txBxAddPublisher.Text == "" || txBxAddTitle.Text == "")
                    {
                        MessageBox.Show("Ellenőrizze az adatokat!");
                    }
                    else
                    {
                        if (Int16.Parse(txBxAddPubDate.Text) < 1000 || Int16.Parse(txBxAddPubDate.Text) > DateTime.Now.Year)
                        {
                            MessageBox.Show("Elenőrize a dátumot!");
                        }
                        else
                        if (comboBox1.SelectedIndex<0)
                        {
                            MessageBox.Show("Válasszon műfajt!");
                        }
                        else
                        {
                            DatasToDB2();
                          
                            CleanAddedDatas();
                            MessageBox.Show("Beillesztés sikeres!");
                            comboBox1.SelectedIndex=-1;
                        }
                    } 
                }
            }
            catch(Exception ex) { MessageBox.Show("Hiba az adatok rögzítésében\n"+ex); }
        }

        private void CleanAddedDatas()
        {
            txBxAddAuthor.Text = txBxAddGenre.Text = txBxAddISBN.Text = txBxAddPubDate.Text = txBxAddPublisher.Text = txBxAddTitle.Text = "";
            chckBxEbook.Checked = chckBxForeignLang.Checked = chckBxLend.Checked = false;
        }

        private void btnCancelWindow_Click(object sender, EventArgs e)
        {
            this.Close();         
        }







        private void DatasToDB2()                //adatbevitel v2 (SQL) 
        {
            try
            {
                string checkAuthID = null, checkAuthMax = "", checkPubID = null, checkPubMax = "";
                int lendChk = 0, foreignChk = 0, ebookChk = 0, genId = comboBox1.SelectedIndex;
                if (chckBxEbook.Checked == true) { ebookChk = 1; }
                if (chckBxForeignLang.Checked == true) { foreignChk = 1; }
                if (chckBxLend.Checked == true) { lendChk = 1; }

                sqlDataAdapterAdd.InsertCommand = new SqlCommand("insert into Authors values ('" + txBxAddAuthor.Text + "')", connAdd);
                connAdd.Open();
                sqlDataAdapterAdd.InsertCommand.ExecuteNonQuery();
                connAdd.Close();

                sqlDataAdapterAdd.InsertCommand = new SqlCommand("insert into Publishers values ('" + txBxAddPublisher.Text + "')", connAdd);
                connAdd.Open();
                sqlDataAdapterAdd.InsertCommand.ExecuteNonQuery();
                connAdd.Close();

                connAdd.Open();                                                     //van-e ilyen szerző?
                SqlCommand cmda = new SqlCommand("select count(*) from authors where authors.author='" + txBxAddAuthor.Text + "'", connAdd);
                int counta = (int)cmda.ExecuteScalar();
                connAdd.Close();

                if (counta > 0)
                {
                    connAdd.Open();
                    SqlCommand commandGetAuthID = new SqlCommand("select id from authors where Author='" + txBxAddAuthor.Text + "'", connAdd);
                    SqlDataReader dataReader = commandGetAuthID.ExecuteReader();

                    if (dataReader.Read())                                          //a szerző ID-je
                    {
                        checkAuthID = dataReader.GetValue(0).ToString();

                        //       MessageBox.Show("Auth ID:\t", checkAuthID);
                    }
                    connAdd.Close();
                }

                else                                                                // nincs ilyen szerző, manuális ID növelés
                {
                    sqlDataAdapterAdd.InsertCommand = new SqlCommand("insert into Authors values ('" + txBxAddAuthor.Text + "')", connAdd);
                    connAdd.Open();
                    sqlDataAdapterAdd.InsertCommand.ExecuteNonQuery();
                    connAdd.Close();

                    connAdd.Open();
                    SqlCommand comandGetAuthID = new SqlCommand("select max(id) from authors", connAdd);
                    SqlDataReader dataReader = comandGetAuthID.ExecuteReader();
                    if (dataReader.Read()) checkAuthMax = dataReader.GetValue(0).ToString();
                    connAdd.Close();
                }

                connAdd.Open();
                SqlCommand cmdp = new SqlCommand("select count(*) from publishers where publishers.publisher='" + txBxAddPublisher.Text + "'", connAdd);
                int countp = (int)cmdp.ExecuteScalar();
                connAdd.Close();

                if (countp > 0)
                {
                    connAdd.Open();
                    SqlCommand commandGetPubID = new SqlCommand("select id from publishers where publisher='" + txBxAddPublisher.Text + "'", connAdd);
                    SqlDataReader dataReader = commandGetPubID.ExecuteReader();

                    if (dataReader.Read())                                          //a kiadó ID-je
                    {
                        checkPubID = dataReader.GetValue(0).ToString();

                        // MessageBox.Show("Pub ID:\t", checkPubID);
                    }
                    connAdd.Close();
                }

                else                                                            // nincs ilyen kiadó, manuális ID növelés
                {
                    sqlDataAdapterAdd.InsertCommand = new SqlCommand("insert into Publishers values ('" + txBxAddPublisher.Text + "')", connAdd);
                    connAdd.Open();
                    sqlDataAdapterAdd.InsertCommand.ExecuteNonQuery();
                    connAdd.Close();

                    connAdd.Open();
                    SqlCommand comandGetPubID = new SqlCommand("select max(id) from publishers", connAdd);
                    SqlDataReader dataReader = comandGetPubID.ExecuteReader();
                    if (dataReader.Read()) checkPubMax = dataReader.GetValue(0).ToString();
                    connAdd.Close();
                }
                /*
                            if (chckBxEbook.Checked == true)
                            {
                                sqlDataAdapterAdd.InsertCommand = new SqlCommand("insert into Books (books.E_book)  values ('" + 1 + "') ", connAdd);
                                connAdd.Open();
                                sqlDataAdapterAdd.UpdateCommand.ExecuteNonQuery();
                                connAdd.Close();
                            }

                            if (chckBxForeignLang.Checked == true)
                            {
                                sqlDataAdapterAdd.UpdateCommand = new SqlCommand("insert into Books  (books.Foreign_language)  values ('" + 1 + "')", connAdd);
                                connAdd.Open();
                                sqlDataAdapterAdd.UpdateCommand.ExecuteNonQuery();
                                connAdd.Close();
                            }

                            if (chckBxLend.Checked == true)
                            {
                                sqlDataAdapterAdd.UpdateCommand = new SqlCommand("insert into Books  (books.Borrowed)  values ('" + 1 + "')", connAdd);
                                connAdd.Open();
                                sqlDataAdapterAdd.UpdateCommand.ExecuteNonQuery();
                                connAdd.Close();
                            }
                            */
                if (checkAuthID != null && checkPubID != null)
                {

                    sqlDataAdapterAdd.InsertCommand = new SqlCommand("Insert into Books  (books.Title, books.ISBN, books.Release_date, books.author_id, books.publisher_id, books.genre_id, books.foreign_language, books.e_book, books.borrowed) " +
                        " values ('" + txBxAddTitle.Text + "','" + txBxAddISBN.Text + "','" + txBxAddPubDate.Text + "','" + Convert.ToInt64(checkAuthID) + "','" + Convert.ToInt64(checkPubID) + "','" + (comboBox1.SelectedIndex + 1) + "','" + foreignChk + "','" + ebookChk + "','" + lendChk + "') ", connAdd);
                    connAdd.Open();
                    sqlDataAdapterAdd.InsertCommand.ExecuteNonQuery();
                    connAdd.Close();
                }
                else if (checkAuthID != null && checkPubID == null)
                {
                    sqlDataAdapterAdd.InsertCommand = new SqlCommand("Insert into Books  (books.Title, books.ISBN, books.Release_date, books.author_id, books.publisher_id, books.genre_id, books.foreign_language, books.e_book, books.borrowed)  " +
                        "values ('" + txBxAddTitle.Text + "','" + txBxAddISBN.Text + "','" + txBxAddPubDate.Text + "','" + Convert.ToInt64(checkAuthID) + "','" + Convert.ToInt64(checkPubMax + 1) + "','" + (comboBox1.SelectedIndex + 1) + "','" + foreignChk + "','" + ebookChk + "','" + lendChk + "') ", connAdd);
                    connAdd.Open();
                    sqlDataAdapterAdd.InsertCommand.ExecuteNonQuery();
                    connAdd.Close();
                }
                else if (checkAuthID == null && checkPubID != null)
                {
                    sqlDataAdapterAdd.InsertCommand = new SqlCommand("Insert into Books  (books.Title, books.ISBN, books.Release_date, books.author_id, books.publisher_id, books.genre_id, books.foreign_language, books.e_book, books.borrowed)  " +
                        "values ('" + txBxAddTitle.Text + "','" + txBxAddISBN.Text + "','" + txBxAddPubDate.Text + "','" + Convert.ToInt64(checkAuthMax + 1) + "','" + Convert.ToInt64(checkPubID) + "','" + (comboBox1.SelectedIndex + 1) + "','" + foreignChk + "','" + ebookChk + "','" + lendChk + "') ", connAdd);
                    connAdd.Open();
                    sqlDataAdapterAdd.InsertCommand.ExecuteNonQuery();
                    connAdd.Close();
                }
                else
                {
                    sqlDataAdapterAdd.InsertCommand = new SqlCommand("Insert into Books  (books.Title, books.ISBN, books.Release_date, books.author_id, books.publisher_id, books.genre_id, books.foreign_language, books.e_book, books.borrowed) " +
                        " values ('" + txBxAddTitle.Text + "','" + txBxAddISBN.Text + "','" + txBxAddPubDate.Text + "','" + Convert.ToInt64(checkAuthMax + 1) + "','" + Convert.ToInt64(checkAuthMax + 1) + "','" + (genId) + "','" + foreignChk + "','" + ebookChk + "','" + lendChk + "') ", connAdd);
                    connAdd.Open();
                    sqlDataAdapterAdd.InsertCommand.ExecuteNonQuery();
                    connAdd.Close();
                }

                MessageBox.Show("" + genId);
            }
            catch (Exception ex) { MessageBox.Show("Probléma az adatok rögzítésében!" + ex); }

        }







    }
}