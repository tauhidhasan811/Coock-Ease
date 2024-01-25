using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presentation_Layer;
using Data_Access_Layer;
using System.Data.SqlClient;
namespace COOCK_EASE_PROJECT_FINAL
{
    public partial class Home_Page : Form
    {
        public static string connectionString = "Data Source=DESKTOP-6K06NP6\\SQLEXPRESS;Initial Catalog=Coock_Ease;Integrated Security=True;MultipleActiveResultSets=true;";
        public static string searchID;
        public static string Label1;
        public static string Label2;
        public static string WebView;
        public Home_Page()
        {
            InitializeComponent();
            string sqlquery = @" SELECT REC_TITLE, REC_ID, REC_IMG FROM CE_RECIPE WHERE REC_ID IN ( SELECT REC_ID FROM CE_REVIEW GROUP BY REC_ID HAVING AVG(CONVERT(FLOAT, RV_STAR)) > ( SELECT AVG(CONVERT(FLOAT, RV_STAR)) FROM CE_REVIEW )) AND REC_ACTIVE_STATUS = 'Active'ORDER BY REC_ID
                                OFFSET 0 ROWS FETCH NEXT 1 ROW ONLY; ";
            string sqlquery1 = @" SELECT REC_TITLE, REC_ID, REC_IMG FROM CE_RECIPE WHERE REC_ID IN ( SELECT REC_ID FROM CE_REVIEW GROUP BY REC_ID HAVING AVG(CONVERT(FLOAT, RV_STAR)) > ( SELECT AVG(CONVERT(FLOAT, RV_STAR)) FROM CE_REVIEW )) AND REC_ACTIVE_STATUS = 'Active'ORDER BY REC_ID
                                OFFSET 1 ROWS FETCH NEXT 1 ROW ONLY; ";
            string sqlquery2 = @" SELECT REC_TITLE, REC_ID, REC_IMG FROM CE_RECIPE WHERE REC_ID IN ( SELECT REC_ID FROM CE_REVIEW GROUP BY REC_ID HAVING AVG(CONVERT(FLOAT, RV_STAR)) > ( SELECT AVG(CONVERT(FLOAT, RV_STAR)) FROM CE_REVIEW )) AND REC_ACTIVE_STATUS = 'Active'ORDER BY REC_ID
                                OFFSET 2 ROWS FETCH NEXT 1 ROW ONLY; ";
            string sqlquery3 = @" SELECT REC_TITLE, REC_ID, REC_IMG FROM CE_RECIPE WHERE REC_ID IN ( SELECT REC_ID FROM CE_REVIEW GROUP BY REC_ID HAVING AVG(CONVERT(FLOAT, RV_STAR)) > ( SELECT AVG(CONVERT(FLOAT, RV_STAR)) FROM CE_REVIEW )) AND REC_ACTIVE_STATUS = 'Active'ORDER BY REC_ID
                                OFFSET 3 ROWS FETCH NEXT 1 ROW ONLY; ";
            string query = "SELECT [REC_IMG], [REC_TITLE], [REC_ID] FROM [dbo].[CE_RECIPE] WHERE [REC_ACTIVE_STATUS] = 'Active' ORDER BY [REC_DATE] DESC OFFSET 0 ROW FETCH NEXT 1 ROW ONLY ";
            string query1 = "SELECT [REC_IMG], [REC_TITLE], [REC_ID] FROM [dbo].[CE_RECIPE] WHERE [REC_ACTIVE_STATUS] = 'Active' ORDER BY [REC_DATE] DESC OFFSET 1 ROW FETCH NEXT 1 ROW ONLY ";
            string query2 = "SELECT [REC_IMG], [REC_TITLE], [REC_ID] FROM [dbo].[CE_RECIPE] WHERE [REC_ACTIVE_STATUS] = 'Active' ORDER BY [REC_DATE] DESC OFFSET 2 ROW FETCH NEXT 1 ROW ONLY ";
            string query3 = "SELECT [REC_IMG], [REC_TITLE], [REC_ID] FROM [dbo].[CE_RECIPE] WHERE [REC_ACTIVE_STATUS] = 'Active' ORDER BY [REC_DATE] DESC OFFSET 3 ROW FETCH NEXT 1 ROW ONLY ";
            string queryADs = "SELECT [ADS_PP], [ADS_DESC] FROM [dbo].[CE_ADS] ORDER BY [ADS_ID] DESC OFFSET 0 ROW FETCH NEXT 1 ROW ONLY ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(queryADs, connection))
            {
                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            WebView = reader.GetString(1);
                            button8.Image = GetImageFromByteArray(reader["ADS_PP"] as byte[]);
                        }
                        else
                        {
                            //MessageBox.Show("Recipe not found.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Error: " + ex.Message);
                }
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sqlquery, connection))
            {
                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            pictureBox13.Image = GetImageFromByteArray(reader["REC_IMG"] as byte[]);
                            label28.Text = reader["REC_TITLE"].ToString();
                            label27.Text = reader["REC_ID"].ToString();
                        }
                        else
                        {
                            //MessageBox.Show("Recipe not found.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Error: " + ex.Message);
                }
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sqlquery1, connection))
            {
                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            pictureBox12.Image = GetImageFromByteArray(reader["REC_IMG"] as byte[]);
                            label26.Text = reader["REC_TITLE"].ToString();
                            label25.Text = reader["REC_ID"].ToString();
                        }
                        else
                        {
                            //MessageBox.Show("Recipe not found.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Error: " + ex.Message);
                }
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sqlquery2, connection))
            {
                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            pictureBox3.Image = GetImageFromByteArray(reader["REC_IMG"] as byte[]);
                            label24.Text = reader["REC_TITLE"].ToString();
                            label23.Text = reader["REC_ID"].ToString();
                        }
                        else
                        {
                            //MessageBox.Show("Recipe not found.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Error: " + ex.Message);
                }
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sqlquery3, connection))
            {
                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            pictureBox2.Image = GetImageFromByteArray(reader["REC_IMG"] as byte[]);
                            label22.Text = reader["REC_TITLE"].ToString();
                            label21.Text = reader["REC_ID"].ToString();
                        }
                        else
                        {
                            //MessageBox.Show("Recipe not found.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Error: " + ex.Message);
                }
            }
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
                            pictureBox8.Image = GetImageFromByteArray(reader["REC_IMG"] as byte[]);
                            label10.Text = reader["REC_TITLE"].ToString();
                            label9.Text = reader["REC_ID"].ToString();
                        }
                        else
                        {
                            //MessageBox.Show("Recipe not found.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Error: " + ex.Message);
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
                            pictureBox7.Image = GetImageFromByteArray(reader["REC_IMG"] as byte[]);
                            label8.Text = reader["REC_TITLE"].ToString();
                            label7.Text = reader["REC_ID"].ToString();
                        }
                        else
                        {
                            //MessageBox.Show("Recipe not found.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Error: " + ex.Message);
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
                            pictureBox6.Image = GetImageFromByteArray(reader["REC_IMG"] as byte[]);
                            label6.Text = reader["REC_TITLE"].ToString();
                            label5.Text = reader["REC_ID"].ToString();
                        }
                        else
                        {
                            //MessageBox.Show("Recipe not found.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Error: " + ex.Message);
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
                            pictureBox5.Image = GetImageFromByteArray(reader["REC_IMG"] as byte[]);
                            label4.Text = reader["REC_TITLE"].ToString();
                            label3.Text = reader["REC_ID"].ToString();
                        }
                        else
                        {
                            //MessageBox.Show("Recipe not found.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private Image GetImageFromByteArray(byte[] byteArray)
        {
            if (byteArray == null)
                return null;

            using (var stream = new System.IO.MemoryStream(byteArray))
            {
                return Image.FromStream(stream);
            }
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            bool logIn = LogInHelper.UniversalUserLogIn;
            if (logIn || LogInShafe.UniversalShafeLogIn || LogInSpornsorHelper.UniversalSponsorLogIn)
            {
                if (LogInHelper.UniversalUserLogIn)
                {
                    User user = new User();
                    user.Show();
                }
                else if (LogInShafe.UniversalShafeLogIn)
                {
                    Shafe shafe = new Shafe();
                    shafe.Show();
                }
                else
                {
                    Sponser sponser = new Sponser();
                    sponser.Show();
                }
            }
            else
            {
                Select_LogIn_Option select_LogIn_Option = new Select_LogIn_Option();
                select_LogIn_Option.Show();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Recipe.RecipeID = label27.Text;
            RecipeShafe.RecipeID = label27.Text;
            Recipe_Demo.RecipeID = label27.Text;
            if (LogInHelper.UniversalUserLogIn || LogInShafe.UniversalShafeLogIn || LogInSpornsorHelper.UniversalSponsorLogIn)
            {
                if (LogInShafe.UniversalShafeLogIn)
                {
                    RecipeType.RecipeTypeData("beefcurry1");
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

        private void button19_Click(object sender, EventArgs e)
        {
            if (LogInShafe.UniversalShafeLogIn)
            {
                LogInShafe.UniversalShafeLogIn = false;
            }
            else if (LogInHelper.UniversalUserLogIn)
            {
                LogInHelper.UniversalUserLogIn = false;
                LogInHelper.UniversalLogIn = false;
            }
            else if (Data_Access_Layer.LogInSpornsorHelper.UniversalSponsorLogIn)
            {
                Data_Access_Layer.LogInSpornsorHelper.UniversalSponsorLogIn = false;
            }
            else
            {
                MessageBox.Show("Still Now Your Are Not LogIned.");
                Select_LogIn_Option select_LogIn_Option = new Select_LogIn_Option();
                select_LogIn_Option.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            searchID = textBox1.Text.Trim();
            Search search = new Search();
            search.Show();

        }
        private void button12_Click(object sender, EventArgs e)
        {
            Recipe.RecipeID = label25.Text;
            RecipeShafe.RecipeID = label25.Text;
            Recipe_Demo.RecipeID = label25.Text;
            if (LogInHelper.UniversalUserLogIn || LogInShafe.UniversalShafeLogIn || LogInSpornsorHelper.UniversalSponsorLogIn)
            {
                if (LogInShafe.UniversalShafeLogIn)
                {
                    RecipeType.RecipeTypeData(label25.Text);
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

        private void Home_Page_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Recipe.RecipeID = label7.Text;
            RecipeShafe.RecipeID = label7.Text;
            Recipe_Demo.RecipeID = label7.Text;
            if (LogInHelper.UniversalUserLogIn || LogInShafe.UniversalShafeLogIn || LogInSpornsorHelper.UniversalSponsorLogIn)
            {
                if (LogInShafe.UniversalShafeLogIn)
                {
                    RecipeType.RecipeTypeData(label7.Text);
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

        private void button4_Click(object sender, EventArgs e)
        {
            Recipe.RecipeID = label5.Text;
            RecipeShafe.RecipeID = label5.Text;
            Recipe_Demo.RecipeID = label5.Text;
            if (LogInHelper.UniversalUserLogIn || LogInShafe.UniversalShafeLogIn || LogInSpornsorHelper.UniversalSponsorLogIn)
            {
                if (LogInShafe.UniversalShafeLogIn)
                {
                    RecipeType.RecipeTypeData(label5.Text);
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

        private void button3_Click(object sender, EventArgs e)
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

        private void button6_Click(object sender, EventArgs e)
        {
            Recipe.RecipeID = label9.Text;
            RecipeShafe.RecipeID = label9.Text;
            Recipe_Demo.RecipeID = label9.Text;
            if (LogInHelper.UniversalUserLogIn || LogInShafe.UniversalShafeLogIn || LogInSpornsorHelper.UniversalSponsorLogIn)
            {
                if (LogInShafe.UniversalShafeLogIn)
                {
                    RecipeType.RecipeTypeData(label9.Text);
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            Recipe.RecipeID = label23.Text;
            RecipeShafe.RecipeID = label23.Text;
            Recipe_Demo.RecipeID = label23.Text;
            if (LogInHelper.UniversalUserLogIn || LogInShafe.UniversalShafeLogIn || LogInSpornsorHelper.UniversalSponsorLogIn)
            {
                if (LogInShafe.UniversalShafeLogIn)
                {
                    RecipeType.RecipeTypeData(label23.Text);
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

        private void button10_Click(object sender, EventArgs e)
        {
            Recipe.RecipeID = label21.Text;
            RecipeShafe.RecipeID = label21.Text;
            Recipe_Demo.RecipeID = label21.Text;
            if (LogInHelper.UniversalUserLogIn || LogInShafe.UniversalShafeLogIn || LogInSpornsorHelper.UniversalSponsorLogIn)
            {
                if (LogInShafe.UniversalShafeLogIn)
                {
                    RecipeType.RecipeTypeData(label21.Text);
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

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Home_Page home_Page = new Home_Page();
            home_Page.Show();
            //this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //ADS aDS = new ADS();
            //aDS.Show();
        }
    }
}
