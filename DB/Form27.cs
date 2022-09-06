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
    public partial class Form27 : Form
    {
        NpgsqlConnection npgsqlConnection1;

        public Form27(NpgsqlConnection npgsqlConnection)
        {
            InitializeComponent();

            npgsqlConnection1 = npgsqlConnection;
            npgsqlConnection1.Close();
            NpgsqlCommand cmd = npgsqlConnection.CreateCommand();
            DataTable dt = new DataTable();
            cmd.CommandText = "CREATE OR REPLACE FUNCTION get_middle_weight(VARIADIC dishs text[]) RETURNS real AS $$ DECLARE counter int; sum_weight int = 0; answer REAL; BEGIN FOR counter IN 1..array_upper(dishs, 1) LOOP sum_weight = sum_weight + (SELECT weight FROM dish WHERE name_dish = dishs[counter]); END LOOP; answer = sum_weight / array_upper(dishs, 1); RETURN answer; END; $$ LANGUAGE plpgsql; SELECT get_middle_weight('Цезарь', 'Брауни', 'Овощной суп с пастой', 'Фунчоза с овощами');";
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
