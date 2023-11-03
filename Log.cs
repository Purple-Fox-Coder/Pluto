using System.Diagnostics;

namespace Pluto
{
    /**
     * class by:
     * Anna Robinson
     * 
     * Adds quick, easy, and effective functions for logging and debug.
     * 
     * API - meant to log commands from APIs you are using
     * Write - just writes to the console normally, optionally takes a
     *      color.  No new line.
     * WriteLine - Writes to the console with a new line at the end.  
     *      optionally takes a color.
     * Custom - allows you to create custom logs, you can input the
     *      label (EX: API, WARN.. etc)  it is recommended to keep it
     *      within 5 characters to make sure it looks good with everything
     *      else.  This also takes in a message and optionally a color.
     * Info - Meant for logging informational things, such as when your
     *      program is finished loading.
     * Debug - Meant to log debug information into the console.  Stuff that
     *      you might not want printing into the console when the project is
     *      done.
     * NonCriticalWarn - this function is for any warning that is something 
     *      that may not be an actual problem.
     * Warning - Meant for any warnings you put in place that may actually be
     *      causing some sort of issue or error
     * Error - Meant to log errors that have been caught by a try/catch or any
     *      other errors you want to log without crashing the program.
     *      
     * msg - the message you want to send.
     */
    public class PConsole
    {
        /// <summary>
        /// Logs any API messages to the console.  It
        /// must be set via your API, and not all APIs
        /// will support doing such a thing.
        /// </summary>
        /// <param name="msg">The message that you want to send.</param>
        public static void API(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"[ API\t] - {msg}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Write directly into the console.  Without a newline character
        /// at the end.
        /// </summary>
        /// <param name="msg">The message you want to send</param>
        /// <param name="color">The color you want the message to be.</param>
        public static void Write(string msg, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write($"{msg}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Write directly into the console.  Without a newline character
        /// at the end.
        /// </summary>
        /// <param name="msg">The message you want to send</param>
        public static void Write(string msg)
        {
            Console.Write($"{msg}");
        }

        /// <summary>
        /// Writes a line into the console.
        /// </summary>
        /// <param name="msg">The message you want to send</param>
        /// <param name="color">The color you want the message to be.</param>
        public static void WriteLine(string msg, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"{msg}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Writes a line into the console.
        /// </summary>
        /// <param name="msg">The message you want to send.</param>
        public static void WriteLine(string msg)
        {
            Console.WriteLine($"{msg}");
        }

        /// <summary>
        /// A custom logging message.
        /// </summary>
        /// <param name="label">EX: WARN, ERR, DEBUG</param>
        /// <param name="msg">The message you want to send</param>
        public static void Custom(string label, string msg)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"[ {label.ToUpper()}\t] - {msg}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// A custom logging message.
        /// </summary>
        /// <param name="label">EX: WARN, ERR, DEBUG</param>
        /// <param name="msg">The message you want to send</param>
        /// <param name="color">the color you want the text to be</param>
        public static void Custom(string label, string msg, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"[ {label.ToUpper()}\t] - {msg}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Logs information about what the program is doing
        /// or where it is at at the current time.
        /// </summary>
        /// <param name="msg">The message you want to send.</param>
        public static void Info(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"[ INFO\t] - {msg}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Logs debug information.
        /// </summary>
        /// <param name="msg">The message you want to send.</param>
        public static void Debug(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"[ DEBUG\t] - {DateTime.Now.TimeOfDay.ToString().Split(".")[0]} {msg}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Shows less debug than the normal Warn() function, but serves
        /// the same purpose otherwise.
        /// </summary>
        /// <param name="msg">The message you want to send</param>
        public static void NonCriticalWarn(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[ WARN\t] - {msg}");
            Console.ForegroundColor = ConsoleColor.White;
        }

#pragma warning disable CS8602
        /// <summary>
        /// any warnings you put in place that may actually be causing some sort of issue or error
        /// </summary>
        /// <param name="msg">The message you want to send.</param>
        public static void Warning(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[ WARN\t] - {DateTime.Now.TimeOfDay.ToString().Split(".")[0]} {msg} at {new StackFrame(1).GetMethod().Name}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// log errors that have been caught by a try/catch or any other errors you want to log
        /// </summary>
        /// <param name="msg">The message you want to send.</param>
        public static void Error(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[ ERROR\t] - {DateTime.Now.TimeOfDay.ToString().Split(".")[0]} {msg} at {new StackFrame(1).GetMethod().Name}");
            Console.ForegroundColor = ConsoleColor.White;
        }
#pragma warning restore CS8602
    }
}
