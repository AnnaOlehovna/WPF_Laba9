using BusinessLayer.Models;
using System.Collections.ObjectModel;

namespace DataLayer.Interfaces
{
    public interface ITransportsService
    {       
        ObservableCollection<TransportDTO> GetAll();        
        void AddCarToTransport(int transportId, CarDTO car);
        void RemoveCarFromTransport(int transportId, int carId);
        void CreateTransport(TransportDTO transportDTO);
        void DeleteTransport(int transportId);
        void UpdateTransport(TransportDTO transportDTO);
        void CreateCar(CarDTO carDTO);
        void DeleteCar(int carId);
        void UpdateCar(int transportId, CarDTO carDTO);
    }
}
