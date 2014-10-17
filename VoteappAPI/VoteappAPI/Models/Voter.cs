using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VoteappAPI.Models
{
    public class Voter
    {
        [Key]
        public int VoterId { get; set; }
        public String IpAdress { get; set; }
        public String PhoneName { get; set; }
        public DateTime Timestamp { get; set; }
    }
}