using FreelancerClientPlatform.Models;
using System.Collections.ObjectModel;
using System.Windows;

namespace FreelancerClientPlatform.Views.Client
{
    public partial class ActiveProjectsWindow : Window
    {
        public ObservableCollection<AssignedProject> AssignedProjects { get; set; }
        public ObservableCollection<NonAssignedProject> NonAssignedProjects { get; set; }

        public ActiveProjectsWindow()
        {
            InitializeComponent();
            AssignedProjects = new ObservableCollection<AssignedProject>();
            NonAssignedProjects = new ObservableCollection<NonAssignedProject>();
            LoadProjects();
            this.DataContext = this;
        }

        private void LoadProjects()
        {
            var assignedProjects = App.projects.Where(p => p.status == 1&&p.creator.username==App.signedInUser.username).Select(p => new AssignedProject(p)).ToList();
            foreach (var project in assignedProjects)
            {
                AssignedProjects.Add(project);
            }
            assignedProjectsListView.ItemsSource = AssignedProjects;

            var nonAssignedProjects = App.projects.Where(p => p.status == 0 && p.creator.username == App.signedInUser.username).Select(p => new NonAssignedProject(p)).ToList();
            foreach (var project in nonAssignedProjects)
            {
                NonAssignedProjects.Add(project);
            }
            nonAssignedProjectsListView.ItemsSource = NonAssignedProjects;
        }

        private void ReviewProposalsForProject_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement element && element.DataContext is NonAssignedProject selectedProject)
            {
                ViewProposalsWindow viewProposalsWindow = new ViewProposalsWindow(selectedProject.ProjectObj);
                Close();
                viewProposalsWindow.ShowDialog();
            }
        }

        public class AssignedProject
        {
            public string name { get; set; }
            public string freelancerName { get; set; }
            public string description { get; set; }
            public string timeline { get; set; }
            public string email { get; set; }
            public string phone { get; set; }
            public string username { get; set; }
            public double budget { get; set; }
            public Project projectObj { get; set; }
            public AssignedProject(Project project)
            {
                this.name = project.name;
                this.timeline = project.timeline;
                this.description = project.description;
                this.budget = project.budget;
                this.freelancerName = project.assignedFreelancer.username;
                this.username = project.creator.username;
                this.phone= project.creator.phonenumber;
                this.email = project.creator.email;
                this.projectObj = project;
            }
        }
        public class NonAssignedProject
        {
            public string name { get; set; }
            public string description { get; set; }
            public string timeline { get; set; }
            public int bids { get; set; }
            public double budget { get; set; }
            public Project ProjectObj { get; set; }
            public NonAssignedProject(Project project)
            {
                this.name = project.name;
                this.timeline = project.timeline;
                this.description = project.description;
                this.budget = project.budget;
                this.bids = 0;
                this.ProjectObj = project;
                foreach (var item in project.proposals)
                {
                    this.bids++;
                }
            }
        }
    }
}
