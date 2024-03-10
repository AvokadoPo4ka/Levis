using HiSystems.Interpreter;

namespace LevisV2.Functions
{
    public class Func_degree : Function
    {
        public override string Name
        {
            get
            {
                return "degree";
            }
        }

        public override Literal Execute(IConstruct[] arguments)
        {
            base.EnsureArgumentCountIs(arguments, 2);

            decimal numberValue = base.GetTransformedArgument<Number>(arguments, argumentIndex: 0);

            decimal degreeValue = base.GetTransformedArgument<Number>(arguments, argumentIndex: 1);

            int outValue = int.Parse(numberValue.ToString()) ^ int.Parse(degreeValue.ToString());

            return new Number((decimal)outValue);
        }
    }
}
