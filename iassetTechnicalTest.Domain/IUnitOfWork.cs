using System;
using iassetTechnicalTest.Domain.Repositories;

namespace iassetTechnicalTest.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        IGWSoapServiceClient GWSoapServiceClient { get; }
    }
}