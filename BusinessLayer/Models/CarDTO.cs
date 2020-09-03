namespace BusinessLayer.Models
{
    public class CarDTO
    {
        public CarDTO()
        {
            FileName = "no_photo.jpg";
            Year = 2000;
        }

        public int CarId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string FileName { get; set; }
        public string Color { get; set; }

    }
}
