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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            button1.Click += button1_Click;
            textBox1.Validated += textBox1_Validated;
            textBox2.Validated += textBox2_Validated;
            errorProvider1.SetIconAlignment(textBox1, ErrorIconAlignment.MiddleRight);
            errorProvider2.SetIconAlignment(textBox2, ErrorIconAlignment.MiddleRight);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlConnection npgsqlConnection = new NpgsqlConnection("server=localhost;port=5432;database=restaurant;user id=" + textBox1.Text + ";password=" + textBox2.Text);
                //npgsqlConnection.Open();
                Form4 form4 = new Form4(npgsqlConnection, textBox1.Text);
                form4.Show();
                //this.Hide();
            }
            catch
            {
                MessageBox.Show("Неверный пароль или логин!");
                button1.Enabled = false;
            }
        }

        void textBox1_Validated(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "" || this.textBox2.Text == "") button1.Enabled = false;
            else button1.Enabled = true;
            if (string.IsNullOrEmpty((sender as TextBox).Text))
                errorProvider1.SetError(textBox1, "Заполните поле!");
            else
                errorProvider1.SetError(textBox1, string.Empty);
        }

        void textBox2_Validated(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "" || this.textBox2.Text == "") button1.Enabled = false;
            else button1.Enabled = true;
            if (string.IsNullOrEmpty((sender as TextBox).Text))
                errorProvider2.SetError(textBox2, "Заполните поле!");
            else
                errorProvider2.SetError(textBox2, string.Empty);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
