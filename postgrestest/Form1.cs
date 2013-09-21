using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace postgrestest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var connection = new Npgsql.NpgsqlConnection("Server=127.0.0.1;Port=5432;Database=machinedata;User Id=postgres;Password=asdf;"))
            {
                using (var command = new Npgsql.NpgsqlCommand("INSERT INTO \"cycle data\"(date, name, value) VALUES (@date, @name, @value)", connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@date", dateTimePicker1.Value);
                    command.Parameters.AddWithValue("@name", textBox1.Text);
                    command.Parameters.AddWithValue("@value", textBox2.Text);
                    MessageBox.Show(command.ExecuteNonQuery().ToString());
                    connection.Close();
                }
            }
        }
    }
}
