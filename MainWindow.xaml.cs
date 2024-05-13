using FreelancerClientPlatform.Models;
using FreelancerClientPlatform.Views.Client;
using FreelancerClientPlatform.Views.Freelancer;
using FreelancerClientPlatform.Views.Login_and_registration;
using System.Windows;

namespace FreelancerClientPlatform
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string enteredUsername = txtUsername.Text;
            string enteredPassword = txtPassword.Password;
            if(App.users.Any(user => user.username == enteredUsername))
            {
                if(App.users.Any(users => users.password == enteredPassword))
                {
                    User enteredUser = App.users.Find(users => users.username == enteredUsername);
                    App.signedInUser = enteredUser;
                    if(enteredUser.GetType()==typeof(Client)) {
                        ClientDashboardWindow clientDashboard = new ClientDashboardWindow();
                        clientDashboard.Show();
                    }
                    else
                    {
                        FreelancerDashboard freelancerDashboard = new FreelancerDashboard();
                        freelancerDashboard.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect password. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("User not found. Please register or enter correct credentials.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            };
        }
    }
}
