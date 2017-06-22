using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System;
using Domain;

namespace GraphicInterface
{
    public class PDFConcreteExportingStrategy : ExportingStrategy
    {
        public PDFConcreteExportingStrategy(Panel whiteboardPanel, string whiteboardName)
            : base(whiteboardPanel, whiteboardName) { }

        public override void ExportImage()
        {
            try
            {
                AttemptToGenerateDocument(".pdf",
                "Archivos de texto|*.pdf|Todos los archivos|*.*", SavePDF);
            }
            catch (Exception exceptionCaught)
            {
                InterfaceUtilities.ShowError(exceptionCaught.Message, "Error desconocido");
            }
        }

        private void SavePDF(string fileName)
        {
            Document pdfDocument = new Document(PageSize.A4);
            PdfWriter.GetInstance(pdfDocument, new FileStream(fileName,
                FileMode.Create));
            pdfDocument.Open();
            Image imageToSave = GenerateImageForPDF(pdfDocument);
            pdfDocument.Add(imageToSave);
            pdfDocument.Close();
        }

        private Image GenerateImageForPDF(Document pdfDocument)
        {
            Image imageToSave = Image.GetInstance(GenerateImageOfPanel(), ImageFormat.Jpeg);
            imageToSave.SetAbsolutePosition(1, 1);
            imageToSave.ScaleToFit(pdfDocument.PageSize);
            return imageToSave;
        }
    }
}