using System.Collections.Generic;

namespace iPoleSystemLibrary
{
    public interface IIPoleSystem
    {
        void CreateUserList();
        void CreateTeamList();
        void CreateCheckboxes();
        List<FitnessClass> CreateListOfClassesToBeShown(List<FitnessClass> classesToBeShown);
        User FindUserFromID(int userID);
        User FindUserFromLoginStatus();
        FitnessClass FindClassFromID(int classID);
        void DeleteUnnecessaryStringsFromOpenGym();
    }
}