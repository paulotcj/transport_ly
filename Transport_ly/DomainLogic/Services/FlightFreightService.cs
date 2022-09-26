using Transport_ly.Data.Interfaces;
using Transport_ly.DomainLogic.Interfaces;
using Transport_ly.Model;
using Transport_ly.Model.DTO;

using Consts = Transport_ly.Auxiliaries.Constants.FlightFreightConsts;

namespace Transport_ly.DomainLogic.Services
{
    public class FlightFreightService : IFlightFreightService
    {

        private readonly IOrderRepository _orderRepository;
        private readonly IFlightScheduleRepository _flightRepository;

        public FlightFreightService(IOrderRepository orderRepository, IFlightScheduleRepository flightRepository)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository)); ;
            _flightRepository = flightRepository ?? throw new ArgumentNullException(nameof(flightRepository)); ;
        }

        public async Task<FlightFreightResult> BuildFreightAsync()
        {
            IEnumerable<FlightSchedule> flightSchedules = _flightRepository.GetCollection(null);
            IEnumerable<Order> orders = await _orderRepository.GetCollectionAsync(null);

            return BuildFreight(flightSchedules: flightSchedules, orders: orders);
        }


        //exposing this method would make it easier for unit testing
        public FlightFreightResult BuildFreight(IEnumerable<FlightSchedule> flightSchedules, IEnumerable<Order> orders )
        {
            FlightFreightResult result = new();

            //-----------
            //Items in these lists will be manipulated (added or removed), and as a good practice, and to play it safe
            // the reference objects should not be manipulated
            List<FlightSchedule> listFlightSchedules = flightSchedules
                .OrderBy(x => x.FlightNum )
                .ToList<FlightSchedule>();
            
            List<Order> listOrders = orders
                .OrderBy(x => x.Priority)
                .ToList<Order>();

            //-----------

            List<FlightFreight> listFlightFreight = listFlightSchedules
                .Select(x => new FlightFreight() { FlightSchedule = x, RemainingCapacity = x.Capacity, Orders = null })
                .ToList();

            //-----------

            foreach (FlightFreight item in listFlightFreight)
            {
                List<Order> listOrderTemp = new();
                item.Orders = listOrderTemp;

                while (item.RemainingCapacity > 0)
                {
                    Order order = listOrders
                        .FirstOrDefault(x => x.Destination.Equals(item.FlightSchedule.Arrival));

                    if (order == null) { break; } //in case there's no order matching or no order left

                    listOrderTemp.Add(order);
                    listOrders.Remove(order);

                    item.RemainingCapacity -= order.Volume;

                } //while end


            } // foreach end

            //-----------

            result.FlightFreights = listFlightFreight;
            result.OrdersNotPicked = listOrders;

            return result;

        }




        public async Task PrintToConsoleAsync()
        {
            FlightFreightResult result = await BuildFreightAsync();

            //orders scheduled
            foreach ( FlightFreight flightFreight in result.FlightFreights )
            {
                foreach ( Order order in flightFreight.Orders)
                {
                    Console.WriteLine($"order: {order.OrderIdentifier}, flightNumber: {flightFreight.FlightSchedule.FlightNum}, departure: {flightFreight.FlightSchedule.Departure}, arrival: {flightFreight.FlightSchedule.Arrival}, day:{flightFreight.FlightSchedule.Day} ");
                }
            }


            //orders not scheduled
            foreach (Order order in result.OrdersNotPicked)
            {
                Console.WriteLine($"order: {order.OrderIdentifier}, flightNumber: {Consts.NotScheduled}");
            }
        }



    }
}
