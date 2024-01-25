using Presentation_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COOCK_EASE_PROJECT_FINAL
{
    public partial class Select_LogIn_Option : Form
    {
        public Select_LogIn_Option()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Log_In log_In = new Log_In();
                log_In.Show();
                this.Close();
            }
            else if (radioButton2.Checked)
            {
                LogIn_Shafe logIn_Shafe = new LogIn_Shafe();
                logIn_Shafe.Show();
                this.Close();
            }
            else if (radioButton3.Checked)
            {
                LogInSponsor logInSponsor = new LogInSponsor();
                logInSponsor.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Select Any Option");
            }

        }

        private void Select_LogIn_Option_Load(object sender, EventArgs e)
        {

        }
    }
}
