using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TicketingSystem
{
    public partial class ReservationForm : Form
    {
        MySqlConnection connection = new MySqlConnection("server = localhost;port=3306;username=root;password=;database=tickets");
        private int ticketCounter = 2023001;
        private Timer timer = new Timer();
        private PrintDocument printDocument = new PrintDocument();
        public ReservationForm()
        {
            InitializeComponent();
            DisplayCurrentDateTime();
            printDocument.PrintPage += PrintDocument_PrintPage;

            timer.Interval = 1000; // 1 second
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            DisplayCurrentDateTime();
        }
        private void DisplayCurrentDateTime()
        {
            DateTime currentDateTime = DateTime.Now;

            string formattedDate = currentDateTime.ToString("MMMM d, yyyy dddd");
            lblCurrentDate.Text = formattedDate;

         
            string formattedTime = currentDateTime.ToString("h:mm:ss tt");
            lblCurrentTime.Text = formattedTime;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                string gender = rbMale.Checked ? "Male" : "Female";
                lblTicket.Text = (ticketCounter++).ToString();

                string insertQuery = "INSERT INTO passenger (TicketNumber, FirstName, MiddleName, LastName, Age, Address, CpNumber, EmailAddress, Gender, DestinationFrom, DestinationTo, DateofTravel, BusNumber, SeatNumber, Price, Staff) VALUES ('" + lblTicket.Text +
    "','" + tbxFirstname.Text + "','" + tbxMiddlename.Text + "','" + tbxLastname.Text + "','" + tbxAge.Text + "','" + tbxAddress.Text + "','" + tbxCellphonenumber.Text + "','" + tbxEmailAd.Text + "','"
    + gender + "','" + cbxDestinationFrom.Text + "','" + cbxDestinationTo.Text + "','" + dtpDateoftravel.Value.ToString("yyyy-MM-dd") + "','" + cbxBusnumber.Text + "','" + cbxSeatnum.Text +
    "','" + cbxPrice.Text + "','" + cbxTicketingstaff.Text + "')";

                
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(insertQuery, connection);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("DATA SAVED!");
                    display();
                    ClearForm();


                }
                else
                {
                    MessageBox.Show("DATA NOT SAVED!");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        private void ClearForm()
        {
            tbxFirstname.Clear();
            tbxMiddlename.Clear();
            tbxLastname.Clear();
            tbxAge.Clear();
            tbxCellphonenumber.Clear();
            tbxEmailAd.Clear();
            tbxAddress.Clear();
            cbxDestinationFrom.SelectedIndex = -1;
            cbxDestinationTo.SelectedIndex = -1;
            cbxPrice.SelectedIndex = -1;
            cbxBusnumber.SelectedIndex = -1;
            cbxSeatnum.SelectedIndex = -1;
            rbMale.Checked = false;
            rbFemale.Checked = false;
            cbxTicketingstaff.SelectedIndex = -1;
        }



        private void ReservationForm_Load(object sender, EventArgs e)
        {

            cbxDestinationFrom.Items.AddRange(new string[] { "Pasay", "San Francisco", "Silago", "Liloan", "St. Bernard", "San Juan", "Anahawan", "Hinunangan", "Hinundayan" });

            cbxDestinationTo.Items.AddRange(new string[] { "Pasay", "San Francisco", "Silago", "Liloan", "St. Bernard", "San Juan", "Anahawan", "Hinunangan", "Hinundayan" });

            cbxPrice.Items.AddRange(new string[] { "2,283.60", "2,307.80", "2,347.40", "2,259.40", "2,212.60", "2,222.00", "2,200.00", "2,153.60" });

            cbxSeatnum.Items.AddRange(new string[] { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30" });

            cbxBusnumber.Items.AddRange(new string[] { "9824", "9857", "9833", "9892" });

            cbxTicketingstaff.Items.AddRange(new string[] { "Robert A. Gacutan", "Edgar Corsiga" });

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    string ticketNumToUpdate = dataGridView1.SelectedRows[0].Cells["TicketNumber"].Value.ToString();

                    string gender = rbMale.Checked ? "Male" : "Female";
                    string updateQuery = "UPDATE passenger SET FirstName = '" + tbxFirstname.Text +
                        "', MiddleName = '" + tbxMiddlename.Text +
                        "', LastName = '" + tbxLastname.Text +
                        "', Age = '" + tbxAge.Text +
                        "', Address = '" + tbxAddress.Text +
                        "', CpNumber = '" + tbxCellphonenumber.Text +
                        "', EmailAddress = '" + tbxEmailAd.Text +
                        "', Gender = '" + gender +
                        "', DestinationFrom = '" + cbxDestinationFrom.Text +
                        "', DestinationTo = '" + cbxDestinationTo.Text +
                        "', DateofTravel = '" + dtpDateoftravel.Value.ToString("yyyy-MM-dd") +
                        "', BusNumber = '" + cbxBusnumber.Text +
                        "', SeatNumber = '" + cbxSeatnum.Text +
                        "', Price = '" + cbxPrice.Text +
                        "', Staff = '" + cbxTicketingstaff.Text +
                        "' WHERE TicketNumber = '" + ticketNumToUpdate + "'";

                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(updateQuery, connection);

                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("DATA UPDATED!");

                        // Refresh the DataGridView after updating
                        display();
                    }
                    else
                    {
                        MessageBox.Show("DATA NOT UPDATED!");
                    }
                }
                else
                {
                    MessageBox.Show("Please select a row to update.");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                connection.Close();
            }

            tbxFirstname.Clear();
            tbxMiddlename.Clear();
            tbxLastname.Clear();
            tbxAge.Clear();
            tbxCellphonenumber.Clear();
            tbxEmailAd.Clear();
            tbxAddress.Clear();
            cbxDestinationFrom.SelectedIndex = -1;
            cbxDestinationTo.SelectedIndex = -1;
            cbxPrice.SelectedIndex = -1;
            cbxBusnumber.SelectedIndex = -1;
            cbxSeatnum.SelectedIndex = -1;
            rbMale.Checked = false;
            rbFemale.Checked = false;
            cbxTicketingstaff.SelectedIndex = -1;
        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    // Assuming ticketnum is in the first column (index 0) of the DataGridView
                    string ticketNumToDelete = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

                    string deleteQuery = "DELETE FROM passenger WHERE TicketNumber = '" + ticketNumToDelete + "'";

                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(deleteQuery, connection);

                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("DATA DELETED!");

                        // Refresh the DataGridView after deletion
                        display();
                    }
                    else
                    {
                        MessageBox.Show("DATA NOT DELETED!");
                    }
                }
                else
                {
                    MessageBox.Show("Please select a row to delete.");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void display()
        {

            string mycon = "server=localhost;port=3306;username=root;password=;database=tickets";
            string Query = "SELECT TicketNumber, FirstName, MiddleName, LastName, Age, Address, CpNumber, EmailAddress, Gender, DestinationFrom, DestinationTo, DATE_FORMAT(DateofTravel, '%Y-%m-%d') AS DateofTravel, BusNumber, SeatNumber, Price, Staff FROM tickets.passenger";

            MySqlConnection connection = new MySqlConnection(mycon);
            MySqlCommand cmd = new MySqlCommand(Query, connection);

            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable table = new DataTable();
            da.Fill(table);

            dataGridView1.DataSource = table;
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                lblTicket.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                tbxFirstname.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                tbxMiddlename.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                tbxLastname.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                tbxAge.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                tbxAddress.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                tbxCellphonenumber.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                tbxEmailAd.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                string genderValue = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                if (genderValue == "Male")
                {
                    rbMale.Checked = true;
                }
                else if (genderValue == "Female")
                {
                    rbFemale.Checked = true;
                }
                cbxDestinationFrom.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                cbxDestinationTo.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
                dtpDateoftravel.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
                cbxBusnumber.Text = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
                cbxSeatnum.Text = dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString();
                cbxPrice.Text = dataGridView1.Rows[e.RowIndex].Cells[14].Value.ToString();
                cbxTicketingstaff.Text = dataGridView1.Rows[e.RowIndex].Cells[15].Value.ToString();

            }
            catch
            {
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            display();
            dataGridView1.Show();

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Set up the font and brush for printing
            using (Font printFont = new Font("Cambria", 12))
            {
                using (SolidBrush brush = new SolidBrush(Color.Black))
                {
                    // Specify the area where the text will be printed
                    RectangleF rect = new RectangleF(e.MarginBounds.Left, e.MarginBounds.Top, e.MarginBounds.Width, e.MarginBounds.Height);

                    // Prepare the content to be printed (customize this based on your needs)
                    StringBuilder printContent = new StringBuilder();

                    printContent.AppendLine("Bus Company: ULTRABUS (United Land Transportations & Bus Company, Inc.");
                    printContent.AppendLine("Terminal Address: South Leyte San Francisco Terminal, Poblacion Central, San Francisco, Southern Leyte");
                    printContent.AppendLine();
                    printContent.AppendLine();
                   
                    foreach (DataGridViewCell cell in dataGridView1.SelectedRows[0].Cells)
                    {
                        printContent.AppendLine(dataGridView1.Columns[cell.ColumnIndex].HeaderText + ": " + cell.Value.ToString());
                    }

                    printContent.AppendLine();
                    printContent.AppendLine();
                    printContent.AppendLine("TICKETING STAFF SIGNATURE");
                    printContent.AppendLine();
                    printContent.AppendLine("This ticket will be available refund 24hrs at the date of departure, Thank youu");
                    // Draw the content on the page
                    e.Graphics.DrawString(printContent.ToString(), printFont, brush, rect, StringFormat.GenericTypographic);
                }
            }
        }


        private string GetSelectedDataForPrinting()
        {
            StringBuilder printContent = new StringBuilder();

            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    string ticketNumToPrint = dataGridView1.SelectedRows[0].Cells["TicketNumber"].Value.ToString();
                    string mycon = "server=localhost;port=3306;username=root;password=;database=tickets";
                    string query = "SELECT * FROM tickets.passenger WHERE TicketNumber = '" + ticketNumToPrint + "'";

                    using (MySqlConnection con = new MySqlConnection(mycon))
                    {
                        using (MySqlCommand cmd = new MySqlCommand(query, con))
                        {
                            con.Open();
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    for (int i = 0; i < reader.FieldCount; i++)
                                    {
                                        printContent.Append(reader.GetName(i) + ": " + reader.GetValue(i).ToString() + "\t");
                                    }

                                    printContent.AppendLine();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return printContent.ToString();
        }


        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HomeForm hf = new HomeForm();
            this.Hide();
            hf.Show();
        }

        private void lOGOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}