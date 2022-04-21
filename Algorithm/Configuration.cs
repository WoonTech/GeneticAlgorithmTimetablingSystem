using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GemBox.Spreadsheet;
namespace GeneticAlgorithmTimetablingSystem.Algorithm
{
    public class Configuration
    {
        // Global Instanaces
        static Configuration _instance = new Configuration();
        public static Configuration GetInstance { get { return _instance; } }

        #region Properties

        private Dictionary<int, Lecturer> _lecturers = new Dictionary<int, Lecturer>();
        private Dictionary<int, StudentsGroup> _studentGroups = new Dictionary<int, StudentsGroup>();
        private Dictionary<int, Lecture> _lectures = new Dictionary<int, Lecture>();
        private Dictionary<int, Room> _rooms = new Dictionary<int, Room>();
        public Dictionary<int, Room> Rooms { get { return _rooms; } }
        private List<LectureClass> _lectureClassesSpring = new List<LectureClass>();
        private List<LectureClass> _lectureClassesAutumn = new List<LectureClass>();
        Lecturer l;
        private bool _isEmpty;
        #endregion
        public Configuration()
        {
            _isEmpty = true;
        }
        //~ operator can reverse each bit
        ~Configuration()
        {
            _lecturers.Clear();
            _studentGroups.Clear();
            _lectures.Clear();
            _rooms.Clear();
            _lectureClassesSpring.Clear();
            _lectureClassesAutumn.Clear();
        }

