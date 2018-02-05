using System;
using System.Linq;

namespace Stage3_Verification
{
    class Program
    {
        private static void Main(string[] args)
        {
            if (args.Any())
                Extraction.FileType = args[0];

            Extraction.ExtractCsvDataFile();
        }
    }
}
