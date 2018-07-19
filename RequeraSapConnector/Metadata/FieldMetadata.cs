using RequeraSapConnector.Types;

namespace RequeraSapConnector.Metadata
{
    public class FieldMetadata
    {
        public string Name { get; private set; }
        public AbapDataType DataType { get; private set; }

        public FieldMetadata(string name, AbapDataType dataType)
        {
            this.Name = name;
            this.DataType = dataType;
        }
    }
}
