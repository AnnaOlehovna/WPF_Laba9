using DataLayer.Entities;
using System;

namespace DataLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Car> Cars { get; }
        IRepository<Transport> Transports { get; }
        void Save();
    }
}
