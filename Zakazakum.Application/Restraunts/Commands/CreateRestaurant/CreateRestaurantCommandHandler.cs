using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Zakazakum.Application.Common.Interfaces;
using Zakazakum.Domain.Entities;

namespace Zakazakum.Application.Restraunts.Commands.CreateRestaurant
{
	public class CreateRestaurantCommandHandler : IRequestHandler<CreateRestaurantCommand, CreateRestaurantVm>
	{
		private readonly IZakazakumContext _context;

		public CreateRestaurantCommandHandler(IZakazakumContext context)
		{
			_context = context;
		}

		public async Task<CreateRestaurantVm> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
		{
			var entity = new Restaurant
			{
				Id = new System.Guid(),
				Title = request.Title
			};

			_context.Restaurants.Add(entity);

			await _context.SaveChangesAsync(cancellationToken);

			var result = new CreateRestaurantVm()
			{
				Id = entity.Id
			};

			return result;
		}
}
}
