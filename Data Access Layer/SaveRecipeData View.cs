using System;
using System.Data.SqlClient;

namespace Data_Access_Layer
{
    public class SaveRecipeData_View
    {
        public static string connectionString = "Data Source=DESKTOP-6K06NP6\\SQLEXPRESS;Initial Catalog=Coock_Ease;Integrated Security=True;MultipleActiveResultSets=true;";
        public static string recipeName1;
        public static string recipeDate1;

        public static string recipeName2;
        public static string recipeDate2;

        public static string recipeName3;
        public static string recipeDate3;

        public static void recipeDataView(string userId)
        {
            string query = "SELECT [REC_ID], [SR_DATE] FROM [CE_SAVE_RECIPE] WHERE [UR_ID] = @recid ORDER BY [SR_DATE] DESC OFFSET 0 ROW FETCH NEXT 1 ROW ONLY";
            string query1 = "SELECT [REC_ID], [SR_DATE] FROM [CE_SAVE_RECIPE] WHERE [UR_ID] = @recid ORDER BY [SR_DATE] DESC OFFSET 1 ROW FETCH NEXT 1 ROW ONLY";
            string query2 = "SELECT [REC_ID], [SR_DATE] FROM [CE_SAVE_RECIPE] WHERE [UR_ID] = @recid ORDER BY [SR_DATE] DESC OFFSET 2 ROW FETCH NEXT 1 ROW ONLY";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@recid", userId);
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                recipeName1 = reader.GetString(0);
                                recipeDate1 = reader.GetDateTime(1).ToString();
                            }
                            else
                            {
                                // Handle case where no data is found
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle the exception
                    }
                }
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query1, connection))
                {
                    command.Parameters.AddWithValue("@recid", userId);
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                recipeName2 = reader.GetString(0);
                                recipeDate2 = reader.GetDateTime(1).ToString();
                            }
                            else
                            {
                                // Handle case where no data is found
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle the exception
                    }
                }
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query2, connection))
                {
                    command.Parameters.AddWithValue("@recid", userId);
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                recipeName3 = reader.GetString(0);
                                recipeDate3 = reader.GetDateTime(1).ToString();
                            }
                            else
                            {
                                // Handle case where no data is found
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle the exception
                    }
                }
            }
        }
    }
}
