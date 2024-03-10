using HiSystems.Interpreter;
using LevisV2.Levis_logic;
using LevisV2.Levis_logic.Enums;
using LevisV2.Relief;

namespace LevisV2
{
    public class Program : BetterMethods
    {
        static string ProgramName = $"Levis Compilator for {Levis.Name} {Levis.Version}";

        static string EnterTxtPath = "enter.txt";
        static void Main(string[] args)
        {
            if (Levis.IsModded())
            {
                Console.Title = "[MODED]" + ProgramName;
            }
            else
            {
                Console.Title = ProgramName;
            }


            using (StreamReader sr = new StreamReader(EnterTxtPath))
            {
                string text = sr.ReadToEnd();
                Console.ForegroundColor = ConsoleColor.Green;
                CoolText(text);
                Thread.Sleep(10);
                Console.ForegroundColor = ConsoleColor.White;
            }
            print("");
            print("Should be debug enabled?");

            Console.ForegroundColor = ConsoleColor.Cyan;

            Thread.Sleep(1);

            Console.Write(">");
            string answer = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.White;
            switch (answer.ToLower())
            {
                case "y":
                    Levis.Debug = true;
                    break;
                case "n":
                    Levis.Debug = false;
                    break;
                default:
                    print("Can't get your answer! It'll be false!");
                    Levis.Debug = false;
                    break;
            }

            print("Enter path to file/Enter \"here\" to code here: ");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Thread.Sleep(1);
            Console.Write(">");

            string path = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            if (path == "here")
            {
                try
                {
                    print("Press CTRL+C/Close window to stop coding!");
                    WaitForSeconds(5);
                    Console.Clear();

                    while (true)
                    {
                        Engine en = new Engine();
                        foreach (Function func in FunctionsList.functions)
                        {
                            en.Register(func);
                        }
                        string test = Console.ReadLine();
                        if (test.Contains("print"))
                        {
                            var res = en.Parse(test).Execute<Text>();
                            Console.ForegroundColor = ConsoleColor.Green;
                            print(res);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (test.Contains("+") || test.Contains("-") || test.Contains("/") || test.Contains("*"))
                        {
                            var res = en.Parse(test).Execute<Number>();
                            Console.ForegroundColor = ConsoleColor.Green;
                            print(res);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (test.Contains("^"))
                        {
                            var res = en.Parse(test).Execute<Number>();
                            Console.ForegroundColor = ConsoleColor.Green;
                            print(res);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (test.Contains(">") || test.Contains("<") || test.Contains("=="))
                        {
                            if (test.Contains("=="))
                            {
                                string newtext = test.Replace("==", "=");
                                var res = en.Parse(newtext).Execute<HiSystems.Interpreter.Boolean>();
                                Console.ForegroundColor = ConsoleColor.Green;
                                print(res);
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                var res = en.Parse(test).Execute<HiSystems.Interpreter.Boolean>();
                                Console.ForegroundColor = ConsoleColor.Green;
                                print(res);
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                        }
                        else if (test.StartsWith("Negate"))
                        {
                            var res = en.Parse(test).Execute<Number>();
                            Console.ForegroundColor = ConsoleColor.Green;
                            print(res);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (test.StartsWith("Set"))
                        {
                            int startIndex = test.IndexOf("(");
                            int endIndex = test.IndexOf(")");
                            if (startIndex == -1 || endIndex == -1 || endIndex < startIndex)
                            {
                                Debug.Error($"{ErrorTypes.Unknown}");
                                return;
                            }
                            string values = test.Substring(startIndex + 1, endIndex - startIndex - 1);
                            string[] splitValues = values.Split(',');
                            var varValue = splitValues[1].Substring(1);
                            //Variables.Set(splitValues[0], varValue);
                            print($"Sucefully set {splitValues[0]} to {varValue}");
                        }
                        else if (test.StartsWith("Get"))
                        {
                            int startIndex = test.IndexOf("(");
                            int endIndex = test.IndexOf(")");
                            if (startIndex == -1 || endIndex == -1 || endIndex < startIndex)
                            {
                                Debug.Error($"{ErrorTypes.Unknown}");
                                return;
                            }
                            string values = test.Substring(startIndex + 1, endIndex - startIndex - 1);
                            string[] splitValues = values.Split(',');
                            var varValue = splitValues[1].Substring(1);
                            /*if (Variables.Get(splitValues[0], varValue))
                            {
                                Debug.Log($"There is a {splitValues[0]} with {varValue} in it!");
                            }*/
                        }
                        else if (test == "All_vars")
                        {
                            Variables.Get_all();
                        }
                        else
                        {
                            Debug.Error($"{ErrorTypes.Unknown}: {test}!");
                        }
                    }

                }
                catch (Exception ex)
                {
                    Debug.Error($"{ErrorTypes.InternalError} - {ex.ToString()}");
                }

            }
            else
            {
                try
                {
                    if (path != null || path != "" && TextAnalyzer.AnalyzeExtension(path))
                    {
                        TextAnalyzer.AnalyzeText(path);
                    }
                }
                catch (Exception e)
                {
                    Debug.Error($"{ErrorTypes.InternalError} - {e.ToString()}");
                }
            }

        }
    }
}