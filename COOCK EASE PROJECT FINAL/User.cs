using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Presentation_Layer.PhotoHelper;
using System.Data;
using System.Data.SqlClient;
using Data_Access_Layer;
using Microsoft.VisualBasic.ApplicationServices;
using static System.Net.Mime.MediaTypeNames;
using COOCK_EASE_PROJECT_FINAL;
namespace Presentation_Layer
{


    public partial class User : Form
    {
        public static string connectionString = "Data Source=DESKTOP-6K06NP6\\SQLEXPRESS;Initial Catalog=Coock_Ease;Integrated Security=True;MultipleActiveResultSets=true;";

        public User()
        {
            InitializeComponent();
            ReviewDataView.recipeDataView(LogInHelper.UniversalUserId);
            SaveRecipeData_View.recipeDataView(LogInHelper.UniversalUserId);
            label11.Text = "Given star: " + ReviewDataView.recipeStar1;
            label21.Text = "Given star: " + ReviewDataView.recipeStar2;
            label23.Text = "Given star: " + ReviewDataView.recipeStar3;
            label10.Text = "Recipe ID: " + ReviewDataView.recipeID1;
            label24.Text = "Recipe ID: " + ReviewDataView.recipeID1;
            label26.Text = "Recipe ID: " + ReviewDataView.recipeID2;
            label20.Text = "Recipe ID: " + ReviewDataView.recipeID2;
            label34.Text = "Recipe ID: " + ReviewDataView.recipeID3;
            label22.Text = "Recipe ID: " + ReviewDataView.recipeID3;

            label25.Text = "Comment: " + ReviewDataView.recipeComment1;
            label27.Text = "Comment: " + ReviewDataView.recipeComment2;
            label35.Text = "Comment: " + ReviewDataView.recipeComment3;

            label29.Text = SaveRecipeData_View.recipeName1;
            label31.Text = SaveRecipeData_View.recipeName2;
            label33.Text = SaveRecipeData_View.recipeName3;
            label28.Text = SaveRecipeData_View.recipeDate1;
            label30.Text = SaveRecipeData_View.recipeDate2;
            label32.Text = SaveRecipeData_View.recipeDate3;

            AddPhotoToSpecificPictureBox();
            User_Profile_View.dataView();
            label1.Text = User_Profile_View.FullName;
            label2.Text = "@" + User_Profile_View.UserId;
            DateTime dateTime = User_Profile_View.dateTime;
            string date = dateTime.ToString("dd-MM-yyyy");
            label7.Text = User_Profile_View.ReferId;
            label4.Text = date;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query4 = "SELECT UR_PP FROM CE_USER WHERE UR_ID = @User_ID ";
                string query5 = "SELECT UR_COV_PP FROM CE_USER WHERE UR_ID = @User_ID ";
                using (SqlCommand command5 = new SqlCommand(query5, connection))
                {
                    command5.Parameters.AddWithValue("@User_ID", LogInHelper.UniversalUserId);
                    using (SqlDataReader reader5 = command5.ExecuteReader())
                    {
                        if (reader5.Read())
                        {
                            byte[] imageData = reader5["UR_COV_PP"] != DBNull.Value ? (byte[])reader5["UR_COV_PP"] : null;
                            if (imageData != null && imageData.Length > 0)
                            {
                                using (MemoryStream ms = new MemoryStream(imageData))
                                {
                                    pictureBox2.Image = System.Drawing.Image.FromStream(ms);
                                }
                            }
                        }
                    }
                }
                using (SqlCommand command4 = new SqlCommand(query4, connection))
                {
                    command4.Parameters.AddWithValue("@User_ID", LogInHelper.UniversalUserId);
                    using (SqlDataReader reader4 = command4.ExecuteReader())
                    {
                        if (reader4.Read())
                        {
                            byte[] imageData = reader4["UR_PP"] != DBNull.Value ? (byte[])reader4["UR_PP"] : null;
                            if (imageData != null && imageData.Length > 0)
                            {
                                using (MemoryStream ms = new MemoryStream(imageData))
                                {
                                    pictureBox3.Image = System.Drawing.Image.FromStream(ms);
                                }
                            }
                        }
                    }
                }
            }
            int referCount = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query35 = "SELECT COUNT(*) FROM CE_REFER WHERE UR_ID = @urId";

