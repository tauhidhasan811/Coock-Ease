using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Data_Access_Layer
{
    public  class LogInSpornsorHelper
    {
        public static string connectionString = "Data Source=DESKTOP-6K06NP6\\SQLEXPRESS;Initial Catalog=Coock_Ease;Integrated Security=True;MultipleActiveResultSets=true;";
        public static string UniversalSponsorId;
        public static bool UniversalSponsorLogIn = false;
        public static void LogInHelperData(string ID, string PASSWORD)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT SR_ID FROM CE_SPONSOR WHERE SR_ID = @UserID AND SR_PASS = @Password AND SR_ActiveStatus=@status";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", ID);
                        command.Parameters.AddWithValue("@Password", PASSWORD);
                        command.Parameters.AddWithValue("@status", "Active");

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Login successful
                                //MessageBox.Show("Log In successFull.");
                                UniversalSponsorId = ID;
                                UniversalSponsorLogIn = true;
                            }
                            else
                            {
                                UniversalSponsorId = "NULLL";
                                UniversalSponsorLogIn = false;
                                // Login failed
                                MessageBox.Show("Log In Faild.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
