using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace KopitekCounter
{
    class Logger
    {
        public void ErrorLog(string message)
        {
            
            try
            {
                var path = @"C:\kopitek\errorlogs";
                
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
               
                string errorFilePath = Path.Combine(path, "Errors.log");
                using (var streamWriter = new StreamWriter(errorFilePath, true))
                {
                    streamWriter.WriteLine(DateTime.Now.ToString() + " " + message);
                }


            }
            catch
            {

            }
        
        }
    }
}
