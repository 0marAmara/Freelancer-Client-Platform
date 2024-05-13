using FreelancerClientPlatform.Views.Client;
using System.Collections.ObjectModel;
using System.Windows;
using static FreelancerClientPlatform.Views.Client.ActiveProjectsWindow;

namespace FreelancerClientPlatform.Views.Freelancer
{
    public partial class ManageProjectsWindow : Window
    {
        public ObservableCollection<AssignedProject> ActiveProjects { get; set; }

        public ManageProjectsWindow()
        {
            InitializeComponent();
            LoadActiveProjects();
        }

        private void LoadActiveProjects()
        {
            ActiveProjects= new ObservableCollection<AssignedProject>();
            var assignedProjects = App.projects.Where(p => p.status == 1&&p.assignedFreelancer.username==App.signedInUser.username).Select(p => new AssignedProject(p)).ToList();
            foreach (var project in assignedProjects)
            {
                ActiveProjects.Add(project);
            }
            ActiveProjectsListView.ItemsSource = ActiveProjects;
        }

        private void CompleteProject_Click(object sender, RoutedEventArgs e)
        {
                
            if (sender is FrameworkElement element && element.DataContext is AssignedProject selectedProject)
            {
                selectedProject.projectObj.completeProject();
                LoadActiveProjects();
            }
        }
    }
}
