using Domain;
using DomainServices.Interfaces;
using System;
using System.Linq;

namespace DomainServices.Implementation
{
    public class OrderDomainService : IOrderDomainService
    {
        public decimal GetTotal(Order order)
        {
            return order.Items.Sum(x => x.Quantity * x.Product.Price);
        }
    }
}
