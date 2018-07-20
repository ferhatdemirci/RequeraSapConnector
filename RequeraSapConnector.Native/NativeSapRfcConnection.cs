using SAP.Middleware.Connector;
using System;

namespace RequeraSapConnector.Native
{
    public class NativeSapRfcConnection : SapConnection
    {
        public RfcRepository Repository
        {
            get
            {
                this.EnsureConnectionIsOpen();
                return this.repository;
            }
        }

        public RfcDestination Destination
        {
            get
            {
                this.EnsureConnectionIsOpen();
                return this.destination;
            }
        }

        public NativeSapRfcConnection(string destinationName)
        {
            this.destinationName = destinationName;
            this.structureMapper = new NativeRfcStructureMapper(new NativeRfcValueMapper());
        }

        private void EnsureConnectionIsOpen()
        {
            if (!isOpen)
            {
                try
                {
                    this.destination = RfcDestinationManager.GetDestination(destinationName);
                    this.repository = this.destination.Repository;
                    this.isOpen = true;
                }
                catch (Exception ex)
                {
                    throw new RqRfcCallException("Could not connect to SAP.", ex);
                }
            }
        }

        public override RfcPreparedFunction PrepareFunction(string functionName)
        {
            EnsureConnectionIsOpen();
            return new NativeRfcPreparedFunction(functionName, this.structureMapper, this.Repository, this.Destination);
        }

        public override void Dispose()
        {

        }

        private string destinationName;
        private bool isOpen = false;
        private RfcRepository repository;
        private RfcDestination destination;
        private NativeRfcStructureMapper structureMapper;

        public override RfcStructureMapper GetStructureMapper()
        {
            return this.structureMapper;
        }

        public override void SetTimeout(int timeout)
        {
            //there is no timeout for plain rfc
        }
    }
}
