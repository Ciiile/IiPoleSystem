using System.Collections.Generic;

namespace iPoleSystemLibrary
{
    public interface IIPoleSystem
    {
        void CreateUserList();
        void CreateTeamList();
        void CreateCheckboxes(bool MyBookingsToday);
        List<FitnessClass> CreateListOfClassesToBeShown(List<FitnessClass> classesToBeShown, bool MyBookingsToday);
        User FindUserFromID(int userID);
        User FindUserFromLoginStatus();
        FitnessClass FindClassFromID(int classID);
        List<FitnessClass> FindClassFromStringList(List<string> stringList);
        void DeleteUnnecessaryStringsFromOpenGym();
        void WriteInAttendLog(List<FitnessClass> classList);
        void RemoveUserIDFromClassFile(FitnessClass classAttended);
        void RemoveClassIDFromUserFile(FitnessClass classAttended);
    }
}