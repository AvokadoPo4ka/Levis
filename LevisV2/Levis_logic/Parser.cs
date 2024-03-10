using HiSystems.Interpreter;
using LevisV2.Levis_logic.Enums;
using LevisV2.Relief;

namespace LevisV2.Levis_logic
{
    public class Parser : BetterMethods
    {
        public static void Parse(string file)
        {
            Console.Clear();
            string[] lines = File.ReadAllLines(file);
            try
            {
                foreach (string line in lines)
                {
                    AnalyzeCode(line);
                }
            }
            catch (Exception ex)
            {
                Debug.Error($"{ErrorTypes.InternalError} - {ex.ToString()}");
            }
        }
        private static void AnalyzeCode(string test)
        {
            Engine en = new Engine();
            foreach (Function func in FunctionsList.functions)
            {
                en.Register(func);
            }
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
                Debug.Warn("I have troubles with \"Set\" method. Try again later...");
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
                Debug.Warn("I have troubles with \"Get\" method. Try again later...");
                /*if (Variables.Get(splitValues[0], varValue))
                {
                    Debug.Log($"There is a {splitValues[0]} with {varValue} in it!");
                }*/
            }
            else if (test == "All_vars")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Variables.Get_all();
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Debug.Error($"{ErrorTypes.Unknown}: {test}!");
            }
        }
    }
}