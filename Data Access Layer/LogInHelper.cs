using System;
using System.Data.SqlClient;

namespace Data_Access_Layer
{
    public class LogInHelper
    {
        public static string connectionString = "Data Source=DESKTOP-6K06NP6\\SQLEXPRESS;Initial Catalog=Coock_Ease;Integrated Security=True;MultipleActiveResultSets=true;";
        public static string UniversalUserId;
        public static bool UniversalLogIn=false;
        public static bool UniversalUserLogIn = false;
        public LogInHelper()
        {

        }

        public static void LogInHelperData(string ID, string PASSWORD)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT UR_ID FROM CE_USER WHERE UR_ID = @UserID AND UR_PASS = @Password AND Active_Status=@status";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", ID);
                        command.Parameters.AddWithValue("@Password", PASSWORD);
                        command.Parameters.AddWithValue("@status", "Active");

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                //MessageBox.Show("Log In successFull.");
                                UniversalUserId = ID;
                                UniversalLogIn=true;
                                UniversalUserLogIn = true;
                            }
                            else
                            {
                                UniversalUserId = "NULLL";
                                UniversalLogIn = false;
                                UniversalUserLogIn = false;
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
