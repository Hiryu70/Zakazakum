﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Zakazakum.Application.Common.Interfaces;

namespace Zakazakum.Application.Orders.Queries.GetOrders
{
	public class OrdersListQueryHandler : IRequestHandler<GetOrdersListQuery, OrdersListVm>
	{
		private readonly IZakazakumContext _context;
		private readonly IMapper _mapper;

		public OrdersListQueryHandler(IZakazakumContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<OrdersListVm> Handle(GetOrdersListQuery request, CancellationToken cancellationToken)
		{
			var orders = await _context.Orders
				.Include(o => o.Restaurant)
				.Include(o => o.Owner)
				.OrderByDescending(o => o.Created)
				.ToListAsync(cancellationToken);

			if (request.OrderStatus != null)
			{
				orders = orders.Where(o => o.OrderStatus == request.OrderStatus).ToList();
			}

			var ordersVm = _mapper.Map<List<GetOrdersVm>>(orders);

			var vm = new OrdersListVm
			{
				Orders = ordersVm
			};

			return vm;
		}
	}
}
