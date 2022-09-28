using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace LinqToSQLMultiTabGyak
{
    class MergeTables
    {
     
        public MergeTables()  //konstrutor
        {
           
             try
            {
                  string mainConnect = ConfigurationManager.ConnectionStrings["LinqToSQLMultiTabGyak.Properties.Settings.BookwormDBConnectionString"].ConnectionString;
                  SqlConnection sqlConnection = new SqlConnection(mainConnect);
                  string sqlQuery = " select Books.ID, Books.Title, Authors.Author, Genres.Genre, Publishers.Publisher, Books.Release_date, Books.ISBN, Books.Foreign_language,Books.E_book,Books.Borrowed from[dbo].[Books] inner join[dbo].[Authors] on Books.Author_id=Authors.ID inner join[dbo].[Genres] on books.Genre_id= Genres.ID inner join [dbo].[Publishers] on Books.Publisher_id= Publishers.ID";
                  SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                  sqlConnection.Open();
                  SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                  DataTable dataTable = new DataTable();
                  sqlDataAdapter.Fill(dataTable);
               var fing = dataTable;
                  sqlConnection.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Az adatok betöltése nem sikerült:\nA hibáról bőveben:\n{ex}");
            }
        }

          public void Shit()
           {

               try
               {
                   string mainConnect = ConfigurationManager.ConnectionStrings["LinqToSQLMultiTabGyak.Properties.Settings.BookwormDBConnectionString"].ConnectionString;
                   SqlConnection sqlConnection = new SqlConnection(mainConnect);
                   string sqlQuery = " select Books.ID, Books.Title, Authors.Author, Genres.Genre, Publishers.Publisher, Books.Release_date, Books.ISBN, Books.Foreign_language,Books.E_book,Books.Borrowed from[dbo].[Books] inner join[dbo].[Authors] on Books.Author_id=Authors.ID inner join[dbo].[Genres] on books.Genre_id= Genres.ID inner join [dbo].[Publishers] on Books.Publisher_id= Publishers.ID";
                   SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                   sqlConnection.Open();
                   SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                   DataTable dataTable = new DataTable();
                   sqlDataAdapter.Fill(dataTable);
                  // dataGridView1.DataSource = dataTable;
                   sqlConnection.Close();
               }

               catch (Exception ex)
               {
                   MessageBox.Show($"Az adatok betöltése nem sikerült:\nA hibáról bőveben:\n{ex}");
               }
           }

    }
}
