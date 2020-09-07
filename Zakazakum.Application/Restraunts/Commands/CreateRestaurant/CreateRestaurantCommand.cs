using MediatR;

namespace Zakazakum.Application.Restraunts.Commands.CreateRestaurant
{
	public class CreateRestaurantCommand : IRequest<CreateRestaurantVm>
	{
		public string Title { get; set; }
	}
}
