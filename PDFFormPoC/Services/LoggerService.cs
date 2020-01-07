using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PDFFormPoC.Services
{
    public static class LoggerService
    {
        public static void WriteLog(String msg)
        {
            string logPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

            // Append text to an existing file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(logPath, "PDFFormPoCLogs.txt"), true))
            {
                Console.WriteLine(msg);
                outputFile.WriteLine(msg);
            }
            

        }
    }
}
