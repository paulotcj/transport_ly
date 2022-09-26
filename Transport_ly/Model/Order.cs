using System.ComponentModel.DataAnnotations;


namespace Transport_ly.Model
{
    public class Order
    {
        [Required]
        public string OrderIdentifier { get; set; }

        [Required]
        public string Origin { get; set; }

        [Required]
        public string Destination { get; set; }

        [Required]
        public int Volume { get; set; }

        [Required]
        public int Priority { get; set; }
    }
}
