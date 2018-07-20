using System;
using System.Drawing;
using System.IO;
using RequeraSapConnector.Native;
using RequeraSapConnector;
using Test.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Test.TestCases
{
    public class Native_SimpleTestCase : RfcReadTestCase
    {
        protected override SapConnection GetConnection()
        {
            return new NativeSapRfcConnection("FEP");
        }
    }

    public abstract class RfcReadTestCase
    {
        protected abstract SapConnection GetConnection();

        [Fact]
        public void ReadListRfcTest()
        {
            using (SapConnection baglanti = this.GetConnection() )
            {
                var result = baglanti.ExecuteFunction("ZBDT_SD_GRUP_TESLIMAT_BILGI", new
                {
                    I_VBELN_S = "8500016389",
                    I_VBELN_E = "8500016389"
                });
                List<ZTeslimat> teslimat = new List<ZTeslimat>();

                teslimat = result.GetTable<ZTeslimat>("T_LISTE").ToList();

                Assert.Equal(2, teslimat.Count());

            }
        }
    }
}
