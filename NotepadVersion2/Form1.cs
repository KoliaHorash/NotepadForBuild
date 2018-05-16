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
    public partial class Form1 : Form
    {
        
        public static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\source\repos\NotepadVersion2\NotepadVersion2\DBHome.mdf;Integrated Security=True";
        SqlConnection sqlConnection = new SqlConnection(connectionString);
        public Form1()
        {
            InitializeComponent();
        }
       
        private async void Form1_Load(object sender, EventArgs e)
        {
            string directory = Directory.GetCurrentDirectory();

            await sqlConnection.OpenAsync();

            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT *FROM [House]", sqlConnection);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                List<string[]> list = new List<string[]>();
                while (sqlReader.Read())
                {
                    list.Add(new string[9]);

                    list[list.Count - 1][0] = sqlReader[0].ToString();
                    list[list.Count - 1][1] = sqlReader[1].ToString();
                    list[list.Count - 1][2] = sqlReader[2].ToString();
                    list[list.Count - 1][3] = sqlReader[3].ToString();
                    list[list.Count - 1][4] = sqlReader[4].ToString();
                    list[list.Count - 1][5] = sqlReader[5].ToString();
                    list[list.Count - 1][6] = sqlReader[6].ToString();
                    list[list.Count - 1][7] = sqlReader[7].ToString();
                    list[list.Count - 1][8] = sqlReader[8].ToString();
                }
                sqlReader.Close();
                foreach (string[] s in list)
                {
                    dataGridView1.Rows.Add(s);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }

        public async void UpdateList()
        {
            dataGridView1.Rows.Clear();

            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT *FROM [House]", sqlConnection);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                List<string[]> list = new List<string[]>();
                while (sqlReader.Read())
                {
                    list.Add(new string[9]);

                    list[list.Count - 1][0] = sqlReader[0].ToString();
                    list[list.Count - 1][1] = sqlReader[1].ToString();
                    list[list.Count - 1][2] = sqlReader[2].ToString();
                    list[list.Count - 1][3] = sqlReader[3].ToString();
                    list[list.Count - 1][4] = sqlReader[4].ToString();
                    list[list.Count - 1][5] = sqlReader[5].ToString();
                    list[list.Count - 1][6] = sqlReader[6].ToString();
                    list[list.Count - 1][7] = sqlReader[7].ToString();
                    list[list.Count - 1][8] = sqlReader[8].ToString();
                }

                sqlReader.Close();
                foreach (string[] s in list)
                {
                    dataGridView1.Rows.Add(s);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
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
                    command.Parameters.AddWithValue("Priority", comboBox2.Text);
                    command.Parameters.AddWithValue("Realtor", textBox6.Text);
                    command.Parameters.AddWithValue("Phone", textBox13.Text);
                    await command.ExecuteNonQueryAsync();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                UpdateList();

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                comboBox2.Text = "";
                textBox6.Clear();
                textBox13.Clear();

                MessageBox.Show("Запис доданий в базу даних");
            }
            else
                MessageBox.Show("Поля назва, адреса, ціна і посилання. Заповніть, будь ласка.");

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            //AddObject();

            if ((!string.IsNullOrEmpty(textBox7.Text)) && (!string.IsNullOrWhiteSpace(textBox7.Text)) &&
                (!string.IsNullOrEmpty(textBox8.Text)) && (!string.IsNullOrWhiteSpace(textBox8.Text)) &&
                (!string.IsNullOrEmpty(textBox9.Text)) && (!string.IsNullOrWhiteSpace(textBox9.Text)) &&
                (!string.IsNullOrEmpty(textBox10.Text)) && (!string.IsNullOrWhiteSpace(textBox10.Text)) &&
                (!string.IsNullOrEmpty(textBox11.Text)) && (!string.IsNullOrWhiteSpace(textBox11.Text)) &&
                (!string.IsNullOrEmpty(textBox12.Text)) && (!string.IsNullOrWhiteSpace(textBox12.Text)) &&
                (!string.IsNullOrEmpty(textBox14.Text)) && (!string.IsNullOrWhiteSpace(textBox11.Text)) &&
                (!string.IsNullOrEmpty(textBox15.Text)) && (!string.IsNullOrWhiteSpace(textBox12.Text)) &&
                (!string.IsNullOrEmpty(comboBox1.Text)) && (!string.IsNullOrWhiteSpace(comboBox1.Text)))
            {
                try
                {
                    SqlCommand command = new SqlCommand("UPDATE [House] SET [Name]=@Name, [Adress]=@Adress, [Price]=@Price, [Link]=@Link, [Date]=@Date, [Priority]=@Priority, [Realtor]=@Realtor, [Phone]=@Phone WHERE [Id]=@Id", sqlConnection);

                    command.Parameters.AddWithValue("Id", textBox7.Text);
                    command.Parameters.AddWithValue("Name", textBox8.Text);
                    command.Parameters.AddWithValue("Adress", textBox9.Text);
                    command.Parameters.AddWithValue("Price", textBox10.Text);
                    command.Parameters.AddWithValue("Link", textBox11.Text);
                    command.Parameters.AddWithValue("Date", textBox12.Text);
                    command.Parameters.AddWithValue("Priority", comboBox1.Text);
                    command.Parameters.AddWithValue("Realtor", textBox14.Text);
                    command.Parameters.AddWithValue("Phone", textBox15.Text);

                    await command.ExecuteNonQueryAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                MessageBox.Show("Запис оновлений");
                //UpadateList();
                ClearPage();
            }

            else if ((string.IsNullOrEmpty(textBox7.Text)) && (string.IsNullOrWhiteSpace(textBox7.Text)))
                MessageBox.Show("Поле Id порожнє!");
            else
                MessageBox.Show("Поля назва, адреса, ціна і посилання порожні. Заповніть, будь ласка.");
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox7.Text) && !string.IsNullOrWhiteSpace(textBox7.Text))
            {
                try
                {
                    SqlCommand command = new SqlCommand("DELETE FROM [House] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", textBox7.Text);
                    await command.ExecuteNonQueryAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                MessageBox.Show("Запис видалено");
                UpdateList();
                ClearPage();
            }
            else
                MessageBox.Show("Поле Id порожнє!");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
        }

        private void toolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
            Close();
        }
        private void ClearPage()
        {
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            comboBox1.Text = "";
        }

        AddHouse addHouse;
        private void button4_Click(object sender, EventArgs e)
        {
            if (addHouse == null || addHouse.IsDisposed)
            {
                AddForm();
            }

            UpdateList();
        }
        public void AddObject()
        {
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
                    command.Parameters.AddWithValue("Priority", comboBox2.Text);
                    command.Parameters.AddWithValue("Realtor", textBox6.Text);
                    command.Parameters.AddWithValue("Phone", textBox13.Text);
                    command.ExecuteNonQueryAsync();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                UpdateList();

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                comboBox2.Text = "";
                textBox6.Clear();
                textBox13.Clear();

                MessageBox.Show("Запис доданий в базу даних");
            }
            else
                MessageBox.Show("Поля назва, адреса, ціна і посилання. Заповніть, будь ласка.");
        }

        private void DataGridView1_CellMouseDoubleClick(Object sender, DataGridViewCellMouseEventArgs e)
        {

            System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
            messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("{0} = {1}", "Clicks", e.Clicks);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("{0} = {1}", "X", e.X);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("{0} = {1}", "Delta", e.Delta);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location);
            messageBoxCS.AppendLine();
            MessageBox.Show(messageBoxCS.ToString(), "CellMouseDoubleClick Event");
        }

        //private void DataGridView1_CellMouseDoubleClick(Object sender, DataGridViewCellMouseEventArgs e)
        //{
        //        AddForm();
        //}

        public int IndexDataGridView()
        {
            return dataGridView1.CurrentRow.Index;
        }

        public void AddForm()
        {
            //string number;

            int i = IndexDataGridView();

            AddHouse f2 = new AddHouse(dataGridView1["Id", i].Value.ToString());
            f2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int ind = dataGridView1.SelectedCells[0].RowIndex;
            dataGridView1.Rows.RemoveAt(ind);
        }

        private void відкритиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream streamOpen;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((streamOpen = openFileDialog1.OpenFile()) != null)
                {
                    StreamReader streamReader = new StreamReader(streamOpen);
                    string[] str;
                    int num = 0;
                    try
                    {
                        string[] str1 = streamReader.ReadToEnd().Split('^');
                        num = str1.Count();
                        dataGridView1.RowCount = num;
                        for (int i = 0; i < num; i++)
                        {
                            str = str1[i].Split('^');
                            for (int j = 0; j < dataGridView1.ColumnCount; j++)
                            {
                                try
                                {
                                    dataGridView1.Rows[i].Cells[j].Value = str[j];
                                }
                                catch { }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        streamReader.Close();
                    }
                    streamOpen.Close();
                }
            }
        }

        private void зберегтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream streamDowland;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((streamDowland = saveFileDialog1.OpenFile()) != null)
                {
                    StreamWriter streamWriter = new StreamWriter(streamDowland);
                    try
                    {
                        for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                        {
                            for (int j = 0; j < dataGridView1.ColumnCount; j++)
                            {
                                streamWriter.Write(dataGridView1.Rows[i].Cells[j].Value.ToString() + "^");
                            }
                            streamWriter.WriteLine();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        streamWriter.Close();
                    }
                    streamDowland.Close();
                }
            }
        }
    }
}
