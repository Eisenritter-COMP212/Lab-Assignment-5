using GeorgeZhou_BooksExample;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeorgeZhou_Exercise1
{
    public partial class DisplayBooks : Form
    {
        public DisplayBooks()
        {
            InitializeComponent();
        }

        private GeorgeZhou_BooksExample.BooksEntities dbcontext =
            new GeorgeZhou_BooksExample.BooksEntities();

        private void DisplayBooks_Load(object sender, EventArgs e)
        {
            Exercise1A();
            Exercise1B();
        } // end load method

        // Exercise 1A
        private void Exercise1A()
        {
            //Title, Edition Number, Author ID, Author First Name
            var dataSet =
                from title in dbcontext.Titles
                from author in title.Authors
                orderby title.Title1    // Sort by Title
                select new
                {
                    Title = title.Title1,
                    Edition = title.EditionNumber,
                    AuthorID = author.AuthorID,
                    AuthorName = author.FirstName
                };

            // specify DataSource for authorBindingSource
            dataGridView1.DataSource = dataSet.ToList();
        }


        // Exercise 1B
        // Get list of all authors grouped by titles, sorted by title
        // For a given title sort the author names alphabetically by last name then first name
        private void Exercise1B()
        {
            var titlesAndAuthors =
                from title in dbcontext.Titles
                select new { Title = title.Title1,
                    Authors=
                        from author in title.Authors
                        orderby author.FirstName
                        select author.FirstName + " " +author.LastName
                };

            tbxOutput.AppendText("\r\n\r\nAuthors grouped by titles:");
            foreach (var book in titlesAndAuthors)
            {
                tbxOutput.AppendText(Environment.NewLine);
                tbxOutput.AppendText($"\r\n\t{book.Title}:");   //  Display book Titles
                // Display authors that written the book
                foreach(var author in book.Authors)
                {
                    tbxOutput.AppendText($"\r\n\t\t{author}");
                }
            }
        }


    }   // End Class
}   // End Namespace
