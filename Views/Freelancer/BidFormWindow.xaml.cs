using FreelancerClientPlatform.Models;
using System.Windows;

namespace FreelancerClientPlatform.Views.Freelancer
{
    public partial class BidFormWindow : Window
    {
        Project project;
        public BidFormWindow(Project project)
        {
            InitializeComponent();
            this.project = project;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            string info = InfoTextBox.Text.Trim();
            string timeline = TimelineTextBox.Text.Trim();
            double budget;
            if (timeline.Length == 0)
            {
                MessageBox.Show("Invalid timeline value.", "Error");

            }
            if (info.Length == 0)
            {
                MessageBox.Show("Invalid info value.", "Error");

            }
            if (double.TryParse(BudgetTextBox.Text.Trim(), out budget))
            {
                Proposal proposal = new Proposal((Models.Freelancer)App.signedInUser,info,timeline,budget);
                project.addProposal(proposal);
                Close();
            }
            else
            {
                MessageBox.Show("Invalid budget value. Please enter a valid number.", "Error");
            }
        }
    }
}
