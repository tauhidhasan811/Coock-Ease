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
    public partial class Upload_Recipe : Form
    {
        public Upload_Recipe()
        {
            InitializeComponent();
        }
        public static string connectionString = "Data Source=DESKTOP-6K06NP6\\SQLEXPRESS;Initial Catalog=Coock_Ease;Integrated Security=True;MultipleActiveResultSets=true;";
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg; *.png; *.gif; *.bmp)|*.jpg; *.png; *.gif; *.bmp|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string rec_id = textBox21.Text;
            string rec_title = textBox1.Text;
            string rec_desc = textBox2.Text;
            string rec_component = textBox3.Text;
            byte[] imageData = ImageToByteArray(pictureBox1.Image);
            byte[] newPhotoData = ImageToByteArray(pictureBox1.Image);
            byte[] ImageToByteArray(Image image)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, image.RawFormat);
                    return ms.ToArray();
                }
            }

            // SQL INSERT statement with parameters
            string insertQuery = "INSERT INTO [dbo].[CE_RECIPE] " +
                                 "([REC_ID], [REC_TITLE], [REC_DESC], [REC_IMG], [REC_COMPONENT], [REC_DATE],[CF_ID]) " +
                                 "VALUES (@rEC_ID, @rEC_TITLE, @rEC_DESC, @rEC_IMG, @rEC_COMPONENT, @rEC_DATE, @Cf_Id)";

            // Execute the query
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        // Add parameters to the SqlCommand
                        command.Parameters.AddWithValue("@rEC_ID", rec_id);
                        command.Parameters.AddWithValue("@rEC_TITLE", rec_title);
                        command.Parameters.AddWithValue("@rEC_DESC", rec_desc);
                        command.Parameters.AddWithValue("@rEC_IMG", imageData);
                        command.Parameters.AddWithValue("@rEC_COMPONENT", rec_component);
                        command.Parameters.AddWithValue("@rEC_DATE", DateTime.Now);
                        command.Parameters.AddWithValue("@Cf_Id", LogInShafe.UniversalShafeId);

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
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Coocking_Steps.Data_Insert(Convert.ToInt32(textBox4.Text), textBox5.Text, Convert.ToInt32(textBox6.Text), textBox8.Text, Convert.ToInt32(textBox7.Text), textBox10.Text, Convert.ToInt32(textBox9.Text), textBox12.Text, Convert.ToInt32(textBox11.Text), textBox20.Text, Convert.ToInt32(textBox19.Text), textBox18.Text, Convert.ToInt32(textBox17.Text), textBox16.Text, Convert.ToInt32(textBox15.Text), textBox21.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Upload_Recipe_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
