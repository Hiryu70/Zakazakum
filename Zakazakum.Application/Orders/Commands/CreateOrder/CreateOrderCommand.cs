using System;
using MediatR;

namespace Zakazakum.Application.Orders.Commands.CreateOrder
{
	public class CreateOrderCommand : IRequest<CreateOrderVm>
	{
		public Guid RestaurantId { get; set; }

		public Guid OwnerId { get; set; }
	}
}
