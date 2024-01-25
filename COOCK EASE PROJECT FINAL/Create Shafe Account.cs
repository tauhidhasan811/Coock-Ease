using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Data_Access_Layer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace COOCK_EASE_PROJECT_FINAL
{
    public partial class Create_Shafe_Account : Form
    {
        public Create_Shafe_Account()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReferCheckerSahfe.REFCHECK(textBox5.Text);
            Create_Shafe_Account_Helper.DataInsert(textBox4.Text, textBox4.Text, textBox3.Text, textBox2.Text, textBox4.Text + "123");
        }

        private void Create_Shafe_Account_Load(object sender, EventArgs e)
        {

        }
    }
}
