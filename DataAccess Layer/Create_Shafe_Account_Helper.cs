using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess_Layer
{
    public  class Create_Shafe_Account_Helper
    {
        private string connectionString = "Data Source=DESKTOP-6K06NP6\\SQLEXPRESS;Initial Catalog=Coock_Ease;Integrated Security=True;MultipleActiveResultSets=true;";
        public Create_Shafe_Account_Helper()
        {

        }
        public static void DataInsert(string urID, string urName, string urMail, string Passwrd, string refID )
        {
            string insertQuery = "INSERT INTO [dbo].[CE_Chafe] " +
                                 "([CF_ID], [CF_NAME], [CF_MAIL], [CF_PASS], [REF_ID]) " +
                                 "VALUES (@UR_ID, @UR_NAME, @UR_MAIL, @UR_PASS, @REF_ID)";
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-6K06NP6\\SQLEXPRESS;Initial Catalog=Coock_Ease;Integrated Security=True;MultipleActiveResultSets=true;"))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        // Add parameters to the SqlCommand
                        command.Parameters.AddWithValue("@UR_ID", urID);
                        command.Parameters.AddWithValue("@UR_NAME", urName);
                        command.Parameters.AddWithValue("@UR_MAIL", urMail);
                        command.Parameters.AddWithValue("@UR_PASS", Passwrd);
                        command.Parameters.AddWithValue("@REF_ID", refID);

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
    }
}
