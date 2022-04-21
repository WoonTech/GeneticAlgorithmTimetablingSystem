using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmTimetablingSystem.Algorithm
{
    public class Room
    {
        static int _nextRoomId = 0;

        #region Properties

        // Room ID - automatically assigned
        private int _id;
        public int GetId { get { return _id; } }

        // Room Name
        private string _name;
        public string GetName { get { return _name; } }

        // Inidicates if room has specific
        private string _lab = "false";
        public string GetLab { get { return _lab; } }

        // Number of seats in room
        private int _numberOfSeats;
        public int GetNumberOfSeats { get { return _numberOfSeats; } }

        public int Origin_ID_inDB;
        #endregion
        public Room(int Original_Id, string name, string lab, int numberOfSeats)
        {
            _id = _nextRoomId++;
            _name = name;
            _lab = lab;
            _numberOfSeats = numberOfSeats;
            Origin_ID_inDB = Original_Id;
        }
        public static void RestartIDs() { _nextRoomId = 0; }
    }
}
