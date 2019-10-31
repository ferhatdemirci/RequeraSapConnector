# RequeraSapConnector
This is DotNet SAP Sap connector

SAP Connecting Example


#Configure your SAP connecting on Web.config file

```xml
<configuration>
  <configSections>
    <sectionGroup name="SAP.Middleware.Connector">
      <section name="GeneralSettings" type="SAP.Middleware.Connector.RfcGeneralConfiguration,sapnco" />
      <sectionGroup name="ClientSettings">
        <section name="DestinationConfiguration" type="SAP.Middleware.Connector.RfcDestinationConfiguration, sapnco"/>
      </sectionGroup>
    </sectionGroup>
  </configSections>
  
  <SAP.Middleware.Connector>
    <ClientSettings>
      <DestinationConfiguration>
        <destinations >
          <add NAME="FED" USER="RFCUserName" PASSWD="RFC_Password" CLIENT="001"
             LANG="EN" ASHOST="SAP_HostIPorName" SYSNR="00" />
        </destinations>
      </DestinationConfiguration>
    </ClientSettings>
  </SAP.Middleware.Connector>
</configuration>
```

Get Data from RFC..

```C#
using (SapConnection sapConnection = new NativeSapRfcConnection("FEP"))
            {
                var result = sapConnection.ExecuteFunction("ZBDT_SD_SOME_RFC", new
                {
                    I_VBELN_S = "8500012222",
                    I_VBELN_E = "8500012333"
                });
                List<ZDelivery> delivery = new List<ZDelivery>();

                teslimat = result.GetTable<ZDelivery>("T_LISTE").ToList();               
                //DataTable dt = new DataTable();
                //dt = result.GetTableRFC("T_LISTE"); //Get Data without Model(Model kullanmadan direk DataTable içerisine alır)
            }
```

```C#
public class ZDelivery
    {
        public string WERKS { get; set; }
        public string VBELN { get; set; }
        public string POSNR { get; set; }
        public DateTime WADAT_IST { get; set; }
        public string UEPOS { get; set; }
        public decimal LFIMG { get; set; }
        public string MATNR { get; set; }
        public string DDTEXT { get; set; }
        public string BSTKD { get; set; }
        public string BSTKD_E { get; set; }
        public string SERNR { get; set; }
        public string MAKTX { get; set; }

    }
````

Modelleme için yukarıdaki gibi RFC alan isimleri verilebileceği gibi, Class içerisinde kendi isimlerinize map edebilirsiniz.

You can map SAP structure field with database column on model class.

Example / Örnek:
```C#
    public class Partners
    {
        [RfcStructureField("MANDT")]
        public int Client { get; set; }
        [RfcStructureField("SPRAS")]
        public string Lang { get; set; }
        [RfcStructureField("PARVW")]
        public string PartnerType { get; set; }
        [RfcStructureField("VTEXT")]
        public string Name { get; set; }
    }
```
Direk Tablo'yu almak için aşağıdaki örneği kullanınız.

There's also a shortcut to the RFC_READ_TABLE function.
You can use it like this:

```C#
using (SapConnection sapConnection = new NativeSapRfcConnection("FEP"))
            {
                ASPxGridView2.DataSource= sapConnection.ReadTable<Partners>("TPART",null,null,0,500);
                ASPxGridView2.DataBind();               
            }
```
https://youtu.be/04F53SUiGw0
