using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System;
using System.Globalization;

namespace Interface
{
    public abstract class ExportingStrategy
    {
        protected static readonly string saveDestination =
            Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName +
            "\\Impresiones de Pizarrón\\";

        private Panel panelToBeExported;
        private string fileNameBeginning;

        public ExportingStrategy(Panel whiteboardPanel, string whiteboardName)
        {
            Directory.CreateDirectory(saveDestination);
            panelToBeExported = whiteboardPanel;
            fileNameBeginning = whiteboardName;
        }

        protected Bitmap GenerateImageOfPanel()
        {
            Bitmap result = new Bitmap(panelToBeExported.Width, panelToBeExported.Height);
            panelToBeExported.DrawToBitmap(result, panelToBeExported.ClientRectangle);
            return result;
        }

        protected string GeneratePathToSave()
        {
            return saveDestination + fileNameBeginning + " - " +
                DateTime.Now.ToString("d/M/yyyy, h.mm.ss tt", CultureInfo.CurrentCulture);
        }

        public abstract void ExportImage();
    }
}