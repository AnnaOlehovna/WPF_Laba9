using DataLayer.EFContext;
using DataLayer.Entities;
using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DataLayer.Repositories
{
    class CarsRepository : IRepository<Car>
    {
        TransportsContext context;
        public CarsRepository(TransportsContext context)
        {
            this.context = context;
        }

        public void Create(Car t)
        {
            context.Cars.Add(t);
        }

        public void Delete(int id)
        {
            var car = Get(id);
            context.Cars.Remove(car);
        }
        public IEnumerable<Car> Find(Func<Car, bool> predicate)
        {
            return context
            .Cars         
            .Where(predicate)
            .ToList();
        }

        public Car Get(int id)
        {
            return context.Cars.Find(id);
        }

        public IEnumerable<Car> GetAll()
        {
            return context.Cars;
        }

        public void Update(Car t)
        {
            context.Set<Car>().AddOrUpdate(t);
        }
    }
}
