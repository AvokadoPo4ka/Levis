using HiSystems.Interpreter;
using LevisV2.Functions;

namespace LevisV2.Levis_logic.Enums
{
    public static class FunctionsList
    {
        public static List<Function> functions = new List<Function>() { new Func_print(), new Func_negate(), new Func_set(), new Func_degree() };
    }
}
