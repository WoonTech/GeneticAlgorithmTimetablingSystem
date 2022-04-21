using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using GemBox.Spreadsheet;
using System.Reflection;

namespace GeneticAlgorithmTimetablingSystem
{
    public partial class MainForm : Form
    {
        #region Room properties
        //System.AppDomain.CurrentDomain.BaseDirectory + "Resources\\greyboxDisplay.PNG"
        public List<string> roomID = new List<string>();
        public List<string> roomName = new List<string>();
        public List<string> roomType = new List<string>();
        public List<string> roomSize = new List<string>();
        #endregion

        #region StudentGroup properties
        public List<string> studentGroupID = new List<string>();
        public List<string> studentGroupName = new List<string>();
        public List<string> studentGroupSize = new List<string>();
        #endregion

        #region Module Properties
        public List<string> moduleID = new List<string>();
        public List<string> moduleCode = new List<string>();
        public List<string> moduleName = new List<string>();
        public List<string> credits = new List<string>();
        public List<string> classDuration = new List<string>();
        public List<string> classSpecifyTime = new List<string>();
        public List<string> classType = new List<string>();
        public List<string> tutorialDuration = new List<string>();
        public List<string> tutorialSpecifyTime = new List<string>();
        public List<string> tutorialType = new List<string>();
        public List<string> lecturer = new List<string>();
        public List<string> studentGroup = new List<string>();
        public List<string> moduleSemester = new List<string>();
        #endregion


        #region Lecturer Properties
        public List<string> lecturerID = new List<string>();
        public List<string> lecturerName = new List<string>();
        public List<string> lecturerSchedule = new List<string>();
        #endregion
        #region timetable Properties
        string nl = Environment.NewLine;
        int rowTimeTable, columnTimetable, tmpRow, tmpColumn;
        #endregion
        public MainForm()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
            resetLabel();
            addEmoji(1);
            pbNonStart.Visible = true;
            pbStart.Visible = false;
            timerCalender.Start();

        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
            timerCalender.Stop();
            return;
        }

        private void pbMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        
        private void display(List<string> data, int rowNumber, int order)
        {
            
            pnDisplay.Controls.Add(dataGridView1);
            if (order == 1)
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
            }

