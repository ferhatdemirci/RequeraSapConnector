using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Generic;
using System.Linq;

namespace RequeraSapConnector.Metadata
{
    public class StructureMetadata
    {

        public string Name { get; private set; }
        public IEnumerable<FieldMetadata> Fields { get; private set; }

        public StructureMetadata(string name, IEnumerable<FieldMetadata> fields)
        {
            this.Name = name;
            this.Fields = fields;
        }

        public FieldMetadata GetField(string name)
        {
            var field = this.Fields.FirstOrDefault(x => x.Name == name.ToUpper());
            if (field == null)
                throw new RqRfcException(string.Format("Structure {0} does not have field named {1}.", this.Name, name));

            return field;
        }
    }
}
