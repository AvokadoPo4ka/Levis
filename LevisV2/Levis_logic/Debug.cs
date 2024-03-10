using LevisV2.Relief;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevisV2.Levis_logic
{
    public class Debug : BetterMethods
    {
        /// <summary>
        /// Log something
        /// </summary>
        /// <param name="message">What should it send</param>
        public static void Log(object message)
        {
            if (!Levis.Debug)
            {
                return;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                print($"[DEBUG] {message}");
                Thread.Sleep(10);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        /// <summary>
        /// Throw error
        /// </summary>
        /// <param name="error">What error it should throw</param>
        public static void Error(object error)
        {
            if (!Levis.Debug)
            {
                return;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                print($"[ERROR] {error}");
                Thread.Sleep(10);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        /// <summary>
        /// Throw warn
        /// </summary>
        /// <param name="warn">What should it throw</param>
        public static void Warn(object warn)
        {
            if (!Levis.Debug)
            {
                return;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                print($"[WARN] {warn}");
                Thread.Sleep(10);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
