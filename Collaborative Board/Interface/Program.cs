using System;
using System.Windows.Forms;
using Persistence;
using System.Data;

namespace GraphicInterface
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            try
            {
                UserRepository.InsertOriginalSystemAdministrator();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new LogOn());
            }
            catch (DataException exception)
            {
                InterfaceUtilities.ShowError("Ha ocurrido un error al intentar realizar una acción " +
                    "en la base de datos. La aplicación se cerrará. Detalles: " + exception.Message,
                    "Error fatal");
                Application.Exit();
            }
        }
    }
}
