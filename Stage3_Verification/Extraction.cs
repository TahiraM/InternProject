using System;
using System.IO;
using System.Text;

namespace Stage3_Verification
{
    public class Extraction
    {
        public static StringBuilder JsonString = new StringBuilder();
        // TODO: FileType should be parameteric
        
        // TODO: Think on the naming convention
        // TODO: Think about Reading/Writing json
        // TODO: Error Handling
        // Static? - method that does not need an instance

        public static string FileType { get; set; } = "Deal.csv";

        public static string FileJsonType { get; set; } = "Vali.json";


        public static StreamReader CsvFileReader()
        {
            var sr = new StreamReader(FileType);
            return sr;
        }

        public static string[] NumberofRows()
        {
            var fulltext = CsvFileReader().ReadToEnd();
            var rows = fulltext.Split('\n');
            Console.WriteLine("Rows Split. No of rows: "+rows.Length);
            return rows;
        }


        public static string[] RowValueString(int i)
        {
            var a = NumberofRows()[i];
            var rowValues = a.Split("||"); //split each row with || to get individual values
            Console.WriteLine("Headers Split. No of Headers: " + rowValues.Length);
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
                jsString.Append(  "");

            return jsString;
        }

        public static StringBuilder ValidationOfInterger(int row, int column)
        {
            var v = Validations.Integer_Validator(RowValueString(row)[column]);
            JsonString.Append("\"" + RowValueString(0)[column] + "\":" + "\"" + v +
                              Validations.IntegerType() + "\"");
            JsonString.Append(",");

            return JsonString;
        }

        public static StringBuilder ValidationOfDouble(int row, int column)
        {
            var w = Validations.Double_Validation(RowValueString(row)[column]);
            JsonString.Append("\"" + RowValueString(0)[column] + "\":" + "\"" + w +
                              Validations.DoubleType() + "\"");
            JsonString.Append(",");

            return JsonString;
        }

        public static StringBuilder ErrorValidationString(int row, int column)
        {
            if (RowValueString(row)[column] == "")
            {
                Console.WriteLine("Error: ");
                var empty = Validations.Error(RowValueString(row)[column]);
                JsonString.Append("\"" + RowValueString(0)[column] + "\":" + "\"" + empty + "\"");
                return JsonString;
            }

            var m = Validations.String_Validator(RowValueString(row)[column]);
            JsonString.Append("\"" + RowValueString(0)[column] + "\":" + "\"" + m + "\"");
            JsonString.Append(",");
            return JsonString;
        }

        public static StringBuilder ValidationOfString(int row, int column)
        {
            var x = Validations.String_Validator(RowValueString(row)[column]);
            JsonString.Append("\"" + RowValueString(0)[column] + "\":" + "\"" + x + "\"");
            JsonString.Append(",");

            return JsonString;
        }

        public static StringBuilder CreateJsonTextFile()
        {
            Console.WriteLine(JsonString);
            var jsonDataFile = new FileStream("Vali.json", FileMode.OpenOrCreate, FileAccess.Write);
            var createJsonFile = new StreamWriter(jsonDataFile);
            Console.SetOut(createJsonFile);
            Console.Write(JsonString);
            Console.SetOut(Console.Out);
            createJsonFile.Close();
            jsonDataFile.Close();

            return JsonString;
        }

        public static StringBuilder ExtractCsvDataFile()
        {
            using (CsvFileReader())
            {
                JsonString.Append("[");


                for (var i = 1;
                    i <= NumberofRows().Length - 1;
                    i++)
                {
                    // var headerNames = RowValueString();
                    //var rowDataValues = RowValueString(i);
                    JsonString.Append("{");
                    for (var j = 0; j < RowValueString(0).Length; j++)
                        switch (j)
                        {
                            case 7:
                            case 5:
                                ValidationOfInterger(i, j);
                                break;
                            case 11:
                            case 12:
                                ValidationOfDouble(i, j);
                                break;
                            case 0:
                            case 1:
                            case 2:
                            case 8:
                                ErrorValidationString(i, j);
                                break;
                            default:
                                ValidationOfString(i, j);
                                break;
                        }
                    JsonString.Append("},");
                }

                JsonString.Append("]");
            }

            CreateJsonTextFile();
            return JsonString;
        }
    }
}