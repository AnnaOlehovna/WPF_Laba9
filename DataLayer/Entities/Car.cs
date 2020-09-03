namespace DataLayer.Entities
{
    public class Car
    {
        private string color;

        public string Color
        {
            get
            {
                if (color == null)
                {
                    return "Unknown";
                }
                else
                {
                    return color;
                }
            }

            set => color = value;
        }

        public int CarId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string FileName { get; set; }
        public int TransportId { get; set; }       

        public override string ToString()
        {
            return string.Format("id = {0} - Brand: {1}, Model: {2}, Year: {3}, Color: {4}", CarId, Brand, Model, Year, Color);
        }

    }

}
