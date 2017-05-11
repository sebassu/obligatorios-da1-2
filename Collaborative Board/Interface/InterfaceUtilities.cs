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
    }
}
