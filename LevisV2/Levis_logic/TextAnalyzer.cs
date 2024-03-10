using LevisV2.Levis_logic.Enums;
using LevisV2.Relief;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevisV2.Levis_logic
{
    public class TextAnalyzer : BetterMethods
    {
        /// <summary>
        /// Checks file extension
        /// </summary>
        public static bool AnalyzeExtension(string fileName)
        {
            try
            {
                string ext = Path.GetExtension(fileName);
                if (ext == Levis.FileExtension)
                {
                    print("Trying to load...");
                    return true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Debug.Error($"{ErrorTypes.WrongExtension}");
                    Console.ForegroundColor = ConsoleColor.White;
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Thread.Sleep(10);
                Debug.Error($"{ErrorTypes.InternalError} - {ex.ToString()}");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }

        }
        /// <summary>
        /// Cheks text and turn it to C#
        /// </summary>
        public static void AnalyzeText(string path)
        {
            try
            {
                string filePath = path;
                string[] lines = File.ReadAllLines(filePath);
                if (lines.Length == 0)
                {
                    using (StreamWriter sw = new StreamWriter(filePath, false))
                    {
                        print($"You can find documentation at {Levis.WebSite}");
                        WaitForSeconds(60);
                        sw.WriteLine($"You can find documentaion at {Levis.WebSite}");
                        return;
                    }
                }
                else
                {
                    Parser.Parse(path);
                }

            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Thread.Sleep(10);
                Debug.Error($"{ErrorTypes.InternalError} - {ex.ToString()}");
                Console.ForegroundColor = ConsoleColor.White;
            }

        }
    }
}
