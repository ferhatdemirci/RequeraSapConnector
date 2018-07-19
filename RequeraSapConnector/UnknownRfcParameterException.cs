using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequeraSapConnector
{
    public class UnknownRfcParameterException : RqRfcException
    {
        public UnknownRfcParameterException(string parameterName, string functionName)
            : base(string.Format("Parameter {0} was not found on function {1}.", parameterName, functionName))
        {
        }
    }
}
