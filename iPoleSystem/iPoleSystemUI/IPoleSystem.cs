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
        //Lists are begin created for all users, all teams and checkboxes
        public static List<User> AllUsers = new List<User>();
        public static List<FitnessClass> AllTeams = new List<FitnessClass>();
        public static List<CheckBox> CheckBoxes = new List<CheckBox>();

        public IPoleSystem()
        {
        }

        //This method adds users to the user list. First, a path is created to the
        //.csv file containing the users. Secondly, it seperates the strings and then 
        //it assigns the different strings to appropriate values and converts them if needed.
        //Lastly, it adds all the users and their information to the user list.
        public void CreateUserList()
        {
            var path = Directory.GetCurrentDirectory() + @"\Bruger.csv";
            using (TextFieldParser csvParser = new TextFieldParser(path))
            {
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = false;

                csvParser.ReadLine();

                while (!csvParser.EndOfData)
                {
                    int i = 0,
                        j = 0;
                    string[] fields = csvParser.ReadFields();
                    string id = fields[0];
                    string firstname = fields[1];
                    string lastname = fields[2];
                    string password = fields[3];

                    Int32.TryParse(id, out int memberId);

                    int[] enrolledClasses = new int[fields.Length - 3];

                    for (i = 4; string.IsNullOrEmpty(fields[i]); i++)
                    {
                        string classID = fields[i];
                        Int32.TryParse(classID, out int enrolledClass);
                        enrolledClasses[j] = enrolledClass;
                        j++;
                    }

                    AllUsers.Add(new User(firstname, lastname, memberId, password, false, enrolledClasses));

                }
            }
        }

        //This method does the same as the previous method, except it does it for
        //the classes which are in classes.csv
        public void CreateTeamList()
        {
            var path = Directory.GetCurrentDirectory() + @"\classes.csv";
            using (TextFieldParser csvParser = new TextFieldParser(path))
            {
                int i = 0,
                    j = 0;
                csvParser.SetDelimiters(new string[] { ";" });
                csvParser.HasFieldsEnclosedInQuotes = false;
                

                csvParser.ReadLine();

                while (!csvParser.EndOfData)
                {
                    string[] fields = csvParser.ReadFields();
                    string classIDString = fields[0];
                    Int32.TryParse(classIDString, out int classID);
                    string teamtitle = fields[0];
                    string participantString = fields[1];
                    Int32.TryParse(participantString, out int numberofParticipants);
                    string time = fields[2];
                    string date = fields[3];
                    string roomString = fields[4];
                    Int32.TryParse(roomString, out int room);
                    string instructor = fields[5];

                    int[] participantsEnrolled = new int[fields.Length - 5];

                    for (i = 6; string.IsNullOrEmpty(fields[i]); i++)
                    {
                        string participant = fields[i];
                        Int32.TryParse(participant, out int particpantEnrolled);
                        participantsEnrolled[j] = particpantEnrolled;
                        j++;
                    }

                    AllTeams.Add(new FitnessClass(classID, teamtitle, numberofParticipants, time, date, room, instructor, participantsEnrolled));
                }
            }
        }

        //
        public void CreateCheckboxes()
        {
            List<FitnessClass> classesToBeShown = new List<FitnessClass>();
            CreateListOfClassesToBeShown(classesToBeShown);

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

        //Vent med at skriv om den, til vi har løst exceptions
        public List<FitnessClass> CreateListOfClassesToBeShown(List<FitnessClass> classesToBeShown)
        {
            User currentUser = FindUserFromLoginStatus();
            
            foreach (int temp in currentUser.EnrolledClassIDs)
            {
                classesToBeShown.Add(FindClassFromID(temp));
            }

            return classesToBeShown;
        }

        //This method finds and returns the user whose member ID equals the desired ID
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

        //This method finds and return the user whose LoginStatus is true.
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

        //This method finds and returns the class with the desired ID
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

        //This method assigns the current date and time, finds all lines in OpenGym.csv
        //and deletes the lines where the date does not equal the current date.
        public void DeleteUnnecessaryStringsFromOpenGym()
        {

            DateTime dateAndTimeNow = DateTime.Now;
            int dateNow = dateAndTimeNow.Day;
            //string dateNowString = dateNow.ToString();

            //var file = Directory.GetCurrentDirectory() + @"\OpenGym.csv";
            //using (TextFieldParser csvParser = new TextFieldParser(file))
            //{
                

            //        //memberIDList.Add(memberID);
            //        //dateTimeList.Add(dateTimeFile);
            //}

                


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
                            //line = string.Join(id, ",", dateTimeString);
                            //lines.Remove(line);
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
                

                //while ((line = csvParser.ReadLine()) != null)
                //{
                //    lines.Add(line);
                //}
                //lines.RemoveAll(l => !(l.Contains(dateNowString)));
            
        }
    }
}
