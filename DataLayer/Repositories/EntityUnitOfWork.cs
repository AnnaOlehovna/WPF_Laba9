using DataLayer.EFContext;
using DataLayer.Entities;
using DataLayer.Interfaces;
using System;

namespace DataLayer.Repositories
{
   public class EntityUnitOfWork : IUnitOfWork
    {
        TransportsContext context;
        TransportsRepository transportsRepository;
        CarsRepository carsRepository;

        public EntityUnitOfWork(string name)
        {
            context = new TransportsContext(name);
        }

        public IRepository<Transport> Transports
        {
            get
            {
                if (transportsRepository == null)
                    transportsRepository = new TransportsRepository(context);
                return transportsRepository;
            }
        }

        public IRepository<Car> Cars
        {
            get
            {
                if (carsRepository == null)
                    carsRepository = new CarsRepository(context);
                return carsRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }
        
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)                   
            {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
