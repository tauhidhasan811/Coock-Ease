using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.ComponentModel;
namespace Data_Access_Layer
{
    public  class SearchData
    {
        public static string connectionString = "Data Source=DESKTOP-6K06NP6\\SQLEXPRESS;Initial Catalog=Coock_Ease;Integrated Security=True;MultipleActiveResultSets=true;";
        
        public static string title;
        public static string recipeId;
        public static int count;
        public static void SearchDataView(string SearchName)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query1 = "SELECT REC_TITLE FROM CE_RECIPE WHERE REC_ID = @Recipeid OR REC_TITLE=@Recipetitle";
                    string query2 = "SELECT REC_ID FROM CE_RECIPE WHERE REC_ID = @Recipeid  ORREC_TITLE= @Recipetitle";
                    string sqlQuery = "SELECT COUNT(REC_ID) FROM CE_RECIPE WHERE REC_ID = @Recipeid OR REC_TITLE=@Recipetitle";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Recipeid", SearchName);
                        command.Parameters.AddWithValue("@Recipetitle", SearchName);
                        try
                        {
                             count = (int)command.ExecuteScalar();
                            //MessageBox.Show(Convert.ToString(count));
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    if(count!=0)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            using (SqlCommand command1 = new SqlCommand(query1, connection))
                            {
                                command1.Parameters.AddWithValue("@Recipeid", SearchName);
                                command1.Parameters.AddWithValue("@Recipetitle", SearchName);
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
                                        recipeId = reader2["REC_ID"] == DBNull.Value ? "" : reader2["REC_ID"].ToString();

                                    }
                                }
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
