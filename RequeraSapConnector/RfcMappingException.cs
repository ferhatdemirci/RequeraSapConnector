using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequeraSapConnector
{
    public class RfcMappingException : RqRfcException
    {
        public RfcMappingException(string message)
            : base(message)
        {

        }
    }
}
