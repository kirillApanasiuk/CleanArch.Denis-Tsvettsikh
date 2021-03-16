using AutoMapper;
using DataAccess.Interface;
using DomainServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Application
{
    public class OrderService : IOrderService
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IOrderDomainService _orderService;

        public OrderService(IDbContext dbContext,IMapper mapper,IOrderDomainService orderService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _orderService = orderService;
        }
        public async Task<OrderDto> GetByIdAsync(int id)
        {
            var order = await _dbContext.Orders
                .AsNoTracking()
                .Include(x => x.Items)
                    .ThenInclude(x => x.Product)
                .FirstOrDefaultAsync(x => x.Id == id);

            if(order == null)
            {
                throw new EntityNotFoundException();
            }

            var dto = _mapper.Map<OrderDto>(order);
            dto.Total = _orderService.GetTotal(order);
            return dto;
        }
    }
}
