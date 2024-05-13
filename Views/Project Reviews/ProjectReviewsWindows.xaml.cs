using System.Windows;
using FreelancerClientPlatform.Models;

namespace FreelancerClientPlatform.Views.Client
{
    public partial class ProjectReviewsWindow : Window
    {
        public Project SelectedProject { get; set; }
        public List<Review> Reviews { get; set; }

        public ProjectReviewsWindow(Project selectedProject)
        {
            InitializeComponent();
            if (App.signedInUser is Models.Client)
            {
                AddReviewPanel.Visibility = Visibility.Visible;
            }

            this.SelectedProject = selectedProject;
            this.DataContext = this;
            LoadReviews();
        }

        public void LoadReviews()
        {
            this.Reviews = new List<Review>();
            foreach (var item in SelectedProject.reviews)
            {
                Reviews.Add(item);
            }
            ReviewList.ItemsSource = Reviews;

        }

        private void SubmitReview_Click(object sender, RoutedEventArgs e)
        {
            string reviewText = ReviewText.Text;
            double reviewValue = ReviewValueSlider.Value;

            Review newReview = new Review((int)reviewValue, reviewText, (Models.Client)App.signedInUser);

            SelectedProject.reviews.Add(newReview);
            LoadReviews();
        }
    }
}
