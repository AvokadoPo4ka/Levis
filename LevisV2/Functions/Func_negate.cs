using HiSystems.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevisV2.Functions
{
    public class Func_negate : Function
    {
        public override string Name
        {
            get
            {
                return "Negate";
            }
        }

        public override Literal Execute(IConstruct[] arguments)
        {
            base.EnsureArgumentCountIs(arguments, 1);

            decimal inputValue = base.GetTransformedArgument<Number>(arguments, argumentIndex: 0);

            return new Number(-inputValue);
        }
    }
}
