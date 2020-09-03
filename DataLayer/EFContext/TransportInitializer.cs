using DataLayer.Entities;
using System.Collections.Generic;
using System.Data.Entity;

namespace DataLayer.EFContext
{
    class TransportInitializer : CreateDatabaseIfNotExists<TransportsContext>
    {
        protected override void Seed(TransportsContext context)
        {
            context.Transports.AddRange(new Transport[] {
                new Transport { TransportDescription="Автомобиль с числом мест для сидения более девяти, включая место водителя.",
                    TransportName ="Автобус",
                    Cars =new List<Car> {
                        new Car {Brand = "MAN", Model = "Lion's City", Year = 2002, Color = "Красный", FileName = "man_lion.jpg"},
                        new Car {Brand = "MAN", Model = "A13", Year = 2000, Color = "Серебристый", FileName = "man_a13.jpg"},
                        new Car {Brand = "Scania", Model = "Irizar К380", Year = 2008, Color = "Белый", FileName = "scania.jpg"}
                    }
                },
                new Transport { TransportDescription="Двухколёсное механическое транспортное средство с двигателем рабочим объёмом 50 куб. сантиметров и более.",
                    TransportName ="Мотоцикл",
                    Cars =new List<Car>{
                        new Car {Brand = "Yamaha", Model = "FJR 1300A", Year = 2007, Color = "Бордовый", FileName = "yamaha.jpg"},
                        new Car {Brand = "Honda", Model = "CB 600", Year = 2005, Color = "Оранжевый", FileName = "honda_cb600.jpg"},
                        new Car {Brand = "Honda", Model = "NC 700", Year = 2014, Color = "Черный", FileName = "honda_nc700.jpg"}
                    }
                },
                new Transport { TransportDescription="Четырехколесное механическое транспортное средство.",
                    TransportName ="Автомобиль",
                    Cars =new List<Car>{
                       new Car {Brand = "Mazda", Model = "6", Year = 2014, Color = "Синий", FileName = "mazda_6.jpg"},
                       new Car {Brand = "Audi", Model = "Q7", Year = 2010, Color = "Белый", FileName = "audi_q7.jpg"},
                       new Car {Brand = "Toyota", Model = "Corolla", Year = 2017, Color = "Белый", FileName = "toyota_corolla.jpg"},
                       new Car {Brand = "Toyota", Model = "Camry", Year = 2012, Color = "Серый", FileName = "toyota_camry.jpg"}                  
                    }
                }

            });
        }
    }
}

