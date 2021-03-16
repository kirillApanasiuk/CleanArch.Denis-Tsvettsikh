using Domain;
using System;

namespace DomainServices.Interfaces
{
    public interface IOrderDomainService
    {
        decimal GetTotal(Order order);
    }
}
