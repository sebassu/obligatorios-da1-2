using System;
using Domain;
using Exceptions;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace UnitTests.DomainTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WhiteboardTests
    {
        private static Whiteboard testingWhiteboard;

        [TestInitialize]
        public void TestSetup()
        {
            testingWhiteboard = Whiteboard.InstanceForTestingPurposes();
        }

        private static void GenerateNonGenericTestSituation()
        {
            string testImageLocation = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName
                + "\\..\\Resources\\TestImage.jpg";
            User creator = User.NamesEmailBirthdatePassword("Emilio", "Ravenna",
                "ravenna@simuladores.com", DateTime.Today, "HablarUnasPalabritas");
            Team ownerTeam = Team.CreatorNameDescriptionMaximumMembers(creator, "Equipo 3",
                "Descripción.", 5);
            testingWhiteboard = Whiteboard.CreatorNameDescriptionOwnerTeamWidthHeight(creator,
                "Pizarrón de prueba", "Descripción.", ownerTeam, 1200, 600);
            TextBoxWhiteboard.CreateWithContainer(testingWhiteboard);
            var image = ImageWhiteboard.CreateWithContainerSource(testingWhiteboard, testImageLocation);
            image.Width = 600;
            image.Height = 250;
        }

        [TestMethod]
        public void WhiteboardForTestingPurposesTest()
        {
            Assert.AreEqual("Pizarrón inválido", testingWhiteboard.Name);
            Assert.AreEqual("Descripción inválida.", testingWhiteboard.Description);
            Assert.AreEqual(int.MaxValue, testingWhiteboard.Width);
            Assert.AreEqual(int.MaxValue, testingWhiteboard.Height);
            Assert.AreEqual(User.InstanceForTestingPurposes(),
                testingWhiteboard.Creator);
            Assert.AreEqual(Team.InstanceForTestingPurposes(),
                testingWhiteboard.OwnerTeam);
            Assert.AreEqual(testingWhiteboard.CreationDate, DateTime.Today);
        }

        [TestMethod]
        public void WhiteboardSetValidNameTest1()
        {
            testingWhiteboard.Name = "Pizarron1";
            Assert.AreEqual("Pizarron1", testingWhiteboard.Name);
        }

        [TestMethod]
        public void WhiteboardSetValidNameTest2()
        {
            testingWhiteboard.Name = "PizarronNuevo";
            Assert.AreEqual("PizarronNuevo", testingWhiteboard.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(WhiteboardException))]
        public void WhiteboardSetInvalidName()
        {
            testingWhiteboard.Name = "Equipo!.-";
        }

        [TestMethod]
        [ExpectedException(typeof(WhiteboardException))]
        public void WhiteboardSetInvalidNameEmptyTest()
        {
            testingWhiteboard.Name = "";
        }

        [TestMethod]
        [ExpectedException(typeof(WhiteboardException))]
        public void WhiteboardSetInvalidNameNullTest()
        {
            testingWhiteboard.Name = null;
        }

        [TestMethod]
        public void WhiteboardSetValidDescriptionTest()
        {
            testingWhiteboard.Description = "Esto es una breve descripción " +
                "del pizarrón.";
            Assert.AreEqual("Esto es una breve descripción del pizarrón.",
                testingWhiteboard.Description);
        }

        [TestMethod]
        [ExpectedException(typeof(WhiteboardException))]
        public void WhiteboardSetInvalidDescriptionNullTest()
        {
            testingWhiteboard.Description = null;
        }

        [TestMethod]
        [ExpectedException(typeof(WhiteboardException))]
        public void WhiteboardSetInvalidDescriptionEmptyTest()
        {
            testingWhiteboard.Description = "";
        }

        [TestMethod]
        public void WhiteboardSetValidWidthTest()
        {
            testingWhiteboard.Width = 1532;
            Assert.AreEqual(1532, testingWhiteboard.Width);
        }

        [TestMethod]
        public void WhiteboardSetValidMinimumWidthTest()
        {
            testingWhiteboard.Width = 1;
            Assert.AreEqual(1, testingWhiteboard.Width);
        }

        [TestMethod]
        [ExpectedException(typeof(WhiteboardException))]
        public void WhiteboardSetInvalidMinimumWidthTest()
        {
            testingWhiteboard.Width = 0;
        }

        [TestMethod]
        [ExpectedException(typeof(WhiteboardException))]
        public void WhiteboardSetInvalidNegativeWidthTest()
        {
            testingWhiteboard.Width = -40;
        }

        [TestMethod]
        public void WhiteboardSetValidHeightTest()
        {
            testingWhiteboard.Height = 2500;
            Assert.AreEqual(2500, testingWhiteboard.Height);
        }

        [TestMethod]
        public void WhiteboardSetValidMinimumHeightTest()
        {
            testingWhiteboard.Height = 1;
            Assert.AreEqual(1, testingWhiteboard.Height);
        }

        [TestMethod]
        [ExpectedException(typeof(WhiteboardException))]
        public void WhiteboardSetInvalidMinimumHeightTest()
        {
            testingWhiteboard.Height = 0;
        }

        [TestMethod]
        [ExpectedException(typeof(WhiteboardException))]
        public void WhiteboardSetInvalidNegativeHeightTest()
        {
            testingWhiteboard.Width = -50;
        }

        [TestMethod]
        public void WhiteboardParameterFactoryMethodValidTest()
        {
            User creator = User.InstanceForTestingPurposes();
            Team ownerTeam = Team.CreatorNameDescriptionMaximumMembers(creator, "Los Simuladores",
                "Un grupo de gente que resuelve todo tipo de problemas.", 4);
            testingWhiteboard = Whiteboard.CreatorNameDescriptionOwnerTeamWidthHeight(creator,
                "Pizarron1", "Descripción de pizarrón", ownerTeam, 500, 500);
            Assert.AreEqual("Pizarron1", testingWhiteboard.Name);
            Assert.AreEqual("Descripción de pizarrón", testingWhiteboard.Description);
            Assert.AreEqual(creator, testingWhiteboard.Creator);
            Assert.AreEqual(ownerTeam, testingWhiteboard.OwnerTeam);
            Assert.AreEqual(500, testingWhiteboard.Width);
            Assert.AreEqual(500, testingWhiteboard.Height);
            Assert.AreEqual(testingWhiteboard.CreationDate, DateTime.Today);
            CollectionAssert.Contains(ownerTeam.CreatedWhiteboards.ToList(), testingWhiteboard);
        }

        [TestMethod]
        [ExpectedException(typeof(WhiteboardException))]
        public void WhiteboardParameterFactoryMethodInvalidNameTest()
        {
            Team ownerTeam = Team.InstanceForTestingPurposes();
            User creator = User.InstanceForTestingPurposes();
            testingWhiteboard = Whiteboard.CreatorNameDescriptionOwnerTeamWidthHeight(creator,
                "Pizarron#11.32!", "Tareas:", ownerTeam, 500, 500);
        }

        [TestMethod]
        [ExpectedException(typeof(WhiteboardException))]
        public void WhiteboardParameterFactoryMethodInvalidDescriptionTest()
        {
            Team ownerTeam = Team.InstanceForTestingPurposes();
            User creator = User.InstanceForTestingPurposes();
            testingWhiteboard = Whiteboard.CreatorNameDescriptionOwnerTeamWidthHeight(creator,
                "Pizarron2", "", ownerTeam, 100, 100);
        }

        [TestMethod]
        [ExpectedException(typeof(WhiteboardException))]
        public void WhiteboardParameterFactoryMethodInvalidWidthTest()
        {
            Team ownerTeam = Team.InstanceForTestingPurposes();
            User creator = User.InstanceForTestingPurposes();
            testingWhiteboard = Whiteboard.CreatorNameDescriptionOwnerTeamWidthHeight(creator,
                "Equipo3", "Descripción de pizarrón", ownerTeam, 0, 100);
        }

        [TestMethod]
        [ExpectedException(typeof(WhiteboardException))]
        public void WhiteboardParameterFactoryMethodInvalidHeightTest()
        {
            Team ownerTeam = Team.InstanceForTestingPurposes();
            User creator = User.InstanceForTestingPurposes();
            testingWhiteboard = Whiteboard.CreatorNameDescriptionOwnerTeamWidthHeight(creator,
                "Equipo3", "Descripción de pizarrón", ownerTeam, 100, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(WhiteboardException))]
        public void WhiteboardParameterFactoryMethodUserNotInTeamTest()
        {
            User creator = User.NamesEmailBirthdatePassword("Pablo", "Lamponne",
                "lamponne@simuladores.com", DateTime.Today, "contraseñaVálida123");
            Team ownerTeam = Team.InstanceForTestingPurposes();
            testingWhiteboard = Whiteboard.CreatorNameDescriptionOwnerTeamWidthHeight(creator,
                "Equipo3", "Descripción de pizarrón", ownerTeam, 100, 50);
        }

        [TestMethod]
        [ExpectedException(typeof(WhiteboardException))]
        public void WhiteboardParameterFactoryMethodNullTeamTest()
        {
            User creator = User.InstanceForTestingPurposes();
            testingWhiteboard = Whiteboard.CreatorNameDescriptionOwnerTeamWidthHeight(creator,
                "Equipo3", "Descripción de pizarrón", null, 100, 50);
        }

        [TestMethod]
        public void WhiteboardToStringTest1()
        {
            Assert.AreEqual("Pizarrón inválido", testingWhiteboard.ToString());
        }

        [TestMethod]
        public void WhiteboardToStringTest2()
        {
            testingWhiteboard.Name = "Equipo10";
            Assert.AreEqual("Equipo10", testingWhiteboard.ToString());
        }

        [TestMethod]
        public void WhiteboardToStringTest3()
        {
            testingWhiteboard.Name = "Equipo15";
            Assert.AreEqual(testingWhiteboard.Name, testingWhiteboard.ToString());
        }

        [TestMethod]
        public void WhiteboardEqualsReflexiveTest()
        {
            Assert.AreEqual(testingWhiteboard, testingWhiteboard);
        }

        [TestMethod]
        public void WhiteboardEqualsSymmetricTest()
        {
            Whiteboard secondTestingWhiteboard = Whiteboard.InstanceForTestingPurposes();
            Assert.AreEqual(testingWhiteboard, secondTestingWhiteboard);
            Assert.AreEqual(secondTestingWhiteboard, testingWhiteboard);
        }

        [TestMethod]
        public void WhiteboardEqualsTransitiveTest()
        {
            Whiteboard secondTestingWhiteboard = Whiteboard.InstanceForTestingPurposes();
            Whiteboard thirdTestingWhiteboard = Whiteboard.InstanceForTestingPurposes();
            Assert.AreEqual(testingWhiteboard, secondTestingWhiteboard);
            Assert.AreEqual(secondTestingWhiteboard, thirdTestingWhiteboard);
            Assert.AreEqual(testingWhiteboard, thirdTestingWhiteboard);
        }

        [TestMethod]
        public void WhiteboardEqualsDifferentTeamsTest()
        {
            User creator = User.InstanceForTestingPurposes();
            Team oneTeam = Team.CreatorNameDescriptionMaximumMembers(creator, "One name",
                "Same descriptions", 10);
            Team secondTeam = Team.CreatorNameDescriptionMaximumMembers(creator,
                "Different name", "Same descriptions", 10);
            testingWhiteboard = Whiteboard.CreatorNameDescriptionOwnerTeamWidthHeight(creator,
                "Pizarron1", "Descripción 1.", oneTeam, 75, 75);
            Whiteboard secondTestingWhiteboard = Whiteboard.CreatorNameDescriptionOwnerTeamWidthHeight(creator,
                "Pizarron1", "Descripción 2.", secondTeam, 25, 25);
            Assert.AreNotEqual(testingWhiteboard, secondTestingWhiteboard);
        }

        [TestMethod]
        public void WhiteboardEqualsNullTest()
        {
            Assert.AreNotEqual(testingWhiteboard, null);
        }

        [TestMethod]
        public void WhiteboardEqualsDifferentTypesTest()
        {
            object someRandomObject = new object();
            Assert.AreNotEqual(testingWhiteboard, someRandomObject);
        }

        [TestMethod]
        public void WhiteboardGetHashCodeTest()
        {
            object testingWhiteboardAsObject = testingWhiteboard;
            Assert.AreEqual(testingWhiteboardAsObject.GetHashCode(),
                testingWhiteboard.GetHashCode());
        }

        [TestMethod]
        public void WhiteboardAddElementValidImageTest()
        {
            ElementWhiteboard image = ImageWhiteboard.InstanceForTestingPurposes();
            testingWhiteboard.AddWhiteboardElement(image);
            CollectionAssert.Contains(testingWhiteboard.Contents.ToList(), image);
        }

        [TestMethod]
        public void WhiteboardAddElementValidTextBoxTest()
        {
            ElementWhiteboard textBox = TextBoxWhiteboard.InstanceForTestingPurposes();
            testingWhiteboard.AddWhiteboardElement(textBox);
            CollectionAssert.Contains(testingWhiteboard.Contents.ToList(), textBox);
        }

        [TestMethod]
        [ExpectedException(typeof(WhiteboardException))]
        public void WhiteboardAddElementNullTest()
        {
            testingWhiteboard.AddWhiteboardElement(null);
        }

        [TestMethod]
        public void WhiteboardRemoveElementValidImageTest()
        {
            ElementWhiteboard image = ImageWhiteboard.InstanceForTestingPurposes();
            testingWhiteboard.AddWhiteboardElement(image);
            testingWhiteboard.RemoveWhiteboardElement(image);
            CollectionAssert.DoesNotContain(testingWhiteboard.Contents.ToList(), image);
        }

        [TestMethod]
        public void WhiteboardRemoveElementValidTextBoxTest()
        {
            ElementWhiteboard textBox = TextBoxWhiteboard.InstanceForTestingPurposes();
            testingWhiteboard.AddWhiteboardElement(textBox);
            testingWhiteboard.RemoveWhiteboardElement(textBox);
            CollectionAssert.DoesNotContain(testingWhiteboard.Contents.ToList(), textBox);
        }

        [TestMethod]
        [ExpectedException(typeof(WhiteboardException))]
        public void WhiteboardRemoveElementNotAMemberImageTest()
        {
            ElementWhiteboard image = ImageWhiteboard.InstanceForTestingPurposes();
            testingWhiteboard.RemoveWhiteboardElement(image);
        }

        [TestMethod]
        [ExpectedException(typeof(WhiteboardException))]
        public void WhiteboardRemoveElementNotAMemberTextBoxTest()
        {
            ElementWhiteboard textBox = TextBoxWhiteboard.InstanceForTestingPurposes();
            testingWhiteboard.RemoveWhiteboardElement(textBox);
        }

        [TestMethod]
        [ExpectedException(typeof(WhiteboardException))]
        public void WhiteboardRemoveElementNullTest()
        {
            testingWhiteboard.RemoveWhiteboardElement(null);
        }

        [TestMethod]
        public void WhiteboardChangeWidthWhenNotEmptyValidTest()
        {
            GenerateNonGenericTestSituation();
            testingWhiteboard.Width = 1150;
        }

        [TestMethod]
        [ExpectedException(typeof(WhiteboardException))]
        public void WhiteboardChangeWidthWhenNotEmptyInvalidTest()
        {
            GenerateNonGenericTestSituation();
            testingWhiteboard.Width = 1;
        }

        [TestMethod]
        public void WhiteboardChangeHeightWhenNotEmptyValidTest()
        {
            GenerateNonGenericTestSituation();
            testingWhiteboard.Height = 500;
        }

        [TestMethod]
        [ExpectedException(typeof(WhiteboardException))]
        public void WhiteboardChangeHeightWhenNotEmptyInvalidTest()
        {
            GenerateNonGenericTestSituation();
            testingWhiteboard.Height = 1;
        }

        [TestMethod]
        public void WhiteboardUserCanRemoveTest()
        {
            Assert.IsTrue(testingWhiteboard.UserCanRemove(testingWhiteboard.Creator));
        }

        [TestMethod]
        public void WhiteboardUserCanRemoveAdministratorTest()
        {
            Administrator someAdministrator = Administrator.NamesEmailBirthdatePassword("Mario",
                "Santos", "santos@simuladores.com", DateTime.Today, "DisculpeFuegoTiene");
            Assert.AreNotEqual(someAdministrator, testingWhiteboard.Creator);
            Assert.IsTrue(testingWhiteboard.UserCanRemove(someAdministrator));
        }

        [TestMethod]
        public void WhiteboardUserCanRemoveUserNonCreatorTest()
        {
            User someOtherUser = User.NamesEmailBirthdatePassword("Emilio", "Ravenna",
                "ravenna@simuladores.com", DateTime.Today, "HablarUnasPalabritas");
            Assert.IsFalse(testingWhiteboard.UserCanRemove(someOtherUser));
        }

        [TestMethod]
        public void WhiteboardUserCanRemoveNullUserTest()
        {
            Assert.IsFalse(testingWhiteboard.UserCanRemove(null));
        }
    }
}