using System;

namespace Zakazakum.Application.Orders.Commands.UpdateDeliveryCost
{
	public class UserPaidStatusVm
	{
		public bool IsPaid { get; set; }

		public Guid UserId { get; set; }
	}
}
