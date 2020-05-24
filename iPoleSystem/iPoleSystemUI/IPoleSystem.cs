using iPoleSystemLibrary;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPoleSystemLibrary
{
    public class IPoleSystem : IIPoleSystem
    {
        // Lists are begin created for all users, all teams and checkboxes.
        public static List<User> AllUsers = new List<User>();
        public static List<FitnessClass> AllTeams = new List<FitnessClass>();
        public static List<CheckBox> CheckBoxes = new List<CheckBox>();

        public IPoleSystem()
        {
        }

        // This method adds users to the user list. First, a path is created to the
        // .csv file containing the users. Secondly, it seperates the strings and then 
        // it assigns the different strings to appropriate values and converts them if needed.
        // Lastly, it adds all the users and their information to the user list.
        public void CreateUserList()
        {
            var path = Directory.GetCurrentDirectory() + @"\Bruger.csv";
            using (TextFieldParser csvParser = new TextFieldParser(path))
            {
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = false;

                while (!csvParser.EndOfData)
                {
                    int i = 0;
                    string[] fields = csvParser.ReadFields();
                    string id = fields[0];
                    string firstname = fields[1];
                    string lastname = fields[2];
                    string password = fields[3];
                    Int32.TryParse(id, out int memberId);

                    int[] enrolledClasses = new int[fields.Length - 4];

                    for (i = 4; i < fields.Length; i++)
                    {
                        string classID = fields[i];
                        Int32.TryParse(classID, out int enrolledClass);
                        enrolledClasses[i-4] = enrolledClass;
                    }
                    AllUsers.Add(new User(firstname, lastname, memberId, password, false, enrolledClasses));
                }
            }
        }

        // This method does the same as the previous method, except it does it for
        // the classes which are in classes.csv.
        public void CreateTeamList()
        {
            var path = Directory.GetCurrentDirectory() + @"\classes.csv";
            using (TextFieldParser csvParser = new TextFieldParser(path))
            {
                int i = 0;
                csvParser.SetDelimiters(new string[] { ";" });
                csvParser.HasFieldsEnclosedInQuotes = false;

                while (!csvParser.EndOfData)
                {
                    string[] fields = csvParser.ReadFields();
                    string classIDString = fields[0];
                    Int32.TryParse(classIDString, out int classID);
                    string teamtitle = fields[1];
                    string participantString = fields[2];
                    Int32.TryParse(participantString, out int numberofParticipants);
                    string time = fields[3];
                    string date = fields[4];
                    string roomString = fields[5];
                    Int32.TryParse(roomString, out int room);
                    string instructor = fields[6];

                    int[] participantsEnrolled = new int[fields.Length - 7];

                    for (i = 7; i < fields.Length; i++)
                    {
                        string participant = fields[i];
                        Int32.TryParse(participant, out int particpantEnrolled);
                        participantsEnrolled[i-7] = particpantEnrolled;
                    }
                    AllTeams.Add(new FitnessClass(classID, teamtitle, numberofParticipants, time, date, room, instructor, participantsEnrolled));
                }
            }
        }

        // This method creates the checkboxes the users have to use in order to choose the different classes.
        public void CreateCheckboxes(bool MyBookingsToday)
        {
            List<FitnessClass> classesToBeShown = new List<FitnessClass>();
            CreateListOfClassesToBeShown(classesToBeShown, MyBookingsToday);

            int i = 0;
            foreach (FitnessClass fclass in classesToBeShown)
            {
                CheckBox dynamicCheckBox = new CheckBox();
                dynamicCheckBox.Left = 295;
                dynamicCheckBox.Top = 170 + (i * 40);
                dynamicCheckBox.Width = 76;
                dynamicCheckBox.Height = 17;

                dynamicCheckBox.Text = fclass.Title;
                dynamicCheckBox.Name = "DynamicCheckBox";
                dynamicCheckBox.Font = new Font("Microsoft Sans Serif", 8);
                CheckBoxes.Add(dynamicCheckBox);
                i++;
            }
        }

        // This method creates a list of classes to be shown on MyBookingsToday and MyFutureBookings
        // based on whether the specific list is to be shown on MyBookingsToday or MyFutureBookings and
        // if it the class is on the current day or not.
        public List<FitnessClass> CreateListOfClassesToBeShown(List<FitnessClass> classesToBeShown, bool MyBookingsToday)
        {
            User currentUser = FindUserFromLoginStatus();
            DateTime dateTimeNow = DateTime.Now;
            int dateNow = dateTimeNow.Day;
            string dateNowString = dateNow.ToString();
            
            foreach (int temp in currentUser.EnrolledClassIDs)
            {
                classesToBeShown.Add(FindClassFromID(temp));
                if (MyBookingsToday && (FindClassFromID(temp).Date != dateNowString))
                {
                    classesToBeShown.Remove(FindClassFromID(temp));
                }
            }
            return classesToBeShown;
        }

        // This method finds and returns the user whose member ID equals the desired ID.
        public User FindUserFromID(int userID)
        {
            try
            {
                User found = AllUsers.Find(u => u.MemberId == userID);
                return found;
            }
            catch
            {
                throw new ArgumentException("User could not be found from userID");
            }
        }

        // This method finds and return the user whose LoginStatus is true.
        public User FindUserFromLoginStatus()
        {
            try
            {
                User found = AllUsers.Find(u => u.LoginStatus == true);
                return found;
            }
            catch
            {
                throw new ArgumentException("User could not be found based on login status");
            }
        }

        // This method finds and returns the class with the desired ID.
        public FitnessClass FindClassFromID(int classID)
        {
            try
            {
                FitnessClass found = AllTeams.Find(c => c.ClassID == classID);
                return found;
            }
            catch
            {
                throw new ArgumentException("Class could not be found from classID");
            }
        }

        // This method turns a string list into at FitnessClass list.
        public List<FitnessClass> FindClassFromStringList(List<string> stringList)
        {
            try
            {
                List<FitnessClass> fitnessClassList = new List<FitnessClass>();
                foreach(string s in stringList)
                {
                    FitnessClass found = AllTeams.Find(t => t.Title == s);
                    fitnessClassList.Add(found);
                }
                return fitnessClassList;
            }
            catch
            {
                throw new ArgumentException("Class could not be found from string list");
            }
        }

        // This method assigns the current date and time, finds all lines in OpenGym.csv
        // and deletes the lines where the date does not equal the current date.
        public void DeleteUnnecessaryStringsFromOpenGym()
        {
            DateTime dateAndTimeNow = DateTime.Now;
            int dateNow = dateAndTimeNow.Day;
            List<string> lines = new List<string>();
            using(StreamReader reader=new StreamReader("OpenGym.csv"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains(","))
                    {
                        string[] fields = line.Split(',');

                        string id = fields[0];
                        Int32.TryParse(id, out int memberID);
                        string dateTimeString = fields[1];
                        DateTime.TryParse(dateTimeString, out DateTime dateTimeFile);

                        if (dateTimeFile.Day == dateNow)
                        {
                            line = string.Join("", id, ',', dateTimeString);
                            lines.Add(line);
                        }
                        if(dateTimeFile.Day != dateNow)
                        {
                        }
                    }
                }
            }
            using(StreamWriter writer=new StreamWriter("OpenGym.csv"))
            {
                foreach(string line in lines)
                {
                    writer.WriteLine(line);
                }
            }
        }

        // This method writes in AttendLog.csv the member ID of who attended a class, 
        // the class ID of the class attended and when it was attended.
        public void WriteInAttendLog(List<FitnessClass> classList)
        {
            User currentUser = FindUserFromLoginStatus();
            DateTime dateTimeNow = DateTime.Now;

            using (StreamWriter SW = File.AppendText("AttendLog.csv"))
            {
                foreach(FitnessClass classAttended in classList)
                {
                    SW.WriteLine("Member: " + currentUser.MemberId + " attended class " + classAttended.ClassID + " at " + dateTimeNow);
                }
            }
        }

        // This method removes the user ID of the user who attended a class,
        // from the classes.csv file.
        public void RemoveUserIDFromClassFile(FitnessClass classAttended)
        {
            List<string> lines = new List<string>();
            string line;
            User currentUser = FindUserFromLoginStatus();

            var path = Directory.GetCurrentDirectory() + @"\classes.csv";
            using (TextFieldParser csvParser = new TextFieldParser(path))
            {
                int i = 0;
                csvParser.SetDelimiters(new string[] { ";" });
                csvParser.HasFieldsEnclosedInQuotes = false;

                while (!csvParser.EndOfData)
                {
                    string[] fields = csvParser.ReadFields();
                    string classIDString = fields[0];
                    Int32.TryParse(classIDString, out int classID);
                    string teamtitle = fields[1];
                    string participantString = fields[2];
                    Int32.TryParse(participantString, out int numberofParticipants);
                    string time = fields[3];
                    string date = fields[4];
                    string roomString = fields[5];
                    Int32.TryParse(roomString, out int room);
                    string instructor = fields[6];

                    int[] participantsEnrolled = new int[fields.Length - 7];
                    string participantsClassesString = "";

                    for (i = 7; i < fields.Length; i++)
                    {
                        string participant = fields[i];
                        Int32.TryParse(participant, out int particpantEnrolled);

                        if (currentUser.MemberId != particpantEnrolled)
                        {
                            participantsEnrolled[i - 7] = particpantEnrolled;
                            participantsClassesString += ";" + particpantEnrolled;
                        }
                        else if (currentUser.MemberId == particpantEnrolled && classAttended.ClassID != classID)
                        {
                            participantsEnrolled[i - 7] = particpantEnrolled;
                            participantsClassesString += ";" + particpantEnrolled;
                        }
                        else if (currentUser.MemberId == particpantEnrolled && classAttended.ClassID == classID)
                        {
                            participantsClassesString += "";
                        }
                    }
                    line = string.Join("", classID, ';', teamtitle, ';', numberofParticipants, ';', time, ';', date, ';', room, ';', instructor, participantsClassesString);
                    lines.Add(line);
                }
            }

            using (StreamWriter SW = new StreamWriter("classes.csv"))
            {
                foreach (string l in lines)
                {
                    SW.WriteLine(l);
                }
            }
        }

        // This method removes the class ID of the class a user attended,
        // from the Bruger.csv file.
        public void RemoveClassIDFromUserFile(FitnessClass classAttended)
        {
            List<string> lines = new List<string>();
            string line;
            User currentUser = FindUserFromLoginStatus();

            var path = Directory.GetCurrentDirectory() + @"\Bruger.csv";
            using (TextFieldParser csvParser = new TextFieldParser(path))
            {
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = false;

                while (!csvParser.EndOfData)
                {
                    int i = 0;
                    string[] fields = csvParser.ReadFields();
                    string id = fields[0];
                    string firstname = fields[1];
                    string lastname = fields[2];
                    string password = fields[3];
                    Int32.TryParse(id, out int memberId);

                    int[] enrolledClasses = new int[fields.Length - 4];
                    string enrolledClassesString = "";

                    for (i = 4; i < fields.Length; i++)
                    {
                        string classID = fields[i];
                        Int32.TryParse(classID, out int enrolledClass);

                            if (currentUser.MemberId != memberId)
                            {
                                enrolledClasses[i - 4] = enrolledClass;
                                enrolledClassesString += "," + enrolledClass;
                            }
                            else if (currentUser.MemberId == memberId && classAttended.ClassID != enrolledClass)
                            {
                            enrolledClasses[i - 4] = enrolledClass;
                            enrolledClassesString += "," + enrolledClass;
                        }
                            else if (currentUser.MemberId == memberId && classAttended.ClassID == enrolledClass)
                            {
                            enrolledClassesString += "";
                            }
                    }
                    line = string.Join("", memberId, ',', firstname, ',', lastname, ',', password, enrolledClassesString);
                    lines.Add(line);
                }
            }
            using (StreamWriter SW = new StreamWriter("Bruger.csv"))
            {
                foreach (string l in lines)
                {
                    SW.WriteLine(l);
                }
            }
        }
    }
}
