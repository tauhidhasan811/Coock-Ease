using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
namespace Data_Access_Layer
{
    public class Create_Shafe_Account_Helper
    {
        public static string connectionString = "Data Source=DESKTOP-6K06NP6\\SQLEXPRESS;Initial Catalog=Coock_Ease;Integrated Security=True;MultipleActiveResultSets=true;";
        public Create_Shafe_Account_Helper()
        {

        }
        public static void DataInsert(string sfID, string sfName, string sfMail, string Passwrd, string refID)
        {
            string referID = sfName + "1234";

            // SQL INSERT statement with parameters
            string insertQuery = "INSERT INTO [dbo].[CE_SHAFE] " +
                                 "([CF_ID], [CF_NAME], [CF_MAIL], [CF_PASS], [REF_ID],[CF_JOIN_DATE]) " +
                                 "VALUES (@UR_ID, @UR_NAME, @UR_MAIL, @UR_PASS, @REF_ID,@Date)";

            // Execute the query
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        // Add parameters to the SqlCommand
                        command.Parameters.AddWithValue("@UR_ID", sfID);
                        command.Parameters.AddWithValue("@UR_NAME", sfName);
                        command.Parameters.AddWithValue("@UR_MAIL", sfMail);
                        command.Parameters.AddWithValue("@UR_PASS", Passwrd);
                        command.Parameters.AddWithValue("@REF_ID", referID);
                        command.Parameters.AddWithValue("@Date", DateTime.Now);

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
