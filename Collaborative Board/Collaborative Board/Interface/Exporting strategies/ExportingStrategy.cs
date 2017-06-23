using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System;

namespace GraphicInterface
{
    public abstract class ExportingStrategy
    {
        protected static readonly string saveDestination =
            Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName +
            "\\Impresiones de Pizarrón\\";

        private Panel panelToBeExported;
        private string fileNameBeginning;

        protected ExportingStrategy(Panel whiteboardPanel, string whiteboardName)
        {
            try
            {
                Directory.CreateDirectory(saveDestination);
                panelToBeExported = whiteboardPanel;
                fileNameBeginning = whiteboardName;
            }
            catch (Exception exceptionCaught)
            {
                InterfaceUtilities.ShowError(exceptionCaught.Message, "Error desconocido");
            }
        }

        protected Bitmap GenerateImageOfPanel()
        {
            Bitmap result = new Bitmap(panelToBeExported.Width, panelToBeExported.Height);
            panelToBeExported.DrawToBitmap(result, panelToBeExported.ClientRectangle);
            return result;
        }

        protected void AttemptToGenerateDocument(string defaultExtension,
            string extensionFilter, Action<string> actionToExecute)
        {
            using (var dialog = OpenSaveDialog(defaultExtension,
                extensionFilter))
            {
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    CheckIfPathExistsAndSave(dialog, actionToExecute);
                }
            }
        }

        private static SaveFileDialog OpenSaveDialog(string defaultExtension,
            string extensionFilter)
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                OverwritePrompt = true,
                DefaultExt = defaultExtension,
                Filter = extensionFilter
            };
            return dialog;
        }

        private void CheckIfPathExistsAndSave(SaveFileDialog dialog,
            Action<string> actionToExecute)
        {
            if (dialog.CheckPathExists)
            {
                actionToExecute(dialog.FileName);
            }
            else
            {
                InterfaceUtilities.ShowError("La ruta ingresada no es válida, " +
                    "reintente.", "Error");
                AttemptToGenerateDocument(dialog.DefaultExt,
                    dialog.Filter, actionToExecute);
            }
        }

        public abstract void ExportImage();
    }
}