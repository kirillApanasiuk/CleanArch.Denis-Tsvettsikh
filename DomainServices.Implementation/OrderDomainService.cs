using Domain.Entities;
using DomainServices.Interfaces;
using System.Linq;

namespace DomainServices.Implementation
{
    public class OrderDomainService : IOrderDomainService
    {
        public decimal GetTotal(Order order,CalculateDeliveryCost calcDeliveryCost)
        {
            var totalPrice =  order.Items.Sum(x => x.Quantity * x.Product.Price);
            decimal deliveryCost = 0;
            if(totalPrice < 1000) 
            {
                var totalWeight = order.Items.Sum(x => x.Quantity * x.Product.Weight);
                deliveryCost = calcDeliveryCost(totalWeight);
            }
            return totalPrice + deliveryCost;
        }
    }
}
