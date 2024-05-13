using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancerClientPlatform.Models
{
    public class Proposal
    {
        public Freelancer bidder;
        public string info,timeline;
        public double budget;
        public Proposal(Freelancer freelancer,string info,string timeline,double budget) {
            this.timeline = timeline;
            this.bidder = freelancer;
            this.info = info;
            this.budget = budget;
        }
    }
}
