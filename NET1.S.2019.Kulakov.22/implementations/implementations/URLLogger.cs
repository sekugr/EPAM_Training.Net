namespace Implementations
{
using NLog;

    public class URLLogger : IURLLogger
    {
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public void Log(string message)
        {
            logger.Log(LogLevel.Info, $"No Valid URL: {message}");
        }
    }
}
