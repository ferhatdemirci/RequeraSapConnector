using System;


namespace RequeraSapConnector
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public class RfcEnumValueAttribute : Attribute
    {
        public string Value { get; private set; }
        public RfcEnumValueAttribute(string value)
        {
            this.Value = value;
        }
    }
}
