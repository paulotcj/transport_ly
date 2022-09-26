using Transport_ly.Data.Repository;
using Transport_ly.Model;

namespace Transport_ly.Data.Interfaces
{
    public interface IOrderRepository  : IRepositoryAsync<Order, OrderRepositoryParameters>
    {
    }
}
