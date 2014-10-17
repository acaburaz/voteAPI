using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VoteappAPI.Models;
using VoteappAPI.Context;
using System.Collections.Generic;
using VoteappAPI.Controllers;

namespace VoteappAPI.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Vote()
        {
            var vote = new Vote();
            vote.Name = "Vem har bästa Luren?";
            vote.Choices = new List<Choice>();
           
            var context = new VoteContext();
            vote.Choices.Add(new Choice {Text="Kudde",Timestamp=DateTime.Today });
            vote.Choices.Add(new Choice { Text = "Armin", Timestamp = DateTime.Today });
            context.Votes.Add(vote);
            context.SaveChanges();
        }

        [TestMethod]
        public void Choices()
        {
            var choice = new Choice();
            choice.Text = "kudde är bög";
            choice.Timestamp = DateTime.Today;
            var context = new VoteContext();
            context.Choices.Add(choice);
            context.SaveChanges();

        }

        [TestMethod]
        public void TestAddVoterChoice()
        {
            var v = new VoterController();
            var voter = new Voter();
            voter.IpAdress = "123,13,31";
            voter.PhoneName = "android";
            voter.Timestamp = DateTime.Today;

           var message = v.PostVoter( voter,1);
            Console.WriteLine(message);
        }
    }
}
