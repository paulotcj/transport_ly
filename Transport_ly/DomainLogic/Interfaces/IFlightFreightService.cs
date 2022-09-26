using Transport_ly.Model;
using Transport_ly.Model.DTO;

namespace Transport_ly.DomainLogic.Interfaces
{
    public interface IFlightFreightService : IConsolePrintAsync
    {
        FlightFreightResult BuildFreight(IEnumerable<FlightSchedule> flightSchedules, IEnumerable<Order> orders);

        Task<FlightFreightResult> BuildFreightAsync();
    }
}
