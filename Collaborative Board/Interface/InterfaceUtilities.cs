using Exceptions;
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

        public static void AskExitApplication()
        {
            DialogResult result = MessageBox.Show("Está seguro que desea salir?", "Salir",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        public static void GoToHome(Panel systemPanel)
        {
            systemPanel.Controls.Clear();
            systemPanel.Controls.Add(new UCAdministratorHome(systemPanel));
        }

        


    }
}
