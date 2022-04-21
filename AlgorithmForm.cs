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
using System.IO;
using GemBox.Spreadsheet;
using GeneticAlgorithmTimetablingSystem.Algorithm;
namespace GeneticAlgorithmTimetablingSystem
{
    public partial class AlgorithmForm : Form
    {
        public static Algorithm.Algorithm GA;
        public static int _key = 0;
        public static int semester = 0;
        private double accumulateScore;
        double[] RecordScore = new double[1050];
        int[] RecordSecondFull = new int[10] ;
        int[] RecordGeneration = new int[10];
        double[] RecordScoreFull = new double[10];
        int[] RecordSecond = new int[1050];
        string tmpScore ="";
        int record = 0;
        int secondaryscore = 0;
        int accumulateTime = 0;
        int run = 0;
        public static int GetKey { get { return _key; } }
        int StartedTickSpring = 0;
        int StartedTickSummer = 0;
        public static ThreadState state = new ThreadState();
        #region stop
        #endregion

        public AlgorithmForm()
        {
            InitializeComponent();
        }
        class MyFlowLayoutPanel : FlowLayoutPanel
        {
            public MyFlowLayoutPanel()
            {
                this.DoubleBuffered = true;
            }
            protected override void OnScroll(ScrollEventArgs se)
            {
                this.Invalidate();
                base.OnScroll(se);
            }
        }

