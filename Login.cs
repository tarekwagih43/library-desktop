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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                txtPassword.Focus();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                LoginB.PerformClick();
        }

        private void LoginB_Click(object sender, EventArgs e)
        {

            try
            {
                if (!(txtUsername.Text == string.Empty))
                {
                    if (!(txtPassword.Text == string.Empty))
                    {
                        int count = 0;
                        string AdName = txtUsername.Text;
                        string AdPassword = txtPassword.Text;
                        string strSQL = "SELECT * FROM Users WHERE Name = '"+ AdName +"' AND Password = '"+ AdPassword +"'";
                        // Create a connection 
                        string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\lib.mdb";
                        OleDbConnection connection = new OleDbConnection(connectionString);
                        // Create a command and set its connection  
                        OleDbCommand command = new OleDbCommand(strSQL, connection);
                        // Open the connection and execute the select command.  
                        // Open connecton  
                        connection.Open();
                        // Execute command  
                        OleDbDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            count = count + 1;
                        }
                        if (count == 1)
                        {
                            this.Hide();
                            main f2 = new main(); //this is the change, code for redirect  
                            f2.ShowDialog();
                           
                        }
                        else if (count > 1)
                        {
                            MessageBox.Show("Duplicate username and password", "login page");
                        }
                        else
                        {
                            MessageBox.Show(" username and password incorrect", "login page");
                        }
                    }
                    else
                    {
                        MessageBox.Show(" password empty", "login page");
                    }
                }
                else
                {
                    MessageBox.Show(" username empty", "login page");
                }
                // con.Close();  
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

    }
}
