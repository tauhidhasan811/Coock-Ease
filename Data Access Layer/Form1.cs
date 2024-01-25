namespace Data_Access_Layer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AverageStart.CalculateAverageRating("22464381");
            label1.Text = AverageStart.avgStar;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
