using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancerClientPlatform.Models
{
    public class Review
    {
        public string text { get; set; }
        public int value { get; set; }

        public Client submitter { get; set; }
        public Review(int val,string txt, Client submitter)
        {
            this.text = txt;
            this.value = val;
            this.submitter = submitter;
        }
    }
}
