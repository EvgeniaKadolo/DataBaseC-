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
    public partial class Form5 : Form
    {
        NpgsqlConnection npgsqlConnection1;
        NpgsqlCommand cmd;
        NpgsqlDataAdapter npgsqlDataAdapter;

        public Form5(NpgsqlConnection npgsqlConnection)
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
            comboBox1.SelectedIndex = 0;

            load();
        }

        public void load()
        {
            DataTable dt1 = new DataTable();
            cmd.CommandText = "SELECT * FROM dish;";
            npgsqlConnection1.Open();
            cmd.ExecuteNonQuery();
            npgsqlConnection1.Close();
            npgsqlDataAdapter = new NpgsqlDataAdapter(cmd);
            npgsqlDataAdapter.Fill(dt1);
            CopyDataTableToList(dt1, listView1);
        }

        public static void CopyDataTableToList(DataTable data, ListView lv)
        {
            lv.BeginUpdate();

            if (lv.Columns.Count != data.Columns.Count)
            {
                lv.Columns.Clear();

                foreach (DataColumn column in data.Columns)
                {
                    lv.Columns.Add(column.ColumnName);
                }
            }

            lv.Items.Clear();

            foreach (DataRow row in data.Rows)
            {
                var list = row.ItemArray.Select(ob => ob.ToString()).ToArray();
                ListViewItem item = new ListViewItem(list);
                lv.Items.Add(item);
            }

            lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            lv.EndUpdate();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox4.Text == "" || textBox3.Text == "" || textBox5.Text == "")
                    throw new ArgumentException();
                NpgsqlCommand cmd = npgsqlConnection1.CreateCommand();
                cmd.CommandText = "INSERT INTO public.dish (name_Dish, id_type_dish, weight, calories, photo, price) VALUES (@name_Dish, @id_type_dish, @weight, @calories, @photo, @price);";
                cmd.Parameters.AddWithValue("@name_Dish", textBox1.Text);
                cmd.Parameters.AddWithValue("@id_type_dish", Int32.Parse((comboBox1.SelectedIndex + 1).ToString()));
                cmd.Parameters.AddWithValue("@weight", Int32.Parse(textBox2.Text));
                cmd.Parameters.AddWithValue("@calories", Int32.Parse(textBox3.Text));
                cmd.Parameters.AddWithValue("@photo", textBox5.Text);
                cmd.Parameters.AddWithValue("@price", Int32.Parse(textBox4.Text));
                npgsqlConnection1.Open();
                cmd.ExecuteNonQuery();
                npgsqlConnection1.Close();
                load();
            }
            catch (Exception exp)
            {
                //MessageBox.Show(exp.Message);
                MessageBox.Show("Заполните все поля!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(npgsqlConnection1);
            form4.Show();
            this.Close();
        }
    }
}
