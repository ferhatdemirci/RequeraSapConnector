# RequeraSapConnector
This is DotNet SAP Sap connector for Requera BI 

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
          <add NAME="FED" USER="RFCKullanıcıAdiniz" PASSWD="RFC_Şifresi" CLIENT="001"
             LANG="EN" ASHOST="SAP_Sunucusu" SYSNR="00" />
        </destinations>
      </DestinationConfiguration>
    </ClientSettings>
  </SAP.Middleware.Connector>
</configuration>
```

Get Data from RFC..

```C#
using (SapConnection baglanti = new NativeSapRfcConnection("FEP"))
            {
                var result = baglanti.ExecuteFunction("ZBDT_SD_GRUP_TESLIMAT_BILGI", new
                {
                    I_VBELN_S = "8500016389",
                    I_VBELN_E = "8500016389"
                });
                List<ZTeslimat> teslimat = new List<ZTeslimat>();

                teslimat = result.GetTable<ZTeslimat>("T_LISTE").ToList();               
                //DataTable dt = new DataTable();
                //dt = result.GetTableRFC("T_LISTE"); //Get Data without Model(Model kullanmadan direk DataTable içerisine alır)
            }
```

```C#
public class ZTeslimat
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
    public class Muhataplar
    {
        [RfcStructureField("MANDT")]
        public int Client { get; set; }
        [RfcStructureField("SPRAS")]
        public string Dil { get; set; }
        [RfcStructureField("PARVW")]
        public string MuhatapRolu { get; set; }
        [RfcStructureField("VTEXT")]
        public string Tanim { get; set; }
    }
```
Direk Tablo'yu almak için aşağıdaki örneği kullanınız.

There's also a shortcut to the RFC_READ_TABLE function.
You can use it like this:

```C#
using (SapConnection baglanti = new NativeSapRfcConnection("FEP"))
            {
                ASPxGridView2.DataSource= conn.ReadTable<Muhataplar>("TPART",null,null,0,500);
                ASPxGridView2.DataBind();               
            }
```
https://youtu.be/04F53SUiGw0
