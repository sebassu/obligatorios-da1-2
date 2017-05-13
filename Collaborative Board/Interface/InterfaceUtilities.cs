using System;
using Exceptions;
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

        public static void AskExitApplication()
        {
            DialogResult result = MessageBox.Show("Está seguro que desea salir?", "Salir",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        public static void NotElementSelectedMessageBox()
        {
            DialogResult result = MessageBox.Show("Debe seleccioar un elemento de la lista!",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void GoToHome(Panel systemPanel)
        {
            systemPanel.Controls.Clear();
            systemPanel.Controls.Add(new UCAdministratorHome(systemPanel));
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
