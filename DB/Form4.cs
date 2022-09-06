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
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Word;

namespace DB
{
    public partial class Form4 : Form
    {
        NpgsqlConnection npgsqlConnection1;

        public Form4(NpgsqlConnection npgsqlConnection, string role = "administrator")
        {
            InitializeComponent();

            npgsqlConnection1 = npgsqlConnection;
            npgsqlConnection1.Close();
            if (role == "client")
            {
                button18.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;
                button10.Enabled = false;
                button11.Enabled = false;
                button12.Enabled = false;
                button13.Enabled = false;
                button14.Enabled = false;
                button15.Enabled = false;
                button16.Enabled = false;
                button17.Enabled = false;
                button20.Enabled = false;
                button21.Enabled = false;
                button22.Enabled = false;
                button23.Enabled = false;
                button24.Enabled = false;
                button25.Enabled = false;
                button26.Enabled = false;
                button27.Enabled = false;
                button28.Enabled = false;
            }
            else if (role == "povar")
            {
                button19.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;
                button10.Enabled = false;
                button11.Enabled = false;
                button12.Enabled = false;
                button13.Enabled = false;
                button14.Enabled = false;
                button15.Enabled = false;
                button16.Enabled = false;
                button17.Enabled = false;
                button20.Enabled = false;
                button21.Enabled = false;
                button22.Enabled = false;
                button23.Enabled = false;
                button24.Enabled = false;
                button25.Enabled = false;
                button26.Enabled = false;
                button27.Enabled = false;
                button28.Enabled = false;
            }
            else if (role == "administrator")
            {
                button18.Enabled = false;
                button19.Enabled = false;
            }
            else if (role == "postgres")
            {
            }
            else
            {
                button19.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;
                button10.Enabled = false;
                button11.Enabled = false;
                button12.Enabled = false;
                button13.Enabled = false;
                button14.Enabled = false;
                button15.Enabled = false;
                button16.Enabled = false;
                button17.Enabled = false;
                button18.Enabled = false;
                button20.Enabled = false;
                button21.Enabled = false;
                button22.Enabled = false;
                button23.Enabled = false;
                button24.Enabled = false;
                button25.Enabled = false;
                button26.Enabled = false;
                button27.Enabled = false;
                button28.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Form3 form3 = new Form3(npgsqlConnection1);
                form3.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Form5 form5 = new Form5(npgsqlConnection1);
                form5.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Form6 form6 = new Form6(npgsqlConnection1);
                form6.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            try
            {
                Form7 form7 = new Form7(npgsqlConnection1);
                form7.Show();
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void button5_Click(object sender, EventArgs e)
        {   
            try
            {
                Form2 form2 = new Form2(npgsqlConnection1);
                form2.Show();
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                Form8 form8 = new Form8(npgsqlConnection1);
                form8.Show();
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                Form9 form9 = new Form9(npgsqlConnection1);
                form9.Show();
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                Form10 form10 = new Form10(npgsqlConnection1);
                form10.Show();
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                Form11 form11 = new Form11(npgsqlConnection1);
                form11.Show();
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                Form12 form12 = new Form12(npgsqlConnection1);
                form12.Show();
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                Form13 form13 = new Form13(npgsqlConnection1);
                form13.Show();
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                Form14 form14 = new Form14(npgsqlConnection1);
                form14.Show();
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                Form15 form15 = new Form15(npgsqlConnection1);
                form15.Show();
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                Form16 form16 = new Form16(npgsqlConnection1);
                form16.Show();
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                Form17 form17 = new Form17(npgsqlConnection1);
                form17.Show();
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                Form18 form18 = new Form18(npgsqlConnection1);
                form18.Show();
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                Form19 form19 = new Form19(npgsqlConnection1);
                form19.Show();
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                Form20 form20 = new Form20(npgsqlConnection1);
                form20.Show();
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            try
            {
                Form21 form21 = new Form21(npgsqlConnection1);
                form21.Show();
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            try
            {
                Form22 form22 = new Form22(npgsqlConnection1);
                form22.Show();
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            try
            {
                Form23 form23 = new Form23(npgsqlConnection1);
                form23.Show();
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            try
            {
                Form24 form24 = new Form24(npgsqlConnection1);
                form24.Show();
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            try
            {
                Form25 form25 = new Form25(npgsqlConnection1);
                form25.Show();
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            try
            {
                Form26 form26 = new Form26(npgsqlConnection1);
                form26.Show();
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            try
            {
                Form27 form27 = new Form27(npgsqlConnection1);
                form27.Show();
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            try
            {
                Form28 form28 = new Form28(npgsqlConnection1);
                form28.Show();
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            try
            {
                Form29 form29 = new Form29(npgsqlConnection1);
                form29.Show();
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlCommand cmd = npgsqlConnection1.CreateCommand();
                System.Data.DataTable dt = new System.Data.DataTable();
                cmd.CommandText = "SELECT last_name || ' ' || first_name AS Имя_клиента, sum(dish.price) AS Цена_заказанных_блюд, min(table_rest.price) AS Цена_столика, sum(dish.price + table_rest.price) AS Итого FROM client JOIN dish_client USING(id_client) JOIN dish USING(id_dish) JOIN table_rest ON client.number_table_id = table_rest.id_table GROUP BY Имя_клиента ORDER BY Имя_клиента;";
                npgsqlConnection1.Open();
                cmd.ExecuteNonQuery();
                npgsqlConnection1.Close();
                NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter(cmd);
                npgsqlDataAdapter.Fill(dt);


                Microsoft.Office.Interop.Word.Application winword =
                new Microsoft.Office.Interop.Word.Application();

                winword.Visible = false;

                //Заголовок документа
                winword.Documents.Application.Caption = "Отчет о прибыли ресторана за день";
                object missing = System.Reflection.Missing.Value;

                //Создание нового документа
                Document document =
                winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);

                //добавление новой страницы
                //winword.Selection.InsertNewPage();

                //Добавление текста со стилем Заголовок 1
                Paragraph para1 = document.Content.Paragraphs.Add(ref missing);
                object styleHeading1 = "Заголовок 1";
                para1.Range.set_Style(styleHeading1);
                para1.Range.Text = "Отчет о прибыли ресторана за день";
                para1.Range.InsertParagraphAfter();

                //Создание таблицы
                Table firstTable = document.Tables.Add(para1.Range, dt.Rows.Count + 1, dt.Columns.Count, ref missing, ref missing);

                firstTable.Borders.Enable = 1;
                int count = -1;
                int count1 = -1;
                int sum = 0;
                string[] columnName = { "Имя клиента", "Цена заказанных блюд", "Цена столика", "Итого" };

                foreach (Row row in firstTable.Rows)
                {
                    count++;
                    int count2 = 0;
                    int sum2 = 0;

                    foreach (Cell cell in row.Cells) //Cell cell in row.Cells
                    {

                        //Заголовок таблицы
                        if (cell.RowIndex == 1) //cell.RowIndex == 1
                        {
                            cell.Range.Text = columnName[count];
                            count++;
                            cell.Range.Font.Bold = 1;
                            //Задаем шрифт и размер текста
                            cell.Range.Font.Name = "verdana";
                            cell.Range.Font.Size = 10;
                            cell.Shading.BackgroundPatternColor = WdColor.wdColorGray25;
                            //Выравнивание текста в заголовках столбцов по центру
                            cell.VerticalAlignment =
                            WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                            cell.Range.ParagraphFormat.Alignment =
                            WdParagraphAlignment.wdAlignParagraphCenter;
                        }

                        //Значения ячеек
                        else
                        {
                            if (count2 == 2 || count2 == 1)
                            {
                                cell.Range.Text = ((dt.Rows[count1].ItemArray.Select(ob => ob.ToString()).ToArray())[count2]).ToString() + " руб.";
                                sum += Int32.Parse((dt.Rows[count1].ItemArray.Select(ob => ob.ToString()).ToArray())[count2]);
                                sum2 += Int32.Parse((dt.Rows[count1].ItemArray.Select(ob => ob.ToString()).ToArray())[count2]);
                            }
                            else if (count2 == 3) cell.Range.Text = sum2.ToString() + " руб.";
                            else cell.Range.Text = ((dt.Rows[count1].ItemArray.Select(ob => ob.ToString()).ToArray())[count2]).ToString();
                            count2++;
                        }
                    }
                    count1++;
                }
                Paragraph para2 = document.Content.Paragraphs.Add(ref missing);
                para2.Range.Text = DateTime.Today.ToString("D");
                para2.Range.InsertParagraphAfter();

                Paragraph para3 = document.Content.Paragraphs.Add(ref missing);
                para3.Range.Text = "Общая сумма: " + sum.ToString() + " руб.";
                para3.Range.InsertParagraphAfter();

                winword.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
