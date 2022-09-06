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
    public partial class Form24 : Form
    {
        NpgsqlConnection npgsqlConnection1;
        NpgsqlCommand cmd;
        NpgsqlCommand cmd1;
        NpgsqlCommand cmd2;
        NpgsqlDataAdapter npgsqlDataAdapter;

        public Form24(NpgsqlConnection npgsqlConnection)
        {
            InitializeComponent();

            npgsqlConnection1 = npgsqlConnection;
            npgsqlConnection1.Close();

            cmd = npgsqlConnection1.CreateCommand();
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT table_rest.number_table FROM table_rest, client EXCEPT SELECT table_rest.number_table FROM table_rest, client WHERE(table_rest.number_table = client.number_table_id);";
            npgsqlConnection1.Open();
            cmd.ExecuteNonQuery();
            npgsqlConnection1.Close();
            npgsqlDataAdapter = new NpgsqlDataAdapter(cmd);
            npgsqlDataAdapter.Fill(dt);

            comboBox1.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                var list = row.ItemArray.Select(ob => ob.ToString()).ToArray();
                ListViewItem item = new ListViewItem(list);
                comboBox1.Items.Add(item.Text);
            }

            cmd1 = npgsqlConnection1.CreateCommand();
            DataTable dt1 = new DataTable();
            cmd1.CommandText = "SELECT name_dish FROM dish;";
            npgsqlConnection1.Open();
            cmd1.ExecuteNonQuery();
            npgsqlConnection1.Close();
            npgsqlDataAdapter = new NpgsqlDataAdapter(cmd1);
            npgsqlDataAdapter.Fill(dt1);

            foreach (DataRow row in dt1.Rows)
            {
                var list = row.ItemArray.Select(ob => ob.ToString()).ToArray();
                ListViewItem item = new ListViewItem(list);
                listBox1.Items.Add(item.Text);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

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
            cmd1.CommandText = "SELECT * FROM client WHERE id_client = '" + textBox1.Text + "';";
            npgsqlConnection1.Open();
            cmd1.ExecuteNonQuery();
            npgsqlConnection1.Close();
            npgsqlDataAdapter = new NpgsqlDataAdapter(cmd1);
            npgsqlDataAdapter.Fill(dt1);

            var list = dt1.Rows[0].ItemArray.Select(ob => ob.ToString()).ToArray();

            cmd = npgsqlConnection1.CreateCommand();
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT table_rest.number_table FROM table_rest, client EXCEPT SELECT table_rest.number_table FROM table_rest, client WHERE(table_rest.number_table = client.number_table_id);";
            npgsqlConnection1.Open();
            cmd.ExecuteNonQuery();
            npgsqlConnection1.Close();
            npgsqlDataAdapter = new NpgsqlDataAdapter(cmd);
            npgsqlDataAdapter.Fill(dt);

            comboBox1.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                var list4 = row.ItemArray.Select(ob => ob.ToString()).ToArray();
                ListViewItem item = new ListViewItem(list4);
                comboBox1.Items.Add(item.Text);
            }
            comboBox1.Items.Add(list[5]);

            textBox2.Text = list[1];
            textBox3.Text = list[2];
            maskedTextBox1.Text = list[3];
            textBox4.Text = list[4];
            comboBox1.SelectedItem = list[5];

            cmd2 = npgsqlConnection1.CreateCommand();
            DataTable dt2 = new DataTable();
            cmd2.CommandText = "SELECT name_dish FROM dish WHERE id_dish IN (SELECT id_dish FROM dish_client WHERE id_client = " + textBox1.Text + ");";
            npgsqlConnection1.Open();
            cmd2.ExecuteNonQuery();
            npgsqlConnection1.Close();
            npgsqlDataAdapter = new NpgsqlDataAdapter(cmd2);
            npgsqlDataAdapter.Fill(dt2);

            listBox1.ClearSelected();
            foreach (DataRow row in dt2.Rows)
            {
                var list1 = row.ItemArray.Select(ob => ob.ToString()).ToArray();
                listBox1.SelectedItem = list1[0];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd2 = npgsqlConnection1.CreateCommand();
            cmd2.CommandText = "DELETE FROM dish_client WHERE id_client = " + textBox1.Text + ";";
            npgsqlConnection1.Open();
            cmd2.ExecuteNonQuery();
            npgsqlConnection1.Close();

            cmd2 = npgsqlConnection1.CreateCommand();
            DataTable dt2 = new DataTable();
            cmd2.CommandText = "UPDATE client SET last_name = '" + textBox2.Text + "', first_name = '" + textBox3.Text + "', phone = '" + maskedTextBox1.Text + "', number_persons = '" + Int32.Parse(textBox4.Text) + "', number_table_id = '" + Int32.Parse(comboBox1.SelectedItem.ToString()) + "' WHERE id_client = " + textBox1.Text + ";";
            npgsqlConnection1.Open();
            cmd2.ExecuteNonQuery();
            npgsqlConnection1.Close();
            foreach (var item in listBox1.SelectedItems)
            {
                NpgsqlCommand cmd2 = npgsqlConnection1.CreateCommand();
                cmd2.CommandText = "SELECT id_dish FROM dish WHERE name_dish = '" + item.ToString() + "';";
                npgsqlConnection1.Open();
                npgsqlDataAdapter = new NpgsqlDataAdapter(cmd2);
                DataTable dt3 = new DataTable();
                npgsqlDataAdapter.Fill(dt3);
                string id_dish = "";
                npgsqlConnection1.Close();
                foreach (DataRow row in dt3.Rows)
                {
                    var list = row.ItemArray.Select(ob => ob.ToString()).ToArray();
                    ListViewItem item1 = new ListViewItem(list);
                    id_dish = item1.Text;
                }

                NpgsqlCommand cmd1 = npgsqlConnection1.CreateCommand();
                cmd1.CommandText = "INSERT INTO public.dish_client (id_dish, id_client) VALUES (@id_dish, @id);";
                cmd1.Parameters.AddWithValue("@id_dish", Int32.Parse(id_dish));
                cmd1.Parameters.AddWithValue("@id", Int32.Parse(textBox1.Text));
                npgsqlConnection1.Open();
                cmd1.ExecuteNonQuery();
                npgsqlConnection1.Close();
            }
            MessageBox.Show("Информация о клиенте изменена");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cmd2 = npgsqlConnection1.CreateCommand();
            DataTable dt2 = new DataTable();
            cmd2.CommandText = "DELETE FROM client WHERE id_client = " + textBox1.Text + ";";
            npgsqlConnection1.Open();
            cmd2.ExecuteNonQuery();
            npgsqlConnection1.Close();
            MessageBox.Show("Информация о клиенте удалена");
        }
    }
}
