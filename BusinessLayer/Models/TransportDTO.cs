using System.Collections.ObjectModel;

namespace BusinessLayer.Models
{
    public class TransportDTO
    {

        public int TransportId { get; set; }
        public string TransportName { get; set; }
        public string TransportDescription { get; set; }
        public ObservableCollection<CarDTO> Cars
        { get; set; }
    }
}
