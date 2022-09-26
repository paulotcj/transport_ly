using System.ComponentModel.DataAnnotations;

namespace Transport_ly.Model
{
    public class FlightSchedule
    {
        [Required]
        public int FlightNum { get; set; }

        [Required]
        public string Departure { get; set; }

        [Required]
        public string Arrival { get; set; }

        [Required]
        public int Day { get; set; }

        [Required]
        public int Capacity { get; set; }

        [Required]
        public bool IsReturnFlight { get; set; }


    }
}
