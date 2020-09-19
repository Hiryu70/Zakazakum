using System;

namespace Zakazakum.Application.Orders.Commands.DeleteFoodOrder
{
	public class DeleteFoodOrderVm
	{
		public Guid Id { get; set; }

		public Guid UserId { get; set; }
	}
}
