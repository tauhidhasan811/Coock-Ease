using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer;
using System.Windows.Forms;

namespace COOCK_EASE_PROJECT_FINAL
{
    public partial class LogIn_Shafe : Form
    {
        public LogIn_Shafe()
        {
            InitializeComponent();
        }

        private void LogIn_Shafe_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LogInShafe.LogInHelperData(textBox1.Text, textBox2.Text);
            if (LogInShafe.UniversalShafeLogIn == true)
            {
                this.Close();
                Shafe shafe = new Shafe();
                shafe.Show();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Create_Shafe_Account create_Shafe_Account = new Create_Shafe_Account();
            create_Shafe_Account.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }
    }
}
