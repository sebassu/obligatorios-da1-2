﻿using Domain;
using System;
using Exceptions;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class TeamTests
    {
        private static Team testingTeam;

        [TestInitialize]
        public void TestSetUp()
        {
            testingTeam = Team.InstanceForTestingPurposes();
        }

        [TestMethod]
        public void TeamForTestingPurposesTest()
        {
            Assert.AreEqual("Nombre inválido.", testingTeam.Name);
            Assert.AreEqual("Descripción inválida.", testingTeam.Description);
            Assert.AreEqual(0, testingTeam.MaximumMembers);
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
            DateTime aBirthdate = new DateTime(1990, 05, 05);
            User creator = User.NamesEmailBirthdatePassword("Creator", "Team",
                "creador@usuario.com", aBirthdate, "password125");
            testingTeam = Team.CreatorNameDescriptionMaximumMembers(creator, "Equipo 1",
                "No hace tareas.", 10);
            Assert.AreEqual("Equipo 1", testingTeam.Name);
            Assert.AreEqual(DateTime.Today, testingTeam.CreationDate.Date);
            Assert.AreEqual("No hace tareas.", testingTeam.Description);
            Assert.AreEqual(10, testingTeam.MaximumMembers);
            CollectionAssert.Contains(testingTeam.Members, creator);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TeamParameterFactoryMethodInvalidNameTest()
        {
            DateTime aBirthdate = new DateTime(1990, 05, 05);
            User creator = User.NamesEmailBirthdatePassword("Creator", "Team",
                "creador@usuario.com", aBirthdate, "password125");
            testingTeam = Team.CreatorNameDescriptionMaximumMembers(creator,
                "Equipo#11.32!", "Tareas:", 5);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TeamParameterFactoryMethodInvalidMaximumNumberTest()
        {
            DateTime aBirthdate = new DateTime(1990, 05, 05);
            User creator = User.NamesEmailBirthdatePassword("Creator", "Team",
                "creador@usuario.com", aBirthdate, "password125");
            testingTeam = Team.CreatorNameDescriptionMaximumMembers(creator,
                "Equipo 2", "Tareas:", 0);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TeamParameterFactoryMethodInvalidDescriptionTest()
        {
            DateTime aBirthdate = new DateTime(1990, 05, 05);
            User creator = User.NamesEmailBirthdatePassword("Creator", "Team",
                "creador@usuario.com", aBirthdate, "password125");
            testingTeam = Team.CreatorNameDescriptionMaximumMembers(creator, "Equipo 3", "", 5);
        }

        [TestMethod]
        public void TeamToStringTest1()
        {
            Assert.AreEqual("Nombre inválido.", testingTeam.ToString());
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
            testingTeam.Name = "Equipo 15";
            Assert.AreEqual(testingTeam.Name, testingTeam.ToString());
        }

        [TestMethod]
        public void TeamAddValidMemberTest()
        {
            DateTime aBirthdate = new DateTime(1990, 05, 05);
            User creator = User.NamesEmailBirthdatePassword("Creator", "Team",
                "creador@usuario.com", aBirthdate, "password125");
            testingTeam = Team.CreatorNameDescriptionMaximumMembers(creator, "Equipo 1",
                "No hace tareas.", 10);
            User aUser = User.InstanceForTestingPurposes();
            testingTeam.AddMember(aUser);
            CollectionAssert.Contains(testingTeam.Members, aUser);
        }

        [TestMethod]
        public void TeamAddValidMembersTest()
        {
            DateTime aBirthdate = new DateTime(1990, 05, 05);
            User creator = User.NamesEmailBirthdatePassword("Creator", "Team",
                "creador@usuario.com", aBirthdate, "password125");
            testingTeam = Team.CreatorNameDescriptionMaximumMembers(creator,
                "Equipo 1", "No hace tareas.", 10);
            User aUser = User.InstanceForTestingPurposes();
            User bUser = User.NamesEmailBirthdatePassword("Nombre", "Apellido",
                "mail@usuario.com", aBirthdate, "password123");
            testingTeam.AddMember(aUser);
            testingTeam.AddMember(bUser);
            CollectionAssert.Contains(testingTeam.Members, aUser);
            CollectionAssert.Contains(testingTeam.Members, bUser);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TeamAddSameMemberTest()
        {
            DateTime aBirthdate = new DateTime(1990, 05, 05);
            User creator = User.NamesEmailBirthdatePassword("Creator", "Team",
                "creador@usuario.com", aBirthdate, "password125");
            testingTeam = Team.CreatorNameDescriptionMaximumMembers(creator,
                "Equipo 1", "No hace tareas.", 10);
            User aUser = User.NamesEmailBirthdatePassword("Nombre", "Apellido",
                "mail@usuario.com", aBirthdate, "password123");
            User bUser = User.NamesEmailBirthdatePassword("Name", "LastName",
                "mail@usuario.com", aBirthdate, "password122");
            testingTeam.AddMember(aUser);
            testingTeam.AddMember(bUser);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TeamAddTooManyMembersTest()
        {
            DateTime aBirthdate = new DateTime(1990, 05, 05);
            User creator = User.NamesEmailBirthdatePassword("Creator", "Team",
                "creador@usuario.com", aBirthdate, "password125");
            testingTeam = Team.CreatorNameDescriptionMaximumMembers(creator,
                "Equipo 1", "No hace tareas.", 1);
            User aUser = User.NamesEmailBirthdatePassword("Nombre", "Apellido",
                "mail@usuario.com", aBirthdate, "password123");
            testingTeam.AddMember(aUser);
        }

        [TestMethod]
        public void TeamRemoveMemberTest()
        {
            DateTime aBirthdate = new DateTime(1990, 05, 05);
            User creator = User.NamesEmailBirthdatePassword("Creator", "Team",
                "creador@usuario.com", aBirthdate, "password125");
            testingTeam = Team.CreatorNameDescriptionMaximumMembers(creator,
                "Equipo 1", "No hace tareas.", 10);
            User aUser = User.InstanceForTestingPurposes();
            testingTeam.AddMember(aUser);
            testingTeam.RemoveMember(aUser);
            CollectionAssert.DoesNotContain(testingTeam.Members, aUser);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TeamRemoveUniqueMemberTest()
        {
            DateTime aBirthdate = new DateTime(1990, 05, 05);
            User creator = User.NamesEmailBirthdatePassword("Creator", "Team",
                "creador@usuario.com", aBirthdate, "password125");
            testingTeam = Team.CreatorNameDescriptionMaximumMembers(creator,
                "Equipo 1", "No hace tareas.", 10);
            testingTeam.RemoveMember(creator);
        }

        [TestMethod]
        [ExpectedException(typeof(TeamException))]
        public void TeamRemoveNotAMemberTest()
        {
            DateTime aBirthdate = new DateTime(1990, 05, 05);
            User creator = User.NamesEmailBirthdatePassword("Creator", "Team",
                "creador@usuario.com", aBirthdate, "password125");
            testingTeam = Team.CreatorNameDescriptionMaximumMembers(creator,
                "Equipo 1", "No hace tareas.", 10);
            User aUser = User.InstanceForTestingPurposes();
            User bUser = User.NamesEmailBirthdatePassword("Name", "LastName",
                "mail@usuario.com", aBirthdate, "password122");
            testingTeam.AddMember(aUser);
            testingTeam.RemoveMember(bUser);
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
            User anotherCreator = User.NamesEmailBirthdatePassword("Gabriel", "Medina",
                "medina@simuladores.com", DateTime.Now, "contraseñaValida123");
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
    }
}