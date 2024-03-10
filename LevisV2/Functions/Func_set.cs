using HiSystems.Interpreter;
using LevisV2.Levis_logic;

namespace LevisV2.Functions
{
    public class Func_set : Function
    {
        public override string Name
        {
            get
            {
                return "Set";
            }
        }

        public override Literal Execute(IConstruct[] arguments)
        {
            Engine en = new Engine();
            base.EnsureArgumentCountIs(arguments, 2);
            string varName = base.GetTransformedArgument<Text>(arguments, argumentIndex: 0);
            var varValue = base.GetTransformedArgument<Number>(arguments, argumentIndex: 1);

            Variables.Set(varName, varValue);
            return null;
        }
    }
}
