using System;

public class FileLogger : LoggerMessage
{
    public string FilePath = "LoggingFile.txt";

    public override void Log(string message)
    {
        using (var writer = new StreamWriter(FilePath))
        {
            writer.WriteLine(message);
            writer.Close();
        }
    }
}
