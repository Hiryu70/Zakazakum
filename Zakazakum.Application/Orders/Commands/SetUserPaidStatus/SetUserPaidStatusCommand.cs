using MediatR;
using System;

namespace Zakazakum.Application.Orders.Commands.UpdateDeliveryCost
{
	public class SetUserPaidStatusCommand : IRequest
	{
		public int OrderId { get; set; }

		public bool IsPaid { get; set; }

		public Guid UserId { get; set; }
	}
}
