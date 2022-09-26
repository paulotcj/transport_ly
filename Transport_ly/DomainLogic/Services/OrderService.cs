using Transport_ly.Data.Interfaces;
using Transport_ly.DomainLogic.Interfaces;
using Transport_ly.Model;

using Consts = Transport_ly.Auxiliaries.Constants.LocationsConsts;

namespace Transport_ly.DomainLogic.Services
{
    public class OrderService : IOrderService
    {

        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        }

        public async Task PrintToConsoleAsync()
        {
            IEnumerable<Order> orders = await _orderRepository.GetCollectionAsync(param: null);


            foreach (var i in orders)
            {
                string auxDest = null , auxOrigin = null;

                if (Consts.Locations.ContainsKey(i.Origin))
                { auxOrigin = Consts.Locations[i.Origin]; }
                else { auxOrigin = Consts.LocationError; }

                if (Consts.Locations.ContainsKey(i.Destination))
                { auxDest = Consts.Locations[i.Destination]; }
                else { auxDest = Consts.LocationError; }


                Console.WriteLine($"OrderIdentifier: {i.OrderIdentifier}, origin: {i.Origin} ({auxOrigin}), destination: {i.Destination} ({auxDest}), volume: {i.Volume}, Priority: {i.Priority}");
            }


        }

    }
}
