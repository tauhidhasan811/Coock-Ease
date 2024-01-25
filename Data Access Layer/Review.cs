using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public class Review
    {
        public static string connectionString = "Data Source=DESKTOP-6K06NP6\\SQLEXPRESS;Initial Catalog=Coock_Ease;Integrated Security=True;MultipleActiveResultSets=true;";
        public Review()
        {

        }
        public static void Data_Insert(int star, string comment, string ur_id, string rec_id)
        {
            Check.RecipeExistCheck(rec_id);
            if(Check.isReviewExists == false)
            {
                string insertQuery = "INSERT INTO [dbo].[CE_REVIEW] " +
                                     "([RV_STAR], [RV_COMM], [RV_DATE], [UR_ID], [REC_ID]) " +
                                     "VALUES (@rv_star, @rv_comm, @rv_date, @UR_id, @REC_id)";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        using (SqlCommand command = new SqlCommand(insertQuery, connection))
                        {
                            // Add parameters to the SqlCommand
                            command.Parameters.AddWithValue("@rv_star", star);
                            command.Parameters.AddWithValue("@rv_comm", comment);
                            command.Parameters.AddWithValue("@rv_date", DateTime.Now);
                            command.Parameters.AddWithValue("@UR_id", ur_id);
                            command.Parameters.AddWithValue("@REC_id", rec_id);

                            connection.Open();
                            command.ExecuteNonQuery();
                            MessageBox.Show("Data inserted successfully!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                string updateQuery = "UPDATE [dbo].[CE_REVIEW] " +
                     "SET [RV_STAR] = @rv_star, " +
                     "    [RV_COMM] = @rv_comm, " +
                     "    [RV_DATE] = @rv_date " +
                     "WHERE [UR_ID] = @UR_id AND [REC_ID] = @REC_id";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        using (SqlCommand command = new SqlCommand(updateQuery, connection))
                        {
                            // Add parameters to the SqlCommand
                            command.Parameters.AddWithValue("@rv_star", star);
                            command.Parameters.AddWithValue("@rv_comm", comment);
                            command.Parameters.AddWithValue("@rv_date", DateTime.Now);
                            command.Parameters.AddWithValue("@UR_id", ur_id);
                            command.Parameters.AddWithValue("@REC_id", rec_id);

                            connection.Open();
                            command.ExecuteNonQuery();
                            MessageBox.Show("Data updated successfully!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

            }
        }
    }
}
