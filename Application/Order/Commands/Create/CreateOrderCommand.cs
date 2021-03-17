using Application;
using MediatR;

namespace UseCases.Order.Commands.Create
{
    public class CreateOrderCommand:IRequest<int>
    {
        public CreateOrderDto Dto{ get; set; }
    }
}
