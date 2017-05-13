using System;
using System.Windows.Forms;
using Persistence;
using Exceptions;
using Domain;

namespace Interface
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                AttemptLogin();
                new UserWindow().Show();
                Hide();
            }
            catch (BoardException exception)
            {
                MessageBox.Show(exception.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Text = "";
            }
        }

        private void AttemptLogin()
        {
            Session.Start(txtEmail.Text, txtPassword.Text);
        }

        private void BtnLoadTestData_Click(object sender, EventArgs e)
        {
            InterfaceUtilities.ExcecuteActionOrThrowErrorMessageBox(GenerateTestData);
        }

        private void GenerateTestData()
        {
            try
            {
                Session.Start("administrator@tf2.com", "Victory");
                TeamRepository globalTeams = TeamRepository.GetInstance();
                UserRepository globalUsers = UserRepository.GetInstance();
                WhiteboardRepository globalWhiteboards = WhiteboardRepository.GetInstance();
                globalUsers.AddNewAdministrator("Mario", "Santos", "santos@simuladores.com", new DateTime(1966, 10, 04), "disculpeFuegoTiene");
                User ravenna = globalUsers.AddNewUser("Emilio", "Ravenna", "ravenna@simuladores.com", new DateTime(1963, 02, 25), "hablarUnasPalabritas");
                User lamponne = globalUsers.AddNewUser("Pablo", "Lamponne", "lamponne@simuladores.com", new DateTime(1969, 07, 05), "noHaceFaltaSaleSolo");
                User medina = globalUsers.AddNewUser("Gabriel David", "Medina", "medina@simuladores.com", new DateTime(1960, 11, 20), "musicaSuperDivertida");
                globalUsers.AddNewAdministrator("Marcos", "Mundstock", "mundstock@lesluthiers.com.ar", new DateTime(1942, 05, 25), "versiculoLIX");
                User maronna = globalUsers.AddNewUser("Jorge Luis", "Maronna", "maronna@lesluthiers.com.ar", new DateTime(1948, 08, 01), "laNocheEstaOscura123");
                User cortes = globalUsers.AddNewUser("Carlos Nuñez", "Cortés", "cortes@lesluthiers.com.ar", new DateTime(1942, 10, 15), "YoEraUnInfeliz");
                User rabinovich = globalUsers.AddNewUser("Daniel Abraham", "Rabinovich", "rabinovich@lesluthiers.com.ar", new DateTime(1943, 11, 18), "achicoria");
                User lopezPuccio = globalUsers.AddNewUser("Carlos", "Lopez Puccio", "lopezpuccio@lesluthiers.com.ar", new DateTime(1946, 10, 09), "horizontal4Letras");
                User daly = globalUsers.AddNewAdministrator("Charles Jerome", "Daly", "daly@dreamteam.com", new DateTime(1930, 07, 20), "chuckCoach1992");
                User johnson = globalUsers.AddNewUser("Earvin Magic", "Johnson", "magic@dreamteam.com", new DateTime(1959, 08, 14), "magic32johnson");
                User jordan = globalUsers.AddNewUser("Michael Jeffrey", "Jordan", "jordan@dreamteam.com", new DateTime(1963, 02, 17), "suMajestadMJ23");
                User bird = globalUsers.AddNewUser("Larry Joe", "Bird", "bird@dreamteam.com", new DateTime(1956, 12, 07), "larryLegend33");
                User barkley = globalUsers.AddNewUser("Charles Wade", "Barkley", "barkley@dreamteam.com", new DateTime(1963, 02, 20), "SirCharlesChuck");
                User ewing = globalUsers.AddNewUser("Patrick Aloysius", "Ewing", "ewing@dream.com", new DateTime(1962, 08, 05), "HoyaDestroya");
                Session.End();

                Session.Start("santos@simuladores.com", "disculpeFuegoTiene");
                Team losSimuladores = globalTeams.AddNewTeam("Los Simuladores", "Un grupo de gente que resuelve " +
                    "cualquier tipo de problemas.", 4);
                globalTeams.AddMemberToTeam(losSimuladores, ravenna);
                globalTeams.AddMemberToTeam(losSimuladores, lamponne);
                globalTeams.AddMemberToTeam(losSimuladores, medina);
                globalWhiteboards.AddNewWhiteboard("El vengador infantil", "Concurso de super héroes infantiles.", losSimuladores, 1000, 1000);
                Session.End();

                Session.Start("mundstock@lesluthiers.com.ar", "versiculoLIX");
                Team lesLuthiers = globalTeams.AddNewTeam("Les Luthiers", "Grupo de seguidores de Johan Sebastian" +
                    " Maestropiero.", 5);
                globalTeams.AddMemberToTeam(lesLuthiers, maronna);
                globalTeams.AddMemberToTeam(lesLuthiers, cortes);
                globalTeams.AddMemberToTeam(lesLuthiers, rabinovich);
                globalTeams.AddMemberToTeam(lesLuthiers, lopezPuccio);
                globalWhiteboards.AddNewWhiteboard("El sendero de Warren Sanchez", "Libertad bajo fianza.", lesLuthiers, 450, 550);
                globalWhiteboards.AddNewWhiteboard("Mastropiero que nunca", "Una de nuestras mejores obras.", lesLuthiers, 800, 800);
                Session.End();

                Session.Start("daly@dreamteam.com", "chuckCoach1992");
                Team dreamTeam = globalTeams.AddNewTeam("Dream Team", "El mejor equipo de baloncesto de la historia.", 6);
                globalTeams.AddMemberToTeam(dreamTeam, johnson);
                globalTeams.AddMemberToTeam(dreamTeam, jordan);
                globalTeams.AddMemberToTeam(dreamTeam, bird);
                globalTeams.AddMemberToTeam(dreamTeam, barkley);
                globalTeams.AddMemberToTeam(dreamTeam, ewing);
                globalWhiteboards.AddNewWhiteboard("UCLA", "Se realiza la jugada con corte UCLA.", dreamTeam, 500, 500);
                Session.End();

                Session.Start("jordan@dreamteam.com", "suMajestadMJ23");
                globalWhiteboards.AddNewWhiteboard("MVP", "Mejor jugador del campeonato.", dreamTeam, 1200, 1200);
                globalWhiteboards.AddNewWhiteboard("Changed the game", "Cambio la forma del juego.", dreamTeam, 900, 900);
                Session.End();

                Session.Start("barkley@dreamteam.com", "SirCharlesChuck");
                globalWhiteboards.AddNewWhiteboard("No Rings", "El señor nunca ha ganado un anillo de NBA, de ahí su " +
                    "odio a Michael Jordan.", dreamTeam, 350, 650);
                Session.End();

                Session.Start("rabinovich@lesluthiers.com.ar", "achicoria");
                globalWhiteboards.AddNewWhiteboard("Lazy Daisy", "El mejor monólogo de la historia.", lesLuthiers, 950, 950);
                globalWhiteboards.AddNewWhiteboard("Esther Piscore", "El merengue es un delicioso postre.", lesLuthiers, 1500, 1500);
                Session.End();

                Session.Start("maronna@lesluthiers.com.ar", "laNocheEstaOscura123");
                globalWhiteboards.AddNewWhiteboard("La payada de la vaca", "Nombreme usted el animal, nombreme usted el animal que " +
                    "no es toro ni cebú", lesLuthiers, 1500, 1200);
                Session.End();

                Session.Start("lopezpuccio@lesluthiers.com.ar", "horizontal4Letras");
                globalWhiteboards.AddNewWhiteboard("Kathy la reina del saloon", "Avant garder", lesLuthiers, 860, 960);
                Session.End();

                Session.Start("medina@simuladores.com", "musicaSuperDivertida");
                globalWhiteboards.AddNewWhiteboard("El debilitador social", "Trata sobre bulimia", losSimuladores, 500, 600);
                globalWhiteboards.AddNewWhiteboard("El matrimonio mixto", "Trata sobre un matrimonio imposible.", losSimuladores, 500, 600);
                globalWhiteboards.AddNewWhiteboard("Los impresentables", "Trata sobre una pareja que desea casarse. La familia del novio es " +
                    "muy informal, casi imprentable. Mientras que la de la novia es todo lo contrario.", losSimuladores, 840, 840);
                globalWhiteboards.AddNewWhiteboard("El pequeño problema del gran hombre", "Trata sobre el problema de impotencia sexual del " +
                    "presidente de la nación.", losSimuladores, 400, 500);
                Session.End();
            }
            catch (BoardException)
            {
                throw new BoardException("Los datos de prueba ya habían sido cargados.");
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
