using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Persistence;
using System;

namespace UnitTests.PersistenceTests
{
    [TestClass]
    public class UserScoresRepositoryTests
    {
        private static User lynott;
        private static User gorham;
        private static Team lizzy;

        [ClassInitialize]
        public static void ClassSetup(TestContext context)
        {
            UserRepository.InsertOriginalSystemAdministrator();
            ChangeActiveUser("administrator@tf2.com", "Victory");
            AddTestingData();
        }

        private static void AddTestingData()
        {
            UserRepository.AddNewUser("Eric", "Clapton",
                "derek@dominos.com", DateTime.Now, "IfYouWannaGetDown");
            lynott = UserRepository.AddNewUser("Phil", "Lynott",
               "lynott@lizzy.com", DateTime.Today, "LonelyBoy");
            gorham = UserRepository.AddNewUser("Scott", "Gorham",
                "gorham@lizzy.com", DateTime.Today, "TheNextToPlay");
            lizzy = TeamRepository.AddNewTeam("Thin Lizzy", "Irish rock band.", 4);
            TeamRepository.AddMemberToTeam(lizzy, lynott);
            TeamRepository.AddMemberToTeam(lizzy, gorham);
        }

        [TestInitialize]
        public void TestSetup()
        {
            ChangeActiveUser("lynott@lizzy.com", "LonelyBoy");
        }

        private static void ChangeActiveUser(string email, string password)
        {
            Session.End();
            Session.Start(email, password);
        }

        [TestMethod]
        public void MSRepositoryUpdateUsersScoreForTeamValidTest()
        {
            UserScoresRepository.UpdateUserScoreInTeam(lizzy.Id, 0);
            var scores = UserScoresRepository.GetScoresForTeam(lizzy.Id);
            CollectionAssert.Contains(scores, new Tuple<User, int>(lynott, 0));
        }

        [TestMethod]
        [ExpectedException(typeof(MemberScoringException))]
        public void MSRepositoryUpdateUsersScoreForTeamNegativeInvalidTest()
        {
            ChangeActiveUser("gorham@lizzy.com", "TheNextToPlay");
            UserScoresRepository.UpdateUserScoreInTeam(lizzy.Id, -180);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void MSRepositoryUpdateUsersScoreNotInTeamInvalidTest()
        {
            ChangeActiveUser("derek@dominos.com", "IfYouWannaGetDown");
            UserScoresRepository.UpdateUserScoreInTeam(lizzy.Id, 360);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void MSRepositoryUpdateUsersScoreInvalidTeamIdTest()
        {
            UserScoresRepository.UpdateUserScoreInTeam(0, 70);
        }

        public void MSRepositoryResetTeamScoreValidTest()
        {
            int teamId = lizzy.Id;
            UserScoresRepository.UpdateUserScoreInTeam(teamId, 900);
            Assert.AreNotEqual(0, UserScoresRepository.GetScoresForTeam(teamId));
            UserScoresRepository.ResetTeamScore(teamId);
            Assert.AreEqual(0, UserScoresRepository.GetScoresForTeam(teamId));
        }
    }
}
