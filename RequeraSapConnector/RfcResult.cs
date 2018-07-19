using System.Collections.Generic;
using System.Data;

namespace RequeraSapConnector
{
    public abstract class RfcResult
    {
        public abstract T GetOutput<T>(string name);
        public abstract IEnumerable<T> GetTable<T>(string name);
        public abstract DataTable GetTableRFC(string name);
    }
}
