using Data_Access_Layer;
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
namespace COOCK_EASE_PROJECT_FINAL
{
    public partial class RecipeShafe : Form
    {
        public static string RecipeID;
        public static string connectionString = "Data Source=DESKTOP-6K06NP6\\SQLEXPRESS;Initial Catalog=Coock_Ease;Integrated Security=True;MultipleActiveResultSets=true;";

        public RecipeShafe()
        {
            InitializeComponent();
            Recipe_Data_View.dataView(RecipeID);
            label1.Text = Recipe_Data_View.title;
            label20.Text = RecipeID;
            label2.Text = Recipe_Data_View.description;
            label6.Text = Recipe_Data_View.component;

            string query = "SELECT TOP 1 [UR_ID], [RV_STAR], [RV_COMM] FROM [CE_REVIEW] WHERE [REC_ID] =@recid ORDER BY [RV_ID] DESC";
            string query1 = "SELECT [UR_ID], [RV_STAR], [RV_COMM] FROM  [CE_REVIEW]  WHERE [REC_ID] =@recid ORDER BY [RV_ID] DESC OFFSET 1 ROW FETCH NEXT 1 ROW ONLY";
            string query2 = "SELECT [UR_ID], [RV_STAR], [RV_COMM] FROM  [CE_REVIEW] WHERE [REC_ID] =@recid ORDER BY [RV_ID] DESC OFFSET 2 ROW FETCH NEXT 1 ROW ONLY";
            string query3 = "SELECT UR_NAME FROM CE_USER WHERE UR_ID=@ueId";

            using (SqlConnection connection = new SqlConnection(connectionString))

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@recid", RecipeID);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string urid = reader.GetString(0);
                            int star = reader.GetInt32(1);
                            string rvcomm = reader.GetString(2);

                            label19.Text = "Reviewed Start: " + Convert.ToString(star);
                            label13.Text = "Comment : " + rvcomm;
                            SqlCommand cmd = new SqlCommand(query3, connection);
                            cmd.Parameters.AddWithValue("@ueId", urid);

                            using (SqlDataReader reader1 = cmd.ExecuteReader())
                            {
                                if (reader1.Read())
                                {
                                    label18.Text = reader1["UR_NAME"].ToString();
                                    label12.Text = reader1["UR_NAME"].ToString();
                                }
                            }

                        }
                        else
                        {
                            //MessageBox.Show("No data found.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query1, connection))
            {
                command.Parameters.AddWithValue("@recid", RecipeID);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string urid = reader.GetString(0);
                            int star = reader.GetInt32(1);
                            string rvcomm = reader.GetString(2);

                            label17.Text = "Reviewed Start: " + Convert.ToString(star);
                            label11.Text = "Comment : " + rvcomm;
                            SqlCommand cmd = new SqlCommand(query3, connection);
                            cmd.Parameters.AddWithValue("@ueId", urid);

                            using (SqlDataReader reader1 = cmd.ExecuteReader())
                            {
                                if (reader1.Read())
                                {
                                    label16.Text = reader1["UR_NAME"].ToString();
                                    label10.Text = reader1["UR_NAME"].ToString();
                                }
                            }

                        }
                        else
                        {
                            //MessageBox.Show("No data found.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query2, connection))
            {
                command.Parameters.AddWithValue("@recid", RecipeID);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string urid = reader.GetString(0);
                            int star = reader.GetInt32(1);
                            string rvcomm = reader.GetString(2);

                            label15.Text = "Reviewed Start: " + Convert.ToString(star);
                            label9.Text = "Comment : " + rvcomm;
                            SqlCommand cmd = new SqlCommand(query3, connection);
                            cmd.Parameters.AddWithValue("@ueId", urid);

                            using (SqlDataReader reader1 = cmd.ExecuteReader())
                            {
                                if (reader1.Read())
                                {
                                    label14.Text = reader1["UR_NAME"].ToString();
                                    label8.Text = reader1["UR_NAME"].ToString();
                                }
                            }

                        }
                        else
                        {
                            //MessageBox.Show("No data found.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
                using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query4 = "SELECT REC_IMG FROM CE_RECIPE WHERE REC_ID = @User_ID ";
                using (SqlCommand command4 = new SqlCommand(query4, connection))
                {
                    command4.Parameters.AddWithValue("@User_ID", RecipeID);
                    using (SqlDataReader reader4 = command4.ExecuteReader())
                    {
                        if (reader4.Read())
                        {
                            byte[] imageData = reader4["REC_IMG"] != DBNull.Value ? (byte[])reader4["REC_IMG"] : null;
                            if (imageData != null && imageData.Length > 0)
                            {
                                using (MemoryStream ms = new MemoryStream(imageData))
                                {
                                    pictureBox1.Image = System.Drawing.Image.FromStream(ms);
                                }
                            }
                            else
                            {

                            }

                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EditRecipe.RecipeID = label20.Text;
            EditRecipe editRecipe = new EditRecipe();
            editRecipe.Show();
        }

        private void RecipeShafe_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string updateQuery = @"
                        UPDATE [dbo].[CE_RECIPE]
                        SET [REC_ACTIVE_STATUS] = 'Inactive'
                        WHERE [REC_ID] = @RecId;
                    ";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@RecId", RecipeID);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Deleted successful.");
                            Home_Page home_Page = new Home_Page();
                            home_Page.Show();
                            this.Close();
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
                    string recIdValue = RecipeID;

                    string updateQuery = "UPDATE CE_REVIEW SET RV_ActiveStatus = 'Inactive' WHERE REC_ID = @RecId";

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
        }
    }
}
