using Domain;
using Exceptions;
using Persistence;
using System;
using System.Windows.Forms;

namespace Interface
{
    public static class InterfaceUtilities
    {
        public static void ExcecuteActionOrThrowErrorMessageBox(Action actionToExecute)
        {
            try
            {
                actionToExecute.Invoke();
            }
            catch (BoardException exception)
            {
                MessageBox.Show(exception.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void AskLogOut()
        {
            DialogResult result = MessageBox.Show("Está seguro que desea cerrar sesión?", "Salir",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                HideAllForms();
                Session.End();
                (new Login()).Show();
            }
        }

        private static void HideAllForms()
        {
            foreach (Form oneForm in Application.OpenForms)
            {
                oneForm.Hide();
            }
        }

        public static void NotElementSelectedMessageBox()
        {
            DialogResult result = MessageBox.Show("Debe seleccioar un elemento de la lista!",
                "Error" , MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void GoToHome(Panel systemPanel)
        {
            systemPanel.Controls.Clear();
            systemPanel.Controls.Add(new UCAdministratorHome(systemPanel));
        }

        public static void UCAdministratorTeamsToPanel(Panel systemPanel)
        {
            systemPanel.Controls.Clear();
            systemPanel.Controls.Add(new UCAdministratorTeams(systemPanel));
        }

        public static void UCAdministatorUsersToPanel(Panel systemPanel)
        {
            systemPanel.Controls.Clear();
            systemPanel.Controls.Add(new UCAdministratorUsers(systemPanel));
        }

        public static void UCWhiteboardsToPanel(Panel systemPanel)
        {
            systemPanel.Controls.Clear();
            systemPanel.Controls.Add(new UCWhiteboards(systemPanel));
        }

        /*public static void UCAdministrateTeamToPanel(Panel systemPanel, Team oneTeam)
        {
            systemPanel.Controls.Clear();
            systemPanel.Controls.Add(new UCAdministrateTeam(systemPanel, oneTeam));
        }*/

        public static void UCAddOrModifyUserToPanel(Panel systemPanel, User oneUser = null)
        {
            if (Utilities.IsNotNull(oneUser))
            {
                systemPanel.Controls.Clear();
                systemPanel.Controls.Add(new UCAddOrModifyUser(systemPanel, oneUser));
            }
            else
            {
                systemPanel.Controls.Clear();
                systemPanel.Controls.Add(new UCAddOrModifyUser(systemPanel));
            }
            
        }

        public static void UCAddOrModifyTeamToPanel(Panel systemPanel, Team oneTeam = null)
        {
            if (Utilities.IsNotNull(oneTeam))
            {
                systemPanel.Controls.Clear();
                systemPanel.Controls.Add(new UCAddOrModifyTeam(systemPanel, oneTeam));
            }
            else
            {
                systemPanel.Controls.Clear();
                systemPanel.Controls.Add(new UCAddOrModifyTeam(systemPanel));
            }
        }

    }
}
