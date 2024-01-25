using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Data_Access_Layer
{
    public  class Recipe_Data_View
    {
        public Recipe_Data_View() { }
        public static string connectionString = "Data Source=DESKTOP-6K06NP6\\SQLEXPRESS;Initial Catalog=Coock_Ease;Integrated Security=True;MultipleActiveResultSets=true;";

        //public static string UserId = LogInHelper.UniversalUserId;
        public static string title= " ";
        public static string description=" ";
        public static string component= " ";
        public static string shafeName= " ";
        public static void dataView(string recipeId)
        {
            title = " ";
            description = " ";
            component = " ";
            shafeName = " ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query1 = "SELECT REC_TITLE FROM CE_RECIPE WHERE REC_ID = @User_ID ";
                    string query2 = "SELECT REC_DESC FROM CE_RECIPE WHERE REC_ID = @User_ID ";
                    string query3 = "SELECT REC_COMPONENT FROM CE_RECIPE WHERE REC_ID = @User_ID ";
                    string query4 = "SELECT CF_NAME FROM CE_SHAFE WHERE CF_ID = (SELECT CF_ID FROM CE_RECIPE WHERE REC_ID = @User_ID )  ";

                    using (SqlCommand command1 = new SqlCommand(query1, connection))
                    {
                        command1.Parameters.AddWithValue("@User_ID", recipeId);
                        using (SqlDataReader reader1 = command1.ExecuteReader())
                        {
                            if (reader1.Read())
                            {
                                title = reader1["REC_TITLE"] == DBNull.Value ? "" : reader1["REC_TITLE"].ToString();

                            }
                        }
                    }
                    using (SqlCommand command2 = new SqlCommand(query2, connection))
                    {
                        command2.Parameters.AddWithValue("@User_ID", recipeId);
                        using (SqlDataReader reader2 = command2.ExecuteReader())
                        {
                            if (reader2.Read())
                            {
                                description = reader2["REC_DESC"] == DBNull.Value ? "" : reader2["REC_DESC"].ToString();

                            }
                        }
                    }
                    using (SqlCommand command3 = new SqlCommand(query3, connection))
                    {
                        command3.Parameters.AddWithValue("@User_ID", recipeId);
                        using (SqlDataReader reader3 = command3.ExecuteReader())
                        {
                            if (reader3.Read())
                            { 
                                component = reader3["REC_COMPONENT"].ToString();

                            }
                        }
                    }
                    using (SqlCommand command4 = new SqlCommand(query4, connection))
                    {
                        command4.Parameters.AddWithValue("@User_ID", recipeId);
                        using (SqlDataReader reader4 = command4.ExecuteReader())
                        {
                            if (reader4.Read())
                            {
                                shafeName = reader4["CF_NAME"].ToString();

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
