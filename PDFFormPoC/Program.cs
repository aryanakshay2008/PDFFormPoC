using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;
using Aspose.Pdf.Facades;
using PDFFormPoC.Services;
using System.IO;
using System.Collections.Generic;

namespace PDFFormPoC
{
    class Program
    {
        static void Main(string[] args)
        {
            LoggerService.WriteLog("Initailizing POC...");
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            IConfiguration config = builder.Build();

            Form pdfTemplate = PDFService.LoadPDFDoc();
            LoggerService.WriteLog("Listing all PDF template form fields..");
            PDFService.ReadPDFForm(pdfTemplate);

            LoggerService.WriteLog("Setting initial value for PDF and creating output file..");
            PDFService.WritePDFForm(pdfTemplate, config);
        }
    }
}
