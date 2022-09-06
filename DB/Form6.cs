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
    public partial class Form6 : Form
    {
        NpgsqlConnection npgsqlConnection1;
        NpgsqlCommand cmd;
        NpgsqlDataAdapter npgsqlDataAdapter;

        public Form6(NpgsqlConnection npgsqlConnection)
        {
            InitializeComponent();
            npgsqlConnection1 = npgsqlConnection;
            npgsqlConnection1.Close();
            cmd = npgsqlConnection1.CreateCommand();
            npgsqlDataAdapter = new NpgsqlDataAdapter(cmd);
            load();
        }

        public void load()
        {
            DataTable dt1 = new DataTable();
            cmd.CommandText = "SELECT * FROM table_rest;";
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

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                    throw new ArgumentException();
                cmd.CommandText = "INSERT INTO public.table_rest (number_table, number_seats, price) VALUES (@number_table, @number_seats, @price);";
                cmd.Parameters.AddWithValue("@number_table", Int32.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@number_seats", Int32.Parse(textBox2.Text));
                cmd.Parameters.AddWithValue("@price", Int32.Parse(textBox3.Text));
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
