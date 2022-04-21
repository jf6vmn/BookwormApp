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
        SqlConnection conn = new SqlConnection(@"Data Source=VLZ_ASUS;Initial Catalog=BookwormDB;Integrated Security=True");
        SqlDataAdapter sqlDataAdapterAdd = new SqlDataAdapter();

        private void AddBookFrm_Load(object sender, EventArgs e)
        {
           // using ()
            {
                try
                {
                    conn.Open();
                    SqlCommand comd = conn.CreateCommand();
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
                }

                catch (Exception ex)
                {
                    // write exception info to log or anything else
                    MessageBox.Show("" + ex);
                }
            }
        }

        private void btnAddFromWindow_Click(object sender, EventArgs e)
        {
            SampleDataContext dataContext = new SampleDataContext();

            try
            {
                if (txBxAddISBN.Text == "")
                {
                    MessageBox.Show("Az ISBN mező nem lehet üres!");
                }
                else
                {
                   /* string checkID = "";

                    conn.Close();
                    SqlCommand cmda = new SqlCommand("select count(*) from authors where authors.author='" + txBxAddAuthor.Text + "'", conn);
                    conn.Open();
                    int count = (int)cmda.ExecuteScalar();

                    if (count > 0)
                    {
                        SqlCommand commAuthID = new SqlCommand("select id from authors where author='" + txBxAddAuthor.Text + "'", conn);
                        SqlDataReader dataReader = commAuthID.ExecuteReader();
                        if (dataReader.Read())
                        {
                            checkID = dataReader.GetValue(0).ToString();
                            conn.Close();                           
                        }
                        conn.Open();
                        sqlDataAdapterAdd.UpdateCommand = new SqlCommand("update Books set Books.Author_id  = '" + checkID + "'from Authors inner join[dbo].Books on Books.Author_id = Authors.ID  where books.isbn'" + txBxAddISBN.Text + "'", conn);

                        sqlDataAdapterAdd.UpdateCommand.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show(checkID);


                    }
                    else*/


                    {
                        Author insAuthor = new Author
                        {
                            Author1 = txBxAddAuthor.Text
                        };

                        dataContext.Authors.InsertOnSubmit(insAuthor);
                        dataContext.SubmitChanges();

                        // insAuthor.ID = insAuthor.ID;

                        Publisher insPub = new Publisher
                        {
                            Publisher1 = txBxAddPublisher.Text
                        };

                        dataContext.Publishers.InsertOnSubmit(insPub);
                        dataContext.SubmitChanges();

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


                        CleanAddedDatas();
                        // btnInsert.Enabled = false;
                        MessageBox.Show("Beillesztés sikeres!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($" Hiba az adatok rögzítésében:\n\n {ex}");
            }
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

    }
}