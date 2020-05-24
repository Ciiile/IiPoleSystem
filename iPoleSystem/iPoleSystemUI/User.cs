using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPoleSystemLibrary
{
    public class User : IComparable
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int MemberId { get; set; }
        public string Password { get; set; }
        public bool LoginStatus { get; set; }
        public int[] EnrolledClassIDs { get; set; }

        public User(string firstname, string lastname, int memberId, string password, bool loginStatus, int[] enrolledClassIDs)
        {
            Firstname = firstname;
            Lastname = lastname;
            MemberId = memberId;
            Password = password;
            LoginStatus = loginStatus;
            EnrolledClassIDs = enrolledClassIDs;
        }

        // This method checks if the object is of the type User.
        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            User otherUser = obj as User;

            if (otherUser == null)
            {
                return this.MemberId.CompareTo(otherUser.MemberId);
            }
            else
            {
                throw new ArgumentException("Object is not a User");
            }
        }
    }
}
