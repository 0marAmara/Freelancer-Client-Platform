using FreelancerClientPlatform.Models;
using System.Windows;

namespace FreelancerClientPlatform
{
    public partial class App : Application
    {
        public static List<User> users = new List<User>();
        public static List<Project> projects = new List<Project>();
        public static User? signedInUser = null;
        public static bool addNewUser(User user)
        {
            User foundUser = users.Find(curUser => curUser.username == user.username);
            if (foundUser != null)
            {
                return false;
            }
            users.Add(user);
            return true;
        }
        public static void addNewProject(Project project) { 
            projects.Add(project);
        }
    }

}
