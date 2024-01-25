using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Data_Access_Layer;

namespace COOCK_EASE_PROJECT_FINAL
{
    public partial class RecipeRecover : Form
    {
        public static string connectionString = "Data Source=DESKTOP-6K06NP6\\SQLEXPRESS;Initial Catalog=Coock_Ease;Integrated Security=True;MultipleActiveResultSets=true;";

        public RecipeRecover()
        {
            InitializeComponent();
            string query = "SELECT [REC_IMG], [REC_TITLE], [REC_ID] FROM [dbo].[CE_RECIPE] WHERE [REC_ACTIVE_STATUS] = 'Inactive' ORDER BY [REC_DATE] DESC OFFSET 0 ROW FETCH NEXT 1 ROW ONLY ";
            string query1 = "SELECT [REC_IMG], [REC_TITLE], [REC_ID] FROM [dbo].[CE_RECIPE] WHERE [REC_ACTIVE_STATUS] = 'Inactive' ORDER BY [REC_DATE] DESC OFFSET 1 ROW FETCH NEXT 1 ROW ONLY ";
            string query2 = "SELECT [REC_IMG], [REC_TITLE], [REC_ID] FROM [dbo].[CE_RECIPE] WHERE [REC_ACTIVE_STATUS] = 'Inactive' ORDER BY [REC_DATE] DESC OFFSET 2 ROW FETCH NEXT 1 ROW ONLY ";
            string query3 = "SELECT [REC_IMG], [REC_TITLE], [REC_ID] FROM [dbo].[CE_RECIPE] WHERE [REC_ACTIVE_STATUS] = 'Inactive' ORDER BY [REC_DATE] DESC OFFSET 3 ROW FETCH NEXT 1 ROW ONLY ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            pictureBox8.Image = GetImageFromByteArray(reader["REC_IMG"] as byte[]);
                            label10.Text = reader["REC_TITLE"].ToString();
                            label9.Text = reader["REC_ID"].ToString();
                        }
                        else
                        {
                            //MessageBox.Show("Recipe not found.");
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
                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            pictureBox7.Image = GetImageFromByteArray(reader["REC_IMG"] as byte[]);
                            label8.Text = reader["REC_TITLE"].ToString();
                            label7.Text = reader["REC_ID"].ToString();
                        }
                        else
                        {
                            //MessageBox.Show("Recipe not found.");
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
                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            pictureBox6.Image = GetImageFromByteArray(reader["REC_IMG"] as byte[]);
                            label6.Text = reader["REC_TITLE"].ToString();
                            label5.Text = reader["REC_ID"].ToString();
                        }
                        else
                        {
                            //MessageBox.Show("Recipe not found.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Error: " + ex.Message);
                }
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query3, connection))
            {
                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            pictureBox5.Image = GetImageFromByteArray(reader["REC_IMG"] as byte[]);
                            label4.Text = reader["REC_TITLE"].ToString();
                            label3.Text = reader["REC_ID"].ToString();
                        }
                        else
                        {
                            //MessageBox.Show("Recipe not found.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Error: " + ex.Message);
                }
            }
            if (string.IsNullOrEmpty(label9.Text))
            {
                button6.Dispose();
            }
            if (string.IsNullOrEmpty(label7.Text))
            {
                button5.Dispose();
            }
            if (string.IsNullOrEmpty(label5.Text)) 
            { 
                button4.Dispose();
            }
            if(string.IsNullOrEmpty(label3.Text))
            {
                button3.Dispose();
            }
        }
        private Image GetImageFromByteArray(byte[] byteArray)
        {
            if (byteArray == null)
                return null;

            using (var stream = new System.IO.MemoryStream(byteArray))
            {
                return Image.FromStream(stream);
            }
        }

        private void RecipeRecover_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string updateQuery = @"
                        UPDATE [dbo].[CE_RECIPE]
                        SET [REC_ACTIVE_STATUS] = 'Active'
                        WHERE [REC_ID] = @RecId;
                    ";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@RecId", label9.Text);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Restored successful.");
                        }
                        else
                        {
                            MessageBox.Show("No rows were updated. Check if REC_ID  exists.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Assuming REC_ID is a string, replace string with the appropriate type
                    string recIdValue = label9.Text;

                    string updateQuery = "UPDATE CE_REVIEW SET RV_ActiveStatus = 'Active' WHERE REC_ID = @RecId";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@RecId", recIdValue);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            
                            //MessageBox.Show("Update successful");
                        }
                        else
                        {
                            //MessageBox.Show("No records were updated");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            RecipeRecover recipeRecover = new RecipeRecover();
            recipeRecover.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string updateQuery = @"
                        UPDATE [dbo].[CE_RECIPE]
                        SET [REC_ACTIVE_STATUS] = 'Active'
                        WHERE [REC_ID] = @RecId;
                    ";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@RecId", label7.Text);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Restored successful.");
                        }
                        else
                        {
                            MessageBox.Show("No rows were updated. Check if REC_ID 'beefcurry1' exists.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Assuming REC_ID is a string, replace string with the appropriate type
                    string recIdValue = label7.Text;

                    string updateQuery = "UPDATE CE_REVIEW SET RV_ActiveStatus = 'Active' WHERE REC_ID = @RecId";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@RecId", recIdValue);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            //MessageBox.Show("Update successful");
                        }
                        else
                        {
                            //MessageBox.Show("No records were updated");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            RecipeRecover recipeRecover = new RecipeRecover();
            recipeRecover.Show();
            this.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string updateQuery = @"
                        UPDATE [dbo].[CE_RECIPE]
                        SET [REC_ACTIVE_STATUS] = 'Active'
                        WHERE [REC_ID] = @RecId;
                    ";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@RecId", label5.Text);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Restored successful.");
                        }
                        else
                        {
                            MessageBox.Show("No rows were updated. Check if REC_ID 'beefcurry1' exists.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Assuming REC_ID is a string, replace string with the appropriate type
                    string recIdValue = label5.Text;

                    string updateQuery = "UPDATE CE_REVIEW SET RV_ActiveStatus = 'Active' WHERE REC_ID = @RecId";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@RecId", recIdValue);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            //MessageBox.Show("Update successful");
                        }
                        else
                        {
                            //MessageBox.Show("No records were updated");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            RecipeRecover recipeRecover = new RecipeRecover();
            recipeRecover.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string updateQuery = @"
                        UPDATE [dbo].[CE_RECIPE]
                        SET [REC_ACTIVE_STATUS] = 'Active'
                        WHERE [REC_ID] = @RecId;
                    ";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@RecId", label3.Text);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Restored successful.");
                        }
                        else
                        {
                            MessageBox.Show("No rows were updated. Check if REC_ID 'beefcurry1' exists.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Assuming REC_ID is a string, replace string with the appropriate type
                    string recIdValue = label3.Text;

                    string updateQuery = "UPDATE CE_REVIEW SET RV_ActiveStatus = 'Active' WHERE REC_ID = @RecId";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@RecId", recIdValue);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            //MessageBox.Show("Update successful");
                        }
                        else
                        {
                            //MessageBox.Show("No records were updated");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            RecipeRecover recipeRecover = new RecipeRecover();
            recipeRecover.Show();
            this.Close();
        }
    }
}
