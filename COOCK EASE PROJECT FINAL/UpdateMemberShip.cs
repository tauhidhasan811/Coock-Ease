using Data_Access_Layer;
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
using Data_Access_Layer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace COOCK_EASE_PROJECT_FINAL
{
    public partial class UpdateMemberShip : Form
    {
        public static string connectionString = "Data Source=DESKTOP-6K06NP6\\SQLEXPRESS;Initial Catalog=Coock_Ease;Integrated Security=True;MultipleActiveResultSets=true;";
        public UpdateMemberShip()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePicker1.Value;
            DateTime finishedDate = dateTimePicker2.Value;

            string updateQuery = "UPDATE [dbo].[CE_SPONSOR] " +
                     "SET [SR_SDMS] = @us_name, " +
                     "[SR_EDMS] = @ur_mail " +
                     "WHERE [SR_ID] = @ur_id";
            // Execute the query
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        // Add parameters to the SqlCommand
                        command.Parameters.AddWithValue("@us_name", startDate);
                        command.Parameters.AddWithValue("@ur_mail", finishedDate);
                        command.Parameters.AddWithValue("@ur_id", LogInSpornsorHelper.UniversalSponsorId);
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Data inserted successfully!");
                        Sponser sponser = new Sponser();
                        sponser.Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
