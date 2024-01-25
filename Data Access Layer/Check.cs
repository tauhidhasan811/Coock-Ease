using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{

    public class Check
    {
        public static string connectionString = "Data Source=DESKTOP-6K06NP6\\SQLEXPRESS;Initial Catalog=Coock_Ease;Integrated Security=True;MultipleActiveResultSets=true;";

        public static bool isReviewExists = false;
        public static bool isSaveExists = false;
        public static void RecipeExistCheck(string recipeId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM [dbo].[CE_REVIEW] WHERE [UR_ID] = @UrId AND [REC_ID]=@recId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Use parameterized query to avoid SQL injection
                    command.Parameters.AddWithValue("@UrId", LogInHelper.UniversalUserId);
                    command.Parameters.AddWithValue("@recId", recipeId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int count = reader.GetInt32(0);
                            if(count > 0)
                            {
                                isReviewExists = true;
                            }
                            else
                            {
                                isSaveExists = false;
                            }
                        }
                    }
                }
            }
        }
        public static void saveCheckDataExists( string recId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT TOP 1 1 FROM [dbo].[CE_SAVE_RECIPE] WHERE [UR_ID] = @UrId AND [REC_ID] = @RecId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UrId", LogInHelper.UniversalUserId);
                    command.Parameters.AddWithValue("@RecId", recId);

                    using (SqlDataReader reader = command.ExecuteReader())
                        if (reader.Read())
                        {
                            isSaveExists = true;
                        }
                        else
                        {
                            isSaveExists = false;
                        }
                }
            }
        }
    }
}