        // Parse file and store parsed object
        public void ParseFile()
        {
            // clear previously parsed objects
            _lecturers.Clear();
            _studentGroups.Clear();
            _lectures.Clear();
            _rooms.Clear();
            _lectureClassesSpring.Clear();
            _lectureClassesAutumn.Clear();
            Room.RestartIDs(); // set the room count into 0

            ExcelFile excelFileLecturer = ExcelFile.Load("Lecturer.xlsx");
            foreach (ExcelWorksheet worksheet in excelFileLecturer.Worksheets)
            {
                int rowIndex = 0;
                foreach (ExcelRow row in worksheet.Rows)
                {
                    if (rowIndex != 0)
                    {
                        string tmpID = row.Cells[0].Value.ToString();
                        string tmpName = row.Cells[1].Value.ToString();
                        string tmpSchedule = row.Cells[2].Value.ToString();
                        LecturerInfoCompiler lIc3 = new LecturerInfoCompiler();
                        Lecturer lecturer;
                        if (lIc3.StartScanner(tmpSchedule))
                        {
                            lecturer = new Lecturer(Convert.ToInt32(tmpID), tmpName, lIc3.CompiledData,null);
                            _lecturers.Add(lecturer.GetId, lecturer);
                        }
                    }
                    rowIndex++;
                }
            }
            ExcelFile excelFileRoom = ExcelFile.Load("Room.xlsx");
            foreach (ExcelWorksheet worksheet in excelFileRoom.Worksheets)
            {
                int rowIndex = 0;
                foreach (ExcelRow row in worksheet.Rows)
                {
                    if (rowIndex != 0)
                    {
                        string tmpID = row.Cells[0].Value.ToString();
                        string tmpName = row.Cells[1].Value.ToString();
                        string tmpType = row.Cells[2].Value.ToString();
                        string tmpSize = row.Cells[3].Value.ToString();
                        Room room;
                        room = new Room(Convert.ToInt32(tmpID), tmpName, tmpType, Convert.ToInt32(tmpSize));
                        _rooms.Add(room.GetId, room);
                    }
                    rowIndex++;
                }
            }

            ExcelFile excelFileStudentGroup = ExcelFile.Load("StudentGroup.xlsx");
            foreach (ExcelWorksheet worksheet in excelFileStudentGroup.Worksheets)
            {
                int rowIndex = 0;
                foreach (ExcelRow row in worksheet.Rows)
                {
                    if (rowIndex != 0)
                    {
                        string tmpID = row.Cells[0].Value.ToString();
                        string tmpName = row.Cells[1].Value.ToString();
                        string tmpSize = row.Cells[2].Value.ToString();
                        StudentsGroup studentsGroup;
                        studentsGroup = new StudentsGroup(Convert.ToInt32(tmpID), tmpName, Convert.ToInt32(tmpSize));
                        _studentGroups.Add(studentsGroup.GetId, studentsGroup);
                    }
                    rowIndex++;
                }
            }

            ExcelFile excelFileModule = ExcelFile.Load("Module.xlsx");
            foreach (ExcelWorksheet worksheet in excelFileModule.Worksheets)
            {

                int rowIndex = 0;
                foreach (ExcelRow row in worksheet.Rows)
                {
                    List<Lecturer> lecturer111 = new List<Lecturer>();
                    if (rowIndex != 0)
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
                        Lecture module = new Lecture(Convert.ToInt32(tmpID), tmpCode, tmpName, Convert.ToInt32(tmpCredits));
                        Lecture moduleTutorial = new Lecture(Convert.ToInt32(tmpID), tmpCode, tmpName + " tutorial", Convert.ToInt32(tmpCredits));
                        (List<string> tmpLecturer2, List<string> tmpTime) =LecturerReader(tmpLecturer,tmpModuleSemester);
                        string[] time = new string[tmpLecturer2.Count];
                        int i = 0;
                        int s = 0;
                        foreach (string time1 in tmpTime)
                        {
                            time[i] = time1;
                            i++;
                        }

                        foreach (string lecturers in tmpLecturer2)
                        {
                            foreach (KeyValuePair<int, Lecturer> it3 in _lecturers)
                            {
                                
                                if (lecturers == it3.Value.GetName)
                                {
                                    l = new Lecturer(it3.Value.GetId, it3.Value.GetName, it3.Value.GetSchedule, time[s]);
                                    lecturer111.Add(l);
                                    s++;
                                    
                                    break;
                                }
                            }
                        }

                        List<StudentsGroup> sg = new List<StudentsGroup>();
                        int num = 0;
                        var numarray = tmpStudentGroup.Split(new[] { " " }, StringSplitOptions.None); //1 2
                        
                        for (num = 0; num < numarray.Length; num++)
                        {
                            foreach (StudentsGroup sg2 in _studentGroups.Values)
                            {
                                if (numarray[num] == sg2.GetId.ToString())
                                {
                                    StudentsGroup g = new StudentsGroup(sg2.GetId, sg2.GetName, sg2.GetNumberOfStudents);
                                    sg.Add(g);
                                }
                            }
                        }
                        int k;
                        LecturerInfoCompiler lIc = new LecturerInfoCompiler();
                        LecturerInfoCompiler lIc2 = new LecturerInfoCompiler();
                        LecturerInfoCompiler lIc3 = new LecturerInfoCompiler();
                        LecturerInfoCompiler lIc4 = new LecturerInfoCompiler();
                        if (tmpModuleSemester == "Spring" || tmpModuleSemester == "Year Long")
                        {
                            for (k = 0; k < Convert.ToInt32(tmpCredits) / 10; k++)
                            {
                                if (lIc.StartScanner(tmpClassSpecifyTime))
                                {
                                    LectureClass lc = new LectureClass(lecturer111, module, sg, tmpClassType, Convert.ToInt32(tmpClassDuration), Convert.ToInt32(tmpID), k, lIc.CompiledData, tmpModuleSemester);
                                    _lectureClassesSpring.Add(lc);
                                }
                                lIc.Clean();

                            }
                            if (Convert.ToInt32(tmpTutorialDuration) != 0)
                            {
                                if (lIc2.StartScanner(tmpTutorialSpecifyTime))
                                {
                                    LectureClass lc_tutorial = new LectureClass(lecturer111, moduleTutorial, sg, tmpTutorialType, Convert.ToInt32(tmpTutorialDuration), Convert.ToInt32(tmpID), k, lIc2.CompiledData, tmpModuleSemester);
                                    _lectureClassesSpring.Add(lc_tutorial);
                                }
                            }

                            lIc2.Clean();
                        }
                        if (tmpModuleSemester == "Autumn" || tmpModuleSemester == "Year Long")
                        {
                            for (k = 0; k < Convert.ToInt32(tmpCredits) / 10; k++)
                            {
                                if (lIc3.StartScanner(tmpClassSpecifyTime))
                                {
                                    LectureClass lc = new LectureClass(lecturer111, module, sg, tmpClassType, Convert.ToInt32(tmpClassDuration), Convert.ToInt32(tmpID), k, lIc3.CompiledData, tmpModuleSemester);
                                    _lectureClassesAutumn.Add(lc);
                                }
                                lIc3.Clean();

                            }
                            if (Convert.ToInt32(tmpTutorialDuration) != 0)
                            {
                                if (lIc4.StartScanner(tmpTutorialSpecifyTime))
                                {
                                    LectureClass lc_tutorial = new LectureClass(lecturer111, moduleTutorial, sg, tmpTutorialType, Convert.ToInt32(tmpTutorialDuration), Convert.ToInt32(tmpID), k, lIc4.CompiledData, tmpModuleSemester);
                                    _lectureClassesAutumn.Add(lc_tutorial);
                                }
                            }

                            lIc4.Clean();
                        }    

                    }
                    rowIndex++;

                }
                
            }
            _isEmpty = false;
        }

