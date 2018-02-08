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

        public static string FileJsonType { get; set; } = "Vali.json";
        public static StringBuilder jsonString = new StringBuilder();


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


        public static string[] RowValueString(int i)
        {
            var a = NumberofRows()[i];
            var rowValues = a.Split("||"); //split each row with || to get individual values
            return rowValues;
        }

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

        public static StringBuilder ValidationOfInterger(int row, int column)
        {
            var v = Validations.Integer_Validator(RowValueString(row)[column]);
           jsonString.Append("\"" + RowValueString(0)[column] + "\":" + "\"" + v +
                              Validations.IntegerType() + "\"");
            jsonString.Append(",");

            return jsonString;
        }
        public static StringBuilder ValidationOfDouble(int row, int column)
        {
            var w = Validations.Double_Validation(RowValueString(row)[column]);
            jsonString.Append("\"" + RowValueString(0)[column] + "\":" + "\"" + w +
                              Validations.DoubleType() + "\"");
            jsonString.Append(",");

            return jsonString;
        }

        public static StringBuilder ExtractCsvDataFile()
        {
            
            using (var sr = new StreamReader(FileType))
            {
               
                
                    jsonString.Append("[");


                    for (var i = 1; 
                        i <= NumberofRows().Length - 1; i++)
                    {
                        // var headerNames = RowValueString();
                        //var rowDataValues = RowValueString(i);
                        jsonString.Append("{");
                        for (var j = 0; j < RowValueString(0).Length; j++)
                            switch (j)
                            {
                                case 7:
                                case 5:
                                    ValidationOfInterger(i, j);
                                    break;
                                case 12:
                                ValidationOfDouble(i, j);
                                break;
                                case 0:
                                case 1:
                                case 2:
                                case 8:
                                    if (RowValueString(i)[j] == "")
                                    {
                                        Console.WriteLine("Error: ");
                                        var empty = Validations.Error(RowValueString(i)[j]);
                                        jsonString.Append("\"" + RowValueString(0)[j] + "\":" + "\"" + empty + "\"");
                                        //break;
                                    }
                                    else
                                    {
                                        var m = Validations.String_Validator(RowValueString(i)[j]);
                                        jsonString.Append("\"" + RowValueString(0)[j] + "\":" + "\"" + m + "\"");
                                        jsonString.Append(",");
                                    }

                                    break;
                                default:
                                    var x = Validations.String_Validator(RowValueString(i)[j]);
                                    jsonString.Append("\"" + RowValueString(0)[j] + "\":" + "\"" + x + "\"");
                                    jsonString.Append(",");
                                    break;
                            }
                        jsonString.Append("},");
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
    }
}