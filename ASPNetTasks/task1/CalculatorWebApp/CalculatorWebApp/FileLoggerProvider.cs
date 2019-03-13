using Microsoft.Extensions.Logging;

namespace CalculatorWebApp
{
    public class FileLoggerProvider : ILoggerProvider
    {
        private readonly string _path;
        public FileLoggerProvider(string path)
        {
            this._path = path;
        }
        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger(_path);
        }
 
        public void Dispose()
        {
        }
    }
}