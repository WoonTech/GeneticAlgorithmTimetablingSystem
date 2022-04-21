using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmTimetablingSystem.Algorithm
{
    public class LectureClass
    {
        #region Properties

        // ID of a Professor who teaches, 
        // Each class can have several professors at first but one of them will be selected 
        private List<Lecturer> _lecturer = new List<Lecturer>();
        public List<Lecturer> GetLecturer { get { return _lecturer; } }

        // Course to which class belongs
        private Lecture _lecture;
        public Lecture GetLecture { get { return _lecture; } }

        // Student groups who attend class, 
        // each class can be bound to multiple students group.
        private List<StudentsGroup> _groups = new List<StudentsGroup>();
        public List<StudentsGroup> GetGroups { get { return _groups; } }

        // Duration of class in hours
        private int _duration = 1;
        public int GetDuration { get { return _duration; } }

        // Initicates wheather class requires specified
        private string _lab = "false";
        public string Lab { get { return _lab; } }

        // Number of seats (students) required in room
        private int _numberOfSeats;
        public int GetNumberOfSeats { get { return _numberOfSeats; } }

        // CourseClass ID's
        public int Class_ID;
        public int Class_Order;
        private bool[,] _schedule = new bool[9, 6];
        public bool[,] GetSchedule { get { return _schedule; } }
        #endregion
        public string _semester;
        public LectureClass(List<Lecturer> lecturer, Lecture lecture,
       List<StudentsGroup> groups, string lab, int duration, int class_Id, int class_order, bool[,] schedule, string semester)
        {
            foreach (Lecturer l in lecturer)
            {
                l.AddLectureClass(this);
                _lecturer.Add(l);
            }
            _lecture = lecture;
            _numberOfSeats = 0;
            _lab = lab;
            _duration = duration;
            Class_ID = class_Id;
            Class_Order = class_order;
            _schedule = schedule;
            _semester = semester;
            foreach (StudentsGroup it in groups)
            {
                it.AddLectureClass(this);
                _groups.Add(it);
                _numberOfSeats += it.GetNumberOfStudents;
            }
        }

        public bool GroupsOverlap(LectureClass c)
        {
            foreach (StudentsGroup it1 in _groups)
            {
                foreach (StudentsGroup it2 in c._groups)
                {
                    if (it1 == it2)
                        return true;
                }
            }
            return false;
        }

        // Returns TRUE if another class has same professor.
        public bool LecturerOverlaps(LectureClass c)
        {
            foreach (Lecturer l1 in _lecturer)
            {
                foreach (Lecturer l2 in c._lecturer)
                {
                    if (l1 == l2)
                        return true;
                }
            }
            return false;
        }

    }
}
