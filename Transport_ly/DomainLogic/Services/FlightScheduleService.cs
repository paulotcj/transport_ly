using Transport_ly.Data.Interfaces;
using Transport_ly.DomainLogic.Interfaces;
using Transport_ly.Model;

namespace Transport_ly.DomainLogic.Services
{
    public class FlightScheduleService : IFlightScheduleService
    {

        private readonly IFlightScheduleRepository _flightRepository;

        public FlightScheduleService(IFlightScheduleRepository flightRepository)
        { 
            _flightRepository = flightRepository ?? throw new ArgumentNullException(nameof(flightRepository));
        }

        public void PrintToConsole()
        {
            IEnumerable<FlightSchedule> flights = _flightRepository.GetCollection(param: new() { IsReturnFlight = false });
            
            //the example below will select non-return flights arriving in Toronto (YYZ)
            //IEnumerable<FlightSchedule> flights = _flightRepository.Get(param: new() { IsReturnFlight = false, Arrival = "YYZ" }); 


            foreach (var i in flights)
            {
                Console.WriteLine($"Flight: {i.FlightNum}, departure: {i.Departure}, arrival: {i.Arrival}, day: {i.Day}");
            }


        }


    }
}
