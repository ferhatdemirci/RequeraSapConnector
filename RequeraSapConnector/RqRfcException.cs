using System;


namespace RequeraSapConnector
{
    [Serializable]
    public class RqRfcException : Exception
    {
        public RqRfcException(string message)
            : base(message)
        {

        }

        public RqRfcException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
