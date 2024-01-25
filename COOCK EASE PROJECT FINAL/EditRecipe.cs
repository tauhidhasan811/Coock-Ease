using Data_Access_Layer;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Data_Access_Layer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace COOCK_EASE_PROJECT_FINAL
{
    public partial class EditRecipe : Form
    {
        public static string RecipeID ;
        public static string connectionString = "Data Source=DESKTOP-6K06NP6\\SQLEXPRESS;Initial Catalog=Coock_Ease;Integrated Security=True;MultipleActiveResultSets=true;";

        public EditRecipe()
        {
            InitializeComponent();



            Recipe_Data_View.dataView(RecipeID);
            textBox1.Text = Recipe_Data_View.title;
            textBox2.Text = Recipe_Data_View.description;
            textBox3.Text = Recipe_Data_View.component;

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
                                    pictureBox1.Image = Image.FromStream(ms);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string rec_id = RecipeID;
            string rec_title = textBox1.Text;
            string rec_desc = textBox2.Text;
            string rec_component = textBox3.Text;
            byte[] imageData = ImageToByteArray(pictureBox1.Image);

            // SQL UPDATE statement with parameters
            string updateQuery = "UPDATE [dbo].[CE_RECIPE] " +
                                 "SET [REC_TITLE] = @rEC_TITLE, [REC_DESC] = @rEC_DESC, [REC_IMG] = @rEC_IMG, [REC_COMPONENT] = @rEC_COMPONENT " +
                                 "WHERE [REC_ID] = @rEC_ID";

            // Execute the query
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        // Add parameters to the SqlCommand
                        command.Parameters.AddWithValue("@rEC_ID", rec_id);
                        command.Parameters.AddWithValue("@rEC_TITLE", rec_title);
                        command.Parameters.AddWithValue("@rEC_DESC", rec_desc);
                        command.Parameters.AddWithValue("@rEC_IMG", imageData);
                        command.Parameters.AddWithValue("@rEC_COMPONENT", rec_component);

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

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg; *.png; *.gif; *.bmp)|*.jpg; *.png; *.gif; *.bmp|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Dispose of the existing image
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                }

                // Load the new image
                pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }

        private void EditRecipe_Load(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
