using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmTimetablingSystem.Algorithm
{
    public class Lecturer
    {
        #region Properties
        private string _name = ""; // Professor's Name
        public string GetName { get { return _name; } }

        private int _id; // Professor's ID
        public int GetId { get { return _id; } }
        private bool[,] _schedule = new bool[9, 6];
        public bool[,] GetSchedule { get { return _schedule; } }

        private string _availableTime = "";
        public string GetTime { get { return _availableTime; } }

        // List of classes that professor teaches
        private List<LectureClass> _lectureClasses = new List<LectureClass>();
        public List<LectureClass> GetLectureClasses { get { return _lectureClasses; } }

        #endregion
        public Lecturer(int id, string name, bool[,] schedule, string availableTime)
        {
            _name = name;
            _id = id;
            _schedule = schedule;
            _availableTime = availableTime;

        }
        /// Bind professor to course
        public void AddLectureClass(LectureClass lectureClass)
        {
            _lectureClasses.Add(lectureClass); 
        }

        // Compares ID's of two objects which represent professors
        public static bool operator ==(Lecturer lP, Lecturer rP)
        { return (lP._id == rP._id); }

        // Compares ID's of two objects which represent professors
        public static bool operator !=(Lecturer lP, Lecturer rP)
        { return (lP._id != rP._id); }

        // Compares ID's of two objects which represent studentGroups
        public override bool Equals(object obj)
        {
            //Check for null and compare run-time types.
            if (obj == null || this.GetType() != obj.GetType()) return false;
            Lecturer p = (Lecturer)obj;
            return (p._id == this._id);
        }

        // GetHashCode OverLoads
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
