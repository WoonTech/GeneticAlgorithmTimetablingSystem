using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneticAlgorithmTimetablingSystem
{
    public partial class SettingsForm : Form
    {
        public static int settingsKey = 0;
        public static string SemesterKey;
        private int semesterMemory1 = 0;
        public SettingsForm()
        {
            InitializeComponent();
        }

        public void SettingsForm_Load(object sender, EventArgs e)
        {
            resetPB();
            panel1.Controls.Add(panelParameter);
            panelParameter.Location = new Point(244, 84);
            lblParameters.ForeColor = Color.FromArgb(163, 130, 55);
            pbParameters.Visible = true;
            cbSpring.Checked = true;
            lblDNA.Text = "DNA Numbers : " + AlgorithmForm.GA.DNASize;
            sliderDNA.Value = AlgorithmForm.GA.DNASize;
            lblReplace.Text = "Replace by Generation ： " + AlgorithmForm.GA.ReplaceByGeneration;
            sliderReplace.Value = AlgorithmForm.GA.ReplaceByGeneration;
            lblTrackBestDNA.Text = "Track Best DNA Number : " + AlgorithmForm.GA.TrackBest;
            sliderTrackBestDNA.Value = AlgorithmForm.GA.TrackBest;
            lblCrossover.Text = "Crossover Points : " + AlgorithmForm.GA.NumberOfCrossoverPoints;
            sliderCrossover.Value = AlgorithmForm.GA.NumberOfCrossoverPoints;
            lblCrossoverPB.Text = "Crossover Probability : " + AlgorithmForm.GA.CrossoverRate;
            sliderCrossoverPB.Value = AlgorithmForm.GA.CrossoverRate;
            lblMutation.Text = "Mutation Size : " + AlgorithmForm.GA.MutationSize;
            sliderMutation.Value = AlgorithmForm.GA.MutationSize;
            lblMutationPB.Text = "Mutation Probability : " + AlgorithmForm.GA.MutationRate;
            sliderMutationPB.Value = AlgorithmForm.GA.MutationRate;
            SpringAutumn();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (cbAutumn.Checked == false && cbSpring.Checked == false)
            {
                MessageBox.Show("You must select at least 1 semester", "Error",
    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                SpringAutumn();
            }
            else
            {
                Algorithm.Schedule prototype = new Algorithm.Schedule((int)sliderCrossover.Value, (int)sliderMutation.Value, (int)sliderCrossoverPB.Value, (int)sliderMutationPB.Value);
                AlgorithmForm.GA = new GeneticAlgorithmTimetablingSystem.Algorithm.Algorithm((int)sliderDNA.Value, (int)sliderReplace.Value, (int)sliderTrackBestDNA.Value, prototype);
                settingsKey = 1;
                if (cbAutumn.Checked == true)
                {
                    SemesterKey = "Autumn";
                    if (cbSpring.Checked == true)
                    {
                        SemesterKey = "Spring and Autumn";
                    }
                }

                if (cbSpring.Checked == true)
                {
                    SemesterKey = "Spring";
                    if (cbAutumn.Checked == true)
                    {
                        SemesterKey = "Spring and Autumn";
                    }
                }
                this.Close();
            }
           
        }

        private void label3_Click(object sender, EventArgs e)
        {
            resetPB();
            panel1.Controls.Add(panelParameter);
            panelParameter.Location = new Point(244, 84);
            lblParameters.ForeColor = Color.FromArgb(163, 130, 55);
            pbParameters.Visible = true;
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            resetPB();
            panel1.Controls.Add(panelSchedulePrototype);
            panelSchedulePrototype.Location = new Point(244, 84);
            lblPrototype.ForeColor = Color.FromArgb(163, 130, 55);
            pbPrototype.Visible = true;
        }

        private void sliderDNA_Scroll(object sender, ScrollEventArgs e)
        {
            lblDNA.Text = "DNA Numbers : " + sliderDNA.Value;
        }

        private void sliderReplace_Scroll(object sender, ScrollEventArgs e)
        {
            lblReplace.Text = "Replace by Generation ： " + sliderReplace.Value;
        }

        private void sliderTrackBestDNA_Scroll(object sender, ScrollEventArgs e)
        {
            lblTrackBestDNA.Text = "Track Best DNA Number : " + sliderTrackBestDNA.Value;
        }

        private void sliderCrossover_Scroll(object sender, ScrollEventArgs e)
        {
            lblCrossover.Text = "Crossover Points : " + sliderCrossover.Value;
        }

        private void sliderMutation_Scroll(object sender, ScrollEventArgs e)
        {
            lblMutation.Text = "Mutation Size : " + sliderMutation.Value;
        }

        private void sliderCrossoverPB_Scroll(object sender, ScrollEventArgs e)
        {
            lblCrossoverPB.Text = "Crossover Probability : " + sliderCrossoverPB.Value;
        }

        private void sliderMutationPB_Scroll(object sender, ScrollEventArgs e)
        {
            lblMutationPB.Text = "Mutation Probability : " + sliderMutationPB.Value;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            sliderDNA.Value = 1000;
            sliderReplace.Value = 180;
            sliderTrackBestDNA.Value = 50;
            sliderCrossover.Value = 5;
            sliderCrossoverPB.Value = 90;
            sliderMutation.Value = 5;
            sliderMutationPB.Value = 10;
            lblDNA.Text = "DNA Numbers : " + sliderDNA.Value;
            lblReplace.Text = "Replace by Generation ： " + sliderReplace.Value;
            lblTrackBestDNA.Text = "Track Best DNA Number : " + sliderTrackBestDNA.Value;
            lblCrossover.Text = "Crossover Points : " + sliderCrossover.Value;
            lblCrossoverPB.Text = "Crossover Probability : " + sliderCrossoverPB.Value;
            lblMutation.Text = "Mutation Size : " + sliderMutation.Value;
            lblMutationPB.Text = "Mutation Probability : " + sliderMutationPB.Value;
            Algorithm.Schedule prototype = new Algorithm.Schedule((int)sliderCrossover.Value, (int)sliderMutation.Value, (int)sliderCrossoverPB.Value, (int)sliderMutationPB.Value);
            AlgorithmForm.GA = new GeneticAlgorithmTimetablingSystem.Algorithm.Algorithm((int)sliderDNA.Value, (int)sliderReplace.Value, (int)sliderTrackBestDNA.Value, prototype);
            settingsKey = 0;
            SpringAutumn();
            this.Close();
        }

        private void lblPeriod_Click(object sender, EventArgs e)
        {
            resetPB();
            panel1.Controls.Add(pnPeriods);
            pnPeriods.Location = new Point(244, 84);
            lblPeriod.ForeColor = Color.FromArgb(163, 130, 55);
            pbPeriods.Visible = true;
        }

        private void resetPB()
        {
            lblPrototype.ForeColor = Color.FromArgb(207, 192, 142);
            lblParameters.ForeColor = Color.FromArgb(207, 192, 142);
            lblPeriod.ForeColor = Color.FromArgb(207, 192, 142);
            pbPrototype.Visible = false;
            pbParameters.Visible = false;
            pbPeriods.Visible = false;
            panel1.Controls.Remove(panelParameter);
            panel1.Controls.Remove(panelSchedulePrototype);
            panel1.Controls.Remove(pnPeriods);
        }

        private void cbSpring_Paint(object sender, PaintEventArgs e)
        {
            Point pt = new Point(17, 6);
            Rectangle rect = new Rectangle(pt, new Size(14, 14));
            Pen gold = new Pen(Color.FromArgb(207, 192, 142));
            Point pt2 = new Point(14, 3);
            Rectangle rect2 = new Rectangle(pt2, new Size(14, 14));
            if (cbSpring.Checked)
            {
                using (Font wing = new Font("Wingdings", 14f))
                    e.Graphics.DrawString("ü", wing, Brushes.Moccasin, rect2);
            }
            if (!cbSpring.Enabled)
            {
                cbSpring.ForeColor = Color.FromArgb(120, 120, 120);
            }
            else
            {
                cbSpring.ForeColor = Color.FromArgb(207, 192, 142);
            }
            
            e.Graphics.DrawRectangle(gold, rect);
            gold.Dispose();
        }

        private void cbAutumn_Paint(object sender, PaintEventArgs e)
        {
            Point pt = new Point(12, 5);
            Rectangle rect = new Rectangle(pt, new Size(14, 14));
            Pen gold = new Pen(Color.FromArgb(207, 192, 142));
            Point pt2 = new Point(9, 2);
            Rectangle rect2 = new Rectangle(pt2, new Size(14, 14));
            if (cbAutumn.Checked)
            {
                using (Font wing = new Font("Wingdings", 14f))
                    e.Graphics.DrawString("ü", wing, Brushes.Moccasin, rect2);
            }
            if (!cbAutumn.Enabled)
            {
                cbAutumn.ForeColor = Color.FromArgb(120, 120, 120);
            }
            else
            {
                cbAutumn.ForeColor = Color.FromArgb(207, 192, 142);
            }
            e.Graphics.DrawRectangle(gold, rect);
            gold.Dispose();
        }

        private void cbAutumn_Click(object sender, EventArgs e)
        {
            if (cbAutumn.Checked)
            {
                sliderAutumn.Enabled = true;
            }
            else
            {
                sliderAutumn.Enabled = false;
            }
        }

        private void cbSpring_Click(object sender, EventArgs e)
        {
            if (cbSpring.Checked)
            {
                sliderSpring.Enabled = true;
            }
            else
            {
                sliderSpring.Enabled = false;
            }
        }

        private void SpringAutumn()
        {
            if (Algorithm.Configuration.GetInstance.GetLectureClassesSpring().Count != 0)
            {
                cbSpring.Checked = true;
                cbSpring.Enabled = true;
                sliderSpring.Enabled = true;
                SemesterKey = "Spring";
                if (Algorithm.Configuration.GetInstance.GetLectureClassesAutumn().Count != 0)
                {
                    cbAutumn.Checked = true;
                    cbAutumn.Enabled = true;
                    sliderAutumn.Enabled = true;
                    SemesterKey = "Spring and Autumn";
                }
            }
            else
            {
                cbSpring.Checked = false;
                cbSpring.Enabled = false;
                sliderSpring.Enabled = false;

            }
            if (Algorithm.Configuration.GetInstance.GetLectureClassesAutumn().Count != 0)
            {
                cbAutumn.Checked = true;
                cbAutumn.Enabled = true;
                sliderAutumn.Enabled = true;
                SemesterKey = "Autumn";
                if (Algorithm.Configuration.GetInstance.GetLectureClassesSpring().Count != 0)
                {
                    cbSpring.Checked = true;
                    cbSpring.Enabled = true;
                    sliderSpring.Enabled = true;
                    SemesterKey = "Spring and Autumn";
                }
            }
            else
            {
                cbAutumn.Checked = false;
                cbAutumn.Enabled = false;
                sliderAutumn.Enabled = false;
            }
        }
    }
}
