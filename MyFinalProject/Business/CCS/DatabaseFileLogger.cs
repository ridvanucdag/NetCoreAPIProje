using System;

namespace Business.CCS
{
    public class DatabaseFileLogger : ILogger
    {
        public void log()
        {
            Console.WriteLine("Veritabanına loglandı");
        }
    }
}
