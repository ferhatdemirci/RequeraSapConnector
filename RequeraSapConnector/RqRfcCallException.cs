using System;


namespace RequeraSapConnector
{
    public class RqRfcCallException : RqRfcException
    {
        public string RequestBody { get; private set; }

        public RqRfcCallException(string message, string requestBody)
            : this(message, requestBody, null)
        {
        }

        public RqRfcCallException(string message, Exception innerException)
            : this(message, null, innerException)
        {
        }

        public RqRfcCallException(string message, string requestBody, Exception innerException)
            : base(message, innerException)
        {
            this.RequestBody = requestBody;
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(this.RequestBody))
                return base.ToString();

            return string.Format("{0} Request Body was: {1}", base.ToString(), this.RequestBody);
        }
    }
}

