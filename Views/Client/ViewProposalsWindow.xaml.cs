using FreelancerClientPlatform.Models;
using System.Windows;

namespace FreelancerClientPlatform.Views.Client
{
    public partial class ViewProposalsWindow : Window
    {
        public Project Project { get; set; }
        public List<ProposalViewer> proposalViewers { get; set; }

        public ViewProposalsWindow(Project project)
        {
            InitializeComponent();
            this.Project = project;
            proposalViewers = new List<ProposalViewer>();
            loadProposals();
            proposalsListView.ItemsSource = proposalViewers;
        }

        public void loadProposals()
        {
            foreach (var item in Project.proposals)
            {
                proposalViewers.Add(new ProposalViewer(item));
            }
        }

        public class ProposalViewer
        {
            public string freelancer { get; set; }
            public Models.Freelancer freelancerObj { get;set; }
            public string info { get; set; }
            public string timeline { get; set; }
            public double budget { get; set; }

            public ProposalViewer(Proposal proposal)
            {
                this.freelancer = proposal.bidder.username;
                this.info = proposal.info;
                this.budget = proposal.budget;
                this.timeline = proposal.timeline;
                this.freelancerObj = proposal.bidder;
            }
        }

        private void AcceptBid_Click(object sender, RoutedEventArgs e)
        {
            ProposalViewer selectedProposal = ((FrameworkElement)sender).DataContext as ProposalViewer;
            Project.assignFreelancer(selectedProposal.freelancerObj);
            ActiveProjectsWindow activeProjectsWindow = new ActiveProjectsWindow();
            Close();
            activeProjectsWindow.Show();
        }
    }
}
