using System.Windows;
using FreelancerClientPlatform.Models;

namespace FreelancerClientPlatform.Views.Client
{
    public partial class ClientDashboardWindow : Window
    {
        public ClientDashboardWindow()
        {
            InitializeComponent();
            UsernameField.Text = App.signedInUser.username;
        }

        private void ViewFreelancers_Click(object sender, RoutedEventArgs e)
        {
            ViewFreelancersWindow viewFreelancersWindow = new ViewFreelancersWindow();
            viewFreelancersWindow.Show();

        }

        private void PostNewProject_Click(object sender, RoutedEventArgs e)
        {
            NewProjectWindow newProjectWindow = new NewProjectWindow();
            newProjectWindow.ShowDialog();
        }

        private void LeaveReviews_Click(object sender, RoutedEventArgs e)
        {
            CompletedProjectsWindow completedProjectsWindow= new CompletedProjectsWindow();
            completedProjectsWindow.ShowDialog();
        }
        private void ActiveProjects_Click(object sender, RoutedEventArgs e)
        {
            ActiveProjectsWindow activeProjectsWindow = new ActiveProjectsWindow();
            activeProjectsWindow.ShowDialog();
        }
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            App.signedInUser = null;

            App.signedInUser = null;
            this.Close();

        }

    }
}
