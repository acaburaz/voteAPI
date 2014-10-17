using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VoteappAPI.Models
{
    public class Vote
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Votes { get; set; }
        public String VoteType { get; set; }
        public virtual ICollection <Choice> Choices { get; set; }
     
        public Vote()
        {
        }

      
    }
}