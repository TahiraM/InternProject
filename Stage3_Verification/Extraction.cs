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

        public static StringBuilder ReadFile()
        {
            var jsonString = new StringBuilder();
            using (var sr = new StreamReader(FileType))
            {
                while (!sr.EndOfStream)
                {
                    jsonString.Append("[");
                    var fulltext = sr.ReadToEnd();
                    var rows = fulltext.Split('\n');
                    var a = rows[0];

                    var aValues = a.Split("||");


                    for (var i = 1; i <= rows.Length - 1; i++)
                    {
                        var b = rows[i];
                        var bValues = b.Split("||");
                        jsonString.Append("{");
                        for (var j = 0; j < aValues.Length; j++)
                            switch (j)
                            {
                                case 7:
                                case 5:
                                    var v = Validations.Integer_Validator(bValues[j]);
                                    jsonString.Append("\"" + aValues[j] + "\":" + "\"" + v +
                                                      Validations.IntegerType() + "\"");
                                    jsonString.Append(",");
                                    break;
                                case 12:
                                    var w = Validations.Double_Validation(bValues[j]);
                                    jsonString.Append("\"" + aValues[j] + "\":" + "\"" + w +
                                                      Validations.DoubleType() + "\"");
                                    jsonString.Append(",");
                                    break;
                                case 0:
                                case 1:
                                case 2:
                                case 8:
                                    if (bValues[j] == "")
                                    {
                                        Console.WriteLine("Error: ");
                                        var empty = Validations.Error(bValues[j]);
                                        jsonString.Append("\"" + aValues[j] + "\":" + "\"" + empty + "\"");
                                        //break;
                                    }
                                    else
                                    {
                                        var m = Validations.String_Validator(bValues[j]);
                                        jsonString.Append("\"" + aValues[j] + "\":" + "\"" + m + "\"");
                                        jsonString.Append(",");
                                    }

                                    break;
                                default:
                                    var x = Validations.String_Validator(bValues[j]);
                                    jsonString.Append("\"" + aValues[j] + "\":" + "\"" + x + "\"");
                                    jsonString.Append(",");
                                    break;
                            }
                        jsonString.Append("}");
                    }
                }

                jsonString.Append("]");
            }

            Console.WriteLine(jsonString);
            var sjson = new FileStream("Vali.json", FileMode.OpenOrCreate, FileAccess.Write);
            var addJ = new StreamWriter(sjson);
            Console.SetOut(addJ);
            Console.Write(jsonString);
            Console.SetOut(Console.Out);
            addJ.Close();
            sjson.Close();
            return jsonString;
        }


        public static StreamReader Read()
        {
            var sr = new StreamReader(FileType);
            return sr;
        }

        public static string[] RowCount()
        {
            var fulltext = Read().ReadToEnd();
            var rows = fulltext.Split('\n');


            return rows;
        }


        public static int Values()
        {
            var a = RowCount()[0];
            var rowValues = a.Split("||"); //split each row with || to get individual values
            var value = rowValues.Length;
            return value;
        }

        public static string FileJsType()
        {
            var file = "Vali.json";
            return file;
        }

        public static string ReadJson()
        {
            var js = new StreamReader(FileJsType());
            var fulltext = js.ReadToEnd();
            return fulltext;
        }

        public static StringBuilder Map()
        {
            var jsString = new StringBuilder();
            var a = RowCount()[0];
            var b = RowCount()[1];
            var rowValues = a.Split("||");
            var bValues = b.Split("||"); //split each row with || to get individual values
            for (var j = 15; j < rowValues.Length; j++)
                jsString.Append("\"" + rowValues[0] + "\":" + "\"" + bValues[0] + "\"");

            return jsString;
        }
    }
}