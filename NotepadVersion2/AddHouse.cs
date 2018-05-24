using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace NotepadVersion2
{
    public partial class AddHouse : Form
    {
        public AddHouse()
        {
            
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\NotepadVersion2\NotepadVersion2\DBHome.mdf;Integrated Security=True";

            SqlConnection sqlConnection = new SqlConnection(connectionString); 
            if ((!string.IsNullOrEmpty(textBox1.Text)) && (!string.IsNullOrWhiteSpace(textBox1.Text)) &&
                (!string.IsNullOrEmpty(textBox2.Text)) && (!string.IsNullOrWhiteSpace(textBox2.Text)) &&
                (!string.IsNullOrEmpty(textBox3.Text)) && (!string.IsNullOrWhiteSpace(textBox3.Text)) &&
                (!string.IsNullOrEmpty(textBox4.Text)) && (!string.IsNullOrWhiteSpace(textBox4.Text)))
            {
                try
                {
                    SqlCommand command = new SqlCommand("INSERT INTO [House](Name, Adress, Price, Link, Date, Priority, Realtor, Phone)VALUES(@Name, @Adress, @Price, @Link, @Date, @Priority, @Realtor, @Phone)", sqlConnection);

                    command.Parameters.AddWithValue("Name", textBox1.Text);
                    command.Parameters.AddWithValue("Adress", textBox2.Text);
                    command.Parameters.AddWithValue("Price", textBox3.Text);
                    command.Parameters.AddWithValue("Link", textBox4.Text);
                    command.Parameters.AddWithValue("Date", textBox5.Text);
                    command.Parameters.AddWithValue("Priority", textBox6.Text);
                    command.Parameters.AddWithValue("Realtor", textBox7.Text);
                    command.Parameters.AddWithValue("Phone", textBox8.Text);
                    await command.ExecuteNonQueryAsync();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
                MessageBox.Show("Запис доданий в базу даних");
            }
            else
                MessageBox.Show("Поля назва, адреса, ціна і посилання. Заповніть, будь ласка.");
        }

        private void AddHouse_Load(object sender, EventArgs e)
        {

        }
        public void ClearForm()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
        }
    }
}
