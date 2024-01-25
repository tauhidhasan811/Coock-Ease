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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.VisualBasic.ApplicationServices;

namespace Presentation_Layer
{
    public partial class Edit_Profile : Form
    {
        public static string connectionString = "Data Source=DESKTOP-6K06NP6\\SQLEXPRESS;Initial Catalog=Coock_Ease;Integrated Security=True;MultipleActiveResultSets=true;";

        public Edit_Profile()
        {
            InitializeComponent();
            textBox1.Text = User_Profile_View.FullName;
            textBox2.Text = User_Profile_View.Password;
            textBox3.Text = User_Profile_View.Mail;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query4 = "SELECT UR_PP FROM CE_USER WHERE UR_ID = @User_ID ";
                string query5 = "SELECT UR_COV_PP FROM CE_USER WHERE UR_ID = @User_ID ";
                using (SqlCommand command4 = new SqlCommand(query4, connection))
                {
                    command4.Parameters.AddWithValue("@User_ID", LogInHelper.UniversalUserId);
                    using (SqlDataReader reader4 = command4.ExecuteReader())
                    {
                        if (reader4.Read())
                        {
                            byte[] imageData = reader4["UR_PP"] != DBNull.Value ? (byte[])reader4["UR_PP"] : null;


                            // Convert byte array to Image
                            if (imageData != null && imageData.Length > 0)
                            {
                                using (MemoryStream ms = new MemoryStream(imageData))
                                {
                                    pictureBox3.Image = System.Drawing.Image.FromStream(ms);
                                }
                            }
                            else
                            {
                                //MessageBox.Show("Image data is empty or null.");
                            }

                        }
                    }
                }
                using (SqlCommand command5 = new SqlCommand(query5, connection))
                {
                    command5.Parameters.AddWithValue("@User_ID", LogInHelper.UniversalUserId);
                    using (SqlDataReader reader5 = command5.ExecuteReader())
                    {
                        if (reader5.Read())
                        {
                            byte[] imageData = reader5["UR_COV_PP"] != DBNull.Value ? (byte[])reader5["UR_COV_PP"] : null;


                            // Convert byte array to Image
                            if (imageData != null && imageData.Length > 0)
                            {
                                using (MemoryStream ms = new MemoryStream(imageData))
                                {
                                    pictureBox2.Image = System.Drawing.Image.FromStream(ms);
                                }
                            }
                            else
                            {
                                //MessageBox.Show("Image data is empty or null.");
                            }

                        }
                    }
                }
            }
        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg; *.png; *.gif; *.bmp)|*.jpg; *.png; *.gif; *.bmp|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = Image.FromFile(openFileDialog.FileName);
            }
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg; *.png; *.gif; *.bmp)|*.jpg; *.png; *.gif; *.bmp|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox3.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user_name = textBox1.Text;
            string user_mail = textBox3.Text;
            string user_passsword = textBox2.Text;
            string user_id = LogInHelper.UniversalUserId;
            byte[] imageData1 = ImageToByteArray(pictureBox3.Image);
            byte[] imageData2 = ImageToByteArray(pictureBox2.Image);
            byte[] ImageToByteArray(Image image)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, image.RawFormat);
                    return ms.ToArray();
                }
            }
            // SQL INSERT statement with parameters
            string updateQuery = "UPDATE [dbo].[CE_USER] " +
                     "SET [UR_NAME] = @us_name, " +
                     "[UR_MAIL] = @ur_mail, " +
                     "[UR_PASS] = @ur_pass, " +
                     "[UR_PP] = @ur_pp, " +
                     "[UR_COV_PP] = @ur_cov " +
                     "WHERE [UR_ID] = @ur_id";
            // Execute the query
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        // Add parameters to the SqlCommand
                        command.Parameters.AddWithValue("@us_name", user_name);
                        command.Parameters.AddWithValue("@ur_mail", user_mail);
                        command.Parameters.AddWithValue("@ur_pass", user_passsword);
                        command.Parameters.AddWithValue("@ur_pp", imageData1);
                        command.Parameters.AddWithValue("@ur_cov", imageData2);
                        command.Parameters.AddWithValue("@ur_id", user_id);
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Data Updated successfully!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            User user=new User();
            user.Show();
            this.Close();
        }

        private void Edit_Profile_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
