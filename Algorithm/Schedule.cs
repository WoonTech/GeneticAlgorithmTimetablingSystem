using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmTimetablingSystem.Algorithm
{
    public class Schedule
    {        
        public const int DAY_HOURS = 9; 
        public int day_Hours { get { return DAY_HOURS; } }
        public const int DAYS_NUM = 5;
        public int WEEK = 12;
        public int week_Semester { get { return WEEK; } }
        private const int numberOfScores = 60; //
        #region Properties
        public int _numberOfCrossoverPoints;
        public int _mutationSize;
        public int _crossoverRate;
        public int _mutationRate;
        float _fitness;
        bool[] _criteria;
        bool _criteria2;
        List<LectureClass>[] _slots;
        Dictionary<LectureClass, int> _classes = new Dictionary<LectureClass, int>();
        #endregion
        #region rule properties
        public static int _rule1 = 0;
        public static int _rule2 = 0;
        public static int _rule3 = 0;
        public static int _rule4 = 0;
        public static int _rule45 = 0;
        public static int _rule6 = 0;
        public static int _rule7 = 0;
        public static int _rule8 = 0;
        #endregion
        public Schedule(int numberOfCrossoverPoints, int mutationSize,
    int crossoverRate, int mutationRate)
        {
            _mutationSize = mutationSize;
            _numberOfCrossoverPoints = numberOfCrossoverPoints;
            _crossoverRate = crossoverRate;
            _mutationRate = mutationRate;
            _fitness = 0;
            //
            // reserve space for time-space slots in chromosomes code //room slots
            _slots = new List<LectureClass>[(DAYS_NUM * DAY_HOURS * Configuration.GetInstance.GetNumberOfRooms())];
            for (int ptr = 0; ptr < (DAYS_NUM * DAY_HOURS * Configuration.GetInstance.GetNumberOfRooms()); ptr++)
                _slots[ptr] = new List<LectureClass>();

            // reserve space for flags of class requirements 
            if (SettingsForm.SemesterKey == "Spring" && AlgorithmForm.semester == 0)
            {
                _criteria = new bool[(Configuration.GetInstance.GetNumberOfLectureClassesSpring() * numberOfScores)];

            }
            else if (SettingsForm.SemesterKey == "Autumn" && AlgorithmForm.semester == 0)
            {
                _criteria = new bool[(Configuration.GetInstance.GetNumberOfLectureClassesAutumn() * numberOfScores)];
            }
            else if (SettingsForm.SemesterKey == "Spring and Autumn" && AlgorithmForm.semester == 0)
            {
                _criteria = new bool[(Configuration.GetInstance.GetNumberOfLectureClassesSpring() * numberOfScores)];
            }
            else if (SettingsForm.SemesterKey == "Spring and Autumn" && AlgorithmForm.semester == 1)
            {
                _criteria = new bool[(Configuration.GetInstance.GetNumberOfLectureClassesAutumn() * numberOfScores)];
            }

        }
        public Schedule(Schedule c, bool setupOnly)
        {
            if (setupOnly)
            {
                // reserve space for time-space slots in chromosomes code
                _slots = new List<LectureClass>[(DAYS_NUM * DAY_HOURS * Configuration.GetInstance.GetNumberOfRooms())]; //5*9
                for (int ptr = 0; ptr < (DAYS_NUM * DAY_HOURS * Configuration.GetInstance.GetNumberOfRooms()); ptr++)
                    _slots[ptr] = new List<LectureClass>();

                if (SettingsForm.SemesterKey == "Spring" && AlgorithmForm.semester == 0)
                {
                    _criteria = new bool[(Configuration.GetInstance.GetNumberOfLectureClassesSpring() * numberOfScores)];

                }
                else if (SettingsForm.SemesterKey == "Autumn" && AlgorithmForm.semester == 0)
                {
                    _criteria = new bool[(Configuration.GetInstance.GetNumberOfLectureClassesAutumn() * numberOfScores)];
                }
                else if (SettingsForm.SemesterKey == "Spring and Autumn" && AlgorithmForm.semester == 0)
                {
                    _criteria = new bool[(Configuration.GetInstance.GetNumberOfLectureClassesSpring() * numberOfScores)];
                }
                else if (SettingsForm.SemesterKey == "Spring and Autumn" && AlgorithmForm.semester == 1)
                {
                    _criteria = new bool[(Configuration.GetInstance.GetNumberOfLectureClassesAutumn() * numberOfScores)];
                }
            }
            else
            {
                // copy code
                _slots = c._slots;
                _classes = c._classes;
                // copy flags of class requirements
                _criteria = c._criteria;
                // copy fitness
                _fitness = c._fitness;
            }

            // copy parameters
            _numberOfCrossoverPoints = c._numberOfCrossoverPoints;
            _mutationSize = c._mutationSize;
            _crossoverRate = c._crossoverRate;
            _mutationRate = c._mutationRate;
        }
        // Makes copy at chromosome
        public Schedule MakeCopy(bool setupOnly)
        {
            // make object by calling copy constructor and return smart pointer to new object
            return new Schedule(this, setupOnly);
        }
        public Schedule MakeNewFromPrototype(string semester)
        {
            // number of time-space slots
            int size = _slots.Length;
            
            // make new genes, copy genes setup
            Schedule newGenes = new Schedule(this, true);
            List<LectureClass> lc;

            // place classes at random position
            if (semester == "Spring")
            {
                lc = Configuration.GetInstance.GetLectureClassesSpring();
            }
            else        
            {
                lc = Configuration.GetInstance.GetLectureClassesAutumn();
            }
            

            foreach (LectureClass it in lc)
            {

                // determine random position of class
                int num_rooms = Configuration.GetInstance.GetNumberOfRooms();
                //get duration of class
                int dur = it.GetDuration;
                Random rand = new Random(); //9bits random number
                int day = rand.Next() % DAYS_NUM; //0-4
                int room = rand.Next() % num_rooms; //0-number of rooms
                int time = rand.Next() % (DAY_HOURS + 1 - dur); //9am-5pm
                int pos = (day * num_rooms * DAY_HOURS) + (room * DAY_HOURS + time); // (Base) + (offset) time's
                int week = WEEK;
                // fill time-space slots, for each hour of class
                //System.Diagnostics.Debug.WriteLine(pos);
               
                for (int i = dur - 1; i >= 0; i--)
                {
                    newGenes._slots[pos + i].Add(it);
                }
                //System.Diagnostics.Debug.WriteLine(dur.ToString());
                // fill classes to the _classess
                newGenes._classes.Add(it, pos);                              
            }

            newGenes.CalculateFitness();

            // return smart pointer
            return newGenes;
        }

        public Schedule Crossover(Schedule otherParent)
        {
            Random rand = new Random();

            // check probability of crossover operation
            if (rand.Next() % 100 > _crossoverRate)
                // no crossover, just copy first parent
                return new Schedule(this, false);

            // new chromosome object, copy chromosome setup
            Schedule child = new Schedule(this, true);

            // number of classes

            bool[] cp = new bool[_classes.Count];

            // determine crossover point (randomly)
            for (int i = _numberOfCrossoverPoints; i > 1; i--)
            {
                while (true)
                {
                    int p = rand.Next() % _classes.Count;
                    if (cp[p] == false)
                    {
                        cp[p] = true;
                        break;
                    }
                }
            }

            //Dictionary<CourseClass, int> it1 = _classes;
            List<KeyValuePair<LectureClass, int>> it1 = _classes.ToList<KeyValuePair<LectureClass, int>>();
            List<KeyValuePair<LectureClass, int>> it2 = otherParent._classes.ToList<KeyValuePair<LectureClass, int>>();

            // make new code by combining parent codes
            bool first = (rand.Next() % 2 == 0);
            //
            for (int i = 0; i < _classes.Count; i++)
            {
                if (first)
                {
                    // insert class from first parent into new DNA's class table
                    child._classes.Add(it1[i].Key, it1[i].Value);
                    // all time-space slots of class are copied
                    for (int j = it1[i].Key.GetDuration - 1; j >= 0; j--)
                        child._slots[it1[i].Value + j].Add(it1[i].Key);
                }
                else
                {
                    // insert class from second parent into new DNA's class table
                    child._classes.Add(it2[i].Key, it2[i].Value);
                    // all time-space slots of class are copied
                    for (int j = it2[i].Key.GetDuration - 1; j >= 0; j--)
                        child._slots[it2[i].Value + j].Add(it2[i].Key);
                }

                // crossover point
                if (cp[i])
                    // change source chromosome
                    first = !first;
            }

            child.CalculateFitness();

            // return smart pointer to offspring
            return child;
        }

        public void Mutation()
        {
            Random rand = new Random();

            // check probability of mutation operation
            if (rand.Next() % 100 > _mutationRate)
                // will not do mutation
                return;

            // number of classes
            int numberOfClasses = _classes.Count;
            // number of time-space slots
            int size = _slots.Length;

            // move selected number of classes at random position
            for (int i = _mutationSize; i > 0; i--)
            {
                // select random chromosome for movement
                int mpos = rand.Next() % numberOfClasses;
                int pos1 = 0;
                KeyValuePair<LectureClass, int> it = _classes.ToList<KeyValuePair<LectureClass, int>>()[mpos];

                // current time-space slot used by class
                pos1 = it.Value;

                LectureClass lc1 = it.Key;

                // determine position of class randomly
                int nr = Configuration.GetInstance.GetNumberOfRooms();
                int dur = lc1.GetDuration;
                int day = rand.Next() % DAYS_NUM;
                int room = rand.Next() % nr;
                int time = rand.Next() % (DAY_HOURS + 1 - dur);
                int pos2 = day * nr * DAY_HOURS + room * DAY_HOURS + time;

                // move all time-space slots
                for (int j = dur - 1; j >= 0; j--)
                {
                    // remove class hour from current time-space slot
                    List<LectureClass> cl = _slots[pos1 + j];
                    foreach (LectureClass It in cl)
                    {
                        if (It == lc1)
                        {
                            cl.Remove(It);
                            break;
                        }
                    }

                    // move class hour to new time-space slot
                    _slots[pos2 + j].Add(lc1);
                }

                // change entry of class table to point to new time-space slots
                _classes[lc1] = pos2;
            }
        }

        public void CalculateFitness()
        {
            int score = 0;

            int numberOfRooms = Configuration.GetInstance.GetNumberOfRooms();
            int daySize = DAY_HOURS * numberOfRooms;
            int[][] timeCountMorning = new int[DAYS_NUM][];
            int[][] timeCountAfternoon = new int[DAYS_NUM][];
            for (int i = 0; i < DAYS_NUM; i++)
            {
                timeCountMorning[i] = new int[Configuration.GetInstance.GetNumberOfStudentGroups()];
                timeCountAfternoon[i] = new int[Configuration.GetInstance.GetNumberOfStudentGroups()];
            }

            #region rule
            int ci = 0;
            #endregion
            // check criteria and calculate scores for each class in schedule
            foreach (KeyValuePair<LectureClass, int> it in _classes.ToList())
            {                                           //_classes.ToList<KeyValuePair<CourseClass, int>>())
                // coordinate of time-space slot
                int pos = it.Value; // int pos of _slot array
                int day = pos / daySize;
                int time = pos % daySize; // this is not time now!
                int room = time / DAY_HOURS;
                time = time % DAY_HOURS;  // this is a time now!

                int dur = it.Key.GetDuration;
                foreach (var gs in it.Key.GetGroups)
                {
                    for (int j = dur - 1; j >= 0; j--)
                    {
                        if (time + j <= 3) //4slots
                        {
                            timeCountMorning[day][gs.GetId-1]++;//need atleast3
                        }
                        else
                        {
                            timeCountAfternoon[day][gs.GetId-1]++; //if top didnt fulfill dont fill to the afternoon
                        }
                    }
                }

                

                LectureClass cc = it.Key;
                Room r = Configuration.GetInstance.GetRoomById(room);
                #region Score 1 and Score 2 (check for room overlapping of classes and room overlapping of classes with same ID)  [+3] [+3]

                 // check for room overlapping of classes
                 bool overlapping = false;
                 for (int i = dur - 1; i >= 0; i--)
                 {
                     if (_slots[pos + i].Count > 1)
                     {
                         overlapping = true;
                         break;
                     }
                 }

                 // on room overlapping
                 if (!overlapping)
                     score += 3;

                 _criteria[ci + 0] = !overlapping;
                
                _criteria[ci + 1] = true;
                 foreach (KeyValuePair<LectureClass, int> it3 in _classes.ToList())
                 {
                      LectureClass cc2 = it3.Key;
                      int pos2 = it3.Value;
                      int time2 = pos2 % daySize; // this is not time now!
                      int room2 = time2 / DAY_HOURS;
                      //System.Diagnostics.Debug.WriteLine(r.Origin_ID_inDB);
                      if (cc.Class_ID == cc2.Class_ID)
                      {
                        if (cc.Lab == cc2.Lab)
                        {
                            if (r.Origin_ID_inDB != Configuration.GetInstance.GetRoomById(room2).Origin_ID_inDB)
                               _criteria[ci + 1] = false;
                        }
                            
                         break;
                      }
                 }

                if (_criteria[ci + 1])
                {
                    score += 3;
                }


                #endregion


                // check for room with same id must overlap
                #region Score 3 (does current room have enough seats and room must fit around 75%)  [+4][+4]
                // does current room have enough seats
                if (r.GetNumberOfSeats >= cc.GetNumberOfSeats)
                {
                    if (Convert.ToDouble(cc.GetNumberOfSeats)/Convert.ToDouble(r.GetNumberOfSeats) >= 0.75 && Convert.ToDouble(cc.GetNumberOfSeats) / Convert.ToDouble(r.GetNumberOfSeats) <=1)
                    {
                        _criteria[ci + 2] = true;
                    }
                }
                
                if (_criteria[ci + 2])
                {
                    score += 8;
                }

                #endregion

                #region Score 4 and 5 (check overlapping of classes for Lecturers and student groups)  [+4][+4]

                bool lec = false, gro = false;
                // check overlapping of classes for lecturers and student groups
                for (int i = numberOfRooms, t = (day * daySize + time); i > 0; i--, t += DAY_HOURS)
                {
                    // for each hour of class
                    for (int j = dur - 1; j >= 0; j--)
                    {
                        // check for overlapping with other classes at same time
                        List<LectureClass> cl = _slots[t + j];
                        foreach (LectureClass it_cc in cl)
                        {
                            if (cc != it_cc)
                            {
                                // lecturer overlaps?
                                if (!lec && cc.LecturerOverlaps(it_cc))
                                    lec = true;

                                // student group overlaps?
                                if (!gro && cc.GroupsOverlap(it_cc))
                                    gro = true;

                                // both type of overlapping? no need to check more
                                if (lec && gro)
                                    goto total_overlap;
                            }

                        }
                    }
                }

            total_overlap:

                // professors have no overlapping classes?
                if (!lec)
                {
                    score += 4;
                    _criteria[ci + 3] = !lec;
                }



                // student groups has no overlapping classes?
                if (!gro)
                {
                    score += 4;
                    _criteria[ci + 4] = !gro;
                }



                #endregion

                #region Score 6 (check overlapping of classes ID) [+4]
                _criteria[ci + 5] = true;

                foreach (KeyValuePair<LectureClass, int> it3 in _classes.ToList())
                {
                    int pos2 = it3.Value; // int pos of _slot array
                    int day2 = pos2 / daySize;
                    //System.Diagnostics.Debug.WriteLine(day2 + day2.ToString());
                    LectureClass cc2 = it3.Key;
                    if (day == day2)
                    {
                        if (cc.Class_ID == cc2.Class_ID && cc.Class_Order != cc2.Class_Order)
                        {
                            _criteria[ci + 5] = false;
                            break;
                        }
                    }
                }

                if (_criteria[ci + 5])
                {
                    score += 4;
                }


                #endregion

                #region Score 7 (check this class time by module prefered time) [+16]
                _criteria[ci + 6] = true;
                for (int i = 0; i < dur; i++)
                {
                    if (!cc.GetSchedule[time + i, day + 1])
                    {
                        _criteria[ci + 6] = false;
                        break;
                    }
                }

                if (_criteria[ci + 6])
                {
                    score += 16;
                }


                
                    

                #endregion

                #region Score 8 (does current room have computers if they are required)  [+8]
                // does current room have computers if they are required
                _criteria[ci + 7] = (cc.Lab == r.GetLab) ? true : false;
                if (_criteria[ci + 7])
                {
                    score += 8;
                }


                #endregion

                ci += numberOfScores;
            }

            #region score 9 (Optimization) [+10]
            _criteria2 = true;
            for(int gs = 1; gs <= Configuration.GetInstance.GetNumberOfStudentGroups(); gs++)
            {
                for (int day = 0; day < 5; day++)
                {
                    if (timeCountMorning[day][gs-1] < 2 && timeCountAfternoon[day][gs-1] >= 1)
                    {
                        _criteria2 = false;
                        break;
                    }
                }
            }

            if(_criteria2)
            {
                score += (10 * _classes.Count);
            }
            #endregion
            if (SettingsForm.SemesterKey == "Spring" && AlgorithmForm.semester == 0)
            {
                _fitness = (float)score / (Configuration.GetInstance.GetNumberOfLectureClassesSpring() * numberOfScores);
            }
            else if (SettingsForm.SemesterKey == "Autumn" && AlgorithmForm.semester == 0)
            {
                _fitness = (float)score / (Configuration.GetInstance.GetNumberOfLectureClassesAutumn() * numberOfScores);
            }
            else if (SettingsForm.SemesterKey == "Spring and Autumn" && AlgorithmForm.semester == 0)
            {
                _fitness = (float)score / (Configuration.GetInstance.GetNumberOfLectureClassesSpring() * numberOfScores);
            }
            else if (SettingsForm.SemesterKey == "Spring and Autumn" && AlgorithmForm.semester == 1)
            {
                _fitness = (float)score / (Configuration.GetInstance.GetNumberOfLectureClassesAutumn() * numberOfScores);
            }
        }

        public float GetFitness() { return _fitness; }
        // Returns reference to table of classes
        public Dictionary<LectureClass, int> GetClasses() { return _classes; }

        // Return reference to array of time-space slots
        public List<LectureClass>[] GetSlots() { return _slots; }


    }
}
