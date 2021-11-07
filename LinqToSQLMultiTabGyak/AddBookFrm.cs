using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqToSQLMultiTabGyak
{
    public partial class AddBookFrm : Form
    {
        public AddBookFrm()
        {
            InitializeComponent();
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

                    Genre insGen = new Genre
                    {
                        Genre1 = txBxAddGenre.Text
                    };
                    dataContext.Genres.InsertOnSubmit(insGen);
                    dataContext.SubmitChanges();

                    bool lend, foreign, ebook;
                    lend= foreign= ebook = false;
                    
                    if (chckBxLend.Checked == true) { lend = true; } else lend = false;
                    if (chckBxForeignLang.Checked == true) { foreign = true; } else foreign = false;
                    if (chckBxEbook.Checked == true) { ebook = true; } else ebook = false;
                    Book insBook = new Book
                    {
                        Author_id = insAuthor.ID,
                        Publisher_id = insPub.ID,
                        Genre_id = insGen.ID,
                        Title = txBxAddTitle.Text,
                        ISBN = txBxAddISBN.Text,
                        Borrowed = lend,
                        Foreign_language = foreign,
                        E_book = ebook,
                        Release_date=Convert.ToInt16(txBxAddPubDate.Text)
                    };

                    dataContext.Books.InsertOnSubmit(insBook);
                    dataContext.SubmitChanges();
                    

                    CleanAddedDatas();
                    // btnInsert.Enabled = false;
                    MessageBox.Show("Beillesztés sikeres!");
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
            chckBxEbook.Checked = chckBxForeignLang.Checked=chckBxLend.Checked= false;
        }

        private void btnCancelWindow_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
    }
}
