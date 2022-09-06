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
    public partial class Form18 : Form
    {
        NpgsqlConnection npgsqlConnection1;

        public Form18(NpgsqlConnection npgsqlConnection)
        {
            InitializeComponent();

            npgsqlConnection1 = npgsqlConnection;
            npgsqlConnection1.Close();
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlCommand cmd = npgsqlConnection1.CreateCommand();
                DataTable dt = new DataTable();
                cmd.CommandText = "CREATE OR REPLACE FUNCTION get_price(id_dish1 int) RETURNS TEXT AS $$ DECLARE answer TEXT; p REAL; BEGIN IF id_dish1 NOT BETWEEN 0 AND (SELECT count(*) FROM dish) THEN RAISE EXCEPTION 'Invalid id'; END IF; SELECT price INTO p FROM dish WHERE id_dish = id_dish1;	IF p BETWEEN 0 AND 200 THEN answer = 'Цена низкая'; ELSEIF p BETWEEN 201 AND 500 THEN answer = 'Цена средняя'; ELSEIF p BETWEEN 501 AND 1000 THEN answer = 'Цена выше среднего'; ELSE answer = 'Цена высокая'; END IF;	RETURN answer; END; $$ LANGUAGE plpgsql; SELECT get_price(" + textBox1.Text + ");";
                npgsqlConnection1.Open();
                cmd.ExecuteNonQuery();
                npgsqlConnection1.Close();
                NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter(cmd);
                npgsqlDataAdapter.Fill(dt);
                CopyDataTableToList(dt, listView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
