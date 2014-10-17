using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VoteappAPI.Models
{
    public class VoterChoiceView
    {
        public int Id { get; set; }
        public Voter Voter { get; set; }
    }
}