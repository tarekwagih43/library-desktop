using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace liberary
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }
        int leftcontrol = 1;
        private void AddBookbt_Click(object sender, EventArgs e)
        {
            AddBook f_Add = new AddBook(); //this is the change, code for redirect  
            f_Add.ShowDialog();
        }

        private void ViewAllBooks_Paint(object sender, PaintEventArgs e)
        {
            string mySQL = "SELECT * FROM Books";
            string connectionstring = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\lib.mdb";

            OleDbConnection conn = null;
            OleDbCommand cmd = null;
            OleDbDataReader rdr = null;

            try
            {
                conn = new OleDbConnection(connectionstring);
                conn.Open();


                cmd = new OleDbCommand(mySQL, conn);
                rdr = cmd.ExecuteReader();

                Label Name_La = new Label();
                this.Controls.Add(Name_La);
                Name_La.Text = "Name";
                Name_La.Left = 10;

                Label Writer_La = new Label();
                this.Controls.Add(Writer_La);
                Writer_La.Text = "Writer";
                Writer_La.Left = 10;

                Label Year_La = new Label();
                this.Controls.Add(Year_La);
                Year_La.Text = "Year Of Publication";
                Year_La.Left = 10;

                Label Nasher_La = new Label();
                this.Controls.Add(Nasher_La);
                Nasher_La.Text = "Dar Al Nasher";
                Nasher_La.Left = 10;

                Label Borrow_La = new Label();
                this.Controls.Add(Borrow_La);
                Borrow_La.Text = "Borrowing";
                Borrow_La.Left = 10;

                ViewAllBooks.Controls.Add(Name_La, 0, leftcontrol);
                ViewAllBooks.Controls.Add(Writer_La, 1, leftcontrol);
                ViewAllBooks.Controls.Add(Year_La, 2, leftcontrol);
                ViewAllBooks.Controls.Add(Nasher_La, 3, leftcontrol);
                ViewAllBooks.Controls.Add(Borrow_La, 4, leftcontrol);

                while (rdr.Read())
                {
                    TextBox NameColmun = new TextBox();
                    this.Controls.Add(NameColmun);
                    //NameColmun.Top = leftcontrol * 25;
                    NameColmun.Left = 10;
                    NameColmun.ReadOnly = true;
                    NameColmun.Size = new Size(120, 40);
                    NameColmun.Text = rdr.GetValue(0).ToString();

                    TextBox WriterColmun = new TextBox();
                    this.Controls.Add(WriterColmun);
                   // WriterColmun.Top = leftcontrol;
                    WriterColmun.Left = 10 + NameColmun.Width;
                    WriterColmun.ReadOnly = true;
                    WriterColmun.Size = new Size(120, 40);
                    WriterColmun.Text = rdr.GetValue(1).ToString();

                    TextBox YearColmun = new TextBox();
                    this.Controls.Add(YearColmun);
                   // YearColmun.Top = leftcontrol;
                    YearColmun.Left = 10 + NameColmun.Width + WriterColmun.Width;
                    YearColmun.ReadOnly = true;
                    YearColmun.Size = new Size(120, 40);
                    YearColmun.Text = rdr.GetValue(2).ToString();

                    TextBox Darcolmun = new TextBox();
                    this.Controls.Add(Darcolmun);
                    //Darcolmun.Top = leftcontrol;
                    Darcolmun.Left = 10 + NameColmun.Width + WriterColmun.Width + Darcolmun.Width;
                    Darcolmun.ReadOnly = true;
                    Darcolmun.Size = new Size(120, 40);
                    Darcolmun.Text = rdr.GetValue(3).ToString();

                    TextBox PriceColmun = new TextBox();
                    this.Controls.Add(PriceColmun);
                   // PriceColmun.Top = leftcontrol;
                    PriceColmun.Left = 10 + NameColmun.Width + WriterColmun.Width + Darcolmun.Width + Darcolmun.Width;
                    PriceColmun.ReadOnly = true;
                    PriceColmun.Size = new Size(120, 40);
                    PriceColmun.Text = rdr.GetValue(4).ToString();

                    ViewAllBooks.Controls.Add(NameColmun, 0, leftcontrol);
                    ViewAllBooks.Controls.Add(WriterColmun, 1, leftcontrol);
                    ViewAllBooks.Controls.Add(YearColmun, 2, leftcontrol);
                    ViewAllBooks.Controls.Add(Darcolmun, 3, leftcontrol);
                    ViewAllBooks.Controls.Add(PriceColmun, 4, leftcontrol);

                    Controls.Add(ViewAllBooks);

                    leftcontrol = leftcontrol + 1;
                }

                Console.Read();

                conn.Close();

            }
            catch (Exception ex)
            {
                Console.Error.Write("Error founded: " + ex.Message);
            }
            finally
            {
                if (conn != null) conn.Dispose();
                if (cmd != null) cmd.Dispose();
                if (rdr != null) rdr.Dispose();
            }


        }
    }
}
