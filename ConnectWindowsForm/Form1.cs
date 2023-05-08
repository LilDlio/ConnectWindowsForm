using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Krypton.Toolkit;
using System.Web.UI.WebControls;

namespace ConnectWindowsForm
{
    public partial class Form1 : KryptonForm
    {
        public Form1()
        {
            InitializeComponent();
            kryptonComboBox1.Items.Add("SQL Server");
            kryptonComboBox1.Items.Add("MySQL");
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "C://Desktop";
            openFileDialog1.Title = "Select file to be upload.";
            openFileDialog1.Filter = "Select Valid Document(txt files (*.txt)|*.txt|All files (*.*)|*.*)";
            openFileDialog1.FilterIndex = 1;
            try
            {
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (openFileDialog1.CheckFileExists)
                    {
                        string path = Path.GetFullPath(openFileDialog1.FileName);
                        kryptonTextBox3.Text = path;
                        string fileContents = File.ReadAllText(kryptonTextBox3.Text);
                        richkryptonTextBox3.Text = fileContents;
                    }
                }
                else
                {
                    MessageBox.Show("Please Upload document.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            string connectionString = null;
            if (kryptonComboBox1.SelectedItem == "SQL Server")
            {
                connectionString = kryptonkryptonTextBox3.Text;
                try
                {
                    using (SqlConnection cnn = new SqlConnection(connectionString))
                    {
                        cnn.Open();
                        MessageBox.Show("Connection successful!");
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error connecting to the database: " + ex.Message);
                }
            }
            else if (kryptonComboBox1.SelectedItem == "MySQL")
            {
                connectionString = kryptonkryptonTextBox3.Text;
                try
                {
                    using (MySqlConnection cnn = new MySqlConnection(connectionString))
                    {
                        cnn.Open();
                        MessageBox.Show("Connection successful!");
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error connecting to the database: " + ex.Message);
                }
            }
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            string connectionString = null;
            string TB = null;
            string queryTB = null;
            connectionString = kryptonkryptonTextBox3.Text;
            TB = kryptonTextBox2.Text;
            queryTB = "SELECT * FROM " + TB;
            if (kryptonComboBox1.SelectedItem == "SQL Server")
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand())
                        {
                            SqlDataAdapter adapter = new SqlDataAdapter();
                            adapter.SelectCommand = new SqlCommand(queryTB, connection);
                            DataTable table = new DataTable();
                            adapter.Fill(table);
                            kryptonDataGridView1.DataSource = table;
                        }
                        MessageBox.Show("SQL code executed successfully!");
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error executing SQL code: " + ex.Message);
                }
            }
            else if (kryptonComboBox1.SelectedItem == "MySQL")
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();

                        using (MySqlCommand command = new MySqlCommand())
                        {
                            MySqlDataAdapter adapter = new MySqlDataAdapter();
                            adapter.SelectCommand = new MySqlCommand(queryTB, connection);
                            DataTable table = new DataTable();
                            adapter.Fill(table);
                            kryptonDataGridView1.DataSource = table;
                        }
                        MessageBox.Show("MySQL code executed successfully!");
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error executing SQL code: " + ex.Message);
                }
            }
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            string connectionString = null;
            string sql = null;
            if (kryptonComboBox1.SelectedItem == "SQL Server")
            {
                connectionString = kryptonkryptonTextBox3.Text;
                sql = richkryptonTextBox3.Text;
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                        MessageBox.Show("SQL code executed successfully!");
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error executing SQL code: " + ex.Message);
                }
            }
            else if (kryptonComboBox1.SelectedItem == "MySQL")
            {
                connectionString = kryptonkryptonTextBox3.Text;
                sql = richkryptonTextBox3.Text;
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();

                        using (MySqlCommand command = new MySqlCommand(sql, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                        MessageBox.Show("MySQL code executed successfully!");
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error executing SQL code: " + ex.Message);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
