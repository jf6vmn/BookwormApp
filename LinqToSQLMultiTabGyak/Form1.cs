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
using iTextSharp.text.pdf;
using iTextSharp.text;


namespace LinqToSQLMultiTabGyak
{
    public partial class Form1 : Form
    {
        SqlConnection sqlConnection = new SqlConnection("Data Source=VLZ_ASUS;Initial Catalog=bookwormdb;Integrated Security=True");
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //getData();
            tableMergingStuff();
            // btnInsert.Enabled = false;
          //  btnInsUpdate.Enabled = false;
        }

        private void tableMergingStuff()
        {
            try
            {
                #region //adatok beolvasása v1
                /*string mainConnect = ConfigurationManager.ConnectionStrings["LinqToSQLMultiTabGyak.Properties.Settings.BookwormDBConnectionString"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection(mainConnect); 
                string sqlQuery = " select Books.Title, Authors.Author, Genres.Genre, Publishers.Publisher, Books.Release_date, Books.ISBN, Books.Foreign_language,Books.E_book,Books.Borrowed from[dbo].[Books] inner join[dbo].[Authors] on Books.Author_id=Authors.ID inner join[dbo].[Genres] on books.Genre_id= Genres.ID inner join [dbo].[Publishers] on Books.Publisher_id= Publishers.ID";
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                sqlConnection.Open();
                sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                sqlConnection.Close();*/
                #endregion

                //adatok beolvasása v2
                sqlDataAdapter.SelectCommand = new SqlCommand(" select Books.Title as Cím, Authors.Author as Szerző, Genres.Genre as Műfaj, Publishers.Publisher as Kiadó, Books.Release_date as Kiadás_éve, Books.ISBN, Books.Foreign_language as Idegen_nyelv, Books.E_book, Books.Borrowed as Kölcsönadott from[dbo].[Books] inner join[dbo].[Authors] on Books.Author_id=Authors.ID inner join[dbo].[Genres] on books.Genre_id= Genres.ID inner join [dbo].[Publishers] on Books.Publisher_id= Publishers.ID", sqlConnection);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                dataGridView1.DataSource = dataSet.Tables[0];
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Az adatok betöltése nem sikerült:\n\n{ex}");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            tableMergingStuff();          
        }

        private void SearchFromDB()
        {
            SampleDataContext dbContext = new SampleDataContext();
        
            string choosedStuff = comBox.Text;
            try
            {


                if (chckBxEbook.Checked == true)
                {
                    sqlDataAdapter.SelectCommand = new SqlCommand("select  Books.Title as Cím, Authors.Author as Szerző, Genres.Genre as Műfaj, Publishers.Publisher as Kiadó, Books.Release_date as Kiadás_éve, Books.ISBN, Books.Foreign_language as Idegen_nyelv, Books.E_book, Books.Borrowed as Kölcsönadott from[dbo].[Books] inner join[dbo].[Authors] on Books.Author_id=Authors.ID inner join[dbo].[Genres] on books.Genre_id= Genres.ID inner join [dbo].[Publishers] on Books.Publisher_id= Publishers.ID where Books.E_book='" + true + "'", sqlConnection);
                    sqlConnection.Open();
                    sqlDataAdapter.UpdateCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                else
           if (chckBxLend.Checked == true)
                {
                    sqlDataAdapter.SelectCommand = new SqlCommand("select  Books.Title as Cím, Authors.Author as Szerző, Genres.Genre as Műfaj, Publishers.Publisher as Kiadó, Books.Release_date as Kiadás_éve, Books.ISBN, Books.Foreign_language as Idegen_nyelv, Books.E_book, Books.Borrowed as Kölcsönadott from[dbo].[Books] inner join[dbo].[Authors] on Books.Author_id=Authors.ID inner join[dbo].[Genres] on books.Genre_id= Genres.ID inner join [dbo].[Publishers] on Books.Publisher_id= Publishers.ID where Books.Borrowed='" + 1 + "'", sqlConnection);
                    sqlConnection.Open();
                    sqlDataAdapter.SelectCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                else
           if (chckBxForeignLang.Checked == true)
                {
                    sqlDataAdapter.SelectCommand = new SqlCommand("select  Books.Title as Cím, Authors.Author as Szerző, Genres.Genre as Műfaj, Publishers.Publisher as Kiadó, Books.Release_date as Kiadás_éve, Books.ISBN, Books.Foreign_language as Idegen_nyelv, Books.E_book, Books.Borrowed as Kölcsönadott from[dbo].[Books] inner join[dbo].[Authors] on Books.Author_id=Authors.ID inner join[dbo].[Genres] on books.Genre_id= Genres.ID inner join [dbo].[Publishers] on Books.Publisher_id= Publishers.ID where Books.Foreign_language='" + 1 + "'", sqlConnection);
                    sqlConnection.Open();
                    sqlDataAdapter.SelectCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                else
           if (chckBxEbook.Checked = chckBxLend.Checked = true)
                {
                    sqlDataAdapter.SelectCommand = new SqlCommand("select  Books.Title as Cím, Authors.Author as Szerző, Genres.Genre as Műfaj, Publishers.Publisher as Kiadó, Books.Release_date as Kiadás_éve, Books.ISBN, Books.Foreign_language as Idegen_nyelv, Books.E_book, Books.Borrowed as Kölcsönadott from[dbo].[Books] inner join[dbo].[Authors] on Books.Author_id=Authors.ID inner join[dbo].[Genres] on books.Genre_id= Genres.ID inner join [dbo].[Publishers] on Books.Publisher_id= Publishers.ID where Books.E_book='" + true + "' and  Books.Borrowed='" + 1 + "'", sqlConnection);
                    sqlConnection.Open();
                    sqlDataAdapter.UpdateCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                else
           if (chckBxEbook.Checked = chckBxForeignLang.Checked = true)
                {
                    sqlDataAdapter.SelectCommand = new SqlCommand("select  Books.Title as Cím, Authors.Author as Szerző, Genres.Genre as Műfaj, Publishers.Publisher as Kiadó, Books.Release_date as Kiadás_éve, Books.ISBN, Books.Foreign_language as Idegen_nyelv, Books.E_book, Books.Borrowed as Kölcsönadott from[dbo].[Books] inner join[dbo].[Authors] on Books.Author_id=Authors.ID inner join[dbo].[Genres] on books.Genre_id= Genres.ID inner join [dbo].[Publishers] on Books.Publisher_id= Publishers.ID where Books.E_book='" + true + "' and  Books.Foreign_language='" + 1 + "'", sqlConnection);
                    sqlConnection.Open();
                    sqlDataAdapter.UpdateCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                else
           if (chckBxForeignLang.Checked = chckBxLend.Checked = true)
                {
                    sqlDataAdapter.SelectCommand = new SqlCommand("select  Books.Title as Cím, Authors.Author as Szerző, Genres.Genre as Műfaj, Publishers.Publisher as Kiadó, Books.Release_date as Kiadás_éve, Books.ISBN, Books.Foreign_language as Idegen_nyelv, Books.E_book, Books.Borrowed as Kölcsönadott from[dbo].[Books] inner join[dbo].[Authors] on Books.Author_id=Authors.ID inner join[dbo].[Genres] on books.Genre_id= Genres.ID inner join [dbo].[Publishers] on Books.Publisher_id= Publishers.ID where Books.Borrowed='" + 1 + "' and  Books.Foreign_language='" + 1 + "'", sqlConnection);
                    sqlConnection.Open();
                    sqlDataAdapter.UpdateCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                else
           if (chckBxLend.Checked = chckBxForeignLang.Checked = chckBxEbook.Checked = true)
                {
                    sqlDataAdapter.SelectCommand = new SqlCommand("select  Books.Title as Cím, Authors.Author as Szerző, Genres.Genre as Műfaj, Publishers.Publisher as Kiadó, Books.Release_date as Kiadás_éve, Books.ISBN, Books.Foreign_language as Idegen_nyelv, Books.E_book, Books.Borrowed as Kölcsönadott from[dbo].[Books] inner join[dbo].[Authors] on Books.Author_id=Authors.ID inner join[dbo].[Genres] on books.Genre_id= Genres.ID inner join [dbo].[Publishers] on Books.Publisher_id= Publishers.ID where Books.E_book='" + true + "' and  Books.Foreign_language='" + 1 + "' and Books.Borrowed='" + 1 + "'", sqlConnection);
                    sqlConnection.Open();
                    sqlDataAdapter.UpdateCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                else
                {












                    switch (choosedStuff)
                    {
                        case "Cím":
                            {
                                var query = from book in dbContext.Books
                                            where book.Title.Contains(txBxSearch.Text)
                                            join auth in dbContext.Authors on book.Author_id equals auth.ID
                                            join pub in dbContext.Publishers on book.Publisher_id equals pub.ID
                                            join gen in dbContext.Genres on book.Genre_id equals gen.ID
                                            //   == like txBxSearch.Text
                                            orderby book.Title
                                            select new { book.Title, auth.Author1, pub.Publisher1, book.Release_date, gen.Genre1, book.ISBN, book.E_book, book.Foreign_language, book.Borrowed };


                                /* var queryDisp = from bok in dbContext.Books
                                             join auth in dbContext.Authors on bok.Author_id equals auth.ID
                                             select new { bok.Title, auth.Author1, bok.Release_date,bok.ISBN};*/
                                dataGridView1.DataSource = query;

                                break;
                            }

                        case "ISBN":
                            {
                                var query = from isbn in dbContext.Books
                                            where isbn.ISBN.Contains(txBxSearch.Text)
                                            join auth in dbContext.Authors on isbn.Author_id equals auth.ID
                                            join pub in dbContext.Publishers on isbn.Publisher_id equals pub.ID
                                            join gen in dbContext.Genres on isbn.Genre_id equals gen.ID
                                            //   == like txBxSearch.Text
                                            orderby isbn.Title
                                            select new { isbn.Title, auth.Author1, pub.Publisher1, isbn.Release_date, gen.Genre1, isbn.ISBN, isbn.E_book, isbn.Foreign_language, isbn.Borrowed };

                                dataGridView1.DataSource = query;

                                break;
                            }

                        case "Kiadás éve":                                //konverzió macera mindkét esetben
                            {
                                //    int relDate = Convert.ToInt16(txBxSearch.Text);
                                int relDate = Convert.ToInt16(txBxSearch.Text);
                                var query = from pubDate in dbContext.Books
                                            where pubDate.Release_date.Equals(relDate)
                                            join auth in dbContext.Authors on pubDate.Author_id equals auth.ID
                                            join pub in dbContext.Publishers on pubDate.Publisher_id equals pub.ID
                                            join gen in dbContext.Genres on pubDate.Genre_id equals gen.ID
                                            //   == like txBxSearch.Text
                                            orderby pubDate.Title
                                            select new { pubDate.Title, auth.Author1, pub.Publisher1, pubDate.Release_date, gen.Genre1, pubDate.ISBN, pubDate.E_book, pubDate.Foreign_language, pubDate.Borrowed };

                                dataGridView1.DataSource = query;
                                //     int pickedDate = Convert.ToInt16(txBxSearch.Text.ToString());
                                //     sqlDataAdapter.SelectCommand = new SqlCommand("select Books.Title, Authors.Author, Genres.Genre, Publishers.Publisher, Books.Release_date, Books.ISBN, Books.Foreign_language,Books.E_book,Books.Borrowed from[dbo].[Books] inner join[dbo].[Authors] on Books.Author_id=Authors.ID inner join[dbo].[Genres] on books.Genre_id= Genres.ID inner join [dbo].[Publishers] on Books.Publisher_id= Publishers.ID where Books.Release_date='" + pickedDate + "'", sqlConnection);

                                // MessageBox.Show("Fejlesztés alatt!");
                                break;
                            }

                        case "Szerző":
                            {

                                var query = from auth in dbContext.Authors
                                            where auth.Author1.Contains(txBxSearch.Text)
                                            join book in dbContext.Books on auth.ID equals book.Author_id
                                            join pub in dbContext.Publishers on book.Publisher_id equals pub.ID
                                            join gen in dbContext.Genres on book.Genre_id equals gen.ID
                                            //   == like txBxSearch.Text
                                            //       orderby book.Title
                                            select new { book.Title, auth.Author1, pub.Publisher1, book.Release_date, gen.Genre1, book.ISBN, book.E_book, book.Foreign_language, book.Borrowed };


                                /* var queryDisp = from bok in dbContext.Books
                                             join auth in dbContext.Authors on bok.Author_id equals auth.ID
                                             select new { bok.Title, auth.Author1, bok.Release_date,bok.ISBN};
                                dataGridView1.DataSource = query;


                                dataGridView1.DataSource = from book in dbContext.Authors
                                                           where book.Author1 == txBxSearch.Text

                                                           select book;*/
                                dataGridView1.DataSource = query;
                                break;
                            }
                        case "Műfaj":
                            {
                                var query = from gen in dbContext.Genres
                                            where gen.Genre1.Contains(txBxSearch.Text)
                                            join book in dbContext.Books on gen.ID equals book.Genre_id
                                            join pub in dbContext.Publishers on book.Publisher_id equals pub.ID
                                            join auth in dbContext.Authors on book.Author_id equals auth.ID
                                            select new { book.Title, auth.Author1, pub.Publisher1, book.Release_date, gen.Genre1, book.ISBN, book.E_book, book.Foreign_language, book.Borrowed };
                                dataGridView1.DataSource = query;
                                break;
                            }
                        case "Kiadó":
                            {
                                var query = from pub in dbContext.Publishers
                                            where pub.Publisher1.Contains(txBxSearch.Text)
                                            join book in dbContext.Books on pub.ID equals book.Publisher_id
                                            join gen in dbContext.Genres on book.Genre_id equals gen.ID
                                            join auth in dbContext.Authors on book.Author_id equals auth.ID
                                            select new { book.Title, auth.Author1, pub.Publisher1, book.Release_date, gen.Genre1, book.ISBN, book.E_book, book.Foreign_language, book.Borrowed };
                                dataGridView1.DataSource = query;
                                break;
                            }

                        default:
                            // MessageBox.Show("Válasszon a listából / adja meg a keresensdő kifejezést!");
                            break;
                    }
                }
                #region  //checkbox-ok  állapota
              /*  if (chckBxEbook.Checked == true)
                {
                    sqlDataAdapter.SelectCommand = new SqlCommand("select  Books.Title as Cím, Authors.Author as Szerző, Genres.Genre as Műfaj, Publishers.Publisher as Kiadó, Books.Release_date as Kiadás_éve, Books.ISBN, Books.Foreign_language as Idegen_nyelv, Books.E_book, Books.Borrowed as Kölcsönadott from[dbo].[Books] inner join[dbo].[Authors] on Books.Author_id=Authors.ID inner join[dbo].[Genres] on books.Genre_id= Genres.ID inner join [dbo].[Publishers] on Books.Publisher_id= Publishers.ID where Books.E_book='" + true + "'", sqlConnection);
                    sqlConnection.Open();
                    sqlDataAdapter.UpdateCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                if (chckBxLend.Checked == true)
                {
                    sqlDataAdapter.SelectCommand = new SqlCommand("select  Books.Title as Cím, Authors.Author as Szerző, Genres.Genre as Műfaj, Publishers.Publisher as Kiadó, Books.Release_date as Kiadás_éve, Books.ISBN, Books.Foreign_language as Idegen_nyelv, Books.E_book, Books.Borrowed as Kölcsönadott from[dbo].[Books] inner join[dbo].[Authors] on Books.Author_id=Authors.ID inner join[dbo].[Genres] on books.Genre_id= Genres.ID inner join [dbo].[Publishers] on Books.Publisher_id= Publishers.ID where Books.Borrowed='" + 1 + "'", sqlConnection);
                    sqlConnection.Open();
                    sqlDataAdapter.SelectCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                if(chckBxForeignLang.Checked==true)
                {
                    sqlDataAdapter.SelectCommand = new SqlCommand("select  Books.Title as Cím, Authors.Author as Szerző, Genres.Genre as Műfaj, Publishers.Publisher as Kiadó, Books.Release_date as Kiadás_éve, Books.ISBN, Books.Foreign_language as Idegen_nyelv, Books.E_book, Books.Borrowed as Kölcsönadott from[dbo].[Books] inner join[dbo].[Authors] on Books.Author_id=Authors.ID inner join[dbo].[Genres] on books.Genre_id= Genres.ID inner join [dbo].[Publishers] on Books.Publisher_id= Publishers.ID where Books.Foreign_language='" + 1 + "'", sqlConnection);
                    sqlConnection.Open();
                    sqlDataAdapter.SelectCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }

                if(chckBxEbook.Checked=chckBxLend.Checked=true)
                {
                    sqlDataAdapter.SelectCommand = new SqlCommand("select  Books.Title as Cím, Authors.Author as Szerző, Genres.Genre as Műfaj, Publishers.Publisher as Kiadó, Books.Release_date as Kiadás_éve, Books.ISBN, Books.Foreign_language as Idegen_nyelv, Books.E_book, Books.Borrowed as Kölcsönadott from[dbo].[Books] inner join[dbo].[Authors] on Books.Author_id=Authors.ID inner join[dbo].[Genres] on books.Genre_id= Genres.ID inner join [dbo].[Publishers] on Books.Publisher_id= Publishers.ID where Books.E_book='" + true + "' and  Books.Borrowed='" + 1 + "'", sqlConnection);
                    sqlConnection.Open();
                    sqlDataAdapter.UpdateCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }

                if (chckBxEbook.Checked=chckBxForeignLang.Checked=true)
                {
                    sqlDataAdapter.SelectCommand = new SqlCommand("select  Books.Title as Cím, Authors.Author as Szerző, Genres.Genre as Műfaj, Publishers.Publisher as Kiadó, Books.Release_date as Kiadás_éve, Books.ISBN, Books.Foreign_language as Idegen_nyelv, Books.E_book, Books.Borrowed as Kölcsönadott from[dbo].[Books] inner join[dbo].[Authors] on Books.Author_id=Authors.ID inner join[dbo].[Genres] on books.Genre_id= Genres.ID inner join [dbo].[Publishers] on Books.Publisher_id= Publishers.ID where Books.E_book='" + true + "' and  Books.Foreign_language='" + 1 + "'", sqlConnection);
                    sqlConnection.Open();
                    sqlDataAdapter.UpdateCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }

                if(chckBxForeignLang.Checked=chckBxLend.Checked=true)
                {
                    sqlDataAdapter.SelectCommand = new SqlCommand("select  Books.Title as Cím, Authors.Author as Szerző, Genres.Genre as Műfaj, Publishers.Publisher as Kiadó, Books.Release_date as Kiadás_éve, Books.ISBN, Books.Foreign_language as Idegen_nyelv, Books.E_book, Books.Borrowed as Kölcsönadott from[dbo].[Books] inner join[dbo].[Authors] on Books.Author_id=Authors.ID inner join[dbo].[Genres] on books.Genre_id= Genres.ID inner join [dbo].[Publishers] on Books.Publisher_id= Publishers.ID where Books.Borrowed='" + 1 + "' and  Books.Foreign_language='" + 1 + "'", sqlConnection);
                    sqlConnection.Open();
                    sqlDataAdapter.UpdateCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                
                if(chckBxLend.Checked=chckBxForeignLang.Checked=chckBxEbook.Checked=true)
                {
                    sqlDataAdapter.SelectCommand = new SqlCommand("select  Books.Title as Cím, Authors.Author as Szerző, Genres.Genre as Műfaj, Publishers.Publisher as Kiadó, Books.Release_date as Kiadás_éve, Books.ISBN, Books.Foreign_language as Idegen_nyelv, Books.E_book, Books.Borrowed as Kölcsönadott from[dbo].[Books] inner join[dbo].[Authors] on Books.Author_id=Authors.ID inner join[dbo].[Genres] on books.Genre_id= Genres.ID inner join [dbo].[Publishers] on Books.Publisher_id= Publishers.ID where Books.E_book='" + true + "' and  Books.Foreign_language='" + 1 + "' and Books.Borrowed='" +1+"'", sqlConnection);
                    sqlConnection.Open();
                    sqlDataAdapter.UpdateCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }*/

                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show($" A keresés skiertelen volt!\n\n {ex}");
            }
        }

        private void ChechkboxCheckingIfs()
        {
            if (chckBxEbook.Checked == true)
            {
                sqlDataAdapter.SelectCommand = new SqlCommand("select  Books.Title as Cím, Authors.Author as Szerző, Genres.Genre as Műfaj, Publishers.Publisher as Kiadó, Books.Release_date as Kiadás_éve, Books.ISBN, Books.Foreign_language as Idegen_nyelv, Books.E_book, Books.Borrowed as Kölcsönadott from[dbo].[Books] inner join[dbo].[Authors] on Books.Author_id=Authors.ID inner join[dbo].[Genres] on books.Genre_id= Genres.ID inner join [dbo].[Publishers] on Books.Publisher_id= Publishers.ID where Books.E_book='" + true + "'", sqlConnection);
                sqlConnection.Open();
                sqlDataAdapter.UpdateCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            else
            if (chckBxLend.Checked == true)
            {
                sqlDataAdapter.SelectCommand = new SqlCommand("select  Books.Title as Cím, Authors.Author as Szerző, Genres.Genre as Műfaj, Publishers.Publisher as Kiadó, Books.Release_date as Kiadás_éve, Books.ISBN, Books.Foreign_language as Idegen_nyelv, Books.E_book, Books.Borrowed as Kölcsönadott from[dbo].[Books] inner join[dbo].[Authors] on Books.Author_id=Authors.ID inner join[dbo].[Genres] on books.Genre_id= Genres.ID inner join [dbo].[Publishers] on Books.Publisher_id= Publishers.ID where Books.Borrowed='" + 1 + "'", sqlConnection);
                sqlConnection.Open();
                sqlDataAdapter.SelectCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            else
            if (chckBxForeignLang.Checked == true)
            {
                sqlDataAdapter.SelectCommand = new SqlCommand("select  Books.Title as Cím, Authors.Author as Szerző, Genres.Genre as Műfaj, Publishers.Publisher as Kiadó, Books.Release_date as Kiadás_éve, Books.ISBN, Books.Foreign_language as Idegen_nyelv, Books.E_book, Books.Borrowed as Kölcsönadott from[dbo].[Books] inner join[dbo].[Authors] on Books.Author_id=Authors.ID inner join[dbo].[Genres] on books.Genre_id= Genres.ID inner join [dbo].[Publishers] on Books.Publisher_id= Publishers.ID where Books.Foreign_language='" + 1 + "'", sqlConnection);
                sqlConnection.Open();
                sqlDataAdapter.SelectCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            else
            if (chckBxEbook.Checked = chckBxLend.Checked = true)
            {
                sqlDataAdapter.SelectCommand = new SqlCommand("select  Books.Title as Cím, Authors.Author as Szerző, Genres.Genre as Műfaj, Publishers.Publisher as Kiadó, Books.Release_date as Kiadás_éve, Books.ISBN, Books.Foreign_language as Idegen_nyelv, Books.E_book, Books.Borrowed as Kölcsönadott from[dbo].[Books] inner join[dbo].[Authors] on Books.Author_id=Authors.ID inner join[dbo].[Genres] on books.Genre_id= Genres.ID inner join [dbo].[Publishers] on Books.Publisher_id= Publishers.ID where Books.E_book='" + true + "' and  Books.Borrowed='" + 1 + "'", sqlConnection);
                sqlConnection.Open();
                sqlDataAdapter.UpdateCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            else
            if (chckBxEbook.Checked = chckBxForeignLang.Checked = true)
            {
                sqlDataAdapter.SelectCommand = new SqlCommand("select  Books.Title as Cím, Authors.Author as Szerző, Genres.Genre as Műfaj, Publishers.Publisher as Kiadó, Books.Release_date as Kiadás_éve, Books.ISBN, Books.Foreign_language as Idegen_nyelv, Books.E_book, Books.Borrowed as Kölcsönadott from[dbo].[Books] inner join[dbo].[Authors] on Books.Author_id=Authors.ID inner join[dbo].[Genres] on books.Genre_id= Genres.ID inner join [dbo].[Publishers] on Books.Publisher_id= Publishers.ID where Books.E_book='" + true + "' and  Books.Foreign_language='" + 1 + "'", sqlConnection);
                sqlConnection.Open();
                sqlDataAdapter.UpdateCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            else
            if (chckBxForeignLang.Checked = chckBxLend.Checked = true)
            {
                sqlDataAdapter.SelectCommand = new SqlCommand("select  Books.Title as Cím, Authors.Author as Szerző, Genres.Genre as Műfaj, Publishers.Publisher as Kiadó, Books.Release_date as Kiadás_éve, Books.ISBN, Books.Foreign_language as Idegen_nyelv, Books.E_book, Books.Borrowed as Kölcsönadott from[dbo].[Books] inner join[dbo].[Authors] on Books.Author_id=Authors.ID inner join[dbo].[Genres] on books.Genre_id= Genres.ID inner join [dbo].[Publishers] on Books.Publisher_id= Publishers.ID where Books.Borrowed='" + 1 + "' and  Books.Foreign_language='" + 1 + "'", sqlConnection);
                sqlConnection.Open();
                sqlDataAdapter.UpdateCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            else
            if (chckBxLend.Checked = chckBxForeignLang.Checked = chckBxEbook.Checked = true)
            {
                sqlDataAdapter.SelectCommand = new SqlCommand("select  Books.Title as Cím, Authors.Author as Szerző, Genres.Genre as Műfaj, Publishers.Publisher as Kiadó, Books.Release_date as Kiadás_éve, Books.ISBN, Books.Foreign_language as Idegen_nyelv, Books.E_book, Books.Borrowed as Kölcsönadott from[dbo].[Books] inner join[dbo].[Authors] on Books.Author_id=Authors.ID inner join[dbo].[Genres] on books.Genre_id= Genres.ID inner join [dbo].[Publishers] on Books.Publisher_id= Publishers.ID where Books.E_book='" + true + "' and  Books.Foreign_language='" + 1 + "' and Books.Borrowed='" + 1 + "'", sqlConnection);
                sqlConnection.Open();
                sqlDataAdapter.UpdateCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        DataSet dataSetTask = new DataSet();
        DataGridView gridViewThread = new DataGridView();

        private void SearchFromDBThread(string listChosenOne, string searchTex)
        {
            string typeChosen = listChosenOne;
            string wantedTex = searchTex;
            
            SampleDataContext dbContext = new SampleDataContext();

            string choosedStuff = typeChosen;
            try
            {
                  switch (choosedStuff)
                  {
                      case "Cím":
                          {
                              var query = from book in dbContext.Books
                                          where book.Title.Contains(wantedTex)
                                          join auth in dbContext.Authors on book.Author_id equals auth.ID
                                          join pub in dbContext.Publishers on book.Publisher_id equals pub.ID
                                          join gen in dbContext.Genres on book.Genre_id equals gen.ID
                                          orderby book.Title
                                          select new { book.Title, auth.Author1, pub.Publisher1, book.Release_date, gen.Genre1, book.ISBN, book.E_book, book.Foreign_language, book.Borrowed };
                              gridViewThread.DataSource = query;
                              break;
                          }

                      case "ISBN":
                          {
                              var query = from isbn in dbContext.Books
                                          where isbn.ISBN.Contains(wantedTex)
                                          join auth in dbContext.Authors on isbn.Author_id equals auth.ID
                                          join pub in dbContext.Publishers on isbn.Publisher_id equals pub.ID
                                          join gen in dbContext.Genres on isbn.Genre_id equals gen.ID
                                          orderby isbn.Title
                                          select new { isbn.Title, auth.Author1, pub.Publisher1, isbn.Release_date, gen.Genre1, isbn.ISBN, isbn.E_book, isbn.Foreign_language, isbn.Borrowed };

                             gridViewThread.DataSource = query;

                              break;
                          }

                      case "Kiadás éve":
                          {

                              int relDate = Convert.ToInt16(wantedTex);
                              var query = from pubDate in dbContext.Books
                                          where pubDate.Release_date.Equals(relDate)
                                          join auth in dbContext.Authors on pubDate.Author_id equals auth.ID
                                          join pub in dbContext.Publishers on pubDate.Publisher_id equals pub.ID
                                          join gen in dbContext.Genres on pubDate.Genre_id equals gen.ID
                                          orderby pubDate.Title
                                          select new { pubDate.Title, auth.Author1, pub.Publisher1, pubDate.Release_date, gen.Genre1, pubDate.ISBN, pubDate.E_book, pubDate.Foreign_language, pubDate.Borrowed };

                              gridViewThread.DataSource = query;
                              break;
                          }

                      case "Szerző":
                          {
                              var query = from auth in dbContext.Authors
                                          where auth.Author1.Contains(wantedTex)
                                          join book in dbContext.Books on auth.ID equals book.Author_id
                                          join pub in dbContext.Publishers on book.Publisher_id equals pub.ID
                                          join gen in dbContext.Genres on book.Genre_id equals gen.ID
                                          //   == like txBxSearch.Text
                                          //       orderby book.Title
                                          select new { book.Title, auth.Author1, pub.Publisher1, book.Release_date, gen.Genre1, book.ISBN, book.E_book, book.Foreign_language, book.Borrowed };


                              var queryDisp = from bok in dbContext.Books
                                           join auth in dbContext.Authors on bok.Author_id equals auth.ID
                                           select new { bok.Title, auth.Author1, bok.Release_date,bok.ISBN};
                              gridViewThread.DataSource = query;


                              gridViewThread.DataSource = from book in dbContext.Authors
                                                         where book.Author1 ==wantedTex

                                                         select book;
                              gridViewThread.DataSource = query;
                              break;
                          }
                      case "Műfaj":
                          {
                              var query = from gen in dbContext.Genres
                                          where gen.Genre1.Contains(wantedTex)
                                          join book in dbContext.Books on gen.ID equals book.Genre_id
                                          join pub in dbContext.Publishers on book.Publisher_id equals pub.ID
                                          join auth in dbContext.Authors on book.Author_id equals auth.ID
                                          select new { book.Title, auth.Author1, pub.Publisher1, book.Release_date, gen.Genre1, book.ISBN, book.E_book, book.Foreign_language, book.Borrowed };
                              gridViewThread.DataSource = query;
                              break;
                          }
                      case "Kiadó":
                          {
                              var query = from pub in dbContext.Publishers
                                          where pub.Publisher1.Contains(wantedTex)
                                          join book in dbContext.Books on pub.ID equals book.Publisher_id
                                          join gen in dbContext.Genres on book.Genre_id equals gen.ID
                                          join auth in dbContext.Authors on book.Author_id equals auth.ID
                                          select new { book.Title, auth.Author1, pub.Publisher1, book.Release_date, gen.Genre1, book.ISBN, book.E_book, book.Foreign_language, book.Borrowed };
                              gridViewThread.DataSource = query;
                              break;
                          }

                    case "Idegen nyelv":
                        {
                            var query = from foreignLang in dbContext.Books
                                        where foreignLang.Foreign_language==true
                                        join book in dbContext.Books on foreignLang.ID equals book.Publisher_id
                                        join gen in dbContext.Genres on book.Genre_id equals gen.ID
                                        join auth in dbContext.Authors on book.Author_id equals auth.ID
                                        select new { book.Title, auth.Author1, foreignLang.Publisher, book.Release_date, gen.Genre1, book.ISBN, book.E_book, book.Foreign_language, book.Borrowed };
                            gridViewThread.DataSource = query;
                            break;
                        }

                    case "E-book":
                        {
                            var query = from pub in dbContext.Publishers
                                        where pub.Publisher1.Contains(wantedTex)
                                        join book in dbContext.Books on pub.ID equals book.Publisher_id
                                        join gen in dbContext.Genres on book.Genre_id equals gen.ID
                                        join auth in dbContext.Authors on book.Author_id equals auth.ID
                                        select new { book.Title, auth.Author1, pub.Publisher1, book.Release_date, gen.Genre1, book.ISBN, book.E_book, book.Foreign_language, book.Borrowed };
                            gridViewThread.DataSource = query;
                            break;
                        }

                    case "Kölcsönadott":
                        {
                            var query = from pub in dbContext.Publishers
                                        where pub.Publisher1.Contains(wantedTex)
                                        join book in dbContext.Books on pub.ID equals book.Publisher_id
                                        join gen in dbContext.Genres on book.Genre_id equals gen.ID
                                        join auth in dbContext.Authors on book.Author_id equals auth.ID
                                        select new { book.Title, auth.Author1, pub.Publisher1, book.Release_date, gen.Genre1, book.ISBN, book.E_book, book.Foreign_language, book.Borrowed };
                            gridViewThread.DataSource = query;
                            break;
                        }
                        

                    default:
                          // MessageBox.Show("Válasszon a listából / adja meg a keresensdő kifejezést!");
                          break;                      
                  }

            }
            catch (Exception ex)
            {
                MessageBox.Show($" A keresés skiertelen volt!\n\n {ex}");
            }
        }


        private void srcCheckboxes()
        {       

            if (chckBxEbook.Checked == true)
            {
                sqlDataAdapter.SelectCommand = new SqlCommand("select  Books.Title as Cím, Authors.Author as Szerző, Genres.Genre as Műfaj, Publishers.Publisher as Kiadó, Books.Release_date as Kiadás_éve, Books.ISBN, Books.Foreign_language as Idegen_nyelv, Books.E_book, Books.Borrowed as Kölcsönadott from[dbo].[Books] inner join[dbo].[Authors] on Books.Author_id=Authors.ID inner join[dbo].[Genres] on books.Genre_id= Genres.ID inner join [dbo].[Publishers] on Books.Publisher_id= Publishers.ID where Books.E_book='" + 1 + "'", sqlConnection);
                sqlConnection.Open();
                sqlDataAdapter.SelectCommand.ExecuteNonQuery();
                sqlConnection.Close();

            }
            if (chckBxLend.Checked == true)
            {
                sqlDataAdapter.SelectCommand = new SqlCommand("select  Books.Title as Cím, Authors.Author as Szerző, Genres.Genre as Műfaj, Publishers.Publisher as Kiadó, Books.Release_date as Kiadás_éve, Books.ISBN, Books.Foreign_language as Idegen_nyelv, Books.E_book, Books.Borrowed as Kölcsönadott from[dbo].[Books] inner join[dbo].[Authors] on Books.Author_id=Authors.ID inner join[dbo].[Genres] on books.Genre_id= Genres.ID inner join [dbo].[Publishers] on Books.Publisher_id= Publishers.ID where Books.Borrowed='" + 1 + "'", sqlConnection);
                sqlConnection.Open();
                sqlDataAdapter.SelectCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            if (chckBxForeignLang.Checked == true)
            {
                sqlDataAdapter.SelectCommand = new SqlCommand("select  Books.Title as Cím, Authors.Author as Szerző, Genres.Genre as Műfaj, Publishers.Publisher as Kiadó, Books.Release_date as Kiadás_éve, Books.ISBN, Books.Foreign_language as Idegen_nyelv, Books.E_book, Books.Borrowed as Kölcsönadott from[dbo].[Books] inner join[dbo].[Authors] on Books.Author_id=Authors.ID inner join[dbo].[Genres] on books.Genre_id= Genres.ID inner join [dbo].[Publishers] on Books.Publisher_id= Publishers.ID where Books.Foreign_language='" + 1 + "'", sqlConnection);
                sqlConnection.Open();
                sqlDataAdapter.SelectCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            DataSet dataSetSrc = new DataSet();
            sqlDataAdapter.Fill(dataSetSrc);
            dataGridView1.DataSource = dataSetSrc.Tables[0];
        }

   /*     private void FixDaGrid()
        {
            DataGridView dataGridHelpMe = new DataGridView();
           dataGridHelpMe.DataSource  = gridViewThread.DataSource;
            dataGridView1.DataSource = dataGridHelpMe.DataSource;
        }
        */
        private void btnSearch_Click(object sender, EventArgs e)
        {
           //  SearchFromDB();                                            //működik, de egy szálon megy

            string comboxBlabla = comBox.SelectedItem.ToString();     //szálas, már majdnem működik, hibaüzenet nincs, reszelés folyamatban
            string searchboxBlabla=txBxSearch.Text;
            
            Task taskSrc=new Task(() => { SearchFromDBThread(comboxBlabla, searchboxBlabla); this.dataGridView1.Invoke((MethodInvoker)delegate { this.dataGridView1.DataSource = gridViewThread.DataSource; }); });
            taskSrc.Start();
            if (taskSrc.IsCanceled == true || taskSrc.IsFaulted) { MessageBox.Show("Hiba a keresés folyamán!"); }

            /*  if (chckBxEbook.Checked == true)
              {
                  for (int i = 0; i < dataGridView1.RowCount; i++)
                  {
                      if(dataGridView1.SelectedCells[6].Value.ToString()!="true")
                      {
                          dataGridView1.SelectedCells[6].Value = true;
                      }
                  }
              }*/

            //   srcCheckboxes();
         //   ChechkboxCheckingIfs();
        }
        

        private void btnInsert_Click(object sender, EventArgs e)
        {
            #region //hozzáadás a main formon
            /* SampleDataContext dataContext = new SampleDataContext();


            try
            {
                if (txBxInsertISBN.Text == "")
                {
                    MessageBox.Show("Az ISBN mező nem lehet üres!");
                }
                else {
                    Author insAuthor = new Author
                    {
                        Author1 = txBxInsertAuthor.Text
                    };

                    dataContext.Authors.InsertOnSubmit(insAuthor);
                    dataContext.SubmitChanges();

                    // insAuthor.ID = insAuthor.ID;

                    Publisher insPub = new Publisher
                    {
                        Publisher1 = txBxInsertPublisher.Text
                    };

                    dataContext.Publishers.InsertOnSubmit(insPub);
                    dataContext.SubmitChanges();

                    Genre insGen = new Genre
                    {
                        Genre1 = txBxInsertGenre.Text
                    };
                    dataContext.Genres.InsertOnSubmit(insGen);
                    dataContext.SubmitChanges();

                    bool lend = false;
                    if (chckBxLend.Checked == true) { lend = true; } else lend = false;
                    Book insBook = new Book
                    {
                        Author_id = insAuthor.ID,
                        Publisher_id = insPub.ID,
                        Genre_id = insGen.ID,
                        Title = txBxInsertTitle.Text,
                        ISBN = txBxInsertISBN.Text,
                        Borrowed = lend,

                    };

                    dataContext.Books.InsertOnSubmit(insBook);
                    dataContext.SubmitChanges();
                    tableMergingStuff();

                    cleanInsertedDatas();
                    // btnInsert.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($" Hiba az adatok rögzítésében:\n\n {ex}");
            }*/
            #endregion

            AddBookFrm addBook = new AddBookFrm();
            addBook.Show();
        }

        #region //beírt adat törlése a szövegmezőből
        /*    private void cleanInsertedDatas()
            {
                txBxInsertISBN.Text = txBxInsertTitle.Text = txBxInsertPublisher.Text = txBxInsertAuthor.Text = txBxInsertGenre.Text = "";
            }
        */
        #endregion

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {   // cascade delete aktív az adatbázisban!!
                sqlDataAdapter.DeleteCommand = new SqlCommand("delete Books from  [dbo].[Books] where Books.ISBN = '" + dataGridView1.SelectedCells[5].Value.ToString() + "'", sqlConnection);

                #region //cascade nélküli változat kezdete
                /*sqlDataAdapter.DeleteCommand = new SqlCommand("delete Books from  [dbo].[Books] inner join[dbo].[Authors] on Books.Author_id = Authors.ID" +
                      "inner join[dbo].[Genres] on books.Genre_id = Genres.ID inner join[dbo].[Publishers] on Books.Publisher_id = Publishers.ID"+
                      "where Books.ISBN = '"+ dataGridView1.SelectedCells[5].Value.ToString()+"'", sqlConnection);*/
                #endregion

                sqlConnection.Open();
                sqlDataAdapter.DeleteCommand.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Sikeres törlés!");
                tableMergingStuff(); //grid frissítése
            }

            catch (Exception ex)
            {
                MessageBox.Show("Hiba a törlés folyamán:\n" + ex);
            }
        }

        private void menuStripExporAsTxt_Click(object sender, EventArgs e)
        {
            SaveToTxt();
        }
        private void SaveToTxt() //mentés txt-be
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = ("egyszerű szöveg (*.txt) |*.txt");
            saveFile.FileName = "névtelen.txt";
            bool fileError = false;

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                if (!fileError)
                {
                    try
                    {
                        int columnCount = dataGridView1.Columns.Count;
                        string columnNames = "";
                        string[] outputCSV = new string[dataGridView1.Rows.Count + 1];

                        for (int i = 0; i < columnCount; i++)
                        {
                            columnNames += dataGridView1.Columns[i].HeaderText.ToString() + "\t";
                        }
                        outputCSV[0] += columnNames;

                        for (int i = 1; i - 1 < dataGridView1.Rows.Count; i++)
                        {
                            for (int j = 0; j < columnCount; j++)
                            {
                                outputCSV[i] += dataGridView1.Rows[i - 1].Cells[j].Value.ToString() + "\t";
                            }
                        }

                        File.WriteAllLines(saveFile.FileName, outputCSV, Encoding.UTF8);
                        MessageBox.Show("A mentés sikeres!");
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Hiba történt:\n " + ex.Message);
                    }
                }
            }
        }

        private void menuStripExportCSV_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = ("csv (*.csv) |*.csv");
            saveFile.FileName = "névtelen.csv";
            bool fileError = false;
            
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                if (!fileError)
                {
                    try
                    {
                        int columnCount = dataGridView1.Columns.Count;
                        string columnNames = "";
                        string[] outputCSV = new string[dataGridView1.Rows.Count + 1];

                        for (int i = 0; i < columnCount; i++)
                        {
                            columnNames += dataGridView1.Columns[i].HeaderText.ToString() + "\t";
                        }
                        outputCSV[0] += columnNames;

                        for (int i = 1; i - 1 < dataGridView1.Rows.Count; i++)
                        {
                            for (int j = 0; j < columnCount; j++)
                            {
                                outputCSV[i] += dataGridView1.Rows[i - 1].Cells[j].Value.ToString() + "\t";
                            }
                        }

                        File.WriteAllLines(saveFile.FileName, outputCSV, Encoding.UTF8);
                        MessageBox.Show("A mentés sikeres!");
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Hiba történt:\n " + ex.Message);
                    }
                }

            }
            else MessageBox.Show("Hiba történt mentés közben!");
        }

        private void txBxInsertISBN_TextChanged(object sender, EventArgs e)
        {
            /* while (txBxInsertISBN.Text == "" || txBxInsertTitle.Text == "" || txBxInsertPublisher.Text == "" || txBxInsertAuthor.Text == "" || txBxInsertGenre.Text == "")
             {
                 btnInsert.Enabled = false;

                 if(txBxInsertISBN.Text != "" || txBxInsertTitle.Text != "" || txBxInsertPublisher.Text != "" || txBxInsertAuthor.Text != "" || txBxInsertGenre.Text != "")
                 {
                     btnInsert.Enabled = true;
                     break;
                 }
             }*/
        }

        /*  private void UpdateHelper()
          {
              if (dataGridView1.SelectedCells[1].Value.ToString() != "")
              { string helpMeUpdate = dataGridView1.SelectedCells[1].Value.ToString(); }  
          }*/


        string changedCellData, baseCellData, baseISBN;               //main form-os updatehez

        
        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            baseCellData = dataGridView1.CurrentCell.Value.ToString();
            baseISBN = dataGridView1.SelectedCells[5].Value.ToString();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            /*  if (dataGridView1.IsCurrentCellInEditMode == true)
                  changedCellData = dataGridView1.CurrentCell.Value.ToString();
              btnInsUpdate.Enabled = true;*/
        }



        string uTitle = "", uAuthor = "", uGenre = "", uPublihser = "", uPubDate = "", uISBN = "";

        private void menuStripHelp_Click(object sender, EventArgs e)
        {
            Process.Start(@"readme.txt");
        }

        private void menuStripExportPDF_Click(object sender, EventArgs e)   //www.c-sharpcorner.com/blogs/export-datagridview-data-to-pdf-in-c-sharp
        {
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF (*.pdf)|*.pdf";
                saveFileDialog.FileName = "Output.pdf";
                bool fileError = false;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(saveFileDialog.FileName))
                    {
                        try
                        {
                            File.Delete(saveFileDialog.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            PdfPTable pdfTable = new PdfPTable(dataGridView1.Columns.Count);
                            pdfTable.DefaultCell.Padding = 5;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn column in dataGridView1.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                pdfTable.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    pdfTable.AddCell(cell.Value.ToString());
                                }
                            }

                            using (FileStream fstream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                PdfWriter.GetInstance(pdfDoc, fstream);
                                pdfDoc.Open();
                                pdfDoc.Add(pdfTable);
                                pdfDoc.Close();
                                fstream.Close();
                            }

                            MessageBox.Show("Sikeres exportálás!");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Hiba történt:" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Nincs exportálásra kijelölt elem!");
            }
        }

        string uEbook, uForeign, uBorrowed;
        
        private void GetDatasFomGrid() 
        {
            foreach (DataGridViewRow pickedRow in dataGridView1.SelectedRows)
            {
                uTitle = pickedRow.Cells[0].Value.ToString();
                uAuthor = pickedRow.Cells[1].Value.ToString();
                uGenre = pickedRow.Cells[2].Value.ToString();
                uPublihser = pickedRow.Cells[3].Value.ToString();
                uPubDate = pickedRow.Cells[4].Value.ToString();
                uISBN = pickedRow.Cells[5].Value.ToString();
                uEbook = pickedRow.Cells[7].Value.ToString();
                uForeign = pickedRow.Cells[6].Value.ToString();
                uBorrowed = pickedRow.Cells[8].Value.ToString();
            }
        }

        private void btnInsUpdate_Click(object sender, EventArgs e)
        {
            #region //update a datagriden keresztül
            /*   try
               {
                   // var updateForm = new UpdateBookFrm();
                   // updateForm.Show();
                   for (int i = 0; i < dataGridView1.SelectedCells.Count; i++)
                   {
                        if(dataGridView1.SelectedCells[i].ColumnIndex ==0)
                        {
                             sqlDataAdapter.UpdateCommand = new SqlCommand("update Books set books.Title  = '" + changedCellData + "' where books.Title='" + baseCellData + "' and Books.ISBN='"+baseISBN +"'", sqlConnection);
                        }

                        else if (dataGridView1.SelectedCells[i].ColumnIndex == 1)
                        {
                             sqlDataAdapter.UpdateCommand = new SqlCommand("update Authors set Authors.Author  = '" + changedCellData + "' from Authors inner join[dbo].Books on Books.Author_id = Authors.ID where  Books.ISBN='" + baseISBN + "' and  Authors.Author='" + baseCellData + "'", sqlConnection);            
                        }
                        else if (dataGridView1.SelectedCells[i].ColumnIndex == 2)
                         {
                             sqlDataAdapter.UpdateCommand = new SqlCommand("update [dbo].Genres set Genre  = '" + changedCellData + "' where author='" + baseCellData + "'", sqlConnection);
                             MessageBox.Show("izéke:" + baseCellData + "\nizéke még:" + changedCellData);

                         }
                        else if (dataGridView1.SelectedCells[i].ColumnIndex == 3)
                         {
                             // MessageBox.Show(dataGridView1.SelectedCells[i].Value.ToString());

                             //   sqlDataAdapter.UpdateCommand = new SqlCommand("update [dbo].Authors set Author  = '" + dataGridView1.SelectedCells[i].Value.ToString() + "' where author='" + helpMehUpdateTis + "'", sqlConnection);
                             MessageBox.Show("izéke:" + baseCellData + "\nizéke még:" + changedCellData);

                         }
                         else if (dataGridView1.SelectedCells[i].ColumnIndex == 4)
                         {
                             //   sqlDataAdapter.UpdateCommand = new SqlCommand("update [dbo].Authors set Author  = '" + dataGridView1.SelectedCells[i].Value.ToString() + "' where author='" + helpMehUpdateTis + "'", sqlConnection);
                             MessageBox.Show("izéke:" + baseCellData + "\nizéke még:" + changedCellData);

                         }
                         else if (dataGridView1.SelectedCells[i].ColumnIndex == 5)
                         {
                             //   sqlDataAdapter.UpdateCommand = new SqlCommand("update [dbo].Authors set Author  = '" + dataGridView1.SelectedCells[i].Value.ToString() + "' where author='" + helpMehUpdateTis + "'", sqlConnection);
                             MessageBox.Show("izéke:" + baseCellData + "\nizéke még:" + changedCellData);

                         }
                         #region  

                        /*
                       switch (i)
                       {
                           case 0:
                               {
                                   sqlDataAdapter.UpdateCommand = new SqlCommand("update Books set books.Title  = '" + changedCellData + "' where books.Title='" + baseCellData + "' and Books.ISBN='" + baseISBN + "'", sqlConnection);
                                   break;
                               }
                           case 1:
                               {
                                   sqlDataAdapter.UpdateCommand = new SqlCommand("update Authors set Authors.Author  = '" + changedCellData + "' from Authors inner join[dbo].Books on Books.Author_id = Authors.ID where  Books.ISBN='" + baseISBN + "' and  Authors.Author='" + baseCellData + "'", sqlConnection);
                                   break;
                               }
                           case 3:
                               {
                                   sqlDataAdapter.UpdateCommand = new SqlCommand("update Authors set Authors.Author  = '" + changedCellData + "' from Authors inner join[dbo].Books on Books.Author_id = Authors.ID where  Books.ISBN='" + baseISBN + "' and  Authors.Author='" + baseCellData + "'", sqlConnection);
                                   break;
                               }
                           case 4:
                               {

                                   sqlDataAdapter.UpdateCommand = new SqlCommand("update Authors set Authors.Author  = '" + changedCellData + "' from Authors inner join[dbo].Books on Books.Author_id = Authors.ID where  Books.ISBN='" + baseISBN + "' and  Authors.Author='" + baseCellData + "'", sqlConnection);
                                   break;
                               }
                           case 5:
                               {

                                   sqlDataAdapter.UpdateCommand = new SqlCommand("update Authors set Authors.Author  = '" + changedCellData + "' from Authors inner join[dbo].Books on Books.Author_id = Authors.ID where  Books.ISBN='" + baseISBN + "' and  Authors.Author='" + baseCellData + "'", sqlConnection);
                                   break;
                               }
                           default: break;


                       }

                       //  #endregion
                       //  MessageBox.Show("Eredeti szöveg:\t" + baseCellData + "\nMókolt szöveg:\t" + changedCellData + "\n\nHarmadi geci:\t" + baseISBN);
                       sqlConnection.Open();
                       sqlDataAdapter.UpdateCommand.ExecuteNonQuery();
                       sqlConnection.Close();
                   }


                   MessageBox.Show("Sikeres módosítás!");
                   //  tableMergingStuff(); //grid frissítése
               }

               catch (Exception ex)
               {
                   MessageBox.Show("Hiba történt módosítás közben:\n" + ex);
               }*/
            #endregion

            GetDatasFomGrid();

            //    MessageBox.Show(uTitle  + "\n" + uAuthor + "\n" + uGenre + "\n" +uPublihser + "\n" +uPubDate + "\n" +uISBN);   //értékek tesztelése

            UpdateBookFrm updateBook = new UpdateBookFrm();
            updateBook.GetTitle = uTitle;
            updateBook.GetAuthor = uAuthor;
            updateBook.GetGenre = uGenre;
            updateBook.GetPublishser = uPublihser;
            updateBook.GetPubDAte = uPubDate;
            updateBook.GetISBN = uISBN;
            updateBook.GetEbook = chckBxEbook.Checked;
             if (uForeign.CompareTo("true")==1) { updateBook.GetForeign = true; }
             if (uBorrowed.CompareTo( "true")==1) { updateBook.GetBorrowed =true; }
            if (uEbook.CompareTo("true") == 1) { updateBook.GetEbook = true; }

            
            updateBook.Show();

        }
    }
}
