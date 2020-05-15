using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPoleSystemLibrary
{
    public class FitnessClass
    {
        public int ClassID { get; set; }
        public string Title { get; set; }
        public int NumberOfParticipants { get; set; }
        public string Time { get; set; }
        public string Date { get; set; }
        public int Room { get; set; }
        public string Instructor { get; set; }
        public int[] EnrolledUserIDs { get; set; }

        //The constructer for FitnessClass
        public FitnessClass(int classID, string title, int numberOfParticipants, string time, string date, int room, string instructor, int[] enrolledUserIDs)
        {
            ClassID = classID;
            Title = title;
            NumberOfParticipants = numberOfParticipants;
            Time = time;
            Date = date;
            Room = room;
            Instructor = instructor;
            EnrolledUserIDs = enrolledUserIDs;
        }
    }
}
