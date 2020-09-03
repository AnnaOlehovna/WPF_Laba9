using DataLayer.EFContext;
using DataLayer.Entities;
using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Data.Entity.Migrations;

namespace DataLayer.Repositories
{
    class TransportsRepository : IRepository<Transport>
    {
        TransportsContext context;
        public TransportsRepository(TransportsContext context)
        {
            this.context = context;
        }

        public void Create(Transport t)
        {
            context.Transports.Add(t);
        }

        public void Delete(int id)
        {
            var group = context.Transports.Find(id);
            context.Transports.Remove(group);
        }
        public IEnumerable<Transport> Find(Func<Transport, bool> predicate)
        {
            return context
            .Transports
            .Include(t => t.Cars)
            .Where(predicate)
            .ToList();
        }

        public Transport Get(int id)
        {
            return context.Transports.Find(id);
        }

        public IEnumerable<Transport> GetAll()
        {
            return context.Transports.Include(t => t.Cars);
        }

        public void Update(Transport t)
        {
            context.Set<Transport>().AddOrUpdate(t);
        }
    }
}
