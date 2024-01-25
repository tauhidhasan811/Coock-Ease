using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public class SponsorDataView
    {
        public static string connectionString = "Data Source=DESKTOP-6K06NP6\\SQLEXPRESS;Initial Catalog=Coock_Ease;Integrated Security=True;MultipleActiveResultSets=true;";
        public static string SponsorId = LogInSpornsorHelper.UniversalSponsorId;
        public static string FullName;
        public static DateTime joinData;
        public static DateTime MesmebshipStart;
        public static DateTime MesmebshipFnished;
        public static string Mail;
        public static string Password;
        public static void dataView()
        {
            SponsorId = LogInSpornsorHelper.UniversalSponsorId;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query1 = "SELECT SR_NAME FROM CE_SPONSOR WHERE SR_ID = @User_ID ";
                    string query2 = "SELECT SR_JOINDATE FROM CE_SPONSOR WHERE SR_ID = @User_ID ";
                    string query3 = "SELECT SR_SDMS FROM CE_SPONSOR WHERE SR_ID = @User_ID ";
                    string query4 = "SELECT SR_EDMS FROM CE_SPONSOR WHERE SR_ID = @User_ID ";
                   // string query5 = "SELECT SR_MAIL FROM CE_SPONSOR WHERE SR_ID = @User_ID ";

                    using (SqlCommand command1 = new SqlCommand(query1, connection))
                    {
                        command1.Parameters.AddWithValue("@User_ID", SponsorId);
                        using (SqlDataReader reader1 = command1.ExecuteReader())
                        {
                            if (reader1.Read())
                            {
                                FullName = reader1["SR_NAME"] == DBNull.Value ? "" : reader1["SR_NAME"].ToString();

                            }
                        }
                    }
                    using (SqlCommand command2 = new SqlCommand(query2, connection))
                    {
                        command2.Parameters.AddWithValue("@User_ID", SponsorId);
                        using (SqlDataReader reader2 = command2.ExecuteReader())
                        {
                            if (reader2.Read())
                            {
                                joinData = reader2.GetDateTime(0);

                            }
                        }
                    }
                    using (SqlCommand command3 = new SqlCommand(query3, connection))
                    {
                        command3.Parameters.AddWithValue("@User_ID", SponsorId);
                        using (SqlDataReader reader3 = command3.ExecuteReader())
                        {
                            if (reader3.Read())
                            {
                                MesmebshipStart = reader3.GetDateTime(0);

                            }
                        }
                    }
                    using (SqlCommand command5 = new SqlCommand(query4, connection))
                    {
                        command5.Parameters.AddWithValue("@User_ID", SponsorId);
                        using (SqlDataReader reader5 = command5.ExecuteReader())
                        {
                            if (reader5.Read())
                            {
                                MesmebshipFnished = reader5.GetDateTime(0);
                            }
                        }
                    }
                    
                    using (SqlCommand command4 = new SqlCommand(query4, connection))
                    {
                        command4.Parameters.AddWithValue("@User_ID", SponsorId);
                        using (SqlDataReader reader4 = command4.ExecuteReader())
                        {
                            if (reader4.Read())
                            {
                                Password = reader4["SR_PASS"].ToString();

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
