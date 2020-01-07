using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Aspose.Pdf.Facades;
using Aspose.Pdf.Forms;
using Microsoft.Extensions.Configuration;

namespace PDFFormPoC.Services
{
    public static class PDFService
    {
        public static Aspose.Pdf.Facades.Form LoadPDFDoc()
        {
            Aspose.Pdf.Facades.Form pdfForm = new Aspose.Pdf.Facades.Form();
            pdfForm.BindPdf(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\SampleDoc\\PdfFormSample.pdf");
            return pdfForm;
        }

        public static Aspose.Pdf.Facades.Form ReadPDFForm(Aspose.Pdf.Facades.Form pdfForm)
        {
            string[] fields = pdfForm.FieldNames;
            foreach (String field in fields)
            {
                LoggerService.WriteLog(field);
            }
            
            return pdfForm;
        }

        public static Boolean WritePDFForm(Aspose.Pdf.Facades.Form pdfForm,IConfiguration sampleData)
        {
            foreach (KeyValuePair<string, string> data in sampleData.AsEnumerable())
            {
                LoggerService.WriteLog(data.Key);
                LoggerService.WriteLog(data.Value);
                pdfForm.FillField(data.Key, data.Value);                
            }
            
            pdfForm.Document.Flatten();

            // Save updated file
            pdfForm.Save(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\SampleDoc\\OutputPdfFormSample.pdf");
            return true;
        }
    }
}
