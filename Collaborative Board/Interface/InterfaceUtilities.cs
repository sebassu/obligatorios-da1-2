using Domain;
using Exceptions;
using Persistence;
using System;
using System.Windows.Forms;
using System.Globalization;

namespace Interface
{
    public static class InterfaceUtilities
    {
        public static void ExcecuteActionOrThrowErrorMessageBox(Action actionToExecute)
        {
            try
            {
                actionToExecute.Invoke();
                SuccesfulOperation();
            }
            catch (BoardException exception)
            {
                ShowError(exception.Message, "Error");
            }
        }

        public static void ShowError(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void AskLogOut()
        {
            DialogResult result = MessageBox.Show("Está seguro que desea cerrar sesión?", "Salir",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                EndSessionAndGoToLogInForm();
            }
        }

        public static void EndSessionAndGoToLogInForm()
        {
            HideAllForms();
            Session.End();
            (new Login()).Show();
        }

        public static void SuccesfulOperation()
        {
            DialogResult result = MessageBox.Show("La operación se completo exitosamente.", "Operación exitosa",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            DialogResult result = MessageBox.Show("Debe seleccionar un elemento de la lista!",
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

        public static void UCAdministrateTeamToPanel(Panel systemPanel, Team oneTeam)
        {
            systemPanel.Controls.Clear();
            systemPanel.Controls.Add(new UCAdministrateTeam(systemPanel, oneTeam));
        }

        public static void UCAddOrModifyUserToPanel(Panel systemPanel, User oneUser = null)
        {
            systemPanel.Controls.Clear();
            if (Utilities.IsNotNull(oneUser))
            {  
                systemPanel.Controls.Add(new UCAddOrModifyUser(systemPanel, oneUser));
            }
            else
            {
                systemPanel.Controls.Add(new UCAddOrModifyUser(systemPanel));
            }
            
        }

        public static void UCAddOrModifyTeamToPanel(Panel systemPanel, Team oneTeam = null)
        {
            systemPanel.Controls.Clear();
            if (Utilities.IsNotNull(oneTeam))
            {
                systemPanel.Controls.Add(new UCAddOrModifyTeam(systemPanel, oneTeam));
            }
            else
            {
                systemPanel.Controls.Add(new UCAddOrModifyTeam(systemPanel));
            }
        }

        public static void UCAddOrModifyWhiteboardToPanel(Panel systemPanel, Whiteboard oneWhiteboard = null)
        {
            systemPanel.Controls.Clear();
            if (Utilities.IsNotNull(oneWhiteboard))
            {
                systemPanel.Controls.Add(new UCAddOrModifyWhiteboard(systemPanel, oneWhiteboard));
            }
            else
            {
                systemPanel.Controls.Add(new UCAddOrModifyWhiteboard(systemPanel));
            }  
        }

        public static string GetDateToShow(DateTime someDate)
        {
            if (someDate != DateTime.MinValue)
            {
                return someDate.ToString("d", CultureInfo.CurrentCulture);
            }
            else
            {
                return "N/a";
            }
        }
    }
}