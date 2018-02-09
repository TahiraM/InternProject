using System.Linq;

namespace Stage3_Verification
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Any())
                Extraction.FileType = args[0];

            Extraction.ExtractCsvDataFile();
        }
    }
}