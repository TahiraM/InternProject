using System;
using System.Collections.Generic;
using System.Text;

namespace CsvFileConverter
{
    public static class LogHelper
    {
        private static FileLogger logger = null;

        public static void Log(LogTarget target, string message)
        {

            if (target == LogTarget.File)
                logger = new FileLogger();
            logger.Log(message);

        }
    }
}
