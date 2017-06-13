using System;
using System.Windows.Forms;
using Persistence;

namespace GraphicInterface
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LogOn());*/
            UserRepository.AddNewAdministrator("a", "a", "a@a.com", DateTime.Now, "aaa121a2a");
        }
    }
}
