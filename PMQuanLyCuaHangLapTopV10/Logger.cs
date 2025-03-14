using System;
using System.IO;

namespace PMQuanLyCuaHangLapTopV10
{
    class Logger
    {
        private string logFilePath = "debug.log";
        private static Logger instance; // Singleton instance
        private static readonly object lockObject = new object(); // Lock object for thread safety

        // Constructor (private for Singleton pattern)
        private Logger()
        {
            // Optionally, create the log file if it doesn't exist:
            if (!File.Exists(logFilePath))
            {
                try
                {
                    File.Create(logFilePath).Close(); // Create and immediately close to release the lock
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error creating log file: {ex.Message}");
                    // Consider throwing an exception or taking other action here,
                    // as logging might be critical.
                }
            }
        }

        // Singleton pattern implementation
        public static Logger Instance(string filePath = "application.log")
        {
            if (instance == null)
            {
                lock (lockObject) // Thread safety
                {
                    if (instance == null)
                    {
                        instance = new Logger();
                    }
                }
            }
            return instance;
        }


        // Method to log information
        public void LogInformation(string message)
        {
            Log(message, "INFO");
        }

        // Method to log warnings
        public void LogWarning(string message)
        {
            Log(message, "WARN");
        }

        // Method to log errors
        public void LogError(string message)
        {
            Log(message, "ERROR");
        }

        // Method to log exceptions
        public void LogException(Exception ex)
        {
            Log($"Exception: {ex.Message}\nStack Trace: {ex.StackTrace}", "ERROR");
        }

        // Core logging method
        private void Log(string message, string level)
        {
            try
            {
                lock (lockObject) // Thread safety for file access
                {
                    using (StreamWriter writer = File.AppendText(logFilePath))
                    {
                        writer.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] {message}");
                        writer.Flush(); // Ensure the data is written immediately
                    }
                }
            }
            catch (Exception ex)
            {
                // If logging fails, you can't log *that* error to the log file.
                // So, you'll need to handle it in a different way.
                Console.Error.WriteLine($"Error writing to log file: {ex.Message}");
            }
        }
    }
}