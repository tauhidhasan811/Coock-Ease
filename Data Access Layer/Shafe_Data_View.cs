using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Data_Access_Layer
{
    public class Shafe_Data_View
    {
        public static string connectionString = "Data Source=DESKTOP-6K06NP6\\SQLEXPRESS;Initial Catalog=Coock_Ease;Integrated Security=True;MultipleActiveResultSets=true;";
        public static string UserId = LogInShafe.UniversalShafeId;
        public static string FullName;
        public static DateTime dateTime;
        public static string ReferId;
        public static string Mail;
        public static string Password;
        public static void dataView()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query1 = "SELECT CF_NAME FROM CE_SHAFE WHERE CF_ID = @User_ID ";
                    string query2 = "SELECT CF_JOIN_DATE FROM CE_SHAFE WHERE CF_ID = @User_ID ";
                    string query3 = "SELECT REF_ID FROM CE_SHAFE WHERE CF_ID = @User_ID ";
                    string query4 = "SELECT CF_PASS FROM CE_SHAFE WHERE CF_ID = @User_ID ";
                    string query5 = "SELECT CF_MAIL FROM CE_SHAFE WHERE CF_ID = @User_ID ";

                    using (SqlCommand command1 = new SqlCommand(query1, connection))
                    {
                        command1.Parameters.AddWithValue("@User_ID", UserId);
                        using (SqlDataReader reader1 = command1.ExecuteReader())
                        {
                            if (reader1.Read())
                            {
                                FullName = reader1["CF_NAME"] == DBNull.Value ? "" : reader1["CF_NAME"].ToString();

                            }
                        }
                    }
                    using (SqlCommand command2 = new SqlCommand(query2, connection))
                    {
                        command2.Parameters.AddWithValue("@User_ID", UserId);
                        using (SqlDataReader reader2 = command2.ExecuteReader())
                        {
                            if (reader2.Read())
                            {
                                // Login successful
                                
                                dateTime = reader2.GetDateTime(0);

                            }
                        }
                    }
                    using (SqlCommand command3 = new SqlCommand(query3, connection))
                    {
                        command3.Parameters.AddWithValue("@User_ID", UserId);
                        using (SqlDataReader reader3 = command3.ExecuteReader())
                        {
                            if (reader3.Read())
                            {
                                // Login successful
                                // MessageBox.Show("Log In successFull.");
                                ReferId = reader3["REF_ID"].ToString();

                            }
                        }
                    }
                    using (SqlCommand command4 = new SqlCommand(query4, connection))
                    {
                        command4.Parameters.AddWithValue("@User_ID", UserId);
                        using (SqlDataReader reader4 = command4.ExecuteReader())
                        {
                            if (reader4.Read())
                            {
                                // Login successful
                                // MessageBox.Show("Log In successFull.");
                                Password = reader4["CF_PASS"].ToString();

                            }
                        }
                    }
                    using (SqlCommand command5 = new SqlCommand(query5, connection))
                    {
                        command5.Parameters.AddWithValue("@User_ID", UserId);
                        using (SqlDataReader reader5 = command5.ExecuteReader())
                        {
                            if (reader5.Read())
                            {
                                // Login successful
                                // MessageBox.Show("Log In successFull.");
                                Mail = reader5["CF_MAIL"].ToString();

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
