using System.Windows;
using FreelancerClientPlatform.Models;
using FreelancerClientPlatform.Views.Client;

namespace FreelancerClientPlatform.Views.Freelancer
{
    public partial class FreelancerDashboard : Window
    {
        public FreelancerDashboard()
        {
            InitializeComponent();
            UsernameField.Text = App.signedInUser.username;
        }

        private void BrowseProjects_Click(object sender, RoutedEventArgs e)
        {
            BrowseProjectsWindow browseProjectsWindow = new BrowseProjectsWindow();
            browseProjectsWindow.Show();
        }

        private void ManageProjects_Click(object sender, RoutedEventArgs e)
        {
            ManageProjectsWindow manageProjectsWindow = new ManageProjectsWindow();
            manageProjectsWindow.Show();
        }

        private void ViewCompletedProjects_Click(object sender, RoutedEventArgs e)
        {
            CompletedProjectsWindow completedProjectsWindow = new CompletedProjectsWindow();
            completedProjectsWindow.Show();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            App.signedInUser = null;

            this.Close();
        }
    }
}
