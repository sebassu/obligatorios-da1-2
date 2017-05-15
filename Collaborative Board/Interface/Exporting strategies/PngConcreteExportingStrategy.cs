using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Interface
{
    public class PngConcreteExportingStrategy : ExportingStrategy
    {
        public PngConcreteExportingStrategy(Panel whiteboardPanel, string whiteboardName)
            : base(whiteboardPanel, whiteboardName) { }

        public override void ExportImage()
        {
            Bitmap imageToSave = GenerateImageOfPanel();
            imageToSave.Save(GeneratePathToSave() + ".gif", ImageFormat.Png);
        }
    }
}