            dataGridView1.Columns.Add(rowNumber.ToString(),data[0] );
            if (dataGridView1.Rows.Count == 0)
            {
                //dataGridView1.Columns.Add();
                for (int rowIndex = 1; rowIndex < rowNumber; rowIndex++)
                {
                    dataGridView1.RowTemplate.Height = 15;
                    dataGridView1.Rows.Add();
                    dataGridView1.RowTemplate.Height = 45;
                    dataGridView1.Rows.Add();

                }
            }
            for (int rowIndex = 1; rowIndex < rowNumber; rowIndex++)
            {
                dataGridView1.Rows[rowIndex+rowIndex-1].Cells[order - 1].Value = data[rowIndex];

            }
        }

        private void resetLabel()
        {
            pnDisplay.Controls.Clear();
            lblStudent.ForeColor = Color.FromArgb(240, 230, 210);
            lblStudent.Text = "Student";
            lblRoom.ForeColor = Color.FromArgb(240, 230, 210);
            lblRoom.Text = "Room";
            lblModule.ForeColor = Color.FromArgb(240, 230, 210);
            lblModule.Text = "Module ";
            lblLecturer.ForeColor = Color.FromArgb(240, 230, 210);
            lblLecturer.Text = "Lecturer";
            pbBarRoom.Visible = false;
            pbBarStudent.Visible = false;
            pbBarModule.Visible = false;
            pbBarLecturer.Visible = false;
            pbBarCalender.Visible = false;
            pbModuleBar2.Visible = false;
            pbBarRoom2.Visible = false;
            pbStudentBar2.Visible = false;
            pbLecturerBar2.Visible = false;
            panel8.Controls.Remove(pnSemester);
            panel8.Controls.Remove(pnAcademicField);
            panel8.Controls.Remove(pnLecturer);
            panel8.Controls.Remove(pnRoom);

        }
        private void addEmoji(int error)
        {
            #region Add Sad Emoji
            Label label = new Label();
            pnDisplay.Controls.Add(label);
            label.Width = 400;
            label.Height = 18;           
            label.ForeColor = Color.FromArgb(106, 111, 119);
            label.Font = new Font("Arial", 12);
            if (error == 1)
            {
                label.Text = "You haven't import any data...";
                label.Location = new Point(483, 281);
            }
            else if (error == 2)
            {
                label.Text = "You have import a wrong format dataset...";
                label.Location = new Point(448, 281);

            }
            #endregion
        }
        private void pbRoom_Click(object sender, EventArgs e)
        {
            pbBarRoom.Visible = true;
            ExcelFile excelFile = new ExcelFile();
            OpenFileDialog openFromExcel = new OpenFileDialog();
            openFromExcel.Filter = @"Excel files|*.xlsx";
            if (openFromExcel.ShowDialog() == DialogResult.OK)
            {
                resetLabel();
                roomID.Clear();
                roomName.Clear();
                roomType.Clear();
                roomSize.Clear();
                lblRoom.ForeColor = Color.FromArgb(192, 189, 175);
                pbBarRoom2.Visible = true;
                ExcelFile workbook = ExcelFile.Load(openFromExcel.FileName);
                foreach (ExcelWorksheet worksheet in workbook.Worksheets)
                {

                    foreach (ExcelRow row in worksheet.Rows)
                    {

                        try
                        {
                            string tmpID = row.Cells[0].Value.ToString();
                            string tmpName = row.Cells[1].Value.ToString();
                            string tmpType = row.Cells[2].Value.ToString();
                            string tmpSize = row.Cells[3].Value.ToString();
                            roomID.Add(tmpID);
                            roomName.Add(tmpName);
                            roomType.Add(tmpType);
                            roomSize.Add(tmpSize);
                            //create file save data into it
                        }
                        catch (NullReferenceException ex)
                        {
                            resetLabel();
                            addEmoji(2);
                            return;
                        }
                    }
                }
                if (roomID[0] != "Room ID")
                {
                    resetLabel();
                    addEmoji(2);
                    return;
                }
                display(roomID, roomID.Count, 1);
                display(roomName, roomID.Count, 2);
                display(roomType, roomID.Count, 3);
                display(roomSize, roomID.Count, 4);
                #region Export to excel file
                SaveFileDialog save2Excel = new SaveFileDialog();
                //SpreadsheetInfo.SetLicense("YOUR-SERIAL-KEY-HERE");
                save2Excel.Filter = @"Excel files|*.xlsx";
                save2Excel.DefaultExt = "Room.xlsx";
                save2Excel.FileName = "Room.xlsx";
                string[] files = Directory.GetFiles(System.AppDomain.CurrentDomain.BaseDirectory, "Room.xlsx");

                if (files.Length != 0)
                {
                    File.Delete(System.AppDomain.CurrentDomain.BaseDirectory + "Room.xlsx");
                }

                ExcelFile excelFileExport = new ExcelFile();
                ExcelWorksheet workSheet = excelFileExport.Worksheets.Add("Room");
                int RowCount = 0;
                for (int row = 0; row < roomID.Count; row++, RowCount++)
                {
                    workSheet.Cells[row, 0].Value = roomID[row].ToString();
                    workSheet.Cells[row, 1].Value = roomName[row].ToString();
                    workSheet.Cells[row, 2].Value = roomType[row].ToString();
                    workSheet.Cells[row, 3].Value = roomSize[row].ToString();
                }
                excelFileExport.Save(save2Excel.FileName);
                #endregion

            }
            else
            {
                resetLabel();
            }
            if (roomID.Count > 0)
            {
                pbRoom.Visible = false;
                pbRoomGold.Visible = true;
                label4.ForeColor = Color.FromArgb(255,255,255);
            }
            if (roomID.Count > 0 && studentGroupID.Count > 0 && moduleID.Count > 0 && lecturerID.Count > 0)
            {
                pbNonStart.Visible = false;
                pbStart.Visible = true;
            }

        }

        private void pbStudents_Click(object sender, EventArgs e)
        {
            pbBarStudent.Visible = true;
            ExcelFile excelFile = new ExcelFile();
            OpenFileDialog openFromExcel = new OpenFileDialog();
            openFromExcel.Filter = @"Excel files|*.xlsx";
            if (openFromExcel.ShowDialog() == DialogResult.OK)
            {
                resetLabel();
                studentGroupID.Clear();
                studentGroupName.Clear();
                studentGroupSize.Clear();
                lblStudent.ForeColor = Color.FromArgb(192, 189, 175);
                pbStudentBar2.Visible = true;
                ExcelFile workbook = ExcelFile.Load(openFromExcel.FileName);
                foreach (ExcelWorksheet worksheet in workbook.Worksheets)
                {

                    foreach (ExcelRow row in worksheet.Rows)
                    {

                        try
                        {
                            string tmpID = row.Cells[0].Value.ToString();
                            string tmpName = row.Cells[1].Value.ToString();
                            string tmpSize = row.Cells[2].Value.ToString();
                            studentGroupID.Add(tmpID);
                            studentGroupName.Add(tmpName);
                            studentGroupSize.Add(tmpSize);
                        }
                        catch (NullReferenceException ex)
                        {
                            resetLabel();
                            addEmoji(2);
                            return;
                        }
                    }
                }
                if (studentGroupID[0] != "StudentGroup ID")
                {
                    resetLabel();
                    addEmoji(2);
                    return;
                }
                display(studentGroupID, studentGroupID.Count, 1);
                display(studentGroupName, studentGroupName.Count, 2);
                display(studentGroupSize, studentGroupSize.Count, 3);
                #region Export to excel file
                SaveFileDialog save2Excel = new SaveFileDialog();
                //SpreadsheetInfo.SetLicense("YOUR-SERIAL-KEY-HERE");
                save2Excel.Filter = @"Excel files|*.xlsx";
                save2Excel.DefaultExt = "StudentGroupData.xlsx";
                save2Excel.FileName = "StudentGroup.xlsx";
                string[] files = Directory.GetFiles(System.AppDomain.CurrentDomain.BaseDirectory, "StudentGroup.xlsx");

                if (files.Length != 0)
                {
                    File.Delete(System.AppDomain.CurrentDomain.BaseDirectory + "StudentGroup.xlsx");
                }

                ExcelFile excelFileExport = new ExcelFile();
                ExcelWorksheet workSheet = excelFileExport.Worksheets.Add("StudentGroup");
                int RowCount = 0;
                for (int row = 0; row < studentGroupID.Count; row++, RowCount++)
                {
                    workSheet.Cells[row, 0].Value = studentGroupID[row].ToString();
                    workSheet.Cells[row, 1].Value = studentGroupName[row].ToString();
                    workSheet.Cells[row, 2].Value = studentGroupSize[row].ToString();

                }
                excelFileExport.Save(save2Excel.FileName);
                #endregion
            }
            else
            {
                pbBarStudent.Visible = false;
            }
            if (studentGroupID.Count > 0)
            {
                pbStudents.Visible = false;
                pbStudentsGold.Visible = true;
                label3.ForeColor = Color.FromArgb(255, 255, 255);
            }
            if (roomID.Count > 0 && studentGroupID.Count > 0 && moduleID.Count > 0 && lecturerID.Count > 0)
            {
                pbNonStart.Visible = false;
                pbStart.Visible = true;
            }
        }

        private void pbModule_Click(object sender, EventArgs e)
        {
            pbBarModule.Visible = true;
            ExcelFile excelFile = new ExcelFile();
            OpenFileDialog openFromExcel = new OpenFileDialog();
            openFromExcel.Filter = @"Excel files|*.xlsx";
            if (openFromExcel.ShowDialog() == DialogResult.OK)
            {
                resetLabel();
                moduleID.Clear();
                moduleCode.Clear();
                moduleName.Clear();
                credits.Clear();
                classDuration.Clear();
                classSpecifyTime.Clear();
                classType.Clear();
                tutorialDuration.Clear();
                tutorialSpecifyTime.Clear();
                tutorialType.Clear();
                lecturer.Clear();
                studentGroup.Clear();
                moduleSemester.Clear();
                lblModule.ForeColor = Color.FromArgb(192, 189, 175);
                pbModuleBar2.Visible = true;
                ExcelFile workbook = ExcelFile.Load(openFromExcel.FileName);
                foreach (ExcelWorksheet worksheet in workbook.Worksheets)
                {

                    foreach (ExcelRow row in worksheet.Rows)
                    {

                        try
                        {
                            string tmpID = row.Cells[0].Value.ToString();
                            string tmpCode = row.Cells[1].Value.ToString();
                            string tmpName = row.Cells[2].Value.ToString();
                            string tmpCredits = row.Cells[3].Value.ToString();
                            string tmpClassDuration = row.Cells[4].Value.ToString();
                            string tmpClassSpecifyTime = row.Cells[5].Value.ToString();
                            string tmpClassType = row.Cells[6].Value.ToString();
                            string tmpTutorialDuration = row.Cells[7].Value.ToString();
                            string tmpTutorialSpecifyTime = row.Cells[8].Value.ToString();
                            string tmpTutorialType = row.Cells[9].Value.ToString();
                            string tmpLecturer = row.Cells[10].Value.ToString();
                            string tmpStudentGroup = row.Cells[11].Value.ToString();
                            string tmpModuleSemester = row.Cells[12].Value.ToString();
                            moduleID.Add(tmpID);
                            moduleCode.Add(tmpCode);
                            moduleName.Add(tmpName);
                            credits.Add(tmpCredits);
                            classDuration.Add(tmpClassDuration);
                            classSpecifyTime.Add(tmpClassSpecifyTime);
                            classType.Add(tmpClassType);
                            tutorialDuration.Add(tmpTutorialDuration);
                            tutorialSpecifyTime.Add(tmpTutorialSpecifyTime);
                            tutorialType.Add(tmpTutorialType);
                            lecturer.Add(tmpLecturer);
                            studentGroup.Add(tmpStudentGroup);
                            moduleSemester.Add(tmpModuleSemester);
                        }
                        catch (NullReferenceException ex)
                        {
                            resetLabel();
                            addEmoji(2);
                            return;
                        }
                    }
                }
                if (moduleID[0] != "Module ID")
                {
                    resetLabel();
                    addEmoji(2);
                    return;
                }
                display(moduleID, moduleID.Count, 1);
                display(moduleCode, moduleID.Count, 2);
                display(moduleName, moduleID.Count, 3);
                display(credits, moduleID.Count, 4);
                display(classDuration, moduleID.Count, 5);
                display(classSpecifyTime, moduleID.Count, 6);
                display(classType, moduleID.Count, 7);
                display(tutorialDuration, moduleID.Count, 8);
                display(tutorialSpecifyTime, moduleID.Count, 9);
                display(tutorialType, moduleID.Count, 10);
                display(lecturer, moduleID.Count, 11);
                display(studentGroup, moduleID.Count, 12);
                display(moduleSemester, moduleID.Count, 13);
                #region Export to excel file
                SaveFileDialog save2Excel = new SaveFileDialog();
                //SpreadsheetInfo.SetLicense("YOUR-SERIAL-KEY-HERE");
                save2Excel.Filter = @"Excel files|*.xlsx";
                save2Excel.DefaultExt = "Module.xlsx";
                save2Excel.FileName = "Module.xlsx";
                string[] files = Directory.GetFiles(System.AppDomain.CurrentDomain.BaseDirectory, "Module.xlsx");

                if (files.Length != 0)
                {
                    File.Delete(System.AppDomain.CurrentDomain.BaseDirectory + "Module.xlsx");
                }

                ExcelFile excelFileExport = new ExcelFile();
                ExcelWorksheet workSheet = excelFileExport.Worksheets.Add("Module");
                int RowCount = 0;
                for (int row = 0; row < moduleID.Count; row++, RowCount++)
                {
                    workSheet.Cells[row, 0].Value = moduleID[row].ToString();
                    workSheet.Cells[row, 1].Value = moduleCode[row].ToString();
                    workSheet.Cells[row, 2].Value = moduleName[row].ToString();
                    workSheet.Cells[row, 3].Value = credits[row].ToString();
                    workSheet.Cells[row, 4].Value = classDuration[row].ToString();
                    workSheet.Cells[row, 5].Value = classSpecifyTime[row].ToString();
                    workSheet.Cells[row, 6].Value = classType[row].ToString();
                    workSheet.Cells[row, 7].Value = tutorialDuration[row].ToString();
                    workSheet.Cells[row, 8].Value = tutorialSpecifyTime[row].ToString();
                    workSheet.Cells[row, 9].Value = tutorialType[row].ToString();
                    workSheet.Cells[row, 10].Value = lecturer[row].ToString();
                    workSheet.Cells[row, 11].Value = studentGroup[row].ToString();
                    workSheet.Cells[row, 12].Value = moduleSemester[row].ToString();
                }
                excelFileExport.Save(save2Excel.FileName);
                #endregion
            }
            else
            {
                pbBarModule.Visible = false;
            }
            if (moduleID.Count > 0)
            {
                pbModule.Visible = false;
                pbModuleGold.Visible = true;
                label6.ForeColor = Color.FromArgb(255, 255, 255);
            }
            if (roomID.Count > 0 && studentGroupID.Count > 0 && moduleID.Count > 0 && lecturerID.Count> 0)
            {
                pbNonStart.Visible = false;
                pbStart.Visible = true;
            }
        }

        private void lblModule_Click(object sender, EventArgs e)
        {
            resetLabel();
            lblModule.ForeColor = Color.FromArgb(192,189,175);
            pbModuleBar2.Visible = true;
            if (moduleID.Count != 0)
            {
                display(moduleID, moduleID.Count, 1);
                display(moduleCode, moduleID.Count, 2);
                display(moduleName, moduleID.Count, 3);
                display(credits, moduleID.Count, 4);
                display(classDuration, moduleID.Count, 5);
                display(classSpecifyTime, moduleID.Count, 6);
                display(classType, moduleID.Count, 7);
                display(tutorialDuration, moduleID.Count, 8);
                display(tutorialSpecifyTime, moduleID.Count, 9);
                display(tutorialType, moduleID.Count, 10);
                display(lecturer, moduleID.Count, 11);
                display(studentGroup, moduleID.Count, 12);
                display(moduleSemester, moduleID.Count, 13);
            }
            else
            {
                addEmoji(1);
            }
        }

        private void lblRoom_Click(object sender, EventArgs e)
        {
            resetLabel();
            lblRoom.ForeColor = Color.FromArgb(192, 189, 175);
            pbBarRoom2.Visible = true;
            if (roomID.Count != 0)
            {
                display(roomID, roomID.Count, 1);
                display(roomName, roomID.Count, 2);
                display(roomType, roomID.Count, 3);
                display(roomSize, roomID.Count, 4);
            }
            else
            {
                addEmoji(1);
            }
        }

        private void lblStudent_Click(object sender, EventArgs e)
        {
            resetLabel();
            lblStudent.ForeColor = Color.FromArgb(192, 189, 175);
            pbStudentBar2.Visible = true;
            if (studentGroupID.Count != 0)
            {
                display(studentGroupID, studentGroupID.Count, 1);
                display(studentGroupName, studentGroupName.Count, 2);
                display(studentGroupSize, studentGroupSize.Count, 3);
            }
            else
            {
                addEmoji(1);
            }

        }

        private void pbStart_Click(object sender, EventArgs e)
        {
            AlgorithmForm algorithmForm = new AlgorithmForm();
            this.Hide();
            algorithmForm.ShowDialog();
            this.Show();
        }

        private void pbLecturer_Click(object sender, EventArgs e)
        {
            pbBarLecturer.Visible = true;
            ExcelFile excelFile = new ExcelFile();
            OpenFileDialog openFromExcel = new OpenFileDialog();
            openFromExcel.Filter = @"Excel files|*.xlsx";
            if (openFromExcel.ShowDialog() == DialogResult.OK)
            {
                resetLabel();
                lecturerID.Clear();
                lecturerName.Clear();
                lecturerSchedule.Clear();
                lblLecturer.ForeColor = Color.FromArgb(192, 189, 175);
                pbLecturerBar2.Visible = true;
                ExcelFile workbook = ExcelFile.Load(openFromExcel.FileName);
                foreach (ExcelWorksheet worksheet in workbook.Worksheets)
                {

                    foreach (ExcelRow row in worksheet.Rows)
                    {

                        try
                        {
                            string tmpID = row.Cells[0].Value.ToString();
                            string tmpName = row.Cells[1].Value.ToString();
                            string tmpSchedule = row.Cells[2].Value.ToString();
                            lecturerID.Add(tmpID);
                            lecturerName.Add(tmpName);
                            lecturerSchedule.Add(tmpSchedule);
                        }
                        catch (NullReferenceException ex)
                        {
                            resetLabel();
                            addEmoji(2);
                            return;
                        }
                    }
                }
                if (lecturerID[0] != "Lecturer ID")
                {
                    resetLabel();
                    addEmoji(2);
                    return;
                }
                display(lecturerID, lecturerID.Count, 1);
                display(lecturerName, lecturerID.Count, 2);
                display(lecturerSchedule, lecturerID.Count, 3);

                #region Export to excel file
                SaveFileDialog save2Excel = new SaveFileDialog();
                //SpreadsheetInfo.SetLicense("YOUR-SERIAL-KEY-HERE");
                save2Excel.Filter = @"Excel files|*.xlsx";
                save2Excel.DefaultExt = "Lecturer.xlsx";
                save2Excel.FileName = "Lecturer.xlsx";
                string[] files = Directory.GetFiles(System.AppDomain.CurrentDomain.BaseDirectory, "Lecturer.xlsx");

                if (files.Length != 0)
                {
                    File.Delete(System.AppDomain.CurrentDomain.BaseDirectory + "Lecturer.xlsx");
                }

                ExcelFile excelFileExport = new ExcelFile();
                ExcelWorksheet workSheet = excelFileExport.Worksheets.Add("Lecturer");
                int RowCount = 0;
                for (int row = 0; row < lecturerID.Count; row++, RowCount++)
                {
                    workSheet.Cells[row, 0].Value = lecturerID[row].ToString();
                    workSheet.Cells[row, 1].Value = lecturerName[row].ToString();
                    workSheet.Cells[row, 2].Value = lecturerSchedule[row].ToString();

                }
                excelFileExport.Save(save2Excel.FileName);
                #endregion
            }
            else
            {
                pbBarLecturer.Visible = false;
            }
            if (lecturerID.Count > 0)
            {
                pbLecturer.Visible = false;
                pbLecturerGold.Visible = true;
                label2.ForeColor = Color.FromArgb(255, 255, 255);
            }
            if (roomID.Count > 0 && studentGroupID.Count > 0 && moduleID.Count > 0 && lecturerID.Count >0)
            {
                pbNonStart.Visible = false;
                pbStart.Visible = true;
            }
        }

        private void lblLecturer_Click(object sender, EventArgs e)
        {
            resetLabel();
            lblLecturer.ForeColor = Color.FromArgb(192, 189, 175);
            pbLecturerBar2.Visible = true;
            if (lecturerID.Count != 0)
            {
                display(lecturerID, lecturerID.Count, 1);
                display(lecturerName, lecturerID.Count, 2);
                display(lecturerSchedule, lecturerID.Count, 3);
            }
            else
            {
                addEmoji(1);
            }
        }

        private void pbCalender_Click(object sender, EventArgs e)
        {
            resetLabel();
            addEmoji(1);
        }
        private void lblSemester_Click(object sender, EventArgs e)
        {
            if (lblSemester.Text == "Autumn")
            {
                lblSemester.Text = "Spring";
            }
            else if (lblSemester.Text == "Spring")
            {
                lblSemester.Text = "Autumn";
            }
            for (int j = 1; j < 6; j++)
            {
                for (int i = 0; i < 9; i++)
                {
                    dataGridViewCalender.Rows[i].Cells[j].Value = " ";

                }
            }
            cbAcademicField.SelectedItem = "Select Course";
            cbLecturer.SelectedItem = "Select Lecturer";
            cbRoom.SelectedItem = "Select Room";
        }

        private void pbCalenderGold_Click(object sender, EventArgs e)
        {
            resetLabel();
            panel8.Controls.Add(pnAcademicField);
            panel8.Controls.Add(pnRoom);
            panel8.Controls.Add(pnLecturer);
            panel8.Controls.Add(pnSemester);
            pbBarCalender.Visible = true;
            pbBarCalender.BringToFront();
            pnDisplay.Controls.Add(dataGridViewCalender);

            if (dataGridViewCalender.Rows.Count == 0)
            {
                dataGridViewCalender.Rows.Add(9);
                dataGridViewCalender.Rows[0].Cells[0].Value = "   9 AM";
                dataGridViewCalender.Rows[1].Cells[0].Value = "  10 AM";
                dataGridViewCalender.Rows[2].Cells[0].Value = "  11 AM";
                dataGridViewCalender.Rows[3].Cells[0].Value = "  12 PM";
                dataGridViewCalender.Rows[4].Cells[0].Value = "   1 PM";
                dataGridViewCalender.Rows[5].Cells[0].Value = "   2 PM";
                dataGridViewCalender.Rows[6].Cells[0].Value = "   3 PM";
                dataGridViewCalender.Rows[7].Cells[0].Value = "   4 PM";
                dataGridViewCalender.Rows[8].Cells[0].Value = "   5 PM";
                cbAcademicField.SelectedItem = "Select Course";
                cbLecturer.SelectedItem = "Select Lecturer";
                cbRoom.SelectedItem = "Select Room";
            }



        }

        private void timerCalender_Tick(object sender, EventArgs e)
        {
            if (AlgorithmForm.GetKey == 1)
            {
                pbCalender.Visible = false;
                pbCalenderGold.Visible = true;
                label12.ForeColor = Color.FromArgb(255, 255, 255);               
                if (cbAcademicField.Items.Count == 0)
                {
                    cbAcademicField.Items.Add("Select Course");
                    if (cbAcademicField.Items.Count == 1)
                    {
                        pnDisplay.Controls.Add(pbReady);
                        pbReady.BringToFront();
                        for (int i = 1; i < studentGroupName.Count; i++)
                        {
                            cbAcademicField.Items.Add(studentGroupName[i]);
                        }
                    }

                }
                if (cbLecturer.Items.Count == 0)
                {
                    cbLecturer.Items.Add("Select Lecturer");
                    if (cbLecturer.Items.Count == 1)
                    {
                        for (int i = 1; i < lecturerName.Count; i++)
                        {
                            cbLecturer.Items.Add(lecturerName[i]);
                        }
                    }

                }

                if (cbRoom.Items.Count == 0)
                {
                    cbRoom.Items.Add("Select Room");
                    if (cbRoom.Items.Count == 1)
                    {
                        for (int i = 1; i < roomName.Count; i++)
                        {
                            cbRoom.Items.Add(roomName[i]);
                        }
                    }
                }

            }
        }

        private void pbCalenderGold_MouseEnter(object sender, EventArgs e)
        {
            pnDisplay.Controls.Remove(pbReady);
        }

        private void cbLecturer_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SelectedLecturer;
            int f = cbLecturer.SelectedIndex;
            SelectedLecturer = cbLecturer.Items[f].ToString();
            for (int j = 1; j < 6; j++)
            {
                for (int i = 0; i < 9; i++)
                {
                    dataGridViewCalender.Rows[i].Cells[j].Value = " ";

                }
            }

            int rowIndex = 0;
            ExcelFile excelFileGroupSchedule;
            if (lblSemester.Text == "Spring")
            {
                excelFileGroupSchedule = ExcelFile.Load("GroupScheduleSpring.xlsx");
            }
            else
            {
                excelFileGroupSchedule = ExcelFile.Load("GroupScheduleAutumn.xlsx");
            }
            foreach (ExcelWorksheet worksheet in excelFileGroupSchedule.Worksheets)
            {

                foreach (ExcelRow row in worksheet.Rows)
                {
                    if (rowIndex != 0)
                    {
                        if (SelectedLecturer == row.Cells[5].Value.ToString())
                        {
                            (columnTimetable, rowTimeTable) = rowColumnCalculator(Convert.ToInt32(row.Cells[3].Value.ToString()), Convert.ToInt32(row.Cells[2].Value.ToString()));
                            for (int j = 0; j < Convert.ToInt32(row.Cells[6].Value.ToString()); j++)
                            {
                                dataGridViewCalender.Columns[columnTimetable].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                                dataGridViewCalender.Rows[rowTimeTable + j].Cells[columnTimetable].Value = row.Cells[7].Value.ToString() + nl + row.Cells[0].Value.ToString() + nl + row.Cells[5].Value.ToString() + "   " + row.Cells[8].Value.ToString();
                            }
                        }

                    }
                    rowIndex++;

                }
            }

        }

        private void cbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SelectedRoom;
            int f = cbRoom.SelectedIndex;
            int tmpRoom = new int();
            SelectedRoom = cbRoom.Items[f].ToString();

            int rowIndex = 0;
            ExcelFile excelFileGroupSchedule;
            for (int j = 1; j < 6; j++)
            {
                for (int i = 0; i < 9; i++)
                {
                    dataGridViewCalender.Rows[i].Cells[j].Value = " ";

                }
            }
            if (lblSemester.Text == "Spring")
            {
                excelFileGroupSchedule = ExcelFile.Load("GroupScheduleSpring.xlsx");
            }
            else
            {
                excelFileGroupSchedule = ExcelFile.Load("GroupScheduleAutumn.xlsx");
            }
            foreach (ExcelWorksheet worksheet in excelFileGroupSchedule.Worksheets)
            {
                int slot = new int();
                int groupid = new int();
                foreach (ExcelRow row in worksheet.Rows)
                {
                    
                    if (rowIndex != 0)
                    {
                        if (SelectedRoom == row.Cells[0].Value.ToString())
                        {
                            (columnTimetable, rowTimeTable) = rowColumnCalculator(Convert.ToInt32(row.Cells[3].Value.ToString()), Convert.ToInt32(row.Cells[2].Value.ToString()));
                            if (dataGridViewCalender.Rows[rowTimeTable].Cells[columnTimetable].Value.ToString() != " ")
                            {
                                if (groupid == Convert.ToInt32(row.Cells[4].Value))
                                {
                                    
                                }
                                else
                                {
                                    slot = slot + Convert.ToInt32(row.Cells[10].Value);
                                    groupid = Convert.ToInt32(row.Cells[4].Value);
                                    for (int j = 0; j < Convert.ToInt32(row.Cells[6].Value.ToString()); j++)
                                    {
                                        dataGridViewCalender.Columns[columnTimetable].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                                        dataGridViewCalender.Rows[rowTimeTable + j].Cells[columnTimetable].Value = row.Cells[7].Value.ToString() + nl + row.Cells[0].Value.ToString() + "    " + slot.ToString() + "/" + row.Cells[9].Value.ToString() + nl + row.Cells[5].Value.ToString() + "   " + row.Cells[8].Value.ToString();
                                    }
                                    slot = 0;
                                }


                            }
                            else
                            {
                                slot = Convert.ToInt32(row.Cells[10].Value);
                                groupid = Convert.ToInt32(row.Cells[4].Value);
                                for (int j = 0; j < Convert.ToInt32(row.Cells[6].Value.ToString()); j++)
                                {
                                    dataGridViewCalender.Columns[columnTimetable].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                                    dataGridViewCalender.Rows[rowTimeTable + j].Cells[columnTimetable].Value = row.Cells[7].Value.ToString() + nl + row.Cells[0].Value.ToString() + "    " + slot.ToString() + "/" + row.Cells[9].Value.ToString() + nl + row.Cells[5].Value.ToString() + "   " + row.Cells[8].Value.ToString();
                                }
                            }
                        }

                    }
                    rowIndex++;

                }
            }
        }
        private void cbAcademicField_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SelectedField;
            int GroupId = 0;
            int f = cbAcademicField.SelectedIndex;
            int tmpStudentsGroup = new int();
            SelectedField = cbAcademicField.Items[f].ToString();
            
            for (int j = 1; j < 6; j++)
            {
                for (int i = 0; i < 9; i++)
                {
                    dataGridViewCalender.Rows[i].Cells[j].Value = " ";

                }
            }
            int groupIndex = 0;
            foreach (string groupName in studentGroupName)
            {
                if (SelectedField == groupName)
                {
                    GroupId = groupIndex;
                    break;
                }
                groupIndex++;
            }
            int rowIndex = 0;
            ExcelFile excelFileGroupSchedule;
            if (lblSemester.Text == "Spring")
            {
                excelFileGroupSchedule = ExcelFile.Load("GroupScheduleSpring.xlsx");
            }
            else
            {
                excelFileGroupSchedule = ExcelFile.Load("GroupScheduleAutumn.xlsx");
            }
            
            foreach (ExcelWorksheet worksheet in excelFileGroupSchedule.Worksheets)
            {
                int i = new int();
                foreach (ExcelRow row in worksheet.Rows)
                {
                    
                    if (rowIndex != 0)
                    {
                        if (GroupId == Convert.ToInt32(row.Cells[4].Value.ToString()))
                        {
                            (columnTimetable, rowTimeTable) = rowColumnCalculator(Convert.ToInt32(row.Cells[3].Value.ToString()), Convert.ToInt32(row.Cells[2].Value.ToString()));

                            if (dataGridViewCalender.Rows[rowTimeTable].Cells[columnTimetable].Value.ToString() != " ")
                            {
                                for (int j = 0; j < Convert.ToInt32(row.Cells[6].Value.ToString()); j++)
                                {
                                    dataGridViewCalender.Columns[columnTimetable].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                                    dataGridViewCalender.Rows[rowTimeTable + j].Cells[columnTimetable].Value = dataGridViewCalender.Rows[rowTimeTable + j].Cells[columnTimetable].Value + nl + row.Cells[5].Value.ToString() + "   " + row.Cells[8].Value.ToString();
                                }
                            }
                            else
                            {
                                for (int j = 0; j < Convert.ToInt32(row.Cells[6].Value.ToString()); j++)
                                {
                                    dataGridViewCalender.Columns[columnTimetable].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                                    dataGridViewCalender.Rows[rowTimeTable + j].Cells[columnTimetable].Value = row.Cells[7].Value.ToString() + nl + row.Cells[0].Value.ToString() + nl + row.Cells[5].Value.ToString() + "   " + row.Cells[8].Value.ToString();
                                }
                            }                            
                        }

                    }
                    rowIndex++;
                    
                }
            }
        }
        private (int, int) rowColumnCalculator(int day, int time)
        {
            #region day
            if (day == 0)
            {
                tmpColumn = 1;
            }
            else if (day == 1)
            {
                tmpColumn = 2;
            }
            else if (day == 2)
            {
                tmpColumn = 3;
            }
            else if (day == 3)
            {
                tmpColumn = 4;
            }
            else if (day == 4)
            {
                tmpColumn = 5;
            }
            #endregion
            #region time
            if (time == 0)
            {
                tmpRow = 0;
            }
            else if (time == 1)
            {
                tmpRow = 1;
            }
            else if (time == 2)
            {
                tmpRow = 2;
            }
            else if (time == 3)
            {
                tmpRow = 3;
            }
            else if (time == 4)
            {
                tmpRow = 4;
            }
            else if (time == 5)
            {
                tmpRow = 5;
            }
            else if (time == 6)
            {
                tmpRow = 6;
            }
            else if (time == 7)
            {
                tmpRow = 7;
            }
            else if (time == 8)
            {
                tmpRow = 8;
            }
            else if (time == 9)
            {
                tmpRow = 9;
            }
            #endregion
            return (tmpColumn, tmpRow);
        }

    }
}
