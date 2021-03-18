using System.Threading.Tasks;
using Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UseCases.Order.Commands.Create;
using UseCases.Order.Queries.GetById;

namespace CleanArchStartingProject.Controllers
{
    [Route("mobile/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ISender _sender;
        public OrdersController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("{id}")]
        public async Task<OrderDto> Get(int id)
        {
            var result = await _sender.Send(new GetOrderByIdQuery {  Id= id });
            return result;
        }

        [HttpPost]
        public async Task<int> Create([FromBody] CreateOrderDto dto)
        {
            var id = await _sender.Send(new CreateOrderCommand { Dto = dto });
            return id;
        }

    }
}
