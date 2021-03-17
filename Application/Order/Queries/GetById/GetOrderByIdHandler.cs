﻿using Application;
using AutoMapper;
using DataAccess.Interface;
using DomainServices.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace UseCases.Order.Queries.GetById
{
    public class GetOrderByIdHandler:IRequestHandler<GetOrderByIdQuery,OrderDto>
    {
        private readonly IMapper _mapper;
        private readonly IDbContext _dbContext;
        private readonly IOrderDomainService _orderDomainService;

        public GetOrderByIdHandler(IMapper mapper,IDbContext dbContext,IOrderDomainService orderDomainService)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _orderDomainService = orderDomainService;
        }
        public async Task<OrderDto> Handle(GetOrderByIdQuery query, CancellationToken cancellationToken)
        {
            var order = await _dbContext.Orders
                .AsNoTracking()
                .Include(x => x.Items)
                    .ThenInclude(x => x.Product)
                .FirstOrDefaultAsync(x => x.Id == query.Id);

            if (order == null)
            {
                throw new EntityNotFoundException();
            }

            var dto = _mapper.Map<OrderDto>(order);
            dto.Total = _orderDomainService.GetTotal(order);
            return dto;
        }
    }
   
}
