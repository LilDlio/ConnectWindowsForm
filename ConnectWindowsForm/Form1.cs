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

namespace ConnectWindowsForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("SQL Server");
            comboBox1.Items.Add("MySQL");
        }

        private void button1_Click(object sender, EventArgs e)
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
                        textBox1.Text = path;
                        string fileContents  = File.ReadAllText(textBox1.Text);
                        richTextBox1.Text =fileContents;
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = null;
            if (comboBox1.SelectedItem == "SQL Server")
            {
                connectionString = textBox2.Text;
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
            else if(comboBox1.SelectedItem == "MySQL")
            {
                connectionString = textBox2.Text;
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

        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = null;
            string sql = null;
            if (comboBox1.SelectedItem == "SQL Server")
            {
                connectionString = textBox2.Text;
                sql = richTextBox1.Text;
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
            else if (comboBox1.SelectedItem == "MySQL")
            {
                connectionString = textBox2.Text;
                sql = richTextBox1.Text;
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
