using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Data_Access_Layer
{
    public class AverageStart
    {
        public static string avgStar;

        public static void CalculateAverageRating(string cfId)
        {
            string connectionString = "Data Source=DESKTOP-6K06NP6\\SQLEXPRESS;Initial Catalog=Coock_Ease;Integrated Security=True;MultipleActiveResultSets=true;";
            string sqlQuery = "SELECT ROUND(AVG(CONVERT(float, R.RV_STAR)), 2) AS AverageRating FROM CE_REVIEW R JOIN CE_RECIPE C ON R.REC_ID = C.REC_ID WHERE C.CF_ID = @CF_ID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    try
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@CF_ID", cfId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                object result = reader["AverageRating"];

                                if (result != null && result != DBNull.Value)
                                {
                                    avgStar = result.ToString();
                                }
                                else
                                {
                                    avgStar = "0";
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }
    }
}
