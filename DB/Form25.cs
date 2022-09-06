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
    public partial class Form25 : Form
    {
        NpgsqlConnection npgsqlConnection1;
        NpgsqlCommand cmd;
        NpgsqlCommand cmd1;
        NpgsqlCommand cmd2;
        NpgsqlDataAdapter npgsqlDataAdapter;

        public Form25(NpgsqlConnection npgsqlConnection)
        {
            InitializeComponent();

            npgsqlConnection1 = npgsqlConnection;
            npgsqlConnection1.Close();

            cmd = npgsqlConnection1.CreateCommand();
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT type_dish FROM type_dish";
            npgsqlConnection1.Open();
            cmd.ExecuteNonQuery();
            npgsqlConnection1.Close();
            npgsqlDataAdapter = new NpgsqlDataAdapter(cmd);
            npgsqlDataAdapter.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                var list = row.ItemArray.Select(ob => ob.ToString()).ToArray();
                ListViewItem item = new ListViewItem(list);
                comboBox1.Items.Add(item.Text);
            }
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
            cmd1.CommandText = "SELECT * FROM dish WHERE id_dish = '" + textBox1.Text + "';";
            npgsqlConnection1.Open();
            cmd1.ExecuteNonQuery();
            npgsqlConnection1.Close();
            npgsqlDataAdapter = new NpgsqlDataAdapter(cmd1);
            npgsqlDataAdapter.Fill(dt1);

            var list = dt1.Rows[0].ItemArray.Select(ob => ob.ToString()).ToArray();

            cmd = npgsqlConnection1.CreateCommand();
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT type_dish FROM type_dish WHERE id_type = " + list[2];
            npgsqlConnection1.Open();
            cmd.ExecuteNonQuery();
            npgsqlConnection1.Close();
            npgsqlDataAdapter = new NpgsqlDataAdapter(cmd);
            npgsqlDataAdapter.Fill(dt);
            string type = "";
            foreach (DataRow row in dt.Rows)
            {
                var list4 = row.ItemArray.Select(ob => ob.ToString()).ToArray();
                ListViewItem item = new ListViewItem(list4);
                type = item.Text;
            }

            textBox2.Text = list[1];
            comboBox1.SelectedItem = type;
            textBox6.Text = list[3];
            textBox4.Text = list[4];
            textBox3.Text = list[5];
            textBox5.Text = list[6];
            pictureBox1.Load(@"" + list[5] + "");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cmd2 = npgsqlConnection1.CreateCommand();
            DataTable dt2 = new DataTable();
            cmd2.CommandText = "DELETE FROM dish WHERE id_dish = " + textBox1.Text + ";";
            npgsqlConnection1.Open();
            cmd2.ExecuteNonQuery();
            npgsqlConnection1.Close();
            MessageBox.Show("Информация о блюде удалена");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd2 = npgsqlConnection1.CreateCommand();
            DataTable dt2 = new DataTable();
            cmd2.CommandText = "SELECT id_type FROM type_dish WHERE type_dish = '" + comboBox1.SelectedItem.ToString() + "';";
            npgsqlConnection1.Open();
            cmd2.ExecuteNonQuery();
            npgsqlConnection1.Close();
            npgsqlDataAdapter = new NpgsqlDataAdapter(cmd2);
            npgsqlDataAdapter.Fill(dt2);
            string id = "";
            foreach (DataRow row in dt2.Rows)
            {
                var list4 = row.ItemArray.Select(ob => ob.ToString()).ToArray();
                ListViewItem item = new ListViewItem(list4);
                id = item.Text;
            }

            cmd2 = npgsqlConnection1.CreateCommand();
            cmd2.CommandText = "UPDATE dish SET name_dish = '" + textBox2.Text + "', id_type_dish = '" + id + "', weight = '" + Int32.Parse(textBox6.Text) + "', calories = '" + Int32.Parse(textBox4.Text) + "', photo = '" + textBox3.Text + "', price = '" + Int32.Parse(textBox5.Text) + "' WHERE id_dish = " + textBox1.Text + ";";
            npgsqlConnection1.Open();
            cmd2.ExecuteNonQuery();
            npgsqlConnection1.Close();
            MessageBox.Show("Информация о блюде изменена");
        }
    }
}
