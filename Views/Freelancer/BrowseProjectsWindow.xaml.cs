using System.Collections.ObjectModel;
using System.Windows;
using FreelancerClientPlatform.Models;
using static FreelancerClientPlatform.Views.Client.ActiveProjectsWindow;

namespace FreelancerClientPlatform.Views.Freelancer
{
    public partial class BrowseProjectsWindow : Window
    {
        public ObservableCollection<NonAssignedProject> AvailableProjects { get; set; }

        public BrowseProjectsWindow()
        {
            InitializeComponent();
            LoadAvailableProjects();
        }

        private void LoadAvailableProjects()
        {
            AvailableProjects = new ObservableCollection<NonAssignedProject>();
            ProjectsGrid.ItemsSource = AvailableProjects;

            foreach (var item in App.projects)
            {
                if (item.status == 0)
                    AvailableProjects.Add(new NonAssignedProject(item));
            }

        }

        private void SubmitBid_Click(object sender, RoutedEventArgs e)
        {
            if (ProjectsGrid.SelectedItem is NonAssignedProject selectedProject)
            {
                BidFormWindow bidFormWindow = new BidFormWindow(selectedProject.ProjectObj);
                bidFormWindow.ShowDialog();
                LoadAvailableProjects(); 
            }
        }
    }
}
