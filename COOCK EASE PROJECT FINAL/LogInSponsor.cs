using Data_Access_Layer;
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
using Presentation_Layer;
namespace COOCK_EASE_PROJECT_FINAL
{
    public partial class LogInSponsor : Form
    {
        public LogInSponsor()
        {
            InitializeComponent();
        }

        private void LogInSponsor_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LogInSpornsorHelper.LogInHelperData(textBox1.Text, textBox2.Text);
            if (LogInSpornsorHelper.UniversalSponsorLogIn == true)
            {
                this.Close();

                SponsorDataView.dataView();
                Sponser sponser = new Sponser();
                sponser.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Create_Sponsor_Account create_Sponsor_Account = new Create_Sponsor_Account();
            create_Sponsor_Account.Show();
            this.Close();
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
