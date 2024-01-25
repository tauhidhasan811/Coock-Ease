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
    public partial class Edit_Shafe_Account : Form
    {
        public static string connectionString = "Data Source=DESKTOP-6K06NP6\\SQLEXPRESS;Initial Catalog=Coock_Ease;Integrated Security=True;MultipleActiveResultSets=true;";

        public Edit_Shafe_Account()
        {
            InitializeComponent();
            textBox1.Text = Shafe_Data_View.FullName;
            textBox2.Text = Shafe_Data_View.Password;
            textBox3.Text = Shafe_Data_View.Mail;
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
                    command5.Parameters.AddWithValue("@User_ID", LogInShafe.UniversalShafeId);
                    using (SqlDataReader reader5 = command5.ExecuteReader())
                    {
                        if (reader5.Read())
                        {
                            byte[] imageData = reader5["CF_COV_PP"] != DBNull.Value ? (byte[])reader5["CF_COV_PP"] : null;


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

        private void Edit_Shafe_Account_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg; *.png; *.gif; *.bmp)|*.jpg; *.png; *.gif; *.bmp|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox3.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg; *.png; *.gif; *.bmp)|*.jpg; *.png; *.gif; *.bmp|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user_name = textBox1.Text;
            string user_mail = textBox2.Text;
            string user_passsword = textBox3.Text;
            string user_id = LogInShafe.UniversalShafeId;
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
            string updateQuery = "UPDATE [dbo].[CE_SHAFE] " +
                     "SET [CF_NAME] = @us_name, " +
                     "[CF_MAIL] = @ur_mail, " +
                     "[CF_PASS] = @ur_pass, " +
                     "[CF_PP] = @ur_pp, " +
                     "[CF_COV_PP] = @ur_cov " +
                     "WHERE [CF_ID] = @ur_id";
            // Execute the query
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        // Add parameters to the SqlCommand
                        command.Parameters.AddWithValue("@us_name", user_name);
                        command.Parameters.AddWithValue("@ur_mail", user_passsword);
                        command.Parameters.AddWithValue("@ur_pass", user_mail);
                        command.Parameters.AddWithValue("@ur_pp", imageData1);
                        command.Parameters.AddWithValue("@ur_cov", imageData2);
                        command.Parameters.AddWithValue("@ur_id", user_id);
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
            this.Close();
            Shafe shafe = new Shafe();
            shafe.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
