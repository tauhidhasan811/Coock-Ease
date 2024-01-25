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
using Data_Access_Layer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace COOCK_EASE_PROJECT_FINAL
{
    public partial class Sponser : Form
    {
        public static string connectionString = "Data Source=DESKTOP-6K06NP6\\SQLEXPRESS;Initial Catalog=Coock_Ease;Integrated Security=True;MultipleActiveResultSets=true;";

        public Sponser()
        {
            InitializeComponent();
            label1.Text = SponsorDataView.FullName;
            label2.Text = LogInSpornsorHelper.UniversalSponsorId;
            DateTime dateTime = SponsorDataView.joinData;
            DateTime dateTime1 = SponsorDataView.MesmebshipStart;
            DateTime dateTime3 = SponsorDataView.MesmebshipFnished;
            label4.Text = dateTime.ToString("dd-MM-yyyy");
            label6.Text = dateTime1.ToString("dd-MM-yyyyy");
            label7.Text = dateTime3.ToString("dd-MM-yyyy");
            string query = "SELECT [ADS_DESC], [ADS_PP] FROM[CE_ADS] WHERE [SR_ID]=@shafeid ORDER BY [ADS_ID] OFFSET 0 ROW FETCH NEXT 1 ROW ONLY";
            string query1 = "SELECT [ADS_DESC], [ADS_PP] FROM[CE_ADS] WHERE [SR_ID]=@shafeid ORDER BY [ADS_ID] OFFSET 1 ROW FETCH NEXT 1 ROW ONLY";
            string query2 = "SELECT [ADS_DESC], [ADS_PP] FROM[CE_ADS] WHERE [SR_ID]=@shafeid ORDER BY [ADS_ID] OFFSET 2 ROW FETCH NEXT 1 ROW ONLY";
            string query3 = "SELECT [ADS_DESC], [ADS_PP] FROM[CE_ADS] WHERE [SR_ID]=@shafeid ORDER BY [ADS_ID] OFFSET 3 ROW FETCH NEXT 1 ROW ONLY";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@shafeid", LogInSpornsorHelper.UniversalSponsorId);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string recId = reader.GetString(0);
                            label10.Text = recId;
                            byte[] imageData = reader["ADS_PP"] as byte[];
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
            using (SqlCommand command = new SqlCommand(query1, connection))
            {
                command.Parameters.AddWithValue("@shafeid", LogInSpornsorHelper.UniversalSponsorId);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string recId = reader.GetString(0);
                            label12.Text = recId;
                            byte[] imageData = reader["ADS_PP"] as byte[];
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
            using (SqlCommand command = new SqlCommand(query2, connection))
            {
                command.Parameters.AddWithValue("@shafeid", LogInSpornsorHelper.UniversalSponsorId);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string recId = reader.GetString(0);
                            label13.Text = recId;
                            byte[] imageData = reader["ADS_PP"] as byte[];
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
            using (SqlCommand command = new SqlCommand(query3, connection))
            {
                command.Parameters.AddWithValue("@shafeid", LogInSpornsorHelper.UniversalSponsorId);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string recId = reader.GetString(0);
                            label16.Text = recId;
                            byte[] imageData = reader["ADS_PP"] as byte[];
                            if (imageData != null)
                            {
                                System.Drawing.Image image = ByteArrayToImage(imageData);
                                System.Drawing.Image resizedImage = ResizeImage(image, 240, 200);
                                pictureBox7.Image = resizedImage;
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

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg; *.png; *.gif; *.bmp)|*.jpg; *.png; *.gif; *.bmp|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string ads_desc = textBox1.Text;
            byte[] imageData = ImageToByteArray(pictureBox1.Image);
            //byte[] newPhotoData = ImageToByteArray(pictureBox1.Image);
            byte[] ImageToByteArray(Image image)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, image.RawFormat);
                    return ms.ToArray();
                }
            }

            // SQL INSERT statement with parameters
            // SQL INSERT statement with parameters
            string insertQuery = "INSERT INTO [dbo].[CE_ADS] " +
                                 "( [ADS_DESC], [ADS_PP], [SR_ID]) " +
                                 "VALUES ( @ADS_DESC, @ADS_PP, @SR_ID)";

            // Execute the query
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        // Add parameters to the SqlCommand
                        command.Parameters.AddWithValue("@ADS_DESC", textBox1.Text);
                        command.Parameters.AddWithValue("@ADS_PP", imageData);
                        command.Parameters.AddWithValue("@SR_ID", LogInSpornsorHelper.UniversalSponsorId);

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateMemberShip updateMemberShip = new UpdateMemberShip();
            updateMemberShip.Show();
        }

        private void Sponser_Load(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {
            this.Close();
            LogInSpornsorHelper.UniversalSponsorLogIn = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Home_Page home_Page = new Home_Page();
            home_Page.Show();
        }
    }
}
