using System;

namespace Zakazakum.Application.Orders.Commands.SetUserPaidStatus
{
	public class UserPaidStatusVm
	{
		public bool IsPaid { get; set; }

		public Guid UserId { get; set; }
	}
}
