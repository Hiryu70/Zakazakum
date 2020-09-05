using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Zakazakum.Application.Common.Interfaces;
using Zakazakum.Domain.Entities;

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
			var restaurants = await _context.Restaurants.ToListAsync(cancellationToken);
			var restaurant = restaurants.First(r => r.Id == request.RestaurantId);

			var users = await _context.Users.ToListAsync(cancellationToken);
			var user = users.First(u => u.Id == request.OwnerId);

			var entity = new Order
			{
				Restaurant = restaurant,
				Owner = user,
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
