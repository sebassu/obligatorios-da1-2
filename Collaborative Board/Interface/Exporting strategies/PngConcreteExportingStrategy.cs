using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System;

namespace Interface
{
    public class PngConcreteExportingStrategy : ExportingStrategy
    {
        public PngConcreteExportingStrategy(Panel whiteboardPanel, string whiteboardName)
            : base(whiteboardPanel, whiteboardName) { }

        public override void ExportImage()
        {
            try
            {
                AttemptToGenerateImage();
            }
            catch (Exception exceptionCaught)
            {
                InterfaceUtilities.ShowError(exceptionCaught.Message, "Error desconocido");
            }
        }

        private void AttemptToGenerateImage()
        {
            Bitmap imageToSave = GenerateImageOfPanel();
            imageToSave.Save(GeneratePathToSave() + ".gif", ImageFormat.Png);
        }
    }
}