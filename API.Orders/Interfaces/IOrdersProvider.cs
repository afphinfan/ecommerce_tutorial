using API.Orders.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Orders.Interfaces
{
    public interface IOrdersProvider
    {
        Task<(bool IsSuccess, IEnumerable<Order> Orders, string ErrorMessage)> GetOrdersAsync(int customerId);
    }
}
