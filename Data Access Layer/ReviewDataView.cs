using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Data_Access_Layer
{
    public  class ReviewDataView
    {
        public static string connectionString = "Data Source=DESKTOP-6K06NP6\\SQLEXPRESS;Initial Catalog=Coock_Ease;Integrated Security=True;MultipleActiveResultSets=true;";
        public static string recipeStar1;
        public static string recipeComment1;
        public static string recipeID1;
        public static string recipeDate1;

        public static string recipeStar2;
        public static string recipeComment2;
        public static string recipeID2;
        public static string recipeDate2;

        public static string recipeStar3;
        public static string recipeComment3;
        public static string recipeID3;
        public static string recipeDate3;

        public static string recipeStar4;
        public static string recipeComment4;
        public static string recipeUser4;
        public static string recipeDate4;
        public static void recipeDataView(string userId)
        {
            recipeStar1=" ";
            recipeComment1=" ";
            recipeID1 = " ";
            recipeDate1 = " ";

            recipeStar2 = " ";
            recipeComment2 = " ";
            recipeID2 = " ";
            recipeDate2 = " ";
            recipeStar3 = " ";
            recipeComment3 = " ";
            recipeID3 = " ";
            recipeDate3 = " ";
            recipeStar4 = " ";
            recipeComment4 = " ";
            recipeUser4 = " ";
            recipeDate4 = " ";
            string query  = "SELECT [RV_STAR], [RV_COMM] ,[REC_ID], [RV_DATE] FROM [CE_REVIEW] WHERE [UR_ID] =@recid AND [RV_ActiveStatus] = 'Active' ORDER BY [RV_ID] DESC OFFSET 0 ROW FETCH NEXT 1 ROW ONLY ";
            string query1 = "SELECT [RV_STAR], [RV_COMM] ,[REC_ID], [RV_DATE] FROM  [CE_REVIEW]  WHERE [UR_ID] =@recid AND [RV_ActiveStatus] = 'Active' ORDER BY [RV_ID] DESC OFFSET 1 ROW FETCH NEXT 1 ROW ONLY";
            string query2 = "SELECT [RV_STAR], [RV_COMM] ,[REC_ID], [RV_DATE] FROM  [CE_REVIEW] WHERE [UR_ID] =@recid  AND [RV_ActiveStatus] = 'Active' ORDER BY [RV_ID] DESC OFFSET 2 ROW FETCH NEXT 1 ROW ONLY";
            //string query3 = "SELECT UR_NAME FROM CE_USER WHERE UR_ID=@ueId";

            using (SqlConnection connection = new SqlConnection(connectionString))

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
                            recipeStar1 = reader.GetInt32(0).ToString();
                            recipeComment1 = reader.GetString(1);
                            recipeID1 = reader.GetString(2);
                            recipeDate1 = reader.GetDateTime(3).ToString();
                        }
                        else
                        {
                            //MessageBox.Show("No data found.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Error: " + ex.Message);
                }
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
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
                            recipeStar2 = reader.GetInt32(0).ToString();
                            recipeComment2 = reader.GetString(1);
                            recipeID2 = reader.GetString(2);
                            recipeDate2 = reader.GetDateTime(4).ToString();
                        }
                        else
                        {
                            //MessageBox.Show("No data found.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Error: " + ex.Message);
                }
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
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
                            recipeStar3 = reader.GetInt32(0).ToString();
                            recipeComment3 = reader.GetString(1);
                            recipeID3 = reader.GetString(2);
                            recipeDate3 = reader.GetDateTime(4).ToString();

                        }
                        else
                        {
                            //MessageBox.Show("No data found.");
                        }
                    }
                }
                catch (Exception ex)
                {
                   // MessageBox.Show("Error: " + ex.Message);
                }
            }

            
        }
    }
}
