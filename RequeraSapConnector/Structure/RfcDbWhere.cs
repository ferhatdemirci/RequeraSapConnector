

namespace RequeraSapConnector.Structure
{
    public class RfcDbWhere
    {
        [RfcStructureField("TEXT")]
        public string Text { get; set; }

        public RfcDbWhere()
        {

        }

        public RfcDbWhere(string text)
        {
            this.Text = text;
        }
    }
}
