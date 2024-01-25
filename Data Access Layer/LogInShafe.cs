using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Data_Access_Layer
{
    public  class LogInShafe
    {
        public static string connectionString = "Data Source=DESKTOP-6K06NP6\\SQLEXPRESS;Initial Catalog=Coock_Ease;Integrated Security=True;MultipleActiveResultSets=true;";
        public static string UniversalShafeId;
        public static bool UniversalShafeLogIn = false;
        public static bool ShafeLogIn=false;
        public static void LogInHelperData(string ID, string PASSWORD)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT CF_ID FROM CE_SHAFE WHERE CF_ID = @UserID AND CF_PASS = @Password AND CF_Active_Status=@status";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", ID);
                        command.Parameters.AddWithValue("@Password", PASSWORD);
                        command.Parameters.AddWithValue("@status", "Active");

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                UniversalShafeId = ID;
                                UniversalShafeLogIn = true;
                                ShafeLogIn = true;
                            }
                            else
                            {
                                UniversalShafeId = "NULLL";
                                UniversalShafeLogIn = false;
                                ShafeLogIn = false;
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

