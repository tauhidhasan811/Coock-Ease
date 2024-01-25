using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.ComponentModel;

namespace Data_Access_Layer
{

    public class Button_Data_Show
    {
        public static string connectionString = "Data Source=DESKTOP-6K06NP6\\SQLEXPRESS;Initial Catalog=Coock_Ease;Integrated Security=True;MultipleActiveResultSets=true;";
        public Button_Data_Show() { }
        public static string recipeName;
        public static string recipeID;
        public static void buttonDataView()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query1 = "SELECT REC_TITLE FROM CE_RECIPE WHERE REC_ID = @User_ID ";
                    
                    using (SqlCommand command1 = new SqlCommand(query1, connection))
                    {
                        command1.Parameters.AddWithValue("@User_ID", "r");
                        using (SqlDataReader reader1 = command1.ExecuteReader())
                        {
                            if (reader1.Read())
                            {
                                recipeName = reader1["REC_TITLE"] == DBNull.Value ? "" : reader1["REC_TITLE"].ToString();

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
