using SAP.Middleware.Connector;
using System;
using System.Collections.Generic;
using System.Data;

namespace RequeraSapConnector.Native.Extension
{
    public static class IRfcTableExtentions
    {
        /// <summary>
        /// Converts SAP table to .NET DataTable table
        /// </summary>
        /// <param name="sapTable">The SAP table to convert.</param>
        /// <param name="tableName">Table Name </param>
        /// <returns></returns>
        public static DataTable ToDataTable(this IRfcTable sapTable, string tableName = null)
        {
            DataTable adoTable = new DataTable(tableName);
            //... Create ADO.Net table.
            for (int liElement = 0; liElement < sapTable.ElementCount; liElement++)
            {
                RfcElementMetadata metadata = sapTable.GetElementMetadata(liElement);
                adoTable.Columns.Add(metadata.Name, GetDataType(metadata.DataType));
            }

            //Transfer rows from SAP Table ADO.Net table.
            foreach (IRfcStructure row in sapTable)
            {
                DataRow ldr = adoTable.NewRow();
                for (int liElement = 0; liElement < sapTable.ElementCount; liElement++)
                {
                    RfcElementMetadata metadata = sapTable.GetElementMetadata(liElement);

                    switch (metadata.DataType)
                    {
                        case RfcDataType.DATE:
                            ldr[metadata.Name] = row.GetString(metadata.Name).Substring(0, 4) + row.GetString(metadata.Name).Substring(5, 2) + row.GetString(metadata.Name).Substring(8, 2);
                            break;
                        case RfcDataType.BCD:
                            ldr[metadata.Name] = row.GetDecimal(metadata.Name);
                            break;
                        case RfcDataType.CHAR:
                            ldr[metadata.Name] = row.GetString(metadata.Name);
                            break;
                        case RfcDataType.STRING:
                            ldr[metadata.Name] = row.GetString(metadata.Name);
                            break;
                        case RfcDataType.INT2:
                            ldr[metadata.Name] = row.GetInt(metadata.Name);
                            break;
                        case RfcDataType.INT4:
                            ldr[metadata.Name] = row.GetInt(metadata.Name);
                            break;
                        case RfcDataType.FLOAT:
                            ldr[metadata.Name] = row.GetDouble(metadata.Name);
                            break;
                        default:
                            ldr[metadata.Name] = row.GetString(metadata.Name);
                            break;
                    }
                }
                adoTable.Rows.Add(ldr);
            }
            return adoTable;
        }

        private static Type GetDataType(RfcDataType rfcDataType)
        {

            switch (rfcDataType)
            {
                case RfcDataType.DATE:
                    return typeof(string);
                case RfcDataType.CHAR:
                    return typeof(string);
                case RfcDataType.STRING:
                    return typeof(string);
                case RfcDataType.BCD:
                    return typeof(decimal);
                case RfcDataType.INT2:
                    return typeof(int);
                case RfcDataType.INT4:
                    return typeof(int);
                case RfcDataType.FLOAT:
                    return typeof(double);
                default:
                    return typeof(string);
            }
        }

        public static DataTable RfcGetTableToDataTable(this IRfcTable sapTable, string tableName = null, List<SapImportModel> fields = null)
        {
            fields = fields ?? new List<SapImportModel>();
            DataTable adoTable = new DataTable(tableName);

            for (int i = 0; i < fields.Count; i++)
                adoTable.Columns.Add(fields[i].value);

            foreach (IRfcStructure row in sapTable)
            {
                DataRow ldr = adoTable.NewRow();
                string[] fieldValue = row.GetString("WA").Split(';');

                for (int liElement = 0; liElement < fields.Count; liElement++)
                {
                    ldr[liElement] = fieldValue[liElement].ToString();
                }
                adoTable.Rows.Add(ldr);
            }

            return adoTable;
        }
    }
    public class SapImportModel
    {
        public string importFieldName { get; set; }
        public string value { get; set; }
        public string type { get; set; }
        public string sapfieldtype { get; set; }
        public string sapimporttablename { get; set; }
        public string dynamicValue { get; set; }
    }
}
