using Presentation_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Data_Access_Layer;
namespace COOCK_EASE_PROJECT_FINAL
{
    public partial class Recipe : Form
    {
        public static string RecipeID;//= Home_Page.Label1;
        public static string connectionString = "Data Source=DESKTOP-6K06NP6\\SQLEXPRESS;Initial Catalog=Coock_Ease;Integrated Security=True;MultipleActiveResultSets=true;";

        public Recipe()
        {
            InitializeComponent();
            Recipe_Data_View.dataView(RecipeID);
            label1.Text = Recipe_Data_View.title;
            label20.Text = RecipeID;
            label2.Text = Recipe_Data_View.description;
            label6.Text = Recipe_Data_View.component;
            label5.Text = Recipe_Data_View.shafeName;

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


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Recipe_Load(object sender, EventArgs e)
        {


        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                errorProvider1.SetError(checkBox1, "You must check the checkbox.");
                return;
            }
            else
            {

            }
            Coocking_Step_DataView.Coocking_Step_Data_View(RecipeID);
            COOCK_EASE_PROJECT_FINAL.Coocking_Step coocking_Step = new Coocking_Step();
            coocking_Step.Show();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Review.Data_Insert(Convert.ToInt32(radioButton1.Text), textBox1.Text, LogInHelper.UniversalUserId, RecipeID);
            }
            else if (radioButton2.Checked)
            {
                Review.Data_Insert(Convert.ToInt32(radioButton2.Text), textBox1.Text, LogInHelper.UniversalUserId, RecipeID);
            }
            else if (radioButton3.Checked)
            {
                Review.Data_Insert(Convert.ToInt32(radioButton3.Text), textBox1.Text, LogInHelper.UniversalUserId, RecipeID);
            }
            else if (radioButton4.Checked)
            {
                Review.Data_Insert(Convert.ToInt32(radioButton4.Text), textBox1.Text, LogInHelper.UniversalUserId, RecipeID);
            }
            else
            {
                Review.Data_Insert(Convert.ToInt32(radioButton5.Text), textBox1.Text, LogInHelper.UniversalUserId, RecipeID);
            }

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Check.saveCheckDataExists(Recipe.RecipeID);
            string query = "INSERT INTO [CE_SAVE_RECIPE] ([SR_DATE], [UR_ID], [REC_ID]) " +
                           "VALUES (@SR_DATE, @UR_ID, @REC_ID)";

            if (Check.isSaveExists)
            {
                if (LogInSpornsorHelper.UniversalSponsorLogIn)
                {
                    button6.Hide();
                }
                MessageBox.Show("You Already Save This item.");
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the SqlCommand
                    command.Parameters.AddWithValue("@SR_DATE", DateTime.Now);
                    command.Parameters.AddWithValue("@UR_ID", LogInHelper.UniversalUserId);
                    command.Parameters.AddWithValue("@REC_ID", RecipeID);

                    try
                    {
                        // Open the connection and execute the query
                        connection.Open();
                        command.ExecuteNonQuery();

                        MessageBox.Show("Data inserted successfully!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
                if (LogInSpornsorHelper.UniversalSponsorLogIn)
                {
                    button6.Hide();
                }
            }

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
