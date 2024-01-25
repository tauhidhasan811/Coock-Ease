using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Data_Access_Layer
{
    public class Upload_Recipe
    {
        public Upload_Recipe()
        {

        }
        public static string connectionString = "Data Source=DESKTOP-6K06NP6\\SQLEXPRESS;Initial Catalog=Coock_Ease;Integrated Security=True;MultipleActiveResultSets=true;";
        public static void Data_Insert(string urID, string urName, string urMail, string UR_PASS)
        {
            string refID = urName + "1234";

            // SQL INSERT statement with parameters
            string insertQuery = "INSERT INTO [dbo].[CE_USER] " +
                                 "([UR_ID], [UR_NAME], [UR_MAIL], [UR_PASS], [REF_ID],[UR_JOIN_DATE]) " +
                                 "VALUES (@UR_ID, @UR_NAME, @UR_MAIL, @UR_PASS, @REF_ID,@Date)";

            // Execute the query
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        // Add parameters to the SqlCommand
                        command.Parameters.AddWithValue("@UR_ID", urID);
                        command.Parameters.AddWithValue("@UR_NAME", urName);
                        command.Parameters.AddWithValue("@UR_MAIL", urMail);
                        command.Parameters.AddWithValue("@UR_PASS", UR_PASS);
                        command.Parameters.AddWithValue("@REF_ID", refID);
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
