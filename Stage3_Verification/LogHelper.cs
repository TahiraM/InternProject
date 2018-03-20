namespace CsvFileConverter
{
    public static class LogHelper
    {
        private static FileLogger logger;

        public static void Log(LogTarget target, string message)
        {
            if (target == LogTarget.File)
                logger = new FileLogger();
            logger.Log(message);
        }
    }
}