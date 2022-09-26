using System.ComponentModel.DataAnnotations;

namespace Transport_ly.Model
{
    public class FlightFreight
    {
        [Required]
        public FlightSchedule FlightSchedule { get; set; }

        public IEnumerable<Order> Orders { get; set; }

        [Required]
        public int RemainingCapacity { get; set; }
    }
}
