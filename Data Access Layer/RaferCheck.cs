using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Data_Access_Layer
{
    public class RaferCheck
    {
        public static string connectionString = "Data Source=DESKTOP-6K06NP6\\SQLEXPRESS;Initial Catalog=Coock_Ease;Integrated Security=True;MultipleActiveResultSets=true;";

        public static void REFCHECK(string refID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT UR_ID FROM CE_USER WHERE REF_ID = @recID AND Active_Status = @status";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@recID", refID);
                        command.Parameters.AddWithValue("@status", "Active");

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string userId = reader.GetString(0);
                                string insertQuery = "INSERT INTO CE_REFER (UR_ID) VALUES((SELECT UR_ID FROM CE_USER WHERE REF_ID = @refid));";

                                using (SqlConnection connection1 = new SqlConnection(connectionString))
                                {
                                    try
                                    {
                                        using (SqlCommand command1 = new SqlCommand(insertQuery, connection1))
                                        {
                                            command1.Parameters.AddWithValue("@refid", refID);
                                            connection1.Open();
                                            command1.ExecuteNonQuery();
                                            //MessageBox.Show("Data inserted successfully!");
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Error inserting data: " + ex.Message);
                                    }
                                }
                            }
                            else
                            {
                                // Handle the case when the reader doesn't have any rows if needed
                            }
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
