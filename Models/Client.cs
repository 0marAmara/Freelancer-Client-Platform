namespace FreelancerClientPlatform.Models
{
    public class Client:User
    {
        public string email;
        public string phonenumber;

        public Client(string username, string password, string email,string phonenumber) :base(username,password) { 
            this.email = email;
            this.phonenumber = phonenumber;
        }
    }
}
