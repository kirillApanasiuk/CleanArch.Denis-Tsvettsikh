using AutoMapper;
using DataAccess.Interface;
using Infrastructure.Interfaces.Integrations;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Interfaces.WebApp;
using WebApp.Interfaces;

namespace UseCases.Order.Commands.Create
{
    class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IDbContext _dbContext;
        private readonly IBackgroundJobService _backgroundJobService;
        private readonly ICurrentUserService _currentUserService;

        public CreateOrderCommandHandler(
            IMapper mapper,
            IDbContext dbContext, 
            IBackgroundJobService backgroundJobService,
            ICurrentUserService currentUserService)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _backgroundJobService = backgroundJobService;
            _currentUserService = currentUserService;
        }
        public async Task<int> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<Domain.Entities.Order>(command.Dto);
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();

            _backgroundJobService.Schedule<IEmailService>(eService=>
                eService.SendAsync(
                    _currentUserService.Email,
                    "Order created",
                    $"Order {order.Id} created")
                );
            return order.Id;
        }
    }
}
