using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer;
using System.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using System.Windows.Forms;
namespace Data_Access_Layer
{
    public class User_Profile_View
    {
        public User_Profile_View() { }
        public static string connectionString = "Data Source=DESKTOP-6K06NP6\\SQLEXPRESS;Initial Catalog=Coock_Ease;Integrated Security=True;MultipleActiveResultSets=true;";
        public static string UserId;
        public static string FullName;
        public static DateTime dateTime;
        public static string ReferId;
        public static string Mail;
        public static string Password;
        public static void dataView()
        {
            UserId = LogInHelper.UniversalUserId;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query1 = "SELECT UR_NAME FROM CE_USER WHERE UR_ID = @User_ID ";
                    string query2 = "SELECT UR_JOIN_DATE FROM CE_USER WHERE UR_ID = @User_ID ";
                    string query3 = "SELECT REF_ID FROM CE_USER WHERE UR_ID = @User_ID ";
                    string query4 = "SELECT UR_PASS FROM CE_USER WHERE UR_ID = @User_ID ";
                    string query5 = "SELECT UR_MAIL FROM CE_USER WHERE UR_ID = @User_ID ";

                    using (SqlCommand command1 = new SqlCommand(query1, connection))
                    {
                        command1.Parameters.AddWithValue("@User_ID", UserId);
                        using (SqlDataReader reader1 = command1.ExecuteReader())
                        {
                            if (reader1.Read())
                            {
                                FullName = reader1["UR_NAME"] == DBNull.Value ? "" : reader1["UR_NAME"].ToString();

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
                                Password = reader4["UR_PASS"].ToString();

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
                                Mail = reader5["UR_MAIL"].ToString();
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
