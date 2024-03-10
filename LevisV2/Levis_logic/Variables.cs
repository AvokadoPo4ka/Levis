using HiSystems.Interpreter;
using LevisV2.Relief;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevisV2.Levis_logic
{
    public class Variables : BetterMethods
    {
        public string Name { get; set; }
        public decimal NumValue { get; set; }
        //public string StrValue { get; set; }
        public Variables(string Name, decimal NumValue)
        {
            this.Name = Name;
            this.NumValue = NumValue;
        }
        /*public Variables(string Name, string StrValue)
        {
            this.Name = Name;
            this.StrValue = StrValue;
        }*/
        public static List<Variables> VarsList = new List<Variables>() { new Variables("one", 1) };


        public static void Set(string varName, decimal varValue)
        {
            VarsList.Add(new Variables(varName, varValue));
        }
        /*public static void Set(string varName, string StrValue)
        {
            VarsList.Add(new Variables(varName, StrValue));
        }*/
        public static bool Get(string varName, decimal varValue)
        {
            if (VarsList.Contains(new Variables(varName, varValue)))
                return true;
            else
            {
                Debug.Error($"There is no var called {varName}!");
                return false;
            }
        }
        /*public static bool Get(string varName, string varValue)
        {
            if (VarsList.Contains(new Variables(varName, varValue)))
                return true;
            else
            {
                Debug.Error($"There is no var called {varName}!");
                return false;
            }
        }*/
        public static void Get_all()
        {
            foreach (Variables vars in VarsList)
            {
                print($"{vars.Name} exist");
            }
        }
    }
}
