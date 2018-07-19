using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequeraSapConnector
{
    public abstract class RfcFunctionObject<T>
    {
        public abstract string FunctionName { get; }
        public abstract T GetOutput(RfcResult result);

        public virtual object Parameters
        {
            get { return null; }
        }
    }
}
