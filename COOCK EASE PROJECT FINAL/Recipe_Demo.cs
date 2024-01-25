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
using Data_Access_Layer;

namespace COOCK_EASE_PROJECT_FINAL
{
    public partial class Recipe_Demo : Form
    {
        public static string RecipeID=" " ;
        public static string connectionString = "Data Source=DESKTOP-6K06NP6\\SQLEXPRESS;Initial Catalog=Coock_Ease;Integrated Security=True;MultipleActiveResultSets=true;";

        public Recipe_Demo()
        {
            InitializeComponent();
            Recipe_Data_View.dataView(RecipeID);
            label1.Text = Recipe_Data_View.title;
            label20.Text = RecipeID;
            label2.Text = Recipe_Data_View.description;
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

        private void button1_Click(object sender, EventArgs e)
        {
            Select_LogIn_Option select_login_option = new Select_LogIn_Option();
            select_login_option.Show();
            this.Close();
        }

        private void Recipe_Demo_Load(object sender, EventArgs e)
        {

        }
    }
}
