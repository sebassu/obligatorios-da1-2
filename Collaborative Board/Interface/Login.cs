using System;
using System.Windows.Forms;
using Persistence;
using Exceptions;

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
                RedirectToCorrectHomeMenu();
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

        private void RedirectToCorrectHomeMenu()
        {
            if (Session.HasAdministrationPrivileges())
            {
                new UserWindow().Show();
            }//hacer else
        }

        private void btnLoadTestData_Click(object sender, EventArgs e)
        {
            GenerateTestData();
        }

        private void GenerateTestData()
        {
            Session.Start("administrator@tf2.com", "Victory");
            TeamRepository globalTeams = TeamRepository.GetInstance();
            UserRepository globalUsers = UserRepository.GetInstance();
            WhiteboardRepository globalWhiteboards = WhiteboardRepository.GetInstance();
            globalUsers.AddNewAdministrator("Mario", "Santos", "santos@simuladores.com", new DateTime(1959,08,10), "disculpeFuegoTiene");
            globalUsers.AddNewUser("Emilio", "Ravenna", "ravenna@simuladores.com", new DateTime(1959, 05, 10), "hablarUnasPalabritas");
            globalUsers.AddNewUser("Pablo", "Lamponne", "lamponne@simuladores.com", new DateTime(1959, 03, 19), "noHaceFaltaSaleSolo");
            globalUsers.AddNewUser("Gabriel David", "Medina", "medina@simuladores.com", new DateTime(1968, 01, 20), "musicaSuperDivertida");
            globalUsers.AddNewAdministrator("Marcos", "Mundstock", "mundstock@lesluthiers.com.ar", new DateTime(1942, 05, 25), "versiculoLIX");
            globalUsers.AddNewUser("Jorge Luis", "Maronna", "maronna@lesluthiers.com.ar", new DateTime(1948, 08, 01), "laNocheEstaOscura123");
            globalUsers.AddNewUser("Carlos Nuñez", "Cortés", "cortes@lesluthiers.com.ar", new DateTime(1942, 10, 15), "YoEraUnInfeliz");
            globalUsers.AddNewUser("Daniel Abraham", "Rabinovich", "rabinovich@lesluthiers.com.ar", new DateTime(1943, 11, 18), "achicoria");
            globalUsers.AddNewUser("Carlos", "Lopez Puccio", "lopezpuccio@lesluthiers.com.ar", new DateTime(1946, 10, 09), "horizontal4Letras");
            Session.End();
            
        }
    }
}
