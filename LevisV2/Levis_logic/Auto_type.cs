using HiSystems.Interpreter;
using LevisV2.Levis_logic.Enums;
using LevisV2.Relief;

namespace LevisV2.Levis_logic
{
    public class Auto_type : BetterMethods
    {
        public static void GetType(string test)
        {
            Engine en = new Engine();
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
}