        public Lecturer GetLecturerById(int id)
        {
            if (_lecturers.ContainsKey(id))
                return _lecturers[id];
            return null;
        }

        public int GetNumberOfLecturers() { return (int)_lecturers.Count; }
        public StudentsGroup GetStudentsGroupById(int id)
        {
            if (_studentGroups.ContainsKey(id))
                return _studentGroups[id];
            return null;
        }
        public int GetNumberOfStudentGroups() { return (int)_studentGroups.Count; }

        public Lecture GetLectureById(int id)
        {
            if (_lectures.ContainsKey(id))
                return _lectures[id];
            return null;
        }
        public int GetNumberOfLectures() { return (int)_lectures.Count; }

        public Room GetRoomById(int id)
        {
            if (_rooms.ContainsKey(id))
                return _rooms[id];
            return null;
        }
        public int GetNumberOfRooms() { return (int)_rooms.Count; }
        public List<LectureClass> GetLectureClassesAutumn() { return _lectureClassesAutumn; }
        public List<LectureClass> GetLectureClassesSpring() { return _lectureClassesSpring; }
        public int GetNumberOfLectureClassesSpring() { return (int)_lectureClassesSpring.Count; }
        public int GetNumberOfLectureClassesAutumn() { return (int)_lectureClassesAutumn.Count; }
        public bool IsEmpty() { return _isEmpty; }
        private (List<string>, List<string>) LecturerReader(string lecturer, string semester)
        {
            List<string> name = new List<string>();
            List<string> time = new List<string>();
            var numarray = lecturer.Split(new[] { " & "}, StringSplitOptions.None); //Dr hello , ALL & Dr hi , 3 ~ 14
            for (int num = 0; num < numarray.Length; num++)
            {
                var numarray2 = numarray[num].Split(new[] { " { "}, StringSplitOptions.None);            
                var numarray3 = numarray2[1].Split(new[] { " } ", " }" }, StringSplitOptions.None);
                name.Add(numarray2[0]);
                if ((numarray3[0] == "ALL" || numarray3[0] == " ALL") && semester == "Spring")
                {
                    time.Add("3 ~ 14");
                }
                else if ((numarray3[0] == "ALL" || numarray3[0] == " ALL") && semester == "Autumn")
                {
                    time.Add("21 ~ 33");
                }
                else if ((numarray3[0] == "ALL" || numarray3[0] == " ALL") && semester == "Year Long")
                {
                    
                }
                else
                {
                    time.Add(numarray3[0]);
                }


            }
            return (name, time);
        }
    }
}
