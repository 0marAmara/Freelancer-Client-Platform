using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancerClientPlatform.Models
{
    public class Freelancer:User
    {
        public List<Project> pastProjects= new List<Project>();
        public List<Project> currentProjects= new List<Project>();
        public string[] skills;
        public string portfolio;

        public Freelancer(string username, string password,string[] skills, string portfolio) : base(username, password)
        {
            this.skills = skills;
            this.portfolio = portfolio;
        }
        public void addProject(Project project)
        {
            currentProjects.Add(project);
            project.assignFreelancer(this);
        }
        public void completeProject(Project project)
        {
            project.completeProject();
            pastProjects.Add(project);
            currentProjects.Remove(project);
        }
    }
}
