using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using FreelancerClientPlatform.Models;

namespace FreelancerClientPlatform.Views.Login_and_registration
{
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        public bool IsValidPassword(string password)
        {
            if (password.Length < 8 || password.Length > 12)
                return false;
            bool hasLowercase = false;
            bool hasUppercase = false;
            foreach (char c in password)
            {
                if (char.IsLower(c))
                    hasLowercase = true;
                else if (char.IsUpper(c))
                    hasUppercase = true;
            }

            return hasLowercase && hasUppercase;
        }


        private void Register_Click(object sender, RoutedEventArgs e)
        {
            string username = txtNewUsername.Text;
            string password = txtNewPassword.Password;
            string confirmPassword = txtConfirmPassword.Password;
            if (username.Length < 4)
            {
                MessageBox.Show("Enter valid username");
                return;
            }
            if (confirmPassword != password || !IsValidPassword(password))
            {
                MessageBox.Show("Password is not entered correctly");
                return;
            }
            if(cmbUserType.SelectedItem == null)
            {
                MessageBox.Show("Choose a UserType");
                return;
            }
            ComboBoxItem selectedItem = (ComboBoxItem)cmbUserType.SelectedItem;
            string userType = selectedItem.Content.ToString();
            if (userType == "Freelancer")
            {
                if (txtSkills.Text.Length == 0)
                {
                    MessageBox.Show("Enter skills");
                    return;
                }
                string[] skills = txtSkills.Text.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (!txtPortfolio.Text.EndsWith(".com"))
                {
                    MessageBox.Show("Enter Portfolio (Enter a link)");
                    return;
                }
                string portfolio = txtPortfolio.Text;
                Models.Freelancer freelancer = new Models.Freelancer(username, password, skills, portfolio);
                bool isValid= App.addNewUser(freelancer);
                if(isValid )
                {
                    MessageBox.Show("Registered Successfully");
                    Close();
                    return;
                }
                else
                {
                    MessageBox.Show("User Already Exists");
                    Close();
                    return;
                }
            }
            else
            {
                string email = txtEmail.Text;
                string phoneNumber = txtPhoneNumber.Text;

                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phoneNumber))
                {
                    MessageBox.Show("Enter both Email and Phone Number");
                    return;
                }

                FreelancerClientPlatform.Models.Client client = new FreelancerClientPlatform.Models.Client(username, password, email, phoneNumber);
                bool isValid = App.addNewUser(client);

                if (isValid)
                {
                    MessageBox.Show("Registered Successfully");
                    Close();
                    return;
                }

                MessageBox.Show("User Already Exists");
                Close();
                return;
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cmbUserType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            freelancerFields.Visibility = Visibility.Collapsed;
            clientFields.Visibility = Visibility.Collapsed;
            if (cmbUserType.SelectedItem != null)
            {
                ComboBoxItem selectedItem = (ComboBoxItem)cmbUserType.SelectedItem;
                string userType = selectedItem.Content.ToString();

                if (userType == "Freelancer")
                {
                    freelancerFields.Visibility = Visibility.Visible;
                    clientFields.Visibility = Visibility.Collapsed;
                }
                else if (userType == "Client")
                {
                    freelancerFields.Visibility = Visibility.Collapsed;
                    clientFields.Visibility = Visibility.Visible;
                }
            }
        }
    }
}
