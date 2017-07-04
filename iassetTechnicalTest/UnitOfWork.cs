using System;
using iassetTechnicalTest.Domain;
using iassetTechnicalTest.Domain.Repositories;
using iassetTechnicalTest.Repositories;
using iassetTechnicalTest.Domain.Helpers;

namespace iassetTechnicalTest
{
    public class UnitOfWork : IUnitOfWork
    {
        private IGWSoapServiceClient _gwSoapServiceClient;
        private readonly GWServiceAddress _serviceAddress;
        private readonly TimeSpan _operationTimeOut;

        public UnitOfWork(GWServiceAddress serviceAddress, TimeSpan operationTimeOut)
        {
            _serviceAddress = serviceAddress;
            _operationTimeOut = operationTimeOut;
        }

        public IGWSoapServiceClient GWSoapServiceClient
            =>
                _gwSoapServiceClient ??
                (_gwSoapServiceClient = new GwSoapServiceClient(_serviceAddress, _operationTimeOut));

        public void Dispose()
        {
            _gwSoapServiceClient = null;
        }
    }
}