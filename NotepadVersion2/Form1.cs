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


        public static string directory = Directory.GetCurrentDirectory();

        static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + directory + @"\DBHome.mdf;Integrated Security=True";

        SqlConnection sqlConnection = new SqlConnection(connectionString);
        public Form1()
        {
            InitializeComponent();
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateList();
        }

        public void UpdateList()
        {
            dataGridView1.Rows.Clear();

            sqlConnection.Open();

            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT *FROM [House]", sqlConnection);

            try
            {
                sqlReader = command.ExecuteReader();

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
                sqlConnection.Close();
            }
        }

        private void DataGridView1_CellMouseDoubleClick(Object sender, DataGridViewCellMouseEventArgs e)
        {
            AddHouse house = new AddHouse();
            try
            {
                house.textBox1.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                house.textBox2.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                house.textBox3.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                house.textBox4.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
                house.textBox5.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
                house.textBox6.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
                house.textBox7.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
                house.textBox8.Text = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();
                house.textBox9.Text = this.dataGridView1.CurrentRow.Cells[8].Value.ToString();
                house.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK);
            }
        }

        public void AddForm()
        {

            AddHouse f2 = new AddHouse();
            f2.Show();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddObject();
            UpdateList();
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            int ind = dataGridView1.SelectedCells[0].RowIndex;
            dataGridView1.Rows.RemoveAt(ind);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
            Close();
        }

        private void addObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddObject();
            UpdateList();
        }
        public static void AddObject()
        {
            AddHouse addHouse = new AddHouse();
            if (addHouse.ShowDialog() == DialogResult.OK)
            {
                addHouse.ShowDialog();
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateList();
        }
    }
}
