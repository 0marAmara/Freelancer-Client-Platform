using FreelancerClientPlatform.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace FreelancerClientPlatform.Views.Client
{
    public partial class CompletedProjectsWindow : Window
    {
        public ObservableCollection<CompletedProjectView> CompletedProjects { get; set; }
        public ObservableCollection<Project> Projects { get; set; }

        public CompletedProjectsWindow()
        {
            InitializeComponent();
            CompletedProjects = new ObservableCollection<CompletedProjectView>();
            LoadCompletedProjects();
        }
        private void LoadCompletedProjects()
        {
            foreach (var item in App.projects)
            {
                if(App.signedInUser is Models.Freelancer)
                {
                    if (item.status == 2&&item.assignedFreelancer.username==App.signedInUser.username)
                        CompletedProjects.Add(new CompletedProjectView(item));
                }
                else
                {
                    if (item.status == 2)
                        CompletedProjects.Add(new CompletedProjectView(item));
                }
            }
            completedProjectsListView.ItemsSource = CompletedProjects;

        }

        private void ViewReviews_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.CommandParameter is CompletedProjectView selectedProject)
            {
                ProjectReviewsWindow projectReviewsWindow = new ProjectReviewsWindow(selectedProject.ProjectObj);

                projectReviewsWindow.ShowDialog();
            }
        }

    }

    public class CompletedProjectView
    {

        public string assignedFreelancer { get; set; }
        public List<Review> reviews { get; set; }
        public Project ProjectObj { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string timeline { get; set; }
        public double budget { get; set; }
        public CompletedProjectView(Project project)
        {

            this.assignedFreelancer = project.assignedFreelancer.username;
            this.reviews = project.reviews;
            this.name = project.name;
            this.description = project.description;
            this.timeline = project.timeline;
            this.budget = project.budget;
            this.ProjectObj = project;
        }
    }
}
