using System.Globalization;
using System.Threading;

namespace RequeraSapConnector.Native
{
    public class NativeRfcValueMapper : RfcValueMapper
    {
        protected override NumberFormatInfo GetNumberFormat()
        {
            return Thread.CurrentThread.CurrentCulture.NumberFormat;
        }
    }
}
