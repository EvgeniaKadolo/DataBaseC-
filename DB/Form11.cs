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
    public partial class Form11 : Form
    {
        NpgsqlConnection npgsqlConnection1;

        public Form11(NpgsqlConnection npgsqlConnection)
        {
            InitializeComponent();

            npgsqlConnection1 = npgsqlConnection;
            NpgsqlCommand cmd = npgsqlConnection.CreateCommand();
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT last_name || ' ' || first_name AS Имя, sum(dish.weight) AS Вес_блюд, sum(dish.price) AS Цена_заказанных_блюд, avg(table_rest.price) AS Цена_столика, sum(dish.price + table_rest.price) AS Итого FROM client JOIN dish_client USING(id_client) JOIN dish USING(id_dish) JOIN table_rest ON client.number_table_id = table_rest.id_table GROUP BY Имя HAVING sum(dish.weight) >= (SELECT avg(weight) FROM dish) AND sum(dish.price +table_rest.price) > 2000 ORDER BY Вес_блюд; ";
            npgsqlConnection.Open();
            cmd.ExecuteNonQuery();
            npgsqlConnection.Close();
            NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter(cmd);
            npgsqlDataAdapter.Fill(dt);
            CopyDataTableToList(dt, listView1);
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

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(npgsqlConnection1);
            form4.Show();
            this.Close();
        }
    }
}
