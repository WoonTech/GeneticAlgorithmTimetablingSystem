using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace GeneticAlgorithmTimetablingSystem.Algorithm
{
    public enum AlgorithmState
    {
        AS_USER_STOPPED,
        AS_CRITERIA_STOPPED,
        AS_RUNNING,
        AS_SUSPENDED
    }
    public class Algorithm
    {
        #region Public Properties
        //
        //Number of DNA
        private int _dnaSize = 1000;
        public int DNASize
        {
            get
            {
                return _dnaSize;
            }
            set
            {
                // there should be at least 2 chromosomes in population
                if (value < 2) value = 2;
                _dnaSize = value;
            }
        }

        //
        // Number of DNA to track the best DNA
        private int _trackBest = 50;
        public int TrackBest
        {
            get { return _trackBest; }
            set
            {
                // algorithm should track at least on of best DNA
                if (value < 1) value = 1;
                //
                // track best DNA should be less than Genes size
                if (value >= TrackBest) //value = TrackBest - 1;
                //
                // set
                _trackBest = value;
            }
        }
        //
        // Number of genes which are replaced in each generation by offspring
        private int _replaceByGeneration = 180;
        public int ReplaceByGeneration
        {
            get { return _replaceByGeneration; }
            set
            {
                if (value < 1) value = 1;
                else if (value > DNASize - TrackBest)
                    value = DNASize - TrackBest;
                //
                // set
                _replaceByGeneration = value;
            }
        }
        //
        // Number of crossover points of parent's class tables
        public int NumberOfCrossoverPoints
        {
            get { return _prototype._numberOfCrossoverPoints; }
            set
            {
                if (value < 2) value = 2;
                _prototype._numberOfCrossoverPoints = value;
            }
        }

        // Number of classes that is moved randomly by single mutation operation
        public int MutationSize
        {
            get { return _prototype._mutationSize; }
            set
            {
                if (value < 2) value = 2;
                _prototype._mutationSize = value;
            }
        }

        // Probability that crossover will occur
        public int CrossoverRate
        {
            get { return _prototype._crossoverRate; }
            set
            {
                // probability is a Percent between 0 and 100
                if (value < 0) value = 0;
                else if (value > 100) value = 100;
                //
                // set
                _prototype._crossoverRate = value;
            }
        }

        // Probability that mutation will occur
        public int MutationRate
        {
            get { return _prototype._mutationRate; }
            set
            {
                // probability is a Percent between 0 and 100
                if (value < 0) value = 0;
                else if (value > 100) value = 100;
                //
                // set
                _prototype._mutationRate = value;
            }
        }
        #endregion
        #region Properties

        public Thread[] MultiThreads = null;
        public int numCore = 0; // Number of Active CPU or CPU core's for this Programs

        // object for lock or Unlock
        object Locker0 = new object(); // for Lock _state of Algorithm
        object Locker1 = new object(); // for Lock _Chromosome jobs (W/R) 
        object Locker2 = new object(); // for Lock _bestChromosome & _bestFlags job's (W)

        // Population of chromosomes// genes
        private Schedule[] _dna;
        //private Schedule_Spring[] _dnaSpring;
        // Indicates weather chromosome belongs to best chromosome group
        private bool[] _bestFlags;

        // Indices of best chromosomes
        private int[] _bestDNA;

        // Number of best chromosomes currently saved in best chromosome group
        private int _currentBestSize;

        // Pointer to algorithm observer
        //private Schedule.ScheduleObserver _observer;

        // Prototype of chromosomes in population
        public Schedule _prototype;

        // Current generation
        private int _currentGeneration;

        // State of execution of algorithm
        internal static AlgorithmState _state;

        // Pointer to global instance of algorithm
        private static Algorithm _instance;

        #endregion

        public static Algorithm GetInstance()
        {
            if (_instance == null)
            {
                // create a prototype of chromosomes/ the initial model
                Schedule prototype = new Schedule(5, 5, 90, 10);
                _instance = new Algorithm(1000, 180, 50, prototype);
            }
            return _instance;
        }

        //Free memory used by global instance
        public static void FreeInstance()
        {
            if (_instance != null)
            {
                _instance._prototype = null;
                //_instance._observer = null;
                _instance = null;
            }
        }

        //Initiate Genetic Algorithm
        public Algorithm(int dnaSize, int replaceByGeneration, int trackBest, Schedule prototype)
        {
            DNASize= dnaSize;
            TrackBest = trackBest;
            ReplaceByGeneration = replaceByGeneration;
            _currentBestSize = 0;
            _prototype = prototype;
            //_observer = observer;
            _currentGeneration = 0;
            _state = AlgorithmState.AS_USER_STOPPED;
            
            //declare genes
            _dna = new Schedule[DNASize];
            _bestFlags = new bool[DNASize];
            _bestDNA = new int[TrackBest];

            // clear population 
            for (int i = _dna.Length - 1; i >= 0; --i)
            {
                _dna[i] = null;
                _bestFlags[i] = false;
            }
            _instance = this;
        }

        ~Algorithm()
        {
            // clear population by deleting chromosomes 
            Array.Clear(_dna, 0, _dna.Length);
            _dna = null;
            MultiThreads = null;
        }

        public bool Start(string semester)
        {
            #region Start by initialize new population 
            if (_prototype == null)
                return false;

            // do not run already running algorithm
            if (_state == AlgorithmState.AS_RUNNING)
            {
                return false;
            }
            else
            {
                _state = AlgorithmState.AS_RUNNING;
            }

            //do the new chromosomes
            if (semester == "Spring")
            {
                for (int i = 0; i < _dna.Length; i++)
                {
                    if (_dna[i] != null)
                        _dna[i] = null;
                    _dna[i] = _prototype.MakeNewFromPrototype(semester);
                    AddToBest_Parallel(i);
                }
            }
            else if (semester == "Autumn")
            {
                for (int i = 0; i < _dna.Length; i++)
                {
                    if (_dna[i] != null)
                        _dna[i] = null;
                    _dna[i] = _prototype.MakeNewFromPrototype(semester);
                    AddToBest_Parallel(i);
                }
            }
                

            _currentGeneration = 0;
            Thread workingThread = new Thread(new ParameterizedThreadStart(GA_Start));
            workingThread.Start();
            #endregion
            return true;
        }
        private void GA_Start(object data)
        {
            while (true) //------------------------------------------------------------------------
            {
                // user has stopped execution?
                if (_state == AlgorithmState.AS_CRITERIA_STOPPED || _state == AlgorithmState.AS_USER_STOPPED)
                {
                    break;
                }

                Schedule best = GetBestDNA();

                if (best.GetFitness() >= 1)
                {
                    _state = AlgorithmState.AS_CRITERIA_STOPPED;
                    break;
                }
                Schedule[] child;
                child = new Schedule[_replaceByGeneration]; //_replaceByGeneration is the count of population
                Random rand = new Random();
                for (int j = 0; j < _replaceByGeneration; j++)
                {
                    Schedule p1; //parent 1 
                    Schedule p2; // parent 2
                    p1 = _dna[(rand.Next() % _dna.Length)].MakeCopy(false); //choose parent from the population
                    p2 = _dna[(rand.Next() % _dna.Length)].MakeCopy(false);
                    child[j] = p1.Crossover(p2);
                    child[j].Mutation();
                    child[j].CalculateFitness();
                }

                for (int j = 0; j < _replaceByGeneration; j++)
                {
                    int ci;
                    do
                    {
                        ci = rand.Next() % _dna.Length;
                    } while (IsInBest(ci));
                    _dna[ci] = null;
                    _dna[ci] = child[j];
                    AddToBest_Parallel(ci);
                }

                _currentGeneration++;

            }
        }
        public void Stop()
        {
            if (_state == AlgorithmState.AS_RUNNING)
            {
                _state = AlgorithmState.AS_USER_STOPPED;

            }
        }

        public Schedule GetBestDNA()
        {
            return _dna[_bestDNA[0]];
        }

        
        public float GetFitness()
        {
            Schedule best1 = GetBestDNA();
            return best1.GetFitness();
        }
        private bool IsInBest(int chromosomeIndex)
        {
            return _bestFlags[chromosomeIndex];
        }

        private void AddToBest_Parallel(int chromosomeIndex)
        {
            lock (Locker1)
            {
                if ((_currentBestSize == _bestDNA.Length &&
                    _dna[_bestDNA[_currentBestSize - 1]].GetFitness() >=
                    _dna[chromosomeIndex].GetFitness()) || _bestFlags[chromosomeIndex])
                    return;
            }

            //    { ... });
            int i = _currentBestSize;
            for (; i > 0; i--)
            {
                if (i < _bestDNA.Length)
                {
                    Monitor.Enter(Locker1);
                    if (_dna[_bestDNA[i - 1]].GetFitness() >
                        _dna[chromosomeIndex].GetFitness())
                    {
                        Monitor.Exit(Locker1);
                        break;
                    }
                    Monitor.Exit(Locker1);
                    lock (Locker2)
                    {
                        _bestDNA[i] = _bestDNA[i - 1];
                    }
                }
                else
                    lock (Locker2)
                    {
                        _bestFlags[_bestDNA[i - 1]] = false;
                    }
            }

            lock (Locker2)
            {
                _bestDNA[i] = chromosomeIndex;
                _bestFlags[chromosomeIndex] = true;
            }

            if (_currentBestSize < _bestDNA.Length)
                _currentBestSize++;
        }
        public int GetCurrentGeneration() { return _currentGeneration; }
    }


        
}
             