using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmTimetablingSystem.Algorithm
{
    public class Lecture
    {
        #region Properties

        // Course ID
        private int _id = 0;
        public int GetId { get { return _id; } }

        private string _name = string.Empty;
        public string GetName { get { return _name; } }
        public string _classSpecifyTime, _classType, _tutorialSpecifyTime, _tutorialType, _lecturer, _studentGroup;

        public int _credits,_classDuration,_tutorialDuration;
        public int GetCredits { get { return _credits; } }
        #endregion
        /// <summary>
        /// Constructor of Course Class
        /// </summary>
        /// <param name="_id">Course ID</param>
        /// <param name="_name">Course Name</param>
        public Lecture(int id, string code, string name, int credits)
        {
            _id = id;
            _name = name;
            _credits = credits;
            //_classDuration = Duration;
            //_classSpecifyTime = SpecifyTime;
            //_classType = Type;
            //_lecturer = lecturer;
            //_studentGroup = studentGroup;
        }
    }
}
