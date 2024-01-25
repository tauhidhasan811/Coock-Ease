using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data_Access_Layer;
using System.Data.SqlClient;
namespace COOCK_EASE_PROJECT_FINAL
{
    public partial class DeleteAccount : Form
    {
        public static string connectionString = "Data Source=DESKTOP-6K06NP6\\SQLEXPRESS;Initial Catalog=Coock_Ease;Integrated Security=True;MultipleActiveResultSets=true;";

        public DeleteAccount()
        {
            InitializeComponent();
        }
        private void DeleteData(string tableName, string urIdValue)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand($"DELETE FROM [dbo].[{tableName}] WHERE [UR_ID] = @UR_ID", connection))
                {
                    command.Parameters.AddWithValue("@UR_ID", urIdValue);

                    try
                    {
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // MessageBox.Show($"Data deleted from {tableName} for UR_ID = {urIdValue}");
                        }
                        else
                        {
                            // MessageBox.Show($"No data found for UR_ID = {urIdValue} in {tableName}");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting data: {ex.Message}");
                    }
                }
            }
        }

        private List<string> GetRecIdsForCfId(string cfIdValue)
        {
            List<string> recIdValues = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT REC_ID FROM [dbo].[CE_RECIPE] WHERE CF_ID = @CF_ID", connection))
                {
                    command.Parameters.AddWithValue("@CF_ID", cfIdValue);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Assuming REC_ID is a string; adjust the data type accordingly
                            string recId = reader["REC_ID"].ToString();
                            recIdValues.Add(recId);
                        }
                    }
                }
            }

            return recIdValues;
        }
        private void UpdateData(string tableName, string urIdValue, string columnName, string newData)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand($"UPDATE [dbo].[{tableName}] SET [{columnName}] = @NewData WHERE [CF_ID] = @UR_ID", connection))
                {
                    command.Parameters.AddWithValue("@UR_ID", urIdValue);
                    command.Parameters.AddWithValue("@NewData", newData);

                    try
                    {
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // MessageBox.Show($"Data updated in {tableName} for UR_ID = {urIdValue}");
                        }
                        else
                        {
                            // MessageBox.Show($"No data found for UR_ID = {urIdValue} in {tableName}");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error updating data in {tableName}: {ex.Message}");
                    }
                }
            }
        }

        private void UpdateReviewData(string cfIdValue, string newActiveStatus)
        {
            // Get REC_ID values for the specified CF_ID
            List<string> recIdValues = GetRecIdsForCfId(cfIdValue);

            if (recIdValues.Count > 0)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Construct a comma-separated string for the REC_ID values
                    string recIdList = string.Join(",", recIdValues.Select(id => $"'{id}'"));

                    // Use a parameterized query with a WHERE IN clause
                    using (SqlCommand command = new SqlCommand($"UPDATE [dbo].[CE_REVIEW] SET [RV_ActiveStatus] = @NewActiveStatus WHERE [REC_ID] IN ({recIdList})", connection))
                    {
                        command.Parameters.AddWithValue("@NewActiveStatus", newActiveStatus);

                        try
                        {
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                // MessageBox.Show($"Data updated in CE_REVIEW for REC_ID values: {string.Join(", ", recIdValues)}");
                            }
                            else
                            {
                                // MessageBox.Show($"No data found for REC_ID values: {string.Join(", ", recIdValues)} in CE_REVIEW");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error updating data in CE_REVIEW: {ex.Message}");
                        }
                    }
                }
            }
            else
            {
                // MessageBox.Show($"No REC_ID values found for CF_ID = {cfIdValue} in CE_RECIPE");
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if(LogInHelper.UniversalUserLogIn)
            {
                string urIdValue = LogInHelper.UniversalUserId; // Get UR_ID from your form controls
                DeleteData("CE_REFER", urIdValue);
                DeleteData("CE_REVIEW", urIdValue);
                DeleteData("CE_SAVE_RECIPE", urIdValue);
                DeleteData("CE_USER", urIdValue);
                MessageBox.Show("Account Deleted Successsfully.");
                LogInHelper.UniversalUserLogIn = false;
                LogInHelper.UniversalLogIn = false;
                this.Close();
            }
            else if (LogInShafe.UniversalShafeLogIn)
            {
                string cfIdValue = LogInShafe.UniversalShafeId; // Replace with the actual CF_ID value you want to query
                string newActiveStatus = "Inactive"; // Replace with the desired new value

                // Example: Update data in "CE_REVIEW" for REC_ID values where CF_ID = "A"
                UpdateReviewData(cfIdValue, newActiveStatus);
                using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (SqlTransaction transaction = connection.BeginTransaction())
            {
                try
                {
                    string urIdValue = LogInShafe.UniversalShafeId;

                    // Example: Update data in "CE_RECIPE"
                    UpdateData("CE_RECIPE", urIdValue, "REC_ACTIVE_STATUS", "Inactive");

                    // Example: Update data in "CE_SHAFE"
                    UpdateData("CE_SHAFE", urIdValue, "CF_Active_Status", "Inactive");

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"Transaction failed: {ex.Message}");
                }
            }
        }
                MessageBox.Show("Account Updated Successfully.");
                LogInShafe.UniversalShafeLogIn = false;
                LogInShafe.UniversalShafeLogIn = false;
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            MessageBox.Show("Thank You for brring with us.");
        }
    }
}
