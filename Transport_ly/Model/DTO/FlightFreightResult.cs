using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport_ly.Model.DTO
{
    public class FlightFreightResult
    {
        public IEnumerable<FlightFreight> FlightFreights { get; set; }

        public IEnumerable<Order> OrdersNotPicked { get; set; }

    }
}
