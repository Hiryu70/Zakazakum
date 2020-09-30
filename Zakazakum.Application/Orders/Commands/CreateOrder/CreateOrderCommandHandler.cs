using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Zakazakum.Application.Common.Interfaces;
using Zakazakum.Domain.Entities;
using Zakazakum.Domain.Enums;

namespace Zakazakum.Application.Orders.Commands.CreateOrder
{
	public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderVm>
	{
		private readonly IZakazakumContext _context;

		public CreateOrderCommandHandler(IZakazakumContext context)
		{
			_context = context;
		}

		public async Task<CreateOrderVm> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
		{
			var restaurant = await _context.Restaurants.FirstAsync(r => r.Id == request.RestaurantId);
			var user = await _context.Users.FirstAsync(u => u.Id == request.OwnerId);

			var entity = new Order
			{
				Restaurant = restaurant,
				Owner = user,
				OrderStatus = OrderStatus.Open,
				Created = DateTime.Now
			};

			_context.Orders.Add(entity);

			await _context.SaveChangesAsync(cancellationToken);

			var vm = new CreateOrderVm
			{
				OrderId = entity.Id
			};

			return vm;
		}
	}
}
