using FreelancerClientPlatform.Models;
using System.Collections.ObjectModel;
using System.Windows;

namespace FreelancerClientPlatform.Views.Client
{
    public partial class ViewFreelancersWindow : Window
    {
        public ObservableCollection<viewableFreelancer> FreelancersList { get; set; }

        public ViewFreelancersWindow()
        {
            InitializeComponent();
            FreelancersList = new ObservableCollection<viewableFreelancer>();
            LoadFreelancers();
            this.DataContext = this;
        }

        private void LoadFreelancers()
        {
            FreelancersList = new ObservableCollection<viewableFreelancer>();
            foreach (var user in App.users)
            {
                if (user is Models.Freelancer freelancer)
                {
                    FreelancersList.Add(new viewableFreelancer(freelancer));
                }
            }

            if (FreelancersList.Count > 0)
            {
                freelancersListView.ItemsSource = FreelancersList;
            }
            else
            {
                MessageBox.Show("No freelancers found.");
            }
        }

        public class viewableFreelancer
        {
            public string username { get; set; }
            public string skills { get; set; }
            public string portfolio { get; set; }
            public string pastProjects { get; set; }


            public viewableFreelancer(Models.Freelancer freelancer)
            {
                this.username = freelancer.username;
                this.skills = string.Join(", ", freelancer.skills);
                this.portfolio = freelancer.portfolio;
                this.pastProjects = string.Join(", ", freelancer.pastProjects.Select(p => p.name));
            }
        }
    }
}
