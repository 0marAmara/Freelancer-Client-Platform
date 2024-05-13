using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancerClientPlatform.Models
{
    public abstract class User
    {
        public string username { get; set; }
        public string password { get; set; }
        protected User(string username,string password) {
            this.username = username;
            this.password = password;
        }
    }
}
