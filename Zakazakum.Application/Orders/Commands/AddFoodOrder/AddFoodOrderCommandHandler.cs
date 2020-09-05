using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Zakazakum.Application.Common.Interfaces;
using Zakazakum.Domain.Entities;

namespace Zakazakum.Application.Orders.Commands.AddFoodOrder
{
	public class AddFoodOrderCommandHandler : IRequestHandler<AddFoodOrderCommand>
	{
		private readonly IZakazakumContext _context;

		public AddFoodOrderCommandHandler(IZakazakumContext context)
		{
			_context = context;
		}

		public async Task<Unit> Handle(AddFoodOrderCommand request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
