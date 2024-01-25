using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Data_Access_Layer
{
    public class Coocking_Steps
    {
        public Coocking_Steps()
        {

        }

        public static string connectionString = "Data Source=DESKTOP-6K06NP6\\SQLEXPRESS;Initial Catalog=Coock_Ease;Integrated Security=True;MultipleActiveResultSets=true;";

        public static void Data_Insert(int num, string step_1, int step_1_time, string step_2, int step_2_time, string step_3, int step_3_time, string step_4, int step_4_time, string step_5, int step_5_time, string step_6, int step_6_time, string step_7, int step_7_time, string repice_id)
        {
            string insertQuery = "INSERT INTO [dbo].[CE_COOCKING_STEP] " +
                                 "( [CS_STEP_NUM], [CS_STEP-1_DETAILS], [CS_STEP-1_TIME], [CS_STEP-2_DETAILS], [CS_STEP-2_TIME], [CS_STEP-3_DETAILS], [CS_STEP-3_TIME], [CS_STEP-4_DETAILS], [CS_STEP-4_TIME], [CS_STEP-5_DETAILS], [CS_STEP-5_TIME], [CS_STEP-6_DETAILS], [CS_STEP-6_TIME], [CS_STEP-7_DETAILS], [CS_STEP-7_TIME], [REC_ID]) " +
                                 "VALUES ( @STEP_NUM, @Step_1, @Step_1_time, @Step_2, @Step_2_time, @Step_3, @Step_3_time, @Step_4, @Step_4_time, @Step_5, @Step_5_time, @Step_6, @Step_6_time, @Step_7, @Step_7_time, @Repice_id)";

            // Execute the query
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        // Add parameters to the SqlCommand
                       
                        command.Parameters.AddWithValue("@STEP_NUM", num);
                        command.Parameters.AddWithValue("@Step_1", step_1);
                        command.Parameters.AddWithValue("@Step_1_time", step_1_time);
                        command.Parameters.AddWithValue("@Step_2", step_2);
                        command.Parameters.AddWithValue("@Step_2_time", step_2_time);
                        command.Parameters.AddWithValue("@Step_3", step_3);
                        command.Parameters.AddWithValue("@Step_3_time", step_3_time);
                        command.Parameters.AddWithValue("@Step_4", step_4);
                        command.Parameters.AddWithValue("@Step_4_time", step_4_time);
                        command.Parameters.AddWithValue("@Step_5", step_5);
                        command.Parameters.AddWithValue("@Step_5_time", step_5_time);
                        command.Parameters.AddWithValue("@Step_6", step_6);
                        command.Parameters.AddWithValue("@Step_6_time", step_6_time);
                        command.Parameters.AddWithValue("@Step_7", step_7);
                        command.Parameters.AddWithValue("@Step_7_time", step_7_time);
                        command.Parameters.AddWithValue("@Repice_id", repice_id);

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
    }
}
