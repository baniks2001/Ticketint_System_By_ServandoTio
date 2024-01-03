using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TicketingSystem
{
    public partial class Form1 : Form
    {
        MySqlConnection connection = new MySqlConnection("server = localhost;port=3306;username=root;password=;database=tickets");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            try
            {
                MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=tickets");
                if (tbxUser.Text == "admin" && tbxPassword.Text == "1234")
                {
                    MySqlCommand cmd;
                    MySqlDataReader dr;
                    cmd = new MySqlCommand("SELECT * FROM login WHERE Username ='admin' AND Password ='1234'", connection);
                    connection.Open(); // Open the connection before executing the query
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        // User with admin credentials already exists, proceed to the dashboard
                        dr.Close();
                        this.Hide();
                        HomeForm hf = new HomeForm();
                        hf.Show();
                    }
                    else
                    {
                        // User with admin credentials does not exist, insert it into the database
                        dr.Close();
                        MySqlCommand insertCmd = new MySqlCommand("INSERT INTO login (Username, Password) VALUES ('admin', '1234')", connection);
                        insertCmd.ExecuteNonQuery();
                        this.Hide();
                        HomeForm hf = new HomeForm();
                        hf.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or password");
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
