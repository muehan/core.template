namespace core.template.infrastructure
{
    using NLog;

    public class LogTo
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static void Error(string message)
        {
            logger.Error(message);
        }

        public static void Info(string message)
        {
            logger.Info(message);
        }
    }
}
