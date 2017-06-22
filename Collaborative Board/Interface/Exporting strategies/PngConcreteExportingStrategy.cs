using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System;

namespace GraphicInterface
{
    public class PngConcreteExportingStrategy : ExportingStrategy
    {
        public PngConcreteExportingStrategy(Panel whiteboardPanel, string whiteboardName)
            : base(whiteboardPanel, whiteboardName) { }

        public override void ExportImage()
        {
            try
            {
                AttemptToGenerateDocument(".png",
                "Archivos de imagen|*.png|Todos los archivos|*.*", SaveImage);
            }
            catch (Exception exceptionCaught)
            {
                InterfaceUtilities.ShowError(exceptionCaught.Message, "Error desconocido");
            }
        }

        private void SaveImage(string fileName)
        {
            Bitmap imageToSave = GenerateImageOfPanel();
            imageToSave.Save(fileName, ImageFormat.Png);
        }
    }
}