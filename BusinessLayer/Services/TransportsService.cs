using AutoMapper;
using BusinessLayer.Models;
using DataLayer.Entities;
using DataLayer.Interfaces;
using DataLayer.Repositories;
using System;
using System.Collections.ObjectModel;

namespace BusinessLayer.Services
{
    public class TransportsService : ITransportsService
    {
        IUnitOfWork dataBase;
        IMapper mapperDTOToEntity;
        IMapper mapperEntityToDTO;

        public TransportsService(string name)
        {
            dataBase = new EntityUnitOfWork(name);

            mapperDTOToEntity = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TransportDTO, Transport>();
                cfg.CreateMap<CarDTO, Car>();
            }).CreateMapper();

            mapperEntityToDTO = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Transport, TransportDTO>();
                cfg.CreateMap<Car, CarDTO>();
            }).CreateMapper();

        }

        public void AddCarToTransport(int transportId, CarDTO carDTO)
        {
            Transport transport = dataBase.Transports.Get(transportId);
            Car car = mapperDTOToEntity.Map<Car>(carDTO);
            car.TransportId = transportId;
            transport.Cars.Add(car);
            dataBase.Save();
        }

        public void CreateCar(CarDTO carDTO)
        {
            dataBase.Cars.Create(mapperDTOToEntity.Map<Car>(carDTO));
            dataBase.Save();
        }

        public void CreateTransport(TransportDTO transportDTO)
        {
            Transport transport = mapperDTOToEntity.Map<Transport>(transportDTO);
            dataBase.Transports.Create(transport);
            dataBase.Save();
        }

        public void DeleteCar(int carId)
        {
            dataBase.Cars.Delete(carId);
            dataBase.Save();
        }

        public void DeleteTransport(int transportId)
        {
            dataBase.Transports.Delete(transportId);
            dataBase.Save();
        }


        public ObservableCollection<TransportDTO> GetAll()
        {
            ObservableCollection<TransportDTO> transports = mapperEntityToDTO.Map<ObservableCollection<TransportDTO>>(dataBase.Transports.GetAll());
            return transports;
        }

        public void RemoveCarFromTransport(int transportId, int carId)
        {
            Transport transport = dataBase.Transports.Get(transportId);
            transport.Cars.Remove(dataBase.Cars.Get(carId));
            dataBase.Transports.Update(transport);
            dataBase.Cars.Delete(carId);
            dataBase.Save();
        }

        public void UpdateCar(int transportId, CarDTO carDTO)
        {
            var car = mapperDTOToEntity.Map<Car>(carDTO);
            car.TransportId = transportId;
            dataBase.Cars.Update(car);
            dataBase.Save();
        }

        public void UpdateTransport(TransportDTO transportDTO)
        {
            dataBase.Transports.Update(mapperDTOToEntity.Map<Transport>(transportDTO));
            dataBase.Save();
        }


    }
}
