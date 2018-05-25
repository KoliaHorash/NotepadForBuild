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
        public static string directory = Directory.GetCurrentDirectory();

        static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + directory + @"\DBHome.mdf;Integrated Security=True";
        SqlConnection sqlConnection = new SqlConnection(connectionString);
        public AddHouse()
        {
            
            InitializeComponent();
        }

        private void AddHouse_Load(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(textBox1.Text)) && (!string.IsNullOrWhiteSpace(textBox1.Text)))
            {
                btnEdit.Visible = true;
                ButtonAdd.Visible = false;
                ButtonDelete.Visible = true;
            }
            else
            {
                btnEdit.Visible = false;
                ButtonAdd.Visible = true;
                ButtonDelete.Visible = false;
            }
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

        private void ButtonAdd_Click(object sender, EventArgs e)
        {

            sqlConnection.Open();
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
                    command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    sqlConnection.Close();
                }               
                MessageBox.Show("Запис доданий в базу даних");
            }
            else
                MessageBox.Show("Поля назва, адреса, ціна і посилання. Заповніть, будь ласка.");
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text))
            {
                sqlConnection.Open();
                try
                {                   
                    SqlCommand command = new SqlCommand("DELETE FROM [House] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", textBox1.Text);
                    command.ExecuteNonQueryAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    sqlConnection.Close();
                }
                MessageBox.Show("Запис видалено");
                ClearForm();
            }
            else
                MessageBox.Show("Поле Id порожнє!");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(textBox1.Text)) && (!string.IsNullOrWhiteSpace(textBox1.Text)) &&
                    (!string.IsNullOrEmpty(textBox2.Text)) && (!string.IsNullOrWhiteSpace(textBox2.Text)) &&
                    (!string.IsNullOrEmpty(textBox3.Text)) && (!string.IsNullOrWhiteSpace(textBox3.Text)) &&
                    (!string.IsNullOrEmpty(textBox4.Text)) && (!string.IsNullOrWhiteSpace(textBox4.Text)))
            {
                try
                {
                    sqlConnection.Open();
                    SqlCommand command = new SqlCommand("UPDATE [House] SET [Name]=@Name, [Adress]=@Adress, [Price]=@Price, [Link]=@Link, [Date]=@Date, [Priority]=@Priority, [Realtor]=@Realtor, [Phone]=@Phone WHERE [Id]=@Id", sqlConnection);

                    command.Parameters.AddWithValue("Id", textBox1.Text);
                    command.Parameters.AddWithValue("Name", textBox2.Text);
                    command.Parameters.AddWithValue("Adress", textBox3.Text);
                    command.Parameters.AddWithValue("Price", textBox4.Text);
                    command.Parameters.AddWithValue("Link", textBox5.Text);
                    command.Parameters.AddWithValue("Date", textBox6.Text);
                    command.Parameters.AddWithValue("Priority", textBox7.Text);
                    command.Parameters.AddWithValue("Realtor", textBox8.Text);
                    command.Parameters.AddWithValue("Phone", textBox9.Text);

                    command.ExecuteNonQueryAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    sqlConnection.Close();
                }
                MessageBox.Show("Запис оновлений");

                ClearForm();
            }

            else if ((string.IsNullOrEmpty(textBox7.Text)) && (string.IsNullOrWhiteSpace(textBox7.Text)))
                MessageBox.Show("Поле Id порожнє!");
            else
                MessageBox.Show("Поля назва, адреса, ціна і посилання порожні. Заповніть, будь ласка.");
        }
    }
}
