using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace RequeraSapConnector
{
    public class RfcParameter
    {
        public string Name { get; private set; }
        public object Value { get; private set; }

        public RfcParameter(string name, object value)
        {
            this.Name = name;// name.ToUpper(new CultureInfo("en-US", false));
            this.Value = value;
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}", this.Name, this.Value);
        }
    }
}
