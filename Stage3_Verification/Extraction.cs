using System;
using System.IO;
using System.Text;

namespace Stage3_Verification
{
    public class Extraction
    {
        public static string FileType()
        {
            var file = "Deal.csv";
            return file;
        }

        public static StringBuilder ReadFile()
        {
            var jsonString = new StringBuilder();
            using (var sr = new StreamReader(FileType()))
            {
                while (!sr.EndOfStream)
                {
                    jsonString.Append("[");
                    var fulltext = sr.ReadToEnd();
                    var rows = fulltext.Split('\n');
                    var a = rows[0];
                    var b = rows[1];
                    var c = rows[2];
                    var aValues = a.Split("||");
                    var bValues = b.Split("||");
                    var cValues = c.Split("||");

                    for (var i = 0; i <= 2; i++)
                    {
                        jsonString.Append("{");
                        if (i == 0) 
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
                        

                        if (i == 1)
                            for (var k = 0; k < aValues.Length; k++)
                                switch (k)
                                {
                                    case 7:
                                        var v = Validations.Integer_Validator(cValues[k]);
                                        jsonString.Append("\"" + aValues[k] + "\":" + "\"" + v +
                                                          Validations.IntegerType() + "\"");
                                        jsonString.Append(",");
                                        break;
                                    case 12:
                                        var w = Validations.Double_Validation(cValues[k]);
                                        jsonString.Append("\"" + aValues[k] + "\":" + "\"" + w +
                                                          Validations.DoubleType() + "\"");
                                        jsonString.Append(",");
                                        break;
                                    case 5:
                                    case 8:
                                    case 2:
                                        if (cValues[k] == "")
                                        {
                                            Console.WriteLine("Error: ");
                                            var empty = Validations.Error(cValues[k]);
                                            jsonString.Append("\"" + aValues[k] + "\":" + "\"" + empty + "\"");
                                            //break;
                                        }
                                        else
                                        {
                                            var m = Validations.String_Validator(cValues[k]);
                                            jsonString.Append("\"" + aValues[k] + "\":" + "\"" + m + "\"");
                                            jsonString.Append(",");
                                        }

                                        break;
                                    default:
                                        var x = Validations.String_Validator(cValues[k]);
                                        jsonString.Append("\"" + aValues[k] + "\":" + "\"" + x + "\"");
                                        jsonString.Append(",");
                                        break;
                                }
                        else
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
            StreamReader sr = new StreamReader(FileType());
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
            string a = RowCount()[0];
            var rowValues = a.Split("||"); //split each row with || to get individual values
            var value = rowValues.Length;
            return value;

        }

        public static string FileJsType()
        {
            string file = "Vali.json";
            return file;
        }

        public static string ReadJson()
        {
            StreamReader js = new StreamReader(FileJsType());
            string fulltext = js.ReadToEnd();
            return fulltext;
        }

        public static StringBuilder Map()
        {
            StringBuilder jsString = new StringBuilder();
            string a = RowCount()[0];
            string b = RowCount()[1];
            string[] rowValues = a.Split("||");
            string[] bValues = b.Split("||"); //split each row with || to get individual values
            for (int j = 15; j < rowValues.Length; j++)
            {
                jsString.Append("\"" + rowValues[0] + "\":" + "\"" + bValues[0] + "\"");

            }

            return jsString;
        }
    }

}
