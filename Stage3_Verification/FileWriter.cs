using System;
using System.IO;

namespace Stage3_Verification
{
   public class FileWriter : IFileWriter
    {
        public void WriteContent(string output, string data, bool overwrite = true)
        {
            if (overwrite == false && File.Exists(output))
                throw new ApplicationException($"File {output} is exists and can't be replaced");

            File.WriteAllText(output, data);
        }

        
    }
}
