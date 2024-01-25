using System;
using System.Data;
using System.Media;
using System.Timers;
using System.Windows.Forms;
using Data_Access_Layer;

namespace COOCK_EASE_PROJECT_FINAL
{
    public partial class Coocking_Step : Form
    {
        private int currentStep = 1;
        private bool isRunning = false;

        private SoundPlayer soundPlayer;
        private System.Timers.Timer timer;

        public Coocking_Step()
        {
            InitializeComponent();
            Coocking_Step_DataView.Coocking_Step_Data_View(Recipe.RecipeID);
            label6.Text = Coocking_Step_DataView.stepDetails;
            InitializeTimer();
            InitializeSoundPlayer();
        }
        private int[] stepDurations = Coocking_Step_DataView.stepTime;

        private void InitializeTimer()
        {
            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Tick;
        }

        private void InitializeSoundPlayer()
        {
            soundPlayer = new SoundPlayer(@"C:\Users\ASUS\Downloads\Alarm_Clock_Ringing____Free_Sound_Effect_Ringtones_128k_.wav");
        }

        private void Timer_Tick(object sender, ElapsedEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => Timer_Tick(sender, e)));
                return;
            }

            label2.Text = $"Now you are in Step: {currentStep}";

            if (isRunning && currentStep > 0 && currentStep <= stepDurations.Length)
            {
                int targetTime = stepDurations[currentStep - 1];

                if (targetTime > 0)
                {
                    targetTime--;

                    label1.Text = $"You have remain {targetTime} second";

                    stepDurations[currentStep - 1] = targetTime;

                    if (targetTime == 0)
                    {
                        isRunning = false;
                        soundPlayer.Play();

                        label1.Text = $"Step {currentStep} completed!";
                        button3.Enabled = true;
                        button2.PerformClick(); 
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            soundPlayer.Stop();
            button1.Enabled = true;
            timer.Stop();
            button3.Text = "Music stopped.";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            isRunning = true;
            button3.Enabled = false;

            if (currentStep > 0 && currentStep <= stepDurations.Length)
            {
                label1.Text = $"You have remain {stepDurations[currentStep - 1]} second";
                timer.Start();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (currentStep < stepDurations.Length)
            {
                currentStep++;

                if (currentStep > 0 && currentStep <= stepDurations.Length)
                {
                    button1.Enabled = true;
                    label1.Text = "You have remain 0 second";
                    stepDurations[currentStep - 1] = stepDurations[currentStep - 1];
                    timer.Start();
                }
                else
                {
                    currentStep = stepDurations.Length;
                    label1.Text = "All steps completed!";
                    button1.Enabled = false;
                    button3.Enabled = false;
                }
            }
        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void Coocking_Step_Load(object sender, EventArgs e)
        {

        }
    }
}
