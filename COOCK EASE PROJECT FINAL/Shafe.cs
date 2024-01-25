using Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data_Access_Layer;

namespace COOCK_EASE_PROJECT_FINAL
{
    public partial class Shafe : Form
    {
        public static string connectionString = "Data Source=DESKTOP-6K06NP6\\SQLEXPRESS;Initial Catalog=Coock_Ease;Integrated Security=True;MultipleActiveResultSets=true;";

        public Shafe()
        {
            InitializeComponent();

            AddPhotoToSpecificPictureBox();
            Shafe_Data_View.dataView();
            label1.Text = Shafe_Data_View.FullName;
            label2.Text = Shafe_Data_View.UserId;
            string date = Shafe_Data_View.dateTime.ToString("dd-MM-yyyy");
            label4.Text = date;
            label7.Text = Shafe_Data_View.ReferId;
            Data_Access_Layer.AverageStart.CalculateAverageRating(LogInShafe.UniversalShafeId);
            label8.Text = AverageStart.avgStar;
            int referCount = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query35 = "SELECT COUNT(*) FROM CE_REFER WHERE SF_ID = @urId";

                    using (SqlCommand command = new SqlCommand(query35, connection))
                    {
                        command.Parameters.AddWithValue("@urId", LogInShafe.UniversalShafeId);

                        referCount = (int)command.ExecuteScalar();

                        //MessageBox.Show(Convert.ToString(referCount * 50));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            float AvgREVIEW = 0;
            /*try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query35 = "SELECT AVG(CONVERT(FLOAT, RV_STAR)) FROM CE_REVIEW WHERE SF_ID = @urId";


                    using (SqlCommand command = new SqlCommand(query35, connection))
                    {
                        command.Parameters.AddWithValue("@urId", LogInShafe.UniversalShafeId);

                        AvgREVIEW = (float)command.ExecuteScalar();

                        //MessageBox.Show(Convert.ToString(referCount * 50));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }*/
            label36.Text = (referCount * 50).ToString();
            //label11.Text = (AvgREVIEW).ToString();
            /*-----------------Your POST -------------------------*/
            string query = "SELECT[REC_ID], [REC_TITLE], [REC_IMG] FROM[CE_RECIPE] WHERE [REC_ACTIVE_STATUS] = 'Active'AND [CF_ID]=@shafeid ORDER BY[REC_DATE] OFFSET 0 ROW FETCH NEXT 1 ROW ONLY";
            string query1 = "SELECT[REC_ID], [REC_TITLE], [REC_IMG] FROM[CE_RECIPE] WHERE [REC_ACTIVE_STATUS] = 'Active' AND [CF_ID]=@shafeid ORDER BY[REC_DATE] OFFSET 1 ROW FETCH NEXT 1 ROW ONLY";
            string query2 = "SELECT[REC_ID], [REC_TITLE], [REC_IMG] FROM[CE_RECIPE] WHERE [REC_ACTIVE_STATUS] = 'Active' AND [CF_ID]=@shafeid ORDER BY[REC_DATE] OFFSET 2 ROW FETCH NEXT 1 ROW ONLY";
            string query3 = "SELECT[REC_ID], [REC_TITLE], [REC_IMG] FROM[CE_RECIPE] WHERE [REC_ACTIVE_STATUS] = 'Active' AND [CF_ID]=@shafeid ORDER BY[REC_DATE] OFFSET 3 ROW FETCH NEXT 1 ROW ONLY";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@shafeid", LogInShafe.UniversalShafeId);
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
                command.Parameters.AddWithValue("@shafeid", LogInShafe.UniversalShafeId);
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
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query2, connection))
            {
                command.Parameters.AddWithValue("@shafeid", LogInShafe.UniversalShafeId);
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
                command.Parameters.AddWithValue("@shafeid", LogInShafe.UniversalShafeId);
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
                int newWidth = 200;
                int newHeight = 200;
                pictureBox3.Size = new Size(newWidth, newHeight);
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(0, 0, pictureBox3.Width, pictureBox3.Height);
                pictureBox3.Region = new Region(path);
                // pictureBox3.Image = image;
                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}");
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query4 = "SELECT CF_PP FROM CE_SHAFE WHERE CF_ID = @User_ID ";
                string query5 = "SELECT CF_COV_PP FROM CE_SHAFE WHERE CF_ID = @User_ID ";
                using (SqlCommand command4 = new SqlCommand(query4, connection))
                {
                    command4.Parameters.AddWithValue("@User_ID", LogInShafe.UniversalShafeId);
                    using (SqlDataReader reader4 = command4.ExecuteReader())
                    {
                        if (reader4.Read())
                        {
                            byte[] imageData = reader4["CF_PP"] != DBNull.Value ? (byte[])reader4["CF_PP"] : null;
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
                using (SqlCommand command5 = new SqlCommand(query5, connection))
                {
                    command5.Parameters.AddWithValue("@User_ID", LogInShafe.UniversalShafeId);
                    using (SqlDataReader reader5 = command5.ExecuteReader())
                    {
                        if (reader5.Read())
                        {
                            byte[] imageData = reader5["CF_COV_PP"] != DBNull.Value ? (byte[])reader5["CF_COV_PP"] : null;
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
            }

        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            Upload_Recipe upload_Recipe = new Upload_Recipe();
            upload_Recipe.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Edit_Shafe_Account edit_Shafe_Account = new Edit_Shafe_Account();
            edit_Shafe_Account.Show();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            RecipeShafe.RecipeID = label12.Text;
            RecipeShafe recipeShafe = new RecipeShafe();
            recipeShafe.Show();

        }

        private void button19_Click(object sender, EventArgs e)
        {
            LogInShafe.UniversalShafeLogIn = false;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home_Page home_Page = new Home_Page();
            home_Page.Show();
            this.Close();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            RecipeRecover recipeRecover = new RecipeRecover();
            recipeRecover.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RecipeShafe.RecipeID = label14.Text;
            RecipeShafe recipeShafe = new RecipeShafe();
            recipeShafe.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            RecipeShafe.RecipeID = label16.Text;
            RecipeShafe recipeShafe = new RecipeShafe();
            recipeShafe.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RecipeShafe.RecipeID = label18.Text;
            RecipeShafe recipeShafe = new RecipeShafe();
            recipeShafe.Show();
        }
        private void button18_Click(object sender, EventArgs e)
        {
            DeleteAccount deleteAccount = new DeleteAccount();
            deleteAccount.Show();
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