        private void AlgorithmForm_Load(object sender, EventArgs e)
        {
            pbStart.Visible = true;
            pbStop.Visible = false;
            pbNonStop.Visible = true;
            pbNonStart.Visible = false;
            Configuration.GetInstance.ParseFile();

            if (SettingsForm.settingsKey == 0)
             {
                 Schedule prototype = new Schedule(5, 5, 90, 10);
                 GA = new Algorithm.Algorithm(1000, 180, 50, prototype);
             }
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.Show();
            settingsForm.Close();
            state = ThreadState.Unstarted;
            progressBar1.Maximum = 100;
            progressBar1.Step = 1;
            progressBar1.Value = 0;           
            timerWorkingSet.Start();

        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pbStart_Click(object sender, EventArgs e)
        {
            pbSettings.Cursor = Cursors.No;
            pbSettings.Enabled = false;

            #region reload
            lblFitnessSpring.Text = "0.0000";
            lblFitnessSummer.Text = "0.0000";
            lblGenerationSpring.Text = "00000";
            lblGenerationSummer.Text = "00000";
            lblTimeSpring.Text = "00:00:00";
            lblTimeSummer.Text = "00:00:00";
            semester = 0;
            accumulateTime = 0;
            accumulateScore = 0;
            #endregion

            if (state == ThreadState.Unstarted || state == ThreadState.Stopped)
            {
                
                string[] filesClassSchedule = Directory.GetFiles(System.AppDomain.CurrentDomain.BaseDirectory, "ClassSchedule.xlsx");
                if (filesClassSchedule.Length != 0)
                {
                    File.Delete(System.AppDomain.CurrentDomain.BaseDirectory + "ClassSchedule.xlsx");
                }

                string[] filesGroupSchedule = Directory.GetFiles(System.AppDomain.CurrentDomain.BaseDirectory, "ClassSchedule.xlsx");
                if (filesClassSchedule.Length != 0)
                {
                    File.Delete(System.AppDomain.CurrentDomain.BaseDirectory + "filesClassSchedule.xlsx");
                }
                #region display
                pbStart.Visible = false;
                pbStop.Visible = true;
                pbNonStop.Visible = false;
                pbNonStart.Visible = true;
                progressBar1.Value = 0;
                progressBar1.Visible = true;

                #endregion
                if (SettingsForm.SemesterKey == "Spring and Autumn")
                {
                    if (Algorithm.Algorithm.GetInstance().Start("Spring"))
                    {
                        
                        state = ThreadState.Running;
                        StartedTickSpring = Environment.TickCount;
                    }
                }
                else if (SettingsForm.SemesterKey == "Spring")
                {
                    if (Algorithm.Algorithm.GetInstance().Start("Spring"))
                    {

                        state = ThreadState.Running;
                        StartedTickSpring = Environment.TickCount;
                    }
                }
                else if (SettingsForm.SemesterKey == "Autumn")
                {
                    if (Algorithm.Algorithm.GetInstance().Start("Autumn"))
                    {

                        state = ThreadState.Running;
                        StartedTickSummer = Environment.TickCount;
                    }
                }

            }

        }

        private void timerWorkingSet_Tick(object sender, EventArgs e)
        {
            if (state == ThreadState.Running || state == ThreadState.WaitSleepJoin || state == ThreadState.Suspended)
            {
                double tmpscore = Convert.ToInt32(Math.Round(Algorithm.Algorithm.GetInstance().GetFitness(), 2));
                lblPercentage.Visible = true;
                if (SettingsForm.SemesterKey == "Spring and Autumn")
                {
                    progressBar1.Value = Convert.ToInt32((Math.Round(Algorithm.Algorithm.GetInstance().GetFitness() / 2, 2) + accumulateScore) * 100);

                    if (semester == 0)
                    {
                        lblPercentage.Text = "Generating Timetable Spring Semester: " + ((Math.Round(Algorithm.Algorithm.GetInstance().GetFitness() / 2, 2) + accumulateScore) * 100).ToString() + "% complete ";

                    }
                    else if (semester == 1)
                    {
                        lblPercentage.Text = "Generating Timetable Autumn Semester: " + ((Math.Round(Algorithm.Algorithm.GetInstance().GetFitness() / 2, 2) + accumulateScore) * 100).ToString() + "% complete ";

                    }

                }
                else if (SettingsForm.SemesterKey == "Spring")
                {
                    progressBar1.Value = Convert.ToInt32(Math.Round(Algorithm.Algorithm.GetInstance().GetFitness(), 2) * 100);
                    lblPercentage.Text = "Generating Timetable Spring Semester: " + (Math.Round(Algorithm.Algorithm.GetInstance().GetFitness(), 2) * 100).ToString() + "% complete";

                }
                else if (SettingsForm.SemesterKey == "Autumn")
                {
                    progressBar1.Value = Convert.ToInt32(Math.Round(Algorithm.Algorithm.GetInstance().GetFitness(), 2) * 100);
                    lblPercentage.Text = "Generating Timetable Autumn Semester: " + (Math.Round(Algorithm.Algorithm.GetInstance().GetFitness(), 2) * 100).ToString() + "% complete";

                }

                if (SettingsForm.SemesterKey == "Spring and Autumn" && semester == 0)
                {
                    lblGenerationSpring.Text = Algorithm.Algorithm.GetInstance().GetCurrentGeneration().ToString("00000");
                    lblFitnessSpring.Text = (Math.Round(Algorithm.Algorithm.GetInstance().GetFitness(), 4)).ToString("0.0000");
                    int timeLenghtSpring = (Environment.TickCount - StartedTickSpring) / 1000; // Convert to Second
                    string S = (timeLenghtSpring % 60).ToString();
                    string M = ((timeLenghtSpring / 60) % 60).ToString();
                    string H = (timeLenghtSpring / 3600).ToString();
                    S = (S.Length > 1) ? S : S.Insert(0, "0");
                    M = (M.Length > 1) ? M : M.Insert(0, "0");
                    H = (H.Length > 1) ? H : H.Insert(0, "0");
                    lblTimeSpring.Text = string.Format("{0}:{1}:{2}", H, M, S);
                }
                else if ((SettingsForm.SemesterKey == "Spring and Autumn" && semester == 1))
                {
                    lblGenerationSummer.Text = Algorithm.Algorithm.GetInstance().GetCurrentGeneration().ToString("00000");
                    lblFitnessSummer.Text = (Math.Round(Algorithm.Algorithm.GetInstance().GetFitness(), 4)).ToString("0.0000");
                    int timeLenghtSummer = (Environment.TickCount - StartedTickSummer) / 1000; // Convert to Second
                    string Ss = (timeLenghtSummer % 60).ToString();
                    string Mm = ((timeLenghtSummer / 60) % 60).ToString();
                    string Hh = (timeLenghtSummer / 3600).ToString();
                    Ss = (Ss.Length > 1) ? Ss : Ss.Insert(0, "0");
                    Mm = (Mm.Length > 1) ? Mm : Mm.Insert(0, "0");
                    Hh = (Hh.Length > 1) ? Hh : Hh.Insert(0, "0");
                    lblTimeSummer.Text = string.Format("{0}:{1}:{2}", Hh, Mm, Ss);
                }
                else if (SettingsForm.SemesterKey == "Spring" && semester == 0)
                {
                    lblGenerationSpring.Text = Algorithm.Algorithm.GetInstance().GetCurrentGeneration().ToString("00000");
                    lblFitnessSpring.Text = (Math.Round(Algorithm.Algorithm.GetInstance().GetFitness(), 4)).ToString("0.0000");
                    int timeLenghtSpring = (Environment.TickCount - StartedTickSpring) / 1000; // Convert to Second
                    string S = (timeLenghtSpring % 60).ToString();
                    string M = ((timeLenghtSpring / 60) % 60).ToString();
                    string H = (timeLenghtSpring / 3600).ToString();
                    S = (S.Length > 1) ? S : S.Insert(0, "0");
                    M = (M.Length > 1) ? M : M.Insert(0, "0");
                    H = (H.Length > 1) ? H : H.Insert(0, "0");
                    lblTimeSpring.Text = string.Format("{0}:{1}:{2}", H, M, S);
                }

                else if (SettingsForm.SemesterKey == "Autumn" && semester == 0)
                {
                    lblGenerationSummer.Text = Algorithm.Algorithm.GetInstance().GetCurrentGeneration().ToString("00000");
                    lblFitnessSummer.Text = (Math.Round(Algorithm.Algorithm.GetInstance().GetFitness(), 4)).ToString("0.0000");
                    
                    int timeLenghtSummer = (Environment.TickCount - StartedTickSummer) / 1000; // Convert to Second
                    string Ss = (timeLenghtSummer % 60).ToString();
                    string Mm = ((timeLenghtSummer / 60) % 60).ToString();
                    string Hh = (timeLenghtSummer / 3600).ToString();
                    Ss = (Ss.Length > 1) ? Ss : Ss.Insert(0, "0");
                    Mm = (Mm.Length > 1) ? Mm : Mm.Insert(0, "0");
                    Hh = (Hh.Length > 1) ? Hh : Hh.Insert(0, "0");
                    lblTimeSummer.Text = string.Format("{0}:{1}:{2}", Hh, Mm, Ss);

                }

            }


            if (Algorithm.Algorithm._state == AlgorithmState.AS_CRITERIA_STOPPED && SettingsForm.SemesterKey == "Spring and Autumn" && semester == 0)
            {
                Algorithm.Algorithm.GetInstance().Stop();
                Algorithm.Algorithm._state = AlgorithmState.AS_USER_STOPPED;
                Save(Algorithm.Algorithm.GetInstance().GetBestDNA(), "Spring");
                semester++;
                accumulateScore = 0.5;
                _key = 1;
                Algorithm.Algorithm.GetInstance().Start("Autumn");
                StartedTickSummer = Environment.TickCount;

            }

            else if (Algorithm.Algorithm._state == AlgorithmState.AS_CRITERIA_STOPPED && SettingsForm.SemesterKey == "Spring and Autumn" && semester == 1)
            {
                state = ThreadState.Stopped;
                Algorithm.Algorithm.GetInstance().Stop();
                StartedTickSummer = Environment.TickCount;
                Save(Algorithm.Algorithm.GetInstance().GetBestDNA(), "Autumn");
                semester++;
                _key = 1;
                pbStop_Click(sender, e);
                lblPercentage.Text = "Complete Generating Timetable Spring/Autumn Semester!!";
                MessageBox.Show("This Program could successfully solve the problem.", "Finishing the GA", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                pbStart.Visible = true;
                pbStop.Visible = false;
                pbNonStop.Visible = true;
                pbNonStart.Visible = false;
                pbSettings.Enabled = true;
                pbSettings.Cursor = Cursors.Hand;
            }

            else if (Algorithm.Algorithm._state == AlgorithmState.AS_CRITERIA_STOPPED && SettingsForm.SemesterKey == "Spring" && semester == 0)
            {
                pbStop_Click(sender, e);
                Algorithm.Algorithm._state = AlgorithmState.AS_USER_STOPPED;
                lblPercentage.Text = "Complete Generating Timetable Spring Semester!!!";
                MessageBox.Show("This Program could successfully solve the problem.", "Finishing the GA",
                    MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else if (Algorithm.Algorithm._state == AlgorithmState.AS_CRITERIA_STOPPED && SettingsForm.SemesterKey == "Autumn" && semester == 0)
            {
                pbStop_Click(sender, e);
                Algorithm.Algorithm._state = AlgorithmState.AS_USER_STOPPED;
                lblPercentage.Text = "Complete Generating Timetable Spring Semester!!";
                MessageBox.Show("This Program could successfully solve the problem.", "Finishing the GA",
MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            }
        }

        private void pbStop_Click(object sender, EventArgs e)
        {
            //save file
            pbStart.Visible = true;
            pbStop.Visible = false;
            pbNonStop.Visible = true;
            pbNonStart.Visible = false;
            pbSettings.Enabled = true;
            pbSettings.Cursor = Cursors.Hand;
            _key = 1;
            if (state == ThreadState.Running )
            {
                state = ThreadState.Stopped;
                Algorithm.Algorithm.GetInstance().Stop();
                StartedTickSpring = 0;
                StartedTickSummer = 0;
            }
            if (semester == 0 && (SettingsForm.SemesterKey == "Spring" || SettingsForm.SemesterKey == "Spring and Autumn"))
            {
                Save(Algorithm.Algorithm.GetInstance().GetBestDNA(), "Spring");
            }
            else if (semester == 0 && SettingsForm.SemesterKey == "Autumn")
            {
                Save(Algorithm.Algorithm.GetInstance().GetBestDNA(), "Autumn");

            }
            else if (semester == 1 && SettingsForm.SemesterKey == "Spring and Autumn")
            {
                Save(Algorithm.Algorithm.GetInstance().GetBestDNA(), "Autumn");
            }
        }
        private void Save(Schedule schedule, string Semester)
        {
            int numberOfRooms = Configuration.GetInstance.GetNumberOfRooms();
            int daySize = schedule.day_Hours * numberOfRooms;
            int groupIndex = 0;
            SaveFileDialog save2ExcelGraph = new SaveFileDialog();
            SaveFileDialog save2ExcelData = new SaveFileDialog();
            SaveFileDialog save2ExcelGroupSchedule = new SaveFileDialog();
            //SpreadsheetInfo.SetLicense("YOUR-SERIAL-KEY-HERE");

            save2ExcelGroupSchedule.Filter = @"Excel files|*.xlsx";
            save2ExcelGraph.Filter = @"Excel files|*.xlsx";
            ExcelFile excelFileExport2 = new ExcelFile();
            ExcelWorksheet workSheetGroupSchedule;
            if (Semester == "Spring")
            {
                string[] filesClassSchedule = Directory.GetFiles(System.AppDomain.CurrentDomain.BaseDirectory, "GroupScheduleSpring.xlsx");
                if (filesClassSchedule.Length != 0)
                {
                    File.Delete(System.AppDomain.CurrentDomain.BaseDirectory + "GroupScheduleSpring.xlsx");
                }
                save2ExcelGroupSchedule.DefaultExt = "GroupScheduleSpring.xlsx";
                save2ExcelGroupSchedule.FileName = "GroupScheduleSpring.xlsx";
                workSheetGroupSchedule = excelFileExport2.Worksheets.Add("GroupScheduleSpring");
            }
            else 
            {
                string[] filesClassSchedule = Directory.GetFiles(System.AppDomain.CurrentDomain.BaseDirectory, "GroupScheduleAutumn.xlsx");
                if (filesClassSchedule.Length != 0)
                {
                    File.Delete(System.AppDomain.CurrentDomain.BaseDirectory + "GroupScheduleAutumn.xlsx");
                }
                save2ExcelGroupSchedule.DefaultExt = "GroupScheduleAutumn.xlsx";
                save2ExcelGroupSchedule.FileName = "GroupScheduleAutumn.xlsx";
                workSheetGroupSchedule = excelFileExport2.Worksheets.Add("GroupScheduleAutumn");
            }

            workSheetGroupSchedule.Cells[groupIndex, 0].Value = "Room ID";
            workSheetGroupSchedule.Cells[groupIndex, 1].Value = "Module ID";
            workSheetGroupSchedule.Cells[groupIndex, 2].Value = "Start Time";
            workSheetGroupSchedule.Cells[groupIndex, 3].Value = "Day";
            workSheetGroupSchedule.Cells[groupIndex, 4].Value = "Group ID";
            workSheetGroupSchedule.Cells[groupIndex, 5].Value = "Lecturer";
            workSheetGroupSchedule.Cells[groupIndex, 6].Value = "Duration";
            workSheetGroupSchedule.Cells[groupIndex, 7].Value = "Module Name";
            workSheetGroupSchedule.Cells[groupIndex, 8].Value = "Time";
            workSheetGroupSchedule.Cells[groupIndex, 9].Value = "Room Slot";
            workSheetGroupSchedule.Cells[groupIndex, 10].Value = "Group Slot";
            groupIndex++;

            foreach (KeyValuePair<LectureClass, int> it in schedule.GetClasses().ToList())
            {
                int pos = it.Value; // int pos of _slot array
                int day = pos / daySize;
                int time = pos % daySize; // this is not time now!
                int room = time / schedule.day_Hours;
                time = time % schedule.day_Hours;  // this is a time now!
                int dur = it.Key.GetDuration;
                string lectureName = it.Key.GetLecture.GetName.ToString();
                LectureClass lc = it.Key;
                Room r = Configuration.GetInstance.GetRoomById(room);

                foreach (var gs in lc.GetGroups)
                {
                    foreach (var l in lc.GetLecturer)
                    {
                        workSheetGroupSchedule.Cells[groupIndex, 0].Value = r.GetName;
                        workSheetGroupSchedule.Cells[groupIndex, 1].Value = lc.Class_ID.ToString();
                        workSheetGroupSchedule.Cells[groupIndex, 2].Value = time.ToString();
                        workSheetGroupSchedule.Cells[groupIndex, 3].Value = day.ToString();
                        workSheetGroupSchedule.Cells[groupIndex, 4].Value = gs.GetId.ToString();
                        workSheetGroupSchedule.Cells[groupIndex, 5].Value = l.GetName;
                        workSheetGroupSchedule.Cells[groupIndex, 6].Value = dur.ToString();
                        workSheetGroupSchedule.Cells[groupIndex, 7].Value = lc.GetLecture.GetName.ToString();
                        workSheetGroupSchedule.Cells[groupIndex, 8].Value = l.GetTime;
                        workSheetGroupSchedule.Cells[groupIndex, 9].Value = r.GetNumberOfSeats;
                        workSheetGroupSchedule.Cells[groupIndex, 10].Value = gs.GetNumberOfStudents.ToString();
                        groupIndex++;
                    }

                }
            }
            excelFileExport2.Save(save2ExcelGroupSchedule.FileName);
        }

        private void pbSettings_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
            this.Show();
        }
    }
}
