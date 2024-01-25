using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data_Access_Layer;
using COOCK_EASE_PROJECT_FINAL;

namespace Presentation_Layer
{
    public partial class Log_In : Form
    {
        public Log_In()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "ENTER USER ID")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "ENTER USER ID";

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Create_Account create_Account = new Create_Account();
            create_Account.Show();
        }





        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Log_In_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Create_Account create_Account = new Create_Account();
            create_Account.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            LogInHelper.LogInHelperData(textBox1.Text, textBox2.Text);
            if (LogInHelper.UniversalUserLogIn)
            {
                this.Close();
                User user = new User();
                user.Show();
            }
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            Create_Account create_Account = new Create_Account();
            create_Account.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked== true)
            {
                textBox2.PasswordChar ='\0' ;
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
