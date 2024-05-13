using FreelancerClientPlatform.Models;
using System.Windows;

namespace FreelancerClientPlatform.Views.Client
{
    public partial class NewProjectWindow : Window
    {
        public NewProjectWindow()
        {
            InitializeComponent();
        }

        private void Submit_Button_Click(object sender, RoutedEventArgs e)
        {
            string projectName = txtName.Text;
            string projectDescription = txtDescription.Text;
            string projectTimeline = txtTimeline.Text;
            double projectBudget;
            if(projectName.Length == 0) {
                MessageBox.Show("Invalid Project Name");
                return;
            }
            if (projectDescription.Length == 0)
            {
                MessageBox.Show("Invalid Project Description");
                return;
            }
            if (projectTimeline.Length == 0)
            {
                MessageBox.Show("Invalid Project Timeline");
                return;
            }
            if (double.TryParse(txtBudget.Text, out projectBudget))
            {
                Project createdProject = new Models.Project(projectName, projectDescription,projectTimeline,projectBudget, (Models.Client)App.signedInUser);
                MessageBox.Show("Project Created Successfully");
                App.addNewProject(createdProject);
                Close();
                return;
            }
            else
            {
                MessageBox.Show("Invalid budget value. Please enter a valid number.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
