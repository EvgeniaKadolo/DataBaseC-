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
    public partial class Form17 : Form
    {
        NpgsqlConnection npgsqlConnection1;

        public Form17(NpgsqlConnection npgsqlConnection)
        {
            InitializeComponent();

            npgsqlConnection1 = npgsqlConnection;
            npgsqlConnection1.Close();
            NpgsqlCommand cmd = npgsqlConnection.CreateCommand();
            DataTable dt = new DataTable();
            cmd.CommandText = "BEGIN; DROP TABLE IF EXISTS client_sum_min_2000; CREATE TABLE client_sum_min_2000 AS SELECT * FROM client WHERE id_client IN (SELECT id_client FROM client JOIN dish_client USING(id_client) JOIN dish USING(id_dish) JOIN table_rest ON client.number_table_id = table_rest.id_table GROUP BY id_client HAVING sum(dish.price + table_rest.price) > 2000); COMMIT; SELECT * FROM client_sum_min_2000;";
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
