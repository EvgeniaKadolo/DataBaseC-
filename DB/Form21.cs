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
    public partial class Form21 : Form
    {
        NpgsqlConnection npgsqlConnection1;
        NpgsqlCommand cmd;
        NpgsqlCommand cmd1;
        NpgsqlDataAdapter npgsqlDataAdapter;

        public Form21(NpgsqlConnection npgsqlConnection)
        {
            InitializeComponent();

            npgsqlConnection1 = npgsqlConnection;
            npgsqlConnection1.Close();

            cmd = npgsqlConnection1.CreateCommand();
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT table_rest.number_table, table_rest.price FROM table_rest, client EXCEPT SELECT table_rest.number_table, table_rest.price FROM table_rest, client WHERE(table_rest.number_table = client.number_table_id);";
            npgsqlConnection1.Open();
            cmd.ExecuteNonQuery();
            npgsqlConnection1.Close();
            npgsqlDataAdapter = new NpgsqlDataAdapter(cmd);
            npgsqlDataAdapter.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                var list = row.ItemArray.Select(ob => ob.ToString()).ToArray();
                ListViewItem item = new ListViewItem(list);
                comboBox1.Items.Add(list[0] + " - Цена: " + list[1] + " руб.");
            }
            comboBox1.SelectedIndex = 0;

            cmd1 = npgsqlConnection1.CreateCommand();
            DataTable dt1 = new DataTable();
            cmd1.CommandText = "SELECT id_dish, name_dish FROM dish;";
            npgsqlConnection1.Open();
            cmd1.ExecuteNonQuery();
            npgsqlConnection1.Close();
            npgsqlDataAdapter = new NpgsqlDataAdapter(cmd1);
            npgsqlDataAdapter.Fill(dt1);

            foreach (DataRow row in dt1.Rows)
            {
                var list = row.ItemArray.Select(ob => ob.ToString()).ToArray();
                ListViewItem item = new ListViewItem(list);
                listBox1.Items.Add(list[0].ToString() + " " + list[1].ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(npgsqlConnection1, "client");
            form4.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                npgsqlConnection1.Close();
                if (textBox1.Text == "" || textBox2.Text == "" || maskedTextBox1.Text == "" || textBox3.Text == "")
                    throw new ArgumentException();
                NpgsqlCommand cmd = npgsqlConnection1.CreateCommand();
                cmd.CommandText = "INSERT INTO public.client (last_name, first_name, phone, number_persons, number_table_id) VALUES (@last_name, @first_name, @phone, @number_persons, @number_table_id) RETURNING id_client;";
                cmd.Parameters.AddWithValue("@last_name", textBox1.Text);
                cmd.Parameters.AddWithValue("@first_name", textBox2.Text);
                cmd.Parameters.AddWithValue("@phone", maskedTextBox1.Text);
                cmd.Parameters.AddWithValue("@number_persons", Int32.Parse(textBox3.Text));
                cmd.Parameters.AddWithValue("@number_table_id", Int32.Parse(comboBox1.SelectedItem.ToString().Substring(0, comboBox1.SelectedItem.ToString().IndexOf(' '))));
                npgsqlConnection1.Open();
                //cmd.ExecuteNonQuery();
                //npgsqlConnection1.Close();
                npgsqlDataAdapter = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                npgsqlDataAdapter.Fill(dt);
                string id = "";
                npgsqlConnection1.Close();

                foreach (DataRow row in dt.Rows)
                {
                    var list1 = row.ItemArray.Select(ob => ob.ToString()).ToArray();
                    ListViewItem item = new ListViewItem(list1);
                    id = item.Text;
                }
                foreach (var item in listBox1.SelectedItems)
                {
                    NpgsqlCommand cmd2 = npgsqlConnection1.CreateCommand();
                    cmd2.CommandText = "SELECT id_dish FROM dish WHERE name_dish = '" + item.ToString().Remove(0, item.ToString().IndexOf(' ') + 1) + "';";
                    npgsqlConnection1.Open();
                    npgsqlDataAdapter = new NpgsqlDataAdapter(cmd2);
                    DataTable dt2 = new DataTable();
                    npgsqlDataAdapter.Fill(dt2);
                    string id_dish = "";
                    npgsqlConnection1.Close();
                    foreach (DataRow row in dt2.Rows)
                    {
                        var list2 = row.ItemArray.Select(ob => ob.ToString()).ToArray();
                        ListViewItem item1 = new ListViewItem(list2);
                        id_dish = item1.Text;
                    }

                    NpgsqlCommand cmd1 = npgsqlConnection1.CreateCommand();
                    cmd1.CommandText = "INSERT INTO public.dish_client (id_dish, id_client) VALUES (@id_dish, @id);";
                    cmd1.Parameters.AddWithValue("@id_dish", Int32.Parse(id_dish));
                    cmd1.Parameters.AddWithValue("@id", Int32.Parse(id));
                    npgsqlConnection1.Open();
                    cmd1.ExecuteNonQuery();
                    npgsqlConnection1.Close();
                }
                cmd = npgsqlConnection1.CreateCommand();
                DataTable dt3 = new DataTable();
                cmd.CommandText = "SELECT sum(dish.price) AS Цена_заказанных_блюд, min(table_rest.price) AS Цена_столика FROM client JOIN dish_client USING(id_client) JOIN dish USING(id_dish) JOIN table_rest ON client.number_table_id = table_rest.id_table WHERE id_client = " + Int32.Parse(id) + ";";
                npgsqlConnection1.Open();
                cmd.ExecuteNonQuery();
                npgsqlConnection1.Close();
                npgsqlDataAdapter = new NpgsqlDataAdapter(cmd);
                npgsqlDataAdapter.Fill(dt3);

                string[] list = { };
                foreach (DataRow row in dt3.Rows)
                {
                    list = row.ItemArray.Select(ob => ob.ToString()).ToArray();
                }
                MessageBox.Show("Заказ оформлен\nЦена заказанных блюд " + list[0] + " руб.\nЦена столика " + list[1] + " руб.\nИтого " + (Int32.Parse(list[0]) + Int32.Parse(list[1])).ToString() + " руб.");
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
                //MessageBox.Show("Заполните все поля!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd1 = npgsqlConnection1.CreateCommand();
            DataTable dt1 = new DataTable();
            cmd1.CommandText = "SELECT * FROM dish WHERE id_dish = '" + textBox4.Text + "';";
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

            label9.Text = "Название: " + list[1];
            label10.Text = "Тип блюда: " + type;
            label11.Text = "Вес: " + list[3];
            label12.Text = "Калории: " + list[4];
            label13.Text = "Цена: " + list[6] + " руб.";
            pictureBox2.Load(@"" + list[5] + "");
        }
    }
}
