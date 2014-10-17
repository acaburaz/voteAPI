using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using VoteappAPI.Models;

namespace VoteappAPI.Context
{
    public class VoteContext:DbContext
    {
        public VoteContext(): base("VoteappDB")
    {
        
    }
        public System.Data.Entity.DbSet<VoteappAPI.Models.Vote> Votes { get; set; }

        public System.Data.Entity.DbSet<VoteappAPI.Models.Choice> Choices { get; set; }

        public System.Data.Entity.DbSet<VoteappAPI.Models.Voter> Voters { get; set; }

    }
}