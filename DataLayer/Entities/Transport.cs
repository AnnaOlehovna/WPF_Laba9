using System.Collections.Generic;

namespace DataLayer.Entities
{
    public class Transport
    {

        // навигационное свойство
        public List<Car> Cars { get; set; }

        public Transport()
        {

            Cars = new List<Car>();
        }
        public int TransportId { get; set; }
        public string TransportName { get; set; }
        public string TransportDescription { get; set; }
       
    }
}
