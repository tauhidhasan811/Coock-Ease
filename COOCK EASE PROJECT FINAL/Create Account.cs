using Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data_Access_Layer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Presentation_Layer
{
    
    public partial class Create_Account : Form
    {
        public static string connectionString = "Data Source=DESKTOP-6K06NP6\\SQLEXPRESS;Initial Catalog=Coock_Ease;Integrated Security=True;MultipleActiveResultSets=true;";

        public Create_Account()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                errorProvider1.SetError(textBox1, "User Name Can't be Null.");
                return;
            }
            else
            {
                errorProvider1.SetError(textBox1, string.Empty);

            }
            if (string.IsNullOrEmpty(textBox2.Text.Trim()))
            {
                errorProvider2.SetError(textBox2, "User Id Must Be Unick.");
                return;
            }
            else
            {
                errorProvider2.SetError(textBox1, string.Empty);

            }
            if (string.IsNullOrEmpty(textBox3.Text.Trim()))
            {
                errorProvider3.SetError(textBox3, "Must Enter Mail Address.");
                return;
            }
            else
            {
                errorProvider3.SetError(textBox3, string.Empty);

            }

            if (string.IsNullOrEmpty(textBox5.Text.Trim()))
            {
                errorProvider5.SetError(textBox5, "User Name Can't be Null.");
                return;
            }
            else
            {
                errorProvider5.SetError(textBox5, string.Empty);

            }
            Create_Account_Helper.Data_Insert(textBox4.Text, textBox1.Text, textBox2.Text, textBox2.Text);
            string textboxValue = textBox5.Text;
            RaferCheck.REFCHECK(textboxValue);
            this.Close();
            Log_In log_In = new Log_In();
            log_In.Show();
            
        }
    }
}
