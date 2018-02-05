using System;
using System.IO;
using System.Text;

namespace Stage3_Verification
{
    public class Extraction
    {
        // TODO: FileType should be parameteric
//        public static string FileType()
//        {
//            var file = "Deal.csv";
//            return file;
//        }
//

        // TODO: Think about how you break your long method
        // TODO: Think on the naming convention
        // TODO: Think about Reading/Writing json
        // TODO: Error Handling
        // Static? - method that does not need an instance

        public static string FileType { get; set; } = "Deal.csv";

        public static StringBuilder ExtractCsvDataFile()
        {
            var jsonString = new StringBuilder();
            using (var sr = new StreamReader(FileType))
            {
                while (!sr.EndOfStream)
                {
                    jsonString.Append("[");
                    var fulltext = sr.ReadToEnd();
                    var rows = fulltext.Split('\n');
                    var headers = rows[0];

                    var headerNames = headers.Split("||");


                    for (var i = 1; i <= rows.Length - 1; i++)
                    {
                        var RowData = rows[i];
                        var RowDataValues = RowData.Split("||");
                        jsonString.Append("{");
                        for (var j = 0; j < headerNames.Length; j++)
                            switch (j)
                            {
                                case 7:
                                case 5:
                                    var v = Validations.Integer_Validator(RowDataValues[j]);
                                    jsonString.Append("\"" + headerNames[j] + "\":" + "\"" + v +
                                                      Validations.IntegerType() + "\"");
                                    jsonString.Append(",");
                                    break;
                                case 12:
                                    var w = Validations.Double_Validation(RowDataValues[j]);
                                    jsonString.Append("\"" + headerNames[j] + "\":" + "\"" + w +
                                                      Validations.DoubleType() + "\"");
                                    jsonString.Append(",");
                                    break;
                                case 0:
                                case 1:
                                case 2:
                                case 8:
                                    if (RowDataValues[j] == "")
                                    {
                                        Console.WriteLine("Error: ");
                                        var empty = Validations.Error(RowDataValues[j]);
                                        jsonString.Append("\"" + headerNames[j] + "\":" + "\"" + empty + "\"");
                                        //break;
                                    }
                                    else
                                    {
                                        var m = Validations.String_Validator(RowDataValues[j]);
                                        jsonString.Append("\"" + headerNames[j] + "\":" + "\"" + m + "\"");
                                        jsonString.Append(",");
                                    }

                                    break;
                                default:
                                    var x = Validations.String_Validator(RowDataValues[j]);
                                    jsonString.Append("\"" + headerNames[j] + "\":" + "\"" + x + "\"");
                                    jsonString.Append(",");
                                    break;
                            }
                        jsonString.Append("},");
                    }
                }

                jsonString.Append("]");
            }

            Console.WriteLine(jsonString);
            var jsonDataFile = new FileStream("Vali.json", FileMode.OpenOrCreate, FileAccess.Write);
            var createJsonFile = new StreamWriter(jsonDataFile);
            Console.SetOut(createJsonFile);
            Console.Write(jsonString);
            Console.SetOut(Console.Out);
            createJsonFile.Close();
            jsonDataFile.Close();
            return jsonString;
        }


        public static StreamReader CsvFileReader()
        {
            var sr = new StreamReader(FileType);
            return sr;
        }

        public static string[] NumberofRows()
        {
            var fulltext = CsvFileReader().ReadToEnd();
            var rows = fulltext.Split('\n');


            return rows;
        }


        public static int NumberofColumns()
        {
            var a = NumberofRows()[0];
            var rowValues = a.Split("||"); //split each row with || to get individual values
            var value = rowValues.Length;
            return value;
        }

        public static string FileJsonType { get; set; } = "Vali.json";
       

        public static string JsonFileReader()
        {
            var js = new StreamReader(FileJsonType);
            var fulltext = js.ReadToEnd();
            return fulltext;
        }

        public static StringBuilder HeaderToDataMapping()
        {
            var jsString = new StringBuilder();
            var a = NumberofRows()[0];
            var b = NumberofRows()[1];
            var rowValues = a.Split("||");
            var bValues = b.Split("||"); //split each row with || to get individual values
            for (var j = 15; j < rowValues.Length; j++)
                jsString.Append("\"" + rowValues[0] + "\":" + "\"" + bValues[0] + "\"");

            return jsString;
        }
    }
}