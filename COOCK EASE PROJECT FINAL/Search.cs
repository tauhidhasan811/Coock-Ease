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
    public partial class Search : Form
    {
        public static string connectionString = "Data Source=DESKTOP-6K06NP6\\SQLEXPRESS;Initial Catalog=Coock_Ease;Integrated Security=True;MultipleActiveResultSets=true;";

        public Search()
        {
            string query = "SELECT TOP 1 [REC_ID], [REC_TITLE], [REC_IMG] FROM [CE_RECIPE] WHERE ([REC_ID] = @recId OR [REC_TITLE] = @recTitle) AND [REC_ACTIVE_STATUS] = 'Active';";
            InitializeComponent();
            textBox1.Text = Home_Page.searchID;
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@recId", textBox1.Text);
                    command.Parameters.AddWithValue("@recTitle", textBox1.Text);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string recId = reader.GetString(0);
                            string recTitle = reader.GetString(1);
                            label2.Text = recTitle;
                            label3.Text = recId;
                            byte[] imageData = reader["REC_IMG"] as byte[];
                            if (imageData != null)
                            {
                                System.Drawing.Image image = ByteArrayToImage(imageData);
                                System.Drawing.Image resizedImage = ResizeImage(image, 240, 200);
                                pictureBox1.Image = resizedImage;
                            }
                        }
                        else
                        {
                            label2.Text = "No Data";
                            label3.Text = "No id";
                            pictureBox1.Image = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            System.Drawing.Image ByteArrayToImage(byte[] byteArray)
            {
                MemoryStream memoryStream = new MemoryStream(byteArray);
                return System.Drawing.Image.FromStream(memoryStream);
            }

            System.Drawing.Image ResizeImage(System.Drawing.Image originalImage, int width, int height)
            {
                Bitmap resizedImage = new Bitmap(width, height);
                using (Graphics graphics = Graphics.FromImage(resizedImage))
                {
                    graphics.DrawImage(originalImage, 0, 0, width, height);
                }
                return resizedImage;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Search_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "SELECT TOP 1 [REC_ID], [REC_TITLE], [REC_IMG] FROM [CE_RECIPE] WHERE ( [REC_ID] = @recId OR [REC_TITLE] = @recTitle ) AND  [REC_ACTIVE_STATUS] = 'Active';";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@recId", textBox1.Text);
                    command.Parameters.AddWithValue("@recTitle", textBox1.Text);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string recId = reader.GetString(0);
                            string recTitle = reader.GetString(1);
                            label2.Text = recTitle;
                            label3.Text = recId;
                            byte[] imageData = reader["REC_IMG"] as byte[];
                            if (imageData != null)
                            {
                                System.Drawing.Image image = ByteArrayToImage(imageData);
                                System.Drawing.Image resizedImage = ResizeImage(image, 240, 200);
                                pictureBox1.Image = resizedImage;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Sorry No Data Found.");
                            button3.Dispose();
                            label2.Text = "No Data Found";
                            label2.ForeColor = Color.AliceBlue;
                            label3.Dispose();
                            pictureBox1.Image = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            System.Drawing.Image ByteArrayToImage(byte[] byteArray)
            {
                MemoryStream memoryStream = new MemoryStream(byteArray);
                return System.Drawing.Image.FromStream(memoryStream);
            }

            System.Drawing.Image ResizeImage(System.Drawing.Image originalImage, int width, int height)
            {
                Bitmap resizedImage = new Bitmap(width, height);
                using (Graphics graphics = Graphics.FromImage(resizedImage))
                {
                    graphics.DrawImage(originalImage, 0, 0, width, height);
                }
                return resizedImage;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (label2.Text == "No Data")
            {
                button3.Dispose();
            }
            else
            {
                Recipe.RecipeID = label3.Text;
                RecipeShafe.RecipeID = label3.Text;
                Recipe_Demo.RecipeID = label3.Text;
                if (LogInHelper.UniversalUserLogIn || LogInShafe.UniversalShafeLogIn || LogInSpornsorHelper.UniversalSponsorLogIn)
                {
                    if (LogInShafe.UniversalShafeLogIn)
                    {
                        RecipeType.RecipeTypeData(label3.Text);
                        if (RecipeType.ownPost)
                        {

                            RecipeShafe shafe = new RecipeShafe();
                            shafe.Show();
                        }
                        else
                        {

                            Recipe recipe = new Recipe();
                            recipe.Show();

                        }
                    }
                    else
                    {
                        Recipe recipe = new Recipe();
                        recipe.Show();
                    }

                }
                else
                {

                    Recipe_Demo recipe_Demo = new Recipe_Demo();
                    recipe_Demo.Show();
                }
            }
            
        }
    }
}