                    using (SqlCommand command = new SqlCommand(query35, connection))
                    {
                        command.Parameters.AddWithValue("@urId", LogInHelper.UniversalUserId);

                        referCount = (int)command.ExecuteScalar();

                        //MessageBox.Show(Convert.ToString(referCount * 50));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            label36.Text = (referCount * 50).ToString();
            /* ------------------------------FOR YOU MIGTH LIKE---------------------------------------------------------*/

            string query = "SELECT[REC_ID], [REC_TITLE], [REC_IMG] FROM[CE_RECIPE] ORDER BY[REC_DATE] OFFSET 0 ROW FETCH NEXT 1 ROW ONLY";
            string query1 = "SELECT[REC_ID], [REC_TITLE], [REC_IMG] FROM[CE_RECIPE] ORDER BY[REC_DATE] OFFSET 1 ROW FETCH NEXT 1 ROW ONLY";
            string query2 = "SELECT[REC_ID], [REC_TITLE], [REC_IMG] FROM[CE_RECIPE] ORDER BY[REC_DATE] OFFSET 2 ROW FETCH NEXT 1 ROW ONLY";
            string query3 = "SELECT[REC_ID], [REC_TITLE], [REC_IMG] FROM[CE_RECIPE] ORDER BY[REC_DATE] OFFSET 3 ROW FETCH NEXT 1 ROW ONLY";
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
                            string recId = reader.GetString(0);
                            string recTitle = reader.GetString(1);
                            label13.Text = recTitle;
                            label12.Text = recId;
                            byte[] imageData = reader["REC_IMG"] as byte[];
                            if (imageData != null)
                            {
                                System.Drawing.Image image = ByteArrayToImage(imageData);
                                System.Drawing.Image resizedImage = ResizeImage(image, 240, 200);
                                pictureBox1.Image = resizedImage;
                            }
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
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string recId = reader.GetString(0);
                            string recTitle = reader.GetString(1);
                            label19.Text = recTitle;
                            label18.Text = recId;
                            byte[] imageData = reader["REC_IMG"] as byte[];
                            if (imageData != null)
                            {
                                System.Drawing.Image image = ByteArrayToImage(imageData);
                                System.Drawing.Image resizedImage = ResizeImage(image, 240, 200);
                                pictureBox6.Image = resizedImage;
                            }
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
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string recId = reader.GetString(0);
                            string recTitle = reader.GetString(1);
                            label17.Text = recTitle;
                            label16.Text = recId;
                            byte[] imageData = reader["REC_IMG"] as byte[];
                            if (imageData != null)
                            {
                                System.Drawing.Image image = ByteArrayToImage(imageData);
                                System.Drawing.Image resizedImage = ResizeImage(image, 240, 200);
                                pictureBox5.Image = resizedImage;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
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
                            string recId = reader.GetString(0);
                            string recTitle = reader.GetString(1);
                            label15.Text = recTitle;
                            label14.Text = recId;
                            byte[] imageData = reader["REC_IMG"] as byte[];
                            if (imageData != null)
                            {
                                System.Drawing.Image image = ByteArrayToImage(imageData);
                                System.Drawing.Image resizedImage = ResizeImage(image, 240, 200);
                                pictureBox4.Image = resizedImage;
                            }
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
        public void AddPhotoToSpecificPictureBox()
        {
            try
            {
                //string imagePath = @"C:\Users\ASUS\Pictures\hd-assassin-s-creed-gaming-cover-h3zgkk83v6fimy4j.jpg";
                //System.Drawing.Image image = System.Drawing.Image.FromFile(imagePath);
                int newWidth = 200;
                int newHeight = 200;
                pictureBox3.Size = new Size(newWidth, newHeight);
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(0, 0, pictureBox3.Width, pictureBox3.Height);
                pictureBox3.Region = new Region(path);
                //pictureBox3.Image = image;
                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}");
            }
        }


        private void User_Load(object sender, EventArgs e)
        {
            string s = Class1.X();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (LogInHelper.UniversalLogIn)
            {
                Edit_Profile edit_Profile = new Edit_Profile();
                edit_Profile.Show();
            }
        }


        private void button19_Click(object sender, EventArgs e)
        {
            LogInHelper.UniversalLogIn = false;
            LogInHelper.UniversalUserLogIn = false;
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Recipe.RecipeID = label12.Text;
            Recipe recipe = new Recipe();
            recipe.Show();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {
            Recipe.RecipeID = label18.Text;
            Recipe recipe = new Recipe();
            recipe.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Recipe.RecipeID = label16.Text;
            Recipe recipe = new Recipe();
            recipe.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Recipe.RecipeID = label14.Text;
            Recipe recipe = new Recipe();
            recipe.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Recipe.RecipeID = ReviewDataView.recipeID1;
            Recipe recipe = new Recipe();
            recipe.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Recipe.RecipeID = ReviewDataView.recipeID2;
            Recipe recipe = new Recipe();
            recipe.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Recipe.RecipeID = ReviewDataView.recipeID3;
            Recipe recipe = new Recipe();
            recipe.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Recipe.RecipeID = ReviewDataView.recipeID1;
            Recipe recipe = new Recipe();
            recipe.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Recipe.RecipeID = ReviewDataView.recipeID2;
            Recipe recipe = new Recipe();
            recipe.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Recipe.RecipeID = ReviewDataView.recipeID3;
            Recipe recipe = new Recipe();
            recipe.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Recipe.RecipeID = SaveRecipeData_View.recipeName1;
            Recipe recipe = new Recipe();
            recipe.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Recipe.RecipeID = SaveRecipeData_View.recipeName2;
            Recipe recipe = new Recipe();
            recipe.Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Recipe.RecipeID = SaveRecipeData_View.recipeName3;
            Recipe recipe = new Recipe();
            recipe.Show();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            DeleteAccount deleteAccount = new DeleteAccount();
            deleteAccount.Show();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home_Page home_Page = new Home_Page();
            home_Page.Show();
            this.Close();
        }
    }
}
