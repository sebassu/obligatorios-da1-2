using Domain;
using System;
using Exceptions;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.DomainTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class TeamTests
    {
        private static Team testingTeam;

        [TestInitialize]
        public void TestSetup()
        {
            testingTeam = Team.InstanceForTestingPurposes();
        }

        [TestMethod]
        public void TeamForTestingPurposesTest()
        {
            Assert.AreEqual("Equipo inválido", testingTeam.Name);
            Assert.AreEqual("Descripción inválida.", testingTeam.Description);
            Assert.AreEqual(int.MaxValue, testingTeam.MaximumMembers);
            Assert.IsTrue(testingTeam.Members.Count == 0);
        }

        [TestMethod]
        public void TeamSetValidNameTest()
        {
            testingTeam.Name = "Equipo 1";
            Assert.AreEqual("Equipo 1", testingTeam.Name);
        }

        [TestMethod]
        public void TeamSetValidNameTest2()
        {
            testingTeam.Name = "Equipo Nuevo";
            Assert.AreEqual("Equipo Nuevo", testingTeam.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TeamSetInvalidNamePunctuationTest()
        {
            testingTeam.Name = "Equipo.#/!";
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TeamSetInvalidNameEmptyTest()
        {
            testingTeam.Name = "";
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TeamSetInvalidNameNullTest()
        {
            testingTeam.Name = null;
        }

        [TestMethod]
        public void TeamValidCreationDateTest()
        {
            Assert.AreEqual(DateTime.Today, testingTeam.CreationDate.Date);
        }

        [TestMethod]
        public void TeamSetValidDescriptionTest()
        {
            testingTeam.Description = "Esto es una breve descripción del equipo.";
            Assert.AreEqual("Esto es una breve descripción del equipo.",
                testingTeam.Description);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TeamSetInvalidDescriptionEmptyTest()
        {
            testingTeam.Description = "";
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TeamSetInvalidDescriptionNullTest()
        {
            testingTeam.Description = null;
        }

        [TestMethod]
        public void TeamSetValidMaximumMembersTest()
        {
            testingTeam.MaximumMembers = 35;
            Assert.AreEqual(35, testingTeam.MaximumMembers);
        }

        [TestMethod]
        public void TeamSetValidOnlyOneMemberTest()
        {
            testingTeam.MaximumMembers = 1;
            Assert.AreEqual(1, testingTeam.MaximumMembers);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TeamSetInvalidZeroMemberTest()
        {
            testingTeam.MaximumMembers = 0;
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TeamSetInvalidNegativeMembersTest()
        {
            testingTeam.MaximumMembers = -10;
        }

        [TestMethod]
        public void TeamParameterFactoryMethodValidTest()
        {
            string descriptionToSet = "Un grupo de personas que resuelve todo tipo de problemas.";
            User creator = User.CreateNewCollaborator("Mario", "Santos",
                "santos@simuladores.com", DateTime.Today, "DisculpeFuegoTiene");
            testingTeam = Team.CreatorNameDescriptionMaximumMembers(creator, "Los Simuladores",
                descriptionToSet, 4);
            Assert.AreEqual("Los Simuladores", testingTeam.Name);
            Assert.AreEqual(DateTime.Today, testingTeam.CreationDate.Date);
            Assert.AreEqual(descriptionToSet, testingTeam.Description);
            Assert.AreEqual(4, testingTeam.MaximumMembers);
            CollectionAssert.Contains(testingTeam.Members.ToList(), creator);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TeamParameterFactoryMethodInvalidNameTest()
        {
            User creator = User.CreateNewCollaborator("Creator", "Team",
                "creador@usuario.com", DateTime.Today, "password125");
            testingTeam = Team.CreatorNameDescriptionMaximumMembers(creator,
                "Equipo#11.32!", "Tareas:", 5);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TeamParameterFactoryMethodInvalidMaximumNumberTest()
        {
            User creator = User.CreateNewCollaborator("Creator", "Team",
                "creador@usuario.com", DateTime.Today, "password125");
            testingTeam = Team.CreatorNameDescriptionMaximumMembers(creator,
                "Equipo 2", "Tareas:", 0);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TeamParameterFactoryMethodInvalidDescriptionTest()
        {
            User creator = User.CreateNewCollaborator("Creator", "Team",
                "creador@usuario.com", DateTime.Today, "password125");
            testingTeam = Team.CreatorNameDescriptionMaximumMembers(creator, "Equipo 3", "", 5);
        }

        [TestMethod]
        public void TeamToStringTest1()
        {
            Assert.AreEqual("Equipo inválido", testingTeam.ToString());
        }

        [TestMethod]
        public void TeamToStringTest2()
        {
            testingTeam.Name = "Equipo 10";
            Assert.AreEqual("Equipo 10", testingTeam.ToString());
        }

        [TestMethod]
        public void TeamToStringTest3()
        {
            string newName = "Equipo 15";
            testingTeam.Name = newName;
            Assert.AreEqual(newName, testingTeam.ToString());
        }

        [TestMethod]
        public void TeamAddValidMemberTest()
        {
            User aUser = User.CreateNewCollaborator("Pablo", "Lamponne",
                "lamponne@simuladores.com", DateTime.Now, "contraseñaVálida123");
            testingTeam.AddMember(aUser);
            CollectionAssert.Contains(testingTeam.Members.ToList(), aUser);
        }

        [TestMethod]
        public void TeamAddValidMembersTest()
        {
            User aUser = User.CreateNewCollaborator("Nombre", "Apellido",
                "mail@usuario.com", DateTime.Today, "password123");
            User bUser = User.CreateNewCollaborator("Name", "LastName",
                "mail2@usuario.com", DateTime.Today, "password122");
            testingTeam.AddMember(aUser);
            testingTeam.AddMember(bUser);
            CollectionAssert.Contains(testingTeam.Members.ToList(), aUser);
            CollectionAssert.Contains(testingTeam.Members.ToList(), bUser);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TeamAddSameMemberTest()
        {
            User aUser = User.CreateNewCollaborator("Nombre", "Apellido",
                "mail@usuario.com", DateTime.Today, "password123");
            User bUser = User.CreateNewCollaborator("Name", "LastName",
                "mail@usuario.com", DateTime.Today, "password122");
            testingTeam.AddMember(aUser);
            testingTeam.AddMember(bUser);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TeamAddTooManyMembersTest()
        {
            User creator = User.InstanceForTestingPurposes();
            testingTeam = Team.CreatorNameDescriptionMaximumMembers(creator,
                "Equipo 1", "No hace tareas.", 1);
            User aUser = User.CreateNewCollaborator("Nombre", "Apellido",
                "mail@usuario.com", DateTime.Today, "password123");
            testingTeam.AddMember(aUser);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TeamAddNullMemberInvalidTest()
        {
            testingTeam.AddMember(null);
        }

        [TestMethod]
        public void TeamRemoveMemberTest()
        {
            User creator = User.CreateNewCollaborator("Creator", "Team",
                "creador@usuario.com", DateTime.Today, "password125");
            testingTeam = Team.CreatorNameDescriptionMaximumMembers(creator,
                "Equipo 1", "No hace tareas.", 10);
            User aUser = User.InstanceForTestingPurposes();
            testingTeam.AddMember(aUser);
            testingTeam.RemoveMember(aUser);
            CollectionAssert.DoesNotContain(testingTeam.Members.ToList(), aUser);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TeamRemoveUniqueMemberTest()
        {
            User creator = User.CreateNewCollaborator("Creator", "Team",
                "creador@usuario.com", DateTime.Today, "password125");
            testingTeam = Team.CreatorNameDescriptionMaximumMembers(creator,
                "Equipo 1", "No hace tareas.", 10);
            testingTeam.RemoveMember(creator);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TeamRemoveNotAMemberTest()
        {
            testingTeam.RemoveMember(User.InstanceForTestingPurposes());
        }

        [TestMethod]
        public void TeamEqualsReflexiveTest()
        {
            Assert.AreEqual(testingTeam, testingTeam);
        }

        [TestMethod]
        public void TeamEqualsSymmetricTest()
        {
            Team secondTestingTeam = Team.InstanceForTestingPurposes();
            Assert.AreEqual(testingTeam, secondTestingTeam);
            Assert.AreEqual(secondTestingTeam, testingTeam);
        }

        [TestMethod]
        public void TeamEqualsTransitiveTest()
        {
            User oneCreator = User.InstanceForTestingPurposes();
            User anotherCreator = User.CreateNewCollaborator("Gabriel", "Medina",
                "medina@simuladores.com", DateTime.Now, "contraseñaVálida123");
            testingTeam = Team.CreatorNameDescriptionMaximumMembers(oneCreator, "Same name",
                "Description 1", 10);
            Team secondTestingTeam = Team.CreatorNameDescriptionMaximumMembers(oneCreator,
                "Same name", "Description 2", 11);
            Team thirdTestingTeam = Team.CreatorNameDescriptionMaximumMembers(anotherCreator,
                "Same name", "Description 3", 12);
            Assert.AreEqual(testingTeam, secondTestingTeam);
            Assert.AreEqual(secondTestingTeam, thirdTestingTeam);
            Assert.AreEqual(testingTeam, thirdTestingTeam);
        }

        [TestMethod]
        public void TeamEqualsDifferentTeamsTest()
        {
            User sameCreator = User.InstanceForTestingPurposes();
            testingTeam = Team.CreatorNameDescriptionMaximumMembers(sameCreator, "One name",
                "Same descriptions", 10);
            Team secondTestingTeam = Team.CreatorNameDescriptionMaximumMembers(sameCreator,
                "Different name", "Same descriptions", 10);
            Assert.AreNotEqual(testingTeam, secondTestingTeam);
        }

        [TestMethod]
        public void TeamEqualsNullTest()
        {
            Assert.AreNotEqual(testingTeam, null);
        }

        [TestMethod]
        public void TeamEqualsDifferentTypesTest()
        {
            object someRandomObject = new object();
            Assert.AreNotEqual(testingTeam, someRandomObject);
        }

        [TestMethod]
        public void TeamGetHashCodeTest()
        {
            object testingTeamAsObject = testingTeam;
            Assert.AreEqual(testingTeamAsObject.GetHashCode(), testingTeam.GetHashCode());
        }

        [TestMethod]
        public void TeamAddValidWhiteboardTest()
        {
            User creator = User.CreateNewCollaborator("Creator", "Team",
                "creador@usuario.com", DateTime.Today, "password125");
            testingTeam = Team.CreatorNameDescriptionMaximumMembers(creator, "Equipo 1",
                "No hace tareas.", 10);
            Whiteboard aWhiteboard = Whiteboard.CreatorNameDescriptionOwnerTeamWidthHeight(creator,
                "PizarronValido", "Descripcion de pizarron", testingTeam, 500, 500);
            CollectionAssert.Contains(testingTeam.CreatedWhiteboards.ToList(), aWhiteboard);
        }

        [TestMethod]
        public void TeamAddValidWhiteboardsTest()
        {
            User creator = User.CreateNewCollaborator("Creator", "Team",
                "creador@usuario.com", DateTime.Today, "password125");
            testingTeam = Team.CreatorNameDescriptionMaximumMembers(creator, "Equipo 1",
                "No hace tareas.", 10);
            Whiteboard aWhiteboard = Whiteboard.CreatorNameDescriptionOwnerTeamWidthHeight(creator,
                "PizarronValido", "Descripcion de pizarron", testingTeam, 500, 500);
            Whiteboard bWhiteboard = Whiteboard.CreatorNameDescriptionOwnerTeamWidthHeight(creator,
                "PizarronNuevo", "Descripcion de pizarron", testingTeam, 1500, 1500);
            CollectionAssert.Contains(testingTeam.CreatedWhiteboards.ToList(), aWhiteboard);
            CollectionAssert.Contains(testingTeam.CreatedWhiteboards.ToList(), bWhiteboard);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TeamAddSameWhiteboardTest()
        {
            User creator = User.CreateNewCollaborator("Creator", "Team",
                "creador@usuario.com", DateTime.Today, "password125");
            testingTeam = Team.CreatorNameDescriptionMaximumMembers(creator, "Equipo 1",
                "No hace tareas.", 10);
            Whiteboard aWhiteboard = Whiteboard.CreatorNameDescriptionOwnerTeamWidthHeight(creator,
                "PizarronValido", "Descripcion de pizarron", testingTeam, 500, 500);
            testingTeam.AddWhiteboard(aWhiteboard);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TeamAddNullWhiteboardTest()
        {
            testingTeam.AddWhiteboard(null);
        }

        [TestMethod]
        public void TeamRemoveValidWhiteboardTest()
        {
            DateTime aBirthdate = new DateTime(1990, 05, 05);
            User creator = User.CreateNewCollaborator("Creator", "Team",
                "creador@usuario.com", aBirthdate, "password125");
            testingTeam = Team.CreatorNameDescriptionMaximumMembers(creator, "Equipo 1",
                "No hace tareas.", 10);
            Whiteboard aWhiteboard = Whiteboard.CreatorNameDescriptionOwnerTeamWidthHeight(creator,
                "PizarronValido", "Descripcion de pizarron", testingTeam, 500, 500);
            testingTeam.RemoveWhiteboard(aWhiteboard);
            CollectionAssert.DoesNotContain(testingTeam.CreatedWhiteboards.ToList(), aWhiteboard);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TeamRemoveAnUncreatedWhiteboardTest()
        {
            DateTime aBirthdate = new DateTime(1990, 05, 05);
            User creator = User.CreateNewCollaborator("Creator", "Team",
                "creador@usuario.com", aBirthdate, "password125");
            testingTeam = Team.CreatorNameDescriptionMaximumMembers(creator,
                "Equipo 1", "No hace tareas.", 10);
            Whiteboard someRandomWhiteboard = Whiteboard.InstanceForTestingPurposes();
            testingTeam.RemoveWhiteboard(someRandomWhiteboard);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TeamLowerMaximumMembersWithTeamSurpassingItInvalidTest()
        {
            DateTime aBirthdate = new DateTime(1990, 05, 05);
            User creator = User.CreateNewCollaborator("Creator", "Team",
                "creador@usuario.com", aBirthdate, "password125");
            testingTeam = Team.CreatorNameDescriptionMaximumMembers(creator,
                "Equipo 1", "No hace tareas.", 2);
            testingTeam.AddMember(User.InstanceForTestingPurposes());
            testingTeam.MaximumMembers = 1;
        }
    }
}