using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace DB
{
    public partial class Form26 : Form
    {
        NpgsqlConnection npgsqlConnection1;
        NpgsqlCommand cmd;
        NpgsqlCommand cmd1;
        NpgsqlCommand cmd2;
        NpgsqlDataAdapter npgsqlDataAdapter;

        public Form26(NpgsqlConnection npgsqlConnection)
        {
            InitializeComponent();

            npgsqlConnection1 = npgsqlConnection;
            npgsqlConnection1.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(npgsqlConnection1);
            form4.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd1 = npgsqlConnection1.CreateCommand();
            DataTable dt1 = new DataTable();
            cmd1.CommandText = "SELECT * FROM table_rest WHERE id_table = '" + textBox1.Text + "';";
            npgsqlConnection1.Open();
            cmd1.ExecuteNonQuery();
            npgsqlConnection1.Close();
            npgsqlDataAdapter = new NpgsqlDataAdapter(cmd1);
            npgsqlDataAdapter.Fill(dt1);

            var list = dt1.Rows[0].ItemArray.Select(ob => ob.ToString()).ToArray();

            textBox2.Text = list[1];
            textBox3.Text = list[2];
            textBox4.Text = list[3];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cmd2 = npgsqlConnection1.CreateCommand();
            DataTable dt2 = new DataTable();
            cmd2.CommandText = "DELETE FROM table_rest WHERE id_table = " + textBox1.Text + ";";
            npgsqlConnection1.Open();
            cmd2.ExecuteNonQuery();
            npgsqlConnection1.Close();
            MessageBox.Show("Информация о столике удалена");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd2 = npgsqlConnection1.CreateCommand();
            cmd2.CommandText = "UPDATE table_rest SET number_table = '" + Int32.Parse(textBox2.Text) + "', number_seats = '" + Int32.Parse(textBox3.Text) + "', price = '" + Int32.Parse(textBox4.Text) + "' WHERE id_table = " + textBox1.Text + ";";
            npgsqlConnection1.Open();
            cmd2.ExecuteNonQuery();
            npgsqlConnection1.Close();
            MessageBox.Show("Информация о столике изменена");
        }
    }
}
