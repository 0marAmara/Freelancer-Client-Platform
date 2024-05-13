using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancerClientPlatform.Models
{
    public class Project
    {
        public Client creator;
        public Freelancer assignedFreelancer;
        public List<Proposal> proposals;
        public List<Review> reviews;
        public int status = 0;
        public string name { get; set; }
        public string description { get; set; }
        public string timeline {  get; set; }
        public double budget { get; set; }
        public Project(string name,string description, string timeline, double budget, Client creator)
        {
            this.name = name;
            this.description = description;
            this.timeline = timeline;
            this.budget = budget;
            this.creator = creator;
            this.status = 0;
            this.proposals = new List<Proposal>();
            this.reviews = new List<Review>();
        }
        public void assignFreelancer(Freelancer freelancer)
        {
            assignedFreelancer = freelancer;
            Proposal chosenProposal = proposals.FirstOrDefault(p => p.bidder == freelancer);
            if (chosenProposal != null)
            {
                budget = chosenProposal.budget;
                timeline = chosenProposal.timeline;
            }
            status = 1;
        }
        public void addProposal(Proposal proposal)
        {
            proposals.Add(proposal);
        }
        public void completeProject ()
        {
            status = 2;
        }
        public void addReview(Review review)
        {
            this.reviews.Add(review);
        }
    }
}
