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
    public partial class Form3 : Form
    {
        NpgsqlConnection npgsqlConnection1;
        NpgsqlCommand cmd;
        NpgsqlDataAdapter npgsqlDataAdapter;

        public Form3(NpgsqlConnection npgsqlConnection)
        {
            InitializeComponent();
            npgsqlConnection1 = npgsqlConnection;
            npgsqlConnection1.Close();
            load();
        }

        public void load()
        {
            cmd = npgsqlConnection1.CreateCommand();
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT table_rest.number_table FROM table_rest, client EXCEPT SELECT table_rest.number_table FROM table_rest, client WHERE(table_rest.number_table = client.number_table_id);";
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

            DataTable dt1 = new DataTable();
            cmd.CommandText = "SELECT * FROM client;";
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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || maskedTextBox1.Text == "" || textBox3.Text == "")
                    throw new ArgumentException();
                NpgsqlCommand cmd = npgsqlConnection1.CreateCommand();
                cmd.CommandText = "INSERT INTO public.client (last_name, first_name, phone, number_persons, number_table_id) VALUES (@last_name, @first_name, @phone, @number_persons, @number_table_id);";
                cmd.Parameters.AddWithValue("@last_name", textBox1.Text);
                cmd.Parameters.AddWithValue("@first_name", textBox2.Text);
                cmd.Parameters.AddWithValue("@phone", maskedTextBox1.Text);
                cmd.Parameters.AddWithValue("@number_persons", Int32.Parse(textBox3.Text));
                cmd.Parameters.AddWithValue("@number_table_id", Int32.Parse(comboBox1.SelectedItem.ToString()));
                npgsqlConnection1.Open();
                cmd.ExecuteNonQuery();
                npgsqlConnection1.Close();
                load();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
                //MessageBox.Show("Заполните все поля!");
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
