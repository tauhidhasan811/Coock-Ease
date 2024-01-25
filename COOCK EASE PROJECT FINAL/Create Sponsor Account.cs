using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace COOCK_EASE_PROJECT_FINAL
{
    public partial class Create_Sponsor_Account : Form
    {
        public Create_Sponsor_Account()
        {
            InitializeComponent();
        }
        public static string connectionString = "Data Source=DESKTOP-6K06NP6\\SQLEXPRESS;Initial Catalog=Coock_Ease;Integrated Security=True;MultipleActiveResultSets=true;";

        private void button1_Click(object sender, EventArgs e)
        {
            string insertQuery = "INSERT INTO [dbo].[CE_SPONSOR] " +
                                 "([SR_ID], [SR_NAME], [SR_PASS], [SR_SDMS], [SR_EDMS], [SR_JOINDATE]) " +
                                 "VALUES (@sr_id, @sr_name, @sr_pass, @sr_sdms, @sr_edms,@sr_joindate)";
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-6K06NP6\\SQLEXPRESS;Initial Catalog=Coock_Ease;Integrated Security=True;MultipleActiveResultSets=true;"))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        // Add parameters to the SqlCommand
                        command.Parameters.AddWithValue("@sr_id", textBox2.Text);
                        command.Parameters.AddWithValue("@sr_name", textBox1.Text);
                        command.Parameters.AddWithValue("@sr_pass", textBox3.Text);
                        command.Parameters.AddWithValue("@sr_sdms", dateTimePicker1.Value);
                        command.Parameters.AddWithValue("@sr_edms", dateTimePicker2.Value);
                        command.Parameters.AddWithValue("@sr_joindate", DateTime.Now);

                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Data inserted successfully!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Create_Sponsor_Account_Load(object sender, EventArgs e)
        {

        }
    }
}
