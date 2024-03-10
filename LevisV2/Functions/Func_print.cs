using HiSystems.Interpreter;

namespace LevisV2.Functions
{
    public class Func_print : Function
    {
        public override string Name
        {
            get
            {
                return "print";
            }
        }

        public override Literal Execute(IConstruct[] arguments)
        {
            base.EnsureArgumentCountIs(arguments, 1);
            string commandOutput = base.GetTransformedArgument<Text>(arguments, argumentIndex: 0);

            return new Text(commandOutput);
        }

    }
}
