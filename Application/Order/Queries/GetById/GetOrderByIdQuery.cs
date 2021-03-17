using Application;
using MediatR;

namespace UseCases.Order.Queries.GetById
{
    public class GetOrderByIdQuery:IRequest<OrderDto>
    {
        public int Id { get; set; }
    }
}
