using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeneticAlgorithmTimetablingSystem.Algorithm;
using System.Threading;

namespace GeneticAlgorithmTimetablingSystem
{
    public partial class Optimization : Form
    {
        public static Algorithm.Algorithm GA;
        public static ThreadState state = new ThreadState();
        public Optimization()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

        }

        private void Optimization_Load(object sender, EventArgs e)
        {
            Configuration.GetInstance.ParseFile();
            btnStop.Enabled = false;
            //check if got rooms or not
            if (Configuration.GetInstance.GetNumberOfRooms() > 0)
            {
                Schedule prototype = new Schedule(5, 5, 90, 10);
                GA = new Algorithm.Algorithm(1000, 180, 50, prototype);
                state = ThreadState.Unstarted;
                timerWorkingSet.Start();
            }
            else
            {
                MessageBox.Show("Number of rooms is less than the limit!", "Number of Rooms Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                timerWorkingSet.Stop();
                GA = null;
                Dispose();
                return;
            }

        }
        int StartedTick = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblGeneration.Text = "Generation: " + Algorithm.Algorithm.GetInstance().GetCurrentGeneration().ToString();


            if (state == ThreadState.Running || state == ThreadState.WaitSleepJoin || state == ThreadState.Suspended)
            {
                lblFitness.Text = "Fitness:" + Algorithm.Algorithm.GetInstance().GetFitness().ToString();
                int timeLenght = (Environment.TickCount - StartedTick) / 1000; // Convert to Second

                string S = (timeLenght % 60).ToString();
                string M = ((timeLenght / 60) % 60).ToString();
                string H = (timeLenght / 3600).ToString();
                S = (S.Length > 1) ? S : S.Insert(0, "0");
                M = (M.Length > 1) ? M : M.Insert(0, "0");
                H = (H.Length > 1) ? H : H.Insert(0, "0");
                this.Text = string.Format("GAForm             Working Time ({0}:{1}:{2})", H, M, S);
            }


            if (Algorithm.Algorithm._state == AlgorithmState.AS_CRITERIA_STOPPED)
            {
                btnStop_Click(sender, e);
                Algorithm.Algorithm._state = AlgorithmState.AS_USER_STOPPED;
                MessageBox.Show("This Program could successfully solve the problem.", "Finishing the GA",
                    MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            btnStart.Text = "&Start";
            btnStop.Enabled = false;
            btnStart.Enabled = true;
            if (state == ThreadState.Running)
            {
                state = ThreadState.Stopped;
                Algorithm.Algorithm.GetInstance().Stop();
                StartedTick = 0;
            }
            this.Cursor = Cursors.Default;
        }
    }
}